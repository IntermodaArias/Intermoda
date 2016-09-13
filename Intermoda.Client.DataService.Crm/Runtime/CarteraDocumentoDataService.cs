using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDataService: ICarteraDocumentoDataService
    {
        public void Update(CarteraDocumento carteraDocumento, Action<CarteraDocumento, Exception> action)
        {
            try
            {
                var reg = carteraDocumento.Id == 0
                    ? CarteraDocumentoRepository.Insert(carteraDocumento)
                    : CarteraDocumentoRepository.Update(carteraDocumento);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int carteraDocumentoId, Action<Exception> action)
        {
            try
            {
                CarteraDocumentoRepository.Delete(carteraDocumentoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int carteraDocumentoId, Action<CarteraDocumento, Exception> action)
        {
            try
            {
                var reg = CarteraDocumentoRepository.Get(carteraDocumentoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<CarteraDocumento>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCliente(int clienteId, Action<List<CarteraDocumento>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoRepository.GetByCliente(clienteId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByPaquete(int paqueteId, Action<List<CarteraDocumento>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoRepository.GetByPaquete(paqueteId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByPedidoTipo(int pedidoTipoId, Action<List<CarteraDocumento>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoRepository.GetByPedidoTipo(pedidoTipoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}