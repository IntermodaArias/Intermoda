using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ObservacionPredefinidaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public int? Posicion { get; set; }

        //

        [DataMember]
        public OperacionBusiness Operacion { get; private set; }

        #endregion

        #region Methods

        public static ObservacionPredefinidaBusiness Insert(ObservacionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new ObservacionesPreDefinidas()
                    {
                        ObservacionesOperacionPdDescripcion = model.Descripcion,
                        ObservacionOperacionPdId = model.OperacionId,
                        ObservacionesOperacionPdOrden = model.Orden,
                        ObservacionesOperacionPdPosicion = model.Posicion
                    };
                    _context.ObservacionesPreDefinidasSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ObservacionesOperacionPdId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / Insert", exception);
            }
        }

        public static ObservacionPredefinidaBusiness Update(ObservacionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ObservacionesPreDefinidasSet
                               where r.ObservacionOperacionPdId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ObservacionesOperacionPdDescripcion = model.Descripcion;
                        reg.ObservacionesOperacionPdId = model.OperacionId;
                        reg.ObservacionesOperacionPdOrden = model.Orden;
                        reg.ObservacionesOperacionPdPosicion = model.Posicion;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionPredefinida con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / Update", exception);
            }
        }

        public static void Delete(ObservacionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ObservacionesPreDefinidasSet
                               where r.ObservacionesOperacionPdId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ObservacionesPreDefinidasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionPredefinida con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int observacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ObservacionesPreDefinidasSet
                               where r.ObservacionesOperacionPdId == observacionPredefinidaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ObservacionesPreDefinidasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionPredefinida con Id: {observacionPredefinidaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / Delete (id)", exception);
            }
        }

        public static ObservacionPredefinidaBusiness Get(int observacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ObservacionesPreDefinidasSet
                        where r.ObservacionesOperacionPdId == observacionPredefinidaId
                        select new ObservacionPredefinidaBusiness
                        {
                            Id = r.ObservacionesOperacionPdId,
                            Descripcion = r.ObservacionesOperacionPdDescripcion,
                            OperacionId = r.ObservacionOperacionPdId,
                            Orden = r.ObservacionesOperacionPdOrden,
                            Posicion = r.ObservacionesOperacionPdPosicion
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ObservacionPredefinida con Id: {observacionPredefinidaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / Get", exception);
            }
        }

        public static ObservacionPredefinidaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ObservacionesPreDefinidasSet
                        select new ObservacionPredefinidaBusiness
                        {
                            Id = r.ObservacionesOperacionPdId,
                            Descripcion = r.ObservacionesOperacionPdDescripcion,
                            OperacionId = r.ObservacionOperacionPdId,
                            Orden = r.ObservacionesOperacionPdOrden,
                            Posicion = r.ObservacionesOperacionPdPosicion
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / GetAll", exception);
            }
        }

        public static ObservacionPredefinidaBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ObservacionesPreDefinidasSet
                        where r.ObservacionOperacionPdId == operacionId
                        select new ObservacionPredefinidaBusiness
                        {
                            Id = r.ObservacionesOperacionPdId,
                            Descripcion = r.ObservacionesOperacionPdDescripcion,
                            OperacionId = r.ObservacionOperacionPdId,
                            Orden = r.ObservacionesOperacionPdOrden,
                            Posicion = r.ObservacionesOperacionPdPosicion
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinidaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}