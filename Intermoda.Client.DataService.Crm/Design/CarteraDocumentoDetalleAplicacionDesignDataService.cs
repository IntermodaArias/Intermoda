using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoDetalleAplicacionDesignDataService : ICarteraDocumentoDetalleAplicacionDataService
    {
        public void Update(CarteraDocumentoDetalleAplicacion carteraDocumentoDetalleAplicacion, Action<CarteraDocumentoDetalleAplicacion, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carteraDocumentoDetalleAplicacionId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int carteraDocumentoDetalleAplicacionId, Action<CarteraDocumentoDetalleAplicacion, Exception> action)
        {

            var reg = MockData.CarteraDocumentoDetalleAplicacion();
            action(reg, null);
        }

        public void GetAll(Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action)
        {

            var lista = new List<CarteraDocumentoDetalleAplicacion>();
            var reg = MockData.CarteraDocumentoDetalleAplicacion();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCarteraDocumentoDebito(int carteraDocumentoDebitoId, Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action)
        {
            var lista = new List<CarteraDocumentoDetalleAplicacion>();
            var reg = MockData.CarteraDocumentoDetalleAplicacion();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCarteraDocumentoCredito(int carteraDocumentoCreditoId, Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action)
        {
            var lista = new List<CarteraDocumentoDetalleAplicacion>();
            var reg = MockData.CarteraDocumentoDetalleAplicacion();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}