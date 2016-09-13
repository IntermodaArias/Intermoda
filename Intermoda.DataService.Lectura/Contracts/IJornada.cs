using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface IJornada
    {
        [OperationContract]
        JornadaBusiness Update(JornadaBusiness jornada);

        [OperationContract]
        void Delete(int jornadaId);

        [OperationContract]
        JornadaBusiness Get(int jornadaId);

        [OperationContract]
        JornadaBusiness[] GetAll();
    }
}
