using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class ProductoImagenDesignDataService : IProductoImagenDataService
    {
        public void Update(ProductoImagen productoImagen, Action<ProductoImagen, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productoImagenId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int productoImagenId, Action<ProductoImagen, Exception> action)
        {
            var reg = MockData.ProductoImagen();
            action(reg, null);
        }

        public void GetAll(Action<List<ProductoImagen>, Exception> action)
        {
            var lista = new List<ProductoImagen>();
            var reg = MockData.ProductoImagen();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByProducto(int productoId, Action<List<ProductoImagen>, Exception> action)
        {
            var lista = new List<ProductoImagen>();
            var reg = MockData.ProductoImagen();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}