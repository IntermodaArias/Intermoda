using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class PaqueteDesignDataService : IPaqueteDataService
    {
        public void Update(Paquete paquete, Action<Paquete, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int paqueteId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int paqueteId, Action<Paquete, Exception> action)
        {
            var reg = MockData.Paquete();
            action(reg, null);
        }

        public void GetAll(Action<List<Paquete>, Exception> action)
        {
            var lista = new List<Paquete>();
            var reg = MockData.Paquete();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}