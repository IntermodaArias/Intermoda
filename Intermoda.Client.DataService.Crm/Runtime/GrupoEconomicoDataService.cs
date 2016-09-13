using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class GrupoEconomicoDataService : IGrupoEconomicoDataService
    {
        public void Update(GrupoEconomico grupoEconomico, Action<GrupoEconomico, Exception> action)
        {
            try
            {
                var reg = grupoEconomico.Id == 0
                    ? GrupoEconomicoRepository.Insert(grupoEconomico)
                    : GrupoEconomicoRepository.Update(grupoEconomico);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int grupoEconomicoId, Action<Exception> action)
        {
            try
            {
                GrupoEconomicoRepository.Delete(grupoEconomicoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int grupoEconomicoId, Action<GrupoEconomico, Exception> action)
        {
            try
            {
                var reg = GrupoEconomicoRepository.Get(grupoEconomicoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<GrupoEconomico>, Exception> action)
        {
            try
            {
                var lista = GrupoEconomicoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}