using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class DetallesServicio
    {
        public DetallesServicio()
        {
            DetallesProductos = new HashSet<DetallesProductos>();
        }

        public int DetalleServicioId { get; set; }
        [Required]
        public TimeSpan HoraInicio { get; set; }
        [Required]
        public TimeSpan HoraFinal { get; set; }
        [Required]
        [MaxLength(100)]
        public string DetalleServicio { get; set; }
        [MaxLength(100)]
        public string Notas { get; set; }
        [Required]
        public int OrdenServicioId { get; set; }
        [Required]
        public int TecnicoId { get; set; }

        public virtual OrdenesServicio OrdenServicio { get; set; }
        public virtual Tecnicos Tecnico { get; set; }
        public virtual ICollection<DetallesProductos> DetallesProductos { get; set; }
    }
}
