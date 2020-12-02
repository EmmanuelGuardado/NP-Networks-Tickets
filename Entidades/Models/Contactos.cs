using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Contactos
    {
        public int ContactoId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }
    }
}
