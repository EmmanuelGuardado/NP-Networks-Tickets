using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class EstadoTicket
    {
        [Key]
        public int EstadoTicketId { get; set; }
        public string Estado { get; set; }
        public byte TipoTicketId { get; set; }

        public virtual TiposTicket TipoTicket { get; set; }
    }
}
