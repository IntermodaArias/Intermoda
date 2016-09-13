using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IObservacionOperacion
    {
        [OperationContract]
        ObservacionOperacionBusiness Update(ObservacionOperacionBusiness observacionOperacionBusiness);

        [OperationContract]
        void Delete(int observacionOperacionId);

        [OperationContract]
        ObservacionOperacionBusiness Get(int observacionOperacionId);

        [OperationContract]
        ObservacionOperacionBusiness[] GetAll();

        [OperationContract]
        ObservacionOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId);
    }
}
