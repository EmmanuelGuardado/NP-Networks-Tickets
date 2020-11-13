using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Entidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.AccesoDatos.Data;
using Web.Areas.Cliente.ViewModels;

namespace Web.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ClienteController(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IActionResult ListarClientes()
        {
            var list = (from cliente in _db.Clientes
                        join contacto in _db.Contactos
                        on cliente.ClienteId equals contacto.ClienteId
                        select new ListaViewModel
                        {
                            NombreCliente = cliente.Nombre,
                            EmailCliente = cliente.Email,
                            NombreContacto = contacto.Nombre,
                            EmailContacto = contacto.Email,
                            TelefonoContacto = contacto.Telefono
                        }).ToList();
            return View(list);
        }
        public IActionResult CrearCliente()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CrearCliente(UbicacionClienteContactoViewModel modelo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var dbContexTransaction = _db.Database.BeginTransaction())
                    {
                        try
                        {
                            var ubicacion = new Ubicaciones()
                            {
                                Nombre = modelo.Ubicaciones.Nombre,
                                Direccion1 = modelo.Ubicaciones.Direccion1,
                                Direccion2 = modelo.Ubicaciones.Direccion2,
                                Ciudad = modelo.Ubicaciones.Ciudad,
                                CodigoPostal = modelo.Ubicaciones.CodigoPostal,
                            };
                            _db.Ubicaciones.Add(ubicacion);
                            var cliente = new Clientes()
                            {
                                Nombre = modelo.Clientes.Nombre,
                                Email = modelo.Clientes.Email,
                                FechaCreacion = modelo.Clientes.FechaCreacion,
                                Ubicacion = ubicacion
                            };
                            _db.Clientes.Add(cliente);
                            var contacto = new Contactos()
                            {
                                Nombre = modelo.Contactos.Nombre,
                                Email = modelo.Contactos.Email,
                                Telefono = modelo.Contactos.Telefono,
                                Cliente = cliente
                            };
                            _db.Contactos.Add(contacto);
                            await _db.SaveChangesAsync();

                            await dbContexTransaction.CommitAsync();
                        }
                        catch (Exception)
                        {
                            await dbContexTransaction.RollbackAsync();
                        }
                    }
                }
                return RedirectToAction("Index", "Home", new { area = "Principal" });
            }
            catch (Exception)
            {
                return View(modelo);
            }
        }
        public IActionResult EliminarCliente(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _db.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        //[HttpPost]
        //public async Task<IActionResult> EliminarCliente()
        //{

        //}
    }
}
