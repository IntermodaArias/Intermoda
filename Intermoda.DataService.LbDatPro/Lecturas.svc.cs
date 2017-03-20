using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class Lecturas : ILecturas
    {
        public LecturaCuponBusiness ValidaUsuario(string usuario)
        {
            try
            {
                return LecturaCuponBusiness.UsuarioLecturaCupon(usuario);

            }
            catch (Exception exception)
            {
                throw new Exception("Lectura WebService / ValidaUsuario", exception);
            }
        }

        public LecturaCuponBusiness ProcesaCupon(string usuario, string cupon)
        {
            try
            {
                return LecturaCuponBusiness.LecturaCupon(cupon, usuario);
            }
            catch (Exception exception)
            {
                throw new Exception("Lectura WebService / ProcesaCupon", exception);
            }
        }
    }
}
