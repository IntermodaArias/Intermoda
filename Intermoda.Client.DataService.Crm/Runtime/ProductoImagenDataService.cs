using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class ProductoImagenDataService : IProductoImagenDataService
    {
        public void Update(ProductoImagen productoImagen, Action<ProductoImagen, Exception> action)
        {
            try
            {
                var reg = productoImagen.Id == 0
                    ? ProductoImagenRepository.Insert(productoImagen)
                    : ProductoImagenRepository.Update(productoImagen);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int productoImagenId, Action<Exception> action)
        {
            try
            {
                ProductoImagenRepository.Delete(productoImagenId);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int productoImagenId, Action<ProductoImagen, Exception> action)
        {
            try
            {
                var reg = ProductoImagenRepository.Get(productoImagenId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<ProductoImagen>, Exception> action)
        {
            try
            {
                var lista = ProductoImagenRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByProducto(int productoId, Action<List<ProductoImagen>, Exception> action)
        {
            try
            {
                var lista = ProductoImagenRepository.GetByProducto(productoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}