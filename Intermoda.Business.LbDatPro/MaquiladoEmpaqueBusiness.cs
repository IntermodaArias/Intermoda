using System.Runtime.Serialization;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class MaquiladoEmpaqueBusiness
    {
        [DataMember]
        public MaquiladoCajaBusiness Caja { get; set; }

        [DataMember]
        public MaquiladoCajaDetalleBusiness[] Detalle { get; set; }
    }
}