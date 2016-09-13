using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class InventarioFisicoRepository
    {

        private static CrmContext _context;

        public static InventarioFisico Insert(InventarioFisico model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Cliente = ClienteRepository.Get(model.ClienteId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / Insert", exception);
            }
        }

        public static InventarioFisico Update(InventarioFisico model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.ClienteId = model.ClienteId;
                        reg.Fecha = model.Fecha;
                        reg.Sincronizado = model.Sincronizado;

                        _context.SaveChanges();

                        model.Cliente = ClienteRepository.Get(model.ClienteId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisico con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / Update", exception);
            }
        }

        public static void Delete(InventarioFisico model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.InventarioFisicoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisico con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int inventarioFisicoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoSet
                    .FirstOrDefault(r => r.Id == inventarioFisicoId);

                    if (reg != null)
                    {
                        _context.InventarioFisicoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisico con Id: {inventarioFisicoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / Delete (id)", exception);
            }
        }

        public static InventarioFisico Get(int inventarioFisicoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.InventarioFisicoSet
                        .Include(r => r.Cliente)
                        .FirstOrDefault(r => r.Id == inventarioFisicoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisico con Id: {inventarioFisicoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / Get", exception);
            }
        }

        public static InventarioFisico[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioFisicoSet
                        .Include(r => r.Cliente)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / GetAll", exception);
            }
        }

        public static InventarioFisico[] GetByCliente(int clienteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioFisicoSet
                        .Include(r => r.Cliente)
                        .Where(r => r.ClienteId == clienteId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoRepository / GetByCliente", exception);
            }
        }
    }
}