using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class MetodosPago
    {
        public byte MetodosPagoId { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int ContratoId { get; set; }

        public virtual Contratos Contrato { get; set; }
    }
}
