using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class GrupoEconomicoDesignDataService : IGrupoEconomicoDataService
    {
        public void Update(GrupoEconomico grupoEconomico, Action<GrupoEconomico, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int grupoEconomicoId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int grupoEconomicoId, Action<GrupoEconomico, Exception> action)
        {
            var reg = MockData.GrupoEconomico();
            action(reg, null);
        }

        public void GetAll(Action<List<GrupoEconomico>, Exception> action)
        {
            var lista = new List<GrupoEconomico>();
            var reg = MockData.GrupoEconomico();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}