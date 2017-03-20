using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro 
{
    [DataContract]
    public class MaquiladoLecturaBusiness
    {
        private static LBDATPROEntities _context;
        private const short SecuenciaMinima = 30;
        private const short SecuenciaMaxima = 160;

        #region Properties

        [DataMember]
        public string PlantaId { get; set; }

        [DataMember]
        public string Planta { get; set; }

        [DataMember]
        public string CentroTrabajoCodigo { get; set; }

        [DataMember]
        public string Estado { get; set; }

        [DataMember]
        public DateTime? LecturaEntrada { get; set; }

        [DataMember]
        public DateTime? LecturaSalida { get; set; }

        [DataMember]
        public TimeSpan? TiempoEnProceso { get; set; }

        [DataMember]
        public TimeSpan? TiempoEnPlanta { get; set; }

        public CentroTrabajoBusiness CentroTrabajo { get; set; }

        #endregion

        #region Methods

        public static MaquiladoLecturaBusiness[] GetLecturas(short companiaId, short ordenProduccionAno,
            short ordenProduccionNumero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var lecturas = new List<MaquiladoLecturaBusiness>();

                    var list = (from r in _context.ORDCENTRSet
                        join o in _context.CUTARC3Set on
                            new {a = r.CIACOD, b = r.PrdAnoCor, c = r.PrdNumCor} equals
                            new {a = o.CIACOD, b = o.PrdAnoCor, c = o.PrdNumCor}
                        join ct in _context.CTRABAJOSet on
                            new {a = r.CIACOD, b = r.PrdCtCod} equals
                            new {a = ct.CIACOD, b = ct.PrdCtCod}
                        join s in _context.PRDSTSSet on
                            o.PrdStsCor equals s.PrdStsCor
                        join p in _context.CORPLASet on
                            o.PrdCorFab equals p.PrdCorFab
                        where r.CIACOD == companiaId &&
                              r.PrdAnoCor == ordenProduccionAno &&
                              r.PrdNumCor == ordenProduccionNumero &&
                              s.PrdSecSts > SecuenciaMinima &&
                              s.PrdSecSts < SecuenciaMaxima
                        orderby r.CIACOD, r.PrdAnoCor, r.PrdNumCor, ct.PrdCTWor
                        select new {r, ct, p}).ToList();

                    var centro = "";
                    var ind = false;
                    DateTime? inicial = null;
                    DateTime? final = null;
                    var tiempoEnPlanta = new TimeSpan(0,0,0,0);
                    foreach (var item in list)
                    {
                        if (centro != item.r.PrdCtCod)
                        {
                            if (ind)
                            {
                                var timeSpan = final - inicial;
                                if (timeSpan != null)
                                    tiempoEnPlanta = tiempoEnPlanta + (TimeSpan)timeSpan;

                                string estado;
                                if (inicial == null)
                                {
                                    estado = "En Espera";
                                }
                                else if (final == null)
                                {
                                    estado = "En Proceso";
                                }
                                else
                                {
                                    estado = "Procesado";
                                }

                                lecturas.Add(new MaquiladoLecturaBusiness
                                {
                                    PlantaId = item.p.PrdCorFab,
                                    Planta = item.p.PrdCorDes,
                                    CentroTrabajoCodigo = item.r.PrdCtCod,
                                    CentroTrabajo = new CentroTrabajoBusiness
                                    {
                                        CompaniaId = item.r.CIACOD,
                                        Id = item.r.PrdCtCod,
                                        Nombre = item.ct.PrdCtDes,
                                        Secuencia = item.ct.PrdCTWor ?? 0
                                    },
                                    Estado = estado,
                                    LecturaEntrada = inicial,
                                    LecturaSalida = final,
                                    TiempoEnProceso = final - inicial,
                                    TiempoEnPlanta = tiempoEnPlanta
                                });
                            }
                            else
                            {
                                ind = true;
                            }
                            inicial = null;
                            final = null;
                        }
                        if (inicial == null && item.r.PrdCtFecI != null)
                        {
                            inicial = item.r.PrdCtFecI;
                        }
                        if (item.r.PrdCtFecF != null)
                        {
                            final = item.r.PrdCtFecF.Value;
                        }
                    }
                    return lecturas.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoLecturaBusiness / GetLecturas", exception);
            }
        }

        #endregion
        }
}