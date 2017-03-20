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
        OrdenProduccionExternoBusiness[] Get();

        [OperationContract]
        MaquiladoTrabajoEnProceso[] GetMaquiladoTrabajoEnProceso();

        [OperationContract]
        void SetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId);

        [OperationContract]
        OrdenProduccionExternoBusiness GrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId, string tipo,
            string usuario);

        [OperationContract]
        void SetEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero);
    }
}
