using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class CiudadDesignDataService : ICiudadDataService
    {
        public void Update(Ciudad ciudad, Action<Ciudad, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ciudadId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int ciudadId, Action<Ciudad, Exception> action)
        {
            var reg = MockData.Ciudad();
            action(reg, null);
        }

        public void GetAll(Action<List<Ciudad>, Exception> action)
        {
            var lista = new List<Ciudad>();
            var reg = MockData.Ciudad();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByPais(int paisId, Action<List<Ciudad>, Exception> action)
        {
            var lista = new List<Ciudad>();
            var reg = MockData.Ciudad();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}