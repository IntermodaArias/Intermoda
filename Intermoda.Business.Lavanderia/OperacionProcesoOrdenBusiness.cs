using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class OperacionProcesoOrdenBusiness
    {
        private static LavanderiaEntities _context;

        private const short CompaniaCodigo = 1;

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

        #endregion

        #region Methods

        public static OperacionProcesoOrdenBusiness Insert(OperacionProcesoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OperacionesProcesoOrden()
                    {
                        OperacionesProcesoOrdenOperacionId = model.OperacionId,
                        OperacionesProcesoOrdenProcesoId = model.ProcesoId,
                        OperacionesProcesoOrdenProcesoCentroTrabajoId = model.ProcesoCentroTrabajoId,
                        OperacionesProcesoOrdenTemperatura = model.Temperatura,
                        OperacionesProcesoOrdenPh = model.Ph,
                        OperacionesProcesoOrdenTiempoMinimo = model.TiempoMinimo,
                        OperacionesProcesoOrdenTiempoMaximo = model.TiempoMaximo,
                        OperacionesProcesoOrdenTiempoEstandar = model.TiempoEstandar,
                        OperacionesProcesoOrdenRelacion = model.RelacionBano,
                        OperacionesProcesoOrden_Orden = model.Orden
                    };
                    _context.OperacionesProcesoOrdenSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OperacionesProcesoOrdenId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoOrdenBusiness / Insert", exception);
            }
        }

        public static OperacionProcesoOrdenBusiness Update(OperacionProcesoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesProcesoOrdenSet
                               where r.OperacionesProcesoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OperacionesProcesoOrdenOperacionId = model.OperacionId;
                        reg.OperacionesProcesoOrdenProcesoId = model.ProcesoId;
                        reg.OperacionesProcesoOrdenProcesoCentroTrabajoId = model.ProcesoCentroTrabajoId;
                        reg.OperacionesProcesoOrdenTemperatura = model.Temperatura;
                        reg.OperacionesProcesoOrdenPh = model.Ph;
                        reg.OperacionesProcesoOrdenTiempoMinimo = model.TiempoMinimo;
                        reg.OperacionesProcesoOrdenTiempoMaximo = model.TiempoMaximo;
                        reg.OperacionesProcesoOrdenTiempoEstandar = model.TiempoEstandar;
                        reg.OperacionesProcesoOrdenRelacion = model.RelacionBano;
                        reg.OperacionesProcesoOrden_Orden = model.Orden;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProcesoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoOrdenBusiness / Update", exception);
            }
        }

        public static void Delete(OperacionProcesoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesProcesoOrdenSet
                               where r.OperacionesProcesoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesProcesoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProcesoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoOrdenBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int operacionProcesoOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesProcesoOrdenSet
                               where r.OperacionesProcesoOrdenId == operacionProcesoOrdenId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesProcesoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProcesoOrden con Id: {operacionProcesoOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoOrdenBusiness / Delete (id)", exception);
            }
        }

        public static OperacionProcesoOrdenBusiness Get(int operacionProcesoOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesProcesoOrdenSet
                                 where r.OperacionesProcesoOrdenId == operacionProcesoOrdenId
                                 select new OperacionProcesoOrdenBusiness
                                 {
                                     Id = r.OperacionesProcesoOrdenId,
                                     OperacionId = r.OperacionesProcesoOrdenOperacionId,
                                     ProcesoId = r.OperacionesProcesoOrdenProcesoId,
                                     ProcesoCentroTrabajoId = r.OperacionesProcesoOrdenProcesoCentroTrabajoId,
                                     Temperatura = r.OperacionesProcesoOrdenTemperatura,
                                     Ph = r.OperacionesProcesoOrdenPh,
                                     TiempoMinimo = r.OperacionesProcesoOrdenTiempoMinimo,
                                     TiempoMaximo = r.OperacionesProcesoOrdenTiempoMaximo,
                                     TiempoEstandar = r.OperacionesProcesoOrdenTiempoEstandar,
                                     RelacionBano = r.OperacionesProcesoOrdenRelacion,
                                     Orden = r.OperacionesProcesoOrden_Orden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionProcesoOrden con Id: {operacionProcesoOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoOrdenBusiness / Get", exception);
            }
        }

        public static OperacionProcesoOrdenBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.OperacionesProcesoOrdenSet
                            select new OperacionProcesoOrdenBusiness
                            {
                                Id = r.OperacionesProcesoOrdenId,
                                OperacionId = r.OperacionesProcesoOrdenOperacionId,
                                ProcesoId = r.OperacionesProcesoOrdenProcesoId,
                                ProcesoCentroTrabajoId = r.OperacionesProcesoOrdenProcesoCentroTrabajoId,
                                Temperatura = r.OperacionesProcesoOrdenTemperatura,
                                Ph = r.OperacionesProcesoOrdenPh,
                                TiempoMinimo = r.OperacionesProcesoOrdenTiempoMinimo,
                                TiempoMaximo = r.OperacionesProcesoOrdenTiempoMaximo,
                                TiempoEstandar = r.OperacionesProcesoOrdenTiempoEstandar,
                                RelacionBano = r.OperacionesProcesoOrdenRelacion,
                                Orden = r.OperacionesProcesoOrden_Orden
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProcesoOrdenBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}