using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class Linea : ILinea
    {
        public LineaBusiness Update(LineaBusiness linea)
        {
            try
            {
                return linea.Id == 0
                    ? LineaBusiness.Insert(linea)
                    : LineaBusiness.Update(linea);
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaUpdate", exception);
            }
        }

        public void Delete(int lineaId)
        {
            try
            {
                LineaBusiness.Delete(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaDelete", exception);
            }
        }

        public LineaBusiness Get(int lineaId)
        {
            try
            {
                return LineaBusiness.Get(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaGet", exception);
            }
        }

        public LineaBusiness[] GetAll()
        {
            try
            {
                return LineaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaGetAll", exception);
            }
        }

        public LineaBusiness[] GetAllActivas()
        {
            try
            {
                return LineaBusiness.GetAllActivas();
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaGetAllActivas", exception);
            }
        }

        public LineaBusiness[] GetByGrupo(int grupoId)
        {
            try
            {
                return LineaBusiness.GetByGrupo(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaGetByGrupo", exception);
            }
        }

        public LineaBusiness[] GetByGrupoActivas(int grupoId)
        {
            try
            {
                return LineaBusiness.GetByGrupoActivas(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Linea.LineaGetByGrupoActivas", exception);
            }
        }
    }
}
