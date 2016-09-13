using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Business.Lavanderia
{
    [DataContract]
    public class ArchivoGlobalBusiness
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

        [DataMember]
        public LavadoBusiness Lavado { get; private set; }

        #endregion

        #region Methods

        public static ArchivoGlobalBusiness Insert(ArchivoGlobalBusiness model)
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

                    model.Lavado = LavadoBusiness.Get(model.PropietarioId);
                    model.Id = reg.ArchivoGlobalId;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobalBusiness / Insert", exception);
            }
        }

        public static ArchivoGlobalBusiness Update(ArchivoGlobalBusiness model)
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

                        model.Lavado = LavadoBusiness.Get(model.PropietarioId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ArchivosGlobales con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobalBusiness / Update", exception);
            }
        }

        public static void Delete(ArchivoGlobalBusiness model)
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
                throw new Exception("ArchivoGlobalBusiness / Delete (model)", exception);
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
                throw new Exception("ArchivoGlobalBusiness / Delete (id)", exception);
            }
        }

        public static ArchivoGlobalBusiness Get(int archivoGlobalId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ArchivosGlobalesSet
                                 where r.ArchivoGlobalId == archivoGlobalId
                                 select new ArchivoGlobalBusiness
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
                        model.Lavado = LavadoBusiness.Get(model.PropietarioId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ArchivosGlobales con Id: {archivoGlobalId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobalBusiness / Get", exception);
            }
        }

        public static ArchivoGlobalBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.ArchivosGlobalesSet
                        select new ArchivoGlobalBusiness
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
                    foreach (var model in lista)
                    {
                        model.Lavado = LavadoBusiness.Get(model.PropietarioId);
                    }
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobalBusiness / GetAll", exception);
            }
        }

        public static ArchivoGlobalBusiness GetByPropietario(int propietarioId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.ArchivosGlobalesSet
                                 where r.ArchivoGlobalPropietarioId == propietarioId
                                 select new ArchivoGlobalBusiness
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

                    if (model != null) model.Lavado = LavadoBusiness.Get(model.PropietarioId);
                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobalBusiness / GetByPropietarioId", exception);
            }
        }

        #endregion
    }
}