using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class AsesorRutaRepository
    {

        private static CrmContext _context;

        public static AsesorRuta Insert(AsesorRuta model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorRutaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Asesor = AsesorRepository.Get(model.AsesorId);
                    model.Ruta = RutaRepository.Get(model.RutaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / Insert", exception);
            }
        }

        public static AsesorRuta Update(AsesorRuta model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorRutaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.AsesorId = model.AsesorId;
                        reg.RutaId = model.RutaId;

                        _context.SaveChanges();

                        model.Asesor = AsesorRepository.Get(model.AsesorId);
                        model.Ruta = RutaRepository.Get(model.RutaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de AsesorRuta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / Update", exception);
            }
        }

        public static void Delete(AsesorRuta model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorRutaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.AsesorRutaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de AsesorRuta con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int asesorRutaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.AsesorRutaSet
                    .FirstOrDefault(r => r.Id == asesorRutaId);

                    if (reg != null)
                    {
                        _context.AsesorRutaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de AsesorRuta con Id: {asesorRutaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / Delete (id)", exception);
            }
        }

        public static AsesorRuta Get(int asesorRutaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.AsesorRutaSet
                        .Include(r => r.Asesor)
                        .Include(r => r.Ruta)
                        .FirstOrDefault(r => r.Id == asesorRutaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de AsesorRuta con Id: {asesorRutaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / Get", exception);
            }
        }

        public static AsesorRuta[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AsesorRutaSet
                        .Include(r => r.Asesor)
                        .Include(r => r.Ruta)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / GetAll", exception);
            }
        }

        public static AsesorRuta[] GetByAsesor(int asesorId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AsesorRutaSet
                        .Include(r => r.Asesor)
                        .Include(r => r.Ruta)
                        .Where(r => r.AsesorId == asesorId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / GetByAsesor", exception);
            }
        }

        public static AsesorRuta[] GetByRuta(int rutaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.AsesorRutaSet
                        .Include(r => r.Asesor)
                        .Include(r => r.Ruta)
                        .Where(r => r.RutaId == rutaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("AsesorRutaRepository / GetByRuta", exception);
            }
        }
    }
}