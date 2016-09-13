using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class CantidadIngredienteOperacionBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public int PlantaId { get; set; }

        [DataMember]
        public short OrdenAno { get; set; }

        [DataMember]
        public short OrdenNumero { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int LavadoId { get; set; }

        [DataMember]
        public int OpcionLavadoId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public short CargaNumero { get; set; }

        [DataMember]
        public decimal? Cantidad { get; set; }

        #endregion

        #region Methods

        public static CantidadIngredienteOperacionBusiness Insert(CantidadIngredienteOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new CantidadIngredientesOperacion()
                    {
                        CantidadIngredienteCiaCod = model.CompaniaId,
                        CantidadIngredientePlantaCod = model.PlantaId,
                        CantidadIngredienteAnio = model.OrdenAno,
                        CantidadIngredienteNumeroOrden = model.OrdenNumero,
                        CantidadIngredienteOperacionId = model.OperacionId,
                        CantidadIngredienteLavadoId = model.LavadoId,
                        CantidadIngredienteOpcionLavadoId = model.OpcionLavadoId,
                        CantidadIngredienteMaterialId = model.MaterialId,
                        CantidadIngredienteCargaLavadoNumero = model.CargaNumero,
                        CantidadIngredienteValor = model.Cantidad
                    };
                    _context.CantidadIngredientesOperacionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.CantidadIngredienteId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteOperacionBusiness / Insert", exception);
            }
        }

        public static CantidadIngredienteOperacionBusiness Update(CantidadIngredienteOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CantidadIngredientesOperacionSet
                               where r.CantidadIngredienteId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CantidadIngredienteCiaCod = model.CompaniaId;
                        reg.CantidadIngredientePlantaCod = model.PlantaId;
                        reg.CantidadIngredienteAnio = model.OrdenAno;
                        reg.CantidadIngredienteNumeroOrden = model.OrdenNumero;
                        reg.CantidadIngredienteOperacionId = model.OperacionId;
                        reg.CantidadIngredienteLavadoId = model.LavadoId;
                        reg.CantidadIngredienteOpcionLavadoId = model.OpcionLavadoId;
                        reg.CantidadIngredienteMaterialId = model.MaterialId;
                        reg.CantidadIngredienteCargaLavadoNumero = model.CargaNumero;
                        reg.CantidadIngredienteValor = model.Cantidad;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteOperacionBusiness / Update", exception);
            }
        }

        public static void Delete(CantidadIngredienteOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CantidadIngredientesOperacionSet
                               where r.CantidadIngredienteId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CantidadIngredientesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteOperacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int cantidadIngredienteInstruccionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CantidadIngredientesOperacionSet
                               where r.CantidadIngredienteId == cantidadIngredienteInstruccionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CantidadIngredientesOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteOperacion con Id: {cantidadIngredienteInstruccionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteOperacionBusiness / Delete (id)", exception);
            }
        }

        public static CantidadIngredienteOperacionBusiness Get(int cantidadIngredienteInstruccionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CantidadIngredientesOperacionSet
                                 where r.CantidadIngredienteId == cantidadIngredienteInstruccionId
                                 select new CantidadIngredienteOperacionBusiness
                                 {
                                     Id = r.CantidadIngredienteId,
                                     CompaniaId = (short)r.CantidadIngredienteCiaCod,
                                     PlantaId = r.CantidadIngredientePlantaCod,
                                     OrdenAno = (short)r.CantidadIngredienteAnio,
                                     OrdenNumero = (short)r.CantidadIngredienteNumeroOrden,
                                     OperacionId = r.CantidadIngredienteOperacionId,
                                     LavadoId = r.CantidadIngredienteLavadoId,
                                     OpcionLavadoId = r.CantidadIngredienteOpcionLavadoId,
                                     MaterialId = r.CantidadIngredienteMaterialId,
                                     CargaNumero = r.CantidadIngredienteCargaLavadoNumero,
                                     Cantidad = r.CantidadIngredienteValor
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteOperacion con Id: {cantidadIngredienteInstruccionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteOperacionBusiness / Get", exception);
            }
        }

        public static CantidadIngredienteOperacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.CantidadIngredientesOperacionSet
                            select new CantidadIngredienteOperacionBusiness
                            {
                                Id = r.CantidadIngredienteId,
                                CompaniaId = (short)r.CantidadIngredienteCiaCod,
                                PlantaId = r.CantidadIngredientePlantaCod,
                                OrdenAno = (short)r.CantidadIngredienteAnio,
                                OrdenNumero = (short)r.CantidadIngredienteNumeroOrden,
                                OperacionId = r.CantidadIngredienteOperacionId,
                                LavadoId = r.CantidadIngredienteLavadoId,
                                OpcionLavadoId = r.CantidadIngredienteOpcionLavadoId,
                                MaterialId = r.CantidadIngredienteMaterialId,
                                CargaNumero = r.CantidadIngredienteCargaLavadoNumero,
                                Cantidad = r.CantidadIngredienteValor
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteOperacionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}