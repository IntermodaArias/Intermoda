using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class OperacionPredefinidaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int Temperatura { get; set; }

        [DataMember]
        public string Ph { get; set; }

        [DataMember]
        public decimal TiempoMinimo { get; set; }

        [DataMember]
        public decimal TiempoMaximo { get; set; }

        [DataMember]
        public int RelacionBano { get; set; }

        [DataMember]
        public int Secuencia { get; set; }


        [DataMember]
        public OperacionBusiness Operacion { get; private set; }

        #endregion

        #region Methods

        public static OperacionPredefinidaBusiness Insert(OperacionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OperacionesPreDefinidas
                    {
                        OperacionId = model.OperacionId,
                        OperacionPreDefinidaTemperatura = model.Temperatura,
                        OperacionPreDefinidaPh = model.Ph,
                        OperacionPreDefinidaTiempoMinimo = model.TiempoMinimo,
                        OperacionPreDefinidaTiempoMaximo = model.TiempoMaximo,
                        OperacionPreDefinidaRelacion = model.RelacionBano,
                        OperacionPreDefinidaOrden = model.Secuencia
                    };
                    _context.OperacionesPreDefinidasSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OperacionPreDefinidaId;
                    model.Operacion = OperacionBusiness.Get(model.OperacionId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / Insert", exception);
            }
        }

        public static OperacionPredefinidaBusiness Update(OperacionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesPreDefinidasSet
                               where r.OperacionPreDefinidaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OperacionId = model.OperacionId;
                        reg.OperacionPreDefinidaTemperatura = model.Temperatura;
                        reg.OperacionPreDefinidaPh = model.Ph;
                        reg.OperacionPreDefinidaTiempoMinimo = model.TiempoMinimo;
                        reg.OperacionPreDefinidaTiempoMaximo = model.TiempoMaximo;
                        reg.OperacionPreDefinidaRelacion = model.RelacionBano;
                        reg.OperacionPreDefinidaOrden = model.Secuencia;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionPredefinida con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / Update", exception);
            }
        }

        public static void Delete(OperacionPredefinidaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesPreDefinidasSet
                               where r.OperacionPreDefinidaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesPreDefinidasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionPredefinida con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int operacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesPreDefinidasSet
                               where r.OperacionPreDefinidaId == operacionPredefinidaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesPreDefinidasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionPredefinida con Id: {operacionPredefinidaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / Delete (id)", exception);
            }
        }

        public static OperacionPredefinidaBusiness Get(int operacionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesPreDefinidasSet
                                 where r.OperacionPreDefinidaId == operacionPredefinidaId
                                 select new OperacionPredefinidaBusiness
                                 {
                                     Id = r.OperacionPreDefinidaId,
                                     OperacionId = r.OperacionId,
                                     Temperatura = r.OperacionPreDefinidaTemperatura,
                                     Ph = r.OperacionPreDefinidaPh,
                                     TiempoMinimo = r.OperacionPreDefinidaTiempoMinimo,
                                     TiempoMaximo = r.OperacionPreDefinidaTiempoMaximo,
                                     RelacionBano = r.OperacionPreDefinidaRelacion,
                                     Secuencia = r.OperacionPreDefinidaOrden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Operacion = OperacionBusiness.GetSingle(model.OperacionId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OperacionPredefinida con Id: {operacionPredefinidaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / Get", exception);
            }
        }

        public static OperacionPredefinidaBusiness GetSingle(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesPreDefinidasSet
                                 where r.OperacionId == operacionId
                                 select new OperacionPredefinidaBusiness
                                 {
                                     Id = r.OperacionPreDefinidaId,
                                     OperacionId = r.OperacionId,
                                     Temperatura = r.OperacionPreDefinidaTemperatura,
                                     Ph = r.OperacionPreDefinidaPh,
                                     TiempoMinimo = r.OperacionPreDefinidaTiempoMinimo,
                                     TiempoMaximo = r.OperacionPreDefinidaTiempoMaximo,
                                     RelacionBano = r.OperacionPreDefinidaRelacion,
                                     Secuencia = r.OperacionPreDefinidaOrden
                                 }).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / Get", exception);
            }
        }

        public static OperacionPredefinidaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesPreDefinidasSet
                        select new OperacionPredefinidaBusiness
                        {
                            Id = r.OperacionPreDefinidaId,
                            OperacionId = r.OperacionId,
                            Temperatura = r.OperacionPreDefinidaTemperatura,
                            Ph = r.OperacionPreDefinidaPh,
                            TiempoMinimo = r.OperacionPreDefinidaTiempoMinimo,
                            TiempoMaximo = r.OperacionPreDefinidaTiempoMaximo,
                            RelacionBano = r.OperacionPreDefinidaRelacion,
                            Secuencia = r.OperacionPreDefinidaOrden
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Operacion = OperacionBusiness.GetSingle(model.OperacionId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinidaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}