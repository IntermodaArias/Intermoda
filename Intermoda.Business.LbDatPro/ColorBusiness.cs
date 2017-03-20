using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class ColorBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public string Codigo { get; set; }              // FacCCol

        [DataMember]
        public string Descripcion { get; set; }         // FacDCol

        [DataMember]
        public string ColorAx1 { get; set; }            // AxColorId01

        //[DataMember]
        //public string ColorAx2 { get; set; }            // AxColorId02

        #endregion

        #region Methods

        public static ColorBusiness Insert(ColorBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = new FACCOL()
                //    {
                //    };
                //    _context.FACCOLSet.Add(reg);
                //    _context.SaveChanges();

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ColorBusiness / Insert", exception);
            }
        }

        public static ColorBusiness Update(ColorBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.FACCOLSet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Color con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ColorBusiness / Update", exception);
            }
        }

        public static void Delete(ColorBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.FACCOLSet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.FACCOLSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Color con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ColorBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int colorCodigo)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.FACCOLSet
                //               where r.Id == colorCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.ColorSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Color con Id: {colorCodigo}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ColorBusiness / Delete (id)", exception);
            }
        }

        public static ColorBusiness Get(string colorCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.FACCOLSet
                                 where r.CIACOD == Compania &&
                                 r.FacCCol == colorCodigo
                                 select new ColorBusiness
                                 {
                                     Codigo = r.FacCCol,
                                     Descripcion = r.FacDCol,
                                     ColorAx1 = r.AxColorId01
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Color con Id: {colorCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorBusiness / Get", exception);
            }
        }

        public static ColorBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.FACCOLSet
                            where r.CIACOD == Compania
                            select new ColorBusiness
                            {
                                Codigo = r.FacCCol,
                                Descripcion = r.FacDCol,
                                ColorAx1 = r.AxColorId01
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}