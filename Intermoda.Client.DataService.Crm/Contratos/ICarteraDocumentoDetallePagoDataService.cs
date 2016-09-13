using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICarteraDocumentoDetallePagoDataService
    {

        void Update(CarteraDocumentoDetallePago carteraDocumentoDetallePago, Action<CarteraDocumentoDetallePago, Exception> action);

        void Delete(int carteraDocumentoDetallePagoId, Action<Exception> action);

        void Get(int carteraDocumentoDetallePagoId, Action<CarteraDocumentoDetallePago, Exception> action);

        void GetAll(Action<List<CarteraDocumentoDetallePago>, Exception> action);

        void GetByCarteraDocumento(int carteraDocumentoId, Action<List<CarteraDocumentoDetallePago>, Exception> action);
    }
}