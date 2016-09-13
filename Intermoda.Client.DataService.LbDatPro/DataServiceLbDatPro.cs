using System;
using System.Collections.Generic;
using Intermoda.Client.LbDatPro;

namespace Intermoda.Client.DataService.LbDatPro
{
    public class DataServiceLbDatPro : IDataServiceLbDatPro
    {
        #region Empleado

        public async void EmpleadoGet(short companiaCodigo, int empleadoId, Action<Empleado, Exception> action)
        {
            try
            {
                var reg = await Empleado.Get(companiaCodigo, empleadoId);

                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void EmpleadoGetAllActivos(Action<List<Empleado>, Exception> action)
        {
            try
            {
                var lista = await Empleado.GetAllActivos();

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion
        
        #region Inasistencias

        public async void InasistenciaGetByFecha(DateTime fechaInicial, DateTime fechaFinal,
            Action<List<Inasistencia>, Exception> action)
        {
            try
            {
                var lista = await Inasistencia.GetByFecha(fechaInicial, fechaFinal);

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InasistenciaGetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicial,
            DateTime fechaFinal, Action<List<Inasistencia>, Exception> action)
        {
            try
            {
                var lista = await
                    Inasistencia.GetByEmpleadoFecha(companiaCodigo, empleadoCodigo, fechaInicial, fechaFinal);

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OrdenProduccionExterno

        public async void OrdenProduccionExternoGetByUsuarioPlanta(string usuario,
            Action<List<OrdenProduccionExterno>, Exception> action)
        {
            try
            {
                var lista = await OrdenProduccionExterno.GetByUsuarioPlanta(usuario);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OrdenProduccionExternoSetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId,
            Action<Exception> action)
        {
            try
            {
                await OrdenProduccionExterno.SetEstado(companiaId, ordenAno, ordenNumero, estadoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OrdenProduccionExternoGrabarLectura(short companiaId, short ordenAno, short ordenNumero, string centroTrabajoId,
            string tipo, string usuario, Action<Exception> action)
        {
            try
            {
                await OrdenProduccionExterno.GrabarLectura(companiaId, ordenAno, ordenNumero, centroTrabajoId, tipo,
                    usuario);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OrdenProduccionExternoSerEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero, Action<Exception> action)
        {
            try
            {
                await OrdenProduccionExterno.SetEstadoEnviarIntermoda(companiaId, ordenAno, ordenNumero);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        #endregion

        #region Planta

        public async void PlantaGetByUsuario(string usuario, string clave, Action<Planta, Exception> action)
        {
            try
            {
                var reg = Planta.GetByUsuario(usuario, clave);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void PlantaUpdateClave(string plantaId, string claveOld, string claveNew, Action<Exception> action)
        {
            try
            {
                Planta.UpdateClave(plantaId, claveOld, claveNew);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        #endregion
    }
}