using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class PagoTipoRepository
    {

        private static CrmContext _context;

        public static PagoTipo Insert(PagoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PagoTipoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PagoTipoRepository / Insert", exception);
            }
        }

        public static PagoTipo Update(PagoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PagoTipoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de PagoTipo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PagoTipoRepository / Update", exception);
            }
        }

        public static void Delete(PagoTipo model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PagoTipoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.PagoTipoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de PagoTipo con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PagoTipoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int pagoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PagoTipoSet
                    .FirstOrDefault(r => r.Id == pagoTipoId);

                    if (reg != null)
                    {
                        _context.PagoTipoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de PagoTipo con Id: {pagoTipoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PagoTipoRepository / Delete (id)", exception);
            }
        }

        public static PagoTipo Get(int pagoTipoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.PagoTipoSet
                        .FirstOrDefault(r => r.Id == pagoTipoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de PagoTipo con Id: {pagoTipoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PagoTipoRepository / Get", exception);
            }
        }

        public static PagoTipo[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PagoTipoSet
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PagoTipoRepository / GetAll", exception);
            }
        } 
    }
}