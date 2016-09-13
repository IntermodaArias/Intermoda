using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ISecadora
    {
        [OperationContract]
        SecadoraBusiness Update(SecadoraBusiness secadora);

        [OperationContract]
        void Delete(int secadoraId);

        [OperationContract]
        SecadoraBusiness Get(int secadoraId);

        [OperationContract]
        SecadoraBusiness[] GetAll();

        [OperationContract]
        SecadoraBusiness[] GetByCapacidad(int secadoraCapacidadId);
    }
}
