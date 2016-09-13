using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioTrasladoDetalleDesignDataService : IInventarioTrasladoDetalleDataService
    {
        public void Update(InventarioTrasladoDetalle inventarioTrasladoDetalle, Action<InventarioTrasladoDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int inventarioTrasladoDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int inventarioTrasladoDetalleId, Action<InventarioTrasladoDetalle, Exception> action)
        {
            var reg = MockData.InventarioTrasladoDetalle();
            action(reg, null);
        }

        public void GetAll(Action<List<InventarioTrasladoDetalle>, Exception> action)
        {
            var lista = new List<InventarioTrasladoDetalle>();
            var reg = MockData.InventarioTrasladoDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByInventarioTraslado(int inventarioTrasladoId, Action<List<InventarioTrasladoDetalle>, Exception> action)
        {
            var lista = new List<InventarioTrasladoDetalle>();
            var reg = MockData.InventarioTrasladoDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByProducto(int productoId, Action<List<InventarioTrasladoDetalle>, Exception> action)
        {
            var lista = new List<InventarioTrasladoDetalle>();
            var reg = MockData.InventarioTrasladoDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}