using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class MonedaRepository
    {

        private static CrmContext _context;

        public static Moneda Insert(Moneda model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.MonedaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MonedaRepository / Insert", exception);
            }
        }

        public static Moneda Update(Moneda model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.MonedaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Simbolo = model.Simbolo;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Moneda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MonedaRepository / Update", exception);
            }
        }

        public static void Delete(Moneda model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.MonedaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.MonedaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Moneda con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MonedaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int monedaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.MonedaSet
                    .FirstOrDefault(r => r.Id == monedaId);

                    if (reg != null)
                    {
                        _context.MonedaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Moneda con Id: {monedaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MonedaRepository / Delete (id)", exception);
            }
        }

        public static Moneda Get(int monedaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.MonedaSet
                        .FirstOrDefault(r => r.Id == monedaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Moneda con Id: {monedaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MonedaRepository / Get", exception);
            }
        }

        public static Moneda[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.MonedaSet
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("MonedaRepository / GetAll", exception);
            }
        } 
    }
}