using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.ViewsModels
{
    public class CambioContrasenaViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Contraseña Actual")]
        public string ContrasenaActual { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña")]
        public string NuevaContrasena { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nueva contraseña")]
        [Compare("NuevaContrasena",ErrorMessage ="La contraseña no coincide")]
        public string ConfirmarContrasena { get; set; }
    }
}
