using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class MaquiladoCajaBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public short OrdenAno { get; set; }

        [DataMember]
        public short OrdenNumero { get; set; }

        [DataMember]
        public int Numero { get; set; }

        #endregion

        #region Methods

        public static MaquiladoCajaBusiness Insert(MaquiladoCajaBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = new MaquiladoCaja
                    {
                        CompaniaId = model.CompaniaId,
                        OrdenAno = model.OrdenAno,
                        OrdenNumero = model.OrdenNumero,
                        Numero = model.Numero
                    };
                    _context.MaquiladoCajaSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / Insert", exception);
            }
        }

        public static MaquiladoCajaBusiness Update(MaquiladoCajaBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.MaquiladoCajaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.CompaniaId = model.CompaniaId;
                        reg.OrdenAno = model.OrdenAno;
                        reg.OrdenNumero = model.OrdenNumero;
                        reg.Numero = model.Numero;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCaja con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / Update", exception);
            }
        }

        public static void Delete(MaquiladoCajaBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.MaquiladoCajaSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.MaquiladoCajaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCaja con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int maquiladoCajaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.MaquiladoCajaSet
                               where r.Id == maquiladoCajaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.MaquiladoCajaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCaja con Id: {maquiladoCajaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / Delete (id)", exception);
            }
        }

        public static MaquiladoCajaBusiness Get(int maquiladoCajaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.MaquiladoCajaSet
                        where r.Id == maquiladoCajaId
                        select new MaquiladoCajaBusiness
                        {
                            Id = r.Id,
                            CompaniaId = r.CompaniaId,
                            OrdenAno = r.OrdenAno,
                            OrdenNumero = r.OrdenNumero,
                            Numero = r.Numero
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCaja con Id: {maquiladoCajaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / Get", exception);
            }
        }

        public static MaquiladoCajaBusiness[] GetAll()
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.MaquiladoCajaSet
                            orderby r.CompaniaId, r.OrdenAno, r.OrdenNumero, r.Numero
                        select new MaquiladoCajaBusiness
                        {
                            Id = r.Id,
                            CompaniaId = r.CompaniaId,
                            OrdenAno = r.OrdenAno,
                            OrdenNumero = r.OrdenNumero,
                            Numero = r.Numero
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / GetAll", exception);
            }
        }

        public static MaquiladoCajaBusiness[] GetAllByOrden(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.MaquiladoCajaSet
                        where r.CompaniaId == companiaId &&
                              r.OrdenAno == ordenAno &&
                              r.OrdenNumero == ordenNumero
                        orderby r.CompaniaId, r.OrdenAno, r.OrdenNumero, r.Numero
                        select new MaquiladoCajaBusiness
                        {
                            Id = r.Id,
                            CompaniaId = r.CompaniaId,
                            OrdenAno = r.OrdenAno,
                            OrdenNumero = r.OrdenNumero,
                            Numero = r.Numero
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}