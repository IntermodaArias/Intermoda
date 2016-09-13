using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class AcuerdoComercialDetalle
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int AcuerdoComercialId { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public decimal Precio { get; set; }

        [DataMember]
        public virtual AcuerdoComercial AcuerdoComercial { get; set; }

        [DataMember]
        public virtual Producto Producto { get; set; }
    }
}