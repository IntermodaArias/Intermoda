using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class OrdenProduccionExterno : IOrdenProduccionExterno
    {
        public OrdenProduccionExternoBusiness[] GetByUsuarioPlanta(string usuario)
        {
            try
            {
                return OrdenProduccionExternoBusiness.GetByUsuarioPlanta(usuario);
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno Service / GetByUsuarioPlanta", exception);
            }
        }

        public OrdenProduccionExternoBusiness[] Get()
        {
            try
            {
                return OrdenProduccionExternoBusiness.Get();
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno Service / Get", exception);
            }
        }

        public MaquiladoTrabajoEnProceso[] GetMaquiladoTrabajoEnProceso()
        {
            try
            {
                return OrdenProduccionExternoBusiness.GetMaquiladoTrabajoEnProceso();
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno Service / GetMaquiladoTrabajoEnProceso", exception);
            }
        }

        public void SetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId)
        {
            try
            {
                OrdenProduccionExternoBusiness.SetEstado(companiaId, ordenAno, ordenNumero, estadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno Service / SetEstado", exception);
            }
        }

        public OrdenProduccionExternoBusiness GrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId, string tipo,
            string usuario)
        {
            try
            {
                return OrdenProduccionExternoBusiness.GrabarLectura(companiaId,ordenAno,ordenNumero,centroTrabajoId, tipo, usuario);
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno Service / GrabarLectura", exception);
            }
        }

        public void SetEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                OrdenProduccionExternoBusiness.SetEstadoEnviarIntermoda(companiaId, ordenAno, ordenNumero);
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno Service / SetEstadoEnviarIntermoda", exception);
            }
        }
    }
}
