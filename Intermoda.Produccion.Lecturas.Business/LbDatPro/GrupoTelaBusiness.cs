using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Produccion.Lecturas.Business.LbDatPro
{
    [DataContract]
    public class GrupoTelaBusiness
    {
        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public string Codigo { get; set; }              // FacCodGrut

        [DataMember]
        public string Descripcion { get; set; }         // FacDesGrut

        [DataMember]
        public short Estado { get; set; }               // GruSts

        [DataMember]
        public short? UltimoNumero { get; set; }         // FacGruUltNum

        [DataMember]
        public short? Reposo { get; set; }               // FacReposo

        #endregion

        #region Methods

        public static GrupoTelaBusiness Insert(GrupoTelaBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = new GRUTEL
                //    {
                //    };
                //    _context.GRUTELSet.Add(reg);
                //    _context.SaveChanges();

                //    model.Id = reg.Id;

                //    return model;
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoTelaBusiness / Insert", exception);
            }
        }

        public static GrupoTelaBusiness Update(GrupoTelaBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.GRUTELSet
                //               where r.FacCodGrut == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {

                //        _context.SaveChanges();

                //        return model;
                //    }
                //    throw new Exception($"No se ha encontrado registro de GrupoTela con Id: {model.Codigo}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoTelaBusiness / Update", exception);
            }
        }

        public static void Delete(GrupoTelaBusiness model)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.GRUTELSet
                //               where r.FacCodGrut == model.Codigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.GRUTELSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de GrupoTela con Id: {model.Id}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoTelaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(string grupoTelaCodigo)
        {
            try
            {
                throw new NotImplementedException();

                //using (_context = new LBDATPROEntities())
                //{
                //    var reg = (from r in _context.GRUTELSet
                //               where r.FacCodGrut == grupoTelaCodigo
                //               select r).FirstOrDefault();
                //    if (reg != null)
                //    {
                //        _context.GRUTELSet.Remove(reg);
                //        _context.SaveChanges();

                //        return;
                //    }
                //    throw new Exception($"No se ha encontrado registro de GrupoTela con Id: {grupoTelaCodigo}");
                //}
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoTelaBusiness / Delete (id)", exception);
            }
        }

        public static GrupoTelaBusiness Get(string grupoTelaCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.GRUTELSet
                                 where r.FacCodGrut == grupoTelaCodigo
                                 select new GrupoTelaBusiness
                                 {
                                     Codigo = r.FacCodGrut,
                                     Descripcion = r.FacDesGrut,
                                     Estado = r.GruSts,
                                     Reposo = r.FacReposo,
                                     UltimoNumero = r.FacGruUltN
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de GrupoTela con Id: {grupoTelaCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoTelaBusiness / Get", exception);
            }
        }

        public static GrupoTelaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.GRUTELSet
                            select new GrupoTelaBusiness
                            {
                                Codigo = r.FacCodGrut,
                                Descripcion = r.FacDesGrut,
                                Estado = r.GruSts,
                                Reposo = r.FacReposo,
                                UltimoNumero = r.FacGruUltN
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoTelaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}