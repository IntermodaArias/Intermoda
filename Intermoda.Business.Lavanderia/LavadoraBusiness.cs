using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class LavadoraBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short LavadoraCapacidadId { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public short Estado { get; set; }

        [DataMember]
        public string NumeroSerie { get; set; }

        [DataMember]
        public string DireccionIp { get; set; }

        [DataMember]
        public string DireccionMac { get; set; }

        [DataMember]
        public LavadoraCapacidadBusiness LavadoraCapacidad { get; private set; }

        #endregion

        #region Methods

        public static LavadoraBusiness Insert(LavadoraBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new Lavadoras()
                    {
                        LavadoraNombre = model.Nombre,
                        LavadorasCapacidadId = model.LavadoraCapacidadId,
                        LavadoraMarca = model.Marca,
                        LavadoraModelo = model.Modelo,
                        LavadoraEstado = model.Estado,
                        LavadoraNumeroSerie = model.NumeroSerie,
                        LavadoraIP = model.DireccionIp,
                        LavadoraMAC = model.DireccionMac
                    };
                    _context.LavadorasSet.Add(reg);
                    _context.SaveChanges();

                    model.LavadoraCapacidad = LavadoraCapacidadBusiness.Get(model.LavadoraCapacidadId);

                    model.Id = reg.LavadoraId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / Insert", exception);
            }
        }

        public static LavadoraBusiness Update(LavadoraBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadorasSet
                               where r.LavadoraId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.LavadoraNombre = model.Nombre;
                        reg.LavadorasCapacidadId = model.LavadoraCapacidadId;
                        reg.LavadoraMarca = model.Marca;
                        reg.LavadoraModelo = model.Modelo;
                        reg.LavadoraEstado = model.Estado;
                        reg.LavadoraNumeroSerie = model.NumeroSerie;
                        reg.LavadoraIP = model.DireccionIp;
                        reg.LavadoraMAC = model.DireccionMac;
                        _context.SaveChanges();

                        model.LavadoraCapacidad = LavadoraCapacidadBusiness.Get(model.LavadoraCapacidadId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavadora con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / Update", exception);
            }
        }

        public static void Delete(LavadoraBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadorasSet
                               where r.LavadoraId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LavadorasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavadora con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int lavadoraId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadorasSet
                               where r.LavadoraId == lavadoraId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LavadorasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavadora con Id: {lavadoraId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / Delete (id)", exception);
            }
        }

        public static LavadoraBusiness Get(int lavadoraId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.LavadorasSet
                                 join c in _context.LavadorasCapacidadSet on 
                                 r.LavadorasCapacidadId equals c.LavadoraCapacidadId
                                 where r.LavadoraId == lavadoraId
                                 select new LavadoraBusiness
                                 {
                                     Id = r.LavadoraId,
                                     Nombre = r.LavadoraNombre,
                                     LavadoraCapacidadId = r.LavadorasCapacidadId,
                                     Marca = r.LavadoraMarca,
                                     Modelo = r.LavadoraModelo,
                                     Estado = r.LavadoraEstado,
                                     NumeroSerie = r.LavadoraNumeroSerie,
                                     DireccionIp = r.LavadoraIP,
                                     DireccionMac = r.LavadoraMAC,
                                     LavadoraCapacidad = new LavadoraCapacidadBusiness
                                     {
                                         Id = r.LavadorasCapacidad.LavadoraCapacidadId,
                                         CapacidadMinimaKg = r.LavadorasCapacidad.LavadoraCapacidadKgMin,
                                         CapacidadMaximaKg = r.LavadorasCapacidad.LavadoraCapacidadKgMax,
                                         CapacidadCanastaLitro = r.LavadorasCapacidad.LavadoraCapacidadLitroCanasta
                                     }
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavadora con Id: {lavadoraId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / Get", exception);
            }
        }

        public static LavadoraBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.LavadorasSet
                            orderby r.LavadoraNombre
                            select new LavadoraBusiness
                            {
                                Id = r.LavadoraId,
                                Nombre = r.LavadoraNombre,
                                LavadoraCapacidadId = r.LavadorasCapacidadId,
                                Marca = r.LavadoraMarca,
                                Modelo = r.LavadoraModelo,
                                Estado = r.LavadoraEstado,
                                NumeroSerie = r.LavadoraNumeroSerie,
                                DireccionIp = r.LavadoraIP,
                                DireccionMac = r.LavadoraMAC,
                                LavadoraCapacidad = new LavadoraCapacidadBusiness
                                {
                                    Id = r.LavadorasCapacidad.LavadoraCapacidadId,
                                    CapacidadMinimaKg = r.LavadorasCapacidad.LavadoraCapacidadKgMin,
                                    CapacidadMaximaKg = r.LavadorasCapacidad.LavadoraCapacidadKgMax,
                                    CapacidadCanastaLitro = r.LavadorasCapacidad.LavadoraCapacidadLitroCanasta
                                }
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / GetAll", exception);
            }
        }

        public static LavadoraBusiness[] GetByCapacidad(int lavadoraCapacidadId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.LavadorasSet
                        where r.LavadorasCapacidadId == lavadoraCapacidadId
                        orderby r.LavadorasCapacidadId, r.LavadoraNombre
                        select new LavadoraBusiness
                        {
                            Id = r.LavadoraId,
                            Nombre = r.LavadoraNombre,
                            LavadoraCapacidadId = r.LavadorasCapacidadId,
                            Marca = r.LavadoraMarca,
                            Modelo = r.LavadoraModelo,
                            Estado = r.LavadoraEstado,
                            NumeroSerie = r.LavadoraNumeroSerie,
                            DireccionIp = r.LavadoraIP,
                            DireccionMac = r.LavadoraMAC,
                            LavadoraCapacidad = new LavadoraCapacidadBusiness
                            {
                                Id = r.LavadorasCapacidad.LavadoraCapacidadId,
                                CapacidadMinimaKg = r.LavadorasCapacidad.LavadoraCapacidadKgMin,
                                CapacidadMaximaKg = r.LavadorasCapacidad.LavadoraCapacidadKgMax,
                                CapacidadCanastaLitro = r.LavadorasCapacidad.LavadoraCapacidadLitroCanasta
                            }
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraBusiness / GetByCapacidad", exception);
            }
        }

        #endregion
    }
}