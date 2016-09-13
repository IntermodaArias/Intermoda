using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class CarteraDocumentoDetallePago
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CarteraDocumentoId { get; set; }

        [DataMember]
        public int Linea { get; set; }

        [DataMember]
        public int PagoTipoId { get; set; }

        [DataMember]
        public int MonedaId { get; set; }

        [DataMember]
        public int? BancoId { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 5)]
        public string Referencia { get; set; }

        [DataMember]
        public decimal Monto { get; set; }

        [DataMember]
        public virtual CarteraDocumento CarteraDocumento { get; set; }

        [DataMember]
        public virtual PagoTipo PagoTipo { get; set; }

        [DataMember]
        public virtual Moneda Moneda { get; set; }

        [DataMember]
        public virtual Banco Banco { get; set; }
    }
}