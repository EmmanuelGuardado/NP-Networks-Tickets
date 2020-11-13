using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.ViewsModels
{
    public class RolUsuarioViewModel
    {
        public string RolId { get; set; }
        public string RolNombre { get; set; }
        public bool EstaSeleccionado { get; set; }
    }
}
