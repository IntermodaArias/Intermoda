using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IPlanta
    {
        [OperationContract]
        PlantaBusiness Update(PlantaBusiness planta);

        [OperationContract]
        void Delete(int plantaId);

        [OperationContract]
        PlantaBusiness Get(int plantaId);

        [OperationContract]
        PlantaBusiness[] GetAll();

        [OperationContract]
        PlantaBusiness[] GetByCompania(int companiaId = 1);
    }
}
