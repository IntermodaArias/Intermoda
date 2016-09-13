using System.ServiceModel;
using Intermoda.Business.Lavanderia;
using Intermoda.Common.Enum;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IMaquinaCapacidad
    {
        [OperationContract]
        MaquinaCapacidadBusiness Update(MaquinaCapacidadBusiness maquinaCapacidad);

        [OperationContract]
        void Delete(MaquinaTipo tipo, int maquinaCapacidadId);

        [OperationContract]
        MaquinaCapacidadBusiness Get(MaquinaTipo tipo, int maquinaCapacidadId);

        [OperationContract]
        MaquinaCapacidadBusiness[] GetAll();

        [OperationContract]
        MaquinaCapacidadBusiness[] GetByTipo(MaquinaTipo tipo);
    }
}
