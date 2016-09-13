using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Ciudad
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int PaisId { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public virtual Pais Pais { get; set; }

        public virtual ICollection<Cliente> ClienteSet { get; set; } = new HashSet<Cliente>();
    }
}