using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ObservacionOperacionBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int OperacionProcesoId { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public int? Posicion { get; set; }

        //

        [DataMember]
        public OperacionProcesoBusiness OperacionProceso { get; set; }

        #endregion

        #region Methods

        public static ObservacionOperacionBusiness Insert(ObservacionOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new ObservacionesOperacion
                    {
                        ObservacionesOperacionDescripcion = model.Descripcion,
                        OperacionProcesoId = model.OperacionProcesoId,
                        ObservacionesOperacionOrden = model.Orden,
                        ObservacionesOperacionPosicion = model.Posicion
                    };
                    _context.ObservacionesOperacionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ObservacionesOperacionId;
                    model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / Insert", exception);
            }
        }

        public static ObservacionOperacionBusiness Update(ObservacionOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ObservacionesOperacionSet
                               where r.ObservacionesOperacionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ObservacionesOperacionDescripcion = model.Descripcion;
                        reg.OperacionProcesoId = model.OperacionProcesoId;
                        reg.ObservacionesOperacionOrden = model.Orden;
                        reg.ObservacionesOperacionPosicion = model.Posicion;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / Update", exception);
            }
        }

        public static void Delete(ObservacionOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ObservacionesOperacionSet
                               where r.ObservacionesOperacionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ObservacionesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int observacionOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ObservacionesOperacionSet
                               where r.ObservacionesOperacionId == observacionOperacionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ObservacionesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionOperacion con Id: {observacionOperacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / Delete (id)", exception);
            }
        }

        public static ObservacionOperacionBusiness Get(int observacionOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ObservacionesOperacionSet
                        where r.ObservacionesOperacionId == observacionOperacionId
                        select new ObservacionOperacionBusiness
                        {
                            Id = r.ObservacionesOperacionId,
                            OperacionProcesoId = r.OperacionProcesoId,
                            Descripcion = r.ObservacionesOperacionDescripcion,
                            Orden = r.ObservacionesOperacionOrden,
                            Posicion = r.ObservacionesOperacionPosicion
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionOperacion con Id: {observacionOperacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / Get", exception);
            }
        }

        public static ObservacionOperacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ObservacionesOperacionSet
                        select new ObservacionOperacionBusiness
                        {
                            Id = r.ObservacionesOperacionId,
                            OperacionProcesoId = r.OperacionProcesoId,
                            Descripcion = r.ObservacionesOperacionDescripcion,
                            Orden = r.ObservacionesOperacionOrden,
                            Posicion = r.ObservacionesOperacionPosicion
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / GetAll", exception);
            }
        }

        public static ObservacionOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ObservacionesOperacionSet
                                 where r.OperacionProcesoId == operacionProcesoId
                                 orderby r.OperacionProcesoId, r.ObservacionesOperacionOrden
                                 select new ObservacionOperacionBusiness
                                 {
                                     Id = r.ObservacionesOperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     Descripcion = r.ObservacionesOperacionDescripcion,
                                     Orden = r.ObservacionesOperacionOrden,
                                     Posicion = r.ObservacionesOperacionPosicion
                                 }).ToArray();
                    foreach (var model in lista)
                    {
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}