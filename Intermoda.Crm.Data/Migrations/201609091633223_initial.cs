namespace Intermoda.Crm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcuerdoComercialDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AcuerdoComercialId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AcuerdoComercial", t => t.AcuerdoComercialId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => new { t.AcuerdoComercialId, t.ProductoId }, unique: true, name: "AcuerdoComercialDetalle1");
            
            CreateTable(
                "dbo.AcuerdoComercial",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 32),
                        FechaInicial = c.DateTime(nullable: false),
                        FechaFinal = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => new { t.ClienteId, t.Codigo }, unique: true, name: "AcuerdoComercial1")
                .Index(t => new { t.ClienteId, t.Nombre }, name: "AcuerdoComercial2");
            
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmpresaId = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 128),
                        Direccion = c.String(nullable: false, maxLength: 1024),
                        Telefono = c.String(nullable: false, maxLength: 32),
                        InventarioDias = c.Int(nullable: false),
                        InventarioUltimo = c.DateTime(),
                        InventarioProximo = c.DateTime(),
                        GrupoEconomicoId = c.Int(nullable: false),
                        PaisId = c.Int(nullable: false),
                        CiudadId = c.Int(nullable: false),
                        RutaId = c.Int(nullable: false),
                        MonedaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ciudad", t => t.CiudadId)
                .ForeignKey("dbo.Empresa", t => t.EmpresaId)
                .ForeignKey("dbo.GrupoEconomico", t => t.GrupoEconomicoId)
                .ForeignKey("dbo.Moneda", t => t.MonedaId)
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .ForeignKey("dbo.Ruta", t => t.RutaId)
                .Index(t => t.EmpresaId)
                .Index(t => t.Codigo, unique: true, name: "Cliente1")
                .Index(t => t.Codigo, name: "Cliente4, 2")
                .Index(t => t.Nombre, name: "Cliente2")
                .Index(t => new { t.GrupoEconomicoId, t.Nombre }, name: "Cliente3")
                .Index(t => new { t.PaisId, t.CiudadId, t.Nombre }, name: "Cliente5")
                .Index(t => new { t.PaisId, t.CiudadId, t.Nombre }, name: "Cliente6")
                .Index(t => t.GrupoEconomicoId, name: "Cliente4")
                .Index(t => t.RutaId)
                .Index(t => t.MonedaId);
            
            CreateTable(
                "dbo.CarteraDocumento",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarteraDocumentoTipoId = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        PaqueteId = c.Int(),
                        PedidoTipoId = c.Int(),
                        MonedaId = c.Int(nullable: false),
                        CaiId = c.Int(),
                        Numero = c.String(nullable: false, maxLength: 32),
                        FechaEmision = c.DateTime(nullable: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        FechaDespacho = c.DateTime(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Flete = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OtrosCargos = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sincronizado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cai", t => t.CaiId)
                .ForeignKey("dbo.CarteraDocumentoTipo", t => t.CarteraDocumentoTipoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Moneda", t => t.MonedaId)
                .ForeignKey("dbo.Paquete", t => t.PaqueteId)
                .ForeignKey("dbo.PedidoTipo", t => t.PedidoTipoId)
                .Index(t => new { t.CarteraDocumentoTipoId, t.Numero }, unique: true, name: "CarteraDocumento1")
                .Index(t => new { t.ClienteId, t.CarteraDocumentoTipoId, t.Numero }, name: "CarteraDocumento2")
                .Index(t => new { t.ClienteId, t.FechaEmision }, name: "CarteraDocumento3")
                .Index(t => t.PaqueteId)
                .Index(t => t.PedidoTipoId)
                .Index(t => t.MonedaId)
                .Index(t => t.CaiId);
            
            CreateTable(
                "dbo.Cai",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarterDocumentoTipoId = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Descripcion = c.String(nullable: false, maxLength: 64),
                        FechaMaximaEmision = c.DateTime(nullable: false),
                        Establecimiento = c.Short(nullable: false),
                        PuntoEmision = c.Short(nullable: false),
                        TipoDocumento = c.Short(nullable: false),
                        NumeroInicial = c.Int(nullable: false),
                        NumeroFinal = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarteraDocumentoTipo", t => t.CarterDocumentoTipoId)
                .Index(t => new { t.CarterDocumentoTipoId, t.FechaMaximaEmision }, name: "Cai2")
                .Index(t => t.Codigo, unique: true, name: "Cai1");
            
            CreateTable(
                "dbo.CarteraDocumentoTipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 3),
                        Nombre = c.String(nullable: false, maxLength: 32),
                        Tipo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "CarteraDocumento1")
                .Index(t => t.Nombre, name: "CarteraDocumento2");
            
            CreateTable(
                "dbo.CarteraDocumentoDetalleAplicacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarteraDocumentoDebitoId = c.Int(nullable: false),
                        CarteraDocumentoCreditoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Aplicacion = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarteraDocumento", t => t.CarteraDocumentoCreditoId)
                .ForeignKey("dbo.CarteraDocumento", t => t.CarteraDocumentoDebitoId)
                .Index(t => new { t.CarteraDocumentoDebitoId, t.CarteraDocumentoCreditoId, t.Fecha }, unique: true, name: "CarteraDocumentoDetalleAplicacion1")
                .Index(t => new { t.CarteraDocumentoCreditoId, t.CarteraDocumentoDebitoId, t.Fecha }, name: "CarteraDocumentoDetalleAplicacion2");
            
            CreateTable(
                "dbo.CarteraDocumentoDetalePago",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarteraDocumentoId = c.Int(nullable: false),
                        Linea = c.Int(nullable: false),
                        PagoTipoId = c.Int(nullable: false),
                        MonedaId = c.Int(nullable: false),
                        BancoId = c.Int(),
                        Referencia = c.String(nullable: false, maxLength: 64),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Banco", t => t.BancoId)
                .ForeignKey("dbo.CarteraDocumento", t => t.CarteraDocumentoId)
                .ForeignKey("dbo.Moneda", t => t.MonedaId)
                .ForeignKey("dbo.PagoTipo", t => t.PagoTipoId)
                .Index(t => new { t.CarteraDocumentoId, t.Linea }, unique: true, name: "CarteraDocumentoDetallePago1")
                .Index(t => t.PagoTipoId)
                .Index(t => t.MonedaId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.Banco",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Banco1")
                .Index(t => t.Nombre, name: "Banco2");
            
            CreateTable(
                "dbo.Moneda",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                        Simbolo = c.String(nullable: false, maxLength: 3),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Moneda1")
                .Index(t => t.Nombre, name: "Moneda2");
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                        DocumentoFiscal = c.String(nullable: false, maxLength: 32),
                        MonedaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moneda", t => t.MonedaId)
                .Index(t => t.Codigo, unique: true, name: "Empresa1")
                .Index(t => t.Nombre, name: "Empresa2")
                .Index(t => t.MonedaId);
            
            CreateTable(
                "dbo.PagoTipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "PagoTipo1")
                .Index(t => t.Nombre, unique: true, name: "PagoTipo2");
            
            CreateTable(
                "dbo.CarteraDocumentoDetalleProducto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CarteraDocumentoId = c.Int(nullable: false),
                        Linea = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CarteraDocumento", t => t.CarteraDocumentoId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => new { t.CarteraDocumentoId, t.Linea }, unique: true, name: "CarteraDocumentoDetalleProducto1")
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Producto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                        Barcode = c.String(nullable: false, maxLength: 64),
                        Base = c.String(nullable: false, maxLength: 6),
                        Variante = c.String(nullable: false, maxLength: 6),
                        Tela = c.String(nullable: false, maxLength: 6),
                        Lavado = c.String(nullable: false, maxLength: 6),
                        Color = c.String(nullable: false, maxLength: 6),
                        Talla = c.String(nullable: false, maxLength: 6),
                        EdadId = c.Int(nullable: false),
                        ProductoCategoriaId = c.Int(nullable: false),
                        Existencia = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Edad", t => t.EdadId)
                .ForeignKey("dbo.ProductoCategoria", t => t.ProductoCategoriaId)
                .Index(t => new { t.Codigo, t.Talla }, unique: true, name: "Producto1")
                .Index(t => t.Nombre, name: "Producto2")
                .Index(t => t.EdadId)
                .Index(t => t.ProductoCategoriaId);
            
            CreateTable(
                "dbo.Edad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Edad1")
                .Index(t => t.Nombre, unique: true, name: "Edad2");
            
            CreateTable(
                "dbo.InventarioFisicoDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventarioFisicoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InventarioFisico", t => t.InventarioFisicoId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => new { t.InventarioFisicoId, t.ProductoId }, unique: true, name: "InventarioFisicoDetalle1");
            
            CreateTable(
                "dbo.InventarioFisico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Sincronizado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteId)
                .Index(t => new { t.ClienteId, t.Fecha }, unique: true, name: "InventarioFisico1")
                .Index(t => t.Sincronizado, name: "InventarioFisico2");
            
            CreateTable(
                "dbo.InventarioTrasladoDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InventarioTrasladoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.InventarioTraslado", t => t.InventarioTrasladoId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => new { t.InventarioTrasladoId, t.ProductoId }, unique: true, name: "InventarioTrasladoDetalle1");
            
            CreateTable(
                "dbo.InventarioTraslado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteOrigenId = c.Int(nullable: false),
                        ClienteDestinoId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cliente", t => t.ClienteDestinoId)
                .ForeignKey("dbo.Cliente", t => t.ClienteOrigenId)
                .Index(t => new { t.ClienteOrigenId, t.ClienteDestinoId, t.Fecha }, unique: true, name: "InventarioTraslado1")
                .Index(t => new { t.ClienteDestinoId, t.ClienteOrigenId, t.Fecha }, name: "InventarioTraslado2")
                .Index(t => new { t.ClienteOrigenId, t.Fecha }, name: "InventarioTraslado3")
                .Index(t => new { t.ClienteDestinoId, t.Fecha }, name: "InventarioTraslado4");
            
            CreateTable(
                "dbo.PaqueteDetalle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaqueteId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paquete", t => t.PaqueteId)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => new { t.PaqueteId, t.ProductoId }, unique: true, name: "PaqueteDetalle1");
            
            CreateTable(
                "dbo.Paquete",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 32),
                        Estado = c.String(nullable: false, maxLength: 3),
                        EstadoDescripcion = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Paquete1")
                .Index(t => t.Nombre, name: "Paquete2");
            
            CreateTable(
                "dbo.ProductoCategoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "ProductoCategoria1")
                .Index(t => t.Nombre, name: "ProductoCategoria2");
            
            CreateTable(
                "dbo.ProductoImagen",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Secuencia = c.Int(nullable: false),
                        Ruta = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Producto", t => t.ProductoId)
                .Index(t => new { t.ProductoId, t.Secuencia }, unique: true, name: "ProductoImagen1");
            
            CreateTable(
                "dbo.PedidoTipo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "PedidoTipo1")
                .Index(t => t.Nombre, name: "PedidoTipo2");
            
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaisId = c.Int(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.PaisId)
                .Index(t => new { t.PaisId, t.Codigo }, unique: true, name: "Ciudad1")
                .Index(t => new { t.PaisId, t.Nombre }, name: "Ciudad2");
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Pais1")
                .Index(t => t.Nombre, name: "Pais2");
            
            CreateTable(
                "dbo.GrupoEconomico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "GrupoEconomico1")
                .Index(t => t.Nombre, name: "GrupoEconomico2");
            
            CreateTable(
                "dbo.Ruta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Ruta01")
                .Index(t => t.Nombre, name: "Ruta02");
            
            CreateTable(
                "dbo.AsesorRuta",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AsesorId = c.Int(nullable: false),
                        RutaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Asesor", t => t.AsesorId)
                .ForeignKey("dbo.Ruta", t => t.RutaId)
                .Index(t => new { t.AsesorId, t.RutaId }, unique: true, name: "AsesorRuta01")
                .Index(t => new { t.RutaId, t.AsesorId }, name: "AsesorRuta02");
            
            CreateTable(
                "dbo.Asesor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                        UsuarioId = c.Int(nullable: false),
                        ZonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .ForeignKey("dbo.Zona", t => t.ZonaId)
                .Index(t => t.Codigo, unique: true, name: "Asesor1")
                .Index(t => new { t.ZonaId, t.Codigo }, name: "Asesor3")
                .Index(t => t.Nombre, name: "Asesor2")
                .Index(t => new { t.ZonaId, t.Nombre }, name: "Asesor4")
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Usuario1")
                .Index(t => t.Nombre, name: "Usuario2");
            
            CreateTable(
                "dbo.Supervisor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId)
                .Index(t => t.Codigo, unique: true, name: "Supervisor1")
                .Index(t => t.Nombre, name: "Supervisor2")
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.SupervisorZona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupervisorId = c.Int(nullable: false),
                        ZonaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Supervisor", t => t.ZonaId)
                .ForeignKey("dbo.Zona", t => t.SupervisorId)
                .Index(t => new { t.SupervisorId, t.ZonaId }, unique: true, name: "SupervisorZona1")
                .Index(t => new { t.ZonaId, t.SupervisorId }, name: "SupervisorZona2");
            
            CreateTable(
                "dbo.Zona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 32),
                        Nombre = c.String(nullable: false, maxLength: 64),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Codigo, unique: true, name: "Zona1")
                .Index(t => t.Nombre, name: "Zona2");
            
            CreateTable(
                "dbo.UsuarioClave",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UsuarioId = c.Int(nullable: false),
                        Clave = c.String(nullable: false, maxLength: 32),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UsuarioId, unique: true, name: "UsuarioClave1");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AcuerdoComercialDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.AcuerdoComercialDetalle", "AcuerdoComercialId", "dbo.AcuerdoComercial");
            DropForeignKey("dbo.AcuerdoComercial", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Cliente", "RutaId", "dbo.Ruta");
            DropForeignKey("dbo.AsesorRuta", "RutaId", "dbo.Ruta");
            DropForeignKey("dbo.AsesorRuta", "AsesorId", "dbo.Asesor");
            DropForeignKey("dbo.Asesor", "ZonaId", "dbo.Zona");
            DropForeignKey("dbo.Asesor", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.SupervisorZona", "SupervisorId", "dbo.Zona");
            DropForeignKey("dbo.SupervisorZona", "ZonaId", "dbo.Supervisor");
            DropForeignKey("dbo.Supervisor", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.Cliente", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Cliente", "MonedaId", "dbo.Moneda");
            DropForeignKey("dbo.Cliente", "GrupoEconomicoId", "dbo.GrupoEconomico");
            DropForeignKey("dbo.Cliente", "EmpresaId", "dbo.Empresa");
            DropForeignKey("dbo.Cliente", "CiudadId", "dbo.Ciudad");
            DropForeignKey("dbo.Ciudad", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.CarteraDocumento", "PedidoTipoId", "dbo.PedidoTipo");
            DropForeignKey("dbo.CarteraDocumento", "PaqueteId", "dbo.Paquete");
            DropForeignKey("dbo.CarteraDocumento", "MonedaId", "dbo.Moneda");
            DropForeignKey("dbo.CarteraDocumento", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.CarteraDocumento", "CarteraDocumentoTipoId", "dbo.CarteraDocumentoTipo");
            DropForeignKey("dbo.CarteraDocumentoDetalleProducto", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.ProductoImagen", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.Producto", "ProductoCategoriaId", "dbo.ProductoCategoria");
            DropForeignKey("dbo.PaqueteDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.PaqueteDetalle", "PaqueteId", "dbo.Paquete");
            DropForeignKey("dbo.InventarioTrasladoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.InventarioTrasladoDetalle", "InventarioTrasladoId", "dbo.InventarioTraslado");
            DropForeignKey("dbo.InventarioTraslado", "ClienteOrigenId", "dbo.Cliente");
            DropForeignKey("dbo.InventarioTraslado", "ClienteDestinoId", "dbo.Cliente");
            DropForeignKey("dbo.InventarioFisicoDetalle", "ProductoId", "dbo.Producto");
            DropForeignKey("dbo.InventarioFisicoDetalle", "InventarioFisicoId", "dbo.InventarioFisico");
            DropForeignKey("dbo.InventarioFisico", "ClienteId", "dbo.Cliente");
            DropForeignKey("dbo.Producto", "EdadId", "dbo.Edad");
            DropForeignKey("dbo.CarteraDocumentoDetalleProducto", "CarteraDocumentoId", "dbo.CarteraDocumento");
            DropForeignKey("dbo.CarteraDocumentoDetalePago", "PagoTipoId", "dbo.PagoTipo");
            DropForeignKey("dbo.CarteraDocumentoDetalePago", "MonedaId", "dbo.Moneda");
            DropForeignKey("dbo.Empresa", "MonedaId", "dbo.Moneda");
            DropForeignKey("dbo.CarteraDocumentoDetalePago", "CarteraDocumentoId", "dbo.CarteraDocumento");
            DropForeignKey("dbo.CarteraDocumentoDetalePago", "BancoId", "dbo.Banco");
            DropForeignKey("dbo.CarteraDocumentoDetalleAplicacion", "CarteraDocumentoDebitoId", "dbo.CarteraDocumento");
            DropForeignKey("dbo.CarteraDocumentoDetalleAplicacion", "CarteraDocumentoCreditoId", "dbo.CarteraDocumento");
            DropForeignKey("dbo.CarteraDocumento", "CaiId", "dbo.Cai");
            DropForeignKey("dbo.Cai", "CarterDocumentoTipoId", "dbo.CarteraDocumentoTipo");
            DropIndex("dbo.UsuarioClave", "UsuarioClave1");
            DropIndex("dbo.Zona", "Zona2");
            DropIndex("dbo.Zona", "Zona1");
            DropIndex("dbo.SupervisorZona", "SupervisorZona2");
            DropIndex("dbo.SupervisorZona", "SupervisorZona1");
            DropIndex("dbo.Supervisor", new[] { "UsuarioId" });
            DropIndex("dbo.Supervisor", "Supervisor2");
            DropIndex("dbo.Supervisor", "Supervisor1");
            DropIndex("dbo.Usuario", "Usuario2");
            DropIndex("dbo.Usuario", "Usuario1");
            DropIndex("dbo.Asesor", new[] { "UsuarioId" });
            DropIndex("dbo.Asesor", "Asesor4");
            DropIndex("dbo.Asesor", "Asesor2");
            DropIndex("dbo.Asesor", "Asesor3");
            DropIndex("dbo.Asesor", "Asesor1");
            DropIndex("dbo.AsesorRuta", "AsesorRuta02");
            DropIndex("dbo.AsesorRuta", "AsesorRuta01");
            DropIndex("dbo.Ruta", "Ruta02");
            DropIndex("dbo.Ruta", "Ruta01");
            DropIndex("dbo.GrupoEconomico", "GrupoEconomico2");
            DropIndex("dbo.GrupoEconomico", "GrupoEconomico1");
            DropIndex("dbo.Pais", "Pais2");
            DropIndex("dbo.Pais", "Pais1");
            DropIndex("dbo.Ciudad", "Ciudad2");
            DropIndex("dbo.Ciudad", "Ciudad1");
            DropIndex("dbo.PedidoTipo", "PedidoTipo2");
            DropIndex("dbo.PedidoTipo", "PedidoTipo1");
            DropIndex("dbo.ProductoImagen", "ProductoImagen1");
            DropIndex("dbo.ProductoCategoria", "ProductoCategoria2");
            DropIndex("dbo.ProductoCategoria", "ProductoCategoria1");
            DropIndex("dbo.Paquete", "Paquete2");
            DropIndex("dbo.Paquete", "Paquete1");
            DropIndex("dbo.PaqueteDetalle", "PaqueteDetalle1");
            DropIndex("dbo.InventarioTraslado", "InventarioTraslado4");
            DropIndex("dbo.InventarioTraslado", "InventarioTraslado3");
            DropIndex("dbo.InventarioTraslado", "InventarioTraslado2");
            DropIndex("dbo.InventarioTraslado", "InventarioTraslado1");
            DropIndex("dbo.InventarioTrasladoDetalle", "InventarioTrasladoDetalle1");
            DropIndex("dbo.InventarioFisico", "InventarioFisico2");
            DropIndex("dbo.InventarioFisico", "InventarioFisico1");
            DropIndex("dbo.InventarioFisicoDetalle", "InventarioFisicoDetalle1");
            DropIndex("dbo.Edad", "Edad2");
            DropIndex("dbo.Edad", "Edad1");
            DropIndex("dbo.Producto", new[] { "ProductoCategoriaId" });
            DropIndex("dbo.Producto", new[] { "EdadId" });
            DropIndex("dbo.Producto", "Producto2");
            DropIndex("dbo.Producto", "Producto1");
            DropIndex("dbo.CarteraDocumentoDetalleProducto", new[] { "ProductoId" });
            DropIndex("dbo.CarteraDocumentoDetalleProducto", "CarteraDocumentoDetalleProducto1");
            DropIndex("dbo.PagoTipo", "PagoTipo2");
            DropIndex("dbo.PagoTipo", "PagoTipo1");
            DropIndex("dbo.Empresa", new[] { "MonedaId" });
            DropIndex("dbo.Empresa", "Empresa2");
            DropIndex("dbo.Empresa", "Empresa1");
            DropIndex("dbo.Moneda", "Moneda2");
            DropIndex("dbo.Moneda", "Moneda1");
            DropIndex("dbo.Banco", "Banco2");
            DropIndex("dbo.Banco", "Banco1");
            DropIndex("dbo.CarteraDocumentoDetalePago", new[] { "BancoId" });
            DropIndex("dbo.CarteraDocumentoDetalePago", new[] { "MonedaId" });
            DropIndex("dbo.CarteraDocumentoDetalePago", new[] { "PagoTipoId" });
            DropIndex("dbo.CarteraDocumentoDetalePago", "CarteraDocumentoDetallePago1");
            DropIndex("dbo.CarteraDocumentoDetalleAplicacion", "CarteraDocumentoDetalleAplicacion2");
            DropIndex("dbo.CarteraDocumentoDetalleAplicacion", "CarteraDocumentoDetalleAplicacion1");
            DropIndex("dbo.CarteraDocumentoTipo", "CarteraDocumento2");
            DropIndex("dbo.CarteraDocumentoTipo", "CarteraDocumento1");
            DropIndex("dbo.Cai", "Cai1");
            DropIndex("dbo.Cai", "Cai2");
            DropIndex("dbo.CarteraDocumento", new[] { "CaiId" });
            DropIndex("dbo.CarteraDocumento", new[] { "MonedaId" });
            DropIndex("dbo.CarteraDocumento", new[] { "PedidoTipoId" });
            DropIndex("dbo.CarteraDocumento", new[] { "PaqueteId" });
            DropIndex("dbo.CarteraDocumento", "CarteraDocumento3");
            DropIndex("dbo.CarteraDocumento", "CarteraDocumento2");
            DropIndex("dbo.CarteraDocumento", "CarteraDocumento1");
            DropIndex("dbo.Cliente", new[] { "MonedaId" });
            DropIndex("dbo.Cliente", new[] { "RutaId" });
            DropIndex("dbo.Cliente", "Cliente4");
            DropIndex("dbo.Cliente", "Cliente6");
            DropIndex("dbo.Cliente", "Cliente5");
            DropIndex("dbo.Cliente", "Cliente3");
            DropIndex("dbo.Cliente", "Cliente2");
            DropIndex("dbo.Cliente", "Cliente4, 2");
            DropIndex("dbo.Cliente", "Cliente1");
            DropIndex("dbo.Cliente", new[] { "EmpresaId" });
            DropIndex("dbo.AcuerdoComercial", "AcuerdoComercial2");
            DropIndex("dbo.AcuerdoComercial", "AcuerdoComercial1");
            DropIndex("dbo.AcuerdoComercialDetalle", "AcuerdoComercialDetalle1");
            DropTable("dbo.UsuarioClave");
            DropTable("dbo.Zona");
            DropTable("dbo.SupervisorZona");
            DropTable("dbo.Supervisor");
            DropTable("dbo.Usuario");
            DropTable("dbo.Asesor");
            DropTable("dbo.AsesorRuta");
            DropTable("dbo.Ruta");
            DropTable("dbo.GrupoEconomico");
            DropTable("dbo.Pais");
            DropTable("dbo.Ciudad");
            DropTable("dbo.PedidoTipo");
            DropTable("dbo.ProductoImagen");
            DropTable("dbo.ProductoCategoria");
            DropTable("dbo.Paquete");
            DropTable("dbo.PaqueteDetalle");
            DropTable("dbo.InventarioTraslado");
            DropTable("dbo.InventarioTrasladoDetalle");
            DropTable("dbo.InventarioFisico");
            DropTable("dbo.InventarioFisicoDetalle");
            DropTable("dbo.Edad");
            DropTable("dbo.Producto");
            DropTable("dbo.CarteraDocumentoDetalleProducto");
            DropTable("dbo.PagoTipo");
            DropTable("dbo.Empresa");
            DropTable("dbo.Moneda");
            DropTable("dbo.Banco");
            DropTable("dbo.CarteraDocumentoDetalePago");
            DropTable("dbo.CarteraDocumentoDetalleAplicacion");
            DropTable("dbo.CarteraDocumentoTipo");
            DropTable("dbo.Cai");
            DropTable("dbo.CarteraDocumento");
            DropTable("dbo.Cliente");
            DropTable("dbo.AcuerdoComercial");
            DropTable("dbo.AcuerdoComercialDetalle");
        }
    }
}
