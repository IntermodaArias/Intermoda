using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class AcuerdoComercialDetalleDataService : IAcuerdoComercialDetalleDataService
    {
        public void Update(AcuerdoComercialDetalle acuerdoComercialDetalle,
            Action<AcuerdoComercialDetalle, Exception> action)
        {
            try
            {
                var reg = acuerdoComercialDetalle.Id == 0
                    ? AcuerdoComercialDetalleReporitory.Insert(acuerdoComercialDetalle)
                    : AcuerdoComercialDetalleReporitory.Update(acuerdoComercialDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int acuerdoComercialDetalleId, Action<Exception> action)
        {
            try
            {
                AcuerdoComercialDetalleReporitory.Delete(acuerdoComercialDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int acuerdoComercialDetalleId, Action<AcuerdoComercialDetalle, Exception> action)
        {
            try
            {
                var reg = AcuerdoComercialDetalleReporitory.Get(acuerdoComercialDetalleId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<AcuerdoComercialDetalle>, Exception> action)
        {
            try
            {
                var lista = AcuerdoComercialDetalleReporitory.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByAcuerdoComercial(int acuerdoComercialId,
            Action<List<AcuerdoComercialDetalle>, Exception> action)
        {
            try
            {
                var lista = AcuerdoComercialDetalleReporitory.GetByAcuerdoComercial(acuerdoComercialId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}