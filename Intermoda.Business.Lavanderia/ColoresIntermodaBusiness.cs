using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ColoresIntermodaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        #endregion

        #region Methods

        public static ColoresIntermodaBusiness Insert(ColoresIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (ValidarColorIntermodaDuplicado(model.Nombre))
                        throw new Exception("El color que desea ingresar ya existe");

                    var reg = new ColoresIntermoda
                    {
                        ColorIntermodaNombre = model.Nombre
                    };
                    _context.ColoresIntermodaSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ColorIntermodaId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / Insert", exception);
            }
        }

        public static ColoresIntermodaBusiness Update(ColoresIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    if (ValidarColorIntermodaDuplicado(model.Nombre))
                        throw new Exception("El color que desea ingresar ya existe");

                    var reg = (from r in _context.ColoresIntermodaSet
                               where r.ColorIntermodaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ColorIntermodaNombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ColoresIntermoda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / Update", exception);
            }
        }

        public static void Delete(ColoresIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ColoresIntermodaSet
                               where r.ColorIntermodaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ColoresIntermodaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ColoresIntermoda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int colorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ColoresIntermodaSet
                               where r.ColorIntermodaId == colorIntermodaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ColoresIntermodaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ColoresIntermoda con Id: {colorIntermodaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / Delete (id)", exception);
            }
        }

        public static ColoresIntermodaBusiness Get(int colorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ColoresIntermodaSet
                                 where r.ColorIntermodaId == colorIntermodaId
                                 select new ColoresIntermodaBusiness
                                 {
                                     Id = r.ColorIntermodaId,
                                     Nombre = r.ColorIntermodaNombre
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ColoresIntermoda con Id: {colorIntermodaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / Get", exception);
            }
        }

        public static ColoresIntermodaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.ColoresIntermodaSet
                            select new ColoresIntermodaBusiness
                            {
                                Id = r.ColorIntermodaId,
                                Nombre = r.ColorIntermodaNombre
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / GetAll", exception);
            }
        }

        private static bool ValidarColorIntermodaDuplicado(string lavadoNombre)
        {
            try
            {
                return (from r in _context.ColoresIntermodaSet
                    where r.ColorIntermodaNombre == lavadoNombre
                    select r).Any();
            }
            catch (Exception exception)
            {
                throw new Exception("ColoresIntermodaBusiness / ValidaColorIntermodaDuplicado", exception);
            }
        }

        #endregion
    }
}