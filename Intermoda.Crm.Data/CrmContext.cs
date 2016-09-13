using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration.Conventions;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Crm.Data
{
    public class CrmContext : DbContext
    {
        #region Properties

        public DbSet<AcuerdoComercial> AcuerdoComercialSet { get; set; }
        public DbSet<AcuerdoComercialDetalle> AcuerdoComercialDetalleSet { get; set; }
        public DbSet<Asesor> AsesorSet { get; set; }
        public DbSet<AsesorRuta> AsesorRutaSet { get; set; }
        public DbSet<Banco> BancoSet { get; set; }
        public DbSet<Cai> CaiSet { get; set; }
        public DbSet<CarteraDocumento> CarteraDocumentoSet { get; set; }
        public DbSet<CarteraDocumentoDetalleAplicacion> CarteraDocumentoDetalleAplicacionSet { get; set; }
        public DbSet<CarteraDocumentoDetallePago> CarteraDocumentoDetallePagoSet { get; set; }
        public DbSet<CarteraDocumentoDetalleProducto> CarteraDocumentoDetalleProductoSet { get; set; }
        public DbSet<CarteraDocumentoTipo> CarteraDocumentoTipoSet { get; set; }
        public DbSet<Ciudad> CiudadSet { get; set; }
        public DbSet<Cliente> ClienteSet { get; set; }
        public DbSet<Edad> EdadSet { get; set; }
        public DbSet<Empresa> EmpresaSet { get; set; }
        public DbSet<GrupoEconomico> GrupoEconomicoSet { get; set; }
        public DbSet<InventarioFisico> InventarioFisicoSet { get; set; }
        public DbSet<InventarioFisicoDetalle> InventarioFisicoDetalleSet { get; set; }
        public DbSet<InventarioTraslado> InventarioTrasladoSet { get; set; }
        public DbSet<InventarioTrasladoDetalle> InventarioTrasladoDetalleSet { get; set; }
        public DbSet<Moneda> MonedaSet { get; set; }
        public DbSet<PagoTipo> PagoTipoSet { get; set; }
        public DbSet<Paquete> PaqueteSet { get; set; }
        public DbSet<PaqueteDetalle> PaqueteDetalleSet { get; set; }
        public DbSet<Pais> PaisSet { get; set; }
        public DbSet<PedidoTipo> PedidoTipoSet { get; set; }
        public DbSet<Producto> ProductoSet { get; set; }
        public DbSet<ProductoCategoria> ProductoCategoriaSet { get; set; }
        public DbSet<ProductoImagen> ProductoImagenSet { get; set; }
        public DbSet<Ruta> RutaSet { get; set; }
        public DbSet<Supervisor> SupervisorSet { get; set; }
        public DbSet<SupervisorZona> SupervisorZonaSet { get; set; }
        public DbSet<Usuario> UsuarioSet { get; set; }
        public DbSet<UsuarioClave> UsuarioClaveSet { get; set; }
        public DbSet<Zona> ZonaSet { get; set; }

        #endregion

        public CrmContext() : base("IntermodaCrm")
        {

        }

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            AcuerdoComercial(modelBuilder);
            AcuerdoComercialDetalle(modelBuilder);
            Asesor(modelBuilder);
            AsesorRuta(modelBuilder);
            Banco(modelBuilder);
            Cai(modelBuilder);
            CarteraDocumento(modelBuilder);
            CarteraDocumentoDetalleAplicacion(modelBuilder);
            CarteraDocumentoDetalePago(modelBuilder);
            CarteraDocumentoDetalleProducto(modelBuilder);
            CarteraDocumentoTipo(modelBuilder);
            Ciudad(modelBuilder);
            Cliente(modelBuilder);
            Edad(modelBuilder);
            Empresa(modelBuilder);
            GrupoEconomico(modelBuilder);
            InventarioFisico(modelBuilder);
            InventarioFisicoDetalle(modelBuilder);
            InventarioTraslado(modelBuilder);
            InventarioTrasladoDetalle(modelBuilder);
            Moneda(modelBuilder);
            PagoTipo(modelBuilder);
            Pais(modelBuilder);
            Paquete(modelBuilder);
            PaqueteDetalle(modelBuilder);
            PedidoTipo(modelBuilder);
            Producto(modelBuilder);
            ProductoCategoria(modelBuilder);
            ProductoImagen(modelBuilder);
            Ruta(modelBuilder);
            Supervisor(modelBuilder);
            SupervisorZona(modelBuilder);
            Usuario(modelBuilder);
            UsuarioClave(modelBuilder);
            Zona(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void AcuerdoComercial(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcuerdoComercial>()
                .ToTable("AcuerdoComercial");

            modelBuilder.Entity<AcuerdoComercial>()
                .Property(e => e.ClienteId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AcuerdoComercial1", 1) {IsUnique = true},
                    new IndexAttribute("AcuerdoComercial2", 1),
                }));

            modelBuilder.Entity<AcuerdoComercial>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AcuerdoComercial1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<AcuerdoComercial>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AcuerdoComercial2", 2),
                }));

            modelBuilder.Entity<AcuerdoComercial>()
                .Property(e => e.FechaInicial)
                .IsRequired();

            modelBuilder.Entity<AcuerdoComercial>()
                .Property(e => e.FechaFinal)
                .IsRequired();

            modelBuilder.Entity<AcuerdoComercial>()
                .HasRequired(r => r.Cliente)
                .WithMany(r => r.AcuerdoComercialSet)
                .HasForeignKey(r => r.ClienteId);
        }

        private void AcuerdoComercialDetalle(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcuerdoComercialDetalle>()
                .ToTable("AcuerdoComercialDetalle");

            modelBuilder.Entity<AcuerdoComercialDetalle>()
                .Property(e => e.AcuerdoComercialId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AcuerdoComercialDetalle1", 1) {IsUnique = true},
                }));
            modelBuilder.Entity<AcuerdoComercialDetalle>()
                .Property(e => e.ProductoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AcuerdoComercialDetalle1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<AcuerdoComercialDetalle>()
                .Property(e => e.Precio)
                .IsRequired();

            modelBuilder.Entity<AcuerdoComercialDetalle>()
                .HasRequired(r => r.AcuerdoComercial)
                .WithMany(r => r.AcuerdoComercialDetalleSet)
                .HasForeignKey(r => r.AcuerdoComercialId);

            modelBuilder.Entity<AcuerdoComercialDetalle>()
                .HasRequired(r => r.Producto)
                .WithMany(r => r.AcuerdoComercialDetalleSet)
                .HasForeignKey(r => r.ProductoId);
        }

        private void Asesor(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asesor>()
                .ToTable("Asesor");

            // Attributes

            modelBuilder.Entity<Asesor>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Asesor1") {IsUnique = true},
                    new IndexAttribute("Asesor3", 2),
                }));

            modelBuilder.Entity<Asesor>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Asesor2"),
                    new IndexAttribute("Asesor4", 2),
                }));

            modelBuilder.Entity<Asesor>()
                .Property(e => e.ZonaId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Asesor3", 1),
                    new IndexAttribute("Asesor4", 1),
                }));

            modelBuilder.Entity<Asesor>()
                .HasRequired(r => r.Usuario)
                .WithMany(r => r.AsesorSet)
                .HasForeignKey(r => r.UsuarioId);

            modelBuilder.Entity<Asesor>()
                .HasRequired(r => r.Zona)
                .WithMany(r => r.AsesorSet)
                .HasForeignKey(r => r.ZonaId);
        }

        private void AsesorRuta(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsesorRuta>()
                .ToTable("AsesorRuta");

            modelBuilder.Entity<AsesorRuta>()
                .Property(e => e.AsesorId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AsesorRuta01", 1) {IsUnique = true},
                    new IndexAttribute("AsesorRuta02", 2),
                }));
            modelBuilder.Entity<AsesorRuta>()
                .Property(e => e.RutaId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("AsesorRuta01", 2) {IsUnique = true},
                    new IndexAttribute("AsesorRuta02", 1)
                }));

            modelBuilder.Entity<AsesorRuta>()
                .HasRequired(r => r.Asesor)
                .WithMany(r => r.AsesorRutaSet)
                .HasForeignKey(r => r.AsesorId);

            modelBuilder.Entity<AsesorRuta>()
                .HasRequired(r => r.Ruta)
                .WithMany(r => r.AsesorRutaSet)
                .HasForeignKey(r => r.RutaId);
        }

        private void Banco(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banco>()
                .ToTable("Banco");

            modelBuilder.Entity<Banco>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Banco1") {IsUnique = true},
                }));
            modelBuilder.Entity<Banco>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Banco2"),
                }));
        }

        private void Cai(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cai>()
                .ToTable("Cai");

            modelBuilder.Entity<Cai>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cai1") {IsUnique = true},
                }));
            modelBuilder.Entity<Cai>()
                .Property(e => e.Descripcion)
                .IsRequired()
                .HasMaxLength(64);
            modelBuilder.Entity<Cai>()
                .Property(e => e.CarterDocumentoTipoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cai2", 1),
                }));
            modelBuilder.Entity<Cai>()
                .Property(e => e.FechaMaximaEmision)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cai2", 2),
                }));
            modelBuilder.Entity<Cai>()
                .Property(e => e.Establecimiento)
                .IsRequired();
            modelBuilder.Entity<Cai>()
                .Property(e => e.PuntoEmision)
                .IsRequired();
            modelBuilder.Entity<Cai>()
                .Property(e => e.TipoDocumento)
                .IsRequired();
            modelBuilder.Entity<Cai>()
                .Property(e => e.NumeroInicial)
                .IsRequired();
            modelBuilder.Entity<Cai>()
                .Property(e => e.NumeroFinal)
                .IsRequired();

            modelBuilder.Entity<Cai>()
                .HasRequired(r => r.CarteraDocumentoTipo)
                .WithMany(r => r.CaiSet)
                .HasForeignKey(r => r.CarterDocumentoTipoId);
        }

        private void CarteraDocumento(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteraDocumento>()
                .ToTable("CarteraDocumento");

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.CarteraDocumentoTipoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumento1", 1) {IsUnique = true},
                    new IndexAttribute("CarteraDocumento2", 2),
                }));

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.ClienteId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumento2", 1),
                    new IndexAttribute("CarteraDocumento3", 1),
                }));

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.PaqueteId)
                .IsOptional();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.PedidoTipoId)
                .IsOptional();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.MonedaId)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.CaiId)
                .IsOptional();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumento1", 2) {IsUnique = true},
                    new IndexAttribute("CarteraDocumento2", 3),
                }));

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.FechaEmision)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumento3", 2),
                }));

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.FechaVencimiento)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.FechaDespacho)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.SubTotal)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.Flete)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.OtrosCargos)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.Iva)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.Total)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.Saldo)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .Property(e => e.Sincronizado)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumento>()
                .HasRequired(r => r.CarteraDocumentoTipo)
                .WithMany(r => r.CarteraDocumentoSet)
                .HasForeignKey(r => r.CarteraDocumentoTipoId);

            modelBuilder.Entity<CarteraDocumento>()
                .HasRequired(r => r.Cliente)
                .WithMany(r => r.CarteraDocumentoSet)
                .HasForeignKey(r => r.ClienteId);

            modelBuilder.Entity<CarteraDocumento>()
                .HasRequired(r => r.Moneda)
                .WithMany(r => r.CarteraDocumentoSet)
                .HasForeignKey(r => r.MonedaId);

            modelBuilder.Entity<CarteraDocumento>()
                .HasOptional(r => r.Cai)
                .WithMany(r => r.CarteraDocumentoSet)
                .HasForeignKey(r => r.CaiId);

            modelBuilder.Entity<CarteraDocumento>()
                .HasOptional(r => r.Paquete)
                .WithMany(r => r.CarteraDocumentoSet)
                .HasForeignKey(r => r.PaqueteId);

            modelBuilder.Entity<CarteraDocumento>()
                .HasOptional(r => r.PedidoTipo)
                .WithMany(r => r.CarteraDocumentoSet)
                .HasForeignKey(r => r.PedidoTipoId);
        }

        private void CarteraDocumentoDetalePago(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .ToTable("CarteraDocumentoDetalePago");

            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.CarteraDocumentoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetallePago1", 1) {IsUnique = true},
                }));
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.Linea)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetallePago1", 2) {IsUnique = true},
                }));
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.PagoTipoId)
                .IsRequired();
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.MonedaId)
                .IsRequired();
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.BancoId)
                .IsOptional();
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.Referencia)
                .IsRequired();
            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .Property(e => e.Monto)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .HasRequired(r => r.CarteraDocumento)
                .WithMany(r => r.CarteraDocumentoDetallePagoSet)
                .HasForeignKey(r => r.CarteraDocumentoId);

            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .HasRequired(r => r.PagoTipo)
                .WithMany(r => r.CarteraDocumentoDetallePagoSet)
                .HasForeignKey(r => r.PagoTipoId);

            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .HasRequired(r => r.CarteraDocumento)
                .WithMany(r => r.CarteraDocumentoDetallePagoSet)
                .HasForeignKey(r => r.CarteraDocumentoId);

            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .HasRequired(r => r.Moneda)
                .WithMany(r => r.CarteraDocumentoDetallePagoSet)
                .HasForeignKey(r => r.MonedaId);

            modelBuilder.Entity<CarteraDocumentoDetallePago>()
                .HasOptional(r => r.Banco)
                .WithMany(r => r.CarteraDocumentoDetallePagoSet)
                .HasForeignKey(r => r.BancoId);
        }

        private void CarteraDocumentoDetalleAplicacion(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .ToTable("CarteraDocumentoDetalleAplicacion");

            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .Property(e => e.CarteraDocumentoDebitoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetalleAplicacion1", 1) {IsUnique = true},
                    new IndexAttribute("CarteraDocumentoDetalleAplicacion2", 2),
                }));
            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .Property(e => e.CarteraDocumentoCreditoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetalleAplicacion1", 2) {IsUnique = true},
                    new IndexAttribute("CarteraDocumentoDetalleAplicacion2", 1),
                }));
            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .Property(e => e.Fecha)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetalleAplicacion1", 3) {IsUnique = true},
                    new IndexAttribute("CarteraDocumentoDetalleAplicacion2", 3),
                }));
            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .Property(e => e.Aplicacion)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .HasRequired(r => r.CarteraDocumentoDebito)
                .WithMany(r => r.CarteraDocumentoDetallePagoDebitoSet)
                .HasForeignKey(r => r.CarteraDocumentoDebitoId);

            modelBuilder.Entity<CarteraDocumentoDetalleAplicacion>()
                .HasRequired(r => r.CarteraDocumentoCredito)
                .WithMany(r => r.CarteraDocumentoDetallePagoCreditoSet)
                .HasForeignKey(r => r.CarteraDocumentoCreditoId);
        }

        private void CarteraDocumentoDetalleProducto(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .ToTable("CarteraDocumentoDetalleProducto");

            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .Property(e => e.CarteraDocumentoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetalleProducto1", 1) {IsUnique = true},
                }));
            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .Property(e => e.Linea)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumentoDetalleProducto1", 2) {IsUnique = true},
                }));
            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .Property(e => e.ProductoId)
                .IsRequired();
            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .Property(e => e.Cantidad)
                .IsRequired();
            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .Property(e => e.Precio)
                .IsRequired();

            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .HasRequired(r => r.CarteraDocumento)
                .WithMany(r => r.CarteraDocumentoDetalleProductoSet)
                .HasForeignKey(r => r.CarteraDocumentoId);

            modelBuilder.Entity<CarteraDocumentoDetalleProducto>()
                .HasRequired(r => r.Producto)
                .WithMany(r => r.CarteraDocumentoDetalleProductoSet)
                .HasForeignKey(r => r.ProductoId);
        }

        private void CarteraDocumentoTipo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarteraDocumentoTipo>()
                .ToTable("CarteraDocumentoTipo");

            modelBuilder.Entity<CarteraDocumentoTipo>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(3)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumento1") {IsUnique = true},
                }));
            modelBuilder.Entity<CarteraDocumentoTipo>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("CarteraDocumento2"),
                }));
            modelBuilder.Entity<CarteraDocumentoTipo>()
                .Property(e => e.Tipo)
                .IsRequired();
        }

        private void Ciudad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>()
                .ToTable("Ciudad");

            modelBuilder.Entity<Ciudad>()
                .Property(e => e.PaisId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Ciudad1", 1) {IsUnique = true},
                    new IndexAttribute("Ciudad2", 1),
                }));
            modelBuilder.Entity<Ciudad>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Ciudad1", 2) {IsUnique = true},
                }));
            modelBuilder.Entity<Ciudad>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Ciudad2", 2),
                }));

            modelBuilder.Entity<Ciudad>()
                .HasRequired(r => r.Pais)
                .WithMany(r => r.CiudadSet)
                .HasForeignKey(r => r.PaisId);
        }

        private void Cliente(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente");

            modelBuilder.Entity<Cliente>()
                .Property(e => e.EmpresaId)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cliente1") {IsUnique = true},
                    new IndexAttribute("Cliente4, 2"),
                }));

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(128)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cliente2"),
                    new IndexAttribute("Cliente3", 2),
                    new IndexAttribute("Cliente5", 3),
                    new IndexAttribute("Cliente6", 3),
                }));

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(1024);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.InventarioDias)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.InventarioUltimo)
                .IsOptional();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.InventarioUltimo)
                .IsOptional();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.GrupoEconomicoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cliente3", 1),
                    new IndexAttribute("Cliente4", 1),
                }));

            modelBuilder.Entity<Cliente>()
                .Property(e => e.PaisId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cliente5", 1),
                    new IndexAttribute("Cliente6", 1),
                }));

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CiudadId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Cliente5", 2),
                    new IndexAttribute("Cliente6", 2),
                }));

            modelBuilder.Entity<Cliente>()
                .Property(e => e.RutaId)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(e => e.MonedaId)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .HasRequired(r => r.Empresa)
                .WithMany(r => r.ClienteSet)
                .HasForeignKey(r => r.EmpresaId);

            modelBuilder.Entity<Cliente>()
                .HasRequired(r => r.GrupoEconomico)
                .WithMany(r => r.ClienteSet)
                .HasForeignKey(r => r.GrupoEconomicoId);

            modelBuilder.Entity<Cliente>()
                .HasRequired(r => r.Pais)
                .WithMany(r => r.ClienteSet)
                .HasForeignKey(r => r.PaisId);

            modelBuilder.Entity<Cliente>()
                .HasRequired(r => r.Ciudad)
                .WithMany(r => r.ClienteSet)
                .HasForeignKey(r => r.CiudadId);

            modelBuilder.Entity<Cliente>()
                .HasRequired(r => r.Ruta)
                .WithMany(r => r.ClienteSet)
                .HasForeignKey(r => r.RutaId);

            modelBuilder.Entity<Cliente>()
                .HasRequired(r => r.Moneda)
                .WithMany(r => r.ClienteSet)
                .HasForeignKey(r => r.MonedaId);
        }

        private void Edad(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Edad>()
                .ToTable("Edad");

            modelBuilder.Entity<Edad>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Edad1") {IsUnique = true},
                }));

            modelBuilder.Entity<Edad>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Edad2") {IsUnique = true},
                }));
        }

        private void Empresa(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empresa>()
                .ToTable("Empresa");

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Empresa1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<Empresa>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Empresa2", 1),
                }));

            modelBuilder.Entity<Empresa>()
                .Property(e => e.DocumentoFiscal)
                .IsRequired()
                .HasMaxLength(32);

            modelBuilder.Entity<Empresa>()
                .Property(e => e.MonedaId)
                .IsRequired();

            modelBuilder.Entity<Empresa>()
                .HasRequired(r => r.Moneda)
                .WithMany(r => r.EmpresaSet);
        }

        private void GrupoEconomico(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GrupoEconomico>()
                .ToTable("GrupoEconomico");

            modelBuilder.Entity<GrupoEconomico>()
                .Property(e => e.Codigo)
                .IsRequired().
                HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("GrupoEconomico1") {IsUnique = true},
                }));

            modelBuilder.Entity<GrupoEconomico>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("GrupoEconomico2"),
                }));
        }

        private void InventarioFisico(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventarioFisico>()
                .ToTable("InventarioFisico");

            modelBuilder.Entity<InventarioFisico>()
                .Property(e => e.ClienteId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioFisico1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<InventarioFisico>()
                .Property(e => e.Fecha)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioFisico1", 2) {IsUnique = true},
                }));
            modelBuilder.Entity<InventarioFisico>()
                .Property(e => e.Sincronizado)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioFisico2"),
                }));

            modelBuilder.Entity<InventarioFisico>()
                .HasRequired(r => r.Cliente)
                .WithMany(r => r.InventarioFisicoSet)
                .HasForeignKey(r => r.ClienteId);
        }

        private void InventarioFisicoDetalle(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventarioFisicoDetalle>()
                .ToTable("InventarioFisicoDetalle");

            modelBuilder.Entity<InventarioFisicoDetalle>()
                .Property(e => e.InventarioFisicoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioFisicoDetalle1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<InventarioFisicoDetalle>()
                .Property(e => e.ProductoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioFisicoDetalle1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<InventarioFisicoDetalle>()
                .Property(e => e.Cantidad)
                .IsRequired();

            modelBuilder.Entity<InventarioFisicoDetalle>()
                .HasRequired(r => r.InventarioFisico)
                .WithMany(r => r.InventarioFisicoDetalleSet)
                .HasForeignKey(r => r.InventarioFisicoId);

            modelBuilder.Entity<InventarioFisicoDetalle>()
                .HasRequired(r => r.Producto)
                .WithMany(r => r.InventarioFisicoDetalleSet)
                .HasForeignKey(r => r.ProductoId);
        }

        private void InventarioTraslado(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventarioTraslado>()
                .ToTable("InventarioTraslado");

            modelBuilder.Entity<InventarioTraslado>()
                .Property(e => e.ClienteOrigenId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioTraslado1", 1) {IsUnique = true},
                    new IndexAttribute("InventarioTraslado2", 2),
                    new IndexAttribute("InventarioTraslado3", 1),
                }));

            modelBuilder.Entity<InventarioTraslado>()
                .Property(e => e.ClienteDestinoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioTraslado1", 2) {IsUnique = true},
                    new IndexAttribute("InventarioTraslado2", 1),
                    new IndexAttribute("InventarioTraslado4", 1),
                }));

            modelBuilder.Entity<InventarioTraslado>()
                .Property(e => e.Fecha)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioTraslado1", 3) {IsUnique = true},
                    new IndexAttribute("InventarioTraslado2", 3),
                    new IndexAttribute("InventarioTraslado3", 2),
                    new IndexAttribute("InventarioTraslado4", 2),
                }));

            modelBuilder.Entity<InventarioTraslado>()
                .HasRequired(r => r.ClienteOrigen)
                .WithMany(r => r.InventarioTrasladoClienteOrigenSet)
                .HasForeignKey(r => r.ClienteOrigenId);

            modelBuilder.Entity<InventarioTraslado>()
                .HasRequired(r => r.ClienteDestino)
                .WithMany(r => r.InventarioTrasladoClienteDestinoSet)
                .HasForeignKey(r => r.ClienteDestinoId);
        }

        private void InventarioTrasladoDetalle(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InventarioTrasladoDetalle>()
                .ToTable("InventarioTrasladoDetalle");

            modelBuilder.Entity<InventarioTrasladoDetalle>()
                .Property(e => e.InventarioTrasladoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioTrasladoDetalle1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<InventarioTrasladoDetalle>()
                .Property(e => e.ProductoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("InventarioTrasladoDetalle1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<InventarioTrasladoDetalle>()
                .Property(e => e.Cantidad)
                .IsRequired();

            modelBuilder.Entity<InventarioTrasladoDetalle>()
                .HasRequired(r => r.InventarioTraslado)
                .WithMany(r => r.InventarioTrasladoDetalleSet)
                .HasForeignKey(r => r.InventarioTrasladoId);

            modelBuilder.Entity<InventarioTrasladoDetalle>()
                .HasRequired(r => r.Producto)
                .WithMany(r => r.InventarioTrasladoDetalleSet)
                .HasForeignKey(r => r.ProductoId);
        }

        private void Moneda(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moneda>()
                .ToTable("Moneda");

            modelBuilder.Entity<Moneda>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Moneda1") {IsUnique = true},
                }));

            modelBuilder.Entity<Moneda>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Moneda2"),
                }));

            modelBuilder.Entity<Moneda>()
                .Property(e => e.Simbolo)
                .IsRequired()
                .HasMaxLength(3);
        }

        private void PagoTipo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PagoTipo>()
                .ToTable("PagoTipo");

            modelBuilder.Entity<PagoTipo>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("PagoTipo1") {IsUnique = true},
                }));

            modelBuilder.Entity<PagoTipo>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("PagoTipo2") {IsUnique = true},
                }));
        }

        private void Pais(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pais>()
                .ToTable("Pais");

            modelBuilder.Entity<Pais>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Pais1") {IsUnique = true}
                }));

            modelBuilder.Entity<Pais>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Pais2")
                }));
        }

        private void Paquete(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Paquete>()
                .ToTable("Paquete");

            modelBuilder.Entity<Paquete>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Paquete1") {IsUnique = true},
                }));

            modelBuilder.Entity<Paquete>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Paquete2"),
                }));

            modelBuilder.Entity<Paquete>()
                .Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(3);

            modelBuilder.Entity<Paquete>()
                .Property(e => e.EstadoDescripcion)
                .IsRequired()
                .HasMaxLength(64);
        }

        private void PaqueteDetalle(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaqueteDetalle>()
                .ToTable("PaqueteDetalle");

            modelBuilder.Entity<PaqueteDetalle>()
                .Property(e => e.PaqueteId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("PaqueteDetalle1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<PaqueteDetalle>()
                .Property(e => e.ProductoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("PaqueteDetalle1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<PaqueteDetalle>()
                .HasRequired(r => r.Paquete)
                .WithMany(r => r.PaqueteDetalleSet)
                .HasForeignKey(r => r.PaqueteId);

            modelBuilder.Entity<PaqueteDetalle>()
                .HasRequired(r => r.Producto)
                .WithMany(r => r.PaqueteDetalleSet)
                .HasForeignKey(r => r.ProductoId);
        }

        private void PedidoTipo(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PedidoTipo>()
                .ToTable("PedidoTipo");

            modelBuilder.Entity<PedidoTipo>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("PedidoTipo1") {IsUnique = true},
                }));

            modelBuilder.Entity<PedidoTipo>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("PedidoTipo2"),
                }));
        }

        private void Producto(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>()
                .ToTable("Producto");

            modelBuilder.Entity<Producto>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Producto1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Producto2"),
                }));

            modelBuilder.Entity<Producto>()
                .Property(e => e.Barcode)
                .IsRequired()
                .HasMaxLength(64);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Base)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Variante)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Tela)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Lavado)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Color)
                .IsRequired()
                .HasMaxLength(6);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Talla)
                .IsRequired()
                .HasMaxLength(6)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Producto1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<Producto>()
                .Property(e => e.EdadId)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(e => e.ProductoCategoriaId)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(e => e.Existencia)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .HasRequired(r => r.Edad)
                .WithMany(r => r.ProductoSet)
                .HasForeignKey(r => r.EdadId);

            modelBuilder.Entity<Producto>()
                .HasRequired(r => r.ProductoCategoria)
                .WithMany(r => r.ProductoSet)
                .HasForeignKey(r => r.ProductoCategoriaId);
        }

        private void ProductoCategoria(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoCategoria>()
                .ToTable("ProductoCategoria");

            modelBuilder.Entity<ProductoCategoria>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("ProductoCategoria1") {IsUnique = true},
                }));

            modelBuilder.Entity<ProductoCategoria>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("ProductoCategoria2"),
                }));
        }

        private void ProductoImagen(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductoImagen>()
                .ToTable("ProductoImagen");

            modelBuilder.Entity<ProductoImagen>()
                .Property(e => e.ProductoId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("ProductoImagen1", 1) {IsUnique = true},
                }));

            modelBuilder.Entity<ProductoImagen>()
                .Property(e => e.Secuencia)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("ProductoImagen1", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<ProductoImagen>()
                .Property(e => e.Ruta)
                .IsRequired()
                .HasMaxLength(256);
        }

        private void Ruta(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ruta>()
                .ToTable("Ruta");

            modelBuilder.Entity<Ruta>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Ruta01", 2) {IsUnique = true},
                }));

            modelBuilder.Entity<Ruta>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Ruta02", 2)
                }));

            modelBuilder.Entity<Ruta>()
                .Property(e => e.ZonaId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Ruta01", 1) {IsUnique = true},
                    new IndexAttribute("Ruta02", 1),
                }));

            modelBuilder.Entity<Ruta>()
                .HasRequired(r => r.Zona)
                .WithMany(r => r.RutaSet)
                .HasForeignKey(r => r.ZonaId);
        }

        private void Supervisor(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Supervisor>()
                .ToTable("Supervisor");

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Supervisor1") {IsUnique = true},
                }));

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Supervisor2")
                }));

            modelBuilder.Entity<Supervisor>()
                .Property(e => e.UsuarioId)
                .IsRequired();

            modelBuilder.Entity<Supervisor>()
                .HasRequired(r => r.Usuario)
                .WithMany(r => r.SupervisorSet)
                .HasForeignKey(r => r.UsuarioId);
        }

        private void SupervisorZona(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupervisorZona>()
                .ToTable("SupervisorZona");

            modelBuilder.Entity<SupervisorZona>()
                .Property(e => e.SupervisorId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("SupervisorZona1", 1) {IsUnique = true},
                    new IndexAttribute("SupervisorZona2", 2),
                }));

            modelBuilder.Entity<SupervisorZona>()
                .Property(e => e.ZonaId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("SupervisorZona1", 2) {IsUnique = true},
                    new IndexAttribute("SupervisorZona2", 1)
                }));

            modelBuilder.Entity<SupervisorZona>()
                .HasRequired(r => r.Supervisor)
                .WithMany(r => r.ZonaSet)
                .HasForeignKey(r => r.ZonaId);

            modelBuilder.Entity<SupervisorZona>()
                .HasRequired(r => r.Zona)
                .WithMany(r => r.SupervisorSet)
                .HasForeignKey(r => r.SupervisorId);
        }

        private void Usuario(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .ToTable("Usuario");

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Usuario1") {IsUnique = true},
                }));

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Usuario2")
                }));
        }

        private void UsuarioClave(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioClave>()
               .ToTable("UsuarioClave");

            modelBuilder.Entity<UsuarioClave>()
                .Property(e => e.UsuarioId)
                .IsRequired()
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("UsuarioClave1") {IsUnique = true},
                }));

            modelBuilder.Entity<UsuarioClave>()
                .Property(e => e.Clave)
                .IsRequired()
                .HasMaxLength(32);
        }

        private void Zona(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zona>()
                .ToTable("Zona");

            modelBuilder.Entity<Zona>()
                .Property(e => e.Codigo)
                .IsRequired()
                .HasMaxLength(32)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Zona1") {IsUnique = true},
                }));

            modelBuilder.Entity<Zona>()
                .Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(64)
                .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new[]
                {
                    new IndexAttribute("Zona2")
                }));
        }

        #endregion

    }
}
