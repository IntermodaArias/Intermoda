using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class SupervisorZonaRepository
    {
        private static CrmContext _context;

        public static SupervisorZona Insert(SupervisorZona model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorZonaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Supervisor = SupervisorRepository.Get(model.SupervisorId);
                    model.Zona = ZonaRepository.Get(model.ZonaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / Insert", exception);
            }
        }

        public static SupervisorZona Update(SupervisorZona model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorZonaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.SupervisorId = model.SupervisorId;
                        reg.ZonaId = model.ZonaId;

                        _context.SaveChanges();

                        model.Supervisor = SupervisorRepository.Get(model.SupervisorId);
                        model.Zona = ZonaRepository.Get(model.ZonaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de SupervisorZona con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / Update", exception);
            }
        }

        public static void Delete(SupervisorZona model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorZonaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.SupervisorZonaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de SupervisorZona con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int supervisorZonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorZonaSet
                    .FirstOrDefault(r => r.Id == supervisorZonaId);

                    if (reg != null)
                    {
                        _context.SupervisorZonaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de SupervisorZona con Id: {supervisorZonaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / Delete (id)", exception);
            }
        }

        public static SupervisorZona Get(int supervisorZonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.SupervisorZonaSet
                        .Include(r => r.Supervisor)
                        .Include(r => r.Zona)
                        .FirstOrDefault(r => r.Id == supervisorZonaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de SupervisorZona con Id: {supervisorZonaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / Get", exception);
            }
        }

        public static SupervisorZona[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.SupervisorZonaSet
                        .Include(r => r.Supervisor)
                        .Include(r => r.Zona)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / GetAll", exception);
            }
        }

        public static SupervisorZona[] GetBySupervisor(int supervisorId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.SupervisorZonaSet
                        .Include(r => r.Supervisor)
                        .Include(r => r.Zona)
                        .Where(r => r.SupervisorId == supervisorId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / GetBySupervisor", exception);
            }
        }

        public static SupervisorZona[] GetByZona(int zonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.SupervisorZonaSet
                        .Include(r => r.Supervisor)
                        .Include(r => r.Zona)
                        .Where(r => r.ZonaId == zonaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorZonaRepository / GetByZona", exception);
            }
        }

    }
}