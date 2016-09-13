using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class ZonaRepository
    {
        private static CrmContext _context;

        public static Zona Insert(Zona model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ZonaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ZonaRepository / Insert", exception);
            }
        }

        public static Zona Update(Zona model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ZonaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Zona con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ZonaRepository / Update", exception);
            }
        }

        public static void Delete(Zona model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ZonaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.ZonaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Zona con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ZonaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int zonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ZonaSet
                    .FirstOrDefault(r => r.Id == zonaId);

                    if (reg != null)
                    {
                        _context.ZonaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Zona con Id: {zonaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ZonaRepository / Delete (id)", exception);
            }
        }

        public static Zona Get(int zonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.ZonaSet
                    .FirstOrDefault(r => r.Id == zonaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Zona con Id: {zonaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ZonaRepository / Get", exception);
            }
        }

        public static Zona[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ZonaSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ZonaRepository / GetAll", exception);
            }
        } 
    }
}