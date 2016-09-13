using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class CarteraDocumentoTipo
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(3, MinimumLength = 3)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 5)]
        public string Nombre { get; set; }

        [DataMember]
        public DebitoCredito Tipo { get; set; }

        public virtual ICollection<CarteraDocumento> CarteraDocumentoSet { get; set; }

        public virtual ICollection<Cai> CaiSet { get; set; }
    }
}