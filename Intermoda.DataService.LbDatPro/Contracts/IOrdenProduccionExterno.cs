using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IOrdenProduccionExterno
    {
        [OperationContract]
        OrdenProduccionExternoBusiness[] GetByUsuarioPlanta(string usuario);

        [OperationContract]
        void SetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId);

        [OperationContract]
        void GrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId, string tipo,
            string usuario);

        [OperationContract]
        void SetEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero);
    }
}
