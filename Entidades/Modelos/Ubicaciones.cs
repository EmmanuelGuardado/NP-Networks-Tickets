using System;
using System.Collections.Generic;

namespace Entidades.Modelos
{
    public partial class Ubicaciones
    {
        public Ubicaciones()
        {
            Clientes = new HashSet<Clientes>();
        }

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
