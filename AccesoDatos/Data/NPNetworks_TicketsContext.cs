using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Entidades.Models
{
    public partial class NPNetworks_TicketsContext : IdentityDbContext
    {
        public NPNetworks_TicketsContext()
        {
        }

        public NPNetworks_TicketsContext(DbContextOptions<NPNetworks_TicketsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }





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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-AIH501O;Database=NPNetworks_Tickets;Trusted_Connection=True;MultipleActiveResultSets=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasKey(e => e.ClienteId)
                    .HasName("PK__clientes__C2FF24BD4F57171D");

                entity.ToTable("clientes");

                entity.Property(e => e.ClienteId).HasColumnName("clienteID");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion)
                    .HasColumnName("fechaCreacion")
                    .HasColumnType("date");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.UbicacionId).HasColumnName("ubicacion_id");

                entity.HasOne(d => d.Ubicacion)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.UbicacionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__clientes__ubicac__3B75D760");
            });

            modelBuilder.Entity<Contactos>(entity =>
            {
                entity.HasKey(e => e.ContactoId)
                    .HasName("PK__contacto__0ECCADC774DA06F7");

                entity.ToTable("contactos");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__contacto__AB6E616424459206")
                    .IsUnique();

                entity.Property(e => e.ContactoId).HasColumnName("contactoID");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasColumnName("telefono")
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Contactos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contactos__clien__3F466844");
            });

            modelBuilder.Entity<Contratos>(entity =>
            {
                entity.HasKey(e => e.ContratoId)
                    .HasName("PK__contrato__F7E1966E23DC41C9");

                entity.ToTable("contratos");

                entity.Property(e => e.ContratoId).HasColumnName("contratoID");

                entity.Property(e => e.ClienteId).HasColumnName("cliente_id");

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.Property(e => e.FechaFin)
                    .HasColumnName("fechaFin")
                    .HasColumnType("date");

                entity.Property(e => e.FechaInicio)
                    .HasColumnName("fechaInicio")
                    .HasColumnType("date");

                entity.Property(e => e.MetodoPagoId).HasColumnName("metodoPago_id");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contratos__clien__440B1D61");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.EmpresaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contratos__empre__44FF419A");

                entity.HasOne(d => d.MetodoPago)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.MetodoPagoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__contratos__metod__1293BD5E");
            });

            modelBuilder.Entity<DetallesProductos>(entity =>
            {
                entity.HasKey(e => e.DetalleProductoId)
                    .HasName("PK__detalles__2DD4F46280082268");

                entity.ToTable("detallesProductos");

                entity.Property(e => e.DetalleProductoId).HasColumnName("detalleProductoID");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.DetalleServicioId).HasColumnName("detalleServicio_id");

                entity.Property(e => e.FirmaCliente)
                    .HasColumnName("firmaCliente")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnName("precio");

                entity.Property(e => e.ProductoId).HasColumnName("producto_id");

                entity.HasOne(d => d.DetalleServicio)
                    .WithMany(p => p.DetallesProductos)
                    .HasForeignKey(d => d.DetalleServicioId)
                    .HasConstraintName("FK__detallesP__detal__5FB337D6");

                entity.HasOne(d => d.Producto)
                    .WithMany(p => p.DetallesProductos)
                    .HasForeignKey(d => d.ProductoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detallesP__produ__60A75C0F");
            });

            modelBuilder.Entity<DetallesServicio>(entity =>
            {
                entity.HasKey(e => e.DetalleServicioId)
                    .HasName("PK__detalles__1FB1D30AFBB6CA3D");

                entity.ToTable("detallesServicio");

                entity.Property(e => e.DetalleServicioId).HasColumnName("detalleServicioID");

                entity.Property(e => e.DetalleServicio)
                    .IsRequired()
                    .HasColumnName("detalleServicio")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.HoraFinal).HasColumnName("horaFinal");

                entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");

                entity.Property(e => e.Notas)
                    .HasColumnName("notas")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrdenServicioId).HasColumnName("ordenServicio_id");

                entity.Property(e => e.TecnicoId).HasColumnName("tecnico_id");

                entity.HasOne(d => d.OrdenServicio)
                    .WithMany(p => p.DetallesServicio)
                    .HasForeignKey(d => d.OrdenServicioId)
                    .HasConstraintName("FK__detallesS__orden__59FA5E80");

                entity.HasOne(d => d.Tecnico)
                    .WithMany(p => p.DetallesServicio)
                    .HasForeignKey(d => d.TecnicoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__detallesS__tecni__5AEE82B9");
            });

            modelBuilder.Entity<Empresas>(entity =>
            {
                entity.HasKey(e => e.EmpresaId)
                    .HasName("PK__empresas__C0E670597755C7DC");

                entity.ToTable("empresas");

                entity.Property(e => e.EmpresaId).HasColumnName("empresaID");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .HasColumnName("codigoPostal")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion1)
                    .IsRequired()
                    .HasColumnName("direccion1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion2)
                    .HasColumnName("direccion2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoTicket>(entity =>
            {
                entity.ToTable("estadoTicket");

                entity.Property(e => e.EstadoTicketId).HasColumnName("estadoTicketID");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasColumnName("estado")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('ABIERTO')");

                entity.Property(e => e.TipoTicketId).HasColumnName("tipoTicket_id");

                entity.HasOne(d => d.TipoTicket)
                    .WithMany(p => p.EstadoTicket)
                    .HasForeignKey(d => d.TipoTicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__estadoTic__tipoT__5441852A");
            });

            modelBuilder.Entity<MetodosPago>(entity =>
            {
                entity.ToTable("metodosPago");

                entity.Property(e => e.MetodosPagoId)
                    .HasColumnName("metodosPagoID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrdenesServicio>(entity =>
            {
                entity.HasKey(e => e.OrdenServicioId)
                    .HasName("PK__ordenesS__92A03C4E10FADC39");

                entity.ToTable("ordenesServicio");

                entity.Property(e => e.OrdenServicioId).HasColumnName("ordenServicioID");

                entity.Property(e => e.Cliente)
                    .IsRequired()
                    .HasColumnName("cliente")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasColumnName("empresa")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TicketId).HasColumnName("ticket_id");

                entity.Property(e => e.TipoServicio)
                    .HasColumnName("tipoServicio")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.OrdenesServicio)
                    .HasForeignKey(d => d.TicketId)
                    .HasConstraintName("FK__ordenesSe__ticke__5070F446");
            });

            modelBuilder.Entity<Productos>(entity =>
            {
                entity.HasKey(e => e.ProductoId)
                    .HasName("PK__producto__69E6E0B4781275C5");

                entity.ToTable("productos");

                entity.Property(e => e.ProductoId)
                    .HasColumnName("productoID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Descripcion)
                    .HasColumnName("descripcion")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tecnicos>(entity =>
            {
                entity.HasKey(e => e.TecnicoId)
                    .HasName("PK__tecnicos__738305B2E88BFF9D");

                entity.ToTable("tecnicos");

                entity.Property(e => e.TecnicoId).HasColumnName("tecnicoID");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Latitud)
                    .IsRequired()
                    .HasColumnName("latitud")
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .IsRequired()
                    .HasColumnName("longitud")
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tickets>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__tickets__3333C67092ED514A");

                entity.ToTable("tickets");

                entity.Property(e => e.TicketId).HasColumnName("ticketID");

                entity.Property(e => e.DescripcionProblema)
                    .IsRequired()
                    .HasColumnName("descripcionProblema")
                    .HasColumnType("text");

                entity.Property(e => e.EmpresaId).HasColumnName("empresa_id");

                entity.Property(e => e.TipoTicketId).HasColumnName("tipoTicket_id");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__tickets__empresa__4AB81AF0");

                entity.HasOne(d => d.TipoTicket)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.TipoTicketId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tickets__tipoTic__24B26D99");
            });

            modelBuilder.Entity<TiposTicket>(entity =>
            {
                entity.HasKey(e => e.TipoTicketId)
                    .HasName("PK__tiposTic__299833BD7B04831F");

                entity.ToTable("tiposTicket");

                entity.Property(e => e.TipoTicketId)
                    .HasColumnName("tipoTicketID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.TipoTicket)
                    .IsRequired()
                    .HasColumnName("tipoTicket")
                    .HasMaxLength(12)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Ubicaciones>(entity =>
            {
                entity.HasKey(e => e.UbicacionId)
                    .HasName("PK__ubicacio__6A9B4B9BCA8079DD");

                entity.ToTable("ubicaciones");

                entity.Property(e => e.UbicacionId).HasColumnName("ubicacionID");

                entity.Property(e => e.Activo)
                    .HasColumnName("activo")
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.Ciudad)
                    .HasColumnName("ciudad")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CodigoPostal)
                    .HasColumnName("codigoPostal")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Direccion1)
                    .IsRequired()
                    .HasColumnName("direccion1")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion2)
                    .HasColumnName("direccion2")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
