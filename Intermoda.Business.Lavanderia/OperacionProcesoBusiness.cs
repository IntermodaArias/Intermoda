using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class OperacionProcesoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int ProcesoId { get; set; }

        [DataMember]
        public int ProcesoCentroTrabajoId { get; set; }

        [DataMember]
        public int Temperatura { get; set; }

        [DataMember]
        public string Ph { get; set; }

        [DataMember]
        public decimal TiempoMinimo { get; set; }

        [DataMember]
        public decimal TiempoMaximo { get; set; }

        [DataMember]
        public decimal? TiempoEstandar { get; set; }

        [DataMember]
        public int RelacionBano { get; set; }

        [DataMember]
        public int Orden { get; set; }

        //

        [DataMember]
        public OperacionBusiness Operacion { get; set; }

        [DataMember]
        public ProcesoBusiness Proceso { get; set; }

        [DataMember]
        public ProcesoCentroTrabajoBusiness ProcesoCentroTrabajo { get; set; }

        #endregion

        #region Methods

        public static OperacionProcesoBusiness Insert(OperacionProcesoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OperacionesProceso
                    {
                        OperacionId = model.OperacionId,
                        ProcesoId = model.ProcesoId,
                        ProcesoCentroTrabajoId = model.ProcesoCentroTrabajoId,
                        OperacionProcesoTemperatura = model.Temperatura,
                        OperacionProcesoPh = model.Ph,
                        OperacionProcesoTiempoMinimo = model.TiempoMinimo,
                        OperacionProcesoTiempoMaximo = model.TiempoMaximo,
                        OperacionProcesoTiempoEstandar = model.TiempoEstandar,
                        OperacionProcesoRelacion = model.RelacionBano,
                        OperacionProcesoOrden = model.Orden
                    };
                    _context.OperacionesProcesoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OperacionProcesoId;
                    model.Operacion = OperacionBusiness.Get(model.OperacionId);
                    model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                    model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / Insert", exception);
            }
        }

        public static OperacionProcesoBusiness Update(OperacionProcesoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesProcesoSet
                               where r.OperacionProcesoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OperacionId = model.OperacionId;
                        reg.ProcesoId = model.ProcesoId;
                        reg.ProcesoCentroTrabajoId = model.ProcesoCentroTrabajoId;
                        reg.OperacionProcesoTemperatura = model.Temperatura;
                        reg.OperacionProcesoPh = model.Ph;
                        reg.OperacionProcesoTiempoMinimo = model.TiempoMinimo;
                        reg.OperacionProcesoTiempoMaximo = model.TiempoMaximo;
                        reg.OperacionProcesoTiempoEstandar = model.TiempoEstandar;
                        reg.OperacionProcesoRelacion = model.RelacionBano;
                        reg.OperacionProcesoOrden = model.Orden;

                        _context.SaveChanges();

                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProceso con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / Update", exception);
            }
        }

        public static void Delete(OperacionProcesoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesProcesoSet
                               where r.OperacionProcesoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesProcesoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProceso con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int operacionProcesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesProcesoSet
                               where r.OperacionProcesoId == operacionProcesoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesProcesoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProceso con Id: {operacionProcesoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / Delete (id)", exception);
            }
        }

        public static OperacionProcesoBusiness Get(int operacionProcesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesProcesoSet
                        where r.OperacionProcesoId == operacionProcesoId
                        select new OperacionProcesoBusiness
                        {
                            Id = r.OperacionProcesoId,
                            OperacionId = r.OperacionId,
                            ProcesoId = r.ProcesoId,
                            ProcesoCentroTrabajoId = r.ProcesoCentroTrabajoId,
                            Temperatura = r.OperacionProcesoTemperatura,
                            Ph = r.OperacionProcesoPh,
                            TiempoMinimo = r.OperacionProcesoTiempoMinimo,
                            TiempoMaximo = r.OperacionProcesoTiempoMaximo,
                            TiempoEstandar = r.OperacionProcesoTiempoEstandar,
                            RelacionBano = r.OperacionProcesoRelacion,
                            Orden = r.OperacionProcesoOrden
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProceso con Id: {operacionProcesoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / Get", exception);
            }
        }

        public static OperacionProcesoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesProcesoSet
                            select new OperacionProcesoBusiness
                            {
                                Id = r.OperacionProcesoId,
                                OperacionId = r.OperacionId,
                                ProcesoId = r.ProcesoId,
                                ProcesoCentroTrabajoId = r.ProcesoCentroTrabajoId,
                                Temperatura = r.OperacionProcesoTemperatura,
                                Ph = r.OperacionProcesoPh,
                                TiempoMinimo = r.OperacionProcesoTiempoMinimo,
                                TiempoMaximo = r.OperacionProcesoTiempoMaximo,
                                TiempoEstandar = r.OperacionProcesoTiempoEstandar,
                                RelacionBano = r.OperacionProcesoRelacion,
                                Orden = r.OperacionProcesoOrden
                            }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / GetAll", exception);
            }
        }

        public static OperacionProcesoBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesProcesoSet
                        where r.OperacionId == operacionId
                        orderby r.OperacionId, r.OperacionProcesoOrden
                        select new OperacionProcesoBusiness
                        {
                            Id = r.OperacionProcesoId,
                            OperacionId = r.OperacionId,
                            ProcesoId = r.ProcesoId,
                            ProcesoCentroTrabajoId = r.ProcesoCentroTrabajoId,
                            Temperatura = r.OperacionProcesoTemperatura,
                            Ph = r.OperacionProcesoPh,
                            TiempoMinimo = r.OperacionProcesoTiempoMinimo,
                            TiempoMaximo = r.OperacionProcesoTiempoMaximo,
                            TiempoEstandar = r.OperacionProcesoTiempoEstandar,
                            RelacionBano = r.OperacionProcesoRelacion,
                            Orden = r.OperacionProcesoOrden
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / GetAll", exception);
            }
        }

        public static OperacionProcesoBusiness[] GetByProceso(int procesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesProcesoSet
                        where r.ProcesoId == procesoId
                        orderby r.ProcesoId, r.OperacionProcesoOrden
                        select new OperacionProcesoBusiness
                        {
                            Id = r.OperacionProcesoId,
                            OperacionId = r.OperacionId,
                            ProcesoId = r.ProcesoId,
                            ProcesoCentroTrabajoId = r.ProcesoCentroTrabajoId,
                            Temperatura = r.OperacionProcesoTemperatura,
                            Ph = r.OperacionProcesoPh,
                            TiempoMinimo = r.OperacionProcesoTiempoMinimo,
                            TiempoMaximo = r.OperacionProcesoTiempoMaximo,
                            TiempoEstandar = r.OperacionProcesoTiempoEstandar,
                            RelacionBano = r.OperacionProcesoRelacion,
                            Orden = r.OperacionProcesoOrden
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / GetAll", exception);
            }
        }

        public static OperacionProcesoBusiness[] GetByProcesoCentroTrabajo(int procesoCentroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesProcesoSet
                        where r.ProcesoCentroTrabajoId == procesoCentroTrabajoId
                        orderby r.ProcesoCentroTrabajoId, r.OperacionProcesoOrden
                        select new OperacionProcesoBusiness
                        {
                            Id = r.OperacionProcesoId,
                            OperacionId = r.OperacionId,
                            ProcesoId = r.ProcesoId,
                            ProcesoCentroTrabajoId = r.ProcesoCentroTrabajoId,
                            Temperatura = r.OperacionProcesoTemperatura,
                            Ph = r.OperacionProcesoPh,
                            TiempoMinimo = r.OperacionProcesoTiempoMinimo,
                            TiempoMaximo = r.OperacionProcesoTiempoMaximo,
                            TiempoEstandar = r.OperacionProcesoTiempoEstandar,
                            RelacionBano = r.OperacionProcesoRelacion,
                            Orden = r.OperacionProcesoOrden
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.Proceso = ProcesoBusiness.Get(model.ProcesoId);
                        model.ProcesoCentroTrabajo = ProcesoCentroTrabajoBusiness.Get(model.ProcesoCentroTrabajoId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}