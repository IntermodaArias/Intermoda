using System;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class CarteraDocumentoDetalleAplicacion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CarteraDocumentoDebitoId { get; set; }

        [DataMember]
        public int CarteraDocumentoCreditoId { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public decimal Aplicacion { get; set; }

        [DataMember]
        public virtual CarteraDocumento CarteraDocumentoDebito { get; set; }

        [DataMember]
        public virtual CarteraDocumento CarteraDocumentoCredito { get; set; }
    }
}