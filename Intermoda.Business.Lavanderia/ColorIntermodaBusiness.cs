using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ColorIntermodaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        #endregion

        #region Methods

        public static ColorIntermodaBusiness Insert(ColorIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new ColoresIntermoda()
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
                throw new Exception("ColorIntermodaBusiness / Insert", exception);
            }
        }

        public static ColorIntermodaBusiness Update(ColorIntermodaBusiness model)
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
                        reg.ColorIntermodaNombre = model.Nombre;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ColorIntermoda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermodaBusiness / Update", exception);
            }
        }

        public static void Delete(ColorIntermodaBusiness model)
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
                    throw new Exception($"No se ha encontrado registro de ColorIntermoda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermodaBusiness / Delete (model)", exception);
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
                    throw new Exception($"No se ha encontrado registro de ColorIntermoda con Id: {colorIntermodaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermodaBusiness / Delete (id)", exception);
            }
        }

        public static ColorIntermodaBusiness Get(int colorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ColoresIntermodaSet
                        where r.ColorIntermodaId == colorIntermodaId
                        select new ColorIntermodaBusiness
                        {
                            Id = r.ColorIntermodaId,
                            Nombre = r.ColorIntermodaNombre
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ColorIntermoda con Id: {colorIntermodaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermodaBusiness / Get", exception);
            }
        }

        public static ColorIntermodaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.ColoresIntermodaSet
                        select new ColorIntermodaBusiness
                        {
                            Id = r.ColorIntermodaId,
                            Nombre = r.ColorIntermodaNombre
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermodaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}