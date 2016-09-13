using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class TelaColorIntermodaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int ColorIntermodaId { get; set; }

        [DataMember]
        public string TelaId { get; set; }

        [DataMember]
        public int? MaterialId { get; set; }

        //

        [DataMember]
        public ColorIntermodaBusiness ColorIntermoda { get; private set; }

        [DataMember]
        public TelaBusiness Tela { get; private set; }

        [DataMember]
        public CatalogoBusiness Material { get; set; }

        #endregion

        #region Methods

        public static TelaColorIntermodaBusiness Insert(TelaColorIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new TelasColorIntermoda
                    {
                        ColorIntermodaId = model.ColorIntermodaId,
                        TelaId = model.TelaId,
                        MaterialTelaId = model.MaterialId
                    };
                    _context.TelasColorIntermodaSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.TelaColorIntermodaId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / Insert", exception);
            }
        }

        public static TelaColorIntermodaBusiness Update(TelaColorIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.TelasColorIntermodaSet
                               where r.TelaColorIntermodaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ColorIntermodaId = model.ColorIntermodaId;
                        reg.TelaId = model.TelaId;
                        reg.MaterialTelaId = model.MaterialId;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de TelaColorIntermoda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / Update", exception);
            }
        }

        public static void Delete(TelaColorIntermodaBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.TelasColorIntermodaSet
                               where r.TelaColorIntermodaId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TelasColorIntermodaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de TelaColorIntermoda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int telaColorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.TelasColorIntermodaSet
                               where r.TelaColorIntermodaId == telaColorIntermodaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TelasColorIntermodaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de TelaColorIntermoda con Id: {telaColorIntermodaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / Delete (id)", exception);
            }
        }

        public static TelaColorIntermodaBusiness Get(int telaColorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.TelasColorIntermodaSet
                        where r.TelaColorIntermodaId == telaColorIntermodaId
                        select new TelaColorIntermodaBusiness
                        {
                            Id = r.TelaColorIntermodaId,
                            ColorIntermodaId = r.ColorIntermodaId,
                            MaterialId = r.MaterialTelaId,
                            TelaId = r.TelaId
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.ColorIntermoda = ColorIntermodaBusiness.Get(model.ColorIntermodaId);
                        model.Material = model.MaterialId != null
                            ? CatalogoBusiness.Get(model.MaterialId.Value)
                            : null;
                        model.Tela = TelaBusiness.Get(model.TelaId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de TelaColorIntermoda con Id: {telaColorIntermodaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / Get", exception);
            }
        }

        public static TelaColorIntermodaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.TelasColorIntermodaSet
                        select new TelaColorIntermodaBusiness
                        {
                            Id = r.TelaColorIntermodaId,
                            ColorIntermodaId = r.ColorIntermodaId,
                            MaterialId = r.MaterialTelaId,
                            TelaId = r.TelaId
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.ColorIntermoda = ColorIntermodaBusiness.Get(model.ColorIntermodaId);
                        model.Material = model.MaterialId != null
                            ? CatalogoBusiness.Get(model.MaterialId.Value)
                            : null;
                        model.Tela = TelaBusiness.Get(model.TelaId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / GetAll", exception);
            }
        }

        public static TelaColorIntermodaBusiness[] GetByColorIntermoda(int colorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.TelasColorIntermodaSet
                                 where r.ColorIntermodaId == colorIntermodaId
                                 orderby r.ColorIntermodaId
                                 select new TelaColorIntermodaBusiness
                                 {
                                     Id = r.TelaColorIntermodaId,
                                     ColorIntermodaId = r.ColorIntermodaId,
                                     MaterialId = r.MaterialTelaId,
                                     TelaId = r.TelaId
                                 }).ToArray();
                    foreach (var model in lista)
                    {
                        model.ColorIntermoda = ColorIntermodaBusiness.Get(model.ColorIntermodaId);
                        model.Material = model.MaterialId != null
                            ? CatalogoBusiness.Get(model.MaterialId.Value)
                            : null;
                        model.Tela = TelaBusiness.Get(model.TelaId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermodaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}