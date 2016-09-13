using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class OperacionPredefinida : IOperacionPredefinida
    {
        public OperacionPredefinidaBusiness Update(OperacionPredefinidaBusiness operacionPredefinida)
        {
            try
            {
                return operacionPredefinida.Id == 0
                    ? OperacionPredefinidaBusiness.Insert(operacionPredefinida)
                    : OperacionPredefinidaBusiness.Update(operacionPredefinida);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion Predefinida / Update", exception);
            }
        }

        public void Delete(int operacionPredefinidaId)
        {
            try
            {
                OperacionPredefinidaBusiness.Delete(operacionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion Predefinida / Delete", exception);
            }
        }

        public OperacionPredefinidaBusiness Get(int operacionPredefinidaId)
        {
            try
            {
                return OperacionPredefinidaBusiness.Get(operacionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion Predefinida / Get", exception);
            }
        }

        public OperacionPredefinidaBusiness GetSingle(int operacionPredefinidaId)
        {
            try
            {
                return OperacionPredefinidaBusiness.GetSingle(operacionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion Predefinida / GetSingle", exception);
            }
        }

        public OperacionPredefinidaBusiness[] GetAll()
        {
            try
            {
                return OperacionPredefinidaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion Predefinida / GetAll", exception);
            }
        }
    }
}
