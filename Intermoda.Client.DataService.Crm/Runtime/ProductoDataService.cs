using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class ProductoDataService : IProductoDataService
    {
        public void Update(Producto producto, Action<Producto, Exception> action)
        {
            try
            {
                var reg = producto.Id == 0
                    ? ProductoRepository.Insert(producto)
                    : ProductoRepository.Update(producto);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int productoId, Action<Exception> action)
        {
            try
            {
                ProductoRepository.Delete(productoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int prouctoId, Action<Producto, Exception> action)
        {
            try
            {
                var reg = ProductoRepository.Get(prouctoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Producto>, Exception> action)
        {
            try
            {
                var lista = ProductoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByEdad(int edadId, Action<List<Producto>, Exception> action)
        {
            try
            {
                var lista = ProductoRepository.GetByEdad(edadId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByProductoCategoria(int productoCategoriaId, Action<List<Producto>, Exception> action)
        {
            try
            {
                var lista = ProductoRepository.GetByProductoCategoria(productoCategoriaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}