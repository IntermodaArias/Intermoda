using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class MateriaPrimaColorBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        #endregion

        #region Methods

        public static MateriaPrimaColorBusiness Insert(MateriaPrimaColorBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = new MPRCOLOR
                //    {
                //    };
                //    _context.MPRCOLORSet.Add(reg);
                //    _context.SaveChanges();

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("MateriaPrimaColorBusiness / Insert", exception);
            }
        }

        public static MateriaPrimaColorBusiness Update(MateriaPrimaColorBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.MPRCOLORSet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de MateriaPrimaColor con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("MateriaPrimaColorBusiness / Update", exception);
            }
        }

        public static void Delete(MateriaPrimaColorBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.MPRCOLORSet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.MPRCOLORSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de MateriaPrimaColor con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("MateriaPrimaColorBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int id)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.MPRCOLORSet
                //               where r.Id == id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.MPRCOLORSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de MateriaPrimaColor con Id: {id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("MateriaPrimaColorBusiness / Delete (id)", exception);
            }
        }

        public static MateriaPrimaColorBusiness Get(string materiaPrimaColorCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.MPRCOLORSet
                                 where r.CiaCod == Compania &&
                                 r.MprCodCol == materiaPrimaColorCodigo
                                 select new MateriaPrimaColorBusiness
                                 {
                                     Codigo = r.MprCodCol,
                                     Descripcion = r.MprDesCol
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de MateriaPrimaColor con Id: {materiaPrimaColorCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MateriaPrimaColorBusiness / Get", exception);
            }
        }

        public static MateriaPrimaColorBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.MPRCOLORSet
                            select new MateriaPrimaColorBusiness
                            {
                                Codigo = r.MprCodCol,
                                Descripcion = r.MprDesCol
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MateriaPrimaColorBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}