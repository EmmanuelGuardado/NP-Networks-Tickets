using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class OrdenesServicio
    {
        public OrdenesServicio()
        {
            DetallesServicio = new HashSet<DetallesServicio>();
        }
        [Key]
        public int OrdenServicioId { get; set; }
        [Required]
        public string Empresa { get; set; }
        [Required]
        public string Cliente { get; set; }
        [Required]
        public int TicketId { get; set; }
        public string TipoServicio { get; set; }

        public virtual Tickets Ticket { get; set; }
        public virtual ICollection<DetallesServicio> DetallesServicio { get; set; }
    }
}
