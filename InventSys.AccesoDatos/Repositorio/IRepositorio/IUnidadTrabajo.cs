﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo: IDisposable
    {
        IAlmacen Almacen { get; }
        Task Guardar();
    }
}
