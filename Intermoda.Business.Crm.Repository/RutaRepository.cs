using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class RutaRepository
    {
        private static CrmContext _context;

        public static Ruta Insert(Ruta model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.RutaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / Insert", exception);
            }
        }

        public static Ruta Update(Ruta model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.RutaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Ruta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / Update", exception);
            }
        }

        public static void Delete(Ruta model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.RutaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.RutaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Ruta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int rutaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.RutaSet
                    .FirstOrDefault(r => r.Id == rutaId);

                    if (reg != null)
                    {
                        _context.RutaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Ruta con Id: {rutaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / Delete (id)", exception);
            }
        }

        public static Ruta Get(int rutaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.RutaSet
                    .FirstOrDefault(r => r.Id == rutaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Ruta con Id: {rutaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / Get", exception);
            }
        }

        public static Ruta[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.RutaSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / GetAll", exception);
            }
        }

        public static Ruta[] GetByZona(int zonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.RutaSet
                        .Where(r => r.ZonaId == zonaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("RutaRepository / GetAll", exception);
            }
        }
    }
}