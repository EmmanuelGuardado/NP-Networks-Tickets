using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Identity.ViewsModels;

namespace Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RolController : Controller
    {
        private readonly RoleManager<IdentityRole> _gestionRoles;

        public RolController(RoleManager<IdentityRole> gestionRoles)
        {
            this._gestionRoles = gestionRoles;
        }
        public IActionResult CrearRol()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CrearRol(RolViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole rol = new IdentityRole
                {
                    Name = model.NombreRol
                };

                var result = await _gestionRoles.CreateAsync(rol);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListarRoles", "Rol");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        public IActionResult ListarRoles()
        {
            var roles = _gestionRoles.Roles;
            return View(roles);
        }
    }
}
