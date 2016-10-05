using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class MaquiladoCajaDetalle : IMaquiladoCajaDetalle
    {
        public MaquiladoCajaDetalleBusiness Update(MaquiladoCajaDetalleBusiness model)
        {
            try
            {
                return model.Id == 0
                    ? MaquiladoCajaDetalleBusiness.Insert(model)
                    : MaquiladoCajaDetalleBusiness.Update(model);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCajaDetalle / Update", exception);
            }
        }

        public void Delete(int maquiladoCajaDetalleId)
        {
            try
            {
                MaquiladoCajaDetalleBusiness.Delete(maquiladoCajaDetalleId);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCajaDetalle / Delete", exception);
            }
        }

        public MaquiladoCajaDetalleBusiness Get(int maquiladoCajaDetalleId)
        {
            try
            {
                return MaquiladoCajaDetalleBusiness.Get(maquiladoCajaDetalleId);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCajaDetalle / Get", exception);
            }
        }

        public MaquiladoCajaDetalleBusiness[] GetByMaquiladoCaja(int maquiladoCajaId)
        {
            try
            {
                return MaquiladoCajaDetalleBusiness.GetByMaquiladoCaja(maquiladoCajaId);
            }
            catch (Exception exception)
            {
                throw new Exception("WebService MaquiladoCajaDetalle / GetByMaquiladoCaja", exception);
            }
        }
    }
}
