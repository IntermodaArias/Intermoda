using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class JornadaDetalle : IJornadaDetalle
    {
        public JornadaDetalleBusiness Update(JornadaDetalleBusiness jornadaDetalle)
        {
            try
            {
                return jornadaDetalle.Id == 0
                    ? JornadaDetalleBusiness.Insert(jornadaDetalle)
                    : JornadaDetalleBusiness.Update(jornadaDetalle);
            }
            catch (Exception exception)
            {

                throw new Exception("JornadaDetalle.JornadaDetalleUpdate", exception);
            }
        }

        public void Delete(int jornadaDetalleId)
        {
            try
            {
                JornadaDetalleBusiness.Delete(jornadaDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("JornadaDetalle.JornadaDetalleDelete", exception);
            }
        }

        public JornadaDetalleBusiness Get(int jornadaDetalleId)
        {
            try
            {
                return JornadaDetalleBusiness.Get(jornadaDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("JornadaDetalle.JornadaDetalleGet", exception);
            }
        }

        public JornadaDetalleBusiness[] GetAll()
        {
            try
            {
                return JornadaDetalleBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("JornadaDetalle.JornadaDetalleGetAll", exception);
            }
        }

        public JornadaDetalleBusiness[] GetByJornada(int jornadaId)
        {
            try
            {
                return JornadaDetalleBusiness.GetbyJornada(jornadaId);
            }
            catch (Exception exception)
            {

                throw new Exception("JornadaDetalle.JornadaDetalleGetByJornada", exception);
            }
        }
    }
}
