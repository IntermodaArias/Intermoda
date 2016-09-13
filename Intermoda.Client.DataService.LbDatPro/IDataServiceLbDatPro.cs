using System;
using System.Collections.Generic;
using Intermoda.Client.LbDatPro;

namespace Intermoda.Client.DataService.LbDatPro
{
    public interface IDataServiceLbDatPro
    {
        #region Empleado

        void EmpleadoGet(short companiaCodigo, int empleadoId, Action<Empleado, Exception> action);
        void EmpleadoGetAllActivos(Action<List<Empleado>, Exception> action);

        #endregion

        #region Inasistencias

        void InasistenciaGetByFecha(DateTime fechaInicial, DateTime fechaFinal,
            Action<List<Inasistencia>, Exception> action);
        void InasistenciaGetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicial,
            DateTime fechaFinal, Action<List<Inasistencia>, Exception> action);

        #endregion

        #region OrdenProduccionExterno

        void OrdenProduccionExternoGetByUsuarioPlanta(string usuario,
            Action<List<OrdenProduccionExterno>, Exception> action);

        void OrdenProduccionExternoSetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId,
            Action<Exception> action);

        void OrdenProduccionExternoGrabarLectura(short companiaId, short ordenAno, short ordenNumero,
            string centroTrabajoId, string tipo, string usuario, Action<Exception> action);

        void OrdenProduccionExternoSerEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero,
            Action<Exception> action);

        #endregion

        #region Planta

        void PlantaGetByUsuario(string usuario, string clave, Action<Planta, Exception> action);

        void PlantaUpdateClave(string plantaId, string claveOld, string claveNew, Action<Exception> action);

        #endregion
    }
}