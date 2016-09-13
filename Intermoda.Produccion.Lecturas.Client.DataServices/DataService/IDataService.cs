using System;
using System.Collections.Generic;
using lb = Intermoda.Client.LbDatPro;
using lv = Intermoda.Produccion.Lecturas.Client.Lavanderia;

namespace Intermoda.Produccion.Lecturas.Client.DataServices
{
    public interface IDataService
    {
        #region Lavanderia

        #region CentroTrabajo

        void LavanderiaCentroTrabajoUpdate(lv.CentroTrabajo centroTrabajo, Action<lv.CentroTrabajo, Exception> action);
        void LavanderiaCentroTrabajoDelete(int centroTrabajoId, Action<Exception> action);
        void LavanderiaCentroTrabajoGet(int centroTrabajoId, Action<lv.CentroTrabajo, Exception> action);
        void LavanderiaCentroTrabajoGetAll(Action<List<lv.CentroTrabajo>, Exception> action);
        void LavanderiaCentroTrabajoGetActivos(Action<List<lv.CentroTrabajo>, Exception> action);
        void LavanderiaCentroTrabajoGetByOperacion(int operacionId, Action<List<lv.CentroTrabajo>, Exception> action);
        void LavanderiaCentroTrabajoGetAllLavanderia(Action<List<lv.CentroTrabajo>, Exception> action);

        #endregion

        #region Proceso

        void LavanderiaProcesoUpdate(lv.Proceso proceso, Action<lv.Proceso, Exception> action);
        void LavanderiaProcesoDelete(int procesoId, Action<Exception> action);
        void LavanderiaProcesoGet(int procesoId, Action<lv.Proceso, Exception> action);
        void LavanderiaProcesoGetAll(Action<List<lv.Proceso>, Exception> action);
        void LavanderiaProcesoGetByCentroTrabajo(int centroTrabajoId, Action<List<lv.Proceso>, Exception> action);

        #endregion

        #region Operacion

        void LavanderiaOperacionUpdate(lv.Operacion operacion, Action<lv.Operacion, Exception> action);
        void LavanderiaOperacionDelete(int operacionId, Action<Exception> action);
        void LavanderiaOperacionGet(int operacionId, Action<lv.Operacion, Exception> action);
        void LavanderiaOperacionGetAll(Action<List<lv.Operacion>, Exception> action);
        void LavanderiaOperacionGetAllLavanderia(Action<List<lv.Operacion>, Exception> action);
        void LavanderiaOperacionGetOperacionesHumedas(int centrotrabajoId, Action<List<lv.Operacion>, Exception> action);

        #endregion

        #region OperacionCentroTrabajo

        void LavanderiaOperacionCentroTrabajoUpdate(lv.OperacionCentroTrabajo operacionCentroTrabajo,
            Action<lv.OperacionCentroTrabajo, Exception> action);
        void LavanderiaOperacionCentroTrabajoDelete(int opeacionCentroTrabajoId, Action<Exception> action);
        void LavanderiaOperacionCentroTrabajoGet(int opeacionCentroTrabajoId,
            Action<lv.OperacionCentroTrabajo, Exception> action);
        void LavanderiaOperacionCentroTrabajoGetAll(Action<List<lv.OperacionCentroTrabajo>, Exception> action);
        void LavanderiaOperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<lv.OperacionCentroTrabajo>, Exception> action);
        void LavanderiaOperacionCentroTrabajoGetByOperacion(short opeacionId,
            Action<List<lv.OperacionCentroTrabajo>, Exception> action);

        #endregion

        #endregion

        #region CentroTrabajo

        void CentroTrabajoUpdate(CentroTrabajo centroTrabajo, Action<CentroTrabajo, Exception> action);
        void CentroTrabajoDelete(int centroTrabajoId, Action<Exception> action);
        void CentroTrabajoGet(int centroTrabajoId, Action<CentroTrabajo, Exception> action);
        void CentroTrabajoGetAll(Action<List<CentroTrabajo>, Exception> action);
        void CentroTrabajoGetActivos(Action<List<CentroTrabajo>, Exception> action);

        #endregion

        #region CentroTrabajoClasificacion

        void CentroTrabajoClasificacionUpdate(CentroTrabajoClasificacion centroTrabajoClasificacion,
            Action<CentroTrabajoClasificacion, Exception> action);
        void CentroTrabajoClasificacionDelete(int centroTrabajoClasificacionId, Action<Exception> action);
        void CentroTrabajoClasificacionGetAll(int centroTrabajoId,
            Action<List<CentroTrabajoClasificacion>, Exception> action);
        void CentroTrabajoClasificacionGetAllActive(int centroTrabajoId,
            Action<List<CentroTrabajoClasificacion>, Exception> action);

        #endregion

        #region Empleado

        void EmpleadoGet(short companiaCodigo, int empleadoId, Action<lb.Empleado, Exception> action);
        void EmpleadoGetAllActivos(Action<List<lb.Empleado>, Exception> action);

        #endregion

        #region Grupo

        void GrupoUpdate(Grupo grupo, Action<Grupo, Exception> action);
        void GrupoDelete(int grupoId, Action<Exception> action);
        void GrupoGet(int grupoId, Action<Grupo, Exception> action);
        void GrupoGetAll(Action<List<Grupo>, Exception> action);
        void GrupoGetAllActivos(Action<List<Grupo>, Exception> action);
        void GrupoGetByLinea(int lineaId, Action<Grupo, Exception> action);
        void GrupoCopiarSemana(DateTime desde, DateTime hasta, Action<Exception> action);
        void GrupoHayDataSemana(DateTime fecha, Action<bool, Exception> action);

        #endregion

        #region Jornada

        void JornadaUpdate(Jornada jornada, Action<Jornada, Exception> action);
        void JornadaDelete(int jornadaId, Action<Exception> action);
        void JornadaGet(int jornadaId, Action<Jornada, Exception> action);
        void JornadaGetAll(Action<List<Jornada>, Exception> action);

        #endregion

        #region JornadaDetalle

        void JornadaDetalleUpdate(JornadaDetalle jornadaDetalle, Action<JornadaDetalle, Exception> action);
        void JornadaDetalleDelete(int jornadaDetalleId, Action<Exception> action);
        void JornadaDetalleGet(int jornadaDetalleId, Action<JornadaDetalle, Exception> action);
        void JornadaDetalleGetByJornada(int jornadaId, Action<List<JornadaDetalle>, Exception> action);

        #endregion

        #region Linea

        void LineaUpdate(Linea linea, Action<Linea, Exception> action);
        void LineaDelete(int lineaId, Action<Exception> action);
        void LineaGetByGrupo(int grupoId, Action<List<Linea>, Exception> action);
        void LineaGetByGrupoActivas(int grupoId, Action<List<Linea>, Exception> action);

        #endregion

        #region LineaDetalle

        void LineaDetalleUpdate(LineaDetalle lineaDetalle, Action<LineaDetalle, Exception> action);
        void LineaDetalleDelete(int lineaDetalleId, Action<Exception> action);
        void LineaDetalleGetByLinea(int lineaId, Action<List<LineaDetalle>, Exception> action);

        #endregion

        #region Modulo

        void ModuloUpdate(Modulo modulo, Action<Modulo, Exception> action);
        void ModuloDelete(int moduloId, Action<Exception> action);
        void ModuloGetAll(int centroTrabajoId, Action<List<Modulo>, Exception> action);

        #endregion

        #region ModuloSemana

        void ModuloSemanaUpdate(ModuloSemana moduloSemana, Action<ModuloSemana, Exception> action);
        void ModuloSemanaDelete(int moduloSemanaId, Action<Exception> action);
        void ModuloSemanaGet(int moduloSemanaId, Action<ModuloSemana, Exception> action);
        void ModuloSemanaGetByFecha(DateTime fechaInicio, Action<List<ModuloSemana>, Exception> action);
        void ModuloSemanaGetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId, Action<List<ModuloSemana>, Exception> action);
        void ModuloSemanaGetByFechaModulo(DateTime fechaInicio, int moduloId, Action<List<ModuloSemana>, Exception> action);

        #endregion

        #region ModuloSemanaOperario

        void ModuloSemanaOperarioUpdate(ModuloSemanaOperario moduloSemanaOperario,
            Action<ModuloSemanaOperario, Exception> action);
        void ModuloSemanaOperarioDelete(int moduloSemanaOperarioId, Action<Exception> action);
        void ModuloSemanaOperarioGet(int moduloSemanaOperarioId, Action<ModuloSemanaOperario, Exception> action);
        void ModuloSemanaOperarioGetByModuloSemana(int moduloSemanaId,
            Action<List<ModuloSemanaOperario>, Exception> action);

        #endregion

        #region Turno

        void TurnoUpdate(Turno turno, Action<Turno, Exception> action);
        void TurnoDelete(int turnoId, Action<Exception> action);
        void TurnoGet(int turnoId, Action<Turno, Exception> action);
        void TurnoGetAll(Action<List<Turno>, Exception> action);

        #endregion

        #region TurnoDetalle

        void TurnoDetalleUpdate(TurnoDetalle turnoDetalle, Action<TurnoDetalle, Exception> action);
        void TurnoDetalleDelete(int turnoDetalleId, Action<Exception> action);
        void TurnoDetalleGet(int turnoDetalleId, Action<TurnoDetalle, Exception> action);
        void TurnoDetalleGetByTurno(int turnoId, Action<List<TurnoDetalle>, Exception> action);

        #endregion
    }
}