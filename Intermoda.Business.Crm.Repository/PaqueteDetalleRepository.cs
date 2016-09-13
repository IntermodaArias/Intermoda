using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class PaqueteDetalleRepository
    {

        private static CrmContext _context;

        public static PaqueteDetalle Insert(PaqueteDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteDetalleSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Paquete = PaqueteRepository.Get(model.PaqueteId);
                    model.Producto = ProductoRepository.Get(model.ProductoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / Insert", exception);
            }
        }

        public static PaqueteDetalle Update(PaqueteDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.PaqueteId = model.PaqueteId;
                        reg.ProductoId = model.ProductoId;

                        _context.SaveChanges();

                        model.Paquete = PaqueteRepository.Get(model.PaqueteId);
                        model.Producto = ProductoRepository.Get(model.ProductoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de PaqueteDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / Update", exception);
            }
        }

        public static void Delete(PaqueteDetalle model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteDetalleSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.PaqueteDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de PaqueteDetalle con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int paqueteDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.PaqueteDetalleSet
                    .FirstOrDefault(r => r.Id == paqueteDetalleId);

                    if (reg != null)
                    {
                        _context.PaqueteDetalleSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de PaqueteDetalle con Id: {paqueteDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / Delete (id)", exception);
            }
        }

        public static PaqueteDetalle Get(int paqueteDetalleId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.PaqueteDetalleSet
                        .Include(r => r.Paquete)
                        .Include(r => r.Producto)
                        .FirstOrDefault(r => r.Id == paqueteDetalleId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de PaqueteDetalle con Id: {paqueteDetalleId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / Get", exception);
            }
        }

        public static PaqueteDetalle[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PaqueteDetalleSet
                        .Include(r => r.Paquete)
                        .Include(r => r.Producto)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / GetAll", exception);
            }
        }

        public static PaqueteDetalle[] GetByPaquete(int paqueteId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PaqueteDetalleSet
                        .Include(r => r.Paquete)
                        .Include(r => r.Producto)
                        .Where(r => r.PaqueteId == paqueteId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / GetByPaquete", exception);
            }
        }

        public static PaqueteDetalle[] GetByProducto(int productoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.PaqueteDetalleSet
                        .Include(r => r.Paquete)
                        .Include(r => r.Producto)
                        .Where(r => r.ProductoId == productoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("PaqueteDetalleRepository / GetByProducto", exception);
            }
        }
    }
}