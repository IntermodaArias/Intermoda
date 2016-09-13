using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class ProductoCategoriaDataService : IProductoCategoriaDataService
    {
        public void Update(ProductoCategoria productoCategoria, Action<ProductoCategoria, Exception> action)
        {
            try
            {
                var reg = productoCategoria.Id == 0
                    ? ProductoCategoriaRepository.Insert(productoCategoria)
                    : ProductoCategoriaRepository.Update(productoCategoria);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int productoCategoriaId, Action<Exception> action)
        {
            try
            {
                ProductoCategoriaRepository.Delete(productoCategoriaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int productoCategoriaId, Action<ProductoCategoria, Exception> action)
        {
            try
            {
                var reg = ProductoCategoriaRepository.Get(productoCategoriaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<ProductoCategoria>, Exception> action)
        {
            try
            {
                var lista = ProductoCategoriaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}