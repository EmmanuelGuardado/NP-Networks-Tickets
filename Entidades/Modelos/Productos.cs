using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Productos
    {
        public Productos()
        {
            DetallesProductos = new HashSet<DetallesProductos>();
        }
        [Key]
        public byte ProductoId { get; set; }
        [Required]
        [MaxLength(35)]
        public string Nombre { get; set; }
        [MaxLength(50)]
        public string Descripcion { get; set; }

        public virtual ICollection<DetallesProductos> DetallesProductos { get; set; }
    }
}
