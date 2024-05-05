using InventSys.Modelos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.AccesoDatos.Repositorio.IRepositorio
{
    public interface IAlmacen: IRepositorio<MdAlmacen>
    {
        void Actualizar(MdAlmacen almacen);
    }
}
