using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class EmpresaRepository
    {

        private static CrmContext _context;

        public static Empresa Insert(Empresa model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EmpresaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Moneda = MonedaRepository.Get(model.MonedaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpresaRepository / Insert", exception);
            }
        }

        public static Empresa Update(Empresa model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EmpresaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.DocumentoFiscal = model.DocumentoFiscal;
                        reg.MonedaId = model.MonedaId;

                        _context.SaveChanges();

                        model.Moneda = MonedaRepository.Get(model.MonedaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Empresa con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpresaRepository / Update", exception);
            }
        }

        public static void Delete(Empresa model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EmpresaSet
                        .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.EmpresaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Empresa con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpresaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int empresaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.EmpresaSet
                        .FirstOrDefault(r => r.Id == empresaId);

                    if (reg != null)
                    {
                        _context.EmpresaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Empresa con Id: {empresaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpresaRepository / Delete (id)", exception);
            }
        }

        public static Empresa Get(int empresaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.EmpresaSet
                        .Include(r => r.Moneda)
                        .FirstOrDefault(r => r.Id == empresaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Empresa con Id: {empresaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpresaRepository / Get", exception);
            }
        }

        public static Empresa[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.EmpresaSet
                        .Include(r => r.Moneda)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("EmpresaRepository / GetAll", exception);
            }
        } 
    }
}