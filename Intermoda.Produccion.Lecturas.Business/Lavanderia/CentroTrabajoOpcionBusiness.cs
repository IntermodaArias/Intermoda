using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class CentroTrabajoOpcionBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int CentroTrabajoOpcionId { get; set; }

        [DataMember]
        public int CentroTrabajoId { get; set; }

        [DataMember]
        public string CentroTrabajoNombre { get; set; }

        [DataMember]
        public string CentroTrabajoObservacion { get; set; }

        [DataMember]
        public int OpcionId { get; set; }

        [DataMember]
        public int CentroTrabajoOpcionOrden { get; set; }

        //

        [DataMember]
        public CentroTrabajoBusiness CentroTrabajo { get; private set; }

        [DataMember]
        public OpcionLavadoBusiness OpcionLavado { get; private set; }

        #endregion

        #region Methods

        public static CentroTrabajoOpcionBusiness Insert(CentroTrabajoOpcionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new CentrosTrabajoOpcion
                    {
                        CentroTrabajoId = model.CentroTrabajoId,
                        OpcionId = model.OpcionId,
                        CentroTrabajoOpcionOrden = model.CentroTrabajoOpcionOrden
                    };
                    _context.CentrosTrabajoOpcionSet.Add(reg);
                    _context.SaveChanges();

                    model.CentroTrabajoOpcionId = reg.CentroTrabajoOpcionId;

                    model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                    model.OpcionLavado = OpcionLavadoBusiness.Get(model.OpcionId);
                    
                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / Insert", exception);
            }
        }

        public static void InsertLegacy(int opcionId, int centroTrabajoCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new CentrosTrabajoOpcion
                    {
                        CentroTrabajoId = centroTrabajoCodigo,
                        OpcionId = opcionId,
                        CentroTrabajoOpcionOrden = GetOrdenMaximo(opcionId) + 1
                    };
                    _context.CentrosTrabajoOpcionSet.Add(reg);
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / Insert", exception);
            }
        }

        public static CentroTrabajoOpcionBusiness Update(CentroTrabajoOpcionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajoOpcionSet
                        where r.CentroTrabajoOpcionId == model.CentroTrabajoOpcionId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CentroTrabajoId = model.CentroTrabajoId;
                        reg.OpcionId = model.OpcionId;
                        reg.CentroTrabajoOpcionOrden = model.CentroTrabajoOpcionOrden;

                        _context.SaveChanges();

                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.OpcionLavado = OpcionLavadoBusiness.Get(model.OpcionId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcion con Id: {model.CentroTrabajoOpcionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / Update", exception);
            }
        }

        private static void UpdateOrden(int opcionId, int orden)
        {
            try
            {
                var regs = (from r in _context.CentrosTrabajoOpcionSet
                    where r.OpcionId == opcionId &&
                          r.CentroTrabajoOpcionOrden > orden
                    select r).ToList();
                foreach (var reg in regs)
                {
                    reg.CentroTrabajoOpcionOrden = reg.CentroTrabajoOpcionOrden - 1;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / UpdateOrden", exception);
            }
        }

        public static void UpdateBajarOrden(int opcionId, int orden)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (GetOrdenMaximo(opcionId) == orden) return;

                    var newOrden = orden + 1;

                    var regs = (from r in _context.CentrosTrabajoOpcionSet
                                where r.OpcionId == opcionId &&
                                      (r.CentroTrabajoOpcionOrden == orden ||
                                      r.CentroTrabajoOpcionOrden == newOrden)
                                select r).ToList();
                    foreach (var reg in regs)
                    {
                        if (reg.CentroTrabajoOpcionOrden == orden)
                        {
                            reg.CentroTrabajoOpcionOrden = newOrden;
                        }
                        else if (reg.CentroTrabajoOpcionOrden > orden)
                        {
                            reg.CentroTrabajoOpcionOrden = orden;
                        }
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / UpdateBajarOrden", exception);
            }
        }

        public static void UpdateSubirOrden(int opcionId, int orden)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (orden == 1) return;

                    var newOrden = orden - 1;

                    var regs = (from r in _context.CentrosTrabajoOpcionSet
                                where r.OpcionId == opcionId &&
                                      (r.CentroTrabajoOpcionOrden == orden ||
                                      r.CentroTrabajoOpcionOrden == newOrden)
                                select r).ToList();
                    foreach (var reg in regs)
                    {
                        if (reg.CentroTrabajoOpcionOrden == orden)
                        {
                            reg.CentroTrabajoOpcionOrden = newOrden;
                        }
                        else if (reg.CentroTrabajoOpcionOrden < orden)
                        {
                            reg.CentroTrabajoOpcionOrden = orden;
                        }
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / UpdateBajarOrden", exception);
            }
        }

        public static void Delete(CentroTrabajoOpcionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajoOpcionSet
                        where r.CentroTrabajoOpcionId == model.CentroTrabajoOpcionId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        UpdateOrden(reg.OpcionId, reg.CentroTrabajoOpcionOrden);
                        _context.CentrosTrabajoOpcionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcion con Id: {model.CentroTrabajoOpcionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int centroTrabajoOpcionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajoOpcionSet
                        where r.CentroTrabajoOpcionId == centroTrabajoOpcionId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        UpdateOrden(reg.OpcionId, reg.CentroTrabajoOpcionOrden);
                        _context.CentrosTrabajoOpcionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcion con Id: {centroTrabajoOpcionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / Delete (id)", exception);
            }
        }

        public static void DeleteRutaOpcionAcabado(int opcionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var query = from r in _context.CentrosTrabajoOpcionSet
                        where r.OpcionId == opcionId
                        select r;

                    _context.CentrosTrabajoOpcionSet.RemoveRange(query);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / DeleteRutaOpcionAcabado", exception);
            }
        }

        public static CentroTrabajoOpcionBusiness Get(int centroTrabajoOpcionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CentrosTrabajoOpcionSet
                        join c in _context.CentrosTrabajosSet on
                            r.CentroTrabajoId equals c.CentroTrabajoCodigo
                        where r.CentroTrabajoOpcionId == centroTrabajoOpcionId
                        select new CentroTrabajoOpcionBusiness
                        {
                            CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                            CentroTrabajoId = r.CentroTrabajoId,
                            CentroTrabajoNombre = c.CentroTrabajoNombre,
                            CentroTrabajoObservacion = c.CentroTrabajoObservacion,
                            OpcionId = r.OpcionId,
                            CentroTrabajoOpcionOrden = r.CentroTrabajoOpcionOrden
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.OpcionLavado = OpcionLavadoBusiness.Get(model.OpcionId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcion con Id: {centroTrabajoOpcionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / Get", exception);
            }
        }

        public static CentroTrabajoOpcionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CentrosTrabajoOpcionSet
                        join c in _context.CentrosTrabajosSet on
                            r.CentroTrabajoId equals c.CentroTrabajoCodigo
                        select new CentroTrabajoOpcionBusiness
                        {
                            CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                            CentroTrabajoId = r.CentroTrabajoId,
                            CentroTrabajoNombre = c.CentroTrabajoNombre,
                            CentroTrabajoObservacion = c.CentroTrabajoObservacion,
                            OpcionId = r.OpcionId,
                            CentroTrabajoOpcionOrden = r.CentroTrabajoOpcionOrden
                        }).ToList();

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.OpcionLavado = OpcionLavadoBusiness.Get(model.OpcionId);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / GetAll", exception);
            }
        }

        public static CentroTrabajoOpcionBusiness[] GetByOpcion(int opcionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CentrosTrabajoOpcionSet
                        join c in _context.CentrosTrabajosSet on
                            r.CentroTrabajoId equals c.CentroTrabajoCodigo
                        where r.OpcionId == opcionId
                        select new CentroTrabajoOpcionBusiness
                        {
                            CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                            CentroTrabajoId = r.CentroTrabajoId,
                            CentroTrabajoNombre = c.CentroTrabajoNombre,
                            CentroTrabajoObservacion = c.CentroTrabajoObservacion,
                            OpcionId = r.OpcionId,
                            CentroTrabajoOpcionOrden = r.CentroTrabajoOpcionOrden
                        }).ToList();

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.OpcionLavado = OpcionLavadoBusiness.Get(model.OpcionId);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / GetByOpcion", exception);
            }
        }

        public static CentroTrabajoOpcionBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CentrosTrabajoOpcionSet
                            join c in _context.CentrosTrabajosSet on
                                r.CentroTrabajoId equals c.CentroTrabajoCodigo
                            where r.CentroTrabajoId == centroTrabajoId
                            select new CentroTrabajoOpcionBusiness
                            {
                                CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                                CentroTrabajoId = r.CentroTrabajoId,
                                CentroTrabajoNombre = c.CentroTrabajoNombre,
                                CentroTrabajoObservacion = c.CentroTrabajoObservacion,
                                OpcionId = r.OpcionId,
                                CentroTrabajoOpcionOrden = r.CentroTrabajoOpcionOrden
                            }).ToList();
                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CentroTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.OpcionLavado = OpcionLavadoBusiness.Get(model.OpcionId);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / GetByCentroTrabajo", exception);
            }
        }

        private static int GetOrdenMaximo(int opcionId)
        {
            try
            {
                var regs = (from r in _context.CentrosTrabajoOpcionSet
                    where r.OpcionId == opcionId
                    select r.CentroTrabajoOpcionOrden);

                return regs.Any() ? regs.Max() : 0;
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionBusiness / GetOrdenMaximo", exception);
            }
        }

        #endregion
    }
}