using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class AsesorRuta
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int AsesorId { get; set; }

        [DataMember]
        public int RutaId { get; set; }

        [DataMember]
        public virtual Asesor Asesor { get; set; }

        [DataMember]
        public virtual Ruta Ruta { get; set; }
    }
}