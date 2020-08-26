using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class DetallesProductos
    {
        [Key]
        public int DetalleProductoId { get; set; }
        [Required]
        public byte Cantidad { get; set; }
        [Required]
        public double Precio { get; set; }
        public string FirmaCliente { get; set; }
        public int DetalleServicioId { get; set; }
        [Required]
        public byte ProductoId { get; set; }

        public virtual DetallesServicio DetalleServicio { get; set; }
        public virtual Productos Producto { get; set; }
    }
}
