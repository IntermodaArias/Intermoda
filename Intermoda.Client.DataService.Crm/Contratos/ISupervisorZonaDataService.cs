using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ISupervisorZonaDataService
    {
        void Update(SupervisorZona supervisorZona, Action<SupervisorZona, Exception> action);

        void Delete(int supervisorZonaId, Action<Exception> action);

        void Get(int supervisorZonaId, Action<SupervisorZona, Exception> action);

        void GetAll(Action<List<SupervisorZona>, Exception> action);

        void GetBySupervisor(int supervisorId, Action<List<SupervisorZona>, Exception> action);

        void GetByZona(int zonaId, Action<List<SupervisorZona>, Exception> action);
    }
}