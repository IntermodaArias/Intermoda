using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Produccion.Lecturas.Business.LbDatPro
{
    [DataContract]
    public class ClaseBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaCodigo { get; set; }           // CIACOD

        [DataMember]
        public string Codigo { get; set; }                  // MprCodCla

        [DataMember]
        public string ManejoInventario { get; set; }        // MprCanInv

        [DataMember]
        public string Descripcion { get; set; }             // MprDesCla

        [DataMember]
        public string CuentaContable { get; set; }          // MprCtaCon

        [DataMember]
        public short? RotacionBaja { get; set; }            // MapRotBaj

        [DataMember]
        public short? SinRotacion { get; set; }             // MapRotSin

        [DataMember]
        public string Estado { get; set; }                  // MprClaSts

        [DataMember]
        public string DetalleMaestra { get; set; }          // MprClaDet

        [DataMember]
        public short DiasSinMovimiento { get; set; }        // MprClaDia

        [DataMember]
        public short? AgrupacionCodigo { get; set; }       // MprCodAgr

        [DataMember]
        public string AgruparClase { get; set; }            // MprGrpCla

        [DataMember]
        public string GrupoNombre { get; set; }             // MprGrpNom

        [DataMember]
        public decimal? MprClaSig { get; set; }

        [DataMember]
        public string MprClaAx { get; set; }

        [DataMember]
        public string MprClaDl { get; set; }

        #endregion

        #region Methods

        public static ClaseBusiness Insert(ClaseBusiness model)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
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
                //using (_context = new LBDATPROEntities())
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
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.CLASESet
                //               where r.Id == model.Id
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

        public static void Delete(int claseCodigo)
        {
            try
            {
                throw new NotImplementedException();
                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.CLASESet
                //               where r.Id == claseCodigo
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
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.CLASESet
                        where r.CIACOD == Compania &&
                              r.MprCodCla == claseCodigo
                        select new ClaseBusiness
                        {
                            Codigo = r.MprCodCla,
                            ManejoInventario = r.MprCanInv,
                            Descripcion = r.MprDesCla,
                            CuentaContable = r.MprCtaCon,
                            RotacionBaja = r.MapRotBaj,
                            SinRotacion = r.MapRotSin,
                            Estado = r.MprClaSts,
                            AgruparClase = r.MprClaDet,
                            DiasSinMovimiento = r.MprClaDia,
                            AgrupacionCodigo = r.MprCodAgr,
                            GrupoNombre = r.MprGrpNom,
                            MprClaSig = r.MprClaSig,
                            MprClaAx = r.MprClaAX,
                            MprClaDl = r.MprClaDL
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
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.CLASESet
                            where r.CIACOD == Compania
                            select new ClaseBusiness
                            {
                                Codigo = r.MprCodCla,
                                ManejoInventario = r.MprCanInv,
                                Descripcion = r.MprDesCla,
                                CuentaContable = r.MprCtaCon,
                                RotacionBaja = r.MapRotBaj,
                                SinRotacion = r.MapRotSin,
                                Estado = r.MprClaSts,
                                AgruparClase = r.MprClaDet,
                                DiasSinMovimiento = r.MprClaDia,
                                AgrupacionCodigo = r.MprCodAgr,
                                GrupoNombre = r.MprGrpNom,
                                MprClaSig = r.MprClaSig,
                                MprClaAx = r.MprClaAX,
                                MprClaDl = r.MprClaDL
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