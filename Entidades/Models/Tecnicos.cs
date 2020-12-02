using System;
using System.Collections.Generic;

namespace Entidades.Models
{
    public partial class Tecnicos
    {
        public Tecnicos()
        {
            DetallesServicio = new HashSet<DetallesServicio>();
        }

        public int TecnicoId { get; set; }
        public string Nombre { get; set; }
        public bool? Activo { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }

        public virtual ICollection<DetallesServicio> DetallesServicio { get; set; }
    }
}
