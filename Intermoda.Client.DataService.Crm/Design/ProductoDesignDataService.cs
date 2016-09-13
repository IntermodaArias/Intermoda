using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class ProductoDesignDataService : IProductoDataService
    {
        public void Update(Producto producto, Action<Producto, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int productoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int productoId, Action<Producto, Exception> action)
        {
            var reg = MockData.Producto();
            action(reg, null);
        }

        public void GetAll(Action<List<Producto>, Exception> action)
        {
            var lista = new List<Producto>();
            var reg = MockData.Producto();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByEdad(int edadId, Action<List<Producto>, Exception> action)
        {
            var lista = new List<Producto>();
            var reg = MockData.Producto();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByProductoCategoria(int productoCategoriaId, Action<List<Producto>, Exception> action)
        {
            var lista = new List<Producto>();
            var reg = MockData.Producto();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}