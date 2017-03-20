using System;
using System.Threading.Tasks;
using Intermoda.ClientProxy.LbDatPro.LecturaServiceReference;

namespace Intermoda.Client.Produccion.LecturaEnPlanta
{
    public class LecturaCupon
    {
        private static LecturasClient _client;

        #region Properties

        public int ErrorId { get; set; }
        public string ErrorName { get; set; }

        #endregion

        #region Methods

        public static async Task<LecturaCupon> ValidaUsuario(string usuario)
        {
            try
            {
                using (_client = new LecturasClient())
                {
                    var rsp = await _client.ValidaUsuarioAsync(usuario);
                    return BusinessToClient(rsp);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LecturaCupon / ValidaUsuario", exception);
            }
        }

        public static async Task<LecturaCupon> ProcesaCupon(string usuario, string cupon)
        {
            try
            {
                using (_client = new LecturasClient())
                {
                    var rsp = await _client.ProcesaCuponAsync(usuario, cupon);
                    return BusinessToClient(rsp);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LecturaCupon / ProcesaCupon", exception);
            }
        }

        private static LecturaCupon BusinessToClient(LecturaCuponBusiness input)
        {
            return new LecturaCupon
            {
                ErrorId = input.ErrorId,
                ErrorName = input.ErrorName
            };
        }

        private static LecturaCuponBusiness ClientToBusiness(LecturaCupon input)
        {
            return new LecturaCuponBusiness
            {
                ErrorId = input.ErrorId,
                ErrorName = input.ErrorName
            };
        }

        #endregion
    }
}