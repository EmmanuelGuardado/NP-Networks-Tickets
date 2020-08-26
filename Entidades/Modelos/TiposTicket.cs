using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class TiposTicket
    {
        public TiposTicket()
        {
            EstadoTicket = new HashSet<EstadoTicket>();
        }
        [Key]
        public byte TipoTicketId { get; set; }
        [Required]
        public string TipoTicket { get; set; }
        [Required]
        public int TicketId { get; set; }

        public virtual Tickets Ticket { get; set; }
        public virtual ICollection<EstadoTicket> EstadoTicket { get; set; }
    }
}
