using System;
using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface IModuloSemana
    {
        [OperationContract]
        ModuloSemanaBusiness Update(ModuloSemanaBusiness moduloSemana);

        [OperationContract]
        void Delete(int moduloSemanaId);

        [OperationContract]
        ModuloSemanaBusiness Get(int moduloSemanaId);

        [OperationContract]
        ModuloSemanaBusiness[] GetAll();

        [OperationContract]
        ModuloSemanaBusiness[] GetByFecha(DateTime fechaInicio);

        [OperationContract]
        ModuloSemanaBusiness[] GetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId);

        [OperationContract]
        ModuloSemanaBusiness[] GetByFechaModulo(DateTime fechaInicio, int moduloId);
    }
}
