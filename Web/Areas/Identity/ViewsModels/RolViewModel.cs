using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.ViewsModels
{
    public class RolViewModel
    {
        [Required(ErrorMessage ="Campo obligatorio")]
        [Display(Name ="Rol")]
        public string NombreRol { get; set; }
    }
}
