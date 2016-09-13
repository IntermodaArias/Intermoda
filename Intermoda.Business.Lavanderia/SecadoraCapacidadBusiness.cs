using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class SecadoraCapacidadBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public decimal CapacidadMinimaKg { get; set; }

        [DataMember]
        public decimal CapacidadMaximaKg { get; set; }

        #endregion

        #region Methods

        public static SecadoraCapacidadBusiness Insert(SecadoraCapacidadBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new SecadorasCapacidad
                    {
                        SecadoraCapacidadKgMin = model.CapacidadMinimaKg,
                        SecadoraCapacidadKgMax = model.CapacidadMaximaKg
                    };
                    _context.SecadorasCapacidadSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.SecadoraCapacidadId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidadBusiness / Insert", exception);
            }
        }

        public static SecadoraCapacidadBusiness Update(SecadoraCapacidadBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.SecadorasCapacidadSet
                               where r.SecadoraCapacidadId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.SecadoraCapacidadKgMin = model.CapacidadMinimaKg;
                        reg.SecadoraCapacidadKgMax = model.CapacidadMaximaKg;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de SedadoraCapacidad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidadBusiness / Update", exception);
            }
        }

        public static void Delete(SecadoraCapacidadBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.SecadorasCapacidadSet
                               where r.SecadoraCapacidadId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.SecadorasCapacidadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de SedadoraCapacidad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidadBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int secadoraCapacidadId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.SecadorasCapacidadSet
                               where r.SecadoraCapacidadId == secadoraCapacidadId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.SecadorasCapacidadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de SedadoraCapacidad con Id: {secadoraCapacidadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidadBusiness / Delete (id)", exception);
            }
        }

        public static SecadoraCapacidadBusiness Get(int secadoraCapacidadId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.SecadorasCapacidadSet
                                 where r.SecadoraCapacidadId == secadoraCapacidadId
                                 select new SecadoraCapacidadBusiness
                                 {
                                     Id = r.SecadoraCapacidadId,
                                     CapacidadMaximaKg = r.SecadoraCapacidadKgMax,
                                     CapacidadMinimaKg = r.SecadoraCapacidadKgMin
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de SedadoraCapacidad con Id: {secadoraCapacidadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidadBusiness / Get", exception);
            }
        }

        public static SecadoraCapacidadBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.SecadorasCapacidadSet
                            select new SecadoraCapacidadBusiness
                            {
                                Id = r.SecadoraCapacidadId,
                                CapacidadMaximaKg = r.SecadoraCapacidadKgMax,
                                CapacidadMinimaKg = r.SecadoraCapacidadKgMin
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidadBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}