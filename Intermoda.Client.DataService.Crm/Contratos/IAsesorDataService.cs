using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IAsesorDataService
    {
        void Update(Asesor asesor, Action<Asesor, Exception> action);
        void Delete(int asesorId, Action<Exception> action);
        void Get(int asesorId, Action<Asesor, Exception> action);
        void GetAll(Action<List<Asesor>, Exception> action);
        void GetByZona(int zonaId, Action<List<Asesor>, Exception> action);
    }
}