using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class CarteraDocumentoDetalleProducto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CarteraDocumentoId { get; set; }

        [DataMember]
        public int Linea { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public decimal Total => Cantidad*Precio;

        [DataMember]
        public virtual CarteraDocumento CarteraDocumento { get; set; }

        [DataMember]
        public virtual Producto Producto { get; set; }
    }
}