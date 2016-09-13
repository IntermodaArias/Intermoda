using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Cai
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CarterDocumentoTipoId { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 6)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Descripcion { get; set; }

        [DataMember]
        public DateTime FechaMaximaEmision { get; set; }

        [DataMember]
        public short Establecimiento { get; set; }

        [DataMember]
        public short PuntoEmision { get; set; }

        [DataMember]
        public short TipoDocumento { get; set; }

        [DataMember]
        public virtual string Prefijo => $"{Establecimiento.ToString("000")}-" +
                                         $"{PuntoEmision.ToString("000")}-" +
                                         $"{TipoDocumento.ToString("00")}";

        [DataMember]
        public int NumeroInicial { get; set; }

        [DataMember]
        public int NumeroFinal { get; set; }

        [DataMember]
        public virtual CarteraDocumentoTipo CarteraDocumentoTipo { get; set; }

        public virtual ICollection<CarteraDocumento> CarteraDocumentoSet { get; set; }
    }
}