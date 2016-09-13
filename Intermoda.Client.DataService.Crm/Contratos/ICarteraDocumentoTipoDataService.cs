using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICarteraDocumentoTipoDataService
    {
        void Update(CarteraDocumentoTipo carteraDocumentoTipo, Action<CarteraDocumentoTipo, Exception> action);

        void Delete(int carteraDocumentoTipoId, Action<Exception> action);

        void Get(int carteraDocumentoTipoId, Action<CarteraDocumentoTipo, Exception> action);

        void GetAll(Action<List<CarteraDocumentoTipo>, Exception> action); 
    }
}