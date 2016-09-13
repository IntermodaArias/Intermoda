using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ClaseBusiness
    {
        private static LavanderiaEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaCodigo { get; set; }           // CIACOD

        [DataMember]
        public string Codigo { get; set; }                  // MprCodCla

        [DataMember]
        public string ManejaInventario { get; set; }        // MprCanInv

        [DataMember]
        public string Descripcion { get; set; }             // MprDesCla

        [DataMember]
        public string CuentaContable { get; set; }          // MprCtaCon

        [DataMember]
        public short? RotacionBaja { get; set; }             // MapRotBaj

        [DataMember]
        public short? SinRotacion { get; set; }              // MapRotSin

        [DataMember]
        public string Estado { get; set; }                  // MprClaSts

        [DataMember]
        public string DetalleMaestra { get; set; }          // MprClaDet

        [DataMember]
        public short? AgrupacionCodigo { get; set; }         // MprCodAgr

        [DataMember]
        public short DiasSinMovimiento { get; set; }        // MprClaDia

        [DataMember]
        public string AgruparEnClaseCodigo { get; set; }    // MprGrpCla

        [DataMember]
        public string GrupoNombre { get; set; }             // MprGrpNom

        #endregion

        #region Methods

        public static ClaseBusiness Insert(ClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = new CLASE()
                //    {
                //    };
                //    _context.CLASESet.Add(reg);
                //    _context.SaveChanges();

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ClaseBusiness / Insert", exception);
            }
        }

        public static ClaseBusiness Update(ClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.CLASESet
                //               where r.Id == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Clase con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ClaseBusiness / Update", exception);
            }
        }

        public static void Delete(ClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.CLASESet
                //               where r.CIACOD == Compania &&
                //               r.MprCodCla == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.CLASESet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Clase con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ClaseBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(string claseCodigo)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.CLASESet
                //               where r.CIACOD == Compania &&
                //               r.MprCodCla == claseCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.CLASESet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Clase con Id: {claseCodigo}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("ClaseBusiness / Delete (id)", exception);
            }
        }

        public static ClaseBusiness Get(string claseCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CLASESet
                                 where r.CIACOD == Compania &&
                                 r.MprCodCla == claseCodigo
                                 select new ClaseBusiness
                                 {
                                     CompaniaCodigo = r.CIACOD,
                                     Codigo = r.MprCodCla,
                                     ManejaInventario = r.MprCanInv,
                                     Descripcion = r.MprDesCla,
                                     CuentaContable = r.MprCtaCon,
                                     RotacionBaja = r.MapRotBaj,
                                     SinRotacion = r.MapRotSin,
                                     Estado = r.MprClaSts,
                                     DetalleMaestra = r.MprClaDet,
                                     AgrupacionCodigo = r.MprCodAgr,
                                     DiasSinMovimiento = r.MprClaDia,
                                     AgruparEnClaseCodigo = r.MprGrpCla,
                                     GrupoNombre = r.MprGrpNom
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Clase con Id: {claseCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClaseBusiness / Get", exception);
            }
        }

        public static ClaseBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.CLASESet
                            where r.CIACOD == Compania 
                            select new ClaseBusiness
                            {
                                CompaniaCodigo = r.CIACOD,
                                Codigo = r.MprCodCla,
                                ManejaInventario = r.MprCanInv,
                                Descripcion = r.MprDesCla,
                                CuentaContable = r.MprCtaCon,
                                RotacionBaja = r.MapRotBaj,
                                SinRotacion = r.MapRotSin,
                                Estado = r.MprClaSts,
                                DetalleMaestra = r.MprClaDet,
                                AgrupacionCodigo = r.MprCodAgr,
                                DiasSinMovimiento = r.MprClaDia,
                                AgruparEnClaseCodigo = r.MprGrpCla,
                                GrupoNombre = r.MprGrpNom
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ClaseBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}