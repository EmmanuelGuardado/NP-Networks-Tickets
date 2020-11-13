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
            Tickets = new HashSet<Tickets>();
        }
        [Key]
        public byte TipoTicketId { get; set; }
        public string TipoTicket { get; set; }

        public virtual ICollection<EstadoTicket> EstadoTicket { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
