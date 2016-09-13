using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class InstruccionOperacion : IInstruccionOperacion
    {
        public InstruccionOperacionBusiness Update(InstruccionOperacionBusiness instruccionOperacion)
        {
            try
            {
                return instruccionOperacion.Id == 0
                    ? InstruccionOperacionBusiness.Insert(instruccionOperacion)
                    : InstruccionOperacionBusiness.Update(instruccionOperacion);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacion / Update", exception);
            }
        }

        public void Delete(int instruccionOperacionId)
        {
            try
            {
                InstruccionOperacionBusiness.Delete(instruccionOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacion / Delete", exception);
            }
        }

        public InstruccionOperacionBusiness Get(int instruccionOperacionId)
        {
            try
            {
                return InstruccionOperacionBusiness.Get(instruccionOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacion / Get", exception);
            }
        }

        public InstruccionOperacionBusiness[] GetAll()
        {
            try
            {
                return InstruccionOperacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacion / GetAll", exception);
            }
        }

        public InstruccionOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                return InstruccionOperacionBusiness.GetByOperacionProceso(operacionProcesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOperacion / GetByOperacionProceso", exception);
            }
        }
    }
}
