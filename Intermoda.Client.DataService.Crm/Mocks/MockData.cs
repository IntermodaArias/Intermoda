using System;
using Intermoda.Business.Crm.Entities;
using Intermoda.Common.Enum;

namespace Intermoda.Client.DataService.Crm
{
    public class MockData
    {
        public static AcuerdoComercial AcuerdoComercial()
        {
            return new AcuerdoComercial
            {
                Id = 1,
                Codigo = "000001",
                Nombre = "Acuerdo Comercial No. 000001",
                ClienteId = 1,
                Cliente = new Cliente
                {
                    Id = 1,
                    Codigo = "00001",
                    Nombre = "Cliente No. 00001",
                    Direccion = "Dirección del Cliente",
                    EmpresaId = 1,
                    Empresa = Empresa(),
                    CiudadId = 1,
                    Ciudad = Ciudad(),
                    PaisId = 1,
                    Pais = Pais()
                },
                FechaInicial = new DateTime(2016, 1, 1),
                FechaFinal = new DateTime(2016, 2, 28)
            };
        }

        public static AcuerdoComercialDetalle AcuerdoComercialDetalle()
        {
            return new AcuerdoComercialDetalle
            {
                Id = 1,
                AcuerdoComercialId = 1,
                ProductoId = 1,
                Precio = (decimal) 567.89,
                AcuerdoComercial = AcuerdoComercial(),
                Producto = Producto(),
            };
        }

        public static Asesor Asesor()
        {
            return new Asesor
            {
                Id = 1,
                Codigo = "ASE001",
                Nombre = "Nombre del asesor No. 0001",
                UsuarioId = 1,
                ZonaId = 1,
                Usuario = Usuario(),
                Zona = Zona()
            };
        }

        public static AsesorRuta AsesorRuta()
        {
            return new AsesorRuta
            {
                Id = 1,
                AsesorId = 1,
                RutaId = 1,
                Asesor = Asesor(),
                Ruta = Ruta()
            };
        }

        public static Banco Banco()
        {
            return new Banco
            {
                Id = 1,
                Codigo = "BAN001",
                Nombre = "Nombre del Banco No. 001"
            };
        }

        public static Cai Cai()
        {
            return new Cai
            {
                Id = 1,
                CarterDocumentoTipoId = 1,
                Codigo = "CAI0001",
                Descripcion = "CAI Número 0000001",
                FechaMaximaEmision = new DateTime(2017, 12, 31),
                Establecimiento = 1,
                PuntoEmision = 1,
                TipoDocumento = 1,
                NumeroInicial = 0,
                NumeroFinal = 4999,
                CarteraDocumentoTipo = CarteraDocumentoTipo()
            };
        }

        public static CarteraDocumento CarteraDocumento()
        {
            return new CarteraDocumento
            {
                Id = 1,
                CarteraDocumentoTipoId = 1,
                CarteraDocumentoTipo = CarteraDocumentoTipo(),
                ClienteId = 1,
                Cliente = Cliente(),
                PaqueteId = 1,
                Paquete = Paquete(),
                PedidoTipoId = 1,
                PedidoTipo = PedidoTipo(),
                MonedaId = 1,
                Moneda = Moneda(),
                CaiId = 1,
                Cai = Cai(),
                Numero = "001-001-01-123456",
                FechaEmision = new DateTime(2016, 1, 1),
                FechaDespacho = new DateTime(2016, 1, 2),
                FechaVencimiento = new DateTime(2016, 03, 30),
                SubTotal = 20000,
                Flete = 140,
                OtrosCargos = 160,
                Iva = 1500,
                Total = 22000,
                Saldo = 22000,
                Sincronizado = false
            };
        }

        public static CarteraDocumentoDetalleAplicacion CarteraDocumentoDetalleAplicacion()
        {
            return new CarteraDocumentoDetalleAplicacion
            {
                Id = 1,
                CarteraDocumentoDebitoId = 1,
                CarteraDocumentoCreditoId = 2,
                Fecha = new DateTime(2016, 1, 1),
                Aplicacion = 1000,
                CarteraDocumentoDebito = CarteraDocumento(),
                CarteraDocumentoCredito = CarteraDocumento()
            };
        }

        public static CarteraDocumentoDetallePago CarteraDocumentoDetallePago()
        {
            return new CarteraDocumentoDetallePago
            {
                Id = 1,
                CarteraDocumentoId = 1,
                CarteraDocumento = CarteraDocumento(),
                Linea = 1,
                PagoTipoId = 1,
                PagoTipo = PagoTipo(),
                MonedaId = 1,
                Moneda = Moneda(),
                BancoId = 1,
                Banco = Banco(),
                Referencia = "Referencia",
                Monto = 5000
            };
        }

        public static CarteraDocumentoDetalleProducto CarteraDocumentoDetalleProducto()
        {
            return new CarteraDocumentoDetalleProducto
            {
                Id = 1,
                CarteraDocumentoId = 1,
                CarteraDocumento = CarteraDocumento(),
                Linea = 1,
                ProductoId = 1,
                Producto = Producto(),
                Precio = 333,
                Cantidad = 12
            };
        }

        public static CarteraDocumentoTipo CarteraDocumentoTipo()
        {
            return new CarteraDocumentoTipo
            {
                Id = 1,
                Codigo = "TDC001",
                Nombre = "Tipo de Documento de Cartera 001",
                Tipo = DebitoCredito.Debito
            };
        }

        public static Ciudad Ciudad()
        {
            return new Ciudad
            {
                Id = 1,
                Codigo = "001",
                Nombre = "Ciudad",
                PaisId = 1,
                Pais = new Pais { Id = 1, Codigo = "HN", Nombre = "Honduras" }
            };
        }

        public static Cliente Cliente()
        {
            return new Cliente
            {
                Id = 1,
                Codigo = "CLI0001",
                Nombre = "Nombre del Cliente No. 00001",
                Direccion = "Dirección del cliente No. 00001",
                Telefono = "98765432",
                InventarioDias = 90,
                InventarioUltimo = new DateTime(2016, 3, 13),
                InventarioProximo = new DateTime(2016, 6, 12),
                GrupoEconomicoId = 1,
                GrupoEconomico = GrupoEconomico(),
                PaisId = 1,
                Pais = Pais(),
                CiudadId = 1,
                Ciudad = Ciudad(),
                RutaId = 1,
                Ruta = Ruta(),
                MonedaId = 1,
                Moneda = Moneda(),
                EmpresaId = 1,
                Empresa = Empresa(),
            };
        }

        public static Edad Edad()
        {
            return new Edad
            {
                Id = 1,
                Codigo = "EDA001",
                Nombre = "Edad de Producto 0001"
            };
        }

        public static Empresa Empresa()
        {
            return new Empresa
            {
                Id = 1,
                Codigo = "001",
                Nombre = "Empresa No. 001",
                DocumentoFiscal = "XXXX-XXXX-XXXXXX-X",
                MonedaId = 1,
                Moneda = Moneda()
            };
        }

        public static GrupoEconomico GrupoEconomico()
        {
            return new GrupoEconomico
            {
                Id = 1,
                Codigo = "GEC001",
                Nombre = "Grupo Económico No. 0001"
            };
        }

        public static InventarioFisico InventarioFisico()
        {
            return new InventarioFisico
            {
                Id = 1,
                ClienteId = 1,
                Cliente = Cliente(),
                Fecha = new DateTime(2016, 1, 1),
                Sincronizado = true
            };
        }

        public static InventarioFisicoDetalle InventarioFisicoDetalle()
        {
            return new InventarioFisicoDetalle
            {
                Id = 1,
                InventarioFisicoId = 1,
                InventarioFisico = InventarioFisico(),
                ProductoId = 1,
                Producto = Producto(),
                Cantidad = 21
            };
        }

        public static InventarioTraslado InventarioTraslado()
        {
            return new InventarioTraslado
            {
                Id = 1,
                ClienteOrigenId = 1,
                ClienteOrigen = Cliente(),
                ClienteDestinoId = 1,
                ClienteDestino = Cliente(),
                Fecha = new DateTime(2016, 1, 1)
            };
        }

        public static InventarioTrasladoDetalle InventarioTrasladoDetalle()
        {
            return new InventarioTrasladoDetalle
            {
                Id = 1,
                InventarioTrasladoId = 1,
                InventarioTraslado = InventarioTraslado(),
                ProductoId = 1,
                Producto = Producto(),
                Cantidad = 23
            };
        }

        public static Moneda Moneda()
        {
            return new Moneda
            {
                Id = 1,
                Codigo = "HNL",
                Nombre = "Lempira",
                Simbolo = "L"
            };
        }

        public static Pais Pais()
        {
            return new Pais
            {
                Id = 1,
                Codigo = "HN",
                Nombre = "Honduras"
            };
        }

        public static PagoTipo PagoTipo()
        {
            return new PagoTipo
            {
                Id = 1,
                Codigo = "PGT001",
                Nombre = "Pago Tipo No. 0001"
            };
        }

        public static Paquete Paquete()
        {
            return new Paquete
            {
                Id = 1,
                Codigo = "PAQ001",
                Nombre = "Paquete No. 0001",
                Estado = "A",
                EstadoDescripcion = "Activo"
            };
        }

        public static PaqueteDetalle PaqueteDetalle()
        {
            return new PaqueteDetalle
            {
                Id = 1,
                PaqueteId = 1,
                Paquete = Paquete(),
                ProductoId = 1,
                Producto = Producto()
            };
        }

        public static PedidoTipo PedidoTipo()
        {
            return new PedidoTipo
            {
                Id = 1,
                Codigo = "PTI001",
                Nombre = "Pedido Tipo No. 0001"
            };
        }

        public static Producto Producto()
        {
            return new Producto
            {
                Id = 1,
                Codigo = "BA001-V01-TEL-LAV-COL",
                Nombre = "Nombre del producto",
                Barcode = "1234567890123",
                Base = "BA001",
                Variante = "V01",
                Tela = "TEL",
                Lavado = "LAV",
                Color = "Indigo",
                Talla = "TALL",
                EdadId = 1,
                ProductoCategoriaId = 1,
                Existencia = 500,
                Edad = Edad(),
                ProductoCategoria = ProductoCategoria()
            };
        }

        public static ProductoCategoria ProductoCategoria()
        {
            return new ProductoCategoria
            {
                Id = 1,
                Codigo = "CAT001",
                Nombre = "Categoría de Producto 0001"
            };
        }

        public static ProductoImagen ProductoImagen()
        {
            return new ProductoImagen
            {
                Id = 1,
                ProductoId = 1,
                Secuencia = 10,
                Ruta = @"C:\Dir\SubDir\Filename.ext",
                Producto = new Producto()
            };
        }

        public static Ruta Ruta()
        {
            return new Ruta
            {
                Id = 1,
                Codigo = "RUT001",
                Nombre = "Nombre de la Ruta No. 001",
                ZonaId = 1,
                Zona = Zona()
            };
        }

        public static Supervisor Supervisor()
        {
            return new Supervisor
            {
                Id = 1,
                Codigo = "SUP001",
                Nombre = "Nombre del Supervisor No. 001",
                UsuarioId = 1,
                Usuario = Usuario()
            };
        }

        public static SupervisorZona SupervisorZona()
        {
            return new SupervisorZona
            {
                Id = 1,
                SupervisorId = 1,
                ZonaId = 1,
                Supervisor = Supervisor(),
                Zona = Zona()
            };
        }

        public static Usuario Usuario()
        {
            return new Usuario
            {
                Id = 1,
                Codigo = "USU0001",
                Nombre = "Nombre del Usuario No. 0001",
            };
        }

        public static Zona Zona()
        {
            return new Zona
            {
                Id = 1,
                Codigo = "ZON001",
                Nombre = "Nombre de la zona No. 001"
            };
        }
    }
}