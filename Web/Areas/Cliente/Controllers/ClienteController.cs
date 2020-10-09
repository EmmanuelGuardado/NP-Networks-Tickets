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
            IEnumerable<Clientes> clientes = _db.Clientes.ToList();
            return View(clientes);
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
                    int ubicacion_id = (_db.Ubicaciones.Max(x => x.UbicacionId) + 1);
                    int cliente_id = (_db.Clientes.Max(x => x.ClienteId) + 1);

                    var ubicacion = new Ubicaciones()
                    {
                        Nombre = modelo.Ubicaciones.Nombre,
                        Direccion1 = modelo.Ubicaciones.Direccion1,
                        Direccion2 = modelo.Ubicaciones.Direccion2,
                        Ciudad = modelo.Ubicaciones.Ciudad,
                        CodigoPostal = modelo.Ubicaciones.CodigoPostal,
                    };
                    var cliente = new Clientes()
                    {
                        Nombre = modelo.Clientes.Nombre,
                        Email = modelo.Clientes.Email,
                        FechaCreacion = modelo.Clientes.FechaCreacion,
                        Ubicacion_id = ubicacion_id
                    };
                    var contacto = new Contactos()
                    {
                        Nombre = modelo.Contactos.Nombre,
                        Email = modelo.Contactos.Email,
                        Telefono = modelo.Contactos.Telefono,
                        Cliente_id = cliente_id
                    };
                    _db.Ubicaciones.Add(ubicacion);
                    _db.Clientes.Add(cliente);
                    _db.Contactos.Add(contacto);                   
                    await _db.SaveChangesAsync();
                }
                return RedirectToAction("Index", "Home", new { area = "Principal" });
            }
            catch (Exception ex)
            {
                var mns = ex.Message;
                return View();
            }
        }
    }
}
