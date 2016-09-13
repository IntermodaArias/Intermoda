using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class ObservacionPredefinida : IObservacionPredefinida
    {
        public ObservacionPredefinidaBusiness Update(ObservacionPredefinidaBusiness observacionPredefinida)
        {
            try
            {
                return observacionPredefinida.Id == 0
                    ? ObservacionPredefinidaBusiness.Insert(observacionPredefinida)
                    : ObservacionPredefinidaBusiness.Update(observacionPredefinida);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinida / Update", exception);
            }
        }

        public void Delete(int observacionPredefinidaId)
        {
            try
            {
                ObservacionPredefinidaBusiness.Delete(observacionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinida / Delete", exception);
            }
        }

        public ObservacionPredefinidaBusiness Get(int observacionPredefinidaId)
        {
            try
            {
                return ObservacionPredefinidaBusiness.Get(observacionPredefinidaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinida / Get", exception);
            }
        }

        public ObservacionPredefinidaBusiness[] GetAll()
        {
            try
            {
                return ObservacionPredefinidaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinida / GetAll", exception);
            }
        }

        public ObservacionPredefinidaBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                return ObservacionPredefinidaBusiness.GetByOperacion(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionPredefinida / GetByOperacion", exception);
            }
        }
    }
}
