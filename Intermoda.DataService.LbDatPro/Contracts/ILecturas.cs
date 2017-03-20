using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface ILecturas
    {
        [OperationContract]
        LecturaCuponBusiness ValidaUsuario(string usuario);

        [OperationContract]
        LecturaCuponBusiness ProcesaCupon(string usuario, string cupon);
    }
}
