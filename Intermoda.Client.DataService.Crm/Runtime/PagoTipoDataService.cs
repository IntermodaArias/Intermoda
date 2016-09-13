using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class PagoTipoDataService : IPagoTipoDataService
    {
        public void Update(PagoTipo pagoTipo, Action<PagoTipo, Exception> action)
        {
            try
            {
                var reg = pagoTipo.Id == 0
                    ? PagoTipoRepository.Insert(pagoTipo)
                    : PagoTipoRepository.Update(pagoTipo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int pagoTipoId, Action<Exception> action)
        {
            try
            {
                PagoTipoRepository.Delete(pagoTipoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int pagoTipoId, Action<PagoTipo, Exception> action)
        {
            try
            {
                var reg = PagoTipoRepository.Get(pagoTipoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<PagoTipo>, Exception> action)
        {
            try
            {
                var lista = PagoTipoRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}