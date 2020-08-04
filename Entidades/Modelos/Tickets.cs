using System;
using System.Collections.Generic;

namespace Entidades.Modelos
{
    public partial class Tickets
    {
        public Tickets()
        {
            OrdenesServicio = new HashSet<OrdenesServicio>();
            TiposTicket = new HashSet<TiposTicket>();
        }

        public int TicketId { get; set; }
        public string DescripcionProblema { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresas Empresa { get; set; }
        public virtual ICollection<OrdenesServicio> OrdenesServicio { get; set; }
        public virtual ICollection<TiposTicket> TiposTicket { get; set; }
    }
}
