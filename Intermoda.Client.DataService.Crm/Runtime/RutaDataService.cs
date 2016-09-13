using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class RutaDataService : IRutaDataService
    {
        public void Update(Ruta ruta, Action<Ruta, Exception> action)
        {
            try
            {
                var reg = ruta.Id == 0
                    ? RutaRepository.Insert(ruta)
                    : RutaRepository.Update(ruta);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int rutaId, Action<Exception> action)
        {
            try
            {
                RutaRepository.Delete(rutaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int rutaId, Action<Ruta, Exception> action)
        {
            try
            {
                var reg = RutaRepository.Get(rutaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Ruta>, Exception> action)
        {
            try
            {
                var lista = RutaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByZona(int zonaId, Action<List<Ruta>, Exception> action)
        {
            try
            {
                var lista = RutaRepository.GetByZona(zonaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}