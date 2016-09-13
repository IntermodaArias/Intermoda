using System;
using System.Collections.Generic;
using lb = Intermoda.Client.LbDatPro;
using lv = Intermoda.Client.Lavanderia;

namespace Intermoda.DataServices
{
    public class DataService : IDataService
    {

        #region CentroTrabajo

        public async void CentroTrabajoUpdate(CentroTrabajo centroTrabajo, Action<CentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await CentroTrabajo.Update(centroTrabajo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoDelete(int centroTrabajoId, Action<Exception> action)
        {
            try
            {
                await CentroTrabajo.Delete(centroTrabajoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void CentroTrabajoGet(int centroTrabajoId, Action<CentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await CentroTrabajo.Get(centroTrabajoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoGetAll(Action<List<CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajo.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoGetActivos(Action<List<CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajo.GetActivos();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region CentroTrabajoClasificacion

        public async void CentroTrabajoClasificacionUpdate(CentroTrabajoClasificacion centroTrabajoClasificacion,
            Action<CentroTrabajoClasificacion, Exception> action)
        {
            try
            {
                var reg = await CentroTrabajoClasificacion.Update(centroTrabajoClasificacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoClasificacionDelete(int centroTrabajoClasificacionId, Action<Exception> action)
        {
            try
            {
                await CentroTrabajoClasificacion.Delete(centroTrabajoClasificacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void CentroTrabajoClasificacionGetAll(int centroTrabajoId,
            Action<List<CentroTrabajoClasificacion>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajoClasificacion.GetAll(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoClasificacionGetAllActive(int centroTrabajoId,
            Action<List<CentroTrabajoClasificacion>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajoClasificacion.GetAllActive(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Empleado

        public async void EmpleadoGet(short companiaCodigo, int empleadoId, Action<lb.Empleado, Exception> action)
        {
            try
            {
                var reg = await lb.Empleado.Get(companiaCodigo, empleadoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void EmpleadoGetAllActivos(Action<List<lb.Empleado>, Exception> action)
        {
            try
            {
                var lista = await lb.Empleado.GetAllActivos();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Grupo

        public async void GrupoUpdate(Grupo grupo, Action<Grupo, Exception> action)
        {
            try
            {
                var reg = await Grupo.Update(grupo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void GrupoDelete(int grupoId, Action<Exception> action)
        {
            try
            {
                await Grupo.Delete(grupoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void GrupoGet(int grupoId, Action<Grupo, Exception> action)
        {
            try
            {
                var reg = await Grupo.Get(grupoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void GrupoGetAll(Action<List<Grupo>, Exception> action)
        {
            try
            {
                var lista = await Grupo.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void GrupoGetAllActivos(Action<List<Grupo>, Exception> action)
        {
            try
            {
                var lista = await Grupo.GetAllActive();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public void GrupoGetByLinea(int lineaId, Action<Grupo, Exception> action)
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void GrupoCopiarSemana(DateTime desde, DateTime hasta, Action<Exception> action)
        {
            try
            {
                await Grupo.CopiarSemana(desde, hasta);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void GrupoHayDataSemana(DateTime fecha, Action<bool, Exception> action)
        {
            try
            {
                var vrf = await Grupo.HayDataSemana(fecha);
                action(vrf, null);
            }
            catch (Exception exception)
            {
                action(false, exception);
            }
        }

        #endregion

        #region Jornada

        public async void JornadaUpdate(Jornada jornada, Action<Jornada, Exception> action)
        {
            try
            {
                var reg = await Jornada.Update(jornada);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void JornadaDelete(int jornadaId, Action<Exception> action)
        {
            try
            {
                await Jornada.Delete(jornadaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void JornadaGet(int jornadaId, Action<Jornada, Exception> action)
        {
            try
            {
                var reg = await Jornada.Get(jornadaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void JornadaGetAll(Action<List<Jornada>, Exception> action)
        {
            try
            {
                var lista = await Jornada.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region JornadaDetalle

        public async void JornadaDetalleUpdate(JornadaDetalle jornadaDetalle, Action<JornadaDetalle, Exception> action)
        {
            try
            {
                var reg = await JornadaDetalle.Update(jornadaDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void JornadaDetalleDelete(int jornadaDetalleId, Action<Exception> action)
        {
            try
            {
                await JornadaDetalle.Delete(jornadaDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void JornadaDetalleGet(int jornadaDetalleId, Action<JornadaDetalle, Exception> action)
        {
            try
            {
                var reg = await JornadaDetalle.Get(jornadaDetalleId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void JornadaDetalleGetByJornada(int jornadaId, Action<List<JornadaDetalle>, Exception> action)
        {
            try
            {
                var lista = await JornadaDetalle.GetByJornada(jornadaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion
        
        #region Linea

        public async void LineaUpdate(Linea linea, Action<Linea, Exception> action)
        {
            try
            {
                var reg = await Linea.Update(linea);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LineaDelete(int lineaId, Action<Exception> action)
        {
            try
            {
                await Linea.Delete(lineaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LineaGetByGrupo(int grupoId, Action<List<Linea>, Exception> action)
        {
            try
            {
                var lista = await Linea.GetByGrupo(grupoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LineaGetByGrupoActivas(int grupoId, Action<List<Linea>, Exception> action)
        {
            try
            {
                var lista = await Linea.GetByGrupoActivas(grupoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region LineaDetalle

        public async void LineaDetalleUpdate(LineaDetalle lineaDetalle, Action<LineaDetalle, Exception> action)
        {
            try
            {
                var reg = await LineaDetalle.Update(lineaDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LineaDetalleDelete(int lineaDetalleId, Action<Exception> action)
        {
            try
            {
                await LineaDetalle.Delete(lineaDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LineaDetalleGetByLinea(int lineaId, Action<List<LineaDetalle>, Exception> action)
        {
            try
            {
                var lista = await LineaDetalle.GetByLinea(lineaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Modulo

        public async void ModuloUpdate(Modulo modulo, Action<Modulo, Exception> action)
        {
            try
            {
                var reg = await Modulo.Update(modulo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloDelete(int moduloId, Action<Exception> action)
        {
            try
            {
                await Modulo.Delete(moduloId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ModuloGetAll(int centroTrabajoId, Action<List<Modulo>, Exception> action)
        {
            try
            {
                var lista = await Modulo.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion
        
        #region ModuloSemana

        public async void ModuloSemanaUpdate(ModuloSemana moduloSemana, Action<ModuloSemana, Exception> action)
        {
            try
            {
                var reg = await ModuloSemana.Update(moduloSemana);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloSemanaDelete(int moduloSemanaId, Action<Exception> action)
        {
            try
            {
                await ModuloSemana.Delete(moduloSemanaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ModuloSemanaGet(int moduloSemanaId, Action<ModuloSemana, Exception> action)
        {
            try
            {
                var reg = await ModuloSemana.Get(moduloSemanaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloSemanaGetByFecha(DateTime fechaInicio, Action<List<ModuloSemana>, Exception> action)
        {
            try
            {
                var lista = await ModuloSemana.GetByFecha(fechaInicio);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloSemanaGetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId, Action<List<ModuloSemana>, Exception> action)
        {
            try
            {
                var lista = await ModuloSemana.GetByFechaCentroTrabajo(fechaInicio, centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloSemanaGetByFechaModulo(DateTime fechaInicio, int moduloId, Action<List<ModuloSemana>, Exception> action)
        {
            try
            {
                var lista = await ModuloSemana.GetByFechaModulo(fechaInicio, moduloId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region ModuloSemanaOperario

        public async void ModuloSemanaOperarioUpdate(ModuloSemanaOperario moduloSemanaOperario,
            Action<ModuloSemanaOperario, Exception> action)
        {
            try
            {
                var reg = await ModuloSemanaOperario.Update(moduloSemanaOperario);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloSemanaOperarioDelete(int moduloSemanaOperarioId, Action<Exception> action)
        {
            try
            {
                await ModuloSemanaOperario.Delete(moduloSemanaOperarioId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ModuloSemanaOperarioGet(int moduloSemanaOperarioId, Action<ModuloSemanaOperario, Exception> action)
        {
            try
            {
                var reg = await ModuloSemanaOperario.Get(moduloSemanaOperarioId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ModuloSemanaOperarioGetByModuloSemana(int moduloSemanaId,
            Action<List<ModuloSemanaOperario>, Exception> action)
        {
            try
            {
                var lista = await ModuloSemanaOperario.GetByModuloSemana(moduloSemanaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Turno

        public async void TurnoUpdate(Turno turno, Action<Turno, Exception> action)
        {
            try
            {
                var reg = await Turno.Update(turno);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TurnoDelete(int turnoId, Action<Exception> action)
        {
            try
            {
                await Turno.Delete(turnoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void TurnoGet(int turnoId, Action<Turno, Exception> action)
        {
            try
            {
                var reg = await Turno.Get(turnoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TurnoGetAll(Action<List<Turno>, Exception> action)
        {
            try
            {
                var lista = await Turno.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region TurnoDetalle

        public async void TurnoDetalleUpdate(TurnoDetalle turnoDetalle, Action<TurnoDetalle, Exception> action)
        {
            try
            {
                var reg = await TurnoDetalle.Update(turnoDetalle);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TurnoDetalleDelete(int turnoDetalleId, Action<Exception> action)
        {
            try
            {
                await TurnoDetalle.Delete(turnoDetalleId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void TurnoDetalleGet(int turnoDetalleId, Action<TurnoDetalle, Exception> action)
        {
            try
            {
                var reg = await TurnoDetalle.Get(turnoDetalleId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TurnoDetalleGetByTurno(int turnoId, Action<List<TurnoDetalle>, Exception> action)
        {
            try
            {
                var lista = await TurnoDetalle.GetByTurno(turnoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion
    }
}