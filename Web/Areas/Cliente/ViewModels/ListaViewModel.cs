using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Areas.Cliente.ViewModels
{
    public class ListaViewModel
    {
        //Cliente
        public string NombreCliente { get; set; }
        public string EmailCliente { get; set; }
        //Contacto
        public string NombreContacto { get; set; }
        public string EmailContacto { get; set; }
        public string TelefonoContacto { get; set; }
    }
}
