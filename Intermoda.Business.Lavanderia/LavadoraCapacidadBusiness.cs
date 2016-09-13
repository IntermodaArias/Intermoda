using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class LavadoraCapacidadBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public decimal CapacidadMaximaKg { get; set; }

        [DataMember]
        public decimal? CapacidadMinimaKg { get; set; }

        [DataMember]
        public decimal? CapacidadCanastaLitro { get; set; }

        #endregion

        #region Methods

        public static LavadoraCapacidadBusiness Insert(LavadoraCapacidadBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new LavadorasCapacidad
                    {
                        LavadoraCapacidadKgMax = model.CapacidadMaximaKg,
                        LavadoraCapacidadKgMin = model.CapacidadMinimaKg,
                        LavadoraCapacidadLitroCanasta = model.CapacidadCanastaLitro
                    };
                    _context.LavadorasCapacidadSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.LavadoraCapacidadId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Insert", exception);
            }
        }

        public static LavadoraCapacidadBusiness Update(LavadoraCapacidadBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadorasCapacidadSet
                               where r.LavadoraCapacidadId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.LavadoraCapacidadKgMin = model.CapacidadMinimaKg;
                        reg.LavadoraCapacidadKgMax = model.CapacidadMaximaKg;
                        reg.LavadoraCapacidadLitroCanasta = model.CapacidadCanastaLitro;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LavadoraCapacidad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Update", exception);
            }
        }

        public static void Delete(LavadoraCapacidadBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadorasCapacidadSet
                               where r.LavadoraCapacidadId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LavadorasCapacidadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LavadoraCapacidad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int lavadoraCapacidadId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadorasCapacidadSet
                               where r.LavadoraCapacidadId == lavadoraCapacidadId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LavadorasCapacidadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LavadoraCapacidad con Id: {lavadoraCapacidadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Delete (id)", exception);
            }
        }

        public static LavadoraCapacidadBusiness Get(int lavadoraCapacidadId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.LavadorasCapacidadSet
                                 where r.LavadoraCapacidadId == lavadoraCapacidadId
                                 select new LavadoraCapacidadBusiness
                                 {
                                     Id = r.LavadoraCapacidadId,
                                     CapacidadMinimaKg = r.LavadoraCapacidadKgMin,
                                     CapacidadMaximaKg = r.LavadoraCapacidadKgMax,
                                     CapacidadCanastaLitro = r.LavadoraCapacidadLitroCanasta
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LavadoraCapacidad con Id: {lavadoraCapacidadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / Get", exception);
            }
        }

        public static LavadoraCapacidadBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.LavadorasCapacidadSet
                            select new LavadoraCapacidadBusiness
                            {
                                Id = r.LavadoraCapacidadId,
                                CapacidadMinimaKg = r.LavadoraCapacidadKgMin,
                                CapacidadMaximaKg = r.LavadoraCapacidadKgMax,
                                CapacidadCanastaLitro = r.LavadoraCapacidadLitroCanasta
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidadBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}