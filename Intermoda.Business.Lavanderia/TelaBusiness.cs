using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class TelaBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public string TelaCodigo { get; set; }

        [DataMember]
        public string TelaNombre { get; set; }

        [DataMember]
        public string ComposicionNombre { get; set; }

        [DataMember]
        public int MaterialCodigo { get; set; }

        [DataMember]
        public string TelaDescripcion { get; set; }

        #endregion

        #region Methods

        public static TelaBusiness Get(string telaCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from mat in _context.MATMSTSet
                        join catalog in _context.CATALOGSet on mat.MapCodMat equals catalog.MapCodMat
                        join telar in _context.TELAR5Set on mat.FacCodTel equals telar.FacCodTel
                        join grupo in _context.GRUTELSet on telar.FacCodGrut equals grupo.FacCodGrut
                        where mat.MprCodCla == "AA" &&
                        mat.FacCodTel == telaCodigo
                        orderby mat.MprCodCla, mat.FacCodTel
                        select new TelaBusiness
                        {
                            TelaCodigo = mat.FacCodTel,
                            TelaNombre = catalog.CataDesLar,
                            ComposicionNombre = grupo.FacDesGrut,
                            MaterialCodigo = mat.MapCodMat,
                            TelaDescripcion = mat.FacCodTel.Trim() + " " + telar.FacDesTel
                        }).FirstOrDefault();
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
                using (_context = new LavanderiaEntities())
                {
                    return (from mat in _context.MATMSTSet
                        join catalog in _context.CATALOGSet on mat.MapCodMat equals catalog.MapCodMat
                        join telar in _context.TELAR5Set on mat.FacCodTel equals telar.FacCodTel
                        join grupo in _context.GRUTELSet on telar.FacCodGrut equals grupo.FacCodGrut
                        where mat.MprCodCla == "AA"
                        select new TelaBusiness
                        {
                            TelaCodigo = mat.FacCodTel,
                            TelaNombre = catalog.CataDesLar,
                            ComposicionNombre = grupo.FacDesGrut,
                            MaterialCodigo = mat.MapCodMat,
                            TelaDescripcion = mat.FacCodTel.Trim() + " " + telar.FacDesTel
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Telas / GetAll", exception);
            }
        }

        public static TelaBusiness[] GetCombo()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.TELAR5Set
                        select new TelaBusiness
                        {
                            TelaCodigo = r.FacCodTel,
                            TelaNombre = "",
                            ComposicionNombre = "",
                            MaterialCodigo = 0,
                            TelaDescripcion = r.FacCodTel.Trim() + " " + r.FacDesTel
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Telas / GetAll", exception);
            }
        }

        public static string GetComposicionCodigo(string telaCodigo)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.TELAR5Set
                        where r.FacCodTel == telaCodigo
                        select r.FacCodGrut).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetComposicionCodigo", exception);
            }
        }

        #endregion
    }
}