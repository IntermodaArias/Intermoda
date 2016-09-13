using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface IModulo
    {
        [OperationContract]
        ModuloBusiness Update(ModuloBusiness modulo);

        [OperationContract]
        void Delete(int moduloId);

        [OperationContract]
        ModuloBusiness Get(int moduloId);

        [OperationContract]
        ModuloBusiness[] GetAll();

        [OperationContract]
        ModuloBusiness[] GetAllActivos();

        [OperationContract]
        ModuloBusiness[] GetByCentroTrabajo(int centroTrabajoId);

        [OperationContract]
        ModuloBusiness[] GetByCentroTrabajoActivos(int centroTrabajoId);
    }
}
