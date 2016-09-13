using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class CentroTrabajo : ICentroTrabajo
    {
        public CentroTrabajoBusiness Update(CentroTrabajoBusiness centroTrabajo)
        {
            try
            {
                return centroTrabajo.Id == 0
                    ? CentroTrabajoBusiness.Insert(centroTrabajo)
                    : CentroTrabajoBusiness.Update(centroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo.Update", exception);
            }
        }

        public void Delete(int centroTrabajoId)
        {
            try
            {
                CentroTrabajoBusiness.Delete(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo.Delete", exception);
            }
        }

        public CentroTrabajoBusiness Get(int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoBusiness.Get(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo.Get", exception);
            }
        }

        public CentroTrabajoBusiness[] GetAll()
        {
            try
            {
                return CentroTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo.GetAll", exception);
            }
        }

        public CentroTrabajoBusiness[] GetActivos()
        {
            try
            {
                return CentroTrabajoBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo.GetActivos", exception);
            }
        }
    }
}
