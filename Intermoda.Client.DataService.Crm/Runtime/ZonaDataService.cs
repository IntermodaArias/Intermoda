using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class ZonaDataService : IZonaDataService
    {
        public void Update(Zona zona, Action<Zona, Exception> action)
        {
            try
            {
                var reg = zona.Id == 0
                    ? ZonaRepository.Insert(zona)
                    : ZonaRepository.Update(zona);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int zonaId, Action<Exception> action)
        {
            try
            {
                ZonaRepository.Delete(zonaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int zonaId, Action<Zona, Exception> action)
        {
            try
            {
                var reg = ZonaRepository.Get(zonaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Zona>, Exception> action)
        {
            try
            {
                var lista = ZonaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}