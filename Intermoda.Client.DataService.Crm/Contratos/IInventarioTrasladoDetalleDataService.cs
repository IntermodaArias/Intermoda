using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IInventarioTrasladoDetalleDataService
    {
        void Update(InventarioTrasladoDetalle inventarioTrasladoDetalle, Action<InventarioTrasladoDetalle, Exception> action);

        void Delete(int inventarioTrasladoDetalleId, Action<Exception> action);

        void Get(int inventarioTrasladoDetalleId, Action<InventarioTrasladoDetalle, Exception> action);

        void GetAll(Action<List<InventarioTrasladoDetalle>, Exception> action);

        void GetByInventarioTraslado(int inventarioTrasladoId, Action<List<InventarioTrasladoDetalle>, Exception> action);

        void GetByProducto(int productoId, Action<List<InventarioTrasladoDetalle>, Exception> action);
    }
}