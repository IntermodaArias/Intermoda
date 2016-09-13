using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class LitrosAguaOperacionBusiness
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
        public int LavadoId { get; set; }

        [DataMember]
        public int OpcionLavadoId { get; set; }

        [DataMember]
        public int ProcesoId { get; set; }

        [DataMember]
        public short CargaNumero { get; set; }

        [DataMember]
        public decimal CantidadOperacionCarga { get; set; }

        [DataMember]
        public decimal CantidadOperacionSubCarga { get; set; }

        #endregion

        #region Methods

        public static LitrosAguaOperacionBusiness Insert(LitrosAguaOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new LitrosAguaOperacion()
                    {
                        LitrosAguaCiaCod = model.CompaniaId,
                        LitrosAguaPlantaCod = model.PlantaId,
                        LitrosAguaAnio = model.OrdenAno,
                        LitrosAguaNumeroOrden = model.OrdenNumero,
                        LitrosAguaLavadoId = model.LavadoId,
                        LitrosAguaOpcionLavadoId = model.OpcionLavadoId,
                        LitrosAguaOperacionProcesoId = model.ProcesoId,
                        LitrosAguaCargaLavadoNumero = model.CargaNumero,
                        LitrosAguaCantidadOperacionCarga = model.CantidadOperacionCarga,
                        LitrosAguaCantidadOperacionSubCarga = model.CantidadOperacionSubCarga
                    };
                    _context.LitrosAguaOperacionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.LitrosAguaId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LitrosAguaOperacionBusiness / Insert", exception);
            }
        }

        public static LitrosAguaOperacionBusiness Update(LitrosAguaOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LitrosAguaOperacionSet
                               where r.LitrosAguaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.LitrosAguaCiaCod = model.CompaniaId;
                        reg.LitrosAguaPlantaCod = model.PlantaId;
                        reg.LitrosAguaAnio = model.OrdenAno;
                        reg.LitrosAguaNumeroOrden = model.OrdenNumero;
                        reg.LitrosAguaLavadoId = model.LavadoId;
                        reg.LitrosAguaOpcionLavadoId = model.OpcionLavadoId;
                        reg.LitrosAguaOperacionProcesoId = model.ProcesoId;
                        reg.LitrosAguaCargaLavadoNumero = model.CargaNumero;
                        reg.LitrosAguaCantidadOperacionCarga = model.CantidadOperacionCarga;
                        reg.LitrosAguaCantidadOperacionSubCarga = model.CantidadOperacionSubCarga;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LitrosAguaOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LitrosAguaOperacionBusiness / Update", exception);
            }
        }

        public static void Delete(LitrosAguaOperacionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LitrosAguaOperacionSet
                               where r.LitrosAguaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LitrosAguaOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LitrosAguaOperacion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LitrosAguaOperacionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int litrosAguaOperacion)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LitrosAguaOperacionSet
                               where r.LitrosAguaId == litrosAguaOperacion
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LitrosAguaOperacionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LitrosAguaOperacion con Id: {litrosAguaOperacion}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LitrosAguaOperacionBusiness / Delete (id)", exception);
            }
        }

        public static LitrosAguaOperacionBusiness Get(int litrosAguaOperacion)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.LitrosAguaOperacionSet
                                 where r.LitrosAguaId == litrosAguaOperacion
                                 select new LitrosAguaOperacionBusiness
                                 {
                                     Id = r.LitrosAguaId,
                                     CompaniaId = (short)r.LitrosAguaCiaCod,
                                     PlantaId = r.LitrosAguaPlantaCod,
                                     OrdenAno = (short)r.LitrosAguaAnio,
                                     OrdenNumero = (short)r.LitrosAguaNumeroOrden,
                                     LavadoId = r.LitrosAguaLavadoId,
                                     OpcionLavadoId = r.LitrosAguaOpcionLavadoId,
                                     ProcesoId = r.LitrosAguaOperacionProcesoId,
                                     CargaNumero = r.LitrosAguaCargaLavadoNumero,
                                     CantidadOperacionCarga = r.LitrosAguaCantidadOperacionCarga,
                                     CantidadOperacionSubCarga = r.LitrosAguaCantidadOperacionSubCarga
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LitrosAguaOperacion con Id: {litrosAguaOperacion}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LitrosAguaOperacionBusiness / Get", exception);
            }
        }

        public static LitrosAguaOperacionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.LitrosAguaOperacionSet
                            select new LitrosAguaOperacionBusiness
                            {
                                Id = r.LitrosAguaId,
                                CompaniaId = (short)r.LitrosAguaCiaCod,
                                PlantaId = r.LitrosAguaPlantaCod,
                                OrdenAno = (short)r.LitrosAguaAnio,
                                OrdenNumero = (short)r.LitrosAguaNumeroOrden,
                                LavadoId = r.LitrosAguaLavadoId,
                                OpcionLavadoId = r.LitrosAguaOpcionLavadoId,
                                ProcesoId = r.LitrosAguaOperacionProcesoId,
                                CargaNumero = r.LitrosAguaCargaLavadoNumero,
                                CantidadOperacionCarga = r.LitrosAguaCantidadOperacionCarga,
                                CantidadOperacionSubCarga = r.LitrosAguaCantidadOperacionSubCarga
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LitrosAguaOperacionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}