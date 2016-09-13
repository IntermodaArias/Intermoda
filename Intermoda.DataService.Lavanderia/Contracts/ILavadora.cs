using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ILavadora
    {
        [OperationContract]
        LavadoraBusiness Update(LavadoraBusiness lavadora);

        [OperationContract]
        void Delete(int lavadoraId);

        [OperationContract]
        LavadoraBusiness Get(int lavadoraId);

        [OperationContract]
        LavadoraBusiness[] GetAll();

        [OperationContract]
        LavadoraBusiness[] GetByCapacidad(int lavadoraCapacidadId);
    }
}
