using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ILavadoraCapacidad
    {
        [OperationContract]
        LavadoraCapacidadBusiness Update(LavadoraCapacidadBusiness lavadoraCapacidad);

        [OperationContract]
        void Delete(int lavadoraCapacidadId);

        [OperationContract]
        LavadoraCapacidadBusiness Get(int lavadoraCapacidadId);

        [OperationContract]
        LavadoraCapacidadBusiness[] GetAll();
    }
}
