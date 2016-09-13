using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class PaqueteRepository
    {
        private static CrmContext _context;

        public static Paquete Insert(Paquete model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteRepository / Insert", exception);
            }
        }

        public static Paquete Update(Paquete model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Estado = model.Estado;
                        reg.EstadoDescripcion = model.EstadoDescripcion;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Paquete con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteRepository / Update", exception);
            }
        }

        public static void Delete(Paquete model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.PaqueteSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Paquete con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int paqueteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteSet
                    .FirstOrDefault(r => r.Id == paqueteId);

                    if (reg != null)
                    {
                        _context.PaqueteSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Paquete con Id: {paqueteId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteRepository / Delete (id)", exception);
            }
        }

        public static Paquete Get(int paqueteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.PaqueteSet
                    .FirstOrDefault(r => r.Id == paqueteId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Paquete con Id: {paqueteId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteRepository / Get", exception);
            }
        }

        public static Paquete[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PaqueteSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteRepository / GetAll", exception);
            }
        } 
    }
}