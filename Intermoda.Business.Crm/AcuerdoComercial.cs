using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class AcuerdoComercial
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 3)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 10)]
        public string Nombre { get; set; }

        [DataMember]
        public DateTime FechaInicial { get; set; }

        [DataMember]
        public DateTime FechaFinal { get; set; }

        [DataMember]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<AcuerdoComercialDetalle> AcuerdoComercialDetalleSet { get; set; }
    }
}