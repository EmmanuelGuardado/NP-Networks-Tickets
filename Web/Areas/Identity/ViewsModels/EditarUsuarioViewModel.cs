using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.ViewsModels
{
    public class EditarUsuarioViewModel
    {
        public string Id { get; set; }
        [Required]
        public string NombreUsuario { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public List<string> Notificaciones { get; set; }
        public IList<string> Roles { get; set; }

        public EditarUsuarioViewModel()
        {
            Notificaciones = new List<string>();
            Roles = new List<string>();
        }
    }
}
