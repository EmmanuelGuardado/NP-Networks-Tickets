using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidades.Modelos
{
    public partial class Clientes
    {
        public Clientes()
        {
            Contactos = new HashSet<Contactos>();
            Contratos = new HashSet<Contratos>();
        }
        [Key]
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
        public int Ubicacion_id { get; set; }

        [ForeignKey("Ubicacion_id")]
        public virtual Ubicaciones Ubicacion { get; set; }
        public virtual ICollection<Contactos> Contactos { get; set; }
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
