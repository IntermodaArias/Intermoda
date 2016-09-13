using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class CarteraDocumentoDetalleProductoRepository
    {

        private static CrmContext _context;

        public static CarteraDocumentoDetalleProducto Insert(CarteraDocumentoDetalleProducto model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleProductoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.CarteraDocumento = CarteraDocumentoRepository.Get(model.CarteraDocumentoId);
                    model.Producto = ProductoRepository.Get(model.ProductoId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / Insert", exception);
            }
        }

        public static CarteraDocumentoDetalleProducto Update(CarteraDocumentoDetalleProducto model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleProductoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.CarteraDocumentoId = model.CarteraDocumentoId;
                        reg.Linea = model.Linea;
                        reg.ProductoId = model.ProductoId;
                        reg.Cantidad = model.Cantidad;
                        reg.Precio = model.Precio;

                        _context.SaveChanges();

                        model.CarteraDocumento = CarteraDocumentoRepository.Get(model.CarteraDocumentoId);
                        model.Producto = ProductoRepository.Get(model.ProductoId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleProducto con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / Update", exception);
            }
        }

        public static void Delete(CarteraDocumentoDetalleProducto model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleProductoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoDetalleProductoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleProducto con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int carteraDocumentoDetalleProductoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.CarteraDocumentoDetalleProductoSet
                    .FirstOrDefault(r => r.Id == carteraDocumentoDetalleProductoId);

                    if (reg != null)
                    {
                        _context.CarteraDocumentoDetalleProductoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleProducto con Id: {carteraDocumentoDetalleProductoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / Delete (id)", exception);
            }
        }

        public static CarteraDocumentoDetalleProducto Get(int carteraDocumentoDetalleProductoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.CarteraDocumentoDetalleProductoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.Producto)
                        .FirstOrDefault(r => r.Id == carteraDocumentoDetalleProductoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de CarteraDocumentoDetalleProducto con Id: {carteraDocumentoDetalleProductoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / Get", exception);
            }
        }

        public static CarteraDocumentoDetalleProducto[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetalleProductoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.Producto)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / GetAll", exception);
            }
        }

        public static CarteraDocumentoDetalleProducto[] GetByCarteraDocumento(int carteraDocumentoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetalleProductoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.Producto)
                        .Where(r => r.CarteraDocumentoId == carteraDocumentoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / GetByCarteraDocumento", exception);
            }
        }

        public static CarteraDocumentoDetalleProducto[] GetByProducto(int productoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.CarteraDocumentoDetalleProductoSet
                        .Include(r => r.CarteraDocumento)
                        .Include(r => r.Producto)
                        .Where(r => r.ProductoId == productoId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CarteraDocumentoDetalleProductoRepository / GetByProducto", exception);
            }
        }
    }
}