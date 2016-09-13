using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Common.Enum;
using Intermoda.Produccion.Lecturas.Data;

namespace Intermoda.Produccion.Lecturas.Business.Lecturas
{
    [DataContract]
    public class LineaBusiness
    {
        private static ProduccionLecturasEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Secuencia { get; set; }
        [DataMember]
        public LineaTipo Tipo { get; set; }
        [DataMember]
        public int GrupoId { get; set; }
        [DataMember]
        public bool Estado { get; set; }

        #endregion

        #region Methods

        public static LineaBusiness Insert(LineaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = new Linea
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Tipo = (int)model.Tipo,
                        GrupoId = model.GrupoId,
                        Estado = model.Estado
                    };
                    _context.LineaSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / Insert", exception);
            }
        }

        public static LineaBusiness Update(LineaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.LineaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Secuencia = model.Secuencia;
                        reg.Tipo = (int)model.Tipo;
                        reg.GrupoId = model.GrupoId;
                        reg.Estado = model.Estado;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Linea con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / Update", exception);
            }
        }

        public static void Delete(LineaBusiness model)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.LineaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LineaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Linea con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int lineaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var reg = (from r in _context.LineaSet
                               where r.Id == lineaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LineaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Linea con Id: {lineaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / Delete (id)", exception);
            }
        }

        public static LineaBusiness Get(int lineaId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    var model = (from r in _context.LineaSet
                                 where r.Id == lineaId
                                 select new LineaBusiness
                                 {
                                     Id = r.Id,
                                     Codigo = r.Codigo,
                                     Nombre = r.Nombre,
                                     Secuencia = r.Secuencia,
                                     Tipo = (LineaTipo)r.Tipo,
                                     GrupoId = r.GrupoId,
                                     Estado = r.Estado
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Linea con Id: {lineaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / Get", exception);
            }
        }

        public static LineaBusiness[] GetAll()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.LineaSet
                            orderby r.GrupoId, r.Secuencia, r.Nombre
                            select new LineaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Tipo = (LineaTipo)r.Tipo,
                                GrupoId = r.GrupoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / GetAll", exception);
            }
        }

        public static LineaBusiness[] GetAllActivas()
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.LineaSet
                            where r.Estado
                            orderby r.Estado, r.GrupoId, r.Secuencia, r.Nombre
                            select new LineaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Tipo = (LineaTipo)r.Tipo,
                                GrupoId = r.GrupoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / GetAllActivas", exception);
            }
        }

        public static LineaBusiness[] GetByGrupo(int grupoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.LineaSet
                            where r.GrupoId == grupoId
                            orderby r.GrupoId, r.Secuencia, r.Nombre
                            select new LineaBusiness
                            {
                                Id = r.Id,
                                Codigo = r.Codigo,
                                Nombre = r.Nombre,
                                Secuencia = r.Secuencia,
                                Tipo = (LineaTipo)r.Tipo,
                                GrupoId = r.GrupoId,
                                Estado = r.Estado
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / GetByGrupo", exception);
            }
        }

        public static LineaBusiness[] GetByGrupoActivas(int grupoId)
        {
            try
            {
                using (_context = new ProduccionLecturasEntities())
                {
                    return (from r in _context.LineaSet
                        where r.Estado &&
                              r.GrupoId == grupoId
                        orderby r.Estado, r.GrupoId, r.Secuencia, r.Nombre
                        select new LineaBusiness
                        {
                            Id = r.Id,
                            Codigo = r.Codigo,
                            Nombre = r.Nombre,
                            Secuencia = r.Secuencia,
                            Tipo = (LineaTipo)r.Tipo,
                            GrupoId = r.GrupoId,
                            Estado = r.Estado
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaBusiness / GetByGrupoActivas", exception);
            }
        }

        #endregion
    }
}