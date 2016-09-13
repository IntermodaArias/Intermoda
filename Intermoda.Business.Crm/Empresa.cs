using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Empresa
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string DocumentoFiscal { get; set; }

        [DataMember]
        public int MonedaId { get; set; }

        [DataMember]
        public virtual Moneda Moneda { get; set; }

        public virtual ICollection<Cliente> ClienteSet { get; set; } = new HashSet<Cliente>();
    }
}