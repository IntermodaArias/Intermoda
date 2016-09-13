using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Operacion : IOperacion
    {
        public OperacionBusiness Update(OperacionBusiness operacion)
        {
            try
            {
                return operacion.Id == 0
                    ? OperacionBusiness.Insert(operacion)
                    : OperacionBusiness.Update(operacion);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / Update", exception);
            }
        }

        public void Delete(int operacionId)
        {
            try
            {
                OperacionBusiness.Delete(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / Delete", exception);
            }
        }

        public OperacionBusiness Get(int operacionId)
        {
            try
            {
                return OperacionBusiness.Get(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / Get", exception);
            }
        }

        public OperacionBusiness[] GetAll()
        {
            try
            {
                return OperacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetAll", exception);
            }
        }

        public OperacionBusiness[] GetAllLavanderia()
        {
            try
            {
                return OperacionBusiness.GetAllLavanderia();
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetAllLavanderia", exception);
            }
        }

        public OperacionBusiness[] GetHumedas(int centroTrabajoId)
        {
            try
            {
                return OperacionBusiness.GetOperacionesHumedas(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetHumedas", exception);
            }
        }
    }
}
