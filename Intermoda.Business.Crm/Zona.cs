using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Zona
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 3)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 10)]
        public string Nombre { get; set; }

        public virtual ICollection<SupervisorZona> SupervisorSet { get; set; } = new HashSet<SupervisorZona>();

        public virtual ICollection<Asesor> AsesorSet { get; set; } = new HashSet<Asesor>();

        public virtual ICollection<Ruta> RutaSet { get; set; } = new HashSet<Ruta>();
    }
}