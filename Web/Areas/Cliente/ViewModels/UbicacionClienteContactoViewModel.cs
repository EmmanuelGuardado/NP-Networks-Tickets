using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidades.Modelos;

namespace Web.Areas.Cliente.ViewModels
{
    public class UbicacionClienteContactoViewModel
    {
        public Ubicaciones Ubicaciones { get; set; }
        public Clientes Clientes { get; set; }
        public Contactos Contactos { get; set; }
    }
}
