using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IZonaDataService
    {
        void Update(Zona zona, Action<Zona, Exception> action);

        void Delete(int zonaId, Action<Exception> action);

        void Get(int zonaId, Action<Zona, Exception> action);

        void GetAll(Action<List<Zona>, Exception> action);
    }
}