using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class OrdenProduccionLecturaBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public string CentroTrabajoId { get; set; }

        [DataMember]
        public DateTime? Entrada { get; set; }
        
        [DataMember]
        public DateTime? Salida { get; set; }

        [DataMember]
        public short Bulto { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        #endregion

        #region Methods

        public static OrdenProduccionLecturaBusiness[] GetByOrden(short companiaId, short ano, short numero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return _context.ORDCENTRSet
                        .Join(_context.CUTARC1Set,
                            o => new {a = o.CIACOD, b = o.PrdAnoCor, c = o.PrdNumCor, d = o.PrdCtBulto},
                            b => new {a = b.CIACOD, b = b.PrdAnoCor, c = b.PrdNumCor, d = b.PrdNoBund},
                            (o, b) =>
                                new
                                {
                                    o.CIACOD,
                                    o.PrdAnoCor,
                                    o.PrdNumCor,
                                    o.PrdCtCod,
                                    o.PrdCtFecI,
                                    o.PrdCtFecF,
                                    o.PrdCtBulto,
                                    b.PrdCanBun
                                })
                        .Where(r => r.CIACOD == companiaId)
                        .Where(r => r.PrdAnoCor == ano)
                        .Where(r => r.PrdNumCor == numero)
                        .Select(r =>
                            new OrdenProduccionLecturaBusiness
                            {
                                CentroTrabajoId = r.PrdCtCod,
                                Bulto = r.PrdCtBulto,
                                Cantidad = r.PrdCanBun ?? 0,
                                Entrada = r.PrdCtFecI,
                                Salida = r.PrdCtFecF
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionLecturaBusiness / GetByOrden", exception);
            }
        }

        #endregion
    }
}