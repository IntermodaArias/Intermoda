using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICaiDataService
    {

        void Update(Cai cai, Action<Cai, Exception> action);
        void Delete(int caiId, Action<Exception> action);
        void Get(int caiId, Action<Cai, Exception> action);
        void GetAll(Action<List<Cai>, Exception> action);
        void GetByCarteraDocumentoTipo(int carteraDocumentoTipoId, Action<List<Cai>, Exception> action);
    }
}