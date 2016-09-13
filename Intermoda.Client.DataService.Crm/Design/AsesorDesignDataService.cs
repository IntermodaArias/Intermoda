using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class AsesorDesignDataService : IAsesorDataService
    {
        public void Update(Asesor asesor, Action<Asesor, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int asesorId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int asesorId, Action<Asesor, Exception> action)
        {
            var reg = MockData.Asesor();
            action(reg, null);
        }

        public void GetAll(Action<List<Asesor>, Exception> action)
        {
            var lista = new List<Asesor>();
            var reg = MockData.Asesor();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByZona(int zonaId, Action<List<Asesor>, Exception> action)
        {
            var lista = new List<Asesor>();
            var reg = MockData.Asesor();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}