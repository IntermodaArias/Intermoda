using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Paquete
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
        [StringLength(3)]
        public string Estado { get; set; }

        [DataMember]
        [StringLength(64)]
        public string EstadoDescripcion { get; set; }

        public virtual ICollection<PaqueteDetalle> PaqueteDetalleSet { get; set; }

        public virtual ICollection<CarteraDocumento> CarteraDocumentoSet { get; set; }
    }
}