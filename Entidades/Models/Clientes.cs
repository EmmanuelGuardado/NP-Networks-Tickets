using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Contactos = new HashSet<Contactos>();
            Contratos = new HashSet<Contratos>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        public int UbicacionId { get; set; }

        public virtual Ubicaciones Ubicacion { get; set; }
        public virtual ICollection<Contactos> Contactos { get; set; }
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
