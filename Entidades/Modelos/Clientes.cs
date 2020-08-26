using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Clientes
    {
        public Clientes()
        {
            Contactos = new HashSet<Contactos>();
            Contratos = new HashSet<Contratos>();
        }

        public int ClienteId { get; set; }
        [Required]
        [MaxLength(35,ErrorMessage ="El nombre no puede ser mayor a 35 carácteres")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="El e-mail no puede ser mayor a 30 carácteres")]
        public string Email { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public bool? Activo { get; set; }
        [Required]
        public int UbicacionId { get; set; }

        public virtual Ubicaciones Ubicacion { get; set; }
        public virtual ICollection<Contactos> Contactos { get; set; }
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
