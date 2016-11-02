using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class MaquiladoCaja : IMaquiladoCaja
    {
        public MaquiladoCajaBusiness Update(MaquiladoCajaBusiness model)
        {
            try
            {
                return model.Id == 0
                    ? MaquiladoCajaBusiness.Insert(model)
                    : MaquiladoCajaBusiness.Update(model);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCaja / Update", exception);
            }
        }

        public void Delete(int maquiladoCajaId)
        {
            try
            {
                MaquiladoCajaBusiness.Delete(maquiladoCajaId);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCaja / Delete", exception);
            }
        }

        public MaquiladoCajaBusiness Get(int maquiladoCajaId)
        {
            try
            {
                return MaquiladoCajaBusiness.Get(maquiladoCajaId);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCaja / Get", exception);
            }
        }

        public MaquiladoCajaBusiness[] GetByOrden(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                return MaquiladoCajaBusiness.GetAllByOrden(companiaId, ordenAno, ordenNumero);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCaja / GetByOrden", exception);
            }
        }

        //

        public MaquiladoEmpaqueBusiness[] GetDetalleByOrden(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                return MaquiladoCajaBusiness.GetDetalleByOrden(companiaId, ordenAno, ordenNumero);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCaja / GetDetalleByOrden", exception);
            }
        }
    }
}
