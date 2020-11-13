using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Contactos
    {
        [Key]
        public int ContactoId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }
    }
}
