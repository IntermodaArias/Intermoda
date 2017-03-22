using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Intermoda.Business.Crm.Entities
{
    [DataContract]
    public class Moneda
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [StringLength(32, MinimumLength = 1)]
        public string Codigo { get; set; }

        [DataMember]
        [StringLength(64, MinimumLength = 8)]
        public string Nombre { get; set; }

        [DataMember]
        [StringLength(3, MinimumLength = 1)]
        public string Simbolo { get; set; }

        public virtual ICollection<Cliente> ClienteSet { get; set; } = new HashSet<Cliente>();

        public virtual ICollection<CarteraDocumento> CarteraDocumentoSet { get; set; } =
            new HashSet<CarteraDocumento>();

        public virtual ICollection<CarteraDocumentoDetallePago> CarteraDocumentoDetallePagoSet { get; set; } =
            new HashSet<CarteraDocumentoDetallePago>();

        public virtual ICollection<Empresa> EmpresaSet { get; set; } = new HashSet<Empresa>();

        public virtual ICollection<BancoCuenta> BancoCuentaSet { get; set; } = new HashSet<BancoCuenta>();
    }
}