using System;
using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IInasistencia
    {
        [OperationContract]
        InasistenciaBusiness[] GetByFecha(DateTime fechaInicial, DateTime fechaFinal);

        [OperationContract]
        InasistenciaBusiness[] GetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo,
            DateTime fechaInicial, DateTime fechaFinal);
    }
}
