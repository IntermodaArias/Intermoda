using System;
using Intermoda.Business.Lavanderia;
using Intermoda.Common.Enum;

namespace Intermoda.DataService.Lavanderia
{
    public class MaquinaCapacidad : IMaquinaCapacidad
    {
        public MaquinaCapacidadBusiness Update(MaquinaCapacidadBusiness maquinaCapacidad)
        {
            try
            {
                return MaquinaCapacidadBusiness.Update(maquinaCapacidad);
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaCapacidad / Update", exception);
            }
        }

        public void Delete(MaquinaTipo tipo, int maquinaCapacidadId)
        {
            try
            {
                MaquinaCapacidadBusiness.Delete(tipo, maquinaCapacidadId);
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaCapacidad / Delete", exception);
            }
        }

        public MaquinaCapacidadBusiness Get(MaquinaTipo tipo, int maquinaCapacidadId)
        {
            try
            {
                return MaquinaCapacidadBusiness.Get(tipo, maquinaCapacidadId);
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaCapacidad / Get", exception);
            }
        }

        public MaquinaCapacidadBusiness[] GetAll()
        {
            try
            {
                return MaquinaCapacidadBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaCapacidad / GetAll", exception);
            }
        }

        public MaquinaCapacidadBusiness[] GetByTipo(MaquinaTipo tipo)
        {
            try
            {
                return MaquinaCapacidadBusiness.GetByTipo(tipo);
            }
            catch (Exception exception)
            {
                throw new Exception("MaquinaCapacidad / GetByTipo", exception);
            }
        }
    }
}
