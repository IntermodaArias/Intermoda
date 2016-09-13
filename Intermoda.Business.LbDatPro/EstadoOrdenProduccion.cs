using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class EstadoOrdenProduccion
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
        public string CentroTrabajoCodigo { get; set; }

        #endregion

        #region Methods

        public static EstadoOrdenProduccion Get(string estadoId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.PRDSTSSet
                        where r.PrdStsCor == estadoId
                        select new EstadoOrdenProduccion
                        {
                            Id = r.PrdStsCor,
                            Secuencia = r.PrdSecSts,
                            Area = r.PrdAreSts,
                            CentroCostoAlias = r.PrdAliCCos,
                            CentroTrabajoCodigo = r.PrdCTraba,
                            Descripcion = r.PrdDesSts
                        }).FirstOrDefault();

                    if (reg != null)
                        return reg;

                    throw new Exception($"No se ha encontrado estado de orden de producción con Id: {estadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EstadoOrdenProduccion / Get", exception);
            }
        }

        #endregion
    }
}