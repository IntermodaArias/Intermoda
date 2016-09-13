using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IPedidoTipoDataService
    {
        void Update(PedidoTipo pedidoTipo, Action<PedidoTipo, Exception> action);

        void Delete(int pedidoTipoId, Action<Exception> action);

        void Get(int pedidoTipoId, Action<PedidoTipo, Exception> action);

        void GetAll(Action<List<PedidoTipo>, Exception> action);
    }
}