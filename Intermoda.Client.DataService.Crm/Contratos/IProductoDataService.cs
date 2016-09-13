using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IProductoDataService
    {
        void Update(Producto producto, Action<Producto, Exception> action);

        void Delete(int productoId, Action<Exception> action);

        void Get(int productoId, Action<Producto, Exception> action);

        void GetAll(Action<List<Producto>, Exception> action);

        void GetByEdad(int edadId, Action<List<Producto>, Exception> action);

        void GetByProductoCategoria(int productoCategoriaId, Action<List<Producto>, Exception> action);
    }
}