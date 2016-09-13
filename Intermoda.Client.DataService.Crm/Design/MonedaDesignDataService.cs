using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class MonedaDesignDataService : IMonedaDataService
    {
        public void Update(Moneda moneda, Action<Moneda, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int monedaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int monedaId, Action<Moneda, Exception> action)
        {
            var reg = MockData.Moneda();
            action(reg, null);
        }

        public void GetAll(Action<List<Moneda>, Exception> action)
        {
            var lista = new List<Moneda>();
            var reg = MockData.Moneda();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}