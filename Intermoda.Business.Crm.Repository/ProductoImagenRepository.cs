using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class ProductoImagenRepository
    {
        private static CrmContext _context;

        public static ProductoImagen Insert(ProductoImagen model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoImagenSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Producto = ProductoRepository.Get(model.ProductoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / Insert", exception);
            }
        }

        public static ProductoImagen Update(ProductoImagen model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoImagenSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.ProductoId = model.ProductoId;
                        reg.Secuencia = model.Secuencia;
                        reg.Ruta = model.Ruta;

                        _context.SaveChanges();

                        model.Producto = ProductoRepository.Get(model.ProductoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoImagen con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / Update", exception);
            }
        }

        public static void Delete(ProductoImagen model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoImagenSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.ProductoImagenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoImagen con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int productoImagenId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoImagenSet
                    .FirstOrDefault(r => r.Id == productoImagenId);

                    if (reg != null)
                    {
                        _context.ProductoImagenSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoImagen con Id: {productoImagenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / Delete (id)", exception);
            }
        }

        public static ProductoImagen Get(int productoImagenId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.ProductoImagenSet
                        .Include(r => r.Producto)
                        .FirstOrDefault(r => r.Id == productoImagenId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoImagen con Id: {productoImagenId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / Get", exception);
            }
        }

        public static ProductoImagen[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ProductoImagenSet
                        .Include(r => r.Producto)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / GetAll", exception);
            }
        }

        public static ProductoImagen[] GetByProducto(int productoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ProductoImagenSet
                        .Include(r => r.Producto)
                        .Where(r => r.ProductoId == productoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoImagenRepository / GetByProducto", exception);
            }
        }
    }
}