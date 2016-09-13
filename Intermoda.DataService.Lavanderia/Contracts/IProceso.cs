using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IProceso
    {
        [OperationContract]
        ProcesoBusiness Update(ProcesoBusiness proceso);

        [OperationContract]
        void Delete(int procesoId);

        [OperationContract]
        ProcesoBusiness Get(int procesoId);

        [OperationContract]
        ProcesoBusiness[] GetAll();

        [OperationContract]
        ProcesoBusiness[] GetByCentroTrabajo(int centroTrabajoId);
    }
}
