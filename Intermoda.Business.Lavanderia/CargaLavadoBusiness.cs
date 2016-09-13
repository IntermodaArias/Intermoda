using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class CargaLavadoBusiness
    {
        private static LavanderiaEntities _context;

        private const short CompaniaCodigo = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public short OrdenAno { get; set; }

        [DataMember]
        public short OrdenNumero { get; set; }

        [DataMember]
        public short CargaNumero { get; set; }

        [DataMember]
        public short Cantidad { get; set; }

        [DataMember]
        public int? Estado { get; set; }

        [DataMember]
        public int LavadorId { get; set; }

        [DataMember]
        public int OpcionLavadoId { get; set; }

        [DataMember]
        public short LavadoraTipoId { get; set; }

        [DataMember]
        public short? LavadoraId { get; set; }

        [DataMember]
        public DateTime? FechaEntrada { get; set; }

        [DataMember]
        public DateTime? FechaSalida { get; set; }

        [DataMember]
        public decimal CargaPeso { get; set; }

        [DataMember]
        public int CentroTrabajoId { get; set; }

        [DataMember]
        public decimal CapacidadUtilizada { get; set; }

        [DataMember]
        public decimal TiempoMinimoProceso { get; set; }

        [DataMember]
        public decimal? TiempoEstandarProceso { get; set; }

        [DataMember]
        public decimal TiempoMaximoProceso { get; set; }

        [DataMember]
        public string Tela { get; set; }

        [DataMember]
        public short ArmadoNumero { get; set; }

        [DataMember]
        public int? RequisicionQuimicoId { get; set; }

        #endregion

        #region Methods

        public static CargaLavadoBusiness Insert(CargaLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                { 
                    var reg = new CargaLavado
                    {
                        CargaLavadoCiaCod = model.CompaniaId,
                        CargaLavadoNumeroOrden = model.OrdenNumero,
                        CargaLavadoAno = model.OrdenAno,
                        CargaLavadoNumero = model.CargaNumero,
                        CargaLavadoUnidades = model.Cantidad,
                        CargaLavadoEstado = model.Estado,
                        CargaLavadoLavadoId = model.LavadorId,
                        CargaLavadoOpcionLavadoId = model.OpcionLavadoId,
                        CargaLavadoLavadoraTipoId = model.LavadoraTipoId,
                        CargaLavadoLavadoraId = model.LavadoraId,
                        CargaLavadoFechaEntrada = model.FechaEntrada,
                        CargaLavadoFechaSalida = model.FechaSalida,
                        CargaLavadoPeso = model.CargaPeso,
                        CargaLavadoCentroTrabajoId = model.CentroTrabajoId,
                        CargaLavadoCapacidadUtilizadaLavadora = model.CapacidadUtilizada,
                        CargaLavadoTiempoMinimoProceso = model.TiempoMinimoProceso,
                        CargaLavadoTiempoMaximoProceso = model.TiempoMaximoProceso,
                        CargaLavadoTiempoEstandarProceso = model.TiempoEstandarProceso,
                        CargaLavadoTela = model.Tela,
                        CargaLavadoNumeroArmado = model.ArmadoNumero,
                        CargaLavadoNumeroRequisicionQuimicos = model.RequisicionQuimicoId
                    };
                    _context.CargaLavadoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.CargaLavadoId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / Insert", exception);
            }
        }

        public static CargaLavadoBusiness Update(CargaLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CargaLavadoSet
                               where r.CargaLavadoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CargaLavadoCiaCod = model.CompaniaId;
                        reg.CargaLavadoNumeroOrden = model.OrdenNumero;
                        reg.CargaLavadoAno = model.OrdenAno;
                        reg.CargaLavadoNumero = model.CargaNumero;
                        reg.CargaLavadoUnidades = model.Cantidad;
                        reg.CargaLavadoEstado = model.Estado;
                        reg.CargaLavadoLavadoId = model.LavadorId;
                        reg.CargaLavadoOpcionLavadoId = model.OpcionLavadoId;
                        reg.CargaLavadoLavadoraTipoId = model.LavadoraTipoId;
                        reg.CargaLavadoLavadoraId = model.LavadoraId;
                        reg.CargaLavadoFechaEntrada = model.FechaEntrada;
                        reg.CargaLavadoFechaSalida = model.FechaSalida;
                        reg.CargaLavadoPeso = model.CargaPeso;
                        reg.CargaLavadoCentroTrabajoId = model.CentroTrabajoId;
                        reg.CargaLavadoCapacidadUtilizadaLavadora = model.CapacidadUtilizada;
                        reg.CargaLavadoTiempoMinimoProceso = model.TiempoMinimoProceso;
                        reg.CargaLavadoTiempoMaximoProceso = model.TiempoMaximoProceso;
                        reg.CargaLavadoTiempoEstandarProceso = model.TiempoEstandarProceso;
                        reg.CargaLavadoTela = model.Tela;
                        reg.CargaLavadoNumeroArmado = model.ArmadoNumero;
                        reg.CargaLavadoNumeroRequisicionQuimicos = model.RequisicionQuimicoId;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CargaLavado con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / Update", exception);
            }
        }

        public static void Delete(CargaLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CargaLavadoSet
                               where r.CargaLavadoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CargaLavadoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CargaLavado con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int cargaLavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CargaLavadoSet
                               where r.CargaLavadoId == cargaLavadoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CargaLavadoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CargaLavado con Id: {cargaLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / Delete (id)", exception);
            }
        }

        public static CargaLavadoBusiness Get(int cargaLavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CargaLavadoSet
                        where r.CargaLavadoId == cargaLavadoId
                        select new CargaLavadoBusiness
                        {
                            Id = r.CargaLavadoId,
                            CompaniaId = r.CargaLavadoCiaCod,
                            OrdenNumero = r.CargaLavadoNumeroOrden,
                            OrdenAno = r.CargaLavadoAno,
                            CargaNumero = r.CargaLavadoNumero,
                            Cantidad = r.CargaLavadoUnidades,
                            Estado = r.CargaLavadoEstado,
                            LavadorId = r.CargaLavadoLavadoId,
                            OpcionLavadoId = r.CargaLavadoOpcionLavadoId,
                            LavadoraTipoId = r.CargaLavadoLavadoraTipoId,
                            LavadoraId = r.CargaLavadoLavadoraId,
                            FechaEntrada = r.CargaLavadoFechaEntrada,
                            FechaSalida = r.CargaLavadoFechaSalida,
                            CargaPeso = r.CargaLavadoPeso,
                            CentroTrabajoId = r.CargaLavadoCentroTrabajoId,
                            CapacidadUtilizada = r.CargaLavadoCapacidadUtilizadaLavadora,
                            TiempoMinimoProceso = r.CargaLavadoTiempoMinimoProceso,
                            TiempoMaximoProceso = r.CargaLavadoTiempoMaximoProceso,
                            TiempoEstandarProceso = r.CargaLavadoTiempoEstandarProceso,
                            Tela = r.CargaLavadoTela,
                            ArmadoNumero = r.CargaLavadoNumeroArmado,
                            RequisicionQuimicoId = r.CargaLavadoNumeroRequisicionQuimicos
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CargaLavado con Id: {cargaLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / Get", exception);
            }
        }

        public static CargaLavadoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.CargaLavadoSet
                            select new CargaLavadoBusiness
                            {
                                Id = r.CargaLavadoId,
                                CompaniaId = r.CargaLavadoCiaCod,
                                OrdenNumero = r.CargaLavadoNumeroOrden,
                                OrdenAno = r.CargaLavadoAno,
                                CargaNumero = r.CargaLavadoNumero,
                                Cantidad = r.CargaLavadoUnidades,
                                Estado = r.CargaLavadoEstado,
                                LavadorId = r.CargaLavadoLavadoId,
                                OpcionLavadoId = r.CargaLavadoOpcionLavadoId,
                                LavadoraTipoId = r.CargaLavadoLavadoraTipoId,
                                LavadoraId = r.CargaLavadoLavadoraId,
                                FechaEntrada = r.CargaLavadoFechaEntrada,
                                FechaSalida = r.CargaLavadoFechaSalida,
                                CargaPeso = r.CargaLavadoPeso,
                                CentroTrabajoId = r.CargaLavadoCentroTrabajoId,
                                CapacidadUtilizada = r.CargaLavadoCapacidadUtilizadaLavadora,
                                TiempoMinimoProceso = r.CargaLavadoTiempoMinimoProceso,
                                TiempoMaximoProceso = r.CargaLavadoTiempoMaximoProceso,
                                TiempoEstandarProceso = r.CargaLavadoTiempoEstandarProceso,
                                Tela = r.CargaLavadoTela,
                                ArmadoNumero = r.CargaLavadoNumeroArmado,
                                RequisicionQuimicoId = r.CargaLavadoNumeroRequisicionQuimicos
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetAll", exception);
            }
        }

        public static bool ValidaOrdenTieneCargas(short companiaId, short ordenAno, short ordenNumero,
            short centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var query = (from r in _context.CargaLavadoSet
                        where r.CargaLavadoCiaCod == companiaId &&
                              r.CargaLavadoAno == ordenAno &&
                              r.CargaLavadoNumeroOrden == ordenNumero
                        select r).Count();
                    return query > 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / ValidaOrdenTieneCargas", exception);
            }
        }

        public static decimal GetTiempoMaximoProcesoLavado(int opcionLavadoId, short centroTrabajoId, bool tipoCalculo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (tipoCalculo)
                    {
                        return (from pc in _context.ProcesosCentroTrabajoSet
                            join ct in _context.CentrosTrabajoOpcionSet on
                                pc.CentroTrabajoOpcionId equals ct.CentroTrabajoOpcionId
                            join ol in _context.OpcionesLavadosSet on
                                ct.OpcionId equals ol.OpcionLavadoId
                            join op in _context.OperacionesProcesoSet on
                                pc.ProcesoCentroTrabajoId equals op.ProcesoCentroTrabajoId
                            where ol.OpcionLavadoId == opcionLavadoId
                            select op.OperacionProcesoTiempoMaximo).Sum();
                    }
                    return (from pc in _context.ProcesosCentroTrabajoSet
                        join ct in _context.CentrosTrabajoOpcionSet on
                            pc.CentroTrabajoOpcionId equals ct.CentroTrabajoOpcionId
                        join ol in _context.OpcionesLavadosSet on
                            ct.OpcionId equals ol.OpcionLavadoId
                        join op in _context.OperacionesProcesoSet on
                            pc.ProcesoCentroTrabajoId equals op.ProcesoCentroTrabajoId
                        where ol.OpcionLavadoId == opcionLavadoId &&
                              ct.CentroTrabajoId == centroTrabajoId
                        select op.OperacionProcesoTiempoMaximo).Sum();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetTiempoMaximoProcesoLavado", exception);
            }
        }

        public static decimal GetTiempoMinimoProcesoLavado(int opcionLavadoId, short centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from pc in _context.ProcesosCentroTrabajoSet
                        join ct in _context.CentrosTrabajoOpcionSet on
                            pc.CentroTrabajoOpcionId equals ct.CentroTrabajoOpcionId
                        join ol in _context.OpcionesLavadosSet on
                            ct.OpcionId equals ol.OpcionLavadoId
                        join op in _context.OperacionesProcesoSet on
                            pc.ProcesoCentroTrabajoId equals op.ProcesoCentroTrabajoId
                        where ol.OpcionLavadoId == opcionLavadoId &&
                              ct.CentroTrabajoId == centroTrabajoId
                        select op.OperacionProcesoTiempoMinimo).Sum();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetTiempoMinimoProcesoLavado", exception);
            }
        }

        public static decimal GetTiempoEstandarProcesoLavado(int opcionLavadoId, short centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from pc in _context.ProcesosCentroTrabajoSet
                        join ct in _context.CentrosTrabajoOpcionSet on
                            pc.CentroTrabajoOpcionId equals ct.CentroTrabajoOpcionId
                        join ol in _context.OpcionesLavadosSet on
                            ct.OpcionId equals ol.OpcionLavadoId
                        join op in _context.OperacionesProcesoSet on
                            pc.ProcesoCentroTrabajoId equals op.ProcesoCentroTrabajoId
                        where ol.OpcionLavadoId == opcionLavadoId &&
                              ct.CentroTrabajoId == centroTrabajoId
                        select op.OperacionProcesoTiempoEstandar).Sum() ?? 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetTiempoEstandarProcesoLavado", exception);
            }
        }

        public static decimal GetTiempoMaximoProcesoLavadoReArmandoCarga(int opcionLavadoId, short centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from op in _context.OperacionesProcesoOrdenSet
                        where op.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden
                            .CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId == centroTrabajoId &&
                              op.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden.OpcionLavadoOrden
                                  .OpcionLavadoOrdenId == opcionLavadoId
                        select op.OperacionesProcesoOrdenTiempoMaximo).Sum();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetTiempoMaximoProcesoLavadoReArmandoCarga", exception);
            }
        }

        public static decimal GetTiempoMinimoProcesoLavadoReArmandoCarga(int opcionLavadoId, short centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from op in _context.OperacionesProcesoOrdenSet
                            where op.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden
                                .CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId == centroTrabajoId &&
                                  op.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden.OpcionLavadoOrden
                                      .OpcionLavadoOrdenId == opcionLavadoId
                            select op.OperacionesProcesoOrdenTiempoMinimo).Sum();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetTiempoMinimoProcesoLavadoReArmandoCarga", exception);
            }
        }

        public static decimal GetCapacidadCanastaLavadora(decimal capacidadLavadora)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from lc in _context.LavadorasCapacidadSet
                        where lc.LavadoraCapacidadKgMax == capacidadLavadora
                        select lc.LavadoraCapacidadLitroCanasta).FirstOrDefault() ?? 0;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetCapacidadCanastaLavadora", exception);
            }
        }

        public static int GetRelacionBanoMinima(int opcionLavadoId, short centroTrabajoId, bool tipoCalculo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (tipoCalculo)
                    {
                        return (from cto in _context.CentrosTrabajoOpcionSet
                            join pct in _context.ProcesosCentroTrabajoSet on
                                cto.CentroTrabajoOpcionId equals pct.CentroTrabajoOpcionId
                            join op in _context.OperacionesProcesoSet on
                                pct.ProcesoCentroTrabajoId equals op.ProcesoCentroTrabajoId
                            where cto.OpcionId == opcionLavadoId
                            select op.OperacionProcesoRelacion).Min();
                    }
                    return (from cto in _context.CentrosTrabajoOpcionSet
                        join pct in _context.ProcesosCentroTrabajoSet on
                            cto.CentroTrabajoOpcionId equals pct.CentroTrabajoOpcionId
                        join op in _context.OperacionesProcesoSet on
                            pct.ProcesoCentroTrabajoId equals op.ProcesoCentroTrabajoId
                        where cto.OpcionId == opcionLavadoId &&
                              cto.CentroTrabajoId == centroTrabajoId
                        select op.OperacionProcesoRelacion).Min();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetRelacionBanoMinima", exception);
            }
        }

        public static int GetRelacionBanoMinimaOrden(int opcionLavadoId, int centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.OperacionesProcesoOrdenSet
                        where r.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden.OpcionLavadoOrden
                            .OpcionLavadoOrdenId == opcionLavadoId &&
                              r.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden
                                  .CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId == centroTrabajoId
                        select r.OperacionesProcesoOrdenRelacion).Min();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / GetRelacionBanoMinimaOrden", exception);
            }
        }

        public static void ActualizarLavadoEnOrden(short companiaId, short ordenAno, short ordenNumero, int lavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CUTARC3Set
                        where r.CIACOD == companiaId &&
                              r.PrdAnoCor == ordenAno &&
                              r.PrdNumCor == ordenNumero
                        select r).FirstOrDefault();

                    if (reg == null) throw new Exception("Registro no encontrado");

                    reg.OrdLavadoI = lavadoId;
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / ActualizarLavado", exception);
            }
        }

        public static void ActualizarPesoEnOrden(short companiaId, short ordenAno, short ordenNumero, decimal pesoUnidad)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CUTARC3Set
                               where r.CIACOD == companiaId &&
                                     r.PrdAnoCor == ordenAno &&
                                     r.PrdNumCor == ordenNumero
                               select r).FirstOrDefault();

                    if (reg == null) throw new Exception("Registro no encontrado");

                    reg.OrdPrePes = pesoUnidad;
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / ActualizarPesroEnOrden", exception);
            }
        }

        public static void EliminarCargasLavadoOrdenProduccion(short companiaId, short ordenAno, short ordenNumero,
            short centroTrabajoId, bool tipoCalculo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (tipoCalculo)
                    {
                        var cargas = from cl in _context.CargaLavadoSet
                            where cl.CargaLavadoCiaCod == companiaId &&
                                  cl.CargaLavadoNumeroOrden == ordenNumero &&
                                  cl.CargaLavadoAno == ordenAno
                            select cl;

                        if (cargas.Any(c => c.CargaLavadoFechaEntrada != null))
                        {
                            throw new Exception("Hay cargas ya programadas. No se pueden eliminar");
                        }

                        var litrosAgua = from r in _context.LitrosAguaOperacionSet
                            where r.LitrosAguaCiaCod == companiaId &&
                                  r.LitrosAguaAnio == ordenAno &&
                                  r.LitrosAguaNumeroOrden == ordenNumero
                            select r;

                        _context.LitrosAguaOperacionSet.RemoveRange(litrosAgua);

                        var quimicos = from r in _context.CantidadIngredientesInstruccionSet
                            where r.CantidadIngredienteInstruccionCiaCod == companiaId &&
                                  r.CantidadIngredienteInstruccionAnio == ordenAno &&
                                  r.CantidadIngredienteInstruccionNumeroOrden == ordenNumero
                            select r;

                        _context.CantidadIngredientesInstruccionSet.RemoveRange(quimicos);

                        _context.CargaLavadoSet.RemoveRange(cargas);

                        var opcion = from r in _context.OpcionLavadoOrdenSet
                            where r.OpcionLavadoOrdenCompaniaId == companiaId &&
                                  r.OpcionLavadoOrdenPlantaId == 1 &&
                                  r.OpcionLavadoOrdenAnio == ordenAno &&
                                  r.OpcionLavadoOrdenNumeroOrden == ordenNumero
                            select r;

                        _context.OpcionLavadoOrdenSet.RemoveRange(opcion);

                        _context.SaveChanges();
                        return;
                    }

                    var cargas1 = from r in _context.CargaLavadoSet
                        where r.CargaLavadoCiaCod == companiaId &&
                              r.CargaLavadoNumeroOrden == ordenNumero &&
                              r.CargaLavadoAno == ordenAno &&
                              r.CargaLavadoCentroTrabajoId == centroTrabajoId
                        select r;

                    if (cargas1.Any(r => r.CargaLavadoFechaEntrada != null))
                    {
                        throw new Exception("Hay cargas ya programadas. No se pueden eliminar");
                    }

                    var operaciones = from r in _context.OperacionesProcesoOrdenSet
                        where r.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden.OpcionLavadoOrden
                            .OpcionLavadoOrdenCompaniaId == companiaId &&
                              r.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden.OpcionLavadoOrden
                                  .OpcionLavadoOrdenNumeroOrden == ordenNumero &&
                              r.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden.OpcionLavadoOrden
                                  .OpcionLavadoOrdenAnio == ordenAno &&
                              r.ProcesosCentroTrabajoOrden.CentrosTrabajoOpcionLavadoOrden
                                  .CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId == centroTrabajoId
                        select r.OperacionesProcesoOrdenId;
                    foreach (var operacion in operaciones)
                    {
                        var ingredientesOperacion = from r in _context.CantidadIngredientesOperacionSet
                            where r.CantidadIngredienteOperacionId == operacion
                            select r;
                        if (ingredientesOperacion.Any())
                        {
                            _context.CantidadIngredientesOperacionSet.RemoveRange(ingredientesOperacion);
                        }
                        else
                        {
                            var ingredientesInstruccion = from r in _context.CantidadIngredientesInstruccionSet
                                where r.CantidadIngredienteInstruccionOperacionId == operacion
                                select r;

                            _context.CantidadIngredientesInstruccionSet.RemoveRange(ingredientesInstruccion);
                        }

                        var litrosAgua = from r in _context.LitrosAguaOperacionSet
                            where r.LitrosAguaOperacionProcesoId == operacion
                            select r;

                        _context.LitrosAguaOperacionSet.RemoveRange(litrosAgua);
                    }

                    _context.CargaLavadoSet.RemoveRange(cargas1);
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CargaLavadoBusiness / EliminarCargasLavadoOrdenProduccion", exception);
            }
        }

        #endregion
    }
}