using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class TallaBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public string Codigo { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public int Secuencia { get; set; }

        #endregion

        #region Methods

        public static TallaBusiness Insert(TallaBusiness model)
        {
            throw new NotImplementedException();
        }

        public static TallaBusiness Update(TallaBusiness model)
        {
            throw new NotImplementedException();
        }

        public static void Delete(TallaBusiness model)
        {
            throw new NotImplementedException();
        }

        public static void Delete(int tallaId)
        {
            throw new NotImplementedException();
        }

        public static TallaBusiness Get(short companiaId, string tallaCodigo)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = _context.FACTALLSet
                        .Where(r => r.CiaCod == companiaId)
                        .Where(r => r.FacCTall == tallaCodigo)
                        .OrderBy(r => r.CiaCod)
                        .ThenBy(r => r.FacSecTal)
                        .Select(r => new TallaBusiness
                        {
                            CompaniaId = r.CiaCod,
                            Codigo = r.FacCTall,
                            Nombre = r.FacDTall,
                            Secuencia = r.FacSecTal ?? 0
                        })
                        .FirstOrDefault();
                        
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Talla con Id: {companiaId} / {tallaCodigo}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TallaBusiness / Get", exception);
            }
        }

        public static TallaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return _context.FACTALLSet
                        .Where(r => r.CiaCod == Compania)
                        .OrderBy(r => r.CiaCod)
                        .ThenBy(r => r.FacSecTal)
                        .Select(r => new TallaBusiness
                        {
                            CompaniaId = r.CiaCod,
                            Codigo = r.FacCTall,
                            Nombre = r.FacDTall,
                            Secuencia = r.FacSecTal ?? 0
                        })
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TallaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}