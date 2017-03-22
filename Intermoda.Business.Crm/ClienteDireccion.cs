using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class ClienteDireccion
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ClienteId { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Direccion1 { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Direccion2 { get; set; }

        [DataMember]
        [StringLength(64)]
        public string Direccion3 { get; set; }

        [DataMember]
        public int PaisId { get; set; }

        [DataMember]
        public int CiudadId { get; set; }

        [DataMember]
        [StringLength(32), MinLength(7)]
        public string Telefono { get; set; }

        [DataMember]
        public string  Email { get; set; }

        [DataMember]
        [StringLength(256)]
        public bool DireccionPrincipal { get; set; }

        [DataMember]
        public virtual Cliente Cliente { get; set; }

        [DataMember]
        public virtual Pais Pais { get; set; }

        [DataMember]
        public virtual Ciudad Ciudad { get; set; }
    }
}