using System;

namespace Intermoda.Client.DataService.LecturaEnPlanta
{
    public class DesignDataServiceLecturaPlanta : IDataServiceLecturaPlanta
    {
        public void ValidaUsuario(string usuario, Action<bool, Exception> action)
        {
            throw new NotImplementedException();
        }

        public void ProcesaCupon(string usuario, string cupon, Action<bool, Exception> action)
        {
            throw new NotImplementedException();
        }
    }
}