using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IProductoCategoriaDataService
    {
        void Update(ProductoCategoria productoCategoria, Action<ProductoCategoria, Exception> action);

        void Delete(int varId, Action<Exception> action);

        void Get(int varId, Action<ProductoCategoria, Exception> action);

        void GetAll(Action<List<ProductoCategoria>, Exception> action);
    }
}