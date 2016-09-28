using System;
using System.Collections.Generic;
using System.Linq;
using Intermoda.Business.LbDatPro;

namespace Intermoda.Produccion.Planeacion.DataService
{
    public class DataService : IDataService
    {
        public void TrabajoEnProcesoGet(Action<List<TrabajoEnProcesoBusiness>, Exception> action)
        {
            try
            {
                var lista = TrabajoEnProcesoBusiness.GetTeP().ToList();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }
    }
}