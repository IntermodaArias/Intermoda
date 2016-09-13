using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class PagoTipoDesignDataService : IPagoTipoDataService
    {
        public void Update(PagoTipo pagoTipo, Action<PagoTipo, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int pagoTipoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int pagoTipoId, Action<PagoTipo, Exception> action)
        {
            var reg = MockData.PagoTipo();
            action(reg, null);
        }

        public void GetAll(Action<List<PagoTipo>, Exception> action)
        {
            var lista = new List<PagoTipo>();
            var reg = MockData.PagoTipo();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}