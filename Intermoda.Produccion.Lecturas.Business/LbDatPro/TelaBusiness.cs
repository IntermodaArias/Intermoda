using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Produccion.Lecturas.Business.LbDatPro
{
    [DataContract]
    public class TelaBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public string Codigo { get; set; }              // FacCodTel

        [DataMember]
        public string Descripcion { get; set; }         // FacDesTel

        [DataMember]
        public string GrupoTelaCodigo { get; set; }     // FacCodGrut

        [DataMember]
        public short? UltimaLinea { get; set; }          // FacUltLin

        [DataMember]
        public short? UltimaLineaStretch { get; set; }   // FacUktLStr

        [DataMember]
        public string DescripcionVenta { get; set; }    // TelDesVta

        //

        [DataMember]
        public GrupoTelaBusiness GrupoTela { get; private set; }

        #endregion

        #region Methods

        public static TelaBusiness Insert(TelaBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = new TELAR5()
                //    {
                //    };
                //    _context.TELAR5Set.Add(reg);
                //    _context.SaveChanges();

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("TelaBusiness / Insert", exception);
            }
        }

        public static TelaBusiness Update(TelaBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.TELAR5Set
                //               where r.FacCodTel == model.GrupoTelaCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Tela con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("TelaBusiness / Update", exception);
            }
        }

        public static void Delete(TelaBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.TELAR5Set
                //               where r.FacCodTel == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.TELAR5Set.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Tela con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("TelaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(string telaCodigo)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.TELAR5Set
                //               where r.FacCodTel == telaCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.TELAR5Set.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de Tela con Id: {telaCodigo}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("TelaBusiness / Delete (id)", exception);
            }
        }

        public static TelaBusiness Get(string telaCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.TELAR5Set
                                 where r.FacCodTel == telaCodigo
                                 select new TelaBusiness
                                 {
                                     Codigo = r.FacCodTel,
                                     Descripcion = r.FacDesTel,
                                     DescripcionVenta = r.TelDesVta,
                                     GrupoTelaCodigo = r.FacCodGrut,
                                     UltimaLinea = r.FacUltLin,
                                     UltimaLineaStretch = r.FacUltLStr
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.GrupoTela = GrupoTelaBusiness.Get(model.GrupoTelaCodigo);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Tela con Id: {telaCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaBusiness / Get", exception);
            }
        }

        public static TelaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var lista = (from r in _context.TELAR5Set
                        select new TelaBusiness
                        {
                            Codigo = r.FacCodTel,
                            Descripcion = r.FacDesTel,
                            DescripcionVenta = r.TelDesVta,
                            GrupoTelaCodigo = r.FacCodGrut,
                            UltimaLinea = r.FacUltLin,
                            UltimaLineaStretch = r.FacUltLStr
                        }).ToArray();
                    foreach (var model in lista)
                    {
                        model.GrupoTela = GrupoTelaBusiness.Get(model.GrupoTelaCodigo);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}