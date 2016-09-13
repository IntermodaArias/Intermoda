using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class CentroTrabajoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int? Orden { get; set; }

        [DataMember]
        public string Observacion { get; set; }

        [DataMember]
        public decimal? TiempoEspera { get; set; }

        [DataMember]
        public decimal? TiempoProceso { get; set; }

        [DataMember]
        public int? LineaProduccionCodigo { get; set; }

        [DataMember]
        public bool? EsObligatorio { get; set; }

        [DataMember]
        public bool? EsActivo { get; set; }

        #endregion

        #region Methods

        public static CentroTrabajoBusiness Insert(CentroTrabajoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new CentrosTrabajos
                    {
                        CentroTrabajoNombre = model.Nombre,
                        CentroTrabajoOrdenNumero = model.Orden,
                        CentroTrabajoObservacion = model.Observacion,
                        CentroTrabajoTiempoEspera = model.TiempoEspera,
                        CentroTrabajoTiempoProceso = model.TiempoProceso,
                        LineaProduccionCodigo = model.LineaProduccionCodigo,
                        CentroTrabajoIsObligatorio = model.EsObligatorio,
                        CentroTrabajoIsActivo = model.EsActivo
                    };
                    _context.CentrosTrabajosSet.Add(reg);
                    _context.SaveChanges();

                    model.Codigo = reg.CentroTrabajoCodigo;

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
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajosSet
                               where r.CentroTrabajoCodigo == model.Codigo
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CentroTrabajoNombre = model.Nombre;
                        reg.CentroTrabajoOrdenNumero = model.Orden;
                        reg.CentroTrabajoObservacion = model.Observacion;
                        reg.CentroTrabajoTiempoEspera = model.TiempoEspera;
                        reg.CentroTrabajoTiempoProceso = model.TiempoProceso;
                        reg.LineaProduccionCodigo = model.LineaProduccionCodigo;
                        reg.CentroTrabajoIsObligatorio = model.EsObligatorio;
                        reg.CentroTrabajoIsActivo = model.EsActivo;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajo con Id: {model.Codigo}");
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
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajosSet
                               where r.CentroTrabajoCodigo == model.Codigo
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentrosTrabajosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajo con Id: {model.Codigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int centroTrabajoCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajosSet
                               where r.CentroTrabajoCodigo == centroTrabajoCodigo
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentrosTrabajosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoBusiness con Id: {centroTrabajoCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / Delete (id)", exception);
            }
        }

        public static CentroTrabajoBusiness Get(int centroTrabajoCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CentrosTrabajosSet
                                 where r.CentroTrabajoCodigo == centroTrabajoCodigo
                                 select new CentroTrabajoBusiness
                                 {
                                     Codigo = r.CentroTrabajoCodigo,
                                     Nombre = r.CentroTrabajoNombre,
                                     Orden = r.CentroTrabajoOrdenNumero,
                                     Observacion = r.CentroTrabajoObservacion,
                                     TiempoEspera = r.CentroTrabajoTiempoEspera,
                                     TiempoProceso = r.CentroTrabajoTiempoProceso,
                                     LineaProduccionCodigo = r.LineaProduccionCodigo,
                                     EsObligatorio = r.CentroTrabajoIsObligatorio,
                                     EsActivo = r.CentroTrabajoIsActivo
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoBusiness con Id: {centroTrabajoCodigo}");
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
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CentrosTrabajosSet
                            select new CentroTrabajoBusiness
                            { 
                                Codigo = r.CentroTrabajoCodigo,
                                Nombre = r.CentroTrabajoNombre,
                                Orden = r.CentroTrabajoOrdenNumero,
                                Observacion = r.CentroTrabajoObservacion,
                                TiempoEspera = r.CentroTrabajoTiempoEspera,
                                TiempoProceso = r.CentroTrabajoTiempoProceso,
                                LineaProduccionCodigo = r.LineaProduccionCodigo,
                                EsObligatorio = r.CentroTrabajoIsObligatorio,
                                EsActivo = r.CentroTrabajoIsActivo
                            }).ToArray();
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetAll", exception);
            }
        }

        public static CentroTrabajoBusiness[] GetActivos()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CentrosTrabajosSet
                        where r.CentroTrabajoIsActivo == true
                        select new CentroTrabajoBusiness
                        {
                            Codigo = r.CentroTrabajoCodigo,
                            Nombre = r.CentroTrabajoNombre,
                            Orden = r.CentroTrabajoOrdenNumero,
                            Observacion = r.CentroTrabajoObservacion,
                            TiempoEspera = r.CentroTrabajoTiempoEspera,
                            TiempoProceso = r.CentroTrabajoTiempoProceso,
                            LineaProduccionCodigo = r.LineaProduccionCodigo,
                            EsObligatorio = r.CentroTrabajoIsObligatorio,
                            EsActivo = r.CentroTrabajoIsActivo
                        }).ToArray();
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetAllActivos", exception);
            }
        }
        
        public static CentroTrabajoBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from o in _context.OperacionesSet
                            join oc in _context.OperacionesCTrabajosSet on 
                            o.OperacionCodigo equals oc.OperacionCodigo
                            join c in _context.CentrosTrabajosSet on 
                            oc.CtrabajoCodigo equals c.CentroTrabajoCodigo
                            select new CentroTrabajoBusiness
                            {
                                Codigo = c.CentroTrabajoCodigo,
                                Nombre = c.CentroTrabajoNombre,
                                Orden = c.CentroTrabajoOrdenNumero,
                                Observacion = c.CentroTrabajoObservacion,
                                TiempoEspera = c.CentroTrabajoTiempoEspera,
                                TiempoProceso = c.CentroTrabajoTiempoProceso,
                                LineaProduccionCodigo = c.LineaProduccionCodigo,
                                EsObligatorio = c.CentroTrabajoIsObligatorio,
                                EsActivo = c.CentroTrabajoIsActivo
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetByOperacion", exception);
            }
        }

        public static CentroTrabajoBusiness[] GetAllLavanderia()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CentrosTrabajosSet
                        where r.CentroTrabajoCodigoTipo == 4
                        select new CentroTrabajoBusiness
                        {
                            Codigo = r.CentroTrabajoCodigo,
                            Nombre = r.CentroTrabajoNombre,
                            Orden = r.CentroTrabajoOrdenNumero,
                            Observacion = r.CentroTrabajoObservacion,
                            TiempoEspera = r.CentroTrabajoTiempoEspera,
                            TiempoProceso = r.CentroTrabajoTiempoProceso,
                            LineaProduccionCodigo = r.LineaProduccionCodigo,
                            EsObligatorio = r.CentroTrabajoIsObligatorio,
                            EsActivo = r.CentroTrabajoIsActivo
                        }).ToArray();
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoBusiness / GetAllLavanderia", exception);
            }
        }

        #endregion
    }
}