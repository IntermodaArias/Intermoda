using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    public class OrdenProduccionRutaBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        public short Secuencia { get; set; }

        public string CentroTrabajoId { get; set; }

        public string CentroTrabajoNombre { get; set; }

        public List<string> Previos { get; set; }

        #endregion

        #region Methods

        public static OrdenProduccionRutaBusiness[] GetByOrden(short companiaId, short ano, short numero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var rutaBase = _context.CTPLANTASet
                        .Join(_context.CTRABAJOSet,
                            r => new {a = r.CIACOD, b = r.PrdCtCod},
                            c => new {a = c.CIACOD, b = c.PrdCtCod},
                            (r, c) =>
                                new
                                {
                                    r.CIACOD,
                                    r.PrdAnoCor,
                                    r.PrdNumCor,
                                    r.PrdCtCod,
                                    c.PrdCtDes,
                                    r.PrdCtORden,
                                    c.PrdCTWor,
                                    c.PrdCtSts
                                })
                        .Where(e => e.CIACOD == companiaId)
                        .Where(e => e.PrdAnoCor == ano)
                        .Where(e => e.PrdNumCor == numero)
                        .OrderBy(e => e.CIACOD)
                        .ThenBy(e => e.PrdAnoCor)
                        .ThenBy(e => e.PrdNumCor)
                        .ThenBy(e => e.PrdCtORden)
                        .Select(r =>
                            new OrdenProduccionRutaBusiness
                            {
                                Secuencia = r.PrdCtORden.Value,
                                CentroTrabajoId = r.PrdCtCod,
                                CentroTrabajoNombre = r.PrdCtDes
                            }).ToArray();

                    foreach (var paso in rutaBase)
                    {
                        var secuencia = paso.Secuencia;
                        var secuenciaPrevia = rutaBase
                            .FirstOrDefault(r => r.Secuencia < secuencia)?
                            .Secuencia ?? 0;
                        paso.Previos = rutaBase
                            .Where(r => r.Secuencia == secuenciaPrevia)
                            .Select(r => r.CentroTrabajoId)
                            .ToList();
                    }
                    return rutaBase;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionRutaBusiness / GetByOrden", exception);
            }
        }

        #endregion
    }
}