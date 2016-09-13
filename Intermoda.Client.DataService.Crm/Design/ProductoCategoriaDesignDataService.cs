using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class ProductoCategoriaDesignDataService : IProductoCategoriaDataService
    {
        public void Update(ProductoCategoria productoCategoria, Action<ProductoCategoria, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int varId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int varId, Action<ProductoCategoria, Exception> action)
        {
            var reg = MockData.ProductoCategoria();
            action(reg, null);
        }

        public void GetAll(Action<List<ProductoCategoria>, Exception> action)
        {
            var lista = new List<ProductoCategoria>();
            var reg = MockData.ProductoCategoria();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}