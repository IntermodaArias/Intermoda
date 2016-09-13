using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface ILineaDetalle
    {
        [OperationContract]
        LineaDetalleBusiness Update(LineaDetalleBusiness lineaDetalle);

        [OperationContract]
        void Delete(int lineaDetalle);

        [OperationContract]
        LineaDetalleBusiness[] GetAll();

        [OperationContract]
        LineaDetalleBusiness[] GetByLinea(int lineaId);

        [OperationContract]
        LineaDetalleBusiness[] GetByLineaModulo(int lineaId, int moduloId);
    }
}
