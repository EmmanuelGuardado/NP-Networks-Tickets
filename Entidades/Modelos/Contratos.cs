using System;
using System.Collections.Generic;

namespace Entidades.Modelos
{
    public partial class Contratos
    {
        public Contratos()
        {
            MetodosPago = new HashSet<MetodosPago>();
        }

        public int ContratoId { get; set; }
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public virtual Clientes Cliente { get; set; }
        public virtual Empresas Empresa { get; set; }
        public virtual ICollection<MetodosPago> MetodosPago { get; set; }
    }
}
