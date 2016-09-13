using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CarteraDocumentoTipoDesignDataService : ICarteraDocumentoTipoDataService
    {
        public void Update(CarteraDocumentoTipo carteraDocumentoTipo, Action<CarteraDocumentoTipo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int carteraDocumentoTipoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int carteraDocumentoTipoId, Action<CarteraDocumentoTipo, Exception> action)
        {
            var reg = MockData.CarteraDocumentoTipo();
            action(reg, null);
        }

        public void GetAll(Action<List<CarteraDocumentoTipo>, Exception> action)
        {
            var lista = new List<CarteraDocumentoTipo>();
            var reg = MockData.CarteraDocumentoTipo();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}