using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class InventarioFisicoDetalleDataService : IInventarioFisicoDetalleDataService
    {
        public void Update(InventarioFisicoDetalle inventarioFisicoDetalle, Action<InventarioFisicoDetalle, Exception> action)
        {
            try
            {
                var reg = inventarioFisicoDetalle.Id == 0
                    ? InventarioFisicoDetalleRepository.Insert(inventarioFisicoDetalle)
                    : InventarioFisicoDetalleRepository.Update(inventarioFisicoDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int inventarioFisicoDetalleId, Action<Exception> action)
        {
            try
            {
                InventarioFisicoDetalleRepository.Delete(inventarioFisicoDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int inventarioFisicoDetalleId, Action<InventarioFisicoDetalle, Exception> action)
        {
            try
            {
                var reg = InventarioFisicoDetalleRepository.Get(inventarioFisicoDetalleId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<InventarioFisicoDetalle>, Exception> action)
        {
            try
            {
                var lista = InventarioFisicoDetalleRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByInventarioFisico(int inventarioFisicoId, Action<List<InventarioFisicoDetalle>, Exception> action)
        {
            try
            {
                var lista = InventarioFisicoDetalleRepository.GetByInventarioFisico(inventarioFisicoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}