using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class SubClaseBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public string Codigo { get; set; }              // MprCodSCla

        [DataMember]
        public string Descripcion { get; set; }         // MprDesSCla

        [DataMember]
        public string Estado { get; set; }              // MprSClaSts

        [DataMember]
        public string SubClaseAx { get; set; }          // MprSClaAX

        #endregion

        #region Methods

        public static SubClaseBusiness Insert(SubClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = new SUBCLASE()
                //    {
                //    };
                //    _context.SUBCLASESet.Add(reg);
                //    _context.SaveChanges();

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("SubClaseBusiness / Insert", exception);
            }
        }

        public static SubClaseBusiness Update(SubClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.SUBCLASESet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de SubClase con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("SubClaseBusiness / Update", exception);
            }
        }

        public static void Delete(SubClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.SUBCLASESet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.SUBCLASESet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de SubClase con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("SubClaseBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int subClaseCodigo)
        {
            try
            {
                throw new NotImplementedException();
            //    using (_context = new LBDATPROEntities())
            //    {
            //        var reg = (from r in _context.SUBCLASESet
            //                   where r.Id == subClaseCodigo
            //                   select r).FirstOrDefault();
            //        if (reg != null)
            //        {
            //            _context.SUBCLASESet.Remove(reg);
            //            _context.SaveChanges();

            //            return;
            //        }
            //        throw new Exception($"No se ha encontrado registro de SubClase con Id: {subClaseCodigo}");
            //    }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClaseBusiness / Delete (id)", exception);
            }
        }

        public static SubClaseBusiness Get(string subClaseCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.SUBCLASESet
                                 where r.CIACOD == Compania &&
                                 r.MprCodSCla == subClaseCodigo
                                 select new SubClaseBusiness
                                 {
                                     Codigo = r.MprCodSCla,
                                     Descripcion = r.MprDesSCla,
                                     Estado = r.MprSClaSts,
                                     SubClaseAx = r.MprSClaAX
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de SubClase con Id: {subClaseCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClaseBusiness / Get", exception);
            }
        }

        public static SubClaseBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.SUBCLASESet
                            where r.CIACOD == Compania
                            select new SubClaseBusiness
                            {
                                Codigo = r.MprCodSCla,
                                Descripcion = r.MprDesSCla,
                                Estado = r.MprSClaSts,
                                SubClaseAx = r.MprSClaAX
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClaseBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}