using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class MetodosPago
    {
        public MetodosPago()
        {
            Contratos = new HashSet<Contratos>();
        }

        public byte MetodosPagoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
