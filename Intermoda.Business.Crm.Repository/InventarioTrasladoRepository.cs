using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class InventarioTrasladoRepository
    {

        private static CrmContext _context;

        public static InventarioTraslado Insert(InventarioTraslado model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.ClienteOrigen = ClienteRepository.Get(model.ClienteOrigenId);
                    model.ClienteDestino = ClienteRepository.Get(model.ClienteDestinoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / Insert", exception);
            }
        }

        public static InventarioTraslado Update(InventarioTraslado model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.ClienteOrigenId = model.ClienteOrigenId;
                        reg.ClienteDestinoId = model.ClienteDestinoId;
                        reg.Fecha = model.Fecha;

                        _context.SaveChanges();

                        model.ClienteOrigen = ClienteRepository.Get(model.ClienteOrigenId);
                        model.ClienteDestino = ClienteRepository.Get(model.ClienteDestinoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTraslado con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / Update", exception);
            }
        }

        public static void Delete(InventarioTraslado model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.InventarioTrasladoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTraslado con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int inventarioTrasladoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoSet
                    .FirstOrDefault(r => r.Id == inventarioTrasladoId);

                    if (reg != null)
                    {
                        _context.InventarioTrasladoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTraslado con Id: {inventarioTrasladoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / Delete (id)", exception);
            }
        }

        public static InventarioTraslado Get(int inventarioTrasladoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.InventarioTrasladoSet
                        .Include(r => r.ClienteOrigen)
                        .Include(r => r.ClienteDestino)
                        .FirstOrDefault(r => r.Id == inventarioTrasladoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTraslado con Id: {inventarioTrasladoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / Get", exception);
            }
        }

        public static InventarioTraslado[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioTrasladoSet
                        .Include(r => r.ClienteOrigen)
                        .Include(r => r.ClienteDestino)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / GetAll", exception);
            }
        }

        public static InventarioTraslado[] GetByClienteOrigen(int clienteOrigenId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioTrasladoSet
                        .Include(r => r.ClienteOrigen)
                        .Include(r => r.ClienteDestino)
                        .Where(r => r.ClienteOrigenId == clienteOrigenId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / GetByClienteOrigen", exception);
            }
        }

        public static InventarioTraslado[] GetByClienteDestino(int clienteDestinoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioTrasladoSet
                        .Include(r => r.ClienteOrigen)
                        .Include(r => r.ClienteDestino)
                        .Where(r => r.ClienteDestinoId == clienteDestinoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoRepository / GetByClienteDestino", exception);
            }
        }
    }
}