using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface IJornadaDetalle
    {
        [OperationContract]
        JornadaDetalleBusiness Update(JornadaDetalleBusiness jornadaDetalle);

        [OperationContract]
        void Delete(int jornadaDetalleId);

        [OperationContract]
        JornadaDetalleBusiness Get(int jornadaDetalleId);

        [OperationContract]
        JornadaDetalleBusiness[] GetAll();

        [OperationContract]
        JornadaDetalleBusiness[] GetByJornada(int jornadaId);
    }
}
