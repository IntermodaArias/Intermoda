using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class CiudadDataService:ICiudadDataService
    {
        public void Update(Ciudad ciudad, Action<Ciudad, Exception> action)
        {
            try
            {
                var reg = ciudad.Id == 0
                    ? CiudadRepository.Insert(ciudad)
                    : CiudadRepository.Update(ciudad);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int ciudadId, Action<Exception> action)
        {
            try
            {
                CiudadRepository.Delete(ciudadId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int ciudadId, Action<Ciudad, Exception> action)
        {
            try
            {
                var reg = CiudadRepository.Get(ciudadId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Ciudad>, Exception> action)
        {
            try
            {
                var lista = CiudadRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByPais(int paisId, Action<List<Ciudad>, Exception> action)
        {
            try
            {
                var lista = CiudadRepository.GetByPais(paisId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}