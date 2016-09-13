using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class ObservacionOperacion : IObservacionOperacion
    {
        public ObservacionOperacionBusiness Update(ObservacionOperacionBusiness observacionOperacion)
        {
            try
            {
                return observacionOperacion.Id == 0
                    ? ObservacionOperacionBusiness.Insert(observacionOperacion)
                    : ObservacionOperacionBusiness.Update(observacionOperacion);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / Update", exception);
            }
        }

        public void Delete(int observacionOperacionId)
        {
            try
            {
                ObservacionOperacionBusiness.Delete(observacionOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / Delete", exception);
            }
        }

        public ObservacionOperacionBusiness Get(int observacionOperacionId)
        {
            try
            {
                return ObservacionOperacionBusiness.Get(observacionOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / Get", exception);
            }
        }

        public ObservacionOperacionBusiness[] GetAll()
        {
            try
            {
                return ObservacionOperacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / GetAll", exception);
            }
        }

        public ObservacionOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                return ObservacionOperacionBusiness.GetByOperacionProceso(operacionProcesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / GetByOperacionProceso", exception);
            }
        }
    }
}
