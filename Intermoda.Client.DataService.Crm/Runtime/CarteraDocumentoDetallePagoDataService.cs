using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDetallePagoDataService : ICarteraDocumentoDetallePagoDataService
    {
        public void Update(CarteraDocumentoDetallePago carteraDocumentoDetallePago, Action<CarteraDocumentoDetallePago, Exception> action)
        {
            try
            {
                var reg = carteraDocumentoDetallePago.Id == 0
                    ? CarteraDocumentoDetallePagoRepository.Insert(carteraDocumentoDetallePago)
                    : CarteraDocumentoDetallePagoRepository.Update(carteraDocumentoDetallePago);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int carteraDocumentoDetallePagoId, Action<Exception> action)
        {
            try
            {
                CarteraDocumentoDetallePagoRepository.Delete(carteraDocumentoDetallePagoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int carteraDocumentoDetallePagoId, Action<CarteraDocumentoDetallePago, Exception> action)
        {
            try
            {
                var reg = CarteraDocumentoDetallePagoRepository.Get(carteraDocumentoDetallePagoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<CarteraDocumentoDetallePago>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetallePagoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCarteraDocumento(int carteraDocumentoId, Action<List<CarteraDocumentoDetallePago>, Exception> action)
        {
            try
            {
                var lista = CarteraDocumentoDetallePagoRepository.GetByCarteraDocumento(carteraDocumentoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}