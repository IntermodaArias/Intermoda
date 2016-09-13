using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ICTrabajo
    {
        [OperationContract]
        CTrabajoBusiness Update(CTrabajoBusiness centroTrabajo);

        [OperationContract]
        void Delete(int centroTrabajoId);

        [OperationContract]
        CTrabajoBusiness Get(int centroTrabajoId);

        [OperationContract]
        CTrabajoBusiness[] GetAll();

        [OperationContract]
        CTrabajoBusiness[] GetActivos();

        [OperationContract]
        CTrabajoBusiness[] GetByOperacion(int operacionId);

        [OperationContract]
        CTrabajoBusiness[] GetAllLavanderia();
    }
}
