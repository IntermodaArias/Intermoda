using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ProcesoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Secuencia { get; set; }

        [DataMember]
        public bool EsActivo { get; set; }

        [DataMember]
        public bool EsObligatorio { get; set; }

        [DataMember]
        public int CentroTrabajoId { get; set; }

        [DataMember]
        public decimal? TiempoEstandar { get; set; }


        [DataMember]
        public CTrabajoBusiness CentroTrabajo { get; private set; }

        #endregion

        #region Methods

        public static ProcesoBusiness Insert(ProcesoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new Procesos
                    {
                        ProcesoNombre = model.Nombre,
                        ProcesoDescripcion = model.Descripcion,
                        ProcesoOrden = model.Secuencia,
                        ProcesoIsActivo = model.EsActivo,
                        ProcesoIsObligatorio = model.EsObligatorio,
                        ProcesoTiempoEstandar = model.TiempoEstandar,
                        CentroTrabajoCodigo = model.CentroTrabajoId
                    };
                    _context.ProcesosSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ProcesoCodigo;
                    model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / Insert", exception);
            }
        }

        public static ProcesoBusiness Update(ProcesoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosSet
                               where r.ProcesoCodigo == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ProcesoNombre = model.Nombre;
                        reg.ProcesoDescripcion = model.Descripcion;
                        reg.ProcesoOrden = model.Secuencia;
                        reg.ProcesoIsActivo = model.EsActivo;
                        reg.ProcesoIsObligatorio = model.EsObligatorio;
                        reg.ProcesoTiempoEstandar = model.TiempoEstandar;
                        reg.CentroTrabajoCodigo = model.CentroTrabajoId;

                        _context.SaveChanges();

                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Proceso con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / Update", exception);
            }
        }

        public static void Delete(ProcesoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosSet
                               where r.ProcesoCodigo == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ProcesosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Proceso con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int procesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosSet
                               where r.ProcesoCodigo == procesoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ProcesosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Proceso con Id: {procesoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / Delete (id)", exception);
            }
        }

        public static ProcesoBusiness Get(int procesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ProcesosSet
                                 where r.ProcesoCodigo == procesoId
                                 select new ProcesoBusiness
                                 {
                                     Id = r.ProcesoCodigo,
                                     Nombre = r.ProcesoNombre,
                                     Descripcion = r.ProcesoDescripcion,
                                     Secuencia = r.ProcesoOrden,
                                     EsActivo = r.ProcesoIsActivo,
                                     EsObligatorio = r.ProcesoIsObligatorio,
                                     TiempoEstandar = r.ProcesoTiempoEstandar,
                                     CentroTrabajoId = r.CentroTrabajoCodigo
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Proceso con Id: {procesoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / Get", exception);
            }
        }

        public static ProcesoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ProcesosSet
                        select new ProcesoBusiness
                        {
                            Id = r.ProcesoCodigo,
                            Nombre = r.ProcesoNombre,
                            Descripcion = r.ProcesoDescripcion,
                            Secuencia = r.ProcesoOrden,
                            EsActivo = r.ProcesoIsActivo,
                            EsObligatorio = r.ProcesoIsObligatorio,
                            TiempoEstandar = r.ProcesoTiempoEstandar,
                            CentroTrabajoId = r.CentroTrabajoCodigo
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = CTrabajoBusiness.Get(model.CentroTrabajoId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / GetAll", exception);
            }
        }

        public static ProcesoBusiness[] GetbyCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ProcesosSet
                                 where r.CentroTrabajoCodigo == centroTrabajoId
                                 select new ProcesoBusiness
                                 {
                                     Id = r.ProcesoCodigo,
                                     Nombre = r.ProcesoNombre,
                                     Descripcion = r.ProcesoDescripcion,
                                     Secuencia = r.ProcesoOrden,
                                     EsActivo = r.ProcesoIsActivo,
                                     EsObligatorio = r.ProcesoIsObligatorio,
                                     TiempoEstandar = r.ProcesoTiempoEstandar,
                                     CentroTrabajoId = r.CentroTrabajoCodigo
                                 }).ToArray();

                    var centroTrabajo = CTrabajoBusiness.Get(centroTrabajoId);

                    foreach (var model in lista)
                    {
                        model.CentroTrabajo = centroTrabajo;
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoBusiness / GetbyCentroTrabajo", exception);
            }
        }

        #endregion
    }
}