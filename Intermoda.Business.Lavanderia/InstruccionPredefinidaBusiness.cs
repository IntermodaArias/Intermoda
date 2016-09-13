using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class InstruccionPredefinidaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int  OperacionPredefinidaId { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public decimal TiempoMinimo { get; set; }

        [DataMember]
        public decimal TiempoMaximo { get; set; }

        [DataMember]
        public int? Temperatura { get; set; }

        [DataMember]
        public OperacionPredefinidaBusiness OpeacionPredefinida { get; private set; }

        #endregion

        #region Methods

        public static InstruccionPredefinidaBusiness Insert(InstruccionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new InstruccionesPreDefinidas
                    {
                        InstruccionPreDefinidaDescripcion = model.Descripcion,
                        OperacionPreDefinidaId = model.OperacionPredefinidaId,
                        InstruccionPreDefinidaOrden = model.Orden,
                        InstruccionPreDefinidaTiempoMinimo = model.TiempoMinimo,
                        InstruccionPreDefinidaTiempoMaximo = model.TiempoMaximo,
                        InstruccionPreDefinidaTemperatura = model.Temperatura

                    };
                    _context.InstruccionesPreDefinidasSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.InstruccionPreDefinidaId;
                    model.OpeacionPredefinida = OperacionPredefinidaBusiness.Get(model.OperacionPredefinidaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / Insert", exception);
            }
        }

        public static InstruccionPredefinidaBusiness Update(InstruccionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.InstruccionesPreDefinidasSet
                        where r.InstruccionPreDefinidaId == model.Id
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.InstruccionPreDefinidaDescripcion = model.Descripcion;
                        reg.OperacionPreDefinidaId = model.OperacionPredefinidaId;
                        reg.InstruccionPreDefinidaOrden = model.Orden;
                        reg.InstruccionPreDefinidaTiempoMinimo = model.TiempoMinimo;
                        reg.InstruccionPreDefinidaTiempoMaximo = model.TiempoMaximo;
                        reg.InstruccionPreDefinidaTemperatura = model.Temperatura;
                        _context.SaveChanges();

                        model.OpeacionPredefinida = OperacionPredefinidaBusiness.Get(model.OperacionPredefinidaId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionPredefinida con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / Update", exception);
            }
        }

        public static void Delete(InstruccionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.InstruccionesPreDefinidasSet
                        where r.InstruccionPreDefinidaId == model.Id
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.InstruccionesPreDefinidasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionPredefinida con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int operacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.InstruccionesPreDefinidasSet
                        where r.InstruccionPreDefinidaId == operacionPredefinidaId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.InstruccionesPreDefinidasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionPredefinida con Id: {operacionPredefinidaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / Delete (id)", exception);
            }
        }

        public static InstruccionPredefinidaBusiness Get(int operacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.InstruccionesPreDefinidasSet
                                 where r.InstruccionPreDefinidaId == operacionPredefinidaId
                                 select new InstruccionPredefinidaBusiness
                                 {
                                     Id = r.InstruccionPreDefinidaId,
                                     OperacionPredefinidaId = r.OperacionPreDefinidaId,
                                     Descripcion = r.InstruccionPreDefinidaDescripcion,
                                     Orden = r.InstruccionPreDefinidaOrden,
                                     TiempoMinimo = r.InstruccionPreDefinidaTiempoMinimo,
                                     TiempoMaximo = r.InstruccionPreDefinidaTiempoMaximo,
                                     Temperatura = r.InstruccionPreDefinidaTemperatura
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.OpeacionPredefinida = OperacionPredefinidaBusiness.Get(model.OperacionPredefinidaId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionPredefinida con Id: {operacionPredefinidaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / Get", exception);
            }
        }

        public static InstruccionPredefinidaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.InstruccionesPreDefinidasSet
                                 orderby r.OperacionPreDefinidaId, r.InstruccionPreDefinidaOrden
                            select new InstruccionPredefinidaBusiness
                            {
                                Id = r.InstruccionPreDefinidaId,
                                OperacionPredefinidaId = r.OperacionPreDefinidaId,
                                Descripcion = r.InstruccionPreDefinidaDescripcion,
                                Orden = r.InstruccionPreDefinidaOrden,
                                TiempoMinimo = r.InstruccionPreDefinidaTiempoMinimo,
                                TiempoMaximo = r.InstruccionPreDefinidaTiempoMaximo,
                                Temperatura = r.InstruccionPreDefinidaTemperatura
                            }).ToArray();
                    foreach (var reg in lista)
                    {
                        reg.OpeacionPredefinida = OperacionPredefinidaBusiness.Get(reg.OperacionPredefinidaId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / GetAll", exception);
            }
        }

        public static InstruccionPredefinidaBusiness[] GetByOperacionPredefinida(int operacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.InstruccionesPreDefinidasSet
                        where r.OperacionPreDefinidaId == operacionPredefinidaId
                        orderby r.InstruccionPreDefinidaId, r.InstruccionPreDefinidaOrden
                        select new InstruccionPredefinidaBusiness
                        {
                            Id = r.InstruccionPreDefinidaId,
                            OperacionPredefinidaId = r.OperacionPreDefinidaId,
                            Descripcion = r.InstruccionPreDefinidaDescripcion,
                            Orden = r.InstruccionPreDefinidaOrden,
                            TiempoMinimo = r.InstruccionPreDefinidaTiempoMinimo,
                            TiempoMaximo = r.InstruccionPreDefinidaTiempoMaximo,
                            Temperatura = r.InstruccionPreDefinidaTemperatura
                        }).ToArray();
                    
                    foreach (var reg in lista)
                    {
                        reg.OpeacionPredefinida = OperacionPredefinidaBusiness.Get(reg.OperacionPredefinidaId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinidaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}