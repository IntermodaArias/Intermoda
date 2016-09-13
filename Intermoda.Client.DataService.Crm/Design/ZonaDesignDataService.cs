using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class ZonaDesignDataService : IZonaDataService
    {
        public void Update(Zona zona, Action<Zona, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int zonaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int zonaId, Action<Zona, Exception> action)
        {
            var reg = MockData.Zona();
            action(reg, null);
        }

        public void GetAll(Action<List<Zona>, Exception> action)
        {
            var lista = new List<Zona>();
            var reg = MockData.Zona();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}