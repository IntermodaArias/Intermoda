using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class CentroTrabajoOpcionLavadoOrdenBusiness
    {
        private static LavanderiaEntities _context;

        private const short CompaniaCodigo = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int CentroTrabajoId { get; set; }

        [DataMember]
        public int OpcionLavadoId { get; set; }

        [DataMember]
        public int Orden { get; set; }

        #endregion

        #region Methods

        public static CentroTrabajoOpcionLavadoOrdenBusiness Insert(CentroTrabajoOpcionLavadoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new CentrosTrabajoOpcionLavadoOrden()
                    {
                        CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId = model.CentroTrabajoId,
                        CentrosTrabajoOpcionLavadoOrdenOpcionLavadoId = model.OpcionLavadoId,
                        CentrosTrabajoOpcionLavadoOrden_Orden = model.Orden
                    };
                    _context.CentrosTrabajoOpcionLavadoOrdenSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.CentrosTrabajoOpcionLavadoOrdenId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionLavadoOrdenBusiness / Insert", exception);
            }
        }

        public static CentroTrabajoOpcionLavadoOrdenBusiness Update(CentroTrabajoOpcionLavadoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajoOpcionLavadoOrdenSet
                               where r.CentrosTrabajoOpcionLavadoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId = model.CentroTrabajoId;
                        reg.CentrosTrabajoOpcionLavadoOrdenOpcionLavadoId = model.OpcionLavadoId;
                        reg.CentrosTrabajoOpcionLavadoOrden_Orden = model.Orden;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcionLavadoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionLavadoOrdenBusiness / Update", exception);
            }
        }

        public static void Delete(CentroTrabajoOpcionLavadoOrdenBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajoOpcionLavadoOrdenSet
                               where r.CentrosTrabajoOpcionLavadoOrdenId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentrosTrabajoOpcionLavadoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcionLavadoOrden con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionLavadoOrdenBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int centroTrabajoOpcionLavadorOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CentrosTrabajoOpcionLavadoOrdenSet
                               where r.CentrosTrabajoOpcionLavadoOrdenId == centroTrabajoOpcionLavadorOrdenId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CentrosTrabajoOpcionLavadoOrdenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcionLavadoOrden con Id: {centroTrabajoOpcionLavadorOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionLavadoOrdenBusiness / Delete (id)", exception);
            }
        }

        public static CentroTrabajoOpcionLavadoOrdenBusiness Get(int centroTrabajoOpcionLavadorOrdenId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CentrosTrabajoOpcionLavadoOrdenSet
                                 where r.CentrosTrabajoOpcionLavadoOrdenId == centroTrabajoOpcionLavadorOrdenId
                                 select new CentroTrabajoOpcionLavadoOrdenBusiness
                                 {
                                     Id = r.CentrosTrabajoOpcionLavadoOrdenId,
                                     CentroTrabajoId = r.CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId,
                                     OpcionLavadoId = r.CentrosTrabajoOpcionLavadoOrdenOpcionLavadoId,
                                     Orden = r.CentrosTrabajoOpcionLavadoOrden_Orden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CentroTrabajoOpcionLavadoOrden con Id: {centroTrabajoOpcionLavadorOrdenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionLavadoOrdenBusiness / Get", exception);
            }
        }

        public static CentroTrabajoOpcionLavadoOrdenBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.CentrosTrabajoOpcionLavadoOrdenSet
                            select new CentroTrabajoOpcionLavadoOrdenBusiness
                            {
                                Id = r.CentrosTrabajoOpcionLavadoOrdenId,
                                CentroTrabajoId = r.CentrosTrabajoOpcionLavadoOrdenCentroTrabajoId,
                                OpcionLavadoId = r.CentrosTrabajoOpcionLavadoOrdenOpcionLavadoId,
                                Orden = r.CentrosTrabajoOpcionLavadoOrden_Orden
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcionLavadoOrdenBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}