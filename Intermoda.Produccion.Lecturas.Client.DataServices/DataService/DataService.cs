using System;
using System.Collections.Generic;
using lb = Intermoda.Client.LbDatPro;
using lv = Intermoda.Produccion.Lecturas.Client.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Client.DataServices
{
    public class DataService : IDataService
    {
        #region Lavanderia

        #region Lavanderia - CentroTrabajo

        public async void LavanderiaCentroTrabajoUpdate(lv.CentroTrabajo centroTrabajo,
            Action<lv.CentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await lv.CentroTrabajo.Update(centroTrabajo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaCentroTrabajoDelete(int centroTrabajoId, Action<Exception> action)
        {
            try
            {
                await lv.CentroTrabajo.Delete(centroTrabajoId);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LavanderiaCentroTrabajoGet(int centroTrabajoId, Action<lv.CentroTrabajo, Exception> action)
        {
            var reg = await lv.CentroTrabajo.Get(centroTrabajoId);
            action(reg, null);
        }

        public async void LavanderiaCentroTrabajoGetAll(Action<List<lv.CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.CentroTrabajo.GetAll();

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaCentroTrabajoGetActivos(Action<List<lv.CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.CentroTrabajo.GetActivos();

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaCentroTrabajoGetByOperacion(int operacionId, Action<List<lv.CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.CentroTrabajo.GetByOperacion(operacionId);

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaCentroTrabajoGetAllLavanderia(Action<List<lv.CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.CentroTrabajo.GetAllLavanderia();

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Lavanderia - Proceso

        public async void LavanderiaProcesoUpdate(lv.Proceso proceso, Action<lv.Proceso, Exception> action)
        {
            try
            {
                var reg = await lv.Proceso.Update(proceso);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaProcesoDelete(int procesoId, Action<Exception> action)
        {
            try
            {
                await lv.Proceso.Delete(procesoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LavanderiaProcesoGet(int procesoId, Action<lv.Proceso, Exception> action)
        {
            try
            {
                var reg = await lv.Proceso.Get(procesoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaProcesoGetAll(Action<List<lv.Proceso>, Exception> action)
        {
            try
            {
                var lista = await lv.Proceso.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaProcesoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<lv.Proceso>, Exception> action)
        {
            try
            {
                var lista = await lv.Proceso.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Operacion

        public async void LavanderiaOperacionUpdate(lv.Operacion operacion, Action<lv.Operacion, Exception> action)
        {
            try
            {
                var reg = await lv.Operacion.Update(operacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaOperacionDelete(int operacionId, Action<Exception> action)
        {
            try
            {
                await lv.Operacion.Delete(operacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LavanderiaOperacionGet(int operacionId, Action<lv.Operacion, Exception> action)
        {
            try
            {
                var reg = await lv.Operacion.Get(operacionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaOperacionGetAll(Action<List<lv.Operacion>, Exception> action)
        {
            try
            {
                var lista = await lv.Operacion.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaOperacionGetAllLavanderia(Action<List<lv.Operacion>, Exception> action)
        {
            try
            {
                var lista = await lv.Operacion.GetAllLavanderia();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavanderiaOperacionGetOperacionesHumedas(int centrotrabajoId, Action<List<lv.Operacion>, Exception> action)
        {
            try
            {
                var lista = await lv.Operacion.GetOperacionesHumedas(centrotrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OperacionCentroTrabajo

        public async void LavanderiaOperacionCentroTrabajoUpdate(lv.OperacionCentroTrabajo operacionCentroTrabajo,
            Action<lv.OperacionCentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await lv.OperacionCentroTrabajo.Update(operacionCentroTrabajo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void LavanderiaOperacionCentroTrabajoDelete(int opeacionCentroTrabajoId, Action<Exception> action)
        {
            try
            {
                await lv.OperacionCentroTrabajo.Delete(opeacionCentroTrabajoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
                throw;
            }
        }

        public async void LavanderiaOperacionCentroTrabajoGet(int opeacionCentroTrabajoId,
            Action<lv.OperacionCentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await lv.OperacionCentroTrabajo.Get(opeacionCentroTrabajoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void LavanderiaOperacionCentroTrabajoGetAll(
            Action<List<lv.OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.OperacionCentroTrabajo.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void LavanderiaOperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<lv.OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.OperacionCentroTrabajo.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void LavanderiaOperacionCentroTrabajoGetByOperacion(short opeacionId,
            Action<List<lv.OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await lv.OperacionCentroTrabajo.GetByOperacion(opeacionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        #endregion

        #endregion

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