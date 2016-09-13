using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class ArchivosGlobalesBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int PropietarioId { get; set; }

        [DataMember]
        public string Nombre { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string Extension { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public byte[] Binario { get; set; }

        [DataMember]
        public string PropietarioNombre { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public string Version { get; set; }

        #endregion

        #region Methods

        public static ArchivosGlobalesBusiness Insert(ArchivosGlobalesBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new ArchivosGlobales()
                    {
                        ArchivoGlobalPropietarioId = model.PropietarioId,
                        ArchivoGlobalPropietarioNombre = model.PropietarioNombre,
                        ArchivoGlobalNombre = model.Nombre,
                        ArchivoGlobalTipo = model.Tipo,
                        ArchivoGlobalExtension = model.Extension,
                        ArchivoGlobalOrden = model.Orden,
                        ArchivoGlobalDescripcion = model.Descripcion,
                        ArchivoGlobalBinario = model.Binario,
                        ArchivoGlobalFecha = model.Fecha,
                        ArchivoGlobalVersion = model.Version
                    };
                    _context.ArchivosGlobalesSet.Add(reg);
                    _context.SaveChanges();

                    model.Id = reg.ArchivoGlobalId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / Insert", exception);
            }
        }

        public static ArchivosGlobalesBusiness Update(ArchivosGlobalesBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ArchivosGlobalesSet
                               where r.ArchivoGlobalId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        reg.ArchivoGlobalPropietarioId = model.PropietarioId;
                        reg.ArchivoGlobalPropietarioNombre = model.PropietarioNombre;
                        reg.ArchivoGlobalNombre = model.Nombre;
                        reg.ArchivoGlobalTipo = model.Tipo;
                        reg.ArchivoGlobalExtension = model.Extension;
                        reg.ArchivoGlobalOrden = model.Orden;
                        reg.ArchivoGlobalDescripcion = model.Descripcion;
                        reg.ArchivoGlobalBinario = model.Binario;
                        reg.ArchivoGlobalFecha = model.Fecha;
                        reg.ArchivoGlobalVersion = model.Version;
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ArchivosGlobales con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / Update", exception);
            }
        }

        public static void Delete(ArchivosGlobalesBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ArchivosGlobalesSet
                               where r.ArchivoGlobalId == model.Id
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ArchivosGlobalesSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ArchivosGlobales con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int archivoGlobalId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.ArchivosGlobalesSet
                               where r.ArchivoGlobalId == archivoGlobalId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.ArchivosGlobalesSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ArchivosGlobales con Id: {archivoGlobalId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / Delete (id)", exception);
            }
        }

        public static ArchivosGlobalesBusiness Get(int archivoGlobalId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ArchivosGlobalesSet
                                 where r.ArchivoGlobalId == archivoGlobalId
                                 select new ArchivosGlobalesBusiness
                                 {
                                     Id = r.ArchivoGlobalId,
                                     PropietarioId = r.ArchivoGlobalPropietarioId,
                                     PropietarioNombre = r.ArchivoGlobalPropietarioNombre,
                                     Nombre = r.ArchivoGlobalNombre,
                                     Tipo = r.ArchivoGlobalTipo,
                                     Extension = r.ArchivoGlobalExtension,
                                     Orden = r.ArchivoGlobalOrden,
                                     Descripcion = r.ArchivoGlobalDescripcion,
                                     Binario = r.ArchivoGlobalBinario,
                                     Fecha = r.ArchivoGlobalFecha,
                                     Version = r.ArchivoGlobalVersion
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ArchivosGlobales con Id: {archivoGlobalId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / Get", exception);
            }
        }

        public static ArchivosGlobalesBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    return (from r in _context.ArchivosGlobalesSet
                            select new ArchivosGlobalesBusiness
                            {
                                Id = r.ArchivoGlobalId,
                                PropietarioId = r.ArchivoGlobalPropietarioId,
                                PropietarioNombre = r.ArchivoGlobalPropietarioNombre,
                                Nombre = r.ArchivoGlobalNombre,
                                Tipo = r.ArchivoGlobalTipo,
                                Extension = r.ArchivoGlobalExtension,
                                Orden = r.ArchivoGlobalOrden,
                                Descripcion = r.ArchivoGlobalDescripcion,
                                Binario = r.ArchivoGlobalBinario,
                                Fecha = r.ArchivoGlobalFecha,
                                Version = r.ArchivoGlobalVersion
                            }).ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / GetAll", exception);
            }
        }

        public static ArchivosGlobalesBusiness GetByPropietarioId(int propietarioId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ArchivosGlobalesSet
                                 where r.ArchivoGlobalPropietarioId == propietarioId
                                 select new ArchivosGlobalesBusiness
                                 {
                                     Id = r.ArchivoGlobalId,
                                     PropietarioId = r.ArchivoGlobalPropietarioId,
                                     PropietarioNombre = r.ArchivoGlobalPropietarioNombre,
                                     Nombre = r.ArchivoGlobalNombre,
                                     Tipo = r.ArchivoGlobalTipo,
                                     Extension = r.ArchivoGlobalExtension,
                                     Orden = r.ArchivoGlobalOrden,
                                     Descripcion = r.ArchivoGlobalDescripcion,
                                     Binario = r.ArchivoGlobalBinario,
                                     Fecha = r.ArchivoGlobalFecha,
                                     Version = r.ArchivoGlobalVersion
                                 }).FirstOrDefault();

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivosGlobalesBusiness / GetByPropietarioId", exception);
            }
        }

        #endregion
    }
}