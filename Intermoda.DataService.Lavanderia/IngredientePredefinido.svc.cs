using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class IngredientePredefinido : IIngredientePredefinido
    {
        public IngredientePredefinidoBusiness Update(IngredientePredefinidoBusiness ingredientePredefinido)
        {
            try
            {
                return ingredientePredefinido.Id == 0
                    ? IngredientePredefinidoBusiness.Insert(ingredientePredefinido)
                    : IngredientePredefinidoBusiness.Update(ingredientePredefinido);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / Update", exception);
            }
        }

        public void Delete(int ingredientePredefinido)
        {
            try
            {
                IngredientePredefinidoBusiness.Delete(ingredientePredefinido);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / Delete", exception);
            }
        }

        public IngredientePredefinidoBusiness Get(int ingredientePredefinidoId)
        {
            try
            {
                return IngredientePredefinidoBusiness.Get(ingredientePredefinidoId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / Get", exception);
            }
        }

        public IngredientePredefinidoBusiness[] GetAll()
        {
            try
            {
                return IngredientePredefinidoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / GetAll", exception);
            }
        }

        public IngredientePredefinidoBusiness[] GetByInstruccionPredefinida(int instruccionPredefinidaId)
        {
            try
            {
                return IngredientePredefinidoBusiness.GetByInstruccionPredefinida(instruccionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / GetByInstruccionPredefinida", exception);
            }
        }
    }
}
