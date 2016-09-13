using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class PedidoTipoDataService : IPedidoTipoDataService
    {
        public void Update(PedidoTipo pedidoTipo, Action<PedidoTipo, Exception> action)
        {
            try
            {
                var reg = pedidoTipo.Id == 0
                    ? PedidoTipoRepository.Insert(pedidoTipo)
                    : PedidoTipoRepository.Update(pedidoTipo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int pedidoTipoId, Action<Exception> action)
        {
            try
            {
                PedidoTipoRepository.Delete(pedidoTipoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int pedidoTipoId, Action<PedidoTipo, Exception> action)
        {
            try
            {
                var reg = PedidoTipoRepository.Get(pedidoTipoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<PedidoTipo>, Exception> action)
        {
            try
            {
                var lista = PedidoTipoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}