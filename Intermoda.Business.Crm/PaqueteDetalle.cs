using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class PaqueteDetalle
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int PaqueteId { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public virtual Paquete Paquete { get; set; }

        [DataMember]
        public virtual Producto Producto { get; set; }
    }
}