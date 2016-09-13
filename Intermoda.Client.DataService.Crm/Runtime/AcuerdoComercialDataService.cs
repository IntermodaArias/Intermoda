using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class AcuerdoComercialDataService : IAcuerdoComercialDataService
    {
        public void Update(AcuerdoComercial acuerdoComercial, Action<AcuerdoComercial, Exception> action)
        {
            try
            {
                var reg = acuerdoComercial.Id == 0
                    ? AcuerdoComercialRepository.Insert(acuerdoComercial)
                    : AcuerdoComercialRepository.Update(acuerdoComercial);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int acuerdoComercialId, Action<Exception> action)
        {
            try
            {
                AcuerdoComercialRepository.Delete(acuerdoComercialId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int acuerdoComercialId, Action<AcuerdoComercial, Exception> action)
        {
            try
            {
                var reg = AcuerdoComercialRepository.Get(acuerdoComercialId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<AcuerdoComercial>, Exception> action)
        {
            try
            {
                var lista = AcuerdoComercialRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetByCliente(int clienteId, Action<List<AcuerdoComercial>, Exception> action)
        {
            try
            {
                var lista = AcuerdoComercialRepository.GetByCliente(clienteId).ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}