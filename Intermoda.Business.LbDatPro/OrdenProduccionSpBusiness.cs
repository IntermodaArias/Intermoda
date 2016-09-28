using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class OrdenProduccionSpBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public string CompaniaNombre { get; set; }

        [DataMember]
        public short Ano { get; set; }

        [DataMember]
        public short Numero { get; set; }

        [DataMember]
        public string Base { get; set; }

        [DataMember]
        public string Variante { get; set; }

        [DataMember]
        public string Tela { get; set; }

        [DataMember]
        public string Lavado { get; set; }

        [DataMember]
        public string Color { get; set; }

        [DataMember]
        public string EstadoId { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public int Prioriodad { get; set; }

        [DataMember]
        public string TelaProduccion { get; set; }

        [DataMember]
        public int Cantidad { get; set; }
        
        [DataMember]
        public short ModuloEnsamble { get; set; }

        [DataMember]
        public bool ConTela { get; set; }

        [DataMember]
        public virtual string OrdenProduccion => $"{Numero.ToString("0000")}-{Ano.ToString("00")}";

        [DataMember]
        public virtual string Referencia
            => $"{Base.Trim()}-{Variante.Trim()}-{Tela.Trim()}-{Lavado.Trim()}-{Color.Trim()}";

        #endregion

        #region Methods

        public static OrdenProduccionSpBusiness[] Get()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var ordenes = _context.WIPOrdenesProduccionB(Compania).ToList();
                    return ordenes
                        .OrderBy(r => r.CIACOD)
                        .ThenBy(r => r.PrdAnoCor)
                        .ThenBy(r => r.PrdNumCor)
                        .Select(orden =>
                            new OrdenProduccionSpBusiness
                            {
                                CompaniaId = orden.CIACOD,
                                CompaniaNombre = orden.CiaDes,
                                Base = orden.PrdCodArt,
                                Variante = orden.FacCodMdl,
                                Tela = orden.FacCodTel,
                                Lavado = orden.FacCodRef,
                                Color = orden.FacCCol,
                                EstadoId = orden.PrdStsCor,
                                Usuario = orden.PrdUsuPrd,
                                Prioriodad = orden.PrdPriCor ?? 0,
                                TelaProduccion = orden.PrdProTel,
                                ModuloEnsamble = orden.ModuloEnsamble ?? 0,
                                ConTela = orden.ConTela ?? false
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionSpBusiness / Get", exception);
            }
        }

        #endregion
    }
}