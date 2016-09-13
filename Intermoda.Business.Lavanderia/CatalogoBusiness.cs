using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class CatalogoBusiness
    {
        private static LavanderiaEntities _context;

        private const short CompaniaCodigo = 1;
        
        #region Properties

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Descripcion { get; set; }
        [DataMember]
        public string MedidaCompraCodigo { get; set; }
        [DataMember]
        public string MedidaConsumoCodigo { get; set; }
        [DataMember]
        public string TipoRequisicionCodigo { get; set; }
        [DataMember]
        public string GrupoCodigo { get; set; }
        [DataMember]
        public string TelaCodigo { get; set; }
        [DataMember]
        public string CuentaContableCodigo { get; set; }
        [DataMember]
        public string CuentaVariableFija { get; set; }
        [DataMember]
        public string CuentaContableInventarioCodigo { get; set; }
        [DataMember]
        public string RepuestoNumero { get; set; }

        [DataMember]
        public string ClaseId { get; private set; }
        [DataMember]
        public string SubClaseId { get; private set; }

        [DataMember]
        public ClaseBusiness Clase { get; private set; }
        [DataMember]
        public SubClaseBusiness SubClase { get; private set; }

        #endregion

        #region Methods

        public static CatalogoBusiness Insert(CatalogoBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = new CATALOG
                //    {
                //    };
                //    _context.CATALOGSet.Add(reg);
                //    _context.SaveChanges();

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / Insert", exception);
            }
        }

        public static CatalogoBusiness Update(CatalogoBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.CATALOGSet
                //               where r.MapCodMat == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Catalogo con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / Update", exception);
            }
        }

        public static void Delete(CatalogoBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.CATALOGSet
                //               where r.MapCodMat == model.Id
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.CATALOGSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Catalogo con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int ingredienteId)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LavanderiaEntities())
                //{
                //    var reg = (from r in _context.CATALOGSet
                //               where r.MapCodMat == ingredienteId
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.CATALOGSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Catalogo con Id: {Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / Delete (id)", exception);
            }
        }

        public static CatalogoBusiness Get(int ingredienteId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CATALOGSet
                        join m in _context.MATMSTSet on
                            new {a = CompaniaCodigo, b = r.MapCodMat} equals new {a = m.CIACOD, b = m.MapCodMat}
                        where r.MapCodMat == ingredienteId
                        select new CatalogoBusiness
                        {
                            Id = r.MapCodMat,
                            Nombre = r.CataDesCor,
                            Descripcion = r.CataDesLar,
                            MedidaCompraCodigo = r.MedCompra,
                            MedidaConsumoCodigo = r.MedConsum,
                            TipoRequisicionCodigo = r.TipRCod,
                            GrupoCodigo = r.CataGru,
                            CuentaContableCodigo = r.MapCtaCont,
                            CuentaVariableFija = r.MapCtaVF,
                            CuentaContableInventarioCodigo = r.MapCtaCon2,
                            RepuestoNumero = r.MapNum1Rep,
                            TelaCodigo = r.PrdCodTel,
                            ClaseId = m.MprCodCla,
                            SubClaseId = m.MprCodSCla
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Ingrediente con Id: {ingredienteId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / Get", exception);
            }
        }

        public static CatalogoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.CATALOGSet
                        join m in _context.MATMSTSet on
                            new {a = CompaniaCodigo, b = r.MapCodMat} equals new {a = m.CIACOD, b = m.MapCodMat}
                        select new CatalogoBusiness
                        {
                            Id = r.MapCodMat,
                            Nombre = r.CataDesCor,
                            Descripcion = r.CataDesLar,
                            MedidaCompraCodigo = r.MedCompra,
                            MedidaConsumoCodigo = r.MedConsum,
                            TipoRequisicionCodigo = r.TipRCod,
                            GrupoCodigo = r.CataGru,
                            CuentaContableCodigo = r.MapCtaCont,
                            CuentaVariableFija = r.MapCtaVF,
                            CuentaContableInventarioCodigo = r.MapCtaCon2,
                            RepuestoNumero = r.MapNum1Rep,
                            TelaCodigo = r.PrdCodTel,
                            ClaseId = m.MprCodCla,
                            SubClaseId = m.MprCodSCla
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / GetAll", exception);
            }
        }

        public static CatalogoBusiness GetByTela(string telaCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.CATALOGSet
                        join m in _context.MATMSTSet on
                            new {a = CompaniaCodigo, b = r.MapCodMat} equals new {a = m.CIACOD, b = m.MapCodMat}
                        where r.PrdCodTel == telaCodigo
                        select new CatalogoBusiness
                        {
                            Id = r.MapCodMat,
                            Nombre = r.CataDesCor,
                            Descripcion = r.CataDesLar,
                            MedidaCompraCodigo = r.MedCompra,
                            MedidaConsumoCodigo = r.MedConsum,
                            TipoRequisicionCodigo = r.TipRCod,
                            GrupoCodigo = r.CataGru,
                            CuentaContableCodigo = r.MapCtaCont,
                            CuentaVariableFija = r.MapCtaVF,
                            CuentaContableInventarioCodigo = r.MapCtaCon2,
                            RepuestoNumero = r.MapNum1Rep,
                            TelaCodigo = r.PrdCodTel,
                            ClaseId = m.MprCodCla,
                            SubClaseId = m.MprCodSCla
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Clase = ClaseBusiness.Get(model.ClaseId);
                        model.SubClase = SubClaseBusiness.Get(model.SubClaseId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Ingrediente con Id: {telaCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CatalogoBusiness / Get", exception);
            }
        }

        #endregion

    }
}