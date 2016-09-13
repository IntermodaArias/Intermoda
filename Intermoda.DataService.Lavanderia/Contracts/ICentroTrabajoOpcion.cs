using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ICentroTrabajoOpcion
    {
        [OperationContract]
        CentroTrabajoOpcionBusiness Update(CentroTrabajoOpcionBusiness centroTrabajoOpcion);

        [OperationContract]
        void InsertLegacy(int opcionId, int centroTrabajoId);

        [OperationContract]
        void BajarOrden(int centroTrabajoOpcionId, int orden);

        [OperationContract]
        void SubirOrden(int centroTrabajoOpcionId, int orden);

        [OperationContract]
        void Delete(int centroTrabajoOpcionId);

        [OperationContract]
        void DeleteRutaOpcionAcabado(int opcionId);

        [OperationContract]
        CentroTrabajoOpcionBusiness Get(int centroTrabajoOpcionId);

        [OperationContract]
        CentroTrabajoOpcionBusiness[] GetAll();

        [OperationContract]
        CentroTrabajoOpcionBusiness[] GetByOpcion(int opcionId);

        [OperationContract]
        CentroTrabajoOpcionBusiness[] GetByCentroTrabajo(int centroTrabajoId);
    }
}
