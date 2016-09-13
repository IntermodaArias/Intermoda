using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class SupervisorZonaDataService : ISupervisorZonaDataService
    {
        public void Update(SupervisorZona supervisorZona, Action<SupervisorZona, Exception> action)
        {
            try
            {
                var reg = supervisorZona.Id == 0
                    ? SupervisorZonaRepository.Insert(supervisorZona)
                    : SupervisorZonaRepository.Update(supervisorZona);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int supervisorZonaId, Action<Exception> action)
        {
            try
            {
                SupervisorZonaRepository.Delete(supervisorZonaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int supervisorZonaId, Action<SupervisorZona, Exception> action)
        {
            try
            {
                var reg = SupervisorZonaRepository.Get(supervisorZonaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<SupervisorZona>, Exception> action)
        {
            try
            {
                var lista = SupervisorZonaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetBySupervisor(int supervisorId, Action<List<SupervisorZona>, Exception> action)
        {
            try
            {
                var lista = SupervisorZonaRepository.GetBySupervisor(supervisorId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByZona(int zonaId, Action<List<SupervisorZona>, Exception> action)
        {
            try
            {
                var lista = SupervisorZonaRepository.GetByZona(zonaId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}