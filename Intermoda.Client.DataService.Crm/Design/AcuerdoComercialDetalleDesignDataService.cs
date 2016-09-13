using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class AcuerdoComercialDetalleDesignDataService : IAcuerdoComercialDetalleDataService
    {
        public void Update(AcuerdoComercialDetalle acuerdoComercialDetalle, Action<AcuerdoComercialDetalle, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int acuerdoComercialDetalleId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int acuerdoComercialDetalleId, Action<AcuerdoComercialDetalle, Exception> action)
        {
            var reg = MockData.AcuerdoComercialDetalle();
            action(reg, null);
        }

        public void GetAll(Action<List<AcuerdoComercialDetalle>, Exception> action)
        {
            var lista = new List<AcuerdoComercialDetalle>();
            var reg = MockData.AcuerdoComercialDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }

        public void GetByAcuerdoComercial(int acuerdoComercialId, Action<List<AcuerdoComercialDetalle>, Exception> action)
        {
            var lista = new List<AcuerdoComercialDetalle>();
            var reg = MockData.AcuerdoComercialDetalle();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}