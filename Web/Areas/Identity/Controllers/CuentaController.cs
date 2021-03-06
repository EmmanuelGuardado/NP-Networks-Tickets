﻿using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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
        public IActionResult Registro()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Registro(UsuarioViewModel model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new IdentityUser
                {
                    UserName = model.Usuario,
                    Email = model.Usuario
                };

                IdentityResult result = await _gestionUsuarios.CreateAsync(usuario, model.Contrasena);

                if (result.Succeeded)
                {
                    if (_gestionLogin.IsSignedIn(User) && User.IsInRole("Admin"))
                    {
                        return RedirectToAction("ListarUsuarios", "Cuenta");
                    }
                    await _gestionLogin.SignInAsync(usuario, isPersistent: false);
                    return RedirectToAction("Index", "Home", new { area = "Principal" });
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _gestionLogin.PasswordSignInAsync(model.Usuario, model.Contrasena, model.Recordarme, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Principal" });
                }
                ModelState.AddModelError(string.Empty, "Inicio de sesión no valido");
            }
            return View(model);
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CerrarSesion()
        {
            await _gestionLogin.SignOutAsync();
            return RedirectToAction("Login", "Cuenta");
        }

        public async Task<IActionResult> ComprobarEmail(string email)
        {
            var usuario = await _gestionUsuarios.FindByEmailAsync(email);

            if (usuario == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult AccesoDenegado()
        {
            return View();
        }
        public IActionResult CambiarContrasena()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CambiarContrasena(CambioContrasenaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _gestionUsuarios.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                var result = await _gestionUsuarios.ChangePasswordAsync(user, model.ContrasenaActual, model.NuevaContrasena);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
                await _gestionLogin.RefreshSignInAsync(user);
                return View("CambiarContrasenaConfirmacion");
            }
            return View(model);
        }
    }
}
