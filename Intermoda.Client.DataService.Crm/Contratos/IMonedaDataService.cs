using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IMonedaDataService
    {
        void Update(Moneda moneda, Action<Moneda, Exception> action);

        void Delete(int monedaId, Action<Exception> action);

        void Get(int monedaId, Action<Moneda, Exception> action);

        void GetAll(Action<List<Moneda>, Exception> action);
    }
}