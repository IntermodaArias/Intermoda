using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ProcesoCentroTrabajoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProcesoId { get; set; }

        [DataMember]
        public int CentroTrabajoId { get; set; }

        [DataMember]
        public int CentroTrabajoOpcionId { get; set; }

        [DataMember]
        public int Orden { get; set; }

        //

        [DataMember]
        public ProcesoBusiness Proceso { get; private set; }

        [DataMember]
        public CTrabajoBusiness CentroTrabajo { get; private set; }

        [DataMember]
        public CentroTrabajoOpcionBusiness CentroTrabajoOpcion { get; private set; }

        #endregion

        #region Methods

        public static ProcesoCentroTrabajoBusiness Insert(ProcesoCentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new ProcesosCentroTrabajo
                    {
                        ProcesoId = model.ProcesoId,
                        CentroTrabajoId = model.CentroTrabajoId,
                        CentroTrabajoOpcionId = model.CentroTrabajoOpcionId,
                        ProcesoCentroTrabajoOrden = model.Orden
                    };
                    _context.ProcesosCentroTrabajoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ProcesoCentroTrabajoId;
                    model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                    model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                    model.CentroTrabajoOpcion = CentroTrabajoOpcionBusiness.Get(model.CentroTrabajoOpcionId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / Insert", exception);
            }
        }

        public static ProcesoCentroTrabajoBusiness Update(ProcesoCentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosCentroTrabajoSet
                               where r.ProcesoCentroTrabajoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ProcesoId = model.ProcesoId;
                        reg.CentroTrabajoId = model.CentroTrabajoId;
                        reg.CentroTrabajoOpcionId = model.CentroTrabajoOpcionId;
                        reg.ProcesoCentroTrabajoOrden = model.Orden;

                        _context.SaveChanges();

                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.CentroTrabajoOpcion = CentroTrabajoOpcionBusiness.Get(model.CentroTrabajoOpcionId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / Update", exception);
            }
        }

        public static void Delete(ProcesoCentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosCentroTrabajoSet
                               where r.ProcesoCentroTrabajoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ProcesosCentroTrabajoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int procesoCentroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosCentroTrabajoSet
                               where r.ProcesoCentroTrabajoId == procesoCentroTrabajoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ProcesosCentroTrabajoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajo con Id: {procesoCentroTrabajoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / Delete (id)", exception);
            }
        }

        public static ProcesoCentroTrabajoBusiness Get(int procesoCentroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ProcesosCentroTrabajoSet
                                 where r.ProcesoCentroTrabajoId == procesoCentroTrabajoId
                                 select new ProcesoCentroTrabajoBusiness
                                 {
                                     Id = r.ProcesoCentroTrabajoId,
                                     ProcesoId = r.ProcesoId,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                                     Orden = r.ProcesoCentroTrabajoOrden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.CentroTrabajoOpcion = CentroTrabajoOpcionBusiness.Get(model.CentroTrabajoOpcionId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajo con Id: {procesoCentroTrabajoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / Get", exception);
            }
        }

        public static ProcesoCentroTrabajoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ProcesosCentroTrabajoSet
                        select new ProcesoCentroTrabajoBusiness
                        {
                            Id = r.ProcesoCentroTrabajoId,
                            ProcesoId = r.ProcesoId,
                            CentroTrabajoId = r.CentroTrabajoId,
                            CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                            Orden = r.ProcesoCentroTrabajoOrden
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.CentroTrabajoOpcion = CentroTrabajoOpcionBusiness.Get(model.CentroTrabajoOpcionId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / GetAll", exception);
            }
        }

        public static ProcesoCentroTrabajoBusiness[] GetByProceso(int procesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ProcesosCentroTrabajoSet
                                 where r.ProcesoId == procesoId
                                 orderby r.ProcesoId, r.CentroTrabajoId, r.ProcesoCentroTrabajoOrden
                                 select new ProcesoCentroTrabajoBusiness
                                 {
                                     Id = r.ProcesoCentroTrabajoId,
                                     ProcesoId = r.ProcesoId,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                                     Orden = r.ProcesoCentroTrabajoOrden
                                 }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.CentroTrabajoOpcion = CentroTrabajoOpcionBusiness.Get(model.CentroTrabajoOpcionId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / GetAll", exception);
            }
        }

        public static ProcesoCentroTrabajoBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ProcesosCentroTrabajoSet
                                 join p in _context.ProcesosSet on 
                                 r.ProcesoId equals p.ProcesoCodigo
                                 join c in _context.CentrosTrabajosSet on
                                 r.CentroTrabajoId equals c.CentroTrabajoCodigo
                                 where r.CentroTrabajoId == centroTrabajoId
                                 orderby r.CentroTrabajoId, r.ProcesoCentroTrabajoOrden
                                 select new ProcesoCentroTrabajoBusiness
                                 {
                                     Id = r.ProcesoCentroTrabajoId,
                                     ProcesoId = r.ProcesoId,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                                     Orden = r.ProcesoCentroTrabajoOrden,
                                     Proceso = new ProcesoBusiness
                                     {
                                         Id = p.ProcesoCodigo,
                                         Nombre = p.ProcesoNombre,
                                         Descripcion = p.ProcesoDescripcion,
                                         EsActivo = p.ProcesoIsActivo,
                                         EsObligatorio = p.ProcesoIsObligatorio,
                                         Secuencia = p.ProcesoOrden,
                                         TiempoEstandar = p.ProcesoTiempoEstandar
                                     },
                                     CentroTrabajo = new CTrabajoBusiness
                                     {
                                         Codigo = c.CentroTrabajoCodigo,
                                         Nombre = c.CentroTrabajoNombre,
                                         EsActivo = c.CentroTrabajoIsActivo,
                                         EsObligatorio = c.CentroTrabajoIsObligatorio,
                                         LineaProduccionCodigo = c.LineaProduccionCodigo,
                                         Observacion = c.CentroTrabajoObservacion,
                                         Orden = c.CentroTrabajoOrdenNumero,
                                         TiempoEspera = c.CentroTrabajoTiempoEspera,
                                         TiempoProceso = c.CentroTrabajoTiempoProceso
                                     },
                                     CentroTrabajoOpcion = new CentroTrabajoOpcionBusiness
                                     {
                                         Id = r.CentrosTrabajoOpcion.CentroTrabajoOpcionId,
                                         CentroTrabajoId = r.CentrosTrabajoOpcion.CentroTrabajoId,
                                         OpcionId = r.CentrosTrabajoOpcion.OpcionId,
                                         CentroTrabajoNombre = c.CentroTrabajoNombre,
                                         CentroTrabajoObservacion = c.CentroTrabajoObservacion
                                     }
                                 }).ToArray();

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / GetAll", exception);
            }
        }

        public static ProcesoCentroTrabajoBusiness[] GetByCentroTrabajoOpcion(int centroTrabajoOpcionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ProcesosCentroTrabajoSet
                                 where r.CentroTrabajoOpcionId == centroTrabajoOpcionId
                                 orderby r.CentroTrabajoOpcionId, r.ProcesoCentroTrabajoOrden
                                 select new ProcesoCentroTrabajoBusiness
                                 {
                                     Id = r.ProcesoCentroTrabajoId,
                                     ProcesoId = r.ProcesoId,
                                     CentroTrabajoId = r.CentroTrabajoId,
                                     CentroTrabajoOpcionId = r.CentroTrabajoOpcionId,
                                     Orden = r.ProcesoCentroTrabajoOrden
                                 }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                        model.CentroTrabajoOpcion = CentroTrabajoOpcionBusiness.Get(model.CentroTrabajoOpcionId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}