using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IEdadDataService
    {
        void Update(Edad edad, Action<Edad, Exception> action);

        void Delete(int edadId, Action<Exception> action);

        void Get(int edadId, Action<Edad, Exception> action);

        void GetAll(Action<List<Edad>, Exception> action);
    }
}