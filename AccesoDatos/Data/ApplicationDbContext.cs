using System;
using System.Collections.Generic;
using System.Text;
using Entidades.Modelos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Web.AccesoDatos.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Contratos> Contratos { get; set; }
        public virtual DbSet<DetallesProductos> DetallesProductos { get; set; }
        public virtual DbSet<DetallesServicio> DetallesServicio { get; set; }
        public virtual DbSet<Empresas> Empresas { get; set; }
        public virtual DbSet<EstadoTicket> EstadoTicket { get; set; }
        public virtual DbSet<MetodosPago> MetodosPago { get; set; }
        public virtual DbSet<OrdenesServicio> OrdenesServicio { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Tecnicos> Tecnicos { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<TiposTicket> TiposTicket { get; set; }
        public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }
    }
}
