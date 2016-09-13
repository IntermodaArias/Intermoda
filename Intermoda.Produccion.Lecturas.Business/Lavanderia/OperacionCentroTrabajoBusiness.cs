using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class OperacionCentroTrabajoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public short OperacionCodigo { get; set; }

        [DataMember]
        public int CentroTrabajoCodigo { get; set; }

        [DataMember]
        public string CentroTrabajoNombre { get; set; }

        [DataMember]
        public int? EsRepetible { get; set; }

        [DataMember]
        public CentroTrabajoBusiness CentroTrabajo { get; private set; }

        [DataMember]
        public OperacionBusiness Operacion { get; private set; }

        #endregion

        #region Methods

        public static OperacionCentroTrabajoBusiness Insert(OperacionCentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OperacionesCTrabajos()
                    {
                        OperacionCodigo = model.OperacionCodigo,
                        CtrabajoCodigo = model.CentroTrabajoCodigo,
                        CtrabajoNombre = model.CentroTrabajoNombre,
                        EsRepetible = model.EsRepetible
                    };
                    _context.OperacionesCTrabajosSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OperacionesCtCode;
                    model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoCodigo);
                    model.Operacion = OperacionBusiness.Get(model.OperacionCodigo);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / Insert", exception);
            }
        }

        public static OperacionCentroTrabajoBusiness Update(OperacionCentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesCTrabajosSet
                               where r.OperacionesCtCode == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OperacionCodigo = model.OperacionCodigo;
                        reg.CtrabajoCodigo = model.CentroTrabajoCodigo;
                        reg.CtrabajoNombre = model.CentroTrabajoNombre;
                        reg.EsRepetible = model.EsRepetible;

                        _context.SaveChanges();

                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoCodigo);
                        model.Operacion = OperacionBusiness.Get(model.OperacionCodigo);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionCentroTrabajo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / Update", exception);
            }
        }

        public static void UpdateEsRepetible(short operacionCentroTrabajoId, int esRepetible)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesCTrabajosSet
                               where r.OperacionesCtCode == operacionCentroTrabajoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.EsRepetible = esRepetible;

                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / UpdateEsRepetible", exception);
            }
        }

        public static void Delete(OperacionCentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesCTrabajosSet
                               where r.OperacionesCtCode == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesCTrabajosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionCentroTrabajo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int operacionCentroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesCTrabajosSet
                               where r.OperacionesCtCode == operacionCentroTrabajoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesCTrabajosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionCentroTrabajo con Id: {operacionCentroTrabajoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / Delete (id)", exception);
            }
        }

        public static OperacionCentroTrabajoBusiness Get(int operacionCentroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesCTrabajosSet
                                 where r.OperacionesCtCode == operacionCentroTrabajoId
                                 select new OperacionCentroTrabajoBusiness
                                 {
                                     Id = r.OperacionesCtCode,
                                     OperacionCodigo = r.OperacionCodigo,
                                     CentroTrabajoCodigo = r.CtrabajoCodigo,
                                     CentroTrabajoNombre = r.CtrabajoNombre,
                                     EsRepetible = r.EsRepetible
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoCodigo);
                        model.Operacion = OperacionBusiness.Get(model.OperacionCodigo);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionCentroTrabajo con Id: {operacionCentroTrabajoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / Get", exception);
            }
        }

        public static OperacionCentroTrabajoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesCTrabajosSet
                            select new OperacionCentroTrabajoBusiness
                            {
                                Id = r.OperacionesCtCode,
                                OperacionCodigo = r.OperacionCodigo,
                                CentroTrabajoCodigo = r.CtrabajoCodigo,
                                CentroTrabajoNombre = r.CtrabajoNombre,
                                EsRepetible = r.EsRepetible
                            }).ToArray();

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoCodigo);
                        model.Operacion = OperacionBusiness.Get(model.OperacionCodigo);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / GetAll", exception);
            }
        }

        public static OperacionCentroTrabajoBusiness[] GetByCentroTrabajo(int centroTrabajoCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesCTrabajosSet
                                 where r.CtrabajoCodigo == centroTrabajoCodigo
                                 orderby r.CtrabajoCodigo
                                 select new OperacionCentroTrabajoBusiness
                                 {
                                     Id = r.OperacionesCtCode,
                                     OperacionCodigo = r.OperacionCodigo,
                                     CentroTrabajoCodigo = r.CtrabajoCodigo,
                                     CentroTrabajoNombre = r.CtrabajoNombre,
                                     EsRepetible = r.EsRepetible
                                 }).ToArray();

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoCodigo);
                        model.Operacion = OperacionBusiness.Get(model.OperacionCodigo);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / GetByCentroTrabajo", exception);
            }
        }

        public static OperacionCentroTrabajoBusiness[] GetByOperacion(short operacionCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesCTrabajosSet
                                 where r.OperacionCodigo == operacionCodigo
                                 orderby r.OperacionCodigo
                                 select new OperacionCentroTrabajoBusiness
                                 {
                                     Id = r.OperacionesCtCode,
                                     OperacionCodigo = r.OperacionCodigo,
                                     CentroTrabajoCodigo = r.CtrabajoCodigo,
                                     CentroTrabajoNombre = r.CtrabajoNombre,
                                     EsRepetible = r.EsRepetible
                                 }).ToArray();

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoCodigo);
                        model.Operacion = OperacionBusiness.Get(model.OperacionCodigo);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajoBusiness / GetByOperacion", exception);
            }
        }

        #endregion
    }
}