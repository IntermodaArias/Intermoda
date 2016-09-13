using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class SupervisorZonaDesignDataService : ISupervisorZonaDataService
    {
        public void Update(SupervisorZona supervisorZona, Action<SupervisorZona, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int supervisorZonaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int supervisorZonaId, Action<SupervisorZona, Exception> action)
        {
            var reg = MockData.SupervisorZona();
            action(reg, null);
        }

        public void GetAll(Action<List<SupervisorZona>, Exception> action)
        {
            var lista = new List<SupervisorZona>();
            var reg = MockData.SupervisorZona();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetBySupervisor(int supervisorId, Action<List<SupervisorZona>, Exception> action)
        {
            var lista = new List<SupervisorZona>();
            var reg = MockData.SupervisorZona();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByZona(int zonaId, Action<List<SupervisorZona>, Exception> action)
        {
            var lista = new List<SupervisorZona>();
            var reg = MockData.SupervisorZona();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}