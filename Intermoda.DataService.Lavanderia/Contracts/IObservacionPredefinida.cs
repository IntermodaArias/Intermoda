using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IObservacionPredefinida
    {
        [OperationContract]
        ObservacionPredefinidaBusiness Update(ObservacionPredefinidaBusiness observacionPredefinida);

        [OperationContract]
        void Delete(int observacionPredefinidaId);

        [OperationContract]
        ObservacionPredefinidaBusiness Get(int observacionPredefinidaId);

        [OperationContract]
        ObservacionPredefinidaBusiness[] GetAll();

        [OperationContract]
        ObservacionPredefinidaBusiness[] GetByOperacion(int operacionId);
    }
}
