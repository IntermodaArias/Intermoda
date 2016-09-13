using System;
using System.Linq;
using System.Runtime.Serialization;
using Intermoda.Produccion.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Business.Lavanderia
{
    [DataContract]
    public class LavadoBusiness
    {
        private static LavanderiaEntities _context;

        #region Properties

        [DataMember]
        public int LavadoId { get; set; }

        [DataMember]
        public string LavadoNombre { get; set; }

        [DataMember]
        public string LavadoDescripcion { get; set; }

        [DataMember]
        public int ColorId { get; set; }

        [DataMember]
        public string ColorNombre { get; set; }

        [DataMember]
        public int ArchivoCodigo { get; set; }

        [DataMember]
        public string ArchivoNombre { get; set; }

        [DataMember]
        public string ArchivoTipo { get; set; }

        [DataMember]
        public string ArchivoExtension { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public int Orden { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public byte[] Archivo { get; set; }

        [DataMember]
        public int IsActivo { get; set; }

        [DataMember]
        public DateTime? LavadoFechaCreacion { get; set; }

        [DataMember]
        public DateTime? LavadoFechaActualizacion { get; set; }

        //

        [DataMember]
        public ColoresIntermodaBusiness ColorIntermoda { get; private set; }

        #endregion

        #region Methods

        public static LavadoBusiness Insert(LavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = new Lavados()
                    {
                        LavadoNombre = model.LavadoNombre,
                        LavadoDescripcion = model.LavadoDescripcion,
                        ColorIntermodaId = model.ColorId,
                        IsActivo = model.IsActivo,
                        LavadoFechaCreacion = DateTime.Now,
                        LavadoFechaActualizacion = DateTime.Now
                    };
                    _context.LavadosSet.Add(reg);
                    _context.SaveChanges();

                    model.LavadoId = reg.LavadoId;

                    model.ColorIntermoda = ColoresIntermodaBusiness.Get(model.ColorId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / Insert", exception);
            }
        }

        public static LavadoBusiness Update(LavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadosSet
                               where r.LavadoId == model.LavadoId
                               select r).FirstOrDefault();
                    if (reg != null &&
                        (reg.LavadoNombre != model.LavadoNombre ||
                        reg.LavadoDescripcion != model.LavadoDescripcion ||
                        reg.ColorIntermodaId != model.ColorId ||
                        reg.IsActivo != model.IsActivo))
                    {
                        reg.LavadoNombre = model.LavadoNombre;
                        reg.LavadoDescripcion = model.LavadoDescripcion;
                        reg.ColorIntermodaId = model.ColorId;
                        reg.IsActivo = model.IsActivo;
                        reg.LavadoFechaActualizacion = DateTime.Now;

                        _context.SaveChanges();

                        model.ColorIntermoda = ColoresIntermodaBusiness.Get(model.ColorId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavado con Id: {model.LavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / Update", exception);
            }
        }

        public static void Delete(LavadoBusiness model)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadosSet
                               where r.LavadoId == model.LavadoId
                               select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LavadosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavado con Id: {model.LavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / Delete (model)", exception);
            }
        }

        public static void Delete(int lavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var reg = (from r in _context.LavadosSet
                        where r.LavadoId == lavadoId
                        select r).FirstOrDefault();
                    if (reg != null)
                    {
                        _context.LavadosSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavado con Id: {lavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / Delete (id)", exception);
            }
        }

        public static LavadoBusiness Get(int lavadoId)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.LavadosSet
                        join arch in _context.ArchivosGlobalesSet on
                            new {a = r.LavadoId, b = r.LavadoNombre} equals
                            new {a = arch.ArchivoGlobalPropietarioId, b = arch.ArchivoGlobalPropietarioNombre}
                        join color in _context.ColoresIntermodaSet
                            on r.ColorIntermodaId equals color.ColorIntermodaId
                        where r.LavadoId == lavadoId
                        select new LavadoBusiness
                        {
                            LavadoId = r.LavadoId,
                            LavadoNombre = r.LavadoNombre,
                            LavadoDescripcion = r.LavadoDescripcion,
                            ColorId = color.ColorIntermodaId,
                            ColorNombre = color.ColorIntermodaNombre,
                            ArchivoCodigo = arch.ArchivoGlobalId,
                            ArchivoNombre = arch.ArchivoGlobalNombre,
                            ArchivoTipo = arch.ArchivoGlobalTipo,
                            ArchivoExtension = arch.ArchivoGlobalExtension,
                            Path = String.Empty,
                            Descripcion = arch.ArchivoGlobalDescripcion,
                            Version = arch.ArchivoGlobalVersion,
                            Archivo = arch.ArchivoGlobalBinario
                        }).FirstOrDefault();
                    if (model != null)
                    {
                        model.ColorIntermoda = ColoresIntermodaBusiness.Get(model.ColorId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavado con Id: {lavadoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / Get", exception);
            }
        }

        public static LavadoBusiness[] GetAll()
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var lista = (from r in _context.LavadosSet
                            join arch in _context.ArchivosGlobalesSet on
                                new { a = r.LavadoId, b = r.LavadoNombre } equals
                                new { a = arch.ArchivoGlobalPropietarioId, b = arch.ArchivoGlobalPropietarioNombre }
                            join color in _context.ColoresIntermodaSet
                                on r.ColorIntermodaId equals color.ColorIntermodaId
                            select new LavadoBusiness
                            {
                                LavadoId = r.LavadoId,
                                LavadoNombre = r.LavadoNombre,
                                LavadoDescripcion = r.LavadoDescripcion,
                                ColorId = color.ColorIntermodaId,
                                ColorNombre = color.ColorIntermodaNombre,
                                ArchivoCodigo = arch.ArchivoGlobalId,
                                ArchivoNombre = arch.ArchivoGlobalNombre,
                                ArchivoTipo = arch.ArchivoGlobalTipo,
                                ArchivoExtension = arch.ArchivoGlobalExtension,
                                Path = String.Empty,
                                Descripcion = arch.ArchivoGlobalDescripcion,
                                Version = arch.ArchivoGlobalVersion,
                                Archivo = arch.ArchivoGlobalBinario
                            }).ToList();

                    foreach (var model in lista)
                    {
                        model.ColorIntermoda = ColoresIntermodaBusiness.Get(model.ColorId);
                    }

                    return lista.ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / GetAll", exception);
            }
        }

        public static LavadoBusiness GetByNombre(string lavadoNombre)
        {
            try
            {
                using (_context = new LavanderiaEntities())
                {
                    var model = (from r in _context.LavadosSet
                                 join arch in _context.ArchivosGlobalesSet on
                                     new { a = r.LavadoId, b = r.LavadoNombre } equals
                                     new { a = arch.ArchivoGlobalPropietarioId, b = arch.ArchivoGlobalPropietarioNombre }
                                 join color in _context.ColoresIntermodaSet
                                     on r.ColorIntermodaId equals color.ColorIntermodaId
                                 where r.LavadoNombre == lavadoNombre
                                 select new LavadoBusiness
                                 {
                                     LavadoId = r.LavadoId,
                                     LavadoNombre = r.LavadoNombre,
                                     LavadoDescripcion = r.LavadoDescripcion,
                                     ColorId = color.ColorIntermodaId,
                                     ColorNombre = color.ColorIntermodaNombre,
                                     ArchivoCodigo = arch.ArchivoGlobalId,
                                     ArchivoNombre = arch.ArchivoGlobalNombre,
                                     ArchivoTipo = arch.ArchivoGlobalTipo,
                                     ArchivoExtension = arch.ArchivoGlobalExtension,
                                     Path = String.Empty,
                                     Descripcion = arch.ArchivoGlobalDescripcion,
                                     Version = arch.ArchivoGlobalVersion,
                                     Archivo = arch.ArchivoGlobalBinario
                                 }).FirstOrDefault();
                    if (model != null)
                    {
                        model.ColorIntermoda = ColoresIntermodaBusiness.Get(model.ColorId);
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Lavado con Nombre: {lavadoNombre}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoBusiness / Get", exception);
            }
        }

        #endregion
    }
}