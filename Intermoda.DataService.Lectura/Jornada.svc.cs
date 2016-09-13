using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class Jornada : IJornada
    {
        public JornadaBusiness Update(JornadaBusiness jornada)
        {
            try
            {
                return jornada.Id == 0
                    ? JornadaBusiness.Insert(jornada)
                    : JornadaBusiness.Update(jornada);
            }
            catch (Exception exception)
            {

                throw new Exception("Jornada.JornadaUpdate", exception);
            }
        }

        public void Delete(int jornadaId)
        {
            try
            {
                JornadaBusiness.Delete(jornadaId);
            }
            catch (Exception exception)
            {

                throw new Exception("Jornada.JornadaDelete", exception);
            }
        }

        public JornadaBusiness Get(int jornadaId)
        {
            try
            {
                return JornadaBusiness.Get(jornadaId);
            }
            catch (Exception exception)
            {

                throw new Exception("Jornada.JornadaGet", exception);
            }
        }

        public JornadaBusiness[] GetAll()
        {
            try
            {
                return JornadaBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("Jornada.JornadaGetAll", exception);
            }
        }
    }
}
