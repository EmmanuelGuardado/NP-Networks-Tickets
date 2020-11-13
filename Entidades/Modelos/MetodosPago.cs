using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class MetodosPago
    {
        public MetodosPago()
        {
            Contratos = new HashSet<Contratos>();
        }
        [Key]
        public byte MetodosPagoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
