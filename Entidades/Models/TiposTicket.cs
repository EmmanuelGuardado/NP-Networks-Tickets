using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class TiposTicket
    {
        public TiposTicket()
        {
            EstadoTicket = new HashSet<EstadoTicket>();
            Tickets = new HashSet<Tickets>();
        }

        public byte TipoTicketId { get; set; }
        public string TipoTicket { get; set; }

        public virtual ICollection<EstadoTicket> EstadoTicket { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
