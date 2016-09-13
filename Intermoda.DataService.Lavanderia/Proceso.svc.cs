using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Proceso : IProceso
    {
        public ProcesoBusiness Update(ProcesoBusiness proceso)
        {
            try
            {
                return proceso.Id == 0
                    ? ProcesoBusiness.Insert(proceso)
                    : ProcesoBusiness.Update(proceso);
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / Update", exception);
            }
        }

        public void Delete(int procesoId)
        {
            try
            {
                ProcesoBusiness.Delete(procesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / Delete", exception);
            }
        }

        public ProcesoBusiness Get(int procesoId)
        {
            try
            {
                return ProcesoBusiness.Get(procesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / Get", exception);
            }
        }

        public ProcesoBusiness[] GetAll()
        {
            try
            {
                return ProcesoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / GetAll", exception);
            }
        }

        public ProcesoBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return ProcesoBusiness.GetbyCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / GetByCentroTrabajo", exception);
            }
        }
    }
}
