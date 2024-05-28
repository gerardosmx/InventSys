using InventSys.AccesoDatos.Repositorio.IRepositorio;
using InventSys.Modelos.ViewModels;
using InventSys.Utilerias;
using Microsoft.AspNetCore.Mvc;

namespace InventSys.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AlmacenController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public AlmacenController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Almacen.ObtenerTodos();
            return Json(new { data = todos }); //data es el nombre llaado por javascript
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(int id)
        {
            var almacenDb = await _unidadTrabajo.Almacen.Obtener(id);
            if (almacenDb == null)
            {
                return Json(new { success = false, message = "Error al borrar almacen" });
            }
            _unidadTrabajo.Almacen.Remover(almacenDb);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Almacen borrado correctamente" });
        }

        [ActionName("ValidarNombre")]

        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Almacen.ObtenerTodos();
            if(id == 0)
            {
                valor = lista.Any(u => u.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(u => u.Nombre.ToLower().Trim() == nombre.ToLower().Trim() && u.Id != id);
            }
            return Json(new { data = valor });
        }

        #endregion

        #region Actualizar

        public async Task<IActionResult> Actualizar(int? id)
        {
            MdAlmacen almacen = new MdAlmacen();
            if (id == null)
            {
                almacen.Estado = true;
                return View(almacen);
            }
            
            almacen = await _unidadTrabajo.Almacen.Obtener(id.GetValueOrDefault());

            if (almacen == null)
            {
                return NotFound();
            }
            return View(almacen);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Validar que el token de seguridad sea valido y no se carguen datos desde otra página

        public async Task<IActionResult> Actualizar(MdAlmacen almacen)
        {
            if (ModelState.IsValid)
            {
                if (almacen.Id == 0)
                {
                    await _unidadTrabajo.Almacen.Agregar(almacen);
                    TempData[DS.Exitosa] = "Almacén creado exitosamente";
                }
                else
                {
                    _unidadTrabajo.Almacen.Actualizar(almacen); //ojo: no es await porque no devuelve una tarea
                    TempData[DS.Exitosa] = "Almacén actualizado exitosamente";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Fallida] = "Error al guardar el almacén";
            return View(almacen);
        }   

        #endregion
        

    }
}
