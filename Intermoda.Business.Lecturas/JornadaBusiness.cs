using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Business.Lecturas
{
    [DataContract]
    public class JornadaBusiness
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

        public static JornadaBusiness Insert(JornadaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new Jornada()
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre
                    };
                    _context.JornadaSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaBusiness / Insert", exception);
            }
        }

        public static JornadaBusiness Update(JornadaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.JornadaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Jornada con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaBusiness / Update", exception);
            }
        }

        public static void Delete(JornadaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.JornadaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.JornadaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Jornada con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int jornadaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.JornadaSet
                               where r.Id == jornadaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.JornadaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Jornada con Id: {jornadaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaBusiness / Delete (id)", exception);
            }
        }

        public static JornadaBusiness Get(int jornadaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.JornadaSet
                        where r.Id == jornadaId
                        select new JornadaBusiness
                        {
                            Id = r.Id,
                            Codigo = r.Codigo,
                            Nombre = r.Nombre
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Jornada con Id: {jornadaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaBusiness / Get", exception);
            }
        }

        public static JornadaBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.JornadaSet
                            select new JornadaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}