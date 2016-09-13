using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Business.Lecturas
{
    [DataContract]
    public class JornadaDetalleBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int JornadaId { get; set; }
        [DataMember]
        public int EntradaHora { get; set; }
        [DataMember]
        public int EntradaMinuto { get; set; }
        [DataMember]
        public int SalidaHora { get; set; }
        [DataMember]
        public int SalidaMinuto { get; set; }
        [DataMember]
        public int Horas { get; set; }
        [DataMember]
        public int Minutos { get; set; }

        #endregion

        #region Methods
        
        public static JornadaDetalleBusiness Insert(JornadaDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var entradaMinutos = model.EntradaHora*60 + model.EntradaMinuto;
                    var salidaMinutos = model.SalidaHora*60 + model.SalidaMinuto;
                    var tiempoMinutos = 0;
                    if (salidaMinutos < entradaMinutos)
                    {
                        tiempoMinutos = 24*60 - entradaMinutos + salidaMinutos;
                    }
                    else
                    {
                        tiempoMinutos = salidaMinutos - entradaMinutos;
                    }

                    var horas = (int)Math.Truncate((decimal)tiempoMinutos/60);
                    var minutos = tiempoMinutos - (horas*60);

                    var reg = new JornadaDetalle()
                    {
                        JornadaId = model.JornadaId,
                        EntradaHora = model.EntradaHora,
                        EntradaMinuto = model.EntradaMinuto,
                        SalidaHora = model.SalidaHora,
                        SalidaMinuto = model.SalidaMinuto,
                        Horas = horas,
                        Minutos = minutos
                    };
                    _context.JornadaDetalleSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / Insert", exception);
            }
        }

        public static JornadaDetalleBusiness Update(JornadaDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.JornadaDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        var entradaMinutos = model.EntradaHora * 60 + model.EntradaMinuto;
                        var salidaMinutos = model.SalidaHora * 60 + model.SalidaMinuto;
                        var tiempoMinutos = 0;
                        if (salidaMinutos < entradaMinutos)
                        {
                            tiempoMinutos = 24 * 60 - entradaMinutos + salidaMinutos;
                        }
                        else
                        {
                            tiempoMinutos = salidaMinutos - entradaMinutos;
                        }

                        var horas = (int)Math.Truncate((decimal)tiempoMinutos / 60);
                        var minutos = tiempoMinutos - (horas * 60);

                        reg.JornadaId = model.JornadaId;
                        reg.EntradaHora = model.EntradaHora;
                        reg.EntradaMinuto = model.EntradaMinuto;
                        reg.SalidaHora = model.SalidaHora;
                        reg.SalidaMinuto = model.SalidaMinuto;
                        reg.Horas = horas;
                        reg.Minutos = minutos;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de JornadaDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / Update", exception);
            }
        }

        public static void Delete(JornadaDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.JornadaDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.JornadaDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de JornadaDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int jornadaDetalleId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.JornadaDetalleSet
                               where r.Id == jornadaDetalleId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.JornadaDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de JornadaDetalle con Id: {jornadaDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / Delete (id)", exception);
            }
        }

        public static JornadaDetalleBusiness Get(int jornadaDetalleId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.JornadaDetalleSet
                                 where r.Id == jornadaDetalleId
                                 select new JornadaDetalleBusiness
                                 {
                                     Id = r.Id,
                                     JornadaId = r.JornadaId,
                                     EntradaHora = r.EntradaHora,
                                     EntradaMinuto = r.EntradaMinuto,
                                     SalidaHora = r.SalidaHora,
                                     SalidaMinuto = r.SalidaMinuto,
                                     Horas = r.Horas,
                                     Minutos = r.Minutos
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de JornadaDetalle con Id: {jornadaDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / Get", exception);
            }
        }

        public static JornadaDetalleBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.JornadaDetalleSet
                            select new JornadaDetalleBusiness
                            {
                                Id = r.Id,
                                JornadaId = r.JornadaId,
                                EntradaHora = r.EntradaHora,
                                EntradaMinuto = r.EntradaMinuto,
                                SalidaHora = r.SalidaHora,
                                SalidaMinuto = r.SalidaMinuto,
                                Horas = r.Horas,
                                Minutos = r.Minutos
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / GetAll", exception);
            }
        }

        public static JornadaDetalleBusiness[] GetbyJornada(int jornadaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.JornadaDetalleSet
                            where r.JornadaId == jornadaId
                            select new JornadaDetalleBusiness
                            {
                                Id = r.Id,
                                JornadaId = r.JornadaId,
                                EntradaHora = r.EntradaHora,
                                EntradaMinuto = r.EntradaMinuto,
                                SalidaHora = r.SalidaHora,
                                SalidaMinuto = r.SalidaMinuto,
                                Horas = r.Horas,
                                Minutos = r.Minutos
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalleBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}