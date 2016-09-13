using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class OpcionLavadoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public int LavadoId { get; set; }

        [DataMember]
        public string TelaId { get; set; }

        [DataMember]
        public int IsDefault { get; set; }

        //

        [DataMember]
        public LavadoBusiness Lavado { get; set; }

        [DataMember]
        public TelaBusiness Tela { get; set; }

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
                        OpcionNombre = model.Nombre,
                        OpcionDescripcion = model.Descripcion,
                        LavadoId = model.LavadoId,
                        TelaId = model.TelaId,
                        IsDefault = model.IsDefault
                    };
                    _context.OpcionesLavadosSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.OpcionLavadoId;
                    model.Lavado = LavadoBusiness.Get(model.LavadoId);
                    model.Tela = TelaBusiness.Get(model.TelaId);
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
                        where r.OpcionLavadoId == model.Id
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.OpcionNombre = model.Nombre;
                        reg.OpcionDescripcion = model.Descripcion;
                        reg.LavadoId = model.LavadoId;
                        reg.TelaId = model.TelaId;
                        reg.IsDefault = model.IsDefault;

                        _context.SaveChanges();

                        model.Lavado = LavadoBusiness.Get(model.LavadoId);
                        model.Tela = TelaBusiness.Get(model.TelaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavado con Id: {model.Id}");
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
                        where r.OpcionLavadoId == model.Id
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.OpcionesLavadosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de OpcionLavado con Id: {model.Id}");
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
                            Id = r.OpcionLavadoId,
                            Nombre = r.OpcionNombre,
                            Descripcion = r.OpcionDescripcion,
                            LavadoId = r.LavadoId,
                            TelaId = r.TelaId,
                            IsDefault = r.IsDefault
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.Lavado = LavadoBusiness.Get(model.LavadoId);
                        model.Tela = TelaBusiness.Get(model.TelaId);

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
                    var lista = (from r in _context.OpcionesLavadosSet
                        orderby r.OpcionNombre
                        select new OpcionLavadoBusiness
                        {
                            Id = r.OpcionLavadoId,
                            Nombre = r.OpcionNombre,
                            Descripcion = r.OpcionDescripcion,
                            LavadoId = r.LavadoId,
                            TelaId = r.TelaId,
                            IsDefault = r.IsDefault
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Lavado = LavadoBusiness.Get(model.LavadoId);
                        model.Tela = TelaBusiness.Get(model.TelaId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / GetAll", exception);
            }
        }

        public static OpcionLavadoBusiness[] GetByLavado(int lavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OpcionesLavadosSet
                        where r.LavadoId == lavadoId
                        orderby r.LavadoId, r.OpcionNombre
                        select new OpcionLavadoBusiness
                        {
                            Id = r.OpcionLavadoId,
                            Nombre = r.OpcionNombre,
                            Descripcion = r.OpcionDescripcion,
                            LavadoId = r.LavadoId,
                            TelaId = r.TelaId,
                            IsDefault = r.IsDefault
                        }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Lavado = LavadoBusiness.Get(model.LavadoId);
                        model.Tela = TelaBusiness.Get(model.TelaId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / GetByLavado", exception);
            }
        }

        public static OpcionLavadoBusiness[] GetByTela(string telaId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.OpcionesLavadosSet
                                 where r.TelaId == telaId
                                 orderby r.TelaId, r.OpcionNombre
                                 select new OpcionLavadoBusiness
                                 {
                                     Id = r.OpcionLavadoId,
                                     Nombre = r.OpcionNombre,
                                     Descripcion = r.OpcionDescripcion,
                                     LavadoId = r.LavadoId,
                                     TelaId = r.TelaId,
                                     IsDefault = r.IsDefault
                                 }).ToArray();

                    foreach (var model in lista)
                    {
                        model.Lavado = LavadoBusiness.Get(model.LavadoId);
                        model.Tela = TelaBusiness.Get(model.TelaId);
                    }

                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavadoBusiness / GetByTela", exception);
            }
        }

        #endregion
    }
}