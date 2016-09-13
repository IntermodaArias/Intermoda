using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IOperacionCentroTrabajo
    {
        [OperationContract]
        OperacionCentroTrabajoBusiness Update(OperacionCentroTrabajoBusiness operacionCentroTrabajo);

        [OperationContract]
        void Delete(int operacionCentroTrabajoId);

        [OperationContract]
        OperacionCentroTrabajoBusiness Get(int operacionCentroTrabajoId);

        [OperationContract]
        OperacionCentroTrabajoBusiness[] GetAll();

        [OperationContract]
        OperacionCentroTrabajoBusiness[] GetByCentroTrabajo(int centroTrabajoCodigo);

        [OperationContract]
        OperacionCentroTrabajoBusiness[] GetByOperacion(short operacionCodigo);
    }
}
