using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Edad
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 3)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 10)]
        public string Nombre { get; set; }

        public virtual ICollection<Producto> ProductoSet { get; set; }
    }
}