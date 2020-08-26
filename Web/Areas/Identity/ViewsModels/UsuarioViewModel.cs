using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.Areas.Identity.ViewsModels
{
    public class UsuarioViewModel
    {
        [Required]
        [EmailAddress]
        public string Usuario { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Repetir Contraseña")]
        [Compare("Contrasena",ErrorMessage ="La contraseña no coincide")]
        public string ValidarContrasena { get; set; }
    }
}
