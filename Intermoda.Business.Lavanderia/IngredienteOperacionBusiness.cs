using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class IngredienteOperacionBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int IngredienteId { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int OperacionProcesoId { get; set; }

        [DataMember]
        public int? InstruccionOperacionId { get; set; }

        [DataMember]
        public string ClaseId { get; set; }

        [DataMember]
        public string SubClaseId { get; set; }

        [DataMember]
        public decimal? Porcentaje { get; set; }

        [DataMember]
        public int? Orden { get; set; }

        //

        [DataMember]
        public CatalogoBusiness Ingrediente { get; private set; }

        [DataMember]
        public OperacionBusiness Operacion { get; private set; }

        [DataMember]
        public OperacionProcesoBusiness OperacionProceso { get; private set; }

        [DataMember]
        public InstruccionOperacionBusiness InstruccionOperacion { get; private set; }

        [DataMember]
        public ClaseBusiness Clase { get; private set; }

        [DataMember]
        public SubClaseBusiness SubClase { get; private set; }

        #endregion

        #region Methods

        public static IngredienteOperacionBusiness Insert(IngredienteOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new IngredientesOperacion
                    {
                        IngredienteId = model.IngredienteId,
                        OperacionId = model.OperacionId,
                        OperacionProcesoId = model.OperacionProcesoId,
                        IngredienteOperacionPorcentaje = model.Porcentaje,
                        IngredienteOperacionClaseId = model.ClaseId,
                        IngredienteOperacionSubClaseId = model.SubClaseId,
                        IngredienteInstruccionesOperacionId = model.InstruccionOperacionId,
                        IngredienteOperacionOrden = model.Orden
                    };
                    _context.IngredientesOperacionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.IngredienteOperacionId;
                    model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                    model.Operacion = OperacionBusiness.Get(model.OperacionId);
                    model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                    model.Clase = ClaseBusiness.Get(model.ClaseId);
                    model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                    model.InstruccionOperacion = model.InstruccionOperacionId != null
                        ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                        : null;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / Insert", exception);
            }
        }

        public static IngredienteOperacionBusiness Update(IngredienteOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.IngredientesOperacionSet
                               where r.IngredienteOperacionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.IngredienteId = model.IngredienteId;
                        reg.OperacionId = model.OperacionId;
                        reg.OperacionProcesoId = model.OperacionProcesoId;
                        reg.IngredienteOperacionPorcentaje = model.Porcentaje;
                        reg.IngredienteOperacionClaseId = model.ClaseId;
                        reg.IngredienteOperacionSubClaseId = model.SubClaseId;
                        reg.IngredienteInstruccionesOperacionId = model.InstruccionOperacionId;
                        reg.IngredienteOperacionOrden = model.Orden;

                        _context.SaveChanges();

                        model.Id = reg.IngredienteOperacionId;
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredienteOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / Update", exception);
            }
        }

        public static void Delete(IngredienteOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.IngredientesOperacionSet
                               where r.IngredienteOperacionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.IngredientesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredienteOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int ingredienteOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.IngredientesOperacionSet
                               where r.IngredienteOperacionId == ingredienteOperacionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.IngredientesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredienteOperacion con Id: {ingredienteOperacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / Delete (id)", exception);
            }
        }

        public static IngredienteOperacionBusiness Get(int ingredienteOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.IngredientesOperacionSet
                                 where r.IngredienteOperacionId == ingredienteOperacionId
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId =r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId=r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredienteOperacion con Id: {ingredienteOperacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / Get", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                        select new IngredienteOperacionBusiness
                        {
                            Id = r.IngredienteOperacionId,
                            IngredienteId = r.IngredienteId,
                            OperacionId = r.OperacionId,
                            OperacionProcesoId = r.OperacionProcesoId,
                            ClaseId = r.IngredienteOperacionClaseId,
                            SubClaseId = r.IngredienteOperacionSubClaseId,
                            InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                            Porcentaje = r.IngredienteOperacionPorcentaje,
                            Orden = r.IngredienteOperacionOrden
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetByIngrediente(int ingredienteId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                                 where r.IngredienteId == ingredienteId
                                 orderby r.IngredienteId, r.IngredienteOperacionOrden
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId = r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId = r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).ToArray();
                    var ingrediente = CatalogoBusiness.Get(ingredienteId);
                    foreach (var model in lista)
                    {
                        model.Ingrediente = ingrediente;
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                                 where r.OperacionId == operacionId
                                 orderby r.OperacionId, r.IngredienteOperacionOrden
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId = r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId = r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).ToArray();
                    var operacion = OperacionBusiness.Get(operacionId);
                    foreach (var model in lista)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = operacion;
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                                 where r.OperacionProcesoId == operacionProcesoId
                                 orderby r.OperacionProcesoId, r.IngredienteOperacionOrden
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId = r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId = r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).ToArray();
                    var operacionProceso = OperacionProcesoBusiness.Get(operacionProcesoId);
                    foreach (var model in lista)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = operacionProceso;
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetByClase(string claseId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                                 where r.IngredienteOperacionClaseId == claseId
                                 orderby r.IngredienteOperacionClaseId, r.IngredienteOperacionOrden
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId = r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId = r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).ToArray();
                    var clase = ClaseBusiness.Get(claseId);
                    foreach (var model in lista)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = clase;
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetBySubClase(string subClaseId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                                 where r.IngredienteOperacionSubClaseId == subClaseId
                                 orderby r.IngredienteOperacionSubClaseId, r.IngredienteOperacionOrden
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId = r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId = r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).ToArray();
                    var subClase = SubClaseBusiness.Get(subClaseId);
                    foreach (var model in lista)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = subClase;
                        model.InstruccionOperacion = model.InstruccionOperacionId != null
                            ? InstruccionOperacionBusiness.Get(model.InstruccionOperacionId.Value)
                            : null;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        public static IngredienteOperacionBusiness[] GetByInstruccionOperacion(int instruccionOperacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesOperacionSet
                                 where r.IngredienteInstruccionesOperacionId == instruccionOperacionId
                                 orderby r.IngredienteInstruccionesOperacionId, r.IngredienteOperacionOrden
                                 select new IngredienteOperacionBusiness
                                 {
                                     Id = r.IngredienteOperacionId,
                                     IngredienteId = r.IngredienteId,
                                     OperacionId = r.OperacionId,
                                     OperacionProcesoId = r.OperacionProcesoId,
                                     ClaseId = r.IngredienteOperacionClaseId,
                                     SubClaseId = r.IngredienteOperacionSubClaseId,
                                     InstruccionOperacionId = r.IngredienteInstruccionesOperacionId,
                                     Porcentaje = r.IngredienteOperacionPorcentaje,
                                     Orden = r.IngredienteOperacionOrden
                                 }).ToArray();
                    var instruccionOperacion = InstruccionOperacionBusiness.Get(instruccionOperacionId);
                    foreach (var model in lista)
                    {
                        model.Ingrediente = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.OperacionProceso = OperacionProcesoBusiness.Get(model.OperacionProcesoId);
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        model.InstruccionOperacion = instruccionOperacion;
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}