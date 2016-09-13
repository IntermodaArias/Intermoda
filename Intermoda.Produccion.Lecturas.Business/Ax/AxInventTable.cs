using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.AX.Data;

namespace Intermoda.Produccion.Lecturas.Business.Ax
{
    [DataContract]
    public class AxInventTable
    {
        private static Ax2012R2Entities _context;

        #region Properties

        [DataMember]
        public string ItemId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NameAlias { get; set; }

        [DataMember]
        public long Product { get; set; }

        #endregion

        #region Methods

        public static AxInventTable Get(string itemId)
        {
            try
            {
                using (_context = new Ax2012R2Entities())
                {
                    var model = (from a in _context.INVENTTABLESet
                        where a.ITEMID == itemId
                        select a).FirstOrDefault();

                    if (model == null)
                        return null;

                    var modelTranslation = (from r in _context.ECORESPRODUCTTRANSLATIONSet
                        where r.PRODUCT == model.PRODUCT &&
                              r.LANGUAGEID == "es-hn"
                        select r).FirstOrDefault();

                    if (modelTranslation == null)
                    {
                        modelTranslation = (from r in _context.ECORESPRODUCTTRANSLATIONSet
                            where r.PRODUCT == model.PRODUCT &&
                                  r.LANGUAGEID == "es"
                            select r).FirstOrDefault();
                        if (modelTranslation == null)
                        {
                            modelTranslation = (from r in _context.ECORESPRODUCTTRANSLATIONSet
                                where r.PRODUCT == model.PRODUCT
                                select r).FirstOrDefault();
                        }
                    }

                    var reg = new AxInventTable
                    {
                        ItemId = model.ITEMID,
                        Name = modelTranslation == null ? model.NAMEALIAS : modelTranslation.NAME,
                        NameAlias = model.NAMEALIAS,
                        Product = model.PRODUCT
                    };

                    return reg;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AxInventTable / Get", exception);
            }
        }

        #endregion
    }
}