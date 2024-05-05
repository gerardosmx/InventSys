using InventSys.AccesoDatos.Data;
using InventSys.AccesoDatos.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.AccesoDatos.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task Agregar(T entidad)
        {
            await dbSet.AddAsync(entidad);
        }

        public async Task<T> Obtener(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> ObtenerTodos(Expression<Func<T, bool>> filtro = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string incluirProp = null,
            bool isTraking = true)
        {
            IQueryable<T> query = dbSet;
            if(filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirProp != null)
            {
                foreach(var incluirPropiedad in incluirProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirPropiedad);
                }
            }
            if(orderBy != null)
            {
                query = orderBy(query);
            }
            if(!isTraking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<T> ObtenerPrimero(
                Expression<Func<T, bool>> filtro = null,
                string incluirProp = null,
                bool isTraking = true)
        {
            IQueryable<T> query = dbSet;
            if (filtro != null)
            {
                query = query.Where(filtro);
            }
            if (incluirProp != null)
            {
                foreach (var incluirPropiedad in incluirProp.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirPropiedad);
                }
            }
            if (!isTraking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync();

        }
        public void Remover(T entidad)
        {
            dbSet.Remove(entidad);
        }

        public void RemoverRango(IEnumerable<T> entidades)
        {
            dbSet.RemoveRange(entidades);
        }
    }
}
