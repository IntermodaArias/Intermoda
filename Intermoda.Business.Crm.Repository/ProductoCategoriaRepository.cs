using System;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Crm.Data;

namespace Intermoda.Business.Crm.Repository
{
    public class ProductoCategoriaRepository
    {
        private static CrmContext _context;

        public static ProductoCategoria Insert(ProductoCategoria model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoCategoriaSet.Add(model);
                    _context.SaveChanges();

                    model.Id = reg.Id;

                    return model;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoCategoriaRepository / Insert", exception);
            }
        }

        public static ProductoCategoria Update(ProductoCategoria model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoCategoriaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        reg.Codigo = model.Codigo;
                        reg.Nombre = model.Nombre;

                        _context.SaveChanges();

                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoCategoria con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoCategoriaRepository / Update", exception);
            }
        }

        public static void Delete(ProductoCategoria model)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoCategoriaSet
                    .FirstOrDefault(r => r.Id == model.Id);

                    if (reg != null)
                    {
                        _context.ProductoCategoriaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoCategoria con Id: {model.Id}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoCategoriaRepository / Delete (model)", exception);
            }
        }

        public static void Delete(int productoCategoriaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var reg = _context.ProductoCategoriaSet
                    .FirstOrDefault(r => r.Id == productoCategoriaId);

                    if (reg != null)
                    {
                        _context.ProductoCategoriaSet.Remove(reg);
                        _context.SaveChanges();

                        return;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoCategoria con Id: {productoCategoriaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoCategoriaRepository / Delete (id)", exception);
            }
        }

        public static ProductoCategoria Get(int productoCategoriaId)
        {
            try
            {
                using (_context = new CrmContext())
                {
                    var model = _context.ProductoCategoriaSet
                    .FirstOrDefault(r => r.Id == productoCategoriaId);

                    if (model != null)
                    {
                        return model;
                    }
                    throw new Exception($"No se ha encontrado registro de ProductoCategoria con Id: {productoCategoriaId}");
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoCategoriaRepository / Get", exception);
            }
        }

        public static ProductoCategoria[] GetAll()
        {
            try
            {
                using (_context = new CrmContext())
                {
                    return _context.ProductoCategoriaSet
                    .ToArray();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProductoCategoriaRepository / GetAll", exception);
            }
        } 
    }
}