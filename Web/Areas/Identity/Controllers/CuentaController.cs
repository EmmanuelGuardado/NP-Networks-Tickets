using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Web.Areas.Identity.ViewsModels;

namespace Web.Areas.Identity
{
    [Area("Identity")]
    public class CuentaController : Controller
    {
        private readonly UserManager<IdentityUser> _gestionUsuarios;
        private readonly SignInManager<IdentityUser> _gestionLogin;

        public CuentaController(UserManager<IdentityUser> gestionUsuarios, SignInManager<IdentityUser> gestionLogin)
        {
            this._gestionUsuarios = gestionUsuarios;
            this._gestionLogin = gestionLogin;
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioViewModel u)
        {
            if (ModelState.IsValid)
            {
                var usuario = new IdentityUser
                {
                    UserName = u.Usuario,
                    Email = u.Usuario
                };

                var resultado = await _gestionUsuarios.CreateAsync(usuario, u.Contrasena);

                if (resultado.Succeeded)
                {
                    await _gestionLogin.SignInAsync(usuario, isPersistent: false);
                    return RedirectToAction("Index", "Home", new { area = "Principal" });
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(u);
        }
    }
}
