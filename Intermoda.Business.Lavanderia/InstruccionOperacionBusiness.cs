using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class InstruccionOperacionBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties
        
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int OperacionProcesoId { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public decimal TiempoMinimo { get; set; }

        [DataMember]
        public decimal TiempoMaximo { get; set; }

        [DataMember]
        public decimal? TiempoEstandar { get; set; }

        [DataMember]
        public int? Temperatura { get; set; }

        [DataMember]
        public int Orden { get; set; }

        //

        [DataMember]
        public OperacionProcesoBusiness OperacionProceso { get; private set; }

        #endregion

        #region Methods

        public static InstruccionOperacionBusiness Insert(InstruccionOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new InstruccionesOperacion
                    {
                        OperacionProcesoId = model.OperacionProcesoId,
                        InstruccionOperacionDescripcion = model.Descripcion,
                        InstruccionOperacionTiempoMinimo = model.TiempoMinimo,
                        InstruccionOperacionTiempoMaximo = model.TiempoMaximo,
                        InstruccionOperacionTiempoEstandar = model.TiempoEstandar,
                        InstruccionOperacionTemperatura = model.Temperatura,
                        InstruccionOperacionOrden = model.Orden
                    };
                    _context.InstruccionesOperacionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.InstruccionOperacionId;
                    model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacionBusiness / Insert", exception);
            }
        }

        public static InstruccionOperacionBusiness Update(InstruccionOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.InstruccionesOperacionSet
                               where r.InstruccionOperacionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OperacionProcesoId = model.OperacionProcesoId;
                        reg.InstruccionOperacionDescripcion = model.Descripcion;
                        reg.InstruccionOperacionTiempoMinimo = model.TiempoMinimo;
                        reg.InstruccionOperacionTiempoMaximo = model.TiempoMaximo;
                        reg.InstruccionOperacionTiempoEstandar = model.TiempoEstandar;
                        reg.InstruccionOperacionTemperatura = model.Temperatura;
                        reg.InstruccionOperacionOrden = model.Orden;

                        _context.SaveChanges();

                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacionBusiness / Update", exception);
            }
        }

        public static void Delete(InstruccionOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.InstruccionesOperacionSet
                               where r.InstruccionOperacionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.InstruccionesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int instruccionOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.InstruccionesOperacionSet
                               where r.InstruccionOperacionId == instruccionOperacionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.InstruccionesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionOperacion con Id: {instruccionOperacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacionBusiness / Delete (id)", exception);
            }
        }

        public static InstruccionOperacionBusiness Get(int instruccionOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.InstruccionesOperacionSet
                        where r.InstruccionOperacionId == instruccionOperacionId
                        select new InstruccionOperacionBusiness
                        {
                            Id = r.InstruccionOperacionId,
                            OperacionProcesoId = r.OperacionProcesoId,
                            Descripcion = r.InstruccionOperacionDescripcion,
                            TiempoMinimo = r.InstruccionOperacionTiempoMinimo,
                            TiempoMaximo = r.InstruccionOperacionTiempoMaximo,
                            TiempoEstandar = r.InstruccionOperacionTiempoEstandar,
                            Temperatura = r.InstruccionOperacionTemperatura,
                            Orden = r.InstruccionOperacionOrden
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InstruccionOperacion con Id: {instruccionOperacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacionBusiness / Get", exception);
            }
        }

        public static InstruccionOperacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.InstruccionesOperacionSet
                            select new InstruccionOperacionBusiness
                            {
                                Id = r.InstruccionOperacionId,
                                OperacionProcesoId = r.OperacionProcesoId,
                                Descripcion = r.InstruccionOperacionDescripcion,
                                TiempoMinimo = r.InstruccionOperacionTiempoMinimo,
                                TiempoMaximo = r.InstruccionOperacionTiempoMaximo,
                                TiempoEstandar = r.InstruccionOperacionTiempoEstandar,
                                Temperatura = r.InstruccionOperacionTemperatura,
                                Orden = r.InstruccionOperacionOrden
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
                throw new Exception("InstruccionOperacionBusiness / GetAll", exception);
            }
        }

        public static InstruccionOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.InstruccionesOperacionSet
                                 where r.OperacionProcesoId == operacionProcesoId
                                 orderby r.OperacionProcesoId, r.InstruccionOperacionOrden
                                 select new InstruccionOperacionBusiness
                                 {
                                     Id = r.InstruccionOperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     Descripcion = r.InstruccionOperacionDescripcion,
                                     TiempoMinimo = r.InstruccionOperacionTiempoMinimo,
                                     TiempoMaximo = r.InstruccionOperacionTiempoMaximo,
                                     TiempoEstandar = r.InstruccionOperacionTiempoEstandar,
                                     Temperatura = r.InstruccionOperacionTemperatura,
                                     Orden = r.InstruccionOperacionOrden
                                 }).ToArray();
                    var operacionProceso = OperacionProcesoBusiness.Get(operacionProcesoId);
                    foreach (var model in lista)
                    {
                        model.OperacionProceso = operacionProceso;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}