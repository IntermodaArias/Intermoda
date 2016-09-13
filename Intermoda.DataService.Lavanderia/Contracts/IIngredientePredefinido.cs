using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IIngredientePredefinido
    {
        [OperationContract]
        IngredientePredefinidoBusiness Update(IngredientePredefinidoBusiness ingredientePredefinido);

        [OperationContract]
        void Delete(int ingredientePredefinido);

        [OperationContract]
        IngredientePredefinidoBusiness Get(int ingredientePredefinidoId);

        [OperationContract]
        IngredientePredefinidoBusiness[] GetAll();

        [OperationContract]
        IngredientePredefinidoBusiness[] GetByInstruccionPredefinida(int instruccionPredefinidaId);
    }
}
