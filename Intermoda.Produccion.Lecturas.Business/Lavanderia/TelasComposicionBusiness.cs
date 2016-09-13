using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class TelasComposicionBusiness
    {
        private static LavanderiaEntities _context;
        private static LBDATPROEntities _lbdatPro;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        #endregion

        #region Methods

        public static TelasComposicionBusiness Insert(TelasComposicionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new TelasComposicion()
                    {
                        TelaComposicionId = model.Id,
                        TelaComposicionNombre = model.Nombre,
                        TelaComposicionDescripcion = model.Descripcion
                    };
                    _context.TelasComposicionSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.TelaComposicionId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / Insert", exception);
            }
        }

        public static TelasComposicionBusiness Update(TelasComposicionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.TelasComposicionSet
                               where r.TelaComposicionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.TelaComposicionNombre = model.Nombre;
                        reg.TelaComposicionDescripcion = model.Descripcion;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de TelasComposicion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / Update", exception);
            }
        }

        public static void Delete(TelasComposicionBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.TelasComposicionSet
                               where r.TelaComposicionId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TelasComposicionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de TelasComposicion con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int telasComposicionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.TelasComposicionSet
                               where r.TelaComposicionId == telasComposicionId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.TelasComposicionSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de TelasComposicion con Id: {telasComposicionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / Delete (id)", exception);
            }
        }

        public static TelasComposicionBusiness Get(int telasComposicionId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.TelasComposicionSet
                                 where r.TelaComposicionId == telasComposicionId
                                 select new TelasComposicionBusiness
                                 {
                                     Id = r.TelaComposicionId,
                                     Nombre = r.TelaComposicionNombre,
                                     Descripcion = r.TelaComposicionDescripcion
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de TelasComposicion con Id: {telasComposicionId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / Get", exception);
            }
        }

        public static TelasComposicionBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.TelasComposicionSet
                            select new TelasComposicionBusiness
                            {
                                Id = r.TelaComposicionId,
                                Nombre = r.TelaComposicionNombre,
                                Descripcion = r.TelaComposicionDescripcion
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}