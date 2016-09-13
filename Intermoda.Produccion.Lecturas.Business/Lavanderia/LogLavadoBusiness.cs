using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class LogLavadoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Objeto { get; set; }

        [DataMember]
        public string Usuario { get; set; }

        [DataMember]
        public string TipoTransaccion { get; set; }

        #endregion

        #region Methods

        public static LogLavadoBusiness Insert(LogLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new LogsLavado()
                    {
                        LogLavadoFecha = model.Fecha,
                        LogLavadoDescripcion = model.Descripcion,
                        LogLavadoObjeto = model.Objeto,
                        LogLavadoUsuario = model.Usuario,
                        LogLavadoTipoTransaccion = model.TipoTransaccion
                    };
                    _context.LogsLavadoSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.LogLavadoId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LogLavadoBusiness / Insert", exception);
            }
        }

        public static LogLavadoBusiness Update(LogLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LogsLavadoSet
                               where r.LogLavadoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.LogLavadoFecha = model.Fecha;
                        reg.LogLavadoDescripcion = model.Descripcion;
                        reg.LogLavadoObjeto = model.Objeto;
                        reg.LogLavadoUsuario = model.Usuario;
                        reg.LogLavadoTipoTransaccion = model.TipoTransaccion;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LogLavado con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LogLavadoBusiness / Update", exception);
            }
        }

        public static void Delete(LogLavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LogsLavadoSet
                               where r.LogLavadoId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LogsLavadoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LogLavado con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LogLavadoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int logLavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LogsLavadoSet
                               where r.LogLavadoId == logLavadoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LogsLavadoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de LogLavado con Id: {logLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LogLavadoBusiness / Delete (id)", exception);
            }
        }

        public static LogLavadoBusiness Get(int logLavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.LogsLavadoSet
                        select new LogLavadoBusiness
                        {
                            Id = r.LogLavadoId,
                            Fecha = r.LogLavadoFecha,
                            Descripcion = r.LogLavadoDescripcion,
                            Objeto = r.LogLavadoObjeto,
                            Usuario = r.LogLavadoUsuario,
                            TipoTransaccion = r.LogLavadoTipoTransaccion
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de LogLavado con Id: {logLavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LogLavadoBusiness / Get", exception);
            }
        }

        public static LogLavadoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.LogsLavadoSet
                        select new LogLavadoBusiness
                        {
                            Id = r.LogLavadoId,
                            Fecha = r.LogLavadoFecha,
                            Descripcion = r.LogLavadoDescripcion,
                            Objeto = r.LogLavadoObjeto,
                            Usuario = r.LogLavadoUsuario,
                            TipoTransaccion = r.LogLavadoTipoTransaccion
                        }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LogLavadoBusiness / GetAll", exception);
            }
        }

        #endregion
    }
}