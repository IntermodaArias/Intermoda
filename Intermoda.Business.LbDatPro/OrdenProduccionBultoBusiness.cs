using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class OrdenProduccionBultoBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public short OrdenAno { get; set; }

        [DataMember]
        public short OrdenNumero { get; set; }

        [DataMember]
        public short Numero { get; set; }

        [DataMember]
        public string TallaCodigo { get; set; }

        [DataMember]
        public short Cantidad { get; set; }

        [DataMember]
        public TallaBusiness Talla { get; set; }

        #endregion

        #region Methods

        public static OrdenProduccionBultoBusiness[] GetBultosByOrdenProduccion(short companiaId, short ordenAno,
            short ordenNumero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var bultos = _context.CUTARC1Set
                        .Where(r => r.CIACOD == companiaId)
                        .Where(r => r.PrdAnoCor == ordenAno)
                        .Where(r => r.PrdNumCor == ordenNumero)
                        .OrderBy(r => r.CIACOD)
                        .ThenBy(r => r.PrdAnoCor)
                        .ThenBy(r => r.PrdNumCor)
                        .ThenBy(r => r.PrdNoBund)
                        .ToList();

                    var lista = new List<OrdenProduccionBultoBusiness>();
                    foreach (var bulto in bultos)
                    {
                        var talla = _context.FACTALLSet
                            .Where(r => r.CiaCod == bulto.CIACOD)
                            .Where(r => r.FacCTall == bulto.FacCTall)
                            .Select(r => new TallaBusiness
                            {
                                CompaniaId = r.CiaCod,
                                Codigo = r.FacCTall,
                                Nombre = r.FacDTall,
                                Secuencia = r.FacSecTal ?? 0
                            })
                            .FirstOrDefault();

                        lista.Add(new OrdenProduccionBultoBusiness
                        {
                            CompaniaId = bulto.CIACOD,
                            OrdenAno = bulto.PrdAnoCor,
                            OrdenNumero = bulto.PrdNumCor,
                            Numero = bulto.PrdNoBund,
                            TallaCodigo = bulto.FacCTall,
                            Cantidad = bulto.PrdCanBun ?? 0,
                            Talla = talla
                        });
                    }
                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionBultoBusiness / GetByOrdenProduccion", exception);
            }
        }

        public static OrdenProduccionTallaBusiness[] GetTallasByOrdenProduccion(short companiaId, short ordenAno,
            short ordenNumero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var bultos = _context.CUTARC1Set
                        .Where(r => r.CIACOD == companiaId)
                        .Where(r => r.PrdAnoCor == ordenAno)
                        .Where(r => r.PrdNumCor == ordenNumero)
                        .OrderBy(r => r.CIACOD)
                        .ThenBy(r => r.PrdAnoCor)
                        .ThenBy(r => r.PrdNumCor)
                        .ThenBy(r => r.PrdNoBund)
                        .ToList();

                    var lista = new List<OrdenProduccionTallaBusiness>();
                    foreach (var bulto in bultos)
                    {
                        
                        var reg = lista.FirstOrDefault(r =>
                            r.CompaniaId == bulto.CIACOD &&
                            r.OrdenAno == bulto.PrdAnoCor &&
                            r.OrdenNumero == bulto.PrdNumCor &&
                            r.TallaCodigo == bulto.FacCTall);
                        if (reg == null)
                        {
                            var talla = _context.FACTALLSet
                                .Where(r => r.CiaCod == bulto.CIACOD)
                                .Where(r => r.FacCTall == bulto.FacCTall)
                                .Select(r => new TallaBusiness
                                {
                                    CompaniaId = r.CiaCod,
                                    Codigo = r.FacCTall,
                                    Nombre = r.FacDTall,
                                    Secuencia = r.FacSecTal ?? 0
                                })
                                .FirstOrDefault();

                            lista.Add(new OrdenProduccionTallaBusiness
                            {
                                CompaniaId = bulto.CIACOD,
                                OrdenAno = bulto.PrdAnoCor,
                                OrdenNumero = bulto.PrdNumCor,
                                TallaCodigo = bulto.FacCTall,
                                Cantidad = bulto.PrdCanBun ?? 0,
                                Talla = talla
                            });
                        }
                        else
                        {
                            reg.Cantidad += bulto.PrdCanBun ?? 0;
                        }
                    }
                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionBultoBusiness / GetByOrdenProduccion", exception);
            }
        }

        #endregion
    }
}