using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Produccion.Lecturas.Business.Lecturas
{
    [DataContract]
    public class CentroTrabajoBusiness
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
        public bool Estado { get; set; }

        #endregion

        #region Methods

        public static CentroTrabajoBusiness Insert(CentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new CentroTrabajo()
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                    _context.CentroTrabajoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Insert", exception);
            }
        }

        public static CentroTrabajoBusiness Update(CentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.CentroTrabajoSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Secuencia = model.Secuencia;
                        reg.Estado = model.Estado;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Update", exception);
            }
        }

        public static void Delete(CentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.CentroTrabajoSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentroTrabajoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.CentroTrabajoSet
                               where r.Id == centroTrabajoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentroTrabajoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajo con Id: {centroTrabajoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Delete (id)", exception);
            }
        }

        public static CentroTrabajoBusiness Get(int centroTrabajoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.CentroTrabajoSet
                                 where r.Id == centroTrabajoId
                                 select new CentroTrabajoBusiness
                                 {
                                     Id = r.Id,
                                     Codigo = r.Codigo,
                                     Nombre = r.Nombre,
                                     Secuencia = r.Secuencia,
                                     Estado = r.Estado
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajo con Id: {centroTrabajoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Get", exception);
            }
        }

        public static CentroTrabajoBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.CentroTrabajoSet
                            orderby r.Secuencia, r.Nombre
                            select new CentroTrabajoBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetAll", exception);
            }
        }

        public static CentroTrabajoBusiness[] GetAllActivos()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.CentroTrabajoSet
                            where r.Estado
                            orderby r.Estado, r.Secuencia, r.Nombre
                            select new CentroTrabajoBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetAllActivos", exception);
            }
        }

        #endregion
    }
}