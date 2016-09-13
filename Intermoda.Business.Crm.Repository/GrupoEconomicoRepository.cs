using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class GrupoEconomicoRepository
    {

        private static CrmContext _context;

        public static GrupoEconomico Insert(GrupoEconomico model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.GrupoEconomicoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoEconomicoRepository / Insert", exception);
            }
        }

        public static GrupoEconomico Update(GrupoEconomico model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.GrupoEconomicoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de GrupoEconomico con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoEconomicoRepository / Update", exception);
            }
        }

        public static void Delete(GrupoEconomico model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.GrupoEconomicoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.GrupoEconomicoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de GrupoEconomico con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoEconomicoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int grupoEconomicoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.GrupoEconomicoSet
                    .FirstOrDefault(r => r.Id == grupoEconomicoId);

                    if (reg != null)
                    {
                        _context.GrupoEconomicoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de GrupoEconomico con Id: {grupoEconomicoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoEconomicoRepository / Delete (id)", exception);
            }
        }

        public static GrupoEconomico Get(int grupoEconomicoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.GrupoEconomicoSet
                    .FirstOrDefault(r => r.Id == grupoEconomicoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de GrupoEconomico con Id: {grupoEconomicoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoEconomicoRepository / Get", exception);
            }
        }

        public static GrupoEconomico[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.GrupoEconomicoSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("GrupoEconomicoRepository / GetAll", exception);
            }
        } 
    }
}