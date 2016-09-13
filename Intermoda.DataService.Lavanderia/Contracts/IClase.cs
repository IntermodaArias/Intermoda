using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IClase
    {
        [OperationContract]
        ClaseBusiness Update(ClaseBusiness clase);

        [OperationContract]
        void Delete(string claseCodigo);

        [OperationContract]
        ClaseBusiness Get(string claseCodigo);

        [OperationContract]
        ClaseBusiness[] GetAll();
    }
}
