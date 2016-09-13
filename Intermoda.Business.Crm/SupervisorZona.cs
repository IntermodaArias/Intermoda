using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class SupervisorZona
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int SupervisorId { get; set; }

        [DataMember]
        public int ZonaId { get; set; }

        [DataMember]
        public virtual Supervisor Supervisor { get; set; }

        [DataMember]
        public virtual Zona Zona { get; set; }
    }
}