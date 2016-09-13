using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class MonedaDataService : IMonedaDataService
    {
        public void Update(Moneda moneda, Action<Moneda, Exception> action)
        {
            try
            {
                var reg = moneda.Id == 0
                    ? MonedaRepository.Insert(moneda)
                    : MonedaRepository.Update(moneda);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int monedaId, Action<Exception> action)
        {
            try
            {
                MonedaRepository.Delete(monedaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int monedaId, Action<Moneda, Exception> action)
        {
            try
            {
                var reg = MonedaRepository.Get(monedaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Moneda>, Exception> action)
        {
            try
            {
                var lista = MonedaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}