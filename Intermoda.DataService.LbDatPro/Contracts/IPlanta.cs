using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IPlanta
    {
        [OperationContract]
        PlantaBusiness GetByUsuario(string usuario, string clave);

        [OperationContract]
        void UpdateClave(string plantaId, string claveOld, string claveNew);
    }
}
