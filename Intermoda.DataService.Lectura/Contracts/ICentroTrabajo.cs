using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface ICentroTrabajo
    {
        [OperationContract]
        CentroTrabajoBusiness Update(CentroTrabajoBusiness centroTrabajo);

        [OperationContract]
        void Delete(int centroTrabajoId);

        [OperationContract]
        CentroTrabajoBusiness Get(int centroTrabajoId);

        [OperationContract]
        CentroTrabajoBusiness[] GetAll();

        [OperationContract]
        CentroTrabajoBusiness[] GetActivos();
    }
}
