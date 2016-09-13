using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IProductoImagenDataService
    {
        void Update(ProductoImagen productoImagen, Action<ProductoImagen, Exception> action);

        void Delete(int productoImagenId, Action<Exception> action);

        void Get(int productoImagenId, Action<ProductoImagen, Exception> action);

        void GetAll(Action<List<ProductoImagen>, Exception> action);

        void GetByProducto(int productoId, Action<List<ProductoImagen>, Exception> action);
    }
}