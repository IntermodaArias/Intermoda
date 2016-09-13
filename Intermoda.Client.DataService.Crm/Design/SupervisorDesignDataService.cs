using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class SupervisorDesignDataService : ISupervisorDataService
    {
        public void Update(Supervisor supervisor, Action<Supervisor, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int supervisorId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int supervisorId, Action<Supervisor, Exception> action)
        {
            var reg = MockData.Supervisor();
            action(reg, null);
        }

        public void GetAll(Action<List<Supervisor>, Exception> action)
        {
            var lista = new List<Supervisor>();
            var reg = MockData.Supervisor();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}