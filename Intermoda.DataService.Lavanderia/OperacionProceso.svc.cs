using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class OperacionProceso : IOperacionProceso
    {
        public OperacionProcesoBusiness Update(OperacionProcesoBusiness operacionProceso)
        {
            try
            {
                return operacionProceso.Id == 0
                    ? OperacionProcesoBusiness.Insert(operacionProceso)
                    : OperacionProcesoBusiness.Update(operacionProceso);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / Update", exception);
            }
        }

        public void Delete(int operacionProcesoId)
        {
            try
            {
                OperacionProcesoBusiness.Delete(operacionProcesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / Delete", exception);
            }
        }

        public OperacionProcesoBusiness Get(int operacionProcesoId)
        {
            try
            {
                return OperacionProcesoBusiness.Get(operacionProcesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / Get", exception);
            }
        }

        public OperacionProcesoBusiness[] GetAll()
        {
            try
            {
                return OperacionProcesoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetAll", exception);
            }
        }

        public OperacionProcesoBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                return OperacionProcesoBusiness.GetByOperacion(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetByOperacion", exception);
            }
        }

        public OperacionProcesoBusiness[] GetByProceso(int procesoId)
        {
            try
            {
                return OperacionProcesoBusiness.GetByProceso(procesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetByProceso", exception);
            }
        }

        public OperacionProcesoBusiness[] GetByProcesoCentroTrabajo(int procesoCentroTrabajoId)
        {
            try
            {
                return OperacionProcesoBusiness.GetByProcesoCentroTrabajo(procesoCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetByProcesoCentroTrabajo", exception);
            }
        }
    }
}
