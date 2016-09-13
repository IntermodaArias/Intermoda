using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IRutaDataService
    {
        void Update(Ruta ruta, Action<Ruta, Exception> action);

        void Delete(int rutaId, Action<Exception> action);

        void Get(int rutaId, Action<Ruta, Exception> action);

        void GetAll(Action<List<Ruta>, Exception> action);

        void GetByZona(int zonaId, Action<List<Ruta>, Exception> action);
    }
}