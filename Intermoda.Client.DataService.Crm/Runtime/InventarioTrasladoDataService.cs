using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioTrasladoDataService : IInventarioTrasladoDataService
    {
        public void Update(InventarioTraslado inventarioTraslado, Action<InventarioTraslado, Exception> action)
        {
            try
            {
                var reg = inventarioTraslado.Id == 0
                    ? InventarioTrasladoRepository.Insert(inventarioTraslado)
                    : InventarioTrasladoRepository.Update(inventarioTraslado);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int inventarioTrasladoId, Action<Exception> action)
        {
            try
            {
                InventarioTrasladoRepository.Delete(inventarioTrasladoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int inventarioTrasladoId, Action<InventarioTraslado, Exception> action)
        {
            try
            {
                var reg = InventarioTrasladoRepository.Get(inventarioTrasladoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<InventarioTraslado>, Exception> action)
        {
            try
            {
                var lista = InventarioTrasladoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByClienteOrigen(int clienteOrigenId, Action<List<InventarioTraslado>, Exception> action)
        {
            try
            {
                var lista = InventarioTrasladoRepository.GetByClienteOrigen(clienteOrigenId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByClienteDestino(int clienteDestinoId, Action<List<InventarioTraslado>, Exception> action)
        {
            try
            {
                var lista = InventarioTrasladoRepository.GetByClienteDestino(clienteDestinoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}