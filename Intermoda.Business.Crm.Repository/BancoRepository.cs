using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class BancoRepository
    {

        private static CrmContext _context;

        public static Banco Insert(Banco model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.BancoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("BancoRepository / Insert", exception);
            }
        }

        public static Banco Update(Banco model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.BancoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Banco con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("BancoRepository / Update", exception);
            }
        }

        public static void Delete(Banco model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.BancoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.BancoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Banco con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("BancoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int bancoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.BancoSet
                    .FirstOrDefault(r => r.Id == bancoId);

                    if (reg != null)
                    {
                        _context.BancoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Banco con Id: {bancoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("BancoRepository / Delete (id)", exception);
            }
        }

        public static Banco Get(int bancoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.BancoSet
                    .FirstOrDefault(r => r.Id == bancoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Banco con Id: {bancoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("BancoRepository / Get", exception);
            }
        }

        public static Banco[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.BancoSet
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("BancoRepository / GetAll", exception);
            }
        } 
    }
}