using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Produccion.Lecturas.Business.Lecturas
{
    [DataContract]
    public class LineaDetalleBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int LineaId { get; set; }
        [DataMember]
        public int CentroTrabajoId { get; set; }
        [DataMember]
        public int ModuloId { get; set; }
        [DataMember]
        public bool EsSalidaUnica { get; set; }
        [DataMember]
        public int Secuencia { get; set; }

        [DataMember]
        public CentroTrabajo CentroTrabajo { get; private set; }

        [DataMember]
        public Modulo Modulo { get; private set; }

        #endregion

        #region Methods

        public static LineaDetalleBusiness Insert(LineaDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new LineaDetalle()
                    {
                        LineaId = model.LineaId,
                        CentroTrabajoId = model.CentroTrabajoId,
                        ModuloId = model.ModuloId,
                        EsSalidaUnica = model.EsSalidaUnica,
                        Secuencia = model.Secuencia
                    };
                    _context.LineaDetalleSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / Insert", exception);
            }
        }

        public static LineaDetalleBusiness Update(LineaDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.LineaDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.LineaId = model.LineaId;
                        reg.CentroTrabajoId = model.CentroTrabajoId;
                        reg.ModuloId = model.ModuloId;
                        reg.EsSalidaUnica = model.EsSalidaUnica;
                        reg.Secuencia = model.Secuencia;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LineaDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / Update", exception);
            }
        }

        public static void Delete(LineaDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.LineaDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LineaDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LineaDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int lineaDetalleId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.LineaDetalleSet
                               where r.Id == lineaDetalleId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LineaDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LineaDetalle con Id: {lineaDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / Delete (id)", exception);
            }
        }

        public static LineaDetalleBusiness Get(int lineaDetalleId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.LineaDetalleSet
                                 where r.Id == lineaDetalleId
                                 select new LineaDetalleBusiness
                                 {
                                     Id = r.Id,
                                     LineaId = r.LineaId,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     ModuloId = r.ModuloId,
                                     EsSalidaUnica = r.EsSalidaUnica,
                                     Secuencia = r.Secuencia,
                                     CentroTrabajo = new CentroTrabajo
                                     {
                                         Id = r.CentroTrabajo.Id,
                                         Codigo = r.CentroTrabajo.Codigo,
                                         Nombre = r.CentroTrabajo.Nombre,
                                         Secuencia = r.CentroTrabajo.Secuencia,
                                         Estado = r.CentroTrabajo.Estado
                                     },
                                     Modulo = new Modulo
                                     {
                                         Id = r.Modulo.Id,
                                         CentroTrabajoId = r.Modulo.CentroTrabajoId,
                                         Nombre = r.Modulo.Nombre,
                                         Secuencia = r.Modulo.Secuencia,
                                         Estado = r.Modulo.Estado
                                     }
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LineaDetalle con Id: {lineaDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / Get", exception);
            }
        }

        public static LineaDetalleBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.LineaDetalleSet
                            select new LineaDetalleBusiness
                            {
                                Id = r.Id,
                                LineaId = r.LineaId,
                                CentroTrabajoId = r.CentroTrabajoId,
                                ModuloId = r.ModuloId,
                                EsSalidaUnica = r.EsSalidaUnica,
                                Secuencia = r.Secuencia,
                                CentroTrabajo = new CentroTrabajo
                                {
                                    Id = r.CentroTrabajo.Id,
                                    Codigo = r.CentroTrabajo.Codigo,
                                    Nombre = r.CentroTrabajo.Nombre,
                                    Secuencia = r.CentroTrabajo.Secuencia,
                                    Estado = r.CentroTrabajo.Estado
                                },
                                Modulo = new Modulo
                                {
                                    Id = r.Modulo.Id,
                                    CentroTrabajoId = r.Modulo.CentroTrabajoId,
                                    Nombre = r.Modulo.Nombre,
                                    Secuencia = r.Modulo.Secuencia,
                                    Estado = r.Modulo.Estado
                                }
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / GetAll", exception);
            }
        }

        public static LineaDetalleBusiness[] GetByLinea(int lineaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var models = (from r in _context.LineaDetalleSet
                        join c in _context.CentroTrabajoSet on
                            r.CentroTrabajoId equals c.Id
                        join m in _context.ModuloSet on
                            r.ModuloId equals m.Id
                        where r.LineaId == lineaId
                        orderby r.LineaId, r.CentroTrabajoId, r.ModuloId
                        select new {r, c, m}).ToList();

                    var lista = new List<LineaDetalleBusiness>();

                    foreach (var model in models)
                    {
                        lista.Add(new LineaDetalleBusiness
                        {
                            Id = model.r.Id,
                            LineaId = model.r.LineaId,
                            CentroTrabajoId = model.r.CentroTrabajoId,
                            ModuloId = model.r.ModuloId,
                            EsSalidaUnica = model.r.EsSalidaUnica,
                            Secuencia = model.r.Secuencia,
                            CentroTrabajo = new CentroTrabajo
                            {
                                Id = model.c.Id,
                                Codigo = model.c.Codigo,
                                Nombre = model.c.Nombre,
                                Secuencia = model.c.Secuencia,
                                Estado = model.c.Estado
                            },
                            Modulo = new Modulo
                            {
                                Id = model.m.Id,
                                CentroTrabajoId = model.m.CentroTrabajoId,
                                Nombre = model.m.Nombre,
                                Secuencia = model.m.Secuencia,
                                Estado = model.m.Estado
                            }
                        });
                    }
                   
                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / GetByLinea", exception);
            }
        }

        public static LineaDetalleBusiness[] GetByLineaModulo(int lineaId, int moduloId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.LineaDetalleSet
                        where r.LineaId == lineaId &&
                              r.ModuloId == moduloId
                        orderby r.LineaId, r.ModuloId
                        select new LineaDetalleBusiness
                        {
                            Id = r.Id,
                            LineaId = r.LineaId,
                            CentroTrabajoId = r.CentroTrabajoId,
                            ModuloId = r.ModuloId,
                            EsSalidaUnica = r.EsSalidaUnica,
                            Secuencia = r.Secuencia,
                            CentroTrabajo = new CentroTrabajo
                            {
                                Id = r.CentroTrabajo.Id,
                                Codigo = r.CentroTrabajo.Codigo,
                                Nombre = r.CentroTrabajo.Nombre,
                                Secuencia = r.CentroTrabajo.Secuencia,
                                Estado = r.CentroTrabajo.Estado
                            },
                            Modulo = new Modulo
                            {
                                Id = r.Modulo.Id,
                                CentroTrabajoId = r.Modulo.CentroTrabajoId,
                                Nombre = r.Modulo.Nombre,
                                Secuencia = r.Modulo.Secuencia,
                                Estado = r.Modulo.Estado
                            }
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalleBusiness / GetByLinea", exception);
            }
        }

        #endregion
    }
}