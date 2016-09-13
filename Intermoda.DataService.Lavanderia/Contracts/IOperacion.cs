using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IOperacion
    {
        [OperationContract]
        OperacionBusiness Update(OperacionBusiness operacion);

        [OperationContract]
        void Delete(int operacionId);

        [OperationContract]
        OperacionBusiness Get(int operacionId);

        [OperationContract]
        OperacionBusiness[] GetAll();

        [OperationContract]
        OperacionBusiness[] GetAllLavanderia();

        [OperationContract]
        OperacionBusiness[] GetHumedas(int centroTrabajoId);
    }
}
