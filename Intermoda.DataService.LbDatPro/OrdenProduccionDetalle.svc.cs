using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class OrdenProduccionDetalle : IOrdenProduccionDetalle
    {
        public OrdenProduccionBultoBusiness[] GetBultos(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                return OrdenProduccionBultoBusiness.GetBultosByOrdenProduccion(companiaId, ordenAno, ordenNumero);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService OrdenProduccionDetalle / GetBultos", exception);
            }
        }

        public OrdenProduccionTallaBusiness[] GetTallas(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                return OrdenProduccionBultoBusiness.GetTallasByOrdenProduccion(companiaId, ordenAno, ordenNumero);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService OrdenProduccionDetalle / GetTallas", exception);
            }
        }
    }
}
