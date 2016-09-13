using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IProcesoCentroTrabajo
    {
        [OperationContract]
        ProcesoCentroTrabajoBusiness Update(ProcesoCentroTrabajoBusiness procesoCentroTrabajo);

        [OperationContract]
        void Delete(int procesoCentroTrabajoId);

        [OperationContract]
        ProcesoCentroTrabajoBusiness Get(int procesoCentroTrabajoId);

        [OperationContract]
        ProcesoCentroTrabajoBusiness[] GetAll();

        [OperationContract]
        ProcesoCentroTrabajoBusiness[] GetbyProceso(int procesoId);

        [OperationContract]
        ProcesoCentroTrabajoBusiness[] GetByCentroTrabajo(int centroTrabajoId);

        [OperationContract]
        ProcesoCentroTrabajoBusiness[] GetByCentroTrabajoOpcion(int centroTrabajoOpcionId);
    }
}
