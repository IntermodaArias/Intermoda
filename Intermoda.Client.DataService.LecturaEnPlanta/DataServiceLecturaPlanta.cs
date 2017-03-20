using System;
using Intermoda.Client.Produccion.LecturaEnPlanta;

namespace Intermoda.Client.DataService.LecturaEnPlanta
{
    public class DataServiceLecturaPlanta : IDataServiceLecturaPlanta
    {
        public async void ValidaUsuario(string usuario, Action<bool, Exception> action)
        {
            try
            {
                var error = await LecturaCupon.ValidaUsuario(usuario);
                if (error.ErrorId == 0 || error.ErrorName == "")
                {
                    action(true, null);
                }
                else
                {
                    action(false, new Exception(error.ErrorName));
                }
            }
            catch (Exception exception)
            {
                action(false, exception);
            }
        }

        public async void ProcesaCupon(string usuario, string cupon, Action<bool, Exception> action)
        {
            try
            {
                var error = await LecturaCupon.ProcesaCupon(usuario, cupon);
                if (error.ErrorId == 0)
                {
                    action(true, null);
                }
                else
                {
                    action(false, new Exception(error.ErrorName));
                }
            }
            catch (Exception exception)
            {
                action(false, exception);
            }
        }
    }
}