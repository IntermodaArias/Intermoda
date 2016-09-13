using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ISecadoraCapacidad
    {
        [OperationContract]
        SecadoraCapacidadBusiness Update(SecadoraCapacidadBusiness secadoraCapacidad);

        [OperationContract]
        void Delete(int secadoraCapacidadId);

        [OperationContract]
        SecadoraCapacidadBusiness Get(int secadoraCapacidadId);

        [OperationContract]
        SecadoraCapacidadBusiness[] GetAll();
    }
}
