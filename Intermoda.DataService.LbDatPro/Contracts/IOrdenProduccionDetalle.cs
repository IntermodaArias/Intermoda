using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IOrdenProduccionDetalle
    {
        [OperationContract]
        OrdenProduccionBultoBusiness[] GetBultos(short companiaId, short ordenAno, short ordenNumero);

        [OperationContract]
        OrdenProduccionTallaBusiness[] GetTallas(short companiaId, short ordenAno, short ordenNumero);
    }
}
