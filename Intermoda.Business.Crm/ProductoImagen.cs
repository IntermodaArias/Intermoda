using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class ProductoImagen
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProductoId { get; set; }

        [DataMember]
        public int Secuencia { get; set; }

        [DataMember]
        [StringLength(256)]
        public string Ruta { get; set; }

        [DataMember]
        public virtual Producto Producto { get; set; }
    }
}