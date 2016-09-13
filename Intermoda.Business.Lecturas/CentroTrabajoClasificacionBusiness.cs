using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Business.Lecturas
{
    [DataContract]
    public class CentroTrabajoClasificacionBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Secuencia { get; set; }
        [DataMember]
        public CentroTrabajoClasificacionTipo Tipo { get; set; }
        [DataMember]
        public int CentroTrabajoId { get; set; }
        [DataMember]
        public bool Estado { get; set; }

        #endregion

        #region Methods

        public static CentroTrabajoClasificacionBusiness Insert(CentroTrabajoClasificacionBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new CentroTrabajoClasificacion()
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Tipo = (int)model.Tipo,
                        CentroTrabajoId = model.CentroTrabajoId,
                        Estado = model.Estado
                    };
                    _context.CentroTrabajoClasificacionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / Insert", exception);
            }
        }

        public static CentroTrabajoClasificacionBusiness Update(CentroTrabajoClasificacionBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.CentroTrabajoClasificacionSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Secuencia = model.Secuencia;
                        reg.Tipo = (int) model.Tipo;
                        reg.CentroTrabajoId = model.CentroTrabajoId;
                        reg.Estado = model.Estado;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoClasificacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / Update", exception);
            }
        }

        public static void Delete(CentroTrabajoClasificacionBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.CentroTrabajoClasificacionSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentroTrabajoClasificacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoClasificacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int centroTrabajoClasificacionId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.CentroTrabajoClasificacionSet
                               where r.Id == centroTrabajoClasificacionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentroTrabajoClasificacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoClasificacion con Id: {centroTrabajoClasificacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / Delete (id)", exception);
            }
        }

        public static CentroTrabajoClasificacionBusiness Get(int centroTrabajoClasificacionId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.CentroTrabajoClasificacionSet
                                 where r.Id == centroTrabajoClasificacionId
                                 select new CentroTrabajoClasificacionBusiness
                                 {
                                     Id = r.Id,
                                     Codigo = r.Codigo,
                                     Nombre = r.Nombre,
                                     Secuencia = r.Secuencia,
                                     Tipo = (CentroTrabajoClasificacionTipo)r.Tipo,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     Estado = r.Estado
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoClasificacion con Id: {centroTrabajoClasificacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / Get", exception);
            }
        }

        public static CentroTrabajoClasificacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.CentroTrabajoClasificacionSet
                            orderby r.CentroTrabajoId, r.Secuencia, r.Nombre
                            select new CentroTrabajoClasificacionBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Tipo = (CentroTrabajoClasificacionTipo)r.Tipo,
                                CentroTrabajoId = r.CentroTrabajoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / GetAll", exception);
            }
        }

        public static CentroTrabajoClasificacionBusiness[] GetAllActivos()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.CentroTrabajoClasificacionSet
                            where r.Estado
                            orderby r.Estado, r.CentroTrabajoId, r.Secuencia, r.Nombre
                            select new CentroTrabajoClasificacionBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Tipo = (CentroTrabajoClasificacionTipo)r.Tipo,
                                CentroTrabajoId = r.CentroTrabajoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / GetAllActive", exception);
            }
        }

        public static CentroTrabajoClasificacionBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.CentroTrabajoClasificacionSet
                            where r.CentroTrabajoId == centroTrabajoId
                            orderby r.CentroTrabajoId, r.Secuencia, r.Nombre
                            select new CentroTrabajoClasificacionBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Tipo = (CentroTrabajoClasificacionTipo)r.Tipo,
                                CentroTrabajoId = r.CentroTrabajoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / GetByCentroTrabajo", exception);
            }
        }

        public static CentroTrabajoClasificacionBusiness[] GetByCentroTrabajoActivos(int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.CentroTrabajoClasificacionSet
                        where r.CentroTrabajoId == centroTrabajoId &&
                              r.Estado
                        orderby r.CentroTrabajoId, r.Estado, r.Secuencia, r.Nombre
                        select new CentroTrabajoClasificacionBusiness
                        {
                            Id = r.Id,
                            Codigo = r.Codigo,
                            Nombre = r.Nombre,
                            Secuencia = r.Secuencia,
                            Tipo = (CentroTrabajoClasificacionTipo) r.Tipo,
                            CentroTrabajoId = r.CentroTrabajoId,
                            Estado = r.Estado
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacionBusiness / GetByCentroTrabajoActivos", exception);
            }
        }

        #endregion
    }
}