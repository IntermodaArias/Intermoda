using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IEmpresaDataService
    {
        void Update(Empresa empresa, Action<Empresa, Exception> action);

        void Delete(int empresaId, Action<Exception> action);

        void Get(int empresaId, Action<Empresa, Exception> action);

        void GetAll(Action<List<Empresa>, Exception> action);
    }
}