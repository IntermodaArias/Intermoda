using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class AsesorRutaDesignDataService : IAsesorRutaDataService
    {
        public void Update(AsesorRuta asesorRuta, Action<AsesorRuta, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int asesorRutaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int asesorRutaId, Action<AsesorRuta, Exception> action)
        {
            var reg = MockData.AsesorRuta();
            action(reg, null);
        }

        public void GetAll(Action<List<AsesorRuta>, Exception> action)
        {
            var lista = new List<AsesorRuta>();
            var reg = MockData.AsesorRuta();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByAsesor(int asesorId, Action<List<AsesorRuta>, Exception> action)
        {
            var lista = new List<AsesorRuta>();
            var reg = MockData.AsesorRuta();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByRuta(int rutaId, Action<List<AsesorRuta>, Exception> action)
        {
            var lista = new List<AsesorRuta>();
            var reg = MockData.AsesorRuta();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}