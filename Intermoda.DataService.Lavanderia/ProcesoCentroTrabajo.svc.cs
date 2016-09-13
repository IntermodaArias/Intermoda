using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class ProcesoCentroTrabajo : IProcesoCentroTrabajo
    {
        public ProcesoCentroTrabajoBusiness Update(ProcesoCentroTrabajoBusiness procesoCentroTrabajo)
        {
            try
            {
                return procesoCentroTrabajo.Id == 0
                    ? ProcesoCentroTrabajoBusiness.Insert(procesoCentroTrabajo)
                    : ProcesoCentroTrabajoBusiness.Update(procesoCentroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / Update", exception);
            }
        }

        public void Delete(int procesoCentroTrabajoId)
        {
            try
            {
                ProcesoCentroTrabajoBusiness.Delete(procesoCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / Delete", exception);
            }
        }

        public ProcesoCentroTrabajoBusiness Get(int procesoCentroTrabajoId)
        {
            try
            {
                return ProcesoCentroTrabajoBusiness.Get(procesoCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / Get", exception);
            }
        }

        public ProcesoCentroTrabajoBusiness[] GetAll()
        {
            try
            {
                return ProcesoCentroTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetAll", exception);
            }
        }

        public ProcesoCentroTrabajoBusiness[] GetbyProceso(int procesoId)
        {
            try
            {
                return ProcesoCentroTrabajoBusiness.GetByProceso(procesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetbyProceso", exception);
            }
        }

        public ProcesoCentroTrabajoBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return ProcesoCentroTrabajoBusiness.GetByCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetByCentroTrabajo", exception);
            }
        }

        public ProcesoCentroTrabajoBusiness[] GetByCentroTrabajoOpcion(int centroTrabajoOpcionId)
        {
            try
            {
                return ProcesoCentroTrabajoBusiness.GetByCentroTrabajoOpcion(centroTrabajoOpcionId);
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetByCentroTrabajoOpcion", exception);
            }
        }
    }
}
