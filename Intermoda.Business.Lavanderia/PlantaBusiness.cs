using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class PlantaBusiness
    {
        private static LavanderiaEntities _context;

        private const int Compania = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Observacion { get; set; }

        [DataMember]
        public bool Propietaria { get; set; }

        [DataMember]
        public int CompaniaId { get; set; }

        #endregion

        #region Methods
        
        public static PlantaBusiness Insert(PlantaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new Plantas
                    {
                        PlantaNombre = model.Nombre,
                        PlantaObsevacion = model.Observacion,
                        PlantaPropietaria = model.Propietaria,
                        CompañiaCodigo = model.CompaniaId != 0 ? model.CompaniaId : Compania
                    };
                    _context.PlantasSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.PlantaCodigo;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Insert", exception);
            }
        }

        public static PlantaBusiness Update(PlantaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.PlantasSet
                               where r.PlantaCodigo == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.PlantaNombre = model.Nombre;
                        reg.PlantaObsevacion = model.Observacion;
                        reg.PlantaPropietaria = model.Propietaria;
                        reg.CompañiaCodigo = model.CompaniaId != 0 ? model.CompaniaId : Compania;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Planta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Update", exception);
            }
        }

        public static void Delete(PlantaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.PlantasSet
                               where r.PlantaCodigo == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.PlantasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Planta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int plantaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.PlantasSet
                               where r.PlantaCodigo == plantaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.PlantasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Planta con Id: {plantaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Delete (id)", exception);
            }
        }

        public static PlantaBusiness Get(int plantaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.PlantasSet
                                 where r.PlantaCodigo == plantaId
                                 select new PlantaBusiness
                                 {
                                     Id = r.PlantaCodigo,
                                     Nombre = r.PlantaNombre,
                                     Observacion = r.PlantaObsevacion,
                                     Propietaria = r.PlantaPropietaria,
                                     CompaniaId = r.CompañiaCodigo
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Planta con Id: {plantaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / Get", exception);
            }
        }

        public static PlantaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.PlantasSet
                        select new PlantaBusiness
                        {
                            Id = r.PlantaCodigo,
                            Nombre = r.PlantaNombre,
                            Observacion = r.PlantaObsevacion,
                            Propietaria = r.PlantaPropietaria,
                            CompaniaId = r.CompañiaCodigo
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / GetAll", exception);
            }
        }

        public static PlantaBusiness[] GetbyCompania(int companiaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.PlantasSet
                        where r.CompañiaCodigo == (companiaId < 1 ? Compania : companiaId)
                        select new PlantaBusiness
                        {
                            Id = r.PlantaCodigo,
                            Nombre = r.PlantaNombre,
                            Observacion = r.PlantaObsevacion,
                            Propietaria = r.PlantaPropietaria,
                            CompaniaId = r.CompañiaCodigo
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PlantaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}