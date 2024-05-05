using InventSys.AccesoDatos.Data;
using InventSys.AccesoDatos.Repositorio.IRepositorio;
using InventSys.Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.AccesoDatos.Repositorio
{
    public class RAlmacen: Repositorio<MdAlmacen>, IAlmacen
    {
        private readonly ApplicationDbContext _db;
        public RAlmacen(ApplicationDbContext db): base(db)
        {
            _db = db;
        }
        public void Actualizar(MdAlmacen almacen)
        {
            var almacen_db = _db.KAlmacenes.FirstOrDefault(s => s.Id == almacen.Id);
            if(almacen_db != null)
            {
                almacen_db.Nombre = almacen.Nombre;
                almacen_db.Descrip = almacen.Descrip;
                almacen_db.Direccion = almacen.Direccion;
                almacen_db.Estado = almacen.Estado;
                _db.SaveChanges();
            }
            
        }
    }   
}
