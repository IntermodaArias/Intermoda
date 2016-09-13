using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.Crm.Entities;
using Intermoda.Business.Crm.Repository;

namespace Intermoda.Client.DataService.Crm
{
    public class EmpresaDataService : IEmpresaDataService
    {
        public void Update(Empresa empresa, Action<Empresa, Exception> action)
        {
            try
            {
                var reg = empresa.Id == 0
                    ? EmpresaRepository.Insert(empresa)
                    : EmpresaRepository.Update(empresa);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void Delete(int empresaId, Action<Exception> action)
        {
            try
            {
                EmpresaRepository.Delete(empresaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public void Get(int empresaId, Action<Empresa, Exception> action)
        {
            try
            {
                var reg = EmpresaRepository.Get(empresaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GetAll(Action<List<Empresa>, Exception> action)
        {
            try
            {
                var lista = EmpresaRepository.GetAll().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}