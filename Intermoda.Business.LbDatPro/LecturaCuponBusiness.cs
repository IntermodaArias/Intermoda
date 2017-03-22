using System.Data.Entity.Core.Objects;
using System.Runtime.Serialization;
using Intermoda.LbDatPro;

namespace Intermoda.Business.LbDatPro
{
    [DataContract]
    public class LecturaCuponBusiness
    {
        private const short CompaniaId = 1;

        private static LBDATPROEntities _context;

        #region Properties

        [DataMember]
        public int ErrorId { get; set; }

        [DataMember]
        public string ErrorName { get; set; }

        #endregion

        public static LecturaCuponBusiness UsuarioLecturaCupon(string user)
        {
            using (_context = new LBDATPROEntities())
            {
                var error = "";

                var prmUser = new ObjectParameter("strUsuario", user);
                var prmCia = new ObjectParameter("compania", CompaniaId);
                var prmErr = new ObjectParameter("strError", error);

                _context.PRD_UsuarioLecturaCuponGX(prmUser, prmCia, prmErr);

                if (prmErr.Value.GetType() != typeof (string))
                {
                    return new LecturaCuponBusiness {ErrorId = 0, ErrorName = "OK"};
                }
                return new LecturaCuponBusiness {ErrorId = 1, ErrorName = (string)prmErr.Value };
            }
        }

        public static LecturaCuponBusiness LecturaCupon(string cupon, string user)
        {
            using (_context = new LBDATPROEntities())
            {
                var error = "";
                var intError = 0;

                var prmCia = new ObjectParameter("ciaCod", CompaniaId);
                var prmCup = new ObjectParameter("strCupon", cupon);
                var prmUsr = new ObjectParameter("usuario", user);
                var prmErr = new ObjectParameter("strError", error);
                var prmInt = new ObjectParameter("intError", intError);

                _context.PRD_LecturaCuponGX(prmCia, prmCup, prmUsr, prmErr, prmInt);

                intError = (int) prmInt.Value;
                error = (string) prmErr.Value;

                return new LecturaCuponBusiness { ErrorId = intError, ErrorName = error };
            }
        }
    }
}