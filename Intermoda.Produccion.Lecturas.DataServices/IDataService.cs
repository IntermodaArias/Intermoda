using System;
using System.ServiceModel;
using lv = Intermoda.Produccion.Lecturas.Business.Lavanderia;
using Intermoda.Produccion.Lecturas.Business.Lecturas;

namespace Intermoda.Produccion.Lecturas.DataServices
{
    [ServiceContract]
    public interface IDataService
    {
        #region Lavandería

        #region CentroTrabajo

        [OperationContract]
        lv.CentroTrabajoBusiness LavanderiaCentroTrabajoUpdate(lv.CentroTrabajoBusiness centroTrabajo);

        [OperationContract]
        void LavanderiaCentroTrabajoDelete(int centroTrabajoId);

        [OperationContract]
        lv.CentroTrabajoBusiness LavanderiaCentroTrabajoGet(int centroTrabajoId);

        [OperationContract]
        lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetAll();

        [OperationContract]
        lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetActivos();

        [OperationContract]
        lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetByOperacion(int operacionId);

        [OperationContract]
        lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetAllLavanderia();

        #endregion

        #region Proceso

        [OperationContract]
        lv.ProcesoBusiness LavanderiaProcesoUpdate(lv.ProcesoBusiness proceso);

        [OperationContract]
        void LavanderiaProcesoDelete(int procesoId);

        [OperationContract]
        lv.ProcesoBusiness LavanderiaProcesoGet(int procesoId);

        [OperationContract]
        lv.ProcesoBusiness[] LavanderiaProcesoGetAll();

        [OperationContract]
        lv.ProcesoBusiness[] LavanderiaProcesoGetByCentroTrabajo(int centroTrabajoId);

        #endregion

        #region Operacion

        [OperationContract]
        lv.OperacionBusiness LavanderiaOperacionUpdate(lv.OperacionBusiness operacion);

        [OperationContract]
        void LavanderiaOperacionDelete(int operacionId);

        [OperationContract]
        lv.OperacionBusiness LavanderiaOperacionGet(int operacionId);

        [OperationContract]
        lv.OperacionBusiness[] LavanderiaOperacionGetAll();

        [OperationContract]
        lv.OperacionBusiness[] LavanderiaOperacionGetAllLavanderia();

        [OperationContract]
        lv.OperacionBusiness[] LavanderiaOperacionGetHumedas(int centroTrabajoId);

        #endregion

        #region OperacionCentroTrabajo

        [OperationContract]
        lv.OperacionCentroTrabajoBusiness LavanderiaOperacionCentroTrabajoUpdate(
            lv.OperacionCentroTrabajoBusiness operacionCentroTrabajo);

        [OperationContract]
        void LavanderiaOperacionCentroTrabajoDelete(int operacionCentroTrabajoId);

        [OperationContract]
        lv.OperacionCentroTrabajoBusiness LavanderiaOperacionCentroTrabajoGet(int operacionCentroTrabajoId);

        [OperationContract]
        lv.OperacionCentroTrabajoBusiness[] LavanderiaOperacionCentroTrabajoGetAll();

        [OperationContract]
        lv.OperacionCentroTrabajoBusiness[] LavanderiaOperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoCodigo);

        [OperationContract]
        lv.OperacionCentroTrabajoBusiness[] LavanderiaOperacionCentroTrabajoGetByOperacion(short operacionCodigo);


        #endregion

        #endregion

        #region Lecturas

        #region CentroTrabajo

        [OperationContract]
        CentroTrabajoBusiness CentroTrabajoUpdate(CentroTrabajoBusiness centroTrabajo);

        [OperationContract]
        void CentroTrabajoDelete(int centroTrabajoId);

        [OperationContract]
        CentroTrabajoBusiness CentroTrabajoGet(int centroTrabajoId);

        [OperationContract]
        CentroTrabajoBusiness[] CentroTrabajoGetAll();

        [OperationContract]
        CentroTrabajoBusiness[] CentroTrabajoGetActivos();

        #endregion

        #region CentroTrabajoClasificacion

        [OperationContract]
        CentroTrabajoClasificacionBusiness CentroTrabajoClasificacionUpdate(CentroTrabajoClasificacionBusiness centroTrabajoClasificacion);

        [OperationContract]
        void CentroTrabajoClasificacionDelete(int centroTrabajoClasificacionId);

        [OperationContract]
        CentroTrabajoClasificacionBusiness CentroTrabajoClasificacionGet(int centroTrabajoClasificacionId);

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetAll();

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetAllActivos();

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetByCentroTrabajo(int centroTrabajoId);

        [OperationContract]
        CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetByCentroTrabajoActivos(int centroTrabajoId);

        #endregion

        #region Grupo

        [OperationContract]
        GrupoBusiness GrupoUpdate(GrupoBusiness grupoBusiness);

        [OperationContract]
        void GrupoDelete(int grupoId);

        [OperationContract]
        GrupoBusiness GrupoGet(int grupoId);

        [OperationContract]
        GrupoBusiness[] GrupoGetAll();

        [OperationContract]
        GrupoBusiness[] GrupoGetAllActivos();

        [OperationContract]
        GrupoBusiness GrupoGetByLinea(int lineaId);

        [OperationContract]
        void GrupoCopiarSemana(DateTime desde, DateTime hasta);

        [OperationContract]
        bool GrupoHayDataSemana(DateTime fecha);

        #endregion

        #region Jornada

        [OperationContract]
        JornadaBusiness JornadaUpdate(JornadaBusiness jornada);

        [OperationContract]
        void JornadaDelete(int jornadaId);

        [OperationContract]
        JornadaBusiness JornadaGet(int jornadaId);

        [OperationContract]
        JornadaBusiness[] JornadaGetAll();

        #endregion

        #region JornadaDetalle

        [OperationContract]
        JornadaDetalleBusiness JornadaDetalleUpdate(JornadaDetalleBusiness jornadaDetalle);

        [OperationContract]
        void JornadaDetalleDelete(int jornadaDetalleId);

        [OperationContract]
        JornadaDetalleBusiness JornadaDetalleGet(int jornadaDetalleId);

        [OperationContract]
        JornadaDetalleBusiness[] JornadaDetalleGetAll();

        [OperationContract]
        JornadaDetalleBusiness[] JornadaDetalleGetByJornada(int jornadaId);

        #endregion

        #region Linea

        [OperationContract]
        LineaBusiness LineaUpdate(LineaBusiness linea);

        [OperationContract]
        void LineaDelete(int lineaId);

        [OperationContract]
        LineaBusiness LineaGet(int lineaId);

        [OperationContract]
        LineaBusiness[] LineaGetAll();

        [OperationContract]
        LineaBusiness[] LineaGetAllActivas();

        [OperationContract]
        LineaBusiness[] LineaGetByGrupo(int grupoId);

        [OperationContract]
        LineaBusiness[] LineaGetByGrupoActivas(int grupoId);

        #endregion

        #region LineaDetalle

        [OperationContract]
        LineaDetalleBusiness LineaDetalleUpdate(LineaDetalleBusiness lineaDetalle);

        [OperationContract]
        void LineaDetalleDelete(int lineaDetalle);

        [OperationContract]
        LineaDetalleBusiness[] LineaDetalleGetAll();

        [OperationContract]
        LineaDetalleBusiness[] LineaDetalleGetByLinea(int lineaId);

        [OperationContract]
        LineaDetalleBusiness[] LineaDetalleGetByLineaModulo(int lineaId, int moduloId);

        #endregion

        #region Modulo

        [OperationContract]
        ModuloBusiness ModuloUpdate(ModuloBusiness modulo);

        [OperationContract]
        void ModuloDelete(int moduloId);

        [OperationContract]
        ModuloBusiness ModuloGet(int moduloId);

        [OperationContract]
        ModuloBusiness[] ModuloGetAll();

        [OperationContract]
        ModuloBusiness[] ModuloGetAllActivos();

        [OperationContract]
        ModuloBusiness[] ModuloGetByCentroTrabajo(int centroTrabajoId);

        [OperationContract]
        ModuloBusiness[] ModuloGetByCentroTrabajoActivos(int centroTrabajoId);

        #endregion

        #region ModuloSemana

        [OperationContract]
        ModuloSemanaBusiness ModuloSemanaUpdate(ModuloSemanaBusiness moduloSemana);

        [OperationContract]
        void ModuloSemanaDelete(int moduloSemanaId);

        [OperationContract]
        ModuloSemanaBusiness ModuloSemanaGet(int moduloSemanaId);

        [OperationContract]
        ModuloSemanaBusiness[] ModuloSemanaGetAll();

        [OperationContract]
        ModuloSemanaBusiness[] ModuloSemanaGetByFecha(DateTime fechaInicio);

        [OperationContract]
        ModuloSemanaBusiness[] ModuloSemanaGetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId);

        [OperationContract]
        ModuloSemanaBusiness[] ModuloSemanaGetByFechaModulo(DateTime fechaInicio, int moduloId);

        #endregion

        #region ModuloSemanaOperario

        [OperationContract]
        ModuloSemanaOperarioBusiness ModuloSemanaOperarioUpdate(ModuloSemanaOperarioBusiness moduloSemanaOperario);

        [OperationContract]
        void ModuloSemanaOperarioDelete(int moduloSemanaOperarioId);

        [OperationContract]
        ModuloSemanaOperarioBusiness ModuloSemanaOperarioGet(int moduloSemanaOperarioId);

        [OperationContract]
        ModuloSemanaOperarioBusiness[] ModuloSemanaOperarioGetAll();

        [OperationContract]
        ModuloSemanaOperarioBusiness[] ModuloSemanaOperarioGetByModuloSemana(int moduloSemanaId);

        #endregion

        #region Turno

        [OperationContract]
        TurnoBusiness TurnoUpdate(TurnoBusiness turno);

        [OperationContract]
        void TurnoDelete(int turnoId);

        [OperationContract]
        TurnoBusiness TurnoGet(int turnoId);

        [OperationContract]
        TurnoBusiness[] TurnoGetAll();

        #endregion

        #region TurnoDetalle

        [OperationContract]
        TurnoDetalleBusiness TurnoDetalleUpdate(TurnoDetalleBusiness turnoDetalle);

        [OperationContract]
        void TurnoDetalleDelete(int turnoDetalleId);

        [OperationContract]
        TurnoDetalleBusiness TurnoDetalleGet(int turnoDetalleId);

        [OperationContract]
        TurnoDetalleBusiness[] TurnoDetalleGetAll();

        [OperationContract]
        TurnoDetalleBusiness[] TurnoDetalleGetByTurno(int turnoId);

        #endregion

        #endregion

    }
}
