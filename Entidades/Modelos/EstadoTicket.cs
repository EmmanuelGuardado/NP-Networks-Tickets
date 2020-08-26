using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class EstadoTicket
    {
        public int EstadoTicketId { get; set; }
        public string Estado { get; set; }
        [Required]
        public byte TipoTicketId { get; set; }

        public virtual TiposTicket TipoTicket { get; set; }
    }
}
