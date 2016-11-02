using System;
using System.Collections.Generic;
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

        [DataMember]
        public DateTime FechaApertura { get; set; }

        [DataMember]
        public DateTime FechaCierre { get; set; }

        [DataMember]
        public bool Estado { get; set; }

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
                        Numero = model.Numero,
                        FechaApertura = model.FechaApertura,
                        FechaCierre = model.FechaCierre,
                        Estado = model.Estado
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
                        reg.FechaApertura = model.FechaApertura;
                        reg.FechaCierre = model.FechaCierre;
                        reg.Estado = model.Estado;

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
                            Numero = r.Numero,
                            FechaApertura = r.FechaApertura,
                            FechaCierre = r.FechaCierre,
                            Estado = r.Estado
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
                            Numero = r.Numero,
                            FechaApertura = r.FechaApertura,
                            FechaCierre = r.FechaCierre,
                            Estado = r.Estado
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
                            Numero = r.Numero,
                            FechaApertura = r.FechaApertura,
                            FechaCierre = r.FechaCierre,
                            Estado = r.Estado
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / GetAll", exception);
            }
        }

        //

        public static MaquiladoEmpaqueBusiness[] GetDetalleByOrden(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                using (_context = new LBDATPROEntities())
                {
                    var lista = new List<MaquiladoEmpaqueBusiness>();

                    var cajas = (from r in _context.MaquiladoCajaSet
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
                            Numero = r.Numero,
                            FechaApertura = r.FechaApertura,
                            FechaCierre = r.FechaCierre,
                            Estado = r.Estado
                        }).ToList();
                    var detalle = (from r in _context.MaquiladoCajaDetalleSet
                                   join t in _context.FACTALLSet on
                                   new {a=r.CompaniaId, b=r.TallaId} equals 
                                   new {a=t.CiaCod, b=t.FacCTall}
                        where r.MaquiladoCaja.CompaniaId == companiaId &&
                              r.MaquiladoCaja.OrdenAno == ordenAno &&
                              r.MaquiladoCaja.OrdenNumero == ordenNumero
                        orderby r.MaquiladoCaja.CompaniaId,
                            r.MaquiladoCaja.OrdenAno,
                            r.MaquiladoCaja.OrdenNumero,
                            r.MaquiladoCaja.Numero
                        select new
                        {
                            r.Id,
                            r.MaquiladoCajaId,
                            r.MaquiladoCaja.Numero,
                            r.CompaniaId,
                            r.TallaId,
                            t.FacDTall,
                            t.FacSecTal,
                            r.Cantidad
                        }).ToList();
                    foreach (var caja in cajas)
                    {
                        lista.Add(new MaquiladoEmpaqueBusiness
                        {
                            Caja = caja,
                            Detalle = detalle
                                .Where(r => r.MaquiladoCajaId == caja.Id)
                                .OrderBy(r => r.MaquiladoCajaId)
                                .ThenBy(r => r.FacSecTal)
                                .Select(r => new MaquiladoCajaDetalleBusiness
                                {
                                    Id = r.Id,
                                    MaquiladoCajaId = r.MaquiladoCajaId,
                                    CompaniaId = r.CompaniaId,
                                    TallaId = r.TallaId,
                                    Cantidad = r.Cantidad,
                                    Talla = new TallaBusiness
                                    {
                                        CompaniaId = r.CompaniaId,
                                        Codigo = r.TallaId,
                                        Nombre = r.FacDTall,
                                        Secuencia = r.FacSecTal ?? 0
                                    }
                                }).ToArray()
                        });
                    }
                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MaquiladoCajaBusiness / GetDetalleByOrden", exception);
            }
        }

        #endregion
    }
}