using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IInventarioFisicoDetalleDataService
    {
        void Update(InventarioFisicoDetalle inventarioFisicoDetalle, Action<InventarioFisicoDetalle, Exception> action);

        void Delete(int inventarioFisicoDetalleId, Action<Exception> action);

        void Get(int inventarioFisicoDetalleId, Action<InventarioFisicoDetalle, Exception> action);

        void GetAll(Action<List<InventarioFisicoDetalle>, Exception> action);

        void GetByInventarioFisico(int inventarioFisicoId, Action<List<InventarioFisicoDetalle>, Exception> action);
    }
}