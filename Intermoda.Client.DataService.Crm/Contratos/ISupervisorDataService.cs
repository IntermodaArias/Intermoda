using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ISupervisorDataService
    {
        void Update(Supervisor supervisor, Action<Supervisor, Exception> action);

        void Delete(int supervisorId, Action<Exception> action);

        void Get(int supervisorId, Action<Supervisor, Exception> action);

        void GetAll(Action<List<Supervisor>, Exception> action);
    }
}