using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class PedidoTipoDesignDataService : IPedidoTipoDataService
    {
        public void Update(PedidoTipo pedidoTipo, Action<PedidoTipo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int pedidoTipoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int pedidoTipoId, Action<PedidoTipo, Exception> action)
        {
            var reg = MockData.PedidoTipo();
            action(reg, null);
        }

        public void GetAll(Action<List<PedidoTipo>, Exception> action)
        {
            var lista = new List<PedidoTipo>();
            var reg = MockData.PedidoTipo();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}