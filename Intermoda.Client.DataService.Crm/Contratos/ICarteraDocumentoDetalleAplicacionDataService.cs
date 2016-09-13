using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICarteraDocumentoDetalleAplicacionDataService
    {

        void Update(CarteraDocumentoDetalleAplicacion carteraDocumentoDetalleAplicacion,
            Action<CarteraDocumentoDetalleAplicacion, Exception> action);

        void Delete(int carteraDocumentoDetalleAplicacionId, Action<Exception> action);

        void Get(int carteraDocumentoDetalleAplicacionId, Action<CarteraDocumentoDetalleAplicacion, Exception> action);

        void GetAll(Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action);

        void GetByCarteraDocumentoDebito(int carteraDocumentoDebitoId,
            Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action);

        void GetByCarteraDocumentoCredito(int carteraDocumentoCreditoId,
            Action<List<CarteraDocumentoDetalleAplicacion>, Exception> action);
    }
}