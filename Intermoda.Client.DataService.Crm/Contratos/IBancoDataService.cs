using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IBancoDataService
    {
        void Update(Banco banco, Action<Banco, Exception> action);
        void Delete(int bancoId, Action<Exception> action);
        void Get(int bancoId, Action<Banco, Exception> action);
        void GetAll(Action<List<Banco>, Exception> action);
    }
}