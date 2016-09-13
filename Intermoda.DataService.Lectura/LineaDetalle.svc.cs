using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class LineaDetalle : ILineaDetalle
    {
        public LineaDetalleBusiness Update(LineaDetalleBusiness lineaDetalle)
        {
            try
            {
                return lineaDetalle.Id == 0
                    ? LineaDetalleBusiness.Insert(lineaDetalle)
                    : LineaDetalleBusiness.Update(lineaDetalle);
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle.Update", exception);
            }
        }

        public void Delete(int lineaDetalleId)
        {
            try
            {
                LineaDetalleBusiness.Delete(lineaDetalleId);
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle.Delete", exception);
            }
        }

        public LineaDetalleBusiness[] GetAll()
        {
            try
            {
                return LineaDetalleBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle.GetAll", exception);
            }
        }

        public LineaDetalleBusiness[] GetByLinea(int lineaId)
        {
            try
            {
                return LineaDetalleBusiness.GetByLinea(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle.GetByLinea", exception);
            }
        }

        public LineaDetalleBusiness[] GetByLineaModulo(int lineaId, int moduloId)
        {
            try
            {
                return LineaDetalleBusiness.GetByLineaModulo(lineaId, moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle.GetByLineaModulo", exception);
            }
        }
    }
}
