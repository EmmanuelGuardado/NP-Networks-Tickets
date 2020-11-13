using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Tickets
    {
        public Tickets()
        {
            OrdenesServicio = new HashSet<OrdenesServicio>();
        }
        [Key]
        public int TicketId { get; set; }
        public string DescripcionProblema { get; set; }
        public int EmpresaId { get; set; }
        public byte TipoTicketId { get; set; }

        public virtual Empresas Empresa { get; set; }
        public virtual TiposTicket TipoTicket { get; set; }
        public virtual ICollection<OrdenesServicio> OrdenesServicio { get; set; }
    }
}
