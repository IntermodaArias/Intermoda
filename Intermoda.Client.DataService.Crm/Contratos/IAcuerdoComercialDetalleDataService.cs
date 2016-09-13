using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IAcuerdoComercialDetalleDataService
    {
        void Update(AcuerdoComercialDetalle acuerdoComercialDetalle, Action<AcuerdoComercialDetalle, Exception> action);
        void Delete(int acuerdoComercialDetalleId, Action<Exception> action);
        void Get(int acuerdoComercialDetalleId, Action<AcuerdoComercialDetalle, Exception> action);
        void GetAll(Action<List<AcuerdoComercialDetalle>, Exception> action);
        void GetByAcuerdoComercial(int acuerdoComercialId, Action<List<AcuerdoComercialDetalle>, Exception> action);
    }
}