using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class CentroTrabajoOpcion : ICentroTrabajoOpcion
    {
        public CentroTrabajoOpcionBusiness Update(CentroTrabajoOpcionBusiness centroTrabajoOpcion)
        {
            try
            {
                return centroTrabajoOpcion.Id == 0
                    ? CentroTrabajoOpcionBusiness.Insert(centroTrabajoOpcion)
                    : CentroTrabajoOpcionBusiness.Update(centroTrabajoOpcion);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / Update", exception);
            }
        }

        public void InsertLegacy(int opcionId, int centroTrabajoId)
        {
            try
            {
                CentroTrabajoOpcionBusiness.InsertLegacy(opcionId, centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / InsertLegacy", exception);
            }
        }

        public void BajarOrden(int centroTrabajoOpcionId, int orden)
        {
            try
            {
                CentroTrabajoOpcionBusiness.UpdateBajarOrden(centroTrabajoOpcionId, orden);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / BajarOrden", exception);
            }
        }

        public void SubirOrden(int centroTrabajoOpcionId, int orden)
        {
            try
            {
                CentroTrabajoOpcionBusiness.UpdateSubirOrden(centroTrabajoOpcionId, orden);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / SubirOrden", exception);
            }
        }

        public void Delete(int centroTrabajoOpcionId)
        {
            try
            {
                CentroTrabajoOpcionBusiness.Delete(centroTrabajoOpcionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / Delete", exception);
            }
        }

        public void DeleteRutaOpcionAcabado(int opcionId)
        {
            try
            {
                CentroTrabajoOpcionBusiness.DeleteRutaOpcionAcabado(opcionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / DeleteRutaOpcionAcabado", exception);
            }
        }

        public CentroTrabajoOpcionBusiness Get(int centroTrabajoOpcionId)
        {
            try
            {
                return CentroTrabajoOpcionBusiness.Get(centroTrabajoOpcionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / Get", exception);
            }
        }

        public CentroTrabajoOpcionBusiness[] GetAll()
        {
            try
            {
                return CentroTrabajoOpcionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / GetAll", exception);
            }
        }

        public CentroTrabajoOpcionBusiness[] GetByOpcion(int opcionId)
        {
            try
            {
                return CentroTrabajoOpcionBusiness.GetByOpcion(opcionId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / GetByOpcion", exception);
            }
        }

        public CentroTrabajoOpcionBusiness[] GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoOpcionBusiness.GetByCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / GetByCentroTrabajo", exception);
            }
        }
    }
}
