using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Areas.Identity.ViewsModels;

namespace Web.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class RolController : Controller
    {
        private readonly RoleManager<IdentityRole> _gestionRoles;
        private readonly UserManager<IdentityUser> _gestionUsuarios;

        public RolController(RoleManager<IdentityRole> gestionRoles, UserManager<IdentityUser> gestionUsuarios)
        {
            this._gestionRoles = gestionRoles;
            this._gestionUsuarios = gestionUsuarios;
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
        public async Task<IActionResult> EditarRol(string id)
        {
            var rol = await _gestionRoles.FindByIdAsync(id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con ID = {id} no fue encontrado";
                return View("Error");
            }

            var model = new EditarRolViewModel
            {
                Id = rol.Id,
                RolNombre = rol.Name
            };

            foreach (var usuario in _gestionUsuarios.Users)
            {
                if (await _gestionUsuarios.IsInRoleAsync(usuario, rol.Name))
                {
                    model.Usuarios.Add(usuario.UserName);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditarRol(EditarRolViewModel model)
        {
            var rol = await _gestionRoles.FindByIdAsync(model.Id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {model.Id} no encontrado";
                return View("Error");
            }
            else
            {
                rol.Name = model.RolNombre;

                var result = await _gestionRoles.UpdateAsync(rol);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListarRoles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> EliminarRol(string id)
        {
            var rol = await _gestionRoles.FindByIdAsync(id);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con ID = {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                try
                {
                    var result = await _gestionRoles.DeleteAsync(rol);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListarRoles");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View("ListarRoles");
                }
                catch (DbUpdateException ex)
                {
                    ViewBag.ErrorTitle = $"El rol {rol.Name} está siendo utilizado";
                    ViewBag.ErrorMessage = $"El rol {rol.Name} no puede ser eliminado porque contiene usuarios. Antes de eliminar el rol quita los usuarios de dicho rol.";
                    return View("ErrorBorrarRol");
                }
            }
        }
        public async Task<IActionResult> EditarUsuarioRol(string rolId)
        {
            ViewBag.roleId = rolId;

            var role = await _gestionRoles.FindByIdAsync(rolId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {rolId} no encontrado";
                return View("Error");
            }

            var model = new List<UsuarioRolViewModel>();

            foreach (var user in _gestionUsuarios.Users)
            {
                var usuarioRol = new UsuarioRolViewModel
                {
                    UsuarioId = user.Id,
                    UsuarioNombre = user.UserName
                };

                if (await _gestionUsuarios.IsInRoleAsync(user, role.Name))
                {
                    usuarioRol.EstaSeleccionado = true;
                }
                else
                {
                    usuarioRol.EstaSeleccionado = false;
                }
                model.Add(usuarioRol);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditarUsuarioRol(List<UsuarioRolViewModel> model, string rolId)
        {
            var rol = await _gestionRoles.FindByIdAsync(rolId);

            if (rol == null)
            {
                ViewBag.ErrorMessage = $"Rol con el ID = {rolId} no encontrado";
                return View("Error");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await _gestionUsuarios.FindByIdAsync(model[i].UsuarioId);

                IdentityResult result = null;

                if (model[i].EstaSeleccionado && !(await _gestionUsuarios.IsInRoleAsync(user,rol.Name)))
                {
                    result = await _gestionUsuarios.AddToRoleAsync(user, rol.Name);
                }
                else if (!model[i].EstaSeleccionado && await _gestionUsuarios.IsInRoleAsync(user,rol.Name))
                {
                    result = await _gestionUsuarios.RemoveFromRoleAsync(user, rol.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return RedirectToAction("EditarRol", new { Id = rolId });
                    }
                }
            }
            return RedirectToAction("EditarRol", new { Id = rolId });
        }
        public IActionResult ListarUsuarios()
        {
            var usuarios = _gestionUsuarios.Users;
            return View(usuarios);
        }
        public async Task<IActionResult> EditarUsuario(string id)
        {
            var usuario = await _gestionUsuarios.FindByIdAsync(id);
            if (usuario == null)
            {
                ViewBag.ErrorMessage = $"Usuario con ID = {id} no fue encontrado";
                return View("Error");
            }
            var usuarioClaims = await _gestionUsuarios.GetClaimsAsync(usuario);
            var usuarioRol = await _gestionUsuarios.GetRolesAsync(usuario);

            var model = new EditarUsuarioViewModel
            {
                Id = usuario.Id,
                Email = usuario.Email,
                NombreUsuario = usuario.UserName,
                Notificaciones = usuarioClaims.Select(c => c.Value).ToList(),
                Roles = usuarioRol
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditarUsuario(EditarUsuarioViewModel model)
        {
            var usuario = await _gestionUsuarios.FindByIdAsync(model.Id);

            if (usuario == null) 
            {
                ViewBag.ErrorMessage = $"Usuario con ID = {model.Id} no fue encontrado";
                return View("Error");
            }
            else
            {
                usuario.Email = model.Email;
                usuario.UserName = model.NombreUsuario;

                var resultado = await _gestionUsuarios.UpdateAsync(usuario);

                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListarUsuarios");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> BorrarUsuario(string id)
        {
            var user = await _gestionUsuarios.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"Usuario con ID = {id} no fue encontrado";
                return View("Error");
            }
            else
            {
                var resultado = await _gestionUsuarios.DeleteAsync(user);
                if (resultado.Succeeded)
                {
                    return RedirectToAction("ListarUsuarios");
                }

                foreach (var error in resultado.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListarUsuarios");
            }
        }
        public async Task<IActionResult> GestionarRolesUsuarios(string IdUsuario)
        {
            ViewBag.IdUsuario = IdUsuario;

            var user = await _gestionUsuarios.FindByIdAsync(IdUsuario);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"El usuario con ID : {IdUsuario} no se encontró";
                return View("Error");
            }

            var model = new List<RolUsuarioViewModel>();

            foreach (var rol in _gestionRoles.Roles)
            {
                var rolUsuarioModelo = new RolUsuarioViewModel()
                {
                    RolId = rol.Id,
                    RolNombre = rol.Name
                };

                if (await _gestionUsuarios.IsInRoleAsync(user,rol.Name))
                {
                    rolUsuarioModelo.EstaSeleccionado = true;
                }
                else
                {
                    rolUsuarioModelo.EstaSeleccionado = false;
                }
                model.Add(rolUsuarioModelo);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> GestionarRolesUsuarios(List<RolUsuarioViewModel>model,string IdUsuario)
        {
            var user = await _gestionUsuarios.FindByIdAsync(IdUsuario);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"El usuario con ID : {IdUsuario} no se encontró";
                return View("Error");
            }

            var roles = await _gestionUsuarios.GetRolesAsync(user);
            var result = await _gestionUsuarios.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No se puede eliminar usuarios con roles");
                return View(model);
            }
            result = await _gestionUsuarios.AddToRolesAsync(user, model.Where(u => u.EstaSeleccionado).Select(r => r.RolNombre));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "No se puede añadir los roles al usuario seleccionado");
                return View(model);
            }
            return RedirectToAction("EditarUsuario", new { Id = IdUsuario });
        }
    }
}
