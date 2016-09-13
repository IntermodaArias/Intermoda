using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class InventarioFisicoDetalleRepository
    {

        private static CrmContext _context;

        public static InventarioFisicoDetalle Insert(InventarioFisicoDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoDetalleSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.InventarioFisico = InventarioFisicoRepository.Get(model.InventarioFisicoId);
                    model.Producto = ProductoRepository.Get(model.ProductoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / Insert", exception);
            }
        }

        public static InventarioFisicoDetalle Update(InventarioFisicoDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.InventarioFisicoId = model.InventarioFisicoId;
                        reg.ProductoId = model.ProductoId;
                        reg.Cantidad = model.Cantidad;

                        _context.SaveChanges();

                        model.InventarioFisico = InventarioFisicoRepository.Get(model.InventarioFisicoId);
                        model.Producto = ProductoRepository.Get(model.ProductoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisicoDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / Update", exception);
            }
        }

        public static void Delete(InventarioFisicoDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.InventarioFisicoDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisicoDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int inventarioFisicoDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.InventarioFisicoDetalleSet
                    .FirstOrDefault(r => r.Id == inventarioFisicoDetalleId);

                    if (reg != null)
                    {
                        _context.InventarioFisicoDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisicoDetalle con Id: {inventarioFisicoDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / Delete (id)", exception);
            }
        }

        public static InventarioFisicoDetalle Get(int inventarioFisicoDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.InventarioFisicoDetalleSet
                        .Include(r => r.InventarioFisico)
                        .Include(r => r.Producto)
                        .FirstOrDefault(r => r.Id == inventarioFisicoDetalleId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de InventarioFisicoDetalle con Id: {inventarioFisicoDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / Get", exception);
            }
        }

        public static InventarioFisicoDetalle[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioFisicoDetalleSet
                        .Include(r => r.InventarioFisico)
                        .Include(r => r.Producto)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / GetAll", exception);
            }
        }

        public static InventarioFisicoDetalle[] GetByInventarioFisico(int inventarioFisicoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.InventarioFisicoDetalleSet
                        .Include(r => r.InventarioFisico)
                        .Include(r => r.Producto)
                        .Where(r => r.InventarioFisicoId == inventarioFisicoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InventarioFisicoDetalleRepository / GetAll", exception);
            }
        }
    }
}