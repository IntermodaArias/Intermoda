using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class IngredienteOperacion : IIngredienteOperacion
    {
        public IngredienteOperacionBusiness Update(IngredienteOperacionBusiness ingredienteOperacion)
        {
            try
            {
                return ingredienteOperacion.Id == 0
                    ? IngredienteOperacionBusiness.Insert(ingredienteOperacion)
                    : IngredienteOperacionBusiness.Update(ingredienteOperacion);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / Update", exception);
            }
        }

        public void Delete(int ingredienteOperacionId)
        {
            try
            {
                IngredienteOperacionBusiness.Delete(ingredienteOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / Delete", exception);
            }
        }

        public IngredienteOperacionBusiness Get(int ingredienteOperacionId)
        {
            try
            {
                return IngredienteOperacionBusiness.Get(ingredienteOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / Get", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetAll()
        {
            try
            {
                return IngredienteOperacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetAll", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetByIngrediente(int ingredienteId)
        {
            try
            {
                return IngredienteOperacionBusiness.GetByIngrediente(ingredienteId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByIngrediente", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetByOperacion(int operacionId)
        {
            try
            {
                return IngredienteOperacionBusiness.GetByOperacion(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByOperacion", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                return IngredienteOperacionBusiness.GetByOperacionProceso(operacionProcesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByOperacionProceso", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetByClase(string claseId)
        {
            try
            {
                return IngredienteOperacionBusiness.GetByClase(claseId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByClase", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetBySubClase(string subClaseId)
        {
            try
            {
                return IngredienteOperacionBusiness.GetBySubClase(subClaseId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetBySubClase", exception);
            }
        }

        public IngredienteOperacionBusiness[] GetByInstruccionOperacion(int instruccionOperacionId)
        {
            try
            {
                return IngredienteOperacionBusiness.GetByInstruccionOperacion(instruccionOperacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByInstruccionOperacion", exception);
            }
        }
    }
}
