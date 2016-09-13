using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CaiDesignDataService : ICaiDataService
    {
        public void Update(Cai cai, Action<Cai, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int caiId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int caiId, Action<Cai, Exception> action)
        {
            var reg = MockData.Cai();
            action(reg, null);

        }

        public void GetAll(Action<List<Cai>, Exception> action)
        {
            var lista = new List<Cai>();
            var reg = MockData.Cai();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCarteraDocumentoTipo(int carteraDocumentoTipoId, Action<List<Cai>, Exception> action)
        {
            var lista = new List<Cai>();
            var reg = MockData.Cai();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}