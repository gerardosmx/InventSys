using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventSys.Modelos.ViewModels
{
    public class MdAlmacen
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El Nombre del almaces es requerido")]
        [MaxLength(60,ErrorMessage = "La máxima longitud debe ser de 60 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "La descripción del almacén es requerida")]
        [MaxLength(200, ErrorMessage = "La máxima longitud debe ser de 200 caracteres")]
        public string Descrip { get; set; }
        [Required(ErrorMessage = "La dirección del almacén es requerida")]
        [MaxLength(300, ErrorMessage = "La máxima longitud debe ser de 300 caracteres")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "El Estado es requerido")]
        
        public bool Estado { get; set; }
    }
}
