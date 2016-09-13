using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Supervisor
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
        public int UsuarioId { get; set; }

        [DataMember]
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<SupervisorZona> ZonaSet { get; set; } = new HashSet<SupervisorZona>();
    }
}