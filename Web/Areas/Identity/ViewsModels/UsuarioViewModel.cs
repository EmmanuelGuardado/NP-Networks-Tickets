using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Identity.ViewsModels
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        [EmailAddress]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Password)]
        [Display(Name ="Repetir Contraseña")]
        [Compare("Contrasena",ErrorMessage ="La contraseña no coincide")]
        public string ValidarContrasena { get; set; }
    }
}
