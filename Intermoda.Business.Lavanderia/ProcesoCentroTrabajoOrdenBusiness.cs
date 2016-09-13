using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ProcesoCentroTrabajoOrdenBusiness
    {
        private static LavanderiaEntities _context;

        private const short CompaniaCodigo = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ProcesoId { get; set; }

        [DataMember]
        public int CentroTrabajoId { get; set; }

        [DataMember]
        public int CentroTrabajoOpcionLavadoId { get; set; }

        [DataMember]
        public int Orden { get; set; }

        #endregion

        #region Methods

        public static ProcesoCentroTrabajoOrdenBusiness Insert(ProcesoCentroTrabajoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new ProcesosCentroTrabajoOrden()
                    {
                        ProcesosCentroTrabajoOrdenProcesoId = model.ProcesoId,
                        ProcesosCentroTrabajoOrdenCentroTrabajoId = model.CentroTrabajoId,
                        ProcesosCentroTrabajoOrdenCentrosTrabajoOpcionLavadoId = model.CentroTrabajoOpcionLavadoId,
                        ProcesosCentroTrabajoOrden_Orden = model.Orden
                    };
                    _context.ProcesosCentroTrabajoOrdenSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ProcesosCentroTrabajoOrdenId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoOrdenBusiness / Insert", exception);
            }
        }

        public static ProcesoCentroTrabajoOrdenBusiness Update(ProcesoCentroTrabajoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosCentroTrabajoOrdenSet
                               where r.ProcesosCentroTrabajoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ProcesosCentroTrabajoOrdenProcesoId = model.ProcesoId;
                        reg.ProcesosCentroTrabajoOrdenCentroTrabajoId = model.CentroTrabajoId;
                        reg.ProcesosCentroTrabajoOrdenCentrosTrabajoOpcionLavadoId = model.CentroTrabajoOpcionLavadoId;
                        reg.ProcesosCentroTrabajoOrden_Orden = model.Orden;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoOrdenBusiness / Update", exception);
            }
        }

        public static void Delete(ProcesoCentroTrabajoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosCentroTrabajoOrdenSet
                               where r.ProcesosCentroTrabajoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ProcesosCentroTrabajoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoOrdenBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int procesoCentroTrabajoOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ProcesosCentroTrabajoOrdenSet
                               where r.ProcesosCentroTrabajoOrdenId == procesoCentroTrabajoOrdenId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ProcesosCentroTrabajoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajoOrden con Id: {procesoCentroTrabajoOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoOrdenBusiness / Delete (id)", exception);
            }
        }

        public static ProcesoCentroTrabajoOrdenBusiness Get(int procesoCentroTrabajoOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ProcesosCentroTrabajoOrdenSet
                                 where r.ProcesosCentroTrabajoOrdenId == procesoCentroTrabajoOrdenId
                                 select new ProcesoCentroTrabajoOrdenBusiness
                                 {
                                     Id = r.ProcesosCentroTrabajoOrdenId,
                                     ProcesoId = r.ProcesosCentroTrabajoOrdenProcesoId,
                                     CentroTrabajoId = r.ProcesosCentroTrabajoOrdenCentroTrabajoId,
                                     CentroTrabajoOpcionLavadoId = r.ProcesosCentroTrabajoOrdenCentrosTrabajoOpcionLavadoId,
                                     Orden = r.ProcesosCentroTrabajoOrden_Orden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProcesoCentroTrabajoOrden con Id: {procesoCentroTrabajoOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoOrdenBusiness / Get", exception);
            }
        }

        public static ProcesoCentroTrabajoOrdenBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.ProcesosCentroTrabajoOrdenSet
                            select new ProcesoCentroTrabajoOrdenBusiness
                            {
                                Id = r.ProcesosCentroTrabajoOrdenId,
                                ProcesoId = r.ProcesosCentroTrabajoOrdenProcesoId,
                                CentroTrabajoId = r.ProcesosCentroTrabajoOrdenCentroTrabajoId,
                                CentroTrabajoOpcionLavadoId = r.ProcesosCentroTrabajoOrdenCentrosTrabajoOpcionLavadoId,
                                Orden = r.ProcesosCentroTrabajoOrden_Orden
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajoOrdenBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}