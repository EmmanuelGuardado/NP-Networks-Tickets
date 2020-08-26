using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Empresas
    {
        public Empresas()
        {
            Contratos = new HashSet<Contratos>();
            Tickets = new HashSet<Tickets>();
        }
        [Key]
        public int EmpresaId { get; set; }
        [Required]
        [MaxLength(35,ErrorMessage ="El nombre no puede ser mayor a 35 carácteres")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="La dirección no puede tener mas de 50 carácteres")]
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }

        public virtual ICollection<Contratos> Contratos { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
