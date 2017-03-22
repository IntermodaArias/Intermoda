using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Parametro
    {
        [DataMember]
        public int CompaniaId { get; set; }

        [DataMember]
        [StringLength(32)]
        public string CompaniaCodigo { get; set; }

        [DataMember]
        [StringLength(256)]
        public string CompaniaNombre { get; set; }

        [DataMember]
        [StringLength(64)]
        public string CompaniaDireccion1 { get; set; }

        [DataMember]
        [StringLength(64)]
        public string CompaniaDireccion2 { get; set; }

        [DataMember]
        [StringLength(64)]
        public string CompaniaDireccion3 { get; set; }

        [DataMember]
        public byte[] CompaniaLogo { get; set; }

        [DataMember]
        public int AsesorId { get; set; }

        [DataMember]
        [StringLength(15)]
        public string IpPublica { get; set; }

        [DataMember]
        [StringLength(15)]
        public string IpPrivada { get; set; }

        [DataMember]
        public virtual Asesor Asesor { get; set; }
    }
}