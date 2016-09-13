using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IPaisDataService
    {
        void Update(Pais pais, Action<Pais, Exception> action);

        void Delete(int paisId, Action<Exception> action);

        void Get(int paisId, Action<Pais, Exception> action);

        void GetAll(Action<List<Pais>, Exception> action);
    }
}