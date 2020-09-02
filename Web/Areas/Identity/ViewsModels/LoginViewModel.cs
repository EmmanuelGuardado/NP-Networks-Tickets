using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.ViewsModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Campo obligatorio")]
        [EmailAddress]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
        [Display(Name ="Recuerdame")]
        public bool Recordarme { get; set; }
    }
}
