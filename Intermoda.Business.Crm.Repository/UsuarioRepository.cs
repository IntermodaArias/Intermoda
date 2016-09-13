using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class UsuarioRepository
    {
        private static CrmContext _context;

        public static Usuario Insert(Usuario model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.UsuarioSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("UsuarioRepository / Insert", exception);
            }
        }

        public static Usuario Update(Usuario model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.UsuarioSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        
                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Usuario con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("UsuarioRepository / Update", exception);
            }
        }

        public static void Delete(Usuario model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.UsuarioSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.UsuarioSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Usuario con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("UsuarioRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int usuarioId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.UsuarioSet
                    .FirstOrDefault(r => r.Id == usuarioId);

                    if (reg != null)
                    {
                        _context.UsuarioSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Usuario con Id: {usuarioId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("UsuarioRepository / Delete (id)", exception);
            }
        }

        public static Usuario Get(int usuarioId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.UsuarioSet
                    .FirstOrDefault(r => r.Id == usuarioId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Usuario con Id: {usuarioId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("UsuarioRepository / Get", exception);
            }
        }

        public static Usuario[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.UsuarioSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("UsuarioRepository / GetAll", exception);
            }
        } 
    }
}