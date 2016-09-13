using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IEmpleado
    {
        [OperationContract]
        EmpleadoBusiness Get(short companiaCodigo, int empleadoId);

        [OperationContract]
        EmpleadoBusiness[] GetAllActivos();
    }
}
