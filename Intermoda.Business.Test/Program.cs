using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.Business.Test
{
    class Program
    {
        static void Main()
        {

            var user = "NBARDALES ";

            var result1 = LecturaCuponBusiness.UsuarioLecturaCupon(user);

            Console.WriteLine($"Resultado: {result1.ErrorId.ToString("00")} {result1.ErrorName}");



            var cupon = "1307171801011";
            var result2 = LecturaCuponBusiness.LecturaCupon(cupon, user);
            Console.WriteLine($"Resultado: {result2.ErrorId.ToString("00")} {result2.ErrorName}");

            Console.ReadLine();
        }
    }
}
