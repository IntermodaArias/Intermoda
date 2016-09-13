using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface ILinea
    {
        [OperationContract]
        LineaBusiness Update(LineaBusiness linea);

        [OperationContract]
        void Delete(int lineaId);

        [OperationContract]
        LineaBusiness Get(int lineaId);

        [OperationContract]
        LineaBusiness[] GetAll();

        [OperationContract]
        LineaBusiness[] GetAllActivas();

        [OperationContract]
        LineaBusiness[] GetByGrupo(int grupoId);

        [OperationContract]
        LineaBusiness[] GetByGrupoActivas(int grupoId);
    }
}
