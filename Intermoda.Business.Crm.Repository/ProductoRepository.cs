using System;
using System.Data.Entity;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class ProductoRepository
    {
        private static CrmContext _context;

        public static Producto Insert(Producto model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;
                    model.Edad = EdadRepository.Get(model.EdadId);
                    model.ProductoCategoria = ProductoCategoriaRepository.Get(model.ProductoCategoriaId);

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / Insert", exception);
            }
        }

        public static Producto Update(Producto model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;
                        reg.Barcode = model.Barcode;
                        reg.Base = model.Base;
                        reg.Variante = model.Variante;
                        reg.Tela = model.Tela;
                        reg.Lavado = model.Lavado;
                        reg.Color = model.Color;
                        reg.Talla = model.Talla;
                        reg.EdadId = model.EdadId;
                        reg.ProductoCategoriaId = model.ProductoCategoriaId;
                        reg.Existencia = model.Existencia;

                        _context.SaveChanges();

                        model.Edad = EdadRepository.Get(model.EdadId);
                        model.ProductoCategoria = ProductoCategoriaRepository.Get(model.ProductoCategoriaId);

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Producto con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / Update", exception);
            }
        }

        public static void Delete(Producto model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.ProductoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Producto con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int productoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoSet
                    .FirstOrDefault(r => r.Id == productoId);

                    if (reg != null)
                    {
                        _context.ProductoSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de Producto con Id: {productoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / Delete (id)", exception);
            }
        }

        public static Producto Get(int productoId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.ProductoSet
                        .Include(r => r.Edad)
                        .Include(r => r.ProductoCategoria)
                        .FirstOrDefault(r => r.Id == productoId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de Producto con Id: {productoId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / Get", exception);
            }
        }

        public static Producto[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ProductoSet
                        .Include(r => r.Edad)
                        .Include(r => r.ProductoCategoria)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / GetAll", exception);
            }
        }

        public static Producto[] GetByEdad(int edadId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ProductoSet
                        .Include(r => r.Edad)
                        .Include(r => r.ProductoCategoria)
                        .Where(r => r.EdadId == edadId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / GetByEdad", exception);
            }
        }

        public static Producto[] GetByProductoCategoria(int productoCategoriaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ProductoSet
                        .Include(r => r.Edad)
                        .Include(r => r.ProductoCategoria)
                        .Where(r => r.ProductoCategoriaId == productoCategoriaId)
                        .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoRepository / GetByProductoCategoria", exception);
            }
        }
    }
}