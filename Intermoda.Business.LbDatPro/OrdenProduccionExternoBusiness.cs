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
        private const string PlantaIntermoda = "01";
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
                            new {a = c.CIACOD, b = c.FacCCol}
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
                        //var lecturas = MaquiladoLecturaBusiness.GetLecturas(orden.Orden.CIACOD, orden.Orden.PrdAnoCor,
                        //    orden.Orden.PrdNumCor).ToList();
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
                        //var lect = lecturas.FirstOrDefault(r => r.CentroTrabajoCodigo == orden.Ruta.PrdCtCod);
                        ruta.Add(new PasoRutaBusiness
                        {
                            CompaniaId = orden.Orden.CIACOD,
                            Ano = orden.Orden.PrdAnoCor,
                            Numero = orden.Orden.PrdNumCor,
                            CentroTrabajoId = orden.Ruta.PrdCtCod,
                            PlantaId = orden.Ruta.PrdCtPlCod,
                            Secuencia = orden.Estado.PrdSecSts ?? 0,
                            //Estado = lect != null ? lect.Estado : "",
                            //LecturaEntrada = lect?.LecturaEntrada,
                            //LecturaSalida = lect?.LecturaSalida,
                            //TiempoEnProceso = lect?.TiempoEnProceso,
                            //TiempoEnPlanta = lect?.TiempoEnPlanta
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

        public static OrdenProduccionExternoBusiness[] Get()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var plantas = new List<string> {"20","60","61","62"};
                    //var estados = _context.PRDSTSSet.OrderBy(r => r.PrdSecSts).ToList();
                    _centros = _context.CTRABAJOSet
                        .OrderBy(r => r.CIACOD)
                        .ThenBy(r => r.PrdCtCod)
                        .Where(r => r.CIACOD == CompaniaIdConst)
                        .ToList();

                    var lista = new List<OrdenProduccionExternoBusiness>();

                    foreach (var planta in plantas)
                    {
                        var ords = (from p in _context.CTPLANTASet
                            join o in _context.CUTARC3Set on
                                new {a = p.CIACOD, b = p.PrdAnoCor, c = p.PrdNumCor} equals
                                new {a = o.CIACOD, b = o.PrdAnoCor, c = o.PrdNumCor}
                            join s in _context.PRDSTSSet on
                                o.PrdStsCor equals s.PrdStsCor
                            join c in _context.FACCOLSet on
                                new {a = o.CIACOD, b = o.FacCCol} equals
                                new {a = c.CIACOD, b = c.FacCCol}
                            join x in _context.CORPLASet on
                                p.PrdCtPlCod equals x.PrdCorFab
                            where p.CIACOD == CompaniaIdConst &&
                                  p.PrdCtPlCod == planta &&
                                  s.PrdSecSts > SecuenciaMinima &&
                                  s.PrdSecSts < SecuenciaMaxima
                            orderby p.CIACOD, p.PrdCtPlCod, p.PrdAnoCor, p.PrdNumCor
                            select new {Ruta = p, Orden = o, Planta = x, Estado = s, Color = c})
                            .ToList();

                        var ordenes = ords.GroupBy(
                            r => new {r.Orden.CIACOD, r.Ruta.PrdCtPlCod, r.Orden.PrdAnoCor, r.Orden.PrdNumCor})
                            .Select(g => g.FirstOrDefault())
                            .ToList();

                        OrdenProduccionExternoBusiness ord = null;
                        var ruta = new List<PasoRutaBusiness>();
                        var ordenIdCntrl = "";

                        foreach (var orden in ordenes)
                        {
                            var lecturas = MaquiladoLecturaBusiness.GetLecturas(orden.Orden.CIACOD, orden.Orden.PrdAnoCor,
                                orden.Orden.PrdNumCor).ToList();
                            var ubicacion = BuscarUbicacion(orden.Orden.CIACOD, orden.Orden.PrdAnoCor, orden.Orden.PrdNumCor, planta);

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
                                ordenIdCntrl = ordenId;
                                if (ord != null)
                                {
                                    ord.Ruta = ruta.OrderBy(r => r.Secuencia).ToArray();
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
                            var lect = lecturas.FirstOrDefault(r => r.CentroTrabajoCodigo == orden.Ruta.PrdCtCod);
                            ruta.Add(new PasoRutaBusiness
                            {
                                CompaniaId = orden.Orden.CIACOD,
                                Planta = orden.Planta.PrdCorDes,
                                Ano = orden.Orden.PrdAnoCor,
                                Numero = orden.Orden.PrdNumCor,
                                CentroTrabajoId = orden.Ruta.PrdCtCod,
                                CentroTrabajo = lect != null ? lect.CentroTrabajo.Nombre : "",
                                PlantaId = orden.Ruta.PrdCtPlCod,
                                Secuencia = orden.Estado.PrdSecSts ?? 0,
                                Estado = lect != null ? lect.Estado : "",
                                LecturaEntrada = lect?.LecturaEntrada,
                                LecturaSalida = lect?.LecturaSalida,
                                TiempoEnProceso = lect?.TiempoEnProceso,
                                TiempoEnPlanta = lect?.TiempoEnPlanta
                            });
                        }
                        if (ord != null)
                        {
                            ord.Ruta = ruta.OrderBy(r => r.Secuencia).ToArray();
                            lista.Add(ord);
                        }
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness / GetByPlanta", exception);
            }
        }

        public static MaquiladoTrabajoEnProceso[] GetMaquiladoTrabajoEnProceso()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var listaBase = _context.MaquiladoTrabajoEnProceso().ToList();

                    var lista = listaBase.Select(r => new TeP
                    {
                        CompaniaId = r.CompaniaId,
                        OrdenAno = r.OrdenAno,
                        OrdenNumero = r.OrdenNumero,
                        OrdenProduccion = $"{r.OrdenNumero.ToString("0000")}-{r.OrdenAno.ToString("00")}",
                        PlantaId = r.PlantaId,
                        PlantaNombre = r.PlantaNombre,
                        PlantaIniciales = r.PlantaIniciales,
                        BultoNumero = r.BultoNumero,
                        Cantidad = r.Cantidad ?? 0,
                        CentroTrabajoId = r.CentroTrabajoId,
                        CentroTrabajoNombre = r.CentroTrabajoNombre,
                        CentroTrabajoSecuencia = r.CentroTrabajoSecuencia ?? 0,
                        FechaEntrada = r.FechaEntrada,
                        FechaSalida = r.FechaSalida,
                        Patron = r.Patron,
                        Variante = r.Variante,
                        Tela = r.Tela,
                        Lavado = r.Lavado,
                        ColorId = r.ColorId,
                        ColorNombre = r.ColorNombre,
                        EstadoId = r.EstadoId,
                        EstadoNombre = r.EstadoNombre,
                        EstadoSecuencia = r.EstadoSecuencia ?? 0,
                        EnviadaContratista = r.EnvioContratista
                    }).ToList();

                    lista = lista
                        .OrderBy(r => r.CompaniaId)
                        .ThenBy(r => r.OrdenAno)
                        .ThenBy(r => r.OrdenNumero)
                        .ThenBy(r => r.EstadoSecuencia)
                        .ToList();

                    var tep = new List<MaquiladoTrabajoEnProceso>();

                    var ordenes = lista
                        .GroupBy(r => r.OrdenProduccion)
                        .Select(r => r.First())
                        .ToList();

                    foreach (var orden in ordenes)
                    {
                        var subLista = lista
                            .Where(r => r.OrdenAno == orden.OrdenAno && r.OrdenNumero == orden.OrdenNumero)
                            .ToList();
                        var ruta = subLista
                            .GroupBy(r => r.CentroTrabajoId)
                            .Select(r => r.First())
                            .ToList();
                        var tiempoPlanta = new TimeSpan(0);
                        var ini = false;
                        foreach (var paso in ruta)
                        {
                            var bultos = lista
                                .Where(r => r.OrdenProduccion == orden.OrdenProduccion &&
                                            r.CentroTrabajoId == paso.CentroTrabajoId)
                                .ToList();
                            var cantidad = bultos.Sum(r => r.Cantidad);
                            var entrada = bultos.Min(r => r.FechaEntrada);
                            var salida = bultos.Max(r => r.FechaSalida);
                            TimeSpan tiempoProceso;

                            if (!ini)
                            {
                                if (paso.EnviadaContratista == null)
                                {
                                    tiempoProceso = new TimeSpan(0);
                                }
                                else if (entrada == null)
                                {
                                    tiempoProceso = DateTime.Now - paso.EnviadaContratista.Value;
                                }
                                else
                                {
                                    tiempoProceso = (TimeSpan) (entrada - paso.EnviadaContratista);
                                }
                                tiempoPlanta += tiempoProceso;

                                tep.Add(new MaquiladoTrabajoEnProceso
                                {
                                    Planta = new PlantaBusiness
                                    {
                                        Id = paso.PlantaId,
                                        Iniciales = paso.PlantaIniciales,
                                        Descripcion = paso.PlantaNombre
                                    },
                                    CentroTrabajo = new CentroTrabajoBusiness
                                    {
                                        CompaniaId = paso.CompaniaId,
                                        Id = "TR",
                                        Nombre = "Transito",
                                        Secuencia = 0
                                    },
                                    OrdenAno = paso.OrdenAno,
                                    OrdenNumero = paso.OrdenNumero,
                                    Patron = paso.Patron,
                                    Variante = paso.Variante,
                                    Tela = paso.Tela,
                                    Lavado = paso.Lavado,
                                    Color = paso.ColorId,
                                    ColorNombre = paso.ColorNombre,
                                    Cantidad = cantidad,
                                    TiempoProceso = tiempoProceso,
                                    TiempoPlanta = tiempoPlanta,
                                    Entrada = paso.EnviadaContratista,
                                    Salida = entrada,
                                    Estado = paso.EstadoNombre
                                });
                                ini = true;
                            }

                            if (entrada == null)
                            {
                                tiempoProceso = new TimeSpan(0);
                            }
                            else if (salida == null)
                            {
                                tiempoProceso = (TimeSpan) (DateTime.Now - entrada);
                            }
                            else
                            {
                                tiempoProceso = (TimeSpan) (salida - entrada);
                            }
                            tiempoPlanta += tiempoProceso;

                            tep.Add(new MaquiladoTrabajoEnProceso
                            {
                                Planta = new PlantaBusiness
                                {
                                    Id = paso.PlantaId,
                                    Iniciales = paso.PlantaIniciales,
                                    Descripcion = paso.PlantaNombre
                                },
                                CentroTrabajo = new CentroTrabajoBusiness
                                {
                                    CompaniaId = paso.CompaniaId,
                                    Id = paso.CentroTrabajoId,
                                    Nombre = paso.CentroTrabajoNombre,
                                    Secuencia = paso.CentroTrabajoSecuencia
                                },
                                OrdenAno = paso.OrdenAno,
                                OrdenNumero = paso.OrdenNumero,
                                Patron = paso.Patron,
                                Variante = paso.Variante,
                                Tela = paso.Tela,
                                Lavado = paso.Lavado,
                                Color = paso.ColorId,
                                ColorNombre = paso.ColorNombre,
                                Cantidad = cantidad,
                                TiempoProceso = tiempoProceso,
                                TiempoPlanta = tiempoPlanta,
                                Entrada = entrada,
                                Salida = salida,
                                Estado = paso.EstadoNombre
                            });
                        }
                    }
                    return tep.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness / GetTeP", exception);
            }
        }

        public static OrdenProduccionExternoBusiness Get(short companiaId, short ordenAno, short ordenNumero,
            string centroTrabajoId, string tipo, string usuario)
        {
            try
            {
                var lista = GetByUsuarioPlanta(usuario);
                return (from r in lista
                    where r.CompaniaId == companiaId &&
                          r.OrdenProduccion == $"{ordenNumero.ToString("0000")}-" +
                          $"{ordenAno.ToString("00")}"
                    select r).FirstOrDefault();
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExternoBusiness /  Get", exception);
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

        public static OrdenProduccionExternoBusiness GrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId,
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
                                    return null;
                                }
                                break;
                            default:
                                return null;
                        }
                    }
                    else
                    {
                        return null;
                    }

                    var lecturaFecha = DateTime.Now;

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
                                lectura.PrdCtFecI = lecturaFecha;
                                lectura.PrdCtUsrEn = usuario;
                                break;
                            case "S":
                                lectura.PrdLecMan = 9;
                                lectura.PrdCtFecF = lecturaFecha;
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

                    return Get(companiaId, ordenAno, ordenNumero, centroTrabajoId, tipo, usuario);
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

    class TeP
    {
        public short CompaniaId { get; set; }
        public short OrdenAno { get; set; }
        public short OrdenNumero { get; set; }
        public string OrdenProduccion { get; set; }     //=> $"{OrdenNumero.ToString("0000")}-{OrdenAno.ToString("00")}";
        public string PlantaId { get; set; }
        public string PlantaNombre { get; set; }
        public string PlantaIniciales { get; set; }
        public short BultoNumero { get; set; }
        public int Cantidad { get; set; }
        public string CentroTrabajoId { get; set; }
        public string CentroTrabajoNombre { get; set; }
        public short CentroTrabajoSecuencia { get; set; }
        public DateTime? FechaEntrada { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Patron { get; set; }
        public string Variante { get; set; }
        public string Tela { get; set; }
        public string Lavado { get; set; }
        public string ColorId { get; set; }
        public string ColorNombre { get; set; }
        public string EstadoId { get; set; }
        public string EstadoNombre { get; set; }
        public int EstadoSecuencia { get; set; }
        public DateTime? EnviadaContratista { get; set; }
    }
}