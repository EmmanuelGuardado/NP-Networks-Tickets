using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class DetallesServicio
    {
        public DetallesServicio()
        {
            DetallesProductos = new HashSet<DetallesProductos>();
        }

        public int DetalleServicioId { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFinal { get; set; }
        public string DetalleServicio { get; set; }
        public string Notas { get; set; }
        public int OrdenServicioId { get; set; }
        public int TecnicoId { get; set; }

        public virtual OrdenesServicio OrdenServicio { get; set; }
        public virtual Tecnicos Tecnico { get; set; }
        public virtual ICollection<DetallesProductos> DetallesProductos { get; set; }
    }
}
