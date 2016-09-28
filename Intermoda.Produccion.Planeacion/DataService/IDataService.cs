using System;
using System.Collections.Generic;
using Intermoda.Business.LbDatPro;

namespace Intermoda.Produccion.Planeacion.DataService
{
    public interface IDataService
    {
        void TrabajoEnProcesoGet(Action<List<TrabajoEnProcesoBusiness>, Exception> action);
    }
}