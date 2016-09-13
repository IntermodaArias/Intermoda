using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class CantidadIngredienteInstruccionBusiness
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
        public short CargaNumero { get; set; }

        [DataMember]
        public int LavadoId { get; set; }

        [DataMember]
        public int OpcionLavadoId { get; set; }

        [DataMember]
        public int OperacionId { get; set; }

        [DataMember]
        public int InstruccionId { get; set; }

        [DataMember]
        public int MaterialId { get; set; }

        [DataMember]
        public decimal? Cantidad { get; set; }

        #endregion

        #region Methods

        public static CantidadIngredienteInstruccionBusiness Insert(CantidadIngredienteInstruccionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new CantidadIngredientesInstruccion()
                    {
                        CantidadIngredienteInstruccionCiaCod = model.CompaniaId,
                        CantidadIngredienteInstruccionPlantaCod = model.PlantaId,
                        CantidadIngredienteInstruccionAnio = model.OrdenAno,
                        CantidadIngredienteInstruccionNumeroOrden = model.OrdenNumero,
                        CantidadIngredienteInstruccionCargaLavadoNumero = model.CargaNumero,
                        CantidadIngredienteInstruccionLavadoId = model.LavadoId,
                        CantidadIngredienteInstruccionOpcionLavadoId = model.OpcionLavadoId,
                        CantidadIngredienteInstruccionOperacionId = model.OperacionId,
                        CantidadIngredienteInstruccionId = model.InstruccionId,
                        CantidadIngredienteInstruccionMaterialId = model.MaterialId,
                        CantidadIngredienteInstruccionValor = model.Cantidad
                    };
                    _context.CantidadIngredientesInstruccionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.CantidadIngredienteInstruccionId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteInstruccionBusiness / Insert", exception);
            }
        }

        public static CantidadIngredienteInstruccionBusiness Update(CantidadIngredienteInstruccionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CantidadIngredientesInstruccionSet
                               where r.CantidadIngredienteInstruccionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CantidadIngredienteInstruccionCiaCod = model.CompaniaId;
                        reg.CantidadIngredienteInstruccionPlantaCod = model.PlantaId;
                        reg.CantidadIngredienteInstruccionAnio = model.OrdenAno;
                        reg.CantidadIngredienteInstruccionNumeroOrden = model.OrdenNumero;
                        reg.CantidadIngredienteInstruccionCargaLavadoNumero = model.CargaNumero;
                        reg.CantidadIngredienteInstruccionLavadoId = model.LavadoId;
                        reg.CantidadIngredienteInstruccionOpcionLavadoId = model.OpcionLavadoId;
                        reg.CantidadIngredienteInstruccionOperacionId = model.OperacionId;
                        reg.CantidadIngredienteInstruccionId = model.InstruccionId;
                        reg.CantidadIngredienteInstruccionMaterialId = model.MaterialId;
                        reg.CantidadIngredienteInstruccionValor = model.Cantidad;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteInstruccion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteInstruccionBusiness / Update", exception);
            }
        }

        public static void Delete(CantidadIngredienteInstruccionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CantidadIngredientesInstruccionSet
                               where r.CantidadIngredienteInstruccionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CantidadIngredientesInstruccionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteInstruccion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteInstruccionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int cantidadIngredienteInstruccionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.CantidadIngredientesInstruccionSet
                               where r.CantidadIngredienteInstruccionId == cantidadIngredienteInstruccionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.CantidadIngredientesInstruccionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteInstruccion con Id: {cantidadIngredienteInstruccionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteInstruccionBusiness / Delete (id)", exception);
            }
        }

        public static CantidadIngredienteInstruccionBusiness Get(int cantidadIngredienteInstruccionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CantidadIngredientesInstruccionSet
                                 where r.CantidadIngredienteInstruccionId == cantidadIngredienteInstruccionId
                                 select new CantidadIngredienteInstruccionBusiness
                                 {
                                     Id = r.CantidadIngredienteInstruccionId,
                                     CompaniaId = (short)r.CantidadIngredienteInstruccionCiaCod,
                                     PlantaId = r.CantidadIngredienteInstruccionPlantaCod,
                                     OrdenAno = (short)r.CantidadIngredienteInstruccionAnio,
                                     OrdenNumero = (short)r.CantidadIngredienteInstruccionNumeroOrden,
                                     CargaNumero = r.CantidadIngredienteInstruccionCargaLavadoNumero,
                                     LavadoId = r.CantidadIngredienteInstruccionLavadoId,
                                     OpcionLavadoId = r.CantidadIngredienteInstruccionOpcionLavadoId,
                                     OperacionId = r.CantidadIngredienteInstruccionOperacionId,
                                     MaterialId = r.CantidadIngredienteInstruccionMaterialId,
                                     Cantidad = r.CantidadIngredienteInstruccionValor
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CantidadIngredienteInstruccion con Id: {cantidadIngredienteInstruccionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteInstruccionBusiness / Get", exception);
            }
        }

        public static CantidadIngredienteInstruccionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.CantidadIngredientesInstruccionSet
                            select new CantidadIngredienteInstruccionBusiness
                            {
                                Id = r.CantidadIngredienteInstruccionId,
                                CompaniaId = (short)r.CantidadIngredienteInstruccionCiaCod,
                                PlantaId = r.CantidadIngredienteInstruccionPlantaCod,
                                OrdenAno = (short)r.CantidadIngredienteInstruccionAnio,
                                OrdenNumero = (short)r.CantidadIngredienteInstruccionNumeroOrden,
                                CargaNumero = r.CantidadIngredienteInstruccionCargaLavadoNumero,
                                LavadoId = r.CantidadIngredienteInstruccionLavadoId,
                                OpcionLavadoId = r.CantidadIngredienteInstruccionOpcionLavadoId,
                                OperacionId = r.CantidadIngredienteInstruccionOperacionId,
                                MaterialId = r.CantidadIngredienteInstruccionMaterialId,
                                Cantidad = r.CantidadIngredienteInstruccionValor
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CantidadIngredienteInstruccionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}