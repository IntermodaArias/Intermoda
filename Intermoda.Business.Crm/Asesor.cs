using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Asesor
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int UsuarioId { get; set; }

        [DataMember]
        public int ZonaId { get; set; }

        [DataMember]
        public virtual Usuario Usuario { get; set; }

        [DataMember]
        public virtual Zona Zona { get; set; }

        public virtual ICollection<AsesorRuta> AsesorRutaSet { get; set; } = new HashSet<AsesorRuta>();
    }
}