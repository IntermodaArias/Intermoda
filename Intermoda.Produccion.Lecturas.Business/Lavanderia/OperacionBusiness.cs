using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class OperacionBusiness
    {
        private static LavanderiaEntities _context;

        private const int CentroTrabajoCodigoTipo = 4;

        #region Properties

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public short OperacionTipoId { get; set; }

        [DataMember]
        public short GrupoId { get; set; }

        [DataMember]
        public int LineaProduccionId { get; set; }

        [DataMember]
        public OperacionPredefinidaBusiness OperacionPredefinida { get; private set; }

        #endregion

        #region Methods

        public static OperacionBusiness Insert(OperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new Operaciones
                    {
                        OperacionNombre = model.Nombre,
                        OperacionDescripcion = model.Descripcion,
                        TipoOperacionesCodigo = model.OperacionTipoId,
                        GrupoOperacionesCodigo = model.GrupoId,
                        LinaPCodigo = model.LineaProduccionId
                    };
                    _context.OperacionesSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OperacionCodigo;
                    model.OperacionPredefinida = OperacionPredefinidaBusiness.GetSingle(model.Id) ??
                                                 GetPredeterminadaDefault(model.Id);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / Insert", exception);
            }
        }

        public static OperacionBusiness Update(OperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesSet
                               where r.OperacionCodigo == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OperacionNombre = model.Nombre;
                        reg.OperacionDescripcion = model.Descripcion;
                        reg.TipoOperacionesCodigo = model.OperacionTipoId;
                        reg.GrupoOperacionesCodigo = model.GrupoId;
                        reg.LinaPCodigo = model.LineaProduccionId;

                        _context.SaveChanges();

                        model.OperacionPredefinida = OperacionPredefinidaBusiness.GetSingle(model.Id) ??
                                                     GetPredeterminadaDefault(model.Id);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Operacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / Update", exception);
            }
        }

        public static void Delete(OperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesSet
                               where r.OperacionCodigo == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Operacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OperacionesSet
                               where r.OperacionCodigo == operacionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OperacionesSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Operacion con Id: {operacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / Delete (id)", exception);
            }
        }

        public static OperacionBusiness Get(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesSet
                                 where r.OperacionCodigo == operacionId
                                 select new OperacionBusiness
                                 {
                                     Id = r.OperacionCodigo,
                                     Nombre = r.OperacionNombre,
                                     Descripcion = r.OperacionDescripcion,
                                     OperacionTipoId = r.TipoOperacionesCodigo,
                                     GrupoId = r.GrupoOperacionesCodigo,
                                     LineaProduccionId = r.LinaPCodigo
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.OperacionPredefinida = OperacionPredefinidaBusiness.GetSingle(model.Id) ??
                                                     GetPredeterminadaDefault(model.Id);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Operacion con Id: {operacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / Get", exception);
            }
        }

        public static OperacionBusiness GetSingle(int operacionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OperacionesSet
                                 where r.OperacionCodigo == operacionId
                                 select new OperacionBusiness
                                 {
                                     Id = r.OperacionCodigo,
                                     Nombre = r.OperacionNombre,
                                     Descripcion = r.OperacionDescripcion,
                                     OperacionTipoId = r.TipoOperacionesCodigo,
                                     GrupoId = r.GrupoOperacionesCodigo,
                                     LineaProduccionId = r.LinaPCodigo
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Operacion con Id: {operacionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / Get", exception);
            }
        }

        public static OperacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OperacionesSet
                        select new OperacionBusiness
                        {
                            Id = r.OperacionCodigo,
                            Nombre = r.OperacionNombre,
                            Descripcion = r.OperacionDescripcion,
                            OperacionTipoId = r.TipoOperacionesCodigo,
                            GrupoId = r.GrupoOperacionesCodigo,
                            LineaProduccionId = r.LinaPCodigo
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.OperacionPredefinida = OperacionPredefinidaBusiness.GetSingle(model.Id) ??
                                                     GetPredeterminadaDefault(model.Id);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / GetAll", exception);
            }
        }

        public static OperacionBusiness[] GetAllLavanderia()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var grupoLavanderia = 36;
                    var lista = (from r in _context.OperacionesSet
                                 where r.GrupoOperacionesCodigo == grupoLavanderia
                                 select new OperacionBusiness
                                 {
                                     Id = r.OperacionCodigo,
                                     Nombre = r.OperacionNombre,
                                     Descripcion = r.OperacionDescripcion,
                                     OperacionTipoId = r.TipoOperacionesCodigo,
                                     GrupoId = r.GrupoOperacionesCodigo,
                                     LineaProduccionId = r.LinaPCodigo
                                 }).ToArray();
                    foreach (var model in lista)
                    {
                        model.OperacionPredefinida = OperacionPredefinidaBusiness.GetSingle(model.Id) ??
                                                     GetPredeterminadaDefault(model.Id);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / GetAll", exception);
            }
        }
        

        //

        public static OperacionBusiness[] GetOperacionesHumedas(int centroTrabajoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from op in _context.OperacionesSet
                        join cto in _context.OperacionesCTrabajosSet on op.OperacionCodigo equals
                            cto.OperacionCodigo
                        join ct in _context.CentrosTrabajosSet on cto.CtrabajoCodigo equals
                            ct.CentroTrabajoCodigo
                        where ct.CentroTrabajoCodigoTipo == CentroTrabajoCodigoTipo &&
                              ct.CentroTrabajoCodigo == centroTrabajoId
                        select new OperacionBusiness
                        {
                            Id = op.OperacionCodigo,
                            Nombre = op.OperacionNombre,
                            Descripcion = op.OperacionDescripcion,
                            OperacionTipoId = op.TipoOperacionesCodigo,
                            GrupoId = op.GrupoOperacionesCodigo,
                            LineaProduccionId = op.LinaPCodigo
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.OperacionPredefinida = OperacionPredefinidaBusiness.GetSingle(model.Id) ??
                                                     GetPredeterminadaDefault(model.Id);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetOperacionesHumedas", exception);
            }
        }
        
        private static OperacionPredefinidaBusiness GetPredeterminadaDefault(int operacionId)
        {
            try
            {
                return new OperacionPredefinidaBusiness
                {
                    Id = 0,
                    OperacionId = operacionId,
                    Ph = "0",
                    RelacionBano = 0,
                    Secuencia = 0,
                    Temperatura = 0,
                    TiempoMaximo = 0,
                    TiempoMinimo = 0
                };
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionBusiness / GetPredeterminadaDefault", exception);
            }
        }

        #endregion
    }
}