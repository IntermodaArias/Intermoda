using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IInstruccionOperacion
    {
        [OperationContract]
        InstruccionOperacionBusiness Update(InstruccionOperacionBusiness instruccionOperacion);

        [OperationContract]
        void Delete(int instruccionOperacionId);

        [OperationContract]
        InstruccionOperacionBusiness Get(int instruccionOperacionId);

        [OperationContract]
        InstruccionOperacionBusiness[] GetAll();

        [OperationContract]
        InstruccionOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId);
    }
}
