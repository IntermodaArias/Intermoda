using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Ruta
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 3)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 10)]
        public string Nombre { get; set; }

        [DataMember]
        public int ZonaId { get; set; }

        [DataMember]
        public virtual Zona Zona { get; set; }

        public virtual ICollection<AsesorRuta> AsesorRutaSet { get; set; } = new HashSet<AsesorRuta>();

        public virtual ICollection<Cliente> ClienteSet { get; set; } = new HashSet<Cliente>();
    }
}