using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class SupervisorRepository
    {
        private static CrmContext _context;

        public static Supervisor Insert(Supervisor model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Usuario = UsuarioRepository.Get(model.UsuarioId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorRepository / Insert", exception);
            }
        }

        public static Supervisor Update(Supervisor model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.UsuarioId = model.UsuarioId;

                        _context.SaveChanges();

                        model.Usuario = UsuarioRepository.Get(model.UsuarioId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Supervisor con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorRepository / Update", exception);
            }
        }

        public static void Delete(Supervisor model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.SupervisorSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Supervisor con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int supervisorId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.SupervisorSet
                    .FirstOrDefault(r => r.Id == supervisorId);

                    if (reg != null)
                    {
                        _context.SupervisorSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Supervisor con Id: {supervisorId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorRepository / Delete (id)", exception);
            }
        }

        public static Supervisor Get(int supervisorId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.SupervisorSet
                        .Include(r => r.Usuario)
                        .FirstOrDefault(r => r.Id == supervisorId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Supervisor con Id: {supervisorId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorRepository / Get", exception);
            }
        }

        public static Supervisor[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.SupervisorSet
                        .Include(r => r.Usuario)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SupervisorRepository / GetAll", exception);
            }
        } 
    }
}