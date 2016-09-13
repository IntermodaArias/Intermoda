using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Produccion.Lecturas.Business.LbDatPro
{
    [DataContract]
    public class CatalogBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public int Codigo { get; set; }                         // MapCodMat

        [DataMember]
        public string DescripcionLarga { get; set; }            // CataDesLar

        [DataMember]
        public string DescripcionCorta { get; set; }            // CataDesCor

        [DataMember]
        public string UnidadMedidaCompra { get; set; }          // MedCompra

        [DataMember]
        public string UnidadMedidaConsumo { get; set; }         // MedConsum

        [DataMember]
        public string TipoRequisicionCodigo { get; set; }       // TipRCod

        [DataMember]
        public string GrupoCodigo { get; set; }                 // CataGru

        [DataMember]
        public string CuentaContableHojaCosto { get; set; }     // MapCtaCont

        [DataMember]
        public string CuentaContableTipo { get; set; }          // MapCtaVF

        [DataMember]
        public string CuentaContableInventario { get; set; }    // MapCtaCont2

        [DataMember]
        public string RepuestoNumero { get; set; }              // MapNum1Rep

        [DataMember]
        public string TelaCodigo { get; set; }                  // PrdCodTel

        #endregion

        #region Methods

        public static CatalogBusiness Insert(CatalogBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = new CATALOG();
                //    {
                //    };
                //    _context.CATALOGSet.Add(reg);
                //    _context.SaveChanges();

                //    model.Codigo = reg.MapCodMat;

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogBusiness / Insert", exception);
            }
        }

        public static CatalogBusiness Update(CatalogBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.CATALOGSet
                //               where r.MapCodMat == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Catalog con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogBusiness / Update", exception);
            }
        }

        public static void Delete(CatalogBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.CATALOGSet
                //               where r.MapCodMat == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.CATALOGSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Catalog con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int catalogCodigo)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.CATALOGSet
                //               where r.MapCodMat == catalogCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.CATALOGSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Catalog con Id: {catalogCodigo}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogBusiness / Delete (id)", exception);
            }
        }

        public static CatalogBusiness Get(int catalogCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.CATALOGSet
                                 where r.MapCodMat == catalogCodigo
                                 select new CatalogBusiness
                                 {
                                     Codigo = r.MapCodMat,
                                     DescripcionCorta = r.CataDesCor,
                                     DescripcionLarga = r.CataDesLar,
                                     UnidadMedidaCompra = r.MedCompra,
                                     UnidadMedidaConsumo = r.MedConsum,
                                     TipoRequisicionCodigo = r.TipRCod,
                                     GrupoCodigo = r.CataGru,
                                     CuentaContableHojaCosto = r.MapCtaCont,
                                     CuentaContableTipo = r.MapCtaVF,
                                     CuentaContableInventario = r.MapCtaCon2,
                                     RepuestoNumero = r.MapNum1Rep,
                                     TelaCodigo = r.PrdCodTel
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Catalog con Id: {catalogCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogBusiness / Get", exception);
            }
        }

        public static CatalogBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.CATALOGSet
                            select new CatalogBusiness
                            {
                                Codigo = r.MapCodMat,
                                DescripcionCorta = r.CataDesCor,
                                DescripcionLarga = r.CataDesLar,
                                UnidadMedidaCompra = r.MedCompra,
                                UnidadMedidaConsumo = r.MedConsum,
                                TipoRequisicionCodigo = r.TipRCod,
                                GrupoCodigo = r.CataGru,
                                CuentaContableHojaCosto = r.MapCtaCont,
                                CuentaContableTipo = r.MapCtaVF,
                                CuentaContableInventario = r.MapCtaCon2,
                                RepuestoNumero = r.MapNum1Rep,
                                TelaCodigo = r.PrdCodTel
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogBusiness / GetAll", exception);
            }
        }


        #endregion
    }
}