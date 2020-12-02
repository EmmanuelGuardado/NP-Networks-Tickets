using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class EstadoTicket
    {
        public int EstadoTicketId { get; set; }
        public string Estado { get; set; }
        public byte TipoTicketId { get; set; }

        public virtual TiposTicket TipoTicket { get; set; }
    }
}
