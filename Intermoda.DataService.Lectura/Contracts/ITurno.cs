using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface ITurno
    {
        [OperationContract]
        TurnoBusiness Update(TurnoBusiness turno);

        [OperationContract]
        void Delete(int turnoId);

        [OperationContract]
        TurnoBusiness Get(int turnoId);

        [OperationContract]
        TurnoBusiness[] GetAll();
    }
}
