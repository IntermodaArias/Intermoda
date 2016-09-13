using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IOpcionLavado
    {
        [OperationContract]
        OpcionLavadoBusiness Update(OpcionLavadoBusiness model);

        [OperationContract]
        void Delete(int opcionLavadoId);

        [OperationContract]
        OpcionLavadoBusiness Get(int opcionLavadoId);

        [OperationContract]
        OpcionLavadoBusiness[] GetAll();

        [OperationContract]
        OpcionLavadoBusiness[] GetByLavado(int lavadoId);

        [OperationContract]
        OpcionLavadoBusiness[] GetByTela(string telaId);
    }
}
