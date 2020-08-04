using System;
using System.Collections.Generic;

namespace Entidades.Modelos
{
    public partial class MetodosPago
    {
        public byte MetodosPagoId { get; set; }
        public string Nombre { get; set; }
        public int ContratoId { get; set; }

        public virtual Contratos Contrato { get; set; }
    }
}
