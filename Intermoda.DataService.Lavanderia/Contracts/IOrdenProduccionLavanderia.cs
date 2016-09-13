using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IOrdenProduccionLavanderia
    {
        [OperationContract]
        OrdenProduccionLavanderiaBusiness[] Get(short companiaId, int plantId, short centroTrabajoId);
    }
}
