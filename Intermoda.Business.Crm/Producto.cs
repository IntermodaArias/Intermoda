using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Producto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(32)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 10)]
        public string Nombre { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Barcode { get; set; }

        [DataMember]
        [StringLength(6, MinimumLength = 1)]
        public string Base { get; set; }

        [DataMember]
        [StringLength(6, MinimumLength = 1)]
        public string Variante { get; set; }

        [DataMember]
        [StringLength(6, MinimumLength = 1)]
        public string Tela { get; set; }

        [DataMember]
        [StringLength(6, MinimumLength = 1)]
        public string Lavado { get; set; }

        [DataMember]
        [StringLength(6, MinimumLength = 1)]
        public string Color { get; set; }

        [DataMember]
        [StringLength(6, MinimumLength = 1)]
        public string Talla { get; set; }

        [DataMember]
        public int EdadId { get; set; }

        [DataMember]
        public int ProductoCategoriaId { get; set; }

        [DataMember]
        public int Existencia { get; set; }

        [DataMember]
        public virtual Edad Edad { get; set; }

        [DataMember]
        public virtual ProductoCategoria ProductoCategoria { get; set; }

        public virtual ICollection<InventarioFisicoDetalle> InventarioFisicoDetalleSet { get; set; } =
            new HashSet<InventarioFisicoDetalle>();

        public virtual ICollection<InventarioTrasladoDetalle> InventarioTrasladoDetalleSet { get; set; } =
            new HashSet<InventarioTrasladoDetalle>();

        public virtual ICollection<AcuerdoComercialDetalle> AcuerdoComercialDetalleSet { get; set; } =
            new HashSet<AcuerdoComercialDetalle>();

        public virtual ICollection<PaqueteDetalle> PaqueteDetalleSet { get; set; } = new HashSet<PaqueteDetalle>();

        public virtual ICollection<CarteraDocumentoDetalleProducto> CarteraDocumentoDetalleProductoSet { get; set; } =
            new HashSet<CarteraDocumentoDetalleProducto>();

        public virtual ICollection<ProductoImagen> ProductoImagenSet { get; set; } = new HashSet<ProductoImagen>();
    }
}