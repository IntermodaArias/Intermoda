using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class EdadDesignDataService : IEdadDataService
    {
        public void Update(Edad edad, Action<Edad, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int edadId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int edadId, Action<Edad, Exception> action)
        {
            var reg = MockData.Edad();
            action(reg, null);
        }

        public void GetAll(Action<List<Edad>, Exception> action)
        {
            var lista = new List<Edad>();
            var reg = MockData.Edad();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}