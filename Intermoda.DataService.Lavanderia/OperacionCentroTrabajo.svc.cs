using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class OperacionCentroTrabajo : IOperacionCentroTrabajo
    {
        public OperacionCentroTrabajoBusiness Update(OperacionCentroTrabajoBusiness operacionCentroTrabajo)
        {
            try
            {
                return operacionCentroTrabajo.Id == 0
                    ? OperacionCentroTrabajoBusiness.Insert(operacionCentroTrabajo)
                    : OperacionCentroTrabajoBusiness.Update(operacionCentroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        public void Delete(int operacionCentroTrabajoId)
        {
            try
            {
                OperacionCentroTrabajoBusiness.Delete(operacionCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Delete", exception);
            }
        }

        public OperacionCentroTrabajoBusiness Get(int operacionCentroTrabajoId)
        {
            try
            {
                return OperacionCentroTrabajoBusiness.Get(operacionCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Get", exception);
            }
        }

        public OperacionCentroTrabajoBusiness[] GetAll()
        {
            try
            {
                return OperacionCentroTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / GetAll", exception);
            }
        }

        public OperacionCentroTrabajoBusiness[] GetByCentroTrabajo(int centroTrabajoCodigo)
        {
            try
            {
                return OperacionCentroTrabajoBusiness.GetByCentroTrabajo(centroTrabajoCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / GetByCentroTrabajo", exception);
            }
        }

        public OperacionCentroTrabajoBusiness[] GetByOperacion(short operacionCodigo)
        {
            try
            {
                return OperacionCentroTrabajoBusiness.GetByOperacion(operacionCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / GetByOperacion", exception);
            }
        }
    }
}
