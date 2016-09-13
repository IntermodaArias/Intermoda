using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class InventarioFisicoDetalle
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int InventarioFisicoId { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public virtual InventarioFisico InventarioFisico { get; set; }

        [DataMember]
        public virtual Producto Producto { get; set; }
    }
}