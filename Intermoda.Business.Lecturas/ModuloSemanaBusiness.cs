using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Business.Lecturas
{
    [DataContract]
    public class ModuloSemanaBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime FechaInicio { get; set; }
        [DataMember]
        public DateTime FechaFinal { get; set; }
        [DataMember]
        public int CentroTrabajoId { get; set; }
        [DataMember]
        public int ModuloId { get; set; }
        [DataMember]
        public int TransferenciaMinutos { get; set; }
        [DataMember]
        public int MetaPiezasPorHora { get; set; }
        [DataMember]
        public decimal MetaProduccion { get; set; }
        [DataMember]
        public decimal Curva { get; set; }
        [DataMember]
        public int MinutosEntrenamiento { get; set; }
        [DataMember]
        public int MinutosTitular { get; set; }
        [DataMember]
        public int MinutoUtilitario { get; set; }
        [DataMember]
        public int MinutosBase { get; set; }
        [DataMember]
        public int TurnoId { get; set; }

        [DataMember]
        public CentroTrabajoBusiness CentroTrabajo { get; private set; }
        [DataMember]
        public ModuloBusiness Modulo { get; private set; }
        [DataMember]
        public TurnoBusiness Turno { get; private set; }

        #endregion

        #region Methods

        public static ModuloSemanaBusiness Insert(ModuloSemanaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new ModuloSemana()
                    {
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        CentroTrabajoId = model.CentroTrabajoId,
                        ModuloId = model.ModuloId,
                        TransferenciaMinutos = model.TransferenciaMinutos,
                        MetaPiezasPorHora = model.MetaPiezasPorHora,
                        MetaProduccion = model.MetaProduccion,
                        Curva = model.Curva,
                        MinutosEntrenamiento = model.MinutosEntrenamiento,
                        MinutosTitular = model.MinutosTitular,
                        MinutosUtilitario = model.MinutoUtilitario,
                        MinutosBase = model.MinutosBase,
                        TurnoId = model.TurnoId
                    };
                    _context.ModuloSemanaSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                    model.Modulo = ModuloBusiness.Get(model.ModuloId);
                    model.Turno = TurnoBusiness.Get(model.TurnoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / Insert", exception);
            }
        }

        public static ModuloSemanaBusiness Update(ModuloSemanaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSemanaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.FechaInicio = model.FechaInicio;
                        reg.FechaFinal = model.FechaFinal;
                        reg.CentroTrabajoId = model.CentroTrabajoId;
                        reg.ModuloId = model.ModuloId;
                        reg.TransferenciaMinutos = model.TransferenciaMinutos;
                        reg.MetaPiezasPorHora = model.MetaPiezasPorHora;
                        reg.MetaProduccion = model.MetaProduccion;
                        reg.Curva = model.Curva;
                        reg.MinutosEntrenamiento = model.MinutosEntrenamiento;
                        reg.MinutosTitular = model.MinutosTitular;
                        reg.MinutosUtilitario = model.MinutoUtilitario;
                        reg.MinutosBase = model.MinutosBase;
                        reg.TurnoId = model.TurnoId;

                        _context.SaveChanges();

                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.Modulo = ModuloBusiness.Get(model.ModuloId);
                        model.Turno = TurnoBusiness.Get(model.TurnoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemana con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / Update", exception);
            }
        }

        public static void Delete(ModuloSemanaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSemanaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ModuloSemanaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemana con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int moduloSemanaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSemanaSet
                               where r.Id == moduloSemanaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ModuloSemanaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemana con Id: {moduloSemanaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / Delete (id)", exception);
            }
        }

        public static ModuloSemanaBusiness Get(int moduloSemanaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.ModuloSemanaSet
                        where r.Id == moduloSemanaId
                        select new ModuloSemanaBusiness
                        {
                            Id = r.Id,
                            FechaInicio = r.FechaInicio,
                            FechaFinal = r.FechaFinal,
                            CentroTrabajoId = r.CentroTrabajoId,
                            ModuloId = r.ModuloId,
                            TransferenciaMinutos = r.TransferenciaMinutos,
                            MetaPiezasPorHora = r.MetaPiezasPorHora,
                            MetaProduccion = r.MetaProduccion,
                            Curva = r.Curva,
                            MinutosEntrenamiento = r.MinutosEntrenamiento,
                            MinutosTitular = r.MinutosTitular,
                            MinutoUtilitario = r.MinutosUtilitario,
                            MinutosBase = r.MinutosBase,
                            TurnoId = r.TurnoId
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Turno = TurnoBusiness.Get(model.TurnoId);
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.Modulo = ModuloBusiness.Get(model.ModuloId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemana con Id: {moduloSemanaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / Get", exception);
            }
        }

        public static ModuloSemanaBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.ModuloSemanaSet
                        select new ModuloSemanaBusiness
                        {
                            Id = r.Id,
                            FechaInicio = r.FechaInicio,
                            FechaFinal = r.FechaFinal,
                            CentroTrabajoId = r.CentroTrabajoId,
                            ModuloId = r.ModuloId,
                            TransferenciaMinutos = r.TransferenciaMinutos,
                            MetaPiezasPorHora = r.MetaPiezasPorHora,
                            MetaProduccion = r.MetaProduccion,
                            Curva = r.Curva,
                            MinutosEntrenamiento = r.MinutosEntrenamiento,
                            MinutosTitular = r.MinutosTitular,
                            MinutoUtilitario = r.MinutosUtilitario,
                            MinutosBase = r.MinutosBase,
                            TurnoId = r.TurnoId
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Turno = TurnoBusiness.Get(model.TurnoId);
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.Modulo = ModuloBusiness.Get(model.ModuloId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / GetAll", exception);
            }
        }

        public static ModuloSemanaBusiness[] GetByFecha(DateTime fechaInicio)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.ModuloSemanaSet
                        where r.FechaInicio == fechaInicio
                        orderby r.FechaInicio
                        select new ModuloSemanaBusiness
                        {
                            Id = r.Id,
                            FechaInicio = r.FechaInicio,
                            FechaFinal = r.FechaFinal,
                            CentroTrabajoId = r.CentroTrabajoId,
                            ModuloId = r.ModuloId,
                            TransferenciaMinutos = r.TransferenciaMinutos,
                            MetaPiezasPorHora = r.MetaPiezasPorHora,
                            MetaProduccion = r.MetaProduccion,
                            Curva = r.Curva,
                            MinutosEntrenamiento = r.MinutosEntrenamiento,
                            MinutosTitular = r.MinutosTitular,
                            MinutoUtilitario = r.MinutosUtilitario,
                            MinutosBase = r.MinutosBase,
                            TurnoId = r.TurnoId
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Turno = TurnoBusiness.Get(model.TurnoId);
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.Modulo = ModuloBusiness.Get(model.ModuloId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / GetbyFecha", exception);
            }
        }

        public static ModuloSemanaBusiness[] GetbyFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.ModuloSemanaSet
                        where r.FechaInicio == fechaInicio &&
                              r.CentroTrabajoId == centroTrabajoId
                        orderby r.FechaInicio, r.CentroTrabajoId, r.ModuloId
                        select new ModuloSemanaBusiness
                        {
                            Id = r.Id,
                            FechaInicio = r.FechaInicio,
                            FechaFinal = r.FechaFinal,
                            CentroTrabajoId = r.CentroTrabajoId,
                            ModuloId = r.ModuloId,
                            TransferenciaMinutos = r.TransferenciaMinutos,
                            MetaPiezasPorHora = r.MetaPiezasPorHora,
                            MetaProduccion = r.MetaProduccion,
                            Curva = r.Curva,
                            MinutosEntrenamiento = r.MinutosEntrenamiento,
                            MinutosTitular = r.MinutosTitular,
                            MinutoUtilitario = r.MinutosUtilitario,
                            MinutosBase = r.MinutosBase,
                            TurnoId = r.TurnoId
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Turno = TurnoBusiness.Get(model.TurnoId);
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.Modulo = ModuloBusiness.Get(model.ModuloId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / GetbyFechaCentroTrabajo", exception);
            }
        }

        public static ModuloSemanaBusiness[] GetbyFechaModulo(DateTime fechaInicio, int moduloId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.ModuloSemanaSet
                        where r.FechaInicio == fechaInicio &&
                              r.ModuloId == moduloId
                        orderby r.FechaInicio, r.ModuloId
                        select new ModuloSemanaBusiness
                        {
                            Id = r.Id,
                            FechaInicio = r.FechaInicio,
                            FechaFinal = r.FechaFinal,
                            CentroTrabajoId = r.CentroTrabajoId,
                            ModuloId = r.ModuloId,
                            TransferenciaMinutos = r.TransferenciaMinutos,
                            MetaPiezasPorHora = r.MetaPiezasPorHora,
                            MetaProduccion = r.MetaProduccion,
                            Curva = r.Curva,
                            MinutosEntrenamiento = r.MinutosEntrenamiento,
                            MinutosTitular = r.MinutosTitular,
                            MinutoUtilitario = r.MinutosUtilitario,
                            MinutosBase = r.MinutosBase,
                            TurnoId = r.TurnoId
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Turno = TurnoBusiness.Get(model.TurnoId);
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.Modulo = ModuloBusiness.Get(model.ModuloId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaBusiness / GetFechaModulo", exception);
            }
        }

        #endregion
    }
}