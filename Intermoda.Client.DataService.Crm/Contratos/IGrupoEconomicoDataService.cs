using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IGrupoEconomicoDataService
    {
        void Update(GrupoEconomico grupoEconomico, Action<GrupoEconomico, Exception> action);

        void Delete(int grupoEconomicoId, Action<Exception> action);

        void Get(int grupoEconomicoId, Action<GrupoEconomico, Exception> action);

        void GetAll(Action<List<GrupoEconomico>, Exception> action);
    }
}