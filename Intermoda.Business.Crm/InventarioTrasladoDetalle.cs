using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class InventarioTrasladoDetalle
    {
        [DataMember] 
        public int Id { get; set; }

        [DataMember]
        public int InventarioTrasladoId { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public virtual InventarioTraslado InventarioTraslado { get; set; }

        [DataMember]
        public virtual Producto Producto { get; set; }
    }
}