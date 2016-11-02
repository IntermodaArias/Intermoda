using System.Runtime.Serialization;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class OrdenProduccionTallaBusiness
    {
        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public short OrdenAno { get; set; }

        [DataMember]
        public short OrdenNumero { get; set; }

        [DataMember]
        public string TallaCodigo { get; set; }

        [DataMember]
        public string Barras { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public TallaBusiness Talla { get; set; }
    }
}