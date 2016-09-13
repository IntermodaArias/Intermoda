using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class AcuerdoComercialDesignDataService : IAcuerdoComercialDataService
    {
        public void Update(AcuerdoComercial acuerdoComercial, Action<AcuerdoComercial, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int acuerdoComercialId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int acuerdoComercialId, Action<AcuerdoComercial, Exception> action)
        {
            var reg = MockData.AcuerdoComercial();
            action(reg, null);
        }

        public void GetAll(Action<List<AcuerdoComercial>, Exception> action)
        {
            var reg = MockData.AcuerdoComercial();
            var lista = new List<AcuerdoComercial>();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByCliente(int clienteId, Action<List<AcuerdoComercial>, Exception> action)
        {
            var lista = new List<AcuerdoComercial>();
            var reg = MockData.AcuerdoComercial();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
        }
    }
}