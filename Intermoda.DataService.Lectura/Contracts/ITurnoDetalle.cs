using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface ITurnoDetalle
    {
        [OperationContract]
        TurnoDetalleBusiness Update(TurnoDetalleBusiness turnoDetalle);

        [OperationContract]
        void Delete(int turnoDetalleId);

        [OperationContract]
        TurnoDetalleBusiness Get(int turnoDetalleId);

        [OperationContract]
        TurnoDetalleBusiness[] GetAll();

        [OperationContract]
        TurnoDetalleBusiness[] GetByTurno(int turnoId);
    }
}
