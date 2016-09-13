using System;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    public class Turno : ITurno
    {
        public TurnoBusiness Update(TurnoBusiness turno)
        {
            try
            {
                return turno.Id == 0
                    ? TurnoBusiness.Insert(turno)
                    : TurnoBusiness.Update(turno);
            }
            catch (Exception exception)
            {

                throw new Exception("Turno.Update", exception);
            }
        }

        public void Delete(int turnoId)
        {
            try
            {
                TurnoBusiness.Delete(turnoId);
            }
            catch (Exception exception)
            {

                throw new Exception("Turno.Delete", exception);
            }
        }

        public TurnoBusiness Get(int turnoId)
        {
            try
            {
                return TurnoBusiness.Get(turnoId);
            }
            catch (Exception exception)
            {

                throw new Exception("Turno.Get", exception);
            }
        }

        public TurnoBusiness[] GetAll()
        {
            try
            {
                return TurnoBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("Turno.GetAll", exception);
            }
        }
    }
}
