using System;

namespace Intermoda.Client.DataService.LecturaEnPlanta
{
    public interface IDataServiceLecturaPlanta
    {
        void ValidaUsuario(string usuario, Action<bool, Exception> action);

        void ProcesaCupon(string usuario, string cupon, Action<bool, Exception> action);
    }
}