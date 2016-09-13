using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class GrupoTelasBusines
    {
        private static LavanderiaEntities _context;
        private static LBDATPROEntities _lbdatPro;

        #region Properties

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        #endregion

        #region Methods

        public static GrupoTelasBusines[] GetByColorIntermoda(int colorIntermodaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    using (_lbdatPro = new LBDATPROEntities())
                    {

                        var regs = (from c in _context.TelasColorIntermodaSet
                            join t in _lbdatPro.TELAR5Set on
                                c.TelaId equals t.FacCodTel
                            join g in _lbdatPro.GRUTELSet on
                                t.FacCodGrut equals g.FacCodGrut
                            where c.ColorIntermodaId == colorIntermodaId
                            select new {g.FacCodGrut, g.FacDesGrut}).Distinct();

                        return regs.Select(x => new GrupoTelasBusines
                        {
                            Codigo = x.FacCodGrut,
                            Descripcion = x.FacDesGrut
                        }).ToArray();
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelasComposicionBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}