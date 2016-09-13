using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class OrdenProduccionExternoBusiness
    {
        private static LBDATPROEntities _context;
        private const short CompaniaIdConst = 1;
        private const short SecuenciaMinima = 30;
        private const short SecuenciaMaxima = 160;
        private static List<CTRABAJO> _centros;

        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public short Ano { get; set; }

        [DataMember]
        public short Numero { get; set; }

        [DataMember]
        public string OrdenProduccion { get; set; }

        [DataMember]
        public string Patron { get; set; }

        [DataMember]
        public string Variante { get; set; }

        [DataMember]
        public string Tela { get; set; }

        [DataMember]
        public string Lavado { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public string ColorDescripcion { get; set; }

        [DataMember]
        public string Referencia { get; set; }

        [DataMember]
        public string EstadoId { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public string CentroTrabajoUltimaLecturaId { get; set; }

        [DataMember]
        public string SiguienteLecturaTipo { get; set; }

        [DataMember]
        public string CentroTrabajoSiguienteId { get; set; }

        [DataMember]
        public OrdenEstadoBusiness Estado { get; set; }

        [DataMember]
        public PasoRutaBusiness[] Ruta { get; set; }

        [DataMember]
        public CentroTrabajoBusiness CentroTrabajoUltimaLectura { get; set; }

        [DataMember]
        public CentroTrabajoBusiness CentroTrabajoSiguiente { get; set; }

        [DataMember]
        public string EstadoLeyenda { get; set; }


        #endregion

        #region Methods

        public static OrdenProduccionExternoBusiness[] GetByUsuarioPlanta(string usuario)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    //var estados = _context.PRDSTSSet.OrderBy(r => r.PrdSecSts).ToList();
                    _centros = _context.CTRABAJOSet
                        .OrderBy(r => r.CIACOD)
                        .ThenBy(r => r.PrdCtCod)
                        .Where(r => r.CIACOD == CompaniaIdConst)
                        .ToList();

                    var planta = _context.CORPLASet.FirstOrDefault(r => r.PrdPrvUsu == usuario);
                    if (planta == null)
                    {
                        throw new Exception($"No existe planta para el usuario: {usuario}");
                    }

                    var ordenes = (from p in _context.CTPLANTASet
                        join o in _context.CUTARC3Set on
                            new {a = p.CIACOD, b = p.PrdAnoCor, c = p.PrdNumCor} equals
                            new {a = o.CIACOD, b = o.PrdAnoCor, c = o.PrdNumCor}
                        join s in _context.PRDSTSSet on
                            o.PrdStsCor equals s.PrdStsCor
                        join c in _context.FACCOLSet on
                            new {a = o.CIACOD, b = o.FacCCol} equals
                            new {a = c.CiaCod, b = c.FacCCol}
                        where p.CIACOD == CompaniaIdConst &&
                              p.PrdCtPlCod == planta.PrdCorFab &&
                              s.PrdSecSts > SecuenciaMinima &&
                              s.PrdSecSts < SecuenciaMaxima
                        orderby p.CIACOD, p.PrdAnoCor, p.PrdNumCor
                        select new {Ruta = p, Orden = o, Estado = s, Color = c}).GroupBy(
                            r => new {r.Orden.CIACOD, r.Orden.PrdAnoCor, r.Orden.PrdNumCor})
                        .Select(g => g.FirstOrDefault())
                        .ToList();

                    var lista = new List<OrdenProduccionExternoBusiness>();
                    
                    OrdenProduccionExternoBusiness ord = null;
                    var ruta = new List<PasoRutaBusiness>();
                    var ordenIdCntrl = "";

                    foreach (var orden in ordenes)
                    {
                        var ubicacion = BuscarUbicacion(orden.Orden.CIACOD, orden.Orden.PrdAnoCor, orden.Orden.PrdNumCor, planta.PrdCorFab);

                        if (ubicacion == null) continue;

                        var ordenId = orden.Orden.PrdNumCor.ToString("0000") + "-" +
                                       orden.Orden.PrdAnoCor.ToString("00");
                        var estado = new OrdenEstadoBusiness
                        {
                            Id = orden.Estado.PrdStsCor,
                            Area = orden.Estado.PrdAreSts,
                            CentroCostoAlias = orden.Estado.PrdAliCCos,
                            CentroTrabajoId = orden.Estado.PrdCTraba,
                            Descripcion = orden.Estado.PrdDesSts,
                            Secuencia = orden.Estado.PrdSecSts
                        };
                        var centroTrabajoUltimaLectura = _centros
                            .FirstOrDefault(r => r.CIACOD == CompaniaIdConst && r.PrdCtCod == ubicacion.CentroTrabajoActualId);
                        var centroTrabajoSiguiente = _centros.FirstOrDefault(
                            r => r.CIACOD == CompaniaIdConst && r.PrdCtCod == ubicacion.CentroTrabajoSiguienteId);

                        if (ordenIdCntrl != ordenId)
                        {
                            if (ord != null)
                            {
                                ord.Ruta = ruta.OrderBy(r=>r.Secuencia).ToArray();
                                lista.Add(ord);
                            }
                            var color = orden.Color?.FacDCol.Trim() ?? "No Color";
                            ord = new OrdenProduccionExternoBusiness
                            {
                                CompaniaId = orden.Orden.CIACOD,
                                Ano = orden.Orden.PrdAnoCor,
                                Numero = orden.Orden.PrdNumCor,
                                OrdenProduccion = $"{orden.Orden.PrdNumCor.ToString("0000")}-" +
                                                  $"{orden.Orden.PrdAnoCor.ToString("00")}",
                                Patron = orden.Orden.PrdCodArt,
                                Variante = orden.Orden.FacCodMdl,
                                Tela = orden.Orden.FacCodTel,
                                Lavado = orden.Orden.FacCodRef,
                                Color = color,
                                ColorDescripcion = orden.Color.FacDCol.Trim(),
                                Referencia = $"{orden.Orden.PrdCodArt.Trim()}-{orden.Orden.FacCodMdl.Trim()}-" +
                                             $"{orden.Orden.FacCodTel.Trim()}-{orden.Orden.FacCodRef.Trim()}-{orden.Orden.FacCCol.Trim()}",
                                EstadoId = orden.Orden.PrdStsCor,
                                Cantidad = orden.Orden.OrdTotUnd ?? 0,
                                Estado = estado,
                                CentroTrabajoUltimaLecturaId = ubicacion.CentroTrabajoActualId,
                                CentroTrabajoSiguienteId = ubicacion.CentroTrabajoSiguienteId,
                                CentroTrabajoUltimaLectura = centroTrabajoUltimaLectura != null
                                    ? new CentroTrabajoBusiness
                                    {
                                        CompaniaId = centroTrabajoUltimaLectura.CIACOD,
                                        Id = centroTrabajoUltimaLectura.PrdCtCod,
                                        Nombre = centroTrabajoUltimaLectura.PrdCtDes
                                    }
                                    : null,
                                CentroTrabajoSiguiente = centroTrabajoSiguiente != null
                                    ? new CentroTrabajoBusiness
                                    {
                                        CompaniaId = centroTrabajoSiguiente.CIACOD,
                                        Id = centroTrabajoSiguiente.PrdCtCod,
                                        Nombre = centroTrabajoSiguiente.PrdCtDes
                                    }
                                    : null,
                                SiguienteLecturaTipo = ubicacion.LecturaTipo,
                                EstadoLeyenda = ubicacion.Leyenda
                            };
                            ruta = new List<PasoRutaBusiness>();
                        }
                        ruta.Add(new PasoRutaBusiness
                        {
                            CompaniaId = orden.Orden.CIACOD,
                            Ano = orden.Orden.PrdAnoCor,
                            Numero = orden.Orden.PrdNumCor,
                            CentroTrabajoId = orden.Ruta.PrdCtCod,
                            PlantaId = orden.Ruta.PrdCtPlCod,
                            Secuencia = orden.Estado.PrdSecSts ?? 0
                        });
                    }
                    if (ord != null)
                    {
                        ord.Ruta = ruta.OrderBy(r => r.Secuencia).ToArray();
                        lista.Add(ord);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness / GetByPlanta", exception);
            }
        }

        public static void SetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.CUTARC3Set
                        where r.CIACOD == companiaId &&
                              r.PrdAnoCor == ordenAno &&
                              r.PrdNumCor == ordenNumero
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.PrdStsCor = estadoId;
                        _context.SaveChanges();
                        return;
                    }
                    throw new Exception(
                        $"No se encontró orden de producción en la compañía: {companiaId.ToString("000")} con número: {ordenNumero.ToString("0000")}-{ordenNumero.ToString("00")}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness / SetEstado", exception);
            }
        }

        public static void GrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId,
            string tipo, string usuario)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var estados = _context.PRDSTSSet
                        .OrderBy(r => r.PrdSecSts)
                        .ToList();

                    var estadoActual = estados.FirstOrDefault(r => r.PrdCTraba == centroTrabajoId);
                    PRDSTS nuevoEstado;
                    if (estadoActual != null)
                    {
                        switch (tipo)
                        {
                            case "E":
                                nuevoEstado = estadoActual;
                                break;
                            case "S":
                                if (estados.FirstOrDefault(r => r.PrdSecSts > estadoActual.PrdSecSts) != null)
                                {
                                    nuevoEstado = estados.FirstOrDefault(r => r.PrdSecSts > estadoActual.PrdSecSts);
                                }
                                else
                                {
                                    return;
                                }
                                break;
                            default:
                                return;
                        }
                    }
                    else
                    {
                        return;
                    }

                    var lecturas = from r in _context.ORDCENTRSet
                        where r.CIACOD == companiaId &&
                              r.PrdAnoCor == ordenAno &&
                              r.PrdNumCor == ordenNumero &&
                              r.PrdCtCod == centroTrabajoId
                        select r;
                    foreach (var lectura in lecturas)
                    {
                        switch (tipo)
                        {
                            case "E":
                                lectura.PrdLecMan = 9;
                                lectura.PrdCtFecI = DateTime.Now;
                                lectura.PrdCtUsrEn = usuario;
                                break;
                            case "S":
                                lectura.PrdLecMan = 9;
                                lectura.PrdCtFecF = DateTime.Now;
                                lectura.PRdCtUsrSa = usuario;
                                break;
                        }
                    }
                    var orden = (from r in _context.CUTARC3Set
                        where r.CIACOD == companiaId &&
                              r.PrdAnoCor == ordenAno &&
                              r.PrdNumCor == ordenNumero
                        select r).FirstOrDefault();
                    if (orden != null && nuevoEstado != null)
                    {
                        orden.PrdStsCor = nuevoEstado.PrdStsCor;
                    }

                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness / GrabarLectura", exception);
            }
        }

        public static void SetEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var orden = (from r in _context.CUTARC3Set
                                 where r.CIACOD == companiaId &&
                                       r.PrdAnoCor == ordenAno &&
                                       r.PrdNumCor == ordenNumero
                                 select r).FirstOrDefault();
                    if (orden != null)
                    {
                        orden.PrdStsCor = "8";
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness / SetEstadoEnviarIntermoda", exception);
            }
        }

        private static Ubicacion BuscarUbicacion(short companiaId, short ordenAno, short ordenNumero, string plantaId)
        {
            var ubicacion = new Ubicacion();

            var lecturas = (from r in _context.ORDCENTRSet
                join s in _context.PRDSTSSet on
                    r.PrdCtCod equals s.PrdCTraba
                join c in _context.CTPLANTASet on
                    new {a=r.CIACOD, b=r.PrdAnoCor, c=r.PrdNumCor, d=r.PrdCtCod} equals 
                    new {a=c.CIACOD, b=c.PrdAnoCor, c=c.PrdNumCor, d=c.PrdCtCod}
                where r.CIACOD == companiaId &&
                      r.PrdAnoCor == ordenAno &&
                      r.PrdNumCor == ordenNumero &&
                      r.PrdCtBulto == 1 &&                  // Primer Bulto solamente
                      s.PrdSecSts > SecuenciaMinima &&
                      s.PrdSecSts < SecuenciaMaxima &&
                      c.PrdCtPlCod == plantaId
                orderby r.CIACOD, r.PrdAnoCor, r.PrdNumCor, r.PrdCtBulto, s.PrdSecSts
                select new {Orden = r, Estado = s}).ToList();

            if (!lecturas.Any()) return null;

            if (lecturas.All(r => r.Orden.PrdCtFecI == null))
            {
                // No hay lecturas => Pendiente de primer
                ubicacion.CentroTrabajoActualId = lecturas.FirstOrDefault()?.Orden.PrdCtCod;
                ubicacion.CentroTrabajoSiguienteId = ubicacion.CentroTrabajoActualId;
                ubicacion.Leyenda = "En Espera";
                ubicacion.LecturaTipo = "E";
                return ubicacion;
            }
            
            // Primer lectura con entrada y sin salida
            var lectura = lecturas.FirstOrDefault(r => r.Orden.PrdCtFecI != null && r.Orden.PrdCtFecF == null);
            if (lectura != null)
            {
                ubicacion.CentroTrabajoActualId = lectura.Orden.PrdCtCod;
                ubicacion.CentroTrabajoSiguienteId = lectura.Orden.PrdCtCod;
                ubicacion.Leyenda = "En Proceso";
                ubicacion.LecturaTipo = "S";
                return ubicacion;
            }

            // Primer lectura sin entrada 
            lectura = lecturas.FirstOrDefault(r => r.Orden.PrdCtFecI == null);
            if (lectura != null)
            {
                ubicacion.CentroTrabajoActualId = lectura.Orden.PrdCtCod;
                ubicacion.CentroTrabajoSiguienteId = ubicacion.CentroTrabajoActualId;
                ubicacion.Leyenda = "En Espera";
                ubicacion.LecturaTipo = "E";
                return ubicacion;
            }

            // Todo ha sido ejecutado
            lectura = lecturas.FirstOrDefault(r => r.Orden.PrdCtFecI != null && r.Orden.PrdCtFecF != null);
            if (lectura == null)
                return null;

            ubicacion.CentroTrabajoActualId = lecturas.LastOrDefault()?.Orden.PrdCtCod;
            ubicacion.CentroTrabajoSiguienteId = lecturas.LastOrDefault()?.Orden.PrdCtCod;
            ubicacion.Leyenda = "En Espera de enviar";
            ubicacion.LecturaTipo = "X";
            return ubicacion;
        }

        #endregion
    }

    class Ubicacion
    {
        public string CentroTrabajoActualId { get; set; }
        public string CentroTrabajoSiguienteId { get; set; }
        public string Leyenda { get; set; }
        public string LecturaTipo { get; set; }
    }
}