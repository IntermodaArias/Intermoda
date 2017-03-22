using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Pais
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        public virtual ICollection<Ciudad> CiudadSet { get; set; } = new HashSet<Ciudad>();

        public virtual ICollection<Cliente> ClienteSet { get; set; } = new HashSet<Cliente>();

        public virtual ICollection<ClienteDireccion> ClienteDireccionSet { get; set; } = 
            new HashSet<ClienteDireccion>();
    }
}