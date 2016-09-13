using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IPaqueteDetalleDataService
    {
        void Update(PaqueteDetalle paqueteDetalle, Action<PaqueteDetalle, Exception> action);

        void Delete(int paqueteDetalleId, Action<Exception> action);

        void Get(int paqueteDetalleId, Action<PaqueteDetalle, Exception> action);

        void GetAll(Action<List<PaqueteDetalle>, Exception> action);

        void GetByPaquete(int paqueteId, Action<List<PaqueteDetalle>, Exception> action);

        void GetByProducto(int productoId, Action<List<PaqueteDetalle>, Exception> action);
    }
}