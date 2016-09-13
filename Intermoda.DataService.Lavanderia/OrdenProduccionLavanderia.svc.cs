using System;
using System.Linq;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class OrdenProduccionLavanderia : IOrdenProduccionLavanderia
    {
        public OrdenProduccionLavanderiaBusiness[] Get(short companiaId, int plantId, short centroTrabajoId)
        {
            try
            {
                return OrdenProduccionLavanderiaBusiness.Get(companiaId, plantId, centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionLavanderia / Get", exception);
            }
        }
    }
}
