using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IOperacionProceso
    {
        [OperationContract]
        OperacionProcesoBusiness Update(OperacionProcesoBusiness operacionProceso);

        [OperationContract]
        void Delete(int operacionProcesoId);

        [OperationContract]
        OperacionProcesoBusiness Get(int operacionProcesoId);

        [OperationContract]
        OperacionProcesoBusiness[] GetAll();

        [OperationContract]
        OperacionProcesoBusiness[] GetByOperacion(int operacionId);

        [OperationContract]
        OperacionProcesoBusiness[] GetByProceso(int procesoId);

        [OperationContract]
        OperacionProcesoBusiness[] GetByProcesoCentroTrabajo(int procesoCentroTrabajoId);
    }
}
