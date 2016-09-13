using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class PaisRepository
    {
        private static CrmContext _context;

        public static Pais Insert(Pais model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaisSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaisRepository / Insert", exception);
            }
        }

        public static Pais Update(Pais model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaisSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Pais con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaisRepository / Update", exception);
            }
        }

        public static void Delete(Pais model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaisSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.PaisSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Pais con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaisRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int paisId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaisSet
                    .FirstOrDefault(r => r.Id == paisId);

                    if (reg != null)
                    {
                        _context.PaisSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Pais con Id: {paisId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaisRepository / Delete (id)", exception);
            }
        }

        public static Pais Get(int paisId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.PaisSet
                    .FirstOrDefault(r => r.Id == paisId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Pais con Id: {paisId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaisRepository / Get", exception);
            }
        }

        public static Pais[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PaisSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaisRepository / GetAll", exception);
            }
        } 
    }
}