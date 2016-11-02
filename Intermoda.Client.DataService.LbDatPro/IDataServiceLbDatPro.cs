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

        #region MaquiladoCaja

        void MaquiladoCajaUpdate(MaquiladoCaja maquiladoCaja, Action<MaquiladoCaja, Exception> action);
        void MaquiladoCajaDelete(int maquiladoCajaId, Action<Exception> action);
        void MaquiladoCajaGet(int maquiladoCajaId, Action<MaquiladoCaja, Exception> action);
        void MaquiladoCajaGetByOrden(short companiaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCaja>, Exception> action);
        void MaquiladoEmpaqueGet(short companiaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCaja>, Exception> action);

        #endregion

        #region MaquiladoCajaDetalle

        void MaquiladoCajaDetalleUpdate(MaquiladoCajaDetalle maquiladoCajaDetalle, Action<MaquiladoCajaDetalle, Exception> action);
        void MaquiladoCajaDetalleDelete(int maquiladoCajaDetalleId, Action<Exception> action);
        void MaquiladoCajaDetalleGet(int maquiladoCajaDetalleId, Action<MaquiladoCajaDetalle, Exception> action);
        void MaquiladoCajaDetalleGetByMaquiladoCaja(int maquiladoCajaId, short ordenAno, short ordenNumero,
            Action<List<MaquiladoCajaDetalle>, Exception> action);

        #endregion

        #region OrdenProduccionDetalle

        void OrdenProduccionDetalleGetBultos(short companiaId, short ordenAno, short ordenNumero,
            Action<List<OrdenProduccionBulto>, Exception> action);
        void OrdenProduccionDetalleGetTallas(short companiaId, short ordenAno, short ordenNumero,
            Action<List<OrdenProduccionTalla>, Exception> action);

        #endregion

        #region OrdenProduccionExterno

        void OrdenProduccionExternoGet(short companiaCodigo, short ordenAno, short ordenNumero,
            Action<OrdenProduccionExterno, Exception> action);

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