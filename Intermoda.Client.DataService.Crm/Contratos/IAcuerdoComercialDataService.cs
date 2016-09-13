using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IAcuerdoComercialDataService
    {
        void Update(AcuerdoComercial acuerdoComercial, Action<AcuerdoComercial, Exception> action);
        void Delete(int acuerdoComercialId, Action<Exception> action);
        void Get(int acuerdoComercialId, Action<AcuerdoComercial, Exception> action);
        void GetAll(Action<List<AcuerdoComercial>, Exception> action);
        void GetByCliente(int clienteId, Action<List<AcuerdoComercial>, Exception> action);
    }
}