using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class PaqueteDataService : IPaqueteDataService
    {
        public void Update(Paquete paquete, Action<Paquete, Exception> action)
        {
            try
            {
                var reg = paquete.Id == 0
                    ? PaqueteRepository.Insert(paquete)
                    : PaqueteRepository.Update(paquete);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int paqueteId, Action<Exception> action)
        {
            try
            {
                PaqueteRepository.Delete(paqueteId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int paqueteId, Action<Paquete, Exception> action)
        {
            try
            {
                var reg = PaqueteRepository.Get(paqueteId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Paquete>, Exception> action)
        {
            try
            {
                var lista = PaqueteRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}