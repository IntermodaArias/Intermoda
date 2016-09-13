using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CaiDataService : ICaiDataService
    {
        public void Update(Cai cai, Action<Cai, Exception> action)
        {
            try
            {
                var reg = cai.Id == 0
                    ? CaiRepository.Insert(cai)
                    : CaiRepository.Update(cai);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int caiId, Action<Exception> action)
        {
            try
            {
                CaiRepository.Delete(caiId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int caiId, Action<Cai, Exception> action)
        {
            try
            {
                var reg = CaiRepository.Get(caiId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Cai>, Exception> action)
        {
            try
            {
                var lista = CaiRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCarteraDocumentoTipo(int carteraDocumentoTipoId, Action<List<Cai>, Exception> action)
        {
            try
            {
                var lista = CaiRepository.GetByCarteraDocumentoTipo(carteraDocumentoTipoId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}