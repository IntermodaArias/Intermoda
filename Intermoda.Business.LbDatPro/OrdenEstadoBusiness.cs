using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class OrdenEstadoBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public short? Secuencia { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Area { get; set; }

        [DataMember]
        public string CentroCostoAlias { get; set; }

        [DataMember]
        public string CentroTrabajoId { get; set; }

        #endregion

        #region Methods

        public static OrdenEstadoBusiness Get(string id)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return _context.PRDSTSSet
                        .Select(
                            r => new OrdenEstadoBusiness
                            {
                                Id = r.PrdStsCor,
                                Secuencia = r.PrdSecSts,
                                Descripcion = r.PrdDesSts,
                                Area = r.PrdAreSts,
                                CentroCostoAlias = r.PrdAliCCos,
                                CentroTrabajoId = r.PrdCTraba
                            })
                        .FirstOrDefault(s => s.Id == id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenEstadoBusiness / Get", exception);
            }
        }

        #endregion
    }
}