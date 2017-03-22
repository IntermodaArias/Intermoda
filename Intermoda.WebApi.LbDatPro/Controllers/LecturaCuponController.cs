using System.Web.Http;
using Intermoda.Business.LbDatPro;

namespace Intermoda.WebApi.LbDatPro.Controllers
{
    public class LecturaCuponController : ApiController
    {
        public LecturaCuponBusiness ValidaUsuario(string user)
        {
            var resp = LecturaCuponBusiness.UsuarioLecturaCupon(user);

            return resp;
        }


        public LecturaCuponBusiness LecturaCupon(string cupon, string user)
        {
            var resp = LecturaCuponBusiness.LecturaCupon(cupon, user);

            return resp;
        }
    }
}
