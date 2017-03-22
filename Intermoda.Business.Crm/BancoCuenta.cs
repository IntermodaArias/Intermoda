using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class BancoCuenta
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int BancoId { get; set; }

        [DataMember]
        [StringLength(64)]
        public string CuentaNumero { get; set; }

        [DataMember]
        public int MonedaId { get; set; }

        [DataMember]
        public virtual Banco Banco { get; set; }

        [DataMember]
        public virtual Moneda Moneda { get; set; }
    }
}