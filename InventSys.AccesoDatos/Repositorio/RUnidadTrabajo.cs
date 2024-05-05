using InventSys.AccesoDatos.Data;
using InventSys.AccesoDatos.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.AccesoDatos.Repositorio
{
    public class RUnidadTrabajo: IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IAlmacen Almacen { get; private set; }
        public RUnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Almacen = new RAlmacen(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
