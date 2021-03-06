﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            Contratos = new HashSet<Contratos>();
            Tickets = new HashSet<Tickets>();
        }
        [Key]
        public int EmpresaId { get; set; }
        public string Nombre { get; set; }
        public string Direccion1 { get; set; }
        public string Direccion2 { get; set; }
        public string Ciudad { get; set; }
        public string CodigoPostal { get; set; }

        public virtual ICollection<Contratos> Contratos { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
    }
}
