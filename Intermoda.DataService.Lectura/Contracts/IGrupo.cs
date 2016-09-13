using System;
using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface IGrupo
    {
        [OperationContract]
        GrupoBusiness Update(GrupoBusiness grupoBusiness);

        [OperationContract]
        void Delete(int grupoId);

        [OperationContract]
        GrupoBusiness Get(int grupoId);

        [OperationContract]
        GrupoBusiness[] GetAll();

        [OperationContract]
        GrupoBusiness[] GetAllActivos();

        [OperationContract]
        GrupoBusiness GetByLinea(int lineaId);

        [OperationContract]
        void CopiarSemana(DateTime desde, DateTime hasta);

        [OperationContract]
        bool HayDataSemana(DateTime fecha);
    }
}
