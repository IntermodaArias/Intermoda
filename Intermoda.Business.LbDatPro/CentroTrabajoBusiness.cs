using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class CentroTrabajoBusiness
    {
        private static LBDATPROEntities _context;
        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short Secuencia { get; set; }

        #endregion

        #region Methods

        public static CentroTrabajoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return _context.CTRABAJOSet
                        .Where(r => r.CIACOD == Compania)
                        .Where(r => r.PrdCtSts == 1)
                        .OrderBy(r => r.PrdCTWor)
                        .ThenBy(r => r.PrdCtCod)
                        .Select(r =>
                            new CentroTrabajoBusiness
                            {
                                CompaniaId = r.CIACOD,
                                Id = r.PrdCtCod,
                                Nombre = r.PrdCtDes,
                                Secuencia = r.PrdCTWor ?? 0
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}