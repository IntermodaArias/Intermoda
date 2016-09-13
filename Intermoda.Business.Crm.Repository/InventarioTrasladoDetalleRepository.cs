using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class InventarioTrasladoDetalleRepository
    {

        private static CrmContext _context;

        public static InventarioTrasladoDetalle Insert(InventarioTrasladoDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoDetalleSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.InventarioTraslado = InventarioTrasladoRepository.Get(model.InventarioTrasladoId);
                    model.Producto = ProductoRepository.Get(model.ProductoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / Insert", exception);
            }
        }

        public static InventarioTrasladoDetalle Update(InventarioTrasladoDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.InventarioTrasladoId = model.InventarioTrasladoId;
                        reg.ProductoId = model.ProductoId;
                        reg.Cantidad = model.Cantidad;

                        _context.SaveChanges();

                        model.InventarioTraslado = InventarioTrasladoRepository.Get(model.InventarioTrasladoId);
                        model.Producto = ProductoRepository.Get(model.ProductoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTrasladoDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / Update", exception);
            }
        }

        public static void Delete(InventarioTrasladoDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.InventarioTrasladoDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTrasladoDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int inventarioTrasladoDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioTrasladoDetalleSet
                    .FirstOrDefault(r => r.Id == inventarioTrasladoDetalleId);

                    if (reg != null)
                    {
                        _context.InventarioTrasladoDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTrasladoDetalle con Id: {inventarioTrasladoDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / Delete (id)", exception);
            }
        }

        public static InventarioTrasladoDetalle Get(int inventarioTrasladoDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.InventarioTrasladoDetalleSet
                        .Include(r=>r.InventarioTraslado)
                        .Include(r=>r.Producto)
                        .FirstOrDefault(r => r.Id == inventarioTrasladoDetalleId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioTrasladoDetalle con Id: {inventarioTrasladoDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / Get", exception);
            }
        }

        public static InventarioTrasladoDetalle[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioTrasladoDetalleSet
                        .Include(r => r.InventarioTraslado)
                        .Include(r => r.Producto)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / GetAll", exception);
            }
        }

        public static InventarioTrasladoDetalle[] GetByInventarioTraslado(int inventarioTrasladoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioTrasladoDetalleSet
                        .Include(r => r.InventarioTraslado)
                        .Include(r => r.Producto)
                        .Where(r => r.InventarioTrasladoId == inventarioTrasladoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / GetByInventarioTraslado", exception);
            }
        }

        public static InventarioTrasladoDetalle[] GetByProducto(int productoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioTrasladoDetalleSet
                        .Include(r => r.InventarioTraslado)
                        .Include(r => r.Producto)
                        .Where(r => r.ProductoId == productoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioTrasladoDetalleRepository / GetByProducto", exception);
            }
        }
    }
}