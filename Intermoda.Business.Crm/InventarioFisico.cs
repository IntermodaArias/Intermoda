using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class InventarioFisico
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public bool Sincronizado { get; set; }

        [DataMember]
        public virtual Cliente Cliente { get; set; }

        public virtual ICollection<InventarioFisicoDetalle> InventarioFisicoDetalleSet { get; set; } =
            new HashSet<InventarioFisicoDetalle>();
    }
}