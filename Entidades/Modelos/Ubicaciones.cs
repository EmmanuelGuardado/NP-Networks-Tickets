using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Ubicaciones
    {
        public Ubicaciones()
        {
            Clientes = new HashSet<Clientes>();
        }
        [Key]
        public int UbicacionId { get; set; }
        [Required]
        [MaxLength(30)]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50)]
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
