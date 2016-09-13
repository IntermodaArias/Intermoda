using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Produccion.Lecturas.Business.LbDatPro
{
    [DataContract]
    public class MaterialBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public int CodigoAlterno { get; set; }

        #endregion
    }
}