using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ISubClase
    {
        [OperationContract]
        SubClaseBusiness Update(SubClaseBusiness subClase);

        [OperationContract]
        void Delete(string subClaseCodigo);

        [OperationContract]
        SubClaseBusiness Get(string subClaseCodigo);

        [OperationContract]
        SubClaseBusiness[] GetAll();
    }
}
