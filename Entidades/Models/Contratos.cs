using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class Contratos
    {
        [Key]
        public int ContratoId { get; set; }
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public byte MetodoPagoId { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Empresas Empresa { get; set; }
        public virtual MetodosPago MetodoPago { get; set; }
    }
}
