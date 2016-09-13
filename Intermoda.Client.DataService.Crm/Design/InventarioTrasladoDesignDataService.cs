using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioTrasladoDesignDataService : IInventarioTrasladoDataService
    {
        public void Update(InventarioTraslado inventarioTraslado, Action<InventarioTraslado, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int inventarioTrasladoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int inventarioTrasladoId, Action<InventarioTraslado, Exception> action)
        {
            var reg = MockData.InventarioTraslado();
            action(reg, null);
        }

        public void GetAll(Action<List<InventarioTraslado>, Exception> action)
        {
            var lista = new List<InventarioTraslado>();
            var reg = MockData.InventarioTraslado();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByClienteOrigen(int clienteOrigenId, Action<List<InventarioTraslado>, Exception> action)
        {
            var lista = new List<InventarioTraslado>();
            var reg = MockData.InventarioTraslado();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByClienteDestino(int clienteDestinoId, Action<List<InventarioTraslado>, Exception> action)
        {
            var lista = new List<InventarioTraslado>();
            var reg = MockData.InventarioTraslado();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}