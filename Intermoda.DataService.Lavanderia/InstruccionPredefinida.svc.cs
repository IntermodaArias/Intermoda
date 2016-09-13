using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class InstruccionPredefinida : IInstruccionPredefinida
    {
        public InstruccionPredefinidaBusiness Update(InstruccionPredefinidaBusiness model)
        {
            try
            {
                return model.Id == 0
                    ? InstruccionPredefinidaBusiness.Insert(model)
                    : InstruccionPredefinidaBusiness.Update(model);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / Update", exception);
            }
        }

        public void Delete(int instruccionPredefinidaId)
        {
            try
            {
                InstruccionPredefinidaBusiness.Delete(instruccionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / Delete", exception);
            }
        }

        public InstruccionPredefinidaBusiness Get(int instruccionPredefinidaId)
        {
            try
            {
                return InstruccionPredefinidaBusiness.Get(instruccionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / Get", exception);
            }
        }

        public InstruccionPredefinidaBusiness[] GetAll()
        {
            try
            {
                return InstruccionPredefinidaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / GetAll", exception);
            }
        }

        public InstruccionPredefinidaBusiness[] GetByOperacionPredefinida(int operacionPredefinidaId)
        {
            try
            {
                return InstruccionPredefinidaBusiness.GetByOperacionPredefinida(operacionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / GetByOperacionPredefinida", exception);
            }
        }
    }
}
