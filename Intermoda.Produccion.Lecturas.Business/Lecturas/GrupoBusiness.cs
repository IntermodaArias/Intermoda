using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Produccion.Lecturas.Business.Lecturas
{
    [DataContract]
    public class GrupoBusiness
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
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Secuencia { get; set; }
        [DataMember]
        public bool Estado { get; set; }

        #endregion

        #region Methods

        public static GrupoBusiness Insert(GrupoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new Grupo()
                    {
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                    _context.GrupoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / Insert", exception);
            }
        }

        public static GrupoBusiness Update(GrupoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.GrupoSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.FechaInicio = model.FechaInicio;
                        reg.FechaFinal = model.FechaFinal;
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Secuencia = model.Secuencia;
                        reg.Estado = model.Estado;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Grupo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / Update", exception);
            }
        }

        public static void Delete(GrupoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.GrupoSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.GrupoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Grupo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int grupoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.GrupoSet
                               where r.Id == grupoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.GrupoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Grupo con Id: {grupoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / Delete (id)", exception);
            }
        }

        public static GrupoBusiness Get(int grupoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.GrupoSet
                                 where r.Id == grupoId
                                 select new GrupoBusiness
                                 {
                                     Id = r.Id,
                                     FechaInicio = r.FechaInicio,
                                     FechaFinal = r.FechaFinal,
                                     Codigo = r.Codigo,
                                     Nombre = r.Nombre,
                                     Secuencia = r.Secuencia,
                                     Estado = r.Estado
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Grupo con Id: {grupoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / Get", exception);
            }
        }

        public static GrupoBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.GrupoSet
                            orderby r.Secuencia, r.Nombre
                            select new GrupoBusiness
                            {
                                Id = r.Id,
                                FechaInicio = r.FechaInicio,
                                FechaFinal = r.FechaFinal,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / GetAll", exception);
            }
        }

        public static GrupoBusiness[] GetAllActivos()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.GrupoSet
                            where r.Estado
                            orderby r.Estado, r.Secuencia, r.Nombre
                            select new GrupoBusiness
                            {
                                Id = r.Id,
                                FechaInicio = r.FechaInicio,
                                FechaFinal = r.FechaFinal,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / GetAllActivos", exception);
            }
        }

        public static GrupoBusiness GetByLinea(int lineaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.LineaSet
                        where r.Id == lineaId
                        select new GrupoBusiness
                        {
                            Id = r.Grupo.Id,
                            FechaInicio = r.Grupo.FechaInicio,
                            FechaFinal = r.Grupo.FechaFinal,
                            Codigo = r.Grupo.Codigo,
                            Nombre = r.Grupo.Nombre,
                            Secuencia = r.Grupo.Secuencia,
                            Estado = r.Grupo.Estado
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Linea con Id: {lineaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / GetByLinea", exception);
            }
        }

        public static void CopiarSemana(DateTime desde, DateTime hasta)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    if (hasta.DayOfWeek != DayOfWeek.Monday || desde.DayOfWeek != DayOfWeek.Monday)
                    {
                        throw new Exception("Las dos fechas deben ser lunes");
                    }

                    var borrarRegs = (from r in _context.GrupoSet
                        where r.FechaInicio == hasta
                        select r).ToList();
                    _context.GrupoSet.RemoveRange(borrarRegs);

                    var grupos = (from r in _context.GrupoSet
                        where r.FechaInicio == desde && r.Estado
                        select r).ToList();
                    foreach (var grupo in grupos)
                    {
                        var newGrupo = new Grupo
                        {
                            FechaInicio = hasta,
                            FechaFinal = hasta.AddDays(7),
                            Codigo = grupo.Codigo,
                            Nombre = grupo.Nombre,
                            Estado = grupo.Estado,
                            Secuencia = grupo.Secuencia
                        };
                        _context.GrupoSet.Add(newGrupo);
                        
                        var lineas = (from r in _context.LineaSet
                            where r.GrupoId == grupo.Id && r.Estado
                            select r).ToList();
                        foreach (var linea in lineas)
                        {
                            var newLinea = new Linea
                            {
                                GrupoId = newGrupo.Id,
                                Codigo = linea.Codigo,
                                Estado = linea.Estado,
                                Nombre = linea.Nombre,
                                Secuencia = linea.Secuencia,
                                Tipo = linea.Tipo
                            };
                            _context.LineaSet.Add(newLinea);

                            var detalles = (from r in _context.LineaDetalleSet
                                where r.LineaId == newLinea.Id
                                select r).ToList();
                            foreach (var detalle in detalles)
                            {
                                var newDetalle = new LineaDetalle
                                {
                                    LineaId = newLinea.Id,
                                    CentroTrabajoId = detalle.CentroTrabajoId,
                                    ModuloId = detalle.ModuloId,
                                    EsSalidaUnica = detalle.EsSalidaUnica,
                                    Secuencia = detalle.Secuencia
                                };
                                _context.LineaDetalleSet.Add(newDetalle);
                            }
                        }
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / CopiarSemana", exception);
            }
        }

        public static bool HayDataSemana(DateTime fecha)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var existe = (from r in _context.GrupoSet
                        where r.FechaInicio == fecha
                        select r).Any();

                    return !existe;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoBusiness / HayDataSemana", exception);
            }
        }

        #endregion
    }
}