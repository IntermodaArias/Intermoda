using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface ICentroTrabajoClasificacion
    {
        [OperationContract]
        CentroTrabajoClasificacionBusiness Update(CentroTrabajoClasificacionBusiness centroTrabajoClasificacion);

        [OperationContract]
        void Delete(int centroTrabajoClasificacionId);

        [OperationContract]
        CentroTrabajoClasificacionBusiness Get(int centroTrabajoClasificacionId);

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] GetAll();

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] GetAllActivos();

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] GetByCentroTrabajo(int centroTrabajoId);

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] GetByCentroTrabajoActivos(int centroTrabajoId);
    }
}
