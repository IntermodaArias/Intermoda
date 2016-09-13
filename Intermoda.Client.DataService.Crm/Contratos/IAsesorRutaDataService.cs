using System;
using System.Collections.Generic;
using Intermoda.Business.Crm.Entities;

namespace Intermoda.Client.DataService.Crm
{
    public interface IAsesorRutaDataService
    {
        void Update(AsesorRuta asesorRuta, Action<AsesorRuta, Exception> action);
        void Delete(int asesorRutaId, Action<Exception> action);
        void Get(int asesorRutaId, Action<AsesorRuta, Exception> action);
        void GetAll(Action<List<AsesorRuta>, Exception> action);
        void GetByAsesor(int asesorId, Action<List<AsesorRuta>, Exception> action);
        void GetByRuta(int rutaId, Action<List<AsesorRuta>, Exception> action);
    }
}