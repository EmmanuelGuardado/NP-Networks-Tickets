using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class OrdenesServicio
    {
        public OrdenesServicio()
        {
            DetallesServicio = new HashSet<DetallesServicio>();
        }
        [Key]
        public int OrdenServicioId { get; set; }
        public string Empresa { get; set; }
        public string Cliente { get; set; }
        public int TicketId { get; set; }
        public string TipoServicio { get; set; }

        public virtual Tickets Ticket { get; set; }
        public virtual ICollection<DetallesServicio> DetallesServicio { get; set; }
    }
}
