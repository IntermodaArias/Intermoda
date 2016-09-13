using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDetalleAplicacionDataService : ICarteraDocumentoDetalleAplicacionDataService
    {
        public void Update(CarteraDocumentoDetalleAplicacion carteraDocumentoDetalleAplicacion, Action<CarteraDocumentoDetalleAplicacion, Exception> action)
        {
            try
            {
                var reg = carteraDocumentoDetalleAplicacion.Id == 0
                    ? CarteraDocumentoDetalleAplicacionRepository.Insert(carteraDocumentoDetalleAplicacion)
                    : CarteraDocumentoDetalleAplicacionRepository.Update(carteraDocumentoDetalleAplicacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int carteraDocumentoDetalleAplicacionId, Action<Exception> action)
        {
            try
            {
                CarteraDocumentoDetalleAplicacionRepository.Delete(carteraDocumentoDetalleAplicacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int carteraDocumentoDetalleAplicacionId, Action<CarteraDocumentoDetalleAplicacion, Exception> action)
        {
            try
            {
                var reg = CarteraDocumentoDetalleAplicacionRepository.Get(carteraDocumentoDetalleAplicacionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetalleAplicacionRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCarteraDocumentoDebito(int carteraDocumentoDebitoId, Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetalleAplicacionRepository.GetByCarteraDocumentoDebito(carteraDocumentoDebitoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCarteraDocumentoCredito(int carteraDocumentoCreditoId, Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetalleAplicacionRepository.GetByCarteraDocumentoCredito(carteraDocumentoCreditoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}