using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Tickets
    {
        public Tickets()
        {
            OrdenesServicio = new HashSet<OrdenesServicio>();
        }

        public int TicketId { get; set; }
        public string DescripcionProblema { get; set; }
        public int EmpresaId { get; set; }
        public byte TipoTicketId { get; set; }

        public virtual Empresas Empresa { get; set; }
        public virtual TiposTicket TipoTicket { get; set; }
        public virtual ICollection<OrdenesServicio> OrdenesServicio { get; set; }
    }
}
