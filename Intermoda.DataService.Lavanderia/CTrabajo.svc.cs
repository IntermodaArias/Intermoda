using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class CTrabajo : ICTrabajo
    {
        public CTrabajoBusiness Update(CTrabajoBusiness centroTrabajo)
        {
            try
            {
                return centroTrabajo.Codigo == 0
                    ? CTrabajoBusiness.Insert(centroTrabajo)
                    : CTrabajoBusiness.Update(centroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Update", exception);
            }
        }

        public void Delete(int centroTrabajoId)
        {
            try
            {
                CTrabajoBusiness.Delete(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Delete", exception);
            }
        }

        public CTrabajoBusiness Get(int centroTrabajoId)
        {
            try
            {
                return CTrabajoBusiness.Get(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Get", exception);
            }
        }

        public CTrabajoBusiness[] GetAll()
        {
            try
            {
                return CTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetAll", exception);
            }
        }

        public CTrabajoBusiness[] GetActivos()
        {
            try
            {
                return CTrabajoBusiness.GetActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetActivos", exception);
            }
        }

        public CTrabajoBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                return CTrabajoBusiness.GetByOperacion(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetByOperacion", exception);
            }
        }

        public CTrabajoBusiness[] GetAllLavanderia()
        {
            try
            {
                return CTrabajoBusiness.GetAllLavanderia();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetAllLavanderia", exception);
            }
        }
    }
}
