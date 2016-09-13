using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class SubClaseBusiness
    {
        private static LavanderiaEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaCodigo { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Estado { get; set; }

        #endregion

        #region Methods

        public static SubClaseBusiness Insert(SubClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = new SUBCLASE
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
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.SUBCLASESet
                //               where r.CIACOD == model.CompaniaCodigo &&
                //               r.MprCodSCla == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de SubClase con Id: {model.Codigo}");
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
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.SUBCLASESet
                //               where r.CIACOD == Compania && 
                //               r.MprCodSCla == model.Codigo
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

        public static void Delete(string subClaseCodigo)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.SUBCLASESet
                //               where r.CIACOD == Compania &&
                //               r.MprCodSCla == subClaseCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.SUBCLASESet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de SubClase con Id: {subClaseCodigo}");
                //}
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
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.SUBCLASESet
                        where r.CIACOD == Compania &&
                              r.MprCodSCla == subClaseCodigo
                        select new SubClaseBusiness
                        {
                            CompaniaCodigo = r.CIACOD,
                            Codigo = r.MprCodSCla,
                            Descripcion = r.MprDesSCla,
                            Estado = r.MprSClaSts
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
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.SUBCLASESet
                        where r.CIACOD == Compania
                        select new SubClaseBusiness
                        {
                            CompaniaCodigo = r.CIACOD,
                            Codigo = r.MprCodSCla,
                            Descripcion = r.MprDesSCla,
                            Estado = r.MprSClaSts
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