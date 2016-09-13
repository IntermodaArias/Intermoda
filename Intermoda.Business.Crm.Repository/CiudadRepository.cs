using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CiudadRepository
    {

        private static CrmContext _context;

        public static Ciudad Insert(Ciudad model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CiudadSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Pais = PaisRepository.Get(model.PaisId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / Insert", exception);
            }
        }

        public static Ciudad Update(Ciudad model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CiudadSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.PaisId = model.PaisId;

                        _context.SaveChanges();

                        model.Pais = PaisRepository.Get(model.PaisId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Ciudad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / Update", exception);
            }
        }

        public static void Delete(Ciudad model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CiudadSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CiudadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Ciudad con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int ciudadId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CiudadSet
                    .FirstOrDefault(r => r.Id == ciudadId);

                    if (reg != null)
                    {
                        _context.CiudadSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Ciudad con Id: {ciudadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / Delete (id)", exception);
            }
        }

        public static Ciudad Get(int ciudadId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CiudadSet
                        .Include(r => r.Pais)
                        .FirstOrDefault(r => r.Id == ciudadId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Ciudad con Id: {ciudadId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / Get", exception);
            }
        }

        public static Ciudad[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CiudadSet
                        .Include(r => r.Pais)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / GetAll", exception);
            }
        }

        public static Ciudad[] GetByPais(int paisId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CiudadSet
                        .Include(r => r.Pais)
                        .Where(r => r.PaisId == paisId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CiudadRepository / GetByPais", exception);
            }
        }
    }
}