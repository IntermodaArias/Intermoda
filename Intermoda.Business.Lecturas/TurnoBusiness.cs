using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Business.Lecturas
{
    [DataContract]
    public class TurnoBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }

        #endregion

        #region Methods
        
        public static TurnoBusiness Insert(TurnoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new Turno()
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre
                    };
                    _context.TurnoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoBusiness / Insert", exception);
            }
        }

        public static TurnoBusiness Update(TurnoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.TurnoSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Turno con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoBusiness / Update", exception);
            }
        }

        public static void Delete(TurnoBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.TurnoSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TurnoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Turno con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int turnoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.TurnoSet
                               where r.Id == turnoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TurnoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Turno con Id: {turnoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoBusiness / Delete (id)", exception);
            }
        }

        public static TurnoBusiness Get(int turnoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.TurnoSet
                                 where r.Id == turnoId
                                 select new TurnoBusiness
                                 {
                                     Id = r.Id,
                                     Codigo = r.Codigo,
                                     Nombre = r.Nombre
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Turno con Id: {turnoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoBusiness / Get", exception);
            }
        }

        public static TurnoBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.TurnoSet
                            select new TurnoBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}