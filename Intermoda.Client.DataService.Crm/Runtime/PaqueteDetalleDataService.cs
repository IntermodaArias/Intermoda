using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class PaqueteDetalleDataService : IPaqueteDetalleDataService
    {
        public void Update(PaqueteDetalle paqueteDetalle, Action<PaqueteDetalle, Exception> action)
        {
            try
            {
                var reg = paqueteDetalle.Id == 0
                    ? PaqueteDetalleRepository.Insert(paqueteDetalle)
                    : PaqueteDetalleRepository.Update(paqueteDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int paqueteDetalleId, Action<Exception> action)
        {
            try
            {
                PaqueteDetalleRepository.Delete(paqueteDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int paqueteDetalleId, Action<PaqueteDetalle, Exception> action)
        {
            try
            {
                var reg = PaqueteDetalleRepository.Get(paqueteDetalleId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<PaqueteDetalle>, Exception> action)
        {
            try
            {
                var lista = PaqueteDetalleRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByPaquete(int paqueteId, Action<List<PaqueteDetalle>, Exception> action)
        {
            try
            {
                var lista = PaqueteDetalleRepository.GetByPaquete(paqueteId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByProducto(int productoId, Action<List<PaqueteDetalle>, Exception> action)
        {
            try
            {
                var lista = PaqueteDetalleRepository.GetByProducto(productoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}