﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Identity.ViewsModels
{
    public class UsuarioRolViewModel
    {
        public string UsuarioId { get; set; }
        public string UsuarioNombre { get; set; }
        public bool EstaSeleccionado { get; set; }
    }
}
