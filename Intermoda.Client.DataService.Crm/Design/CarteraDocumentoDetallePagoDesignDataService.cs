using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDetallePagoDesignDataService : ICarteraDocumentoDetallePagoDataService
    {
        public void Update(CarteraDocumentoDetallePago carteraDocumentoDetallePago, Action<CarteraDocumentoDetallePago, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carteraDocumentoDetallePagoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int carteraDocumentoDetallePagoId, Action<CarteraDocumentoDetallePago, Exception> action)
        {

            var reg = MockData.CarteraDocumentoDetallePago();
            action(reg, null);
        }

        public void GetAll(Action<List<CarteraDocumentoDetallePago>, Exception> action)
        {

            var lista = new List<CarteraDocumentoDetallePago>();
            var reg = MockData.CarteraDocumentoDetallePago();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCarteraDocumento(int carteraDocumentoId, Action<List<CarteraDocumentoDetallePago>, Exception> action)
        {
            var lista = new List<CarteraDocumentoDetallePago>();
            var reg = MockData.CarteraDocumentoDetallePago();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}