using System;
using System.Collections.Generic;

namespace Entidades.Modelos
{
    public partial class Productos
    {
        public Productos()
        {
            DetallesProductos = new HashSet<DetallesProductos>();
        }

        public byte ProductoId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<DetallesProductos> DetallesProductos { get; set; }
    }
}
