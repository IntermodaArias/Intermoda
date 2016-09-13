using System.Runtime.Serialization;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class CentroTrabajoBusiness
    {
        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        #endregion
    }
}