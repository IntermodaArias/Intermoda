using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ILavado
    {
        [OperationContract]
        LavadoBusiness Update(LavadoBusiness lavado);

        [OperationContract]
        void Delete(int lavadoId);

        [OperationContract]
        LavadoBusiness Get(int lavadoId);

        [OperationContract]
        LavadoBusiness[] GetAll();

        [OperationContract]
        LavadoBusiness GetByNombre(string lavadoNombre);
    }
}
