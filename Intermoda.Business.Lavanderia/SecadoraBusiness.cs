using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class SecadoraBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public short Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public short SecadoraCapacidadId { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public string Modelo { get; set; }

        [DataMember]
        public short? Estado { get; set; }

        [DataMember]
        public string NumeroSerie { get; set; }

        [DataMember]
        public string DireccionIp { get; set; }

        [DataMember]
        public string DireccionMac { get; set; }

        [DataMember]
        public SecadoraCapacidadBusiness SecadoraCapacidad { get; private set; }

        #endregion

        #region Methods

        public static SecadoraBusiness Insert(SecadoraBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new Secadoras()
                    {
                        SecadoraNombre = model.Nombre,
                        SecadorasCapacidadId = model.SecadoraCapacidadId,
                        SecadoraMarca = model.Marca,
                        SecadoraModelo = model.Modelo,
                        SecadoraEstado = model.Estado,
                        SecadoraNumeroSerie = model.NumeroSerie,
                        SecadoraIP = model.DireccionIp,
                        secadoraMAC = model.DireccionMac
                    };
                    _context.SecadorasSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.SecadoraId;
                    model.SecadoraCapacidad = SecadoraCapacidadBusiness.Get(model.SecadoraCapacidadId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / Insert", exception);
            }
        }

        public static SecadoraBusiness Update(SecadoraBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.SecadorasSet
                               where r.SecadoraId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.SecadoraNombre = model.Nombre;
                        reg.SecadorasCapacidadId = model.SecadoraCapacidadId;
                        reg.SecadoraMarca = model.Marca;
                        reg.SecadoraModelo = model.Modelo;
                        reg.SecadoraEstado = model.Estado;
                        reg.SecadoraNumeroSerie = model.NumeroSerie;
                        reg.SecadoraIP = model.DireccionIp;
                        reg.secadoraMAC = model.DireccionMac;

                        model.SecadoraCapacidad = SecadoraCapacidadBusiness.Get(model.SecadoraCapacidadId);
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Secadora con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / Update", exception);
            }
        }

        public static void Delete(SecadoraBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.SecadorasSet
                               where r.SecadoraId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.SecadorasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Secadora con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int secadoraId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.SecadorasSet
                               where r.SecadoraId == secadoraId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.SecadorasSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Secadora con Id: {secadoraId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / Delete (id)", exception);
            }
        }

        public static SecadoraBusiness Get(int secadoraId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.SecadorasSet
                        join c in _context.SecadorasCapacidadSet on
                            r.SecadorasCapacidadId equals c.SecadoraCapacidadId
                        where r.SecadoraId == secadoraId
                        select new SecadoraBusiness
                        {
                            Id = r.SecadoraId,
                            Nombre = r.SecadoraNombre,
                            SecadoraCapacidadId = r.SecadorasCapacidadId,
                            Marca = r.SecadoraMarca,
                            Modelo = r.SecadoraModelo,
                            Estado = r.SecadoraEstado,
                            NumeroSerie = r.SecadoraNumeroSerie,
                            DireccionIp = r.SecadoraIP,
                            DireccionMac = r.secadoraMAC,
                            SecadoraCapacidad = new SecadoraCapacidadBusiness
                            {
                                Id = c.SecadoraCapacidadId,
                                CapacidadMinimaKg = c.SecadoraCapacidadKgMin,
                                CapacidadMaximaKg = c.SecadoraCapacidadKgMax
                            }
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Secadora con Id: {secadoraId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / Get", exception);
            }
        }

        public static SecadoraBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.SecadorasSet
                            join c in _context.SecadorasCapacidadSet on
                            r.SecadorasCapacidadId equals c.SecadoraCapacidadId
                            orderby r.SecadoraNombre
                            select new SecadoraBusiness
                            {
                                Id = r.SecadoraId,
                                Nombre = r.SecadoraNombre,
                                SecadoraCapacidadId = r.SecadorasCapacidadId,
                                Marca = r.SecadoraMarca,
                                Modelo = r.SecadoraModelo,
                                Estado = r.SecadoraEstado,
                                NumeroSerie = r.SecadoraNumeroSerie,
                                DireccionIp = r.SecadoraIP,
                                DireccionMac = r.secadoraMAC,
                                SecadoraCapacidad = new SecadoraCapacidadBusiness
                                {
                                    Id = c.SecadoraCapacidadId,
                                    CapacidadMinimaKg = c.SecadoraCapacidadKgMin,
                                    CapacidadMaximaKg = c.SecadoraCapacidadKgMax
                                }
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / GetAll", exception);
            }
        }

        public static SecadoraBusiness[] GetByCapacidad(int secadoraCapacidadId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.SecadorasSet
                        join c in _context.SecadorasCapacidadSet on
                            r.SecadorasCapacidadId equals c.SecadoraCapacidadId
                        where r.SecadorasCapacidadId == secadoraCapacidadId
                        orderby r.SecadorasCapacidadId, r.SecadoraNombre
                        select new SecadoraBusiness
                        {
                            Id = r.SecadoraId,
                            Nombre = r.SecadoraNombre,
                            SecadoraCapacidadId = r.SecadorasCapacidadId,
                            Marca = r.SecadoraMarca,
                            Modelo = r.SecadoraModelo,
                            Estado = r.SecadoraEstado,
                            NumeroSerie = r.SecadoraNumeroSerie,
                            DireccionIp = r.SecadoraIP,
                            DireccionMac = r.secadoraMAC,
                            SecadoraCapacidad = new SecadoraCapacidadBusiness
                            {
                                Id = c.SecadoraCapacidadId,
                                CapacidadMinimaKg = c.SecadoraCapacidadKgMin,
                                CapacidadMaximaKg = c.SecadoraCapacidadKgMax
                            }
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraBusiness / GetByCapacidad", exception);
            }
        }

        #endregion
    }
}