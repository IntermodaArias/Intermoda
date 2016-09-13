using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Business.LbDatPro;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Business.Lecturas
{
    [DataContract]
    public class ModuloSemanaOperarioBusiness
    {
        private static ProduccionLecturasEntities _context;
        private const short PrmCompaniaCodigo = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ModuloSemanaId { get; set; }
        [DataMember]
        public short CompaniaCodigo { get; set; }
        [DataMember]
        public int OperarioCodigo { get; set; }
        [DataMember]
        public int ClasificacionId { get; set; }
        [DataMember]
        public decimal CurvaEntrenamiento { get; set; }
        [DataMember]
        public int SemanaEntrenamiento { get; set; }

        [DataMember]
        public EmpleadoBusiness Operario { get; set; }
        [DataMember]
        public CentroTrabajoClasificacionBusiness Clasificacion { get; private set; }
        [DataMember]
        public InasistenciaBusiness[] Inasistencias { get; set; }


        #endregion

        #region Methods

        public static ModuloSemanaOperarioBusiness Insert(ModuloSemanaOperarioBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new ModuloSemanaOperario()
                    {
                        ModuloSemanaId = model.ModuloSemanaId,
                        CompaniaCodigo = model.CompaniaCodigo,
                        OperarioCodigo = model.OperarioCodigo,
                        ClasificacionId = model.ClasificacionId,
                        CurvaEntrenamiento = model.CurvaEntrenamiento,
                        SemanaEntrenamiento = model.SemanaEntrenamiento
                    };
                    _context.ModuloSemanaOperarioSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / Insert", exception);
            }
        }

        public static ModuloSemanaOperarioBusiness Update(ModuloSemanaOperarioBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSemanaOperarioSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ModuloSemanaId = model.ModuloSemanaId;
                        reg.CompaniaCodigo = model.CompaniaCodigo;
                        reg.OperarioCodigo = model.OperarioCodigo;
                        reg.ClasificacionId = model.ClasificacionId;
                        reg.CurvaEntrenamiento = model.CurvaEntrenamiento;
                        reg.SemanaEntrenamiento = model.SemanaEntrenamiento;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemanaOperario con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / Update", exception);
            }
        }

        public static void Delete(ModuloSemanaOperarioBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSemanaOperarioSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ModuloSemanaOperarioSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemanaOperario con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int moduloSemanaOperarioId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSemanaOperarioSet
                               where r.Id == moduloSemanaOperarioId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ModuloSemanaOperarioSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemanaOperario con Id: {moduloSemanaOperarioId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / Delete (id)", exception);
            }
        }

        public static ModuloSemanaOperarioBusiness Get(int moduloSemanaOperarioId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.ModuloSemanaOperarioSet
                                 where r.Id == moduloSemanaOperarioId
                                 select new ModuloSemanaOperarioBusiness
                                 {
                                     Id = r.Id,
                                     ModuloSemanaId = r.ModuloSemanaId,
                                     CompaniaCodigo = r.CompaniaCodigo,
                                     OperarioCodigo = r.OperarioCodigo,
                                     ClasificacionId = r.ClasificacionId,
                                     CurvaEntrenamiento = r.CurvaEntrenamiento,
                                     SemanaEntrenamiento = r.SemanaEntrenamiento
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        var moduloSemana = (from r in _context.ModuloSemanaSet
                            where r.Id == model.ModuloSemanaId
                            select r).FirstOrDefault();

                        if (moduloSemana == null)
                            throw new Exception("No se ha encontrada definición de la semana para el módulo ${model.I}");

                        model.Operario = EmpleadoBusiness.Get(model.CompaniaCodigo, model.OperarioCodigo);
                        model.Clasificacion = CentroTrabajoClasificacionBusiness.Get(model.ClasificacionId);
                        model.Inasistencias = InasistenciaBusiness.GetByEmpleadoFecha(PrmCompaniaCodigo,
                            model.OperarioCodigo, moduloSemana.FechaInicio, moduloSemana.FechaFinal);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ModuloSemanaOperario con Id: {moduloSemanaOperarioId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / Get", exception);
            }
        }

        public static ModuloSemanaOperarioBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.ModuloSemanaOperarioSet
                            select new ModuloSemanaOperarioBusiness
                            {
                                Id = r.Id,
                                ModuloSemanaId = r.ModuloSemanaId,
                                CompaniaCodigo = r.CompaniaCodigo,
                                OperarioCodigo = r.OperarioCodigo,
                                ClasificacionId = r.ClasificacionId,
                                CurvaEntrenamiento = r.CurvaEntrenamiento,
                                SemanaEntrenamiento = r.SemanaEntrenamiento
                            }).ToList();

                    foreach (var model in lista)
                    {
                        var moduloSemana = (from r in _context.ModuloSemanaSet
                            where r.Id == model.ModuloSemanaId
                            select r).FirstOrDefault();

                        if (moduloSemana == null)
                            throw new Exception("No se ha encontrada definición de la semana para el módulo ${model.I}");

                        model.Operario = EmpleadoBusiness.Get(model.CompaniaCodigo, model.OperarioCodigo);
                        model.Clasificacion = CentroTrabajoClasificacionBusiness.Get(model.ClasificacionId);
                        model.Inasistencias = InasistenciaBusiness.GetByEmpleadoFecha(PrmCompaniaCodigo,
                            model.OperarioCodigo, moduloSemana.FechaInicio, moduloSemana.FechaFinal);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / GetAll", exception);
            }
        }

        public static ModuloSemanaOperarioBusiness[] GetByModuloSemana(int moduloSemanaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.ModuloSemanaOperarioSet
                        where r.ModuloSemanaId == moduloSemanaId
                        orderby r.ModuloSemanaId, r.CompaniaCodigo, r.OperarioCodigo
                        select new ModuloSemanaOperarioBusiness
                        {
                            Id = r.Id,
                            ModuloSemanaId = r.ModuloSemanaId,
                            CompaniaCodigo = r.CompaniaCodigo,
                            OperarioCodigo = r.OperarioCodigo,
                            ClasificacionId = r.ClasificacionId,
                            CurvaEntrenamiento = r.CurvaEntrenamiento,
                            SemanaEntrenamiento = r.SemanaEntrenamiento
                        }).ToList();

                    foreach (var model in lista)
                    {
                        var moduloSemana = (from r in _context.ModuloSemanaSet
                                            where r.Id == model.ModuloSemanaId
                                            select r).FirstOrDefault();

                        if (moduloSemana == null)
                            throw new Exception("No se ha encontrada definición de la semana para el módulo ${model.I}");

                        model.Operario = EmpleadoBusiness.Get(model.CompaniaCodigo, model.OperarioCodigo);
                        model.Clasificacion = CentroTrabajoClasificacionBusiness.Get(model.ClasificacionId);
                        model.Inasistencias = InasistenciaBusiness.GetByEmpleadoFecha(PrmCompaniaCodigo,
                            model.OperarioCodigo, moduloSemana.FechaInicio, moduloSemana.FechaFinal);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperarioBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}