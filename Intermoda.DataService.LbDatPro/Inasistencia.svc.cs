using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class Inasistencia : IInasistencia
    {
        public InasistenciaBusiness[] GetByFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                if (fechaInicial == fechaFinal)
                {
                    return InasistenciaBusiness.GetByFecha(fechaInicial);
                }

                return InasistenciaBusiness.GetByFecha(fechaInicial, fechaFinal);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.InasistenciaGetByFecha", exception);
            }
        }

        public InasistenciaBusiness[] GetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicial,
            DateTime fechaFinal)
        {
            try
            {
                if (fechaInicial == fechaFinal)
                {
                    return InasistenciaBusiness.GetByEmpleadoFecha(companiaCodigo, empleadoCodigo, fechaInicial);
                }

                return InasistenciaBusiness.GetByEmpleadoFecha(companiaCodigo, empleadoCodigo, fechaInicial, fechaFinal);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.InasistenciaGetByEmpleadoFecha", exception);
            }
        }
    }
}
