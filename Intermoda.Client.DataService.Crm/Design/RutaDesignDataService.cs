using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class RutaDesignDataService : IRutaDataService
    {
        public void Update(Ruta ruta, Action<Ruta, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int rutaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int rutaId, Action<Ruta, Exception> action)
        {
            var reg = MockData.Ruta();
            action(reg, null);
        }

        public void GetAll(Action<List<Ruta>, Exception> action)
        {
            var lista = new List<Ruta>();
            var reg = MockData.Ruta();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByZona(int zonaId, Action<List<Ruta>, Exception> action)
        {
            var lista = new List<Ruta>();
            var reg = MockData.Ruta();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}