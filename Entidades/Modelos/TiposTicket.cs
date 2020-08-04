using System;
using System.Collections.Generic;

namespace Entidades.Modelos
{
    public partial class TiposTicket
    {
        public TiposTicket()
        {
            EstadoTicket = new HashSet<EstadoTicket>();
        }

        public byte TipoTicketId { get; set; }
        public string TipoTicket { get; set; }
        public int TicketId { get; set; }

        public virtual Tickets Ticket { get; set; }
        public virtual ICollection<EstadoTicket> EstadoTicket { get; set; }
    }
}
