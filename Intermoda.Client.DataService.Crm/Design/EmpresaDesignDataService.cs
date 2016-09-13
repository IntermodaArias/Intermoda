using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public class EmpresaDesignDataService : IEmpresaDataService
    {
        public void Update(Empresa empresa, Action<Empresa, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Delete(int empresaId, Action<Exception> action)
        {
            throw new NotImplementedException();
        }

        public void Get(int empresaId, Action<Empresa, Exception> action)
        {
            var reg = MockData.Empresa();
            action(reg, null);
        }

        public void GetAll(Action<List<Empresa>, Exception> action)
        {
            var lista = new List<Empresa>();
            var reg = MockData.Empresa();
            for (var i = 1; i < 21; i++)
            {
                lista.Add(reg);
            }
            action(lista, null);
        }
    }
}