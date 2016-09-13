using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Produccion.Lecturas.Business.Lecturas
{
    [DataContract]
    public class ModuloBusiness
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
        public int CentroTrabajoId { get; set; }
        [DataMember]
        public bool Estado { get; set; }

        #endregion

        #region Methods

        public static ModuloBusiness Insert(ModuloBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new Modulo()
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        CentroTrabajoId = model.CentroTrabajoId,
                        Estado = model.Estado
                    };
                    _context.ModuloSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / Insert", exception);
            }
        }

        public static ModuloBusiness Update(ModuloBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Secuencia = model.Secuencia;
                        reg.CentroTrabajoId = model.CentroTrabajoId;
                        reg.Estado = model.Estado;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Modulo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / Update", exception);
            }
        }

        public static void Delete(ModuloBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ModuloSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Modulo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int moduloId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.ModuloSet
                               where r.Id == moduloId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ModuloSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Modulo con Id: {moduloId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / Delete (id)", exception);
            }
        }

        public static ModuloBusiness Get(int moduloId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.ModuloSet
                                 where r.Id == moduloId
                                 select new ModuloBusiness
                                 {
                                     Id = r.Id,
                                     Codigo = r.Codigo,
                                     Nombre = r.Nombre,
                                     Secuencia = r.Secuencia,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     Estado = r.Estado
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Modulo con Id: {moduloId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / Get", exception);
            }
        }

        public static ModuloBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.ModuloSet
                            orderby r.CentroTrabajoId, r.Secuencia, r.Nombre
                            select new ModuloBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                CentroTrabajoId = r.CentroTrabajoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / GetAll", exception);
            }
        }

        public static ModuloBusiness[] GetAllActivos()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.ModuloSet
                            where r.Estado
                            orderby r.CentroTrabajoId, r.Estado, r.Secuencia, r.Nombre
                            select new ModuloBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                CentroTrabajoId = r.CentroTrabajoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / GetAllActivos", exception);
            }
        }

        public static ModuloBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.ModuloSet
                            where r.CentroTrabajoId == centroTrabajoId
                            orderby r.CentroTrabajoId, r.Secuencia, r.Nombre
                            select new ModuloBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                CentroTrabajoId = r.CentroTrabajoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / GetByCentroTrabajo", exception);
            }
        }

        public static ModuloBusiness[] GetByCentroTrabajoActivos(int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.ModuloSet
                        where r.Estado &&
                              r.CentroTrabajoId == centroTrabajoId
                        orderby r.CentroTrabajoId, r.Secuencia, r.Nombre
                        select new ModuloBusiness
                        {
                            Id = r.Id,
                            Codigo = r.Codigo,
                            Nombre = r.Nombre,
                            Secuencia = r.Secuencia,
                            CentroTrabajoId = r.CentroTrabajoId,
                            Estado = r.Estado
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloBusiness / GetByCentroTrabajoActivos", exception);
            }
        }

        #endregion
    }
}