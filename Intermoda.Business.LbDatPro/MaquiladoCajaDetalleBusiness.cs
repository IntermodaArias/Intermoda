using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class MaquiladoCajaDetalleBusiness
    {
        private static LBDATPROEntities _context;

        private const short Compania = 1;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int MaquiladoCajaId { get; set; }

        [DataMember]
        public short CompaniaId { get; set; }

        [DataMember]
        public string TallaId { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        [DataMember]
        public TallaBusiness Talla { get; set; }

        #endregion

        #region Methods

        public static MaquiladoCajaDetalleBusiness Insert(MaquiladoCajaDetalleBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = new MaquiladoCajaDetalle()
                    {
                        MaquiladoCajaId = model.MaquiladoCajaId,
                        CompaniaId = model.CompaniaId,
                        TallaId = model.TallaId,
                        Cantidad = model.Cantidad
                    };
                    _context.MaquiladoCajaDetalleSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Talla = _context.FACTALLSet
                        .Where(r => r.CiaCod == model.CompaniaId)
                        .Where(r => r.FacCTall == model.TallaId)
                        .Select(r => new TallaBusiness
                        {
                            CompaniaId = r.CiaCod,
                            Codigo = r.FacCTall,
                            Nombre = r.FacDTall,
                            Secuencia = r.FacSecTal ?? 0
                        })
                        .FirstOrDefault();

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaDetalleBusiness / Insert", exception);
            }
        }

        public static MaquiladoCajaDetalleBusiness Update(MaquiladoCajaDetalleBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.MaquiladoCajaDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.MaquiladoCajaId = model.MaquiladoCajaId;
                        reg.CompaniaId = model.CompaniaId;
                        reg.TallaId = model.TallaId;
                        reg.Cantidad = model.Cantidad;

                        _context.SaveChanges();

                        model.Talla = _context.FACTALLSet
                        .Where(r => r.CiaCod == model.CompaniaId)
                        .Where(r => r.FacCTall == model.TallaId)
                        .Select(r => new TallaBusiness
                        {
                            CompaniaId = r.CiaCod,
                            Codigo = r.FacCTall,
                            Nombre = r.FacDTall,
                            Secuencia = r.FacSecTal ?? 0
                        })
                        .FirstOrDefault();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCajaDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaDetalleBusiness / Update", exception);
            }
        }

        public static void Delete(MaquiladoCajaDetalleBusiness model)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.MaquiladoCajaDetalleSet
                               where r.Id == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.MaquiladoCajaDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCajaDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaDetalleBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int maquiladoCajaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var reg = (from r in _context.MaquiladoCajaDetalleSet
                               where r.Id == maquiladoCajaId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.MaquiladoCajaDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCajaDetalle con Id: {maquiladoCajaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaDetalleBusiness / Delete (id)", exception);
            }
        }

        public static MaquiladoCajaDetalleBusiness Get(int maquiladoCajaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var model = (from r in _context.MaquiladoCajaDetalleSet
                        where r.Id == maquiladoCajaId
                        select new MaquiladoCajaDetalleBusiness
                        {
                            Id = r.Id,
                            MaquiladoCajaId = r.MaquiladoCajaId,
                            CompaniaId = r.CompaniaId,
                            TallaId = r.TallaId,
                            Cantidad = r.Cantidad
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Talla = _context.FACTALLSet
                            .Where(r => r.CiaCod == model.CompaniaId)
                            .Where(r => r.FacCTall == model.TallaId)
                            .Select(r => new TallaBusiness
                            {
                                CompaniaId = r.CiaCod,
                                Codigo = r.FacCTall,
                                Nombre = r.FacDTall,
                                Secuencia = r.FacSecTal ?? 0
                            })
                            .FirstOrDefault();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de MaquiladoCajaDetalle con Id: {maquiladoCajaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaDetalleBusiness / Get", exception);
            }
        }

        public static MaquiladoCajaDetalleBusiness[] GetByMaquiladoCaja(int maquiladoCajaId)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    return (from r in _context.MaquiladoCajaDetalleSet
                        join t in _context.FACTALLSet on
                            new {a = r.CompaniaId, b = r.TallaId} equals
                            new {a = t.CiaCod, b = t.FacCTall}
                        orderby r.MaquiladoCajaId, t.FacSecTal
                        select new MaquiladoCajaDetalleBusiness
                        {
                            Id = r.Id,
                            MaquiladoCajaId = r.MaquiladoCajaId,
                            CompaniaId = r.CompaniaId,
                            TallaId = r.TallaId,
                            Cantidad = r.Cantidad,
                            Talla = new TallaBusiness
                            {
                                CompaniaId = t.CiaCod,
                                Codigo = t.FacCTall,
                                Nombre = t.FacDTall,
                                Secuencia = t.FacSecTal ?? 0
                            }
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaDetalleBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}