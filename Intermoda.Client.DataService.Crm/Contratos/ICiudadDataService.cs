using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface ICiudadDataService
    {
        void Update(Ciudad ciudad, Action<Ciudad, Exception> action);

        void Delete(int ciudadId, Action<Exception> action);

        void Get(int ciudadId, Action<Ciudad, Exception> action);

        void GetAll(Action<List<Ciudad>, Exception> action);

        void GetByPais(int paisId, Action<List<Ciudad>, Exception> action);
    }
}