﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class Tecnicos
    {
        public Tecnicos()
        {
            DetallesServicio = new HashSet<DetallesServicio>();
        }
        [Key]
        public int TecnicoId { get; set; }
        public string Nombre { get; set; }
        public bool? Activo { get; set; }
        public string Longitud { get; set; }
        public string Latitud { get; set; }

        public virtual ICollection<DetallesServicio> DetallesServicio { get; set; }
    }
}
