using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class AsesorRepository
    {

        private static CrmContext _context;

        public static Asesor Insert(Asesor model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Usuario = UsuarioRepository.Get(model.UsuarioId);
                    model.Zona = ZonaRepository.Get(model.ZonaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / Insert", exception);
            }
        }

        public static Asesor Update(Asesor model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.UsuarioId = model.UsuarioId;
                        reg.ZonaId = model.ZonaId;

                        _context.SaveChanges();

                        model.Usuario = UsuarioRepository.Get(model.UsuarioId);
                        model.Zona = ZonaRepository.Get(model.ZonaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Asesor con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / Update", exception);
            }
        }

        public static void Delete(Asesor model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.AsesorSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Asesor con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int asesorId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorSet
                    .FirstOrDefault(r => r.Id == asesorId);

                    if (reg != null)
                    {
                        _context.AsesorSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Asesor con Id: {asesorId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / Delete (id)", exception);
            }
        }

        public static Asesor Get(int asesorId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.AsesorSet
                        .Include(r => r.Usuario)
                        .Include(r => r.Zona)
                        .FirstOrDefault(r => r.Id == asesorId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Asesor con Id: {asesorId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / Get", exception);
            }
        }

        public static Asesor[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AsesorSet
                        .Include(r => r.Usuario)
                        .Include(r => r.Zona)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / GetAll", exception);
            }
        }

        public static Asesor[] GetByZona(int zonaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AsesorSet
                        .Include(r => r.Usuario)
                        .Include(r => r.Zona)
                        .Where(r => r.ZonaId == zonaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRepository / GetByZona", exception);
            }
        }
    }
}