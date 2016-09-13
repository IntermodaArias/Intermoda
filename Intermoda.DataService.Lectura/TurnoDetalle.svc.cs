using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class TurnoDetalle : ITurnoDetalle
    {
        public TurnoDetalleBusiness Update(TurnoDetalleBusiness turnoDetalle)
        {
            try
            {
                return turnoDetalle.Id == 0
                    ? TurnoDetalleBusiness.Insert(turnoDetalle)
                    : TurnoDetalleBusiness.Update(turnoDetalle);
            }
            catch (Exception exception)
            {

                throw new Exception("TurnoDetalle.Update", exception);
            }
        }

        public void Delete(int turnoDetalleId)
        {
            try
            {
                TurnoDetalleBusiness.Delete(turnoDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("TurnoDetalle.Delete", exception);
            }
        }

        public TurnoDetalleBusiness Get(int turnoDetalleId)
        {
            try
            {
                return TurnoDetalleBusiness.Get(turnoDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("TurnoDetalle.Get", exception);
            }
        }

        public TurnoDetalleBusiness[] GetAll()
        {
            try
            {
                return TurnoDetalleBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("TurnoDetalle.GetAll", exception);
            }
        }

        public TurnoDetalleBusiness[] GetByTurno(int turnoId)
        {
            try
            {
                return TurnoDetalleBusiness.GetByTurno(turnoId);
            }
            catch (Exception exception)
            {

                throw new Exception("TurnoDetalle.GetByTurno", exception);
            }
        }
    }
}
