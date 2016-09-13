using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Produccion.Lecturas.Business.Lecturas
{
    [DataContract]
    public class TurnoDetalleBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int TurnoId { get; set; }
        [DataMember]
        public DiaSemana Dia { get; set; }
        [DataMember]
        public int JornadaId { get; set; }
        [DataMember]
        public int Horas { get; set; }
        [DataMember]
        public int Minutos { get; set; }
        [DataMember]
        public JornadaBusiness Jornada { get; private set; }

        #endregion

        #region Methods
        
        public static TurnoDetalleBusiness Insert(TurnoDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new TurnoDetalle()
                    {
                        TurnoId = model.TurnoId,
                        Dia = (int)model.Dia,
                        JornadaId = model.JornadaId
                    };
                    _context.TurnoDetalleSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    model.Jornada = JornadaBusiness.Get(model.JornadaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / Insert", exception);
            }
        }

        public static TurnoDetalleBusiness Update(TurnoDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.TurnoDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.TurnoId = model.TurnoId;
                        reg.Dia = (int)model.Dia;
                        reg.JornadaId = model.JornadaId;

                        _context.SaveChanges();

                        model.Jornada = JornadaBusiness.Get(model.JornadaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de TurnoDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / Update", exception);
            }
        }

        public static void Delete(TurnoDetalleBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.TurnoDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TurnoDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de TurnoDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int turnoDetalleId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.TurnoDetalleSet
                               where r.Id == turnoDetalleId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TurnoDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de TurnoDetalle con Id: {turnoDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / Delete (id)", exception);
            }
        }

        public static TurnoDetalleBusiness Get(int turnoDetalleId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.TurnoDetalleSet
                                 where r.Id == turnoDetalleId
                                 select new TurnoDetalleBusiness
                                 {
                                     Id = r.Id,
                                     TurnoId = r.TurnoId,
                                     Dia = (DiaSemana)r.Dia,
                                     JornadaId = r.JornadaId
                                 }).FirstOrDefault();

                    if (model != null)
                    {
                        var jornada = (from r in _context.JornadaDetalleSet
                                       where r.JornadaId == model.JornadaId
                                       select new { r.Horas, r.Minutos }).ToList();

                        model.Horas = jornada.Sum(r => r.Horas);
                        model.Minutos = jornada.Sum(r => r.Minutos);
                        model.Jornada = (from r in _context.JornadaSet
                            where r.Id == model.JornadaId
                            select new JornadaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre
                            }).FirstOrDefault();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de TurnoDetalle con Id: {turnoDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / Get", exception);
            }
        }

        public static TurnoDetalleBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.TurnoDetalleSet
                        select new TurnoDetalleBusiness
                        {
                            Id = r.Id,
                            TurnoId = r.TurnoId,
                            Dia = (DiaSemana)r.Dia,
                            JornadaId = r.JornadaId
                        }).ToList();
                    foreach (var model in lista)
                    {
                        var jornada = (from r in _context.JornadaDetalleSet
                                       where r.JornadaId == model.JornadaId
                                       select new { r.Horas, r.Minutos }).ToList();

                        model.Horas = jornada.Sum(r => r.Horas);
                        model.Minutos = jornada.Sum(r => r.Minutos);
                        model.Jornada = (from r in _context.JornadaSet
                            where r.Id == model.JornadaId
                            select new JornadaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre
                            }).FirstOrDefault();
                    }
                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / GetAll", exception);
            }
        }

        public static TurnoDetalleBusiness[] GetByTurno(int turnoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var lista = (from r in _context.TurnoDetalleSet
                        where r.TurnoId == turnoId
                        select new TurnoDetalleBusiness
                        {
                            Id = r.Id,
                            TurnoId = r.TurnoId,
                            Dia = (DiaSemana)r.Dia,
                            JornadaId = r.JornadaId
                        }).ToList();
                    foreach (var model in lista)
                    {
                        var jornada = (from r in _context.JornadaDetalleSet
                                       where r.JornadaId == model.JornadaId
                                       select new { r.Horas, r.Minutos }).ToList();

                        model.Horas = jornada.Sum(r => r.Horas);
                        model.Minutos = jornada.Sum(r => r.Minutos);
                        model.Jornada = (from r in _context.JornadaSet
                            where r.Id == model.JornadaId
                            select new JornadaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre
                            }).FirstOrDefault();
                    }
                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalleBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}