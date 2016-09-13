using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class CentroTrabajoClasificacion : ICentroTrabajoClasificacion
    {
        public CentroTrabajoClasificacionBusiness Update(
            CentroTrabajoClasificacionBusiness centroTrabajoClasificacion)
        {
            try
            {
                return centroTrabajoClasificacion.Id == 0
                    ? CentroTrabajoClasificacionBusiness.Insert(centroTrabajoClasificacion)
                    : CentroTrabajoClasificacionBusiness.Update(centroTrabajoClasificacion);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionUpdate", exception);
            }
        }

        public void Delete(int centroTrabajoClasificacionId)
        {
            try
            {
                CentroTrabajoClasificacionBusiness.Delete(centroTrabajoClasificacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionDelete", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness Get(int centroTrabajoClasificacionId)
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.Get(centroTrabajoClasificacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionGet", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] GetAll()
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionGetAll", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] GetAllActivos()
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionGetAllActivos", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetByCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionGetByCentroTrabajo", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] GetByCentroTrabajoActivos(
            int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetByCentroTrabajoActivos(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion.CentroTrabajoClasificacionGetByCentroTrabajoActivos", exception);
            }
        }
    }
}
