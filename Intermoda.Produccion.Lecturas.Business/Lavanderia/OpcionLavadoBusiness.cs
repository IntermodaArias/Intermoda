using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class OpcionLavadoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int OpcionLavadoId { get; set; }

        [DataMember]
        public string OpcionNombre { get; set; }

        [DataMember]
        public string OpcionDescripcion { get; set; }

        [DataMember]
        public int LavadoId { get; set; }

        [DataMember]
        public string TelaId { get; set; }

        [DataMember]
        public int IsDefault { get; set; }

        #endregion

        #region Methods

        public static OpcionLavadoBusiness Insert(OpcionLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OpcionesLavados()
                    {
                        OpcionNombre = model.OpcionNombre,
                        OpcionDescripcion = model.OpcionDescripcion,
                        LavadoId = model.LavadoId,
                        TelaId = model.TelaId,
                        IsDefault = model.IsDefault
                    };
                    _context.OpcionesLavadosSet.Add(reg);
                    _context.SaveChanges();

                    model.OpcionLavadoId = reg.OpcionLavadoId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / Insert", exception);
            }
        }

        public static void InsertLegacy(int lavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new OpcionesLavados()
                    {
                        LavadoId = lavadoId

                    };
                    _context.OpcionesLavadosSet.Add(reg);
                    _context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / Insert", exception);
            }
        }

        public static OpcionLavadoBusiness Update(OpcionLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OpcionesLavadosSet
                        where r.OpcionLavadoId == model.OpcionLavadoId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OpcionNombre = model.OpcionNombre;
                        reg.OpcionDescripcion = model.OpcionDescripcion;
                        reg.LavadoId = model.LavadoId;
                        reg.TelaId = model.TelaId;
                        reg.IsDefault = model.IsDefault;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavado con Id: {model.OpcionLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / Update", exception);
            }
        }

        public static void Delete(OpcionLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OpcionesLavadosSet
                        where r.OpcionLavadoId == model.OpcionLavadoId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OpcionesLavadosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavado con Id: {model.OpcionLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int opcionLavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.OpcionesLavadosSet
                        where r.OpcionLavadoId == opcionLavadoId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OpcionesLavadosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavado con Id: {opcionLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / Delete (id)", exception);
            }
        }

        public static OpcionLavadoBusiness Get(int opcionLavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.OpcionesLavadosSet
                        where r.OpcionLavadoId == opcionLavadoId
                        select new OpcionLavadoBusiness
                        {
                            OpcionLavadoId = r.OpcionLavadoId,
                            OpcionNombre = r.OpcionNombre,
                            OpcionDescripcion = r.OpcionDescripcion,
                            LavadoId = r.LavadoId,
                            TelaId = r.TelaId,
                            IsDefault = r.IsDefault
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavado con Id: {opcionLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / Get", exception);
            }
        }

        public static OpcionLavadoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.OpcionesLavadosSet
                        select new OpcionLavadoBusiness
                        {
                            OpcionLavadoId = r.OpcionLavadoId,
                            OpcionNombre = r.OpcionNombre,
                            OpcionDescripcion = r.OpcionDescripcion,
                            LavadoId = r.LavadoId,
                            TelaId = r.TelaId,
                            IsDefault = r.IsDefault
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}