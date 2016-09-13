using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class InventarioTraslado
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClienteOrigenId { get; set; }

        [DataMember]
        public int ClienteDestinoId { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public virtual Cliente ClienteOrigen { get; set; }

        [DataMember]
        public virtual Cliente ClienteDestino { get; set; }

        public virtual ICollection<InventarioTrasladoDetalle> InventarioTrasladoDetalleSet { get; set; }
    }
}