using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IInventarioTrasladoDataService
    {
        void Update(InventarioTraslado inventarioTraslado, Action<InventarioTraslado, Exception> action);

        void Delete(int inventarioTrasladoId, Action<Exception> action);

        void Get(int inventarioTrasladoId, Action<InventarioTraslado, Exception> action);

        void GetAll(Action<List<InventarioTraslado>, Exception> action);

        void GetByClienteOrigen(int clienteOrigenId, Action<List<InventarioTraslado>, Exception> action);

        void GetByClienteDestino(int clienteDestinoId, Action<List<InventarioTraslado>, Exception> action);
    }
}