using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioTrasladoDetalleDataService : IInventarioTrasladoDetalleDataService
    {
        public void Update(InventarioTrasladoDetalle inventarioTrasladoDetalle, Action<InventarioTrasladoDetalle, Exception> action)
        {
            try
            {
                var reg = inventarioTrasladoDetalle.Id == 0
                    ? InventarioTrasladoDetalleRepository.Insert(inventarioTrasladoDetalle)
                    : InventarioTrasladoDetalleRepository.Update(inventarioTrasladoDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int inventarioTrasladoDetalleId, Action<Exception> action)
        {
            try
            {
                InventarioTrasladoDetalleRepository.Delete(inventarioTrasladoDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action( exception);
            }
        }

        public void Get(int inventarioTrasladoDetalleId, Action<InventarioTrasladoDetalle, Exception> action)
        {
            try
            {
                var reg = InventarioTrasladoDetalleRepository.Get(inventarioTrasladoDetalleId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<InventarioTrasladoDetalle>, Exception> action)
        {
            try
            {
                var lista = InventarioTrasladoDetalleRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByInventarioTraslado(int inventarioTrasladoId, Action<List<InventarioTrasladoDetalle>, Exception> action)
        {
            try
            {
                var lista = InventarioTrasladoDetalleRepository.GetByInventarioTraslado(inventarioTrasladoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByProducto(int productoId, Action<List<InventarioTrasladoDetalle>, Exception> action)
        {
            try
            {
                var lista = InventarioTrasladoDetalleRepository.GetByProducto(productoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}