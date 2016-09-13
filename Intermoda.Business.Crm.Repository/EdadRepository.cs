using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class EdadRepository
    {

        private static CrmContext _context;

        public static Edad Insert(Edad model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EdadSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EdadRepository / Insert", exception);
            }
        }

        public static Edad Update(Edad model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EdadSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Edad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EdadRepository / Update", exception);
            }
        }

        public static void Delete(Edad model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EdadSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.EdadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Edad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EdadRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int edadId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EdadSet
                    .FirstOrDefault(r => r.Id == edadId);

                    if (reg != null)
                    {
                        _context.EdadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Edad con Id: {edadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EdadRepository / Delete (id)", exception);
            }
        }

        public static Edad Get(int edadId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.EdadSet
                        .FirstOrDefault(r => r.Id == edadId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Edad con Id: {edadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EdadRepository / Get", exception);
            }
        }

        public static Edad[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.EdadSet
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EdadRepository / GetAll", exception);
            }
        } 
    }
}