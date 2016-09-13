using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class IngredientePredefinidoBusiness
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
        public string ClaseId { get; set; }
        [DataMember]
        public string SubClaseId { get; set; }
        [DataMember]
        public decimal? Porcentaje { get; set; }
        [DataMember]
        public int? Orden { get; set; }
        [DataMember]
        public int? InstruccionPredefinidaId { get; set; }

        //

        [DataMember]
        public CatalogoBusiness Catalogo { get; private set; }

        [DataMember]
        public OperacionBusiness Operacion { get; private set; }

        [DataMember]
        public InstruccionPredefinidaBusiness InstruccionPredefinida { get; private set; }

        [DataMember]
        public ClaseBusiness Clase { get; private set; }

        [DataMember]
        public SubClaseBusiness SubClase { get; private set; }

        #endregion

        #region Methods

        public static IngredientePredefinidoBusiness Insert(IngredientePredefinidoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new IngredientesPreDefinidos
                    {
                        IngredienteId = model.IngredienteId,
                        OperacionId = model.OperacionId,
                        IngredientePreDefinidoClaseId = model.ClaseId,
                        IngredientePreDefinidoSubClaseId = model.SubClaseId,
                        IngredientePreDefinidoPorcentaje = model.Porcentaje,
                        IngredientePreDefinidoOrden = model.Orden,
                        IngredientePreDefinidoInstruccionesOperacionId = model.InstruccionPredefinidaId
                    };
                    _context.IngredientesPreDefinidosSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.IngredientePreDefinidoId;

                    model.Catalogo = CatalogoBusiness.Get(model.IngredienteId);
                    model.Operacion = OperacionBusiness.Get(model.OperacionId);
                    model.InstruccionPredefinida = model.InstruccionPredefinidaId != null
                        ? InstruccionPredefinidaBusiness.Get(model.InstruccionPredefinidaId.Value)
                        : null;
                    model.Clase = ClaseBusiness.Get(model.ClaseId);
                    model.SubClase = SubClaseBusiness.Get(model.SubClaseId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / Insert", exception);
            }
        }

        public static IngredientePredefinidoBusiness Update(IngredientePredefinidoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.IngredientesPreDefinidosSet
                        where r.IngredientePreDefinidoId == model.Id
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.IngredienteId = model.IngredienteId;
                        reg.OperacionId = model.OperacionId;
                        reg.IngredientePreDefinidoClaseId = model.ClaseId;
                        reg.IngredientePreDefinidoSubClaseId = model.SubClaseId;
                        reg.IngredientePreDefinidoPorcentaje = model.Porcentaje;
                        reg.IngredientePreDefinidoOrden = model.Orden;
                        reg.IngredientePreDefinidoInstruccionesOperacionId = model.InstruccionPredefinidaId;

                        _context.SaveChanges();

                        model.Catalogo = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.InstruccionPredefinida = model.InstruccionPredefinidaId != null
                            ? InstruccionPredefinidaBusiness.Get(model.InstruccionPredefinidaId.Value)
                            : null;
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredientePreDefinidos con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / Update", exception);
            }
        }

        public static void Delete(IngredientePredefinidoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.IngredientesPreDefinidosSet
                        where r.IngredientePreDefinidoId == model.Id
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.IngredientesPreDefinidosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredientePreDefinidos con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int ingredientePredefinidoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.IngredientesPreDefinidosSet
                        where r.IngredientePreDefinidoId == ingredientePredefinidoId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.IngredientesPreDefinidosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredientePreDefinidos con Id: {ingredientePredefinidoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / Delete (id)", exception);
            }
        }

        public static IngredientePredefinidoBusiness Get(int ingredientePredefinidoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.IngredientesPreDefinidosSet
                        where r.IngredientePreDefinidoId == ingredientePredefinidoId
                        select new IngredientePredefinidoBusiness
                        {
                            Id = r.IngredientePreDefinidoId,
                            IngredienteId = r.IngredienteId,
                            ClaseId = r.IngredientePreDefinidoClaseId,
                            SubClaseId = r.IngredientePreDefinidoSubClaseId,
                            Porcentaje = r.IngredientePreDefinidoPorcentaje,
                            Orden = r.IngredientePreDefinidoOrden,
                            InstruccionPredefinidaId = r.IngredientePreDefinidoInstruccionesOperacionId
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Catalogo = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.InstruccionPredefinida = model.InstruccionPredefinidaId != null
                            ? InstruccionPredefinidaBusiness.Get(model.InstruccionPredefinidaId.Value)
                            : null;
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de IngredientePreDefinidos con Id: {ingredientePredefinidoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / Get", exception);
            }
        }

        public static IngredientePredefinidoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesPreDefinidosSet
                        select new IngredientePredefinidoBusiness
                        {
                            Id = r.IngredientePreDefinidoId,
                            IngredienteId = r.IngredienteId,
                            ClaseId = r.IngredientePreDefinidoClaseId,
                            SubClaseId = r.IngredientePreDefinidoSubClaseId,
                            Porcentaje = r.IngredientePreDefinidoPorcentaje,
                            Orden = r.IngredientePreDefinidoOrden,
                            InstruccionPredefinidaId = r.IngredientePreDefinidoInstruccionesOperacionId
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Catalogo = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.InstruccionPredefinida = model.InstruccionPredefinidaId != null
                            ? InstruccionPredefinidaBusiness.Get(model.InstruccionPredefinidaId.Value)
                            : null;
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / GetAll", exception);
            }
        }

        public static IngredientePredefinidoBusiness[] GetByInstruccionPredefinida(int instruccionPredefinidaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.IngredientesPreDefinidosSet
                                 where r.IngredientePreDefinidoInstruccionesOperacionId == instruccionPredefinidaId
                        select new IngredientePredefinidoBusiness
                        {
                            Id = r.IngredientePreDefinidoId,
                            IngredienteId = r.IngredienteId,
                            ClaseId = r.IngredientePreDefinidoClaseId,
                            SubClaseId = r.IngredientePreDefinidoSubClaseId,
                            Porcentaje = r.IngredientePreDefinidoPorcentaje,
                            Orden = r.IngredientePreDefinidoOrden,
                            InstruccionPredefinidaId = r.IngredientePreDefinidoInstruccionesOperacionId
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Catalogo = CatalogoBusiness.Get(model.IngredienteId);
                        model.Operacion = OperacionBusiness.Get(model.OperacionId);
                        model.InstruccionPredefinida = model.InstruccionPredefinidaId != null
                            ? InstruccionPredefinidaBusiness.Get(model.InstruccionPredefinidaId.Value)
                            : null;
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinidoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}