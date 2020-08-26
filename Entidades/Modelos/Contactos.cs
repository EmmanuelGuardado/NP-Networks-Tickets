using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidades.Modelos
{
    public partial class Contactos
    {
        public int ContactoId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "El nombre no puede ser mayor a 30 carácteres")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "El e-mail no puede ser mayor a 50 carácteres")]
        public string Email { get; set; }
        [Phone]
        public string Telefono { get; set; }
        [Required]
        public int ClienteId { get; set; }

        public virtual Clientes Cliente { get; set; }
    }
}
