using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class SupervisorDataService : ISupervisorDataService
    {
        public void Update(Supervisor supervisor, Action<Supervisor, Exception> action)
        {
            try
            {
                var reg = supervisor.Id == 0
                    ? SupervisorRepository.Insert(supervisor)
                    : SupervisorRepository.Update(supervisor);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int supervisorId, Action<Exception> action)
        {
            try
            {
                SupervisorRepository.Delete(supervisorId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int supervisorId, Action<Supervisor, Exception> action)
        {
            try
            {
                var reg = SupervisorRepository.Get(supervisorId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Supervisor>, Exception> action)
        {
            try
            {
                var lista = SupervisorRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}