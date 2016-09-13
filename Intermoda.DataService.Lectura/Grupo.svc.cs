using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class Grupo : IGrupo
    {
        public GrupoBusiness Update(GrupoBusiness grupoBusiness)
        {
            try
            {
                return grupoBusiness.Id == 0
                    ? GrupoBusiness.Insert(grupoBusiness)
                    : GrupoBusiness.Update(grupoBusiness);
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoUpdate", exception);
            }
        }

        public void Delete(int grupoId)
        {
            try
            {
                GrupoBusiness.Delete(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoDelete", exception);
            }
        }

        public GrupoBusiness Get(int grupoId)
        {
            try
            {
                return GrupoBusiness.Get(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoGet", exception);
            }
        }

        public GrupoBusiness[] GetAll()
        {
            try
            {
                return GrupoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoGetAll", exception);
            }
        }

        public GrupoBusiness[] GetAllActivos()
        {
            try
            {
                return GrupoBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoGetAllActivos", exception);
            }
        }

        public GrupoBusiness GetByLinea(int lineaId)
        {
            try
            {
                return GrupoBusiness.GetByLinea(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoGetByLinea", exception);
            }
        }

        public void CopiarSemana(DateTime desde, DateTime hasta)
        {
            try
            {
                GrupoBusiness.CopiarSemana(desde, hasta);
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoCopiarSemana", exception);
            }
        }

        public bool HayDataSemana(DateTime fecha)
        {
            try
            {
                return GrupoBusiness.HayDataSemana(fecha);
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo.GrupoHayDataSemana", exception);
            }
        }
    }
}
