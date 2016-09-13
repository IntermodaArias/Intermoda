using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IPaqueteDataService
    {
        void Update(Paquete paquete, Action<Paquete, Exception> action);

        void Delete(int paqueteId, Action<Exception> action);

        void Get(int paqueteId, Action<Paquete, Exception> action);

        void GetAll(Action<List<Paquete>, Exception> action);
    }
}