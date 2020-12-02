using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class Ubicaciones
    {
        public Ubicaciones()
        {
            Clientes = new HashSet<Clientes>();
        }
        [Key]
        public int UbicacionId { get; set; }
        public string Nombre { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }
        public bool? Activo { get; set; }

        public virtual ICollection<Clientes> Clientes { get; set; }
    }
}
