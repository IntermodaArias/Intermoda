using System.ServiceModel;
using Intermoda.Business.Lavanderia;
using Intermoda.Common.Enum;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IMaquina
    {
        [OperationContract]
        MaquinaBusiness Update(MaquinaBusiness maquina);

        [OperationContract]
        void Delete(MaquinaTipo tipo, int maquinaId);

        [OperationContract]
        MaquinaBusiness Get(MaquinaTipo tipo, int maquinaId);

        [OperationContract]
        MaquinaBusiness[] GetAll();

        [OperationContract]
        MaquinaBusiness[] GetByTipo(MaquinaTipo tipo);

        [OperationContract]
        MaquinaBusiness[] GetByTipoCapacidad(MaquinaTipo tipo, int capacidadId);
    }
}
