using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IInstruccionPredefinida
    {
        [OperationContract]
        InstruccionPredefinidaBusiness Update(InstruccionPredefinidaBusiness model);

        [OperationContract]
        void Delete(int instruccionPredefinidaId);

        [OperationContract]
        InstruccionPredefinidaBusiness Get(int instruccionPredefinidaId);

        [OperationContract]
        InstruccionPredefinidaBusiness[] GetAll();

        [OperationContract]
        InstruccionPredefinidaBusiness[] GetByOperacionPredefinida(int operacionPredefinidaId);
    }
}
