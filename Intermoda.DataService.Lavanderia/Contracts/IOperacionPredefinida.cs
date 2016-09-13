using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IOperacionPredefinida
    {
        [OperationContract]
        OperacionPredefinidaBusiness Update(OperacionPredefinidaBusiness operacionPredefinida);

        [OperationContract]
        void Delete(int operacionPredefinidaId);

        [OperationContract]
        OperacionPredefinidaBusiness Get(int operacionPredefinidaId);

        [OperationContract]
        OperacionPredefinidaBusiness GetSingle(int operacionPredefinidaId);

        [OperationContract]
        OperacionPredefinidaBusiness[] GetAll();
    }
}
