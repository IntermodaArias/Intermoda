using System;
using lb = Intermoda.Produccion.Lecturas.Business.LbDatPro;
using lv = Intermoda.Produccion.Lecturas.Business.Lavanderia;
using Intermoda.Produccion.Lecturas.Business.Lecturas;

namespace Intermoda.Produccion.Lecturas.DataServices
{
    public class DataService : IDataService
    {
        #region Lavandería

        #region CentroTrabajo

        public lv.CentroTrabajoBusiness LavanderiaCentroTrabajoUpdate(lv.CentroTrabajoBusiness centroTrabajo)
        {
            try
            {
                return centroTrabajo.Codigo == 0
                    ? lv.CentroTrabajoBusiness.Insert(centroTrabajo)
                    : lv.CentroTrabajoBusiness.Update(centroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoUpdate", exception);
            }
        }

        public void LavanderiaCentroTrabajoDelete(int centroTrabajoId)
        {
            try
            {
                lv.CentroTrabajoBusiness.Delete(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoDelete", exception);
            }
        }

        public lv.CentroTrabajoBusiness LavanderiaCentroTrabajoGet(int centroTrabajoId)
        {
            try
            {
                return lv.CentroTrabajoBusiness.Get(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoGet", exception);
            }
        }

        public lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetAll()
        {
            try
            {
                return lv.CentroTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoGetAll", exception);
            }
        }

        public lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetActivos()
        {
            try
            {
                return lv.CentroTrabajoBusiness.GetActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoGetActivos", exception);
            }
        }

        public lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetByOperacion(int operacionId)
        {
            try
            {
                return lv.CentroTrabajoBusiness.GetByOperacion(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoGetByOperacion", exception);
            }
        }

        public lv.CentroTrabajoBusiness[] LavanderiaCentroTrabajoGetAllLavanderia()
        {
            try
            {
                return lv.CentroTrabajoBusiness.GetAllLavanderia();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaCentroTrabajoGetAllLavanderia", exception);
            }
        }

        #endregion

        #region Proceso

        public lv.ProcesoBusiness LavanderiaProcesoUpdate(lv.ProcesoBusiness proceso)
        {
            try
            {
                return proceso.Id == 0
                    ? lv.ProcesoBusiness.Insert(proceso)
                    : lv.ProcesoBusiness.Update(proceso);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaProcesoUpdate", exception);
            }
        }

        public void LavanderiaProcesoDelete(int procesoId)
        {
            try
            {
                lv.ProcesoBusiness.Delete(procesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaProcesoDelete", exception);
            }
        }

        public lv.ProcesoBusiness LavanderiaProcesoGet(int procesoId)
        {
            try
            {
                return lv.ProcesoBusiness.Get(procesoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaProcesoGet", exception);
            }
        }

        public lv.ProcesoBusiness[] LavanderiaProcesoGetAll()
        {
            try
            {
                return lv.ProcesoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaProcesoGetAll", exception);
            }
        }

        public lv.ProcesoBusiness[] LavanderiaProcesoGetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return lv.ProcesoBusiness.GetbyCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaProcesoGetByCentroTrabajo", exception);
            }
        }

        #endregion

        #region Operacion

        public lv.OperacionBusiness LavanderiaOperacionUpdate(lv.OperacionBusiness operacion)
        {
            try
            {
                return operacion.Id == 0
                    ? lv.OperacionBusiness.Insert(operacion)
                    : lv.OperacionBusiness.Update(operacion);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionUpdate", exception);
            }
        }

        public void LavanderiaOperacionDelete(int operacionId)
        {
            try
            {
                lv.OperacionBusiness.Delete(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionDelete", exception);
            }
        }

        public lv.OperacionBusiness LavanderiaOperacionGet(int operacionId)
        {
            try
            {
                return lv.OperacionBusiness.Get(operacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionGet", exception);
            }
        }

        public lv.OperacionBusiness[] LavanderiaOperacionGetAll()
        {
            try
            {
                return lv.OperacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionGetAll", exception);
            }
        }

        public lv.OperacionBusiness[] LavanderiaOperacionGetAllLavanderia()
        {
            try
            {
                return lv.OperacionBusiness.GetAllLavanderia();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionGetAllLavanderia", exception);
            }
        }

        public lv.OperacionBusiness[] LavanderiaOperacionGetHumedas(int centroTrabajoId)
        {
            try
            {
                return lv.OperacionBusiness.GetOperacionesHumedas(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionGetHumedas", exception);
            }
        }

        #endregion

        #region OperacionCentroTrabajo

        public lv.OperacionCentroTrabajoBusiness LavanderiaOperacionCentroTrabajoUpdate(
            lv.OperacionCentroTrabajoBusiness operacionCentroTrabajo)
        {
            try
            {
                return operacionCentroTrabajo.Id == 0
                    ? lv.OperacionCentroTrabajoBusiness.Insert(operacionCentroTrabajo)
                    : lv.OperacionCentroTrabajoBusiness.Update(operacionCentroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionCentroTrabajoUpdate", exception);
            }
        }

        public void LavanderiaOperacionCentroTrabajoDelete(int operacionCentroTrabajoId)
        {
            try
            {
                lv.OperacionCentroTrabajoBusiness.Delete(operacionCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionCentroTrabajoDelete", exception);
            }
        }

        public lv.OperacionCentroTrabajoBusiness LavanderiaOperacionCentroTrabajoGet(int operacionCentroTrabajoId)
        {
            try
            {
                return lv.OperacionCentroTrabajoBusiness.Get(operacionCentroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionCentroTrabajoGet", exception);
            }
        }

        public lv.OperacionCentroTrabajoBusiness[] LavanderiaOperacionCentroTrabajoGetAll()
        {
            try
            {
                return lv.OperacionCentroTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionCentroTrabajoGetAll", exception);
            }
        }

        public lv.OperacionCentroTrabajoBusiness[] LavanderiaOperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoCodigo)
        {
            try
            {
                return lv.OperacionCentroTrabajoBusiness.GetByCentroTrabajo(centroTrabajoCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionCentroTrabajoGetByCentroTrabajo", exception);
            }
        }

        public lv.OperacionCentroTrabajoBusiness[] LavanderiaOperacionCentroTrabajoGetByOperacion(short operacionCodigo)
        {
            try
            {
                return lv.OperacionCentroTrabajoBusiness.GetByOperacion(operacionCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService / LavanderiaOperacionCentroTrabajoGetByOperacion", exception);
            }
        }

        #endregion

        #endregion

        #region LbDatPro

        #region Empleado

        public lb.EmpleadoBusiness EmpleadoGet(short companiaCodigo, int empleadoId)
        {
            try
            {
                return lb.EmpleadoBusiness.Get(companiaCodigo, empleadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.EmpleadoGet", exception);
            }
        }

        public lb.EmpleadoBusiness[] EmpleadoGetAllActivos()
        {
            try
            {
                var lista = lb.EmpleadoBusiness.GetAllActivos();
                return lista;
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.EmpleadoGetAllActivos", exception);
            }
        }

        #endregion

        #region Inasistencia

        public lb.InasistenciaBusiness[] InasistenciaGetByFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            try
            {
                if (fechaInicial == fechaFinal)
                {
                    return lb.InasistenciaBusiness.GetByFecha(fechaInicial);
                }

                return lb.InasistenciaBusiness.GetByFecha(fechaInicial, fechaFinal);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.InasistenciaGetByFecha", exception);
            }
        }

        public lb.InasistenciaBusiness[] InasistenciaGetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo, DateTime fechaInicial,
            DateTime fechaFinal)
        {
            try
            {
                if (fechaInicial == fechaFinal)
                {
                    return lb.InasistenciaBusiness.GetByEmpleadoFecha(companiaCodigo, empleadoCodigo, fechaInicial);
                }

                return lb.InasistenciaBusiness.GetByEmpleadoFecha(companiaCodigo, empleadoCodigo, fechaInicial, fechaFinal);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.InasistenciaGetByEmpleadoFecha", exception);
            }
        }

        #endregion

        #endregion

        #region CentroTrabajo

        public CentroTrabajoBusiness CentroTrabajoUpdate(CentroTrabajoBusiness centroTrabajo)
        {
            try
            {
                return centroTrabajo.Id == 0
                    ? CentroTrabajoBusiness.Insert(centroTrabajo)
                    : CentroTrabajoBusiness.Update(centroTrabajo);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoUpdate", exception);
            }
        }

        public void CentroTrabajoDelete(int centroTrabajoId)
        {
            try
            {
                CentroTrabajoBusiness.Delete(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoDelete", exception);
            }
        }

        public CentroTrabajoBusiness CentroTrabajoGet(int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoBusiness.Get(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoGet", exception);
            }
        }

        public CentroTrabajoBusiness[] CentroTrabajoGetAll()
        {
            try
            {
                return CentroTrabajoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoGetAll", exception);
            }
        }

        public CentroTrabajoBusiness[] CentroTrabajoGetActivos()
        {
            try
            {
                return CentroTrabajoBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoGetActivos", exception);
            }
        }

        #endregion

        #region CentroTrabajoClasificacion

        public CentroTrabajoClasificacionBusiness CentroTrabajoClasificacionUpdate(
            CentroTrabajoClasificacionBusiness centroTrabajoClasificacion)
        {
            try
            {
                return centroTrabajoClasificacion.Id == 0
                    ? CentroTrabajoClasificacionBusiness.Insert(centroTrabajoClasificacion)
                    : CentroTrabajoClasificacionBusiness.Update(centroTrabajoClasificacion);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionUpdate", exception);
            }
        }

        public void CentroTrabajoClasificacionDelete(int centroTrabajoClasificacionId)
        {
            try
            {
                CentroTrabajoClasificacionBusiness.Delete(centroTrabajoClasificacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionDelete", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness CentroTrabajoClasificacionGet(int centroTrabajoClasificacionId)
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.Get(centroTrabajoClasificacionId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionGet", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetAll()
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionGetAll", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetAllActivos()
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionGetAllActivos", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetByCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionGetByCentroTrabajo", exception);
            }
        }

        public CentroTrabajoClasificacionBusiness[] CentroTrabajoClasificacionGetByCentroTrabajoActivos(
            int centroTrabajoId)
        {
            try
            {
                return CentroTrabajoClasificacionBusiness.GetByCentroTrabajoActivos(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.CentroTrabajoClasificacionGetByCentroTrabajoActivos", exception);
            }
        }

        #endregion

        #region Grupo

        public GrupoBusiness GrupoUpdate(GrupoBusiness grupoBusiness)
        {
            try
            {
                return grupoBusiness.Id == 0
                    ? GrupoBusiness.Insert(grupoBusiness)
                    : GrupoBusiness.Update(grupoBusiness);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoUpdate", exception);
            }
        }

        public void GrupoDelete(int grupoId)
        {
            try
            {
                GrupoBusiness.Delete(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoDelete", exception);
            }
        }

        public GrupoBusiness GrupoGet(int grupoId)
        {
            try
            {
                return GrupoBusiness.Get(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoGet", exception);
            }
        }

        public GrupoBusiness[] GrupoGetAll()
        {
            try
            {
                return GrupoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoGetAll", exception);
            }
        }

        public GrupoBusiness[] GrupoGetAllActivos()
        {
            try
            {
                return GrupoBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoGetAllActivos", exception);
            }
        }

        public GrupoBusiness GrupoGetByLinea(int lineaId)
        {
            try
            {
                return GrupoBusiness.GetByLinea(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoGetByLinea", exception);
            }
        }

        public void GrupoCopiarSemana(DateTime desde, DateTime hasta)
        {
            try
            {
                GrupoBusiness.CopiarSemana(desde, hasta);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoCopiarSemana", exception);
            }
        }

        public bool GrupoHayDataSemana(DateTime fecha)
        {
            try
            {
                return GrupoBusiness.HayDataSemana(fecha);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.GrupoHayDataSemana", exception);
            }
        }

        #endregion

        #region Jornada

        public JornadaBusiness JornadaUpdate(JornadaBusiness jornada)
        {
            try
            {
                return jornada.Id == 0
                    ? JornadaBusiness.Insert(jornada)
                    : JornadaBusiness.Update(jornada);
            }
            catch (Exception exception)
            {
                
                throw new Exception("DataService.JornadaUpdate", exception);
            }
        }

        public void JornadaDelete(int jornadaId)
        {
            try
            {
                JornadaBusiness.Delete(jornadaId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaDelete", exception);
            }
        }

        public JornadaBusiness JornadaGet(int jornadaId)
        {
            try
            {
                return JornadaBusiness.Get(jornadaId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaGet", exception);
            }
        }

        public JornadaBusiness[] JornadaGetAll()
        {
            try
            {
                return JornadaBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaGetAll", exception);
            }
        }

        #endregion

        #region JornadaDetalle

        public JornadaDetalleBusiness JornadaDetalleUpdate(JornadaDetalleBusiness jornadaDetalle)
        {
            try
            {
                return jornadaDetalle.Id == 0
                    ? JornadaDetalleBusiness.Insert(jornadaDetalle)
                    : JornadaDetalleBusiness.Update(jornadaDetalle);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaDetalleUpdate", exception);
            }
        }

        public void JornadaDetalleDelete(int jornadaDetalleId)
        {
            try
            {
                JornadaDetalleBusiness.Delete(jornadaDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaDetalleDelete", exception);
            }
        }

        public JornadaDetalleBusiness JornadaDetalleGet(int jornadaDetalleId)
        {
            try
            {
                return JornadaDetalleBusiness.Get(jornadaDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaDetalleGet", exception);
            }
        }

        public JornadaDetalleBusiness[] JornadaDetalleGetAll()
        {
            try
            {
                return JornadaDetalleBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaDetalleGetAll", exception);
            }
        }

        public JornadaDetalleBusiness[] JornadaDetalleGetByJornada(int jornadaId)
        {
            try
            {
                return JornadaDetalleBusiness.GetbyJornada(jornadaId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.JornadaDetalleGetByJornada", exception);
            }
        }

        #endregion

        #region Linea

        public LineaBusiness LineaUpdate(LineaBusiness linea)
        {
            try
            {
                return linea.Id == 0
                    ? LineaBusiness.Insert(linea)
                    : LineaBusiness.Update(linea);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaUpdate", exception);
            }
        }

        public void LineaDelete(int lineaId)
        {
            try
            {
                LineaBusiness.Delete(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaDelete", exception);
            }
        }

        public LineaBusiness LineaGet(int lineaId)
        {
            try
            {
                return LineaBusiness.Get(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaGet", exception);
            }
        }

        public LineaBusiness[] LineaGetAll()
        {
            try
            {
                return LineaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaGetAll", exception);
            }
        }

        public LineaBusiness[] LineaGetAllActivas()
        {
            try
            {
                return LineaBusiness.GetAllActivas();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaGetAllActivas", exception);
            }
        }

        public LineaBusiness[] LineaGetByGrupo(int grupoId)
        {
            try
            {
                return LineaBusiness.GetByGrupo(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaGetByGrupo", exception);
            }
        }

        public LineaBusiness[] LineaGetByGrupoActivas(int grupoId)
        {
            try
            {
                return LineaBusiness.GetByGrupoActivas(grupoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaGetByGrupoActivas", exception);
            }
        }

        #endregion

        #region LineaDetalle

        public LineaDetalleBusiness LineaDetalleUpdate(LineaDetalleBusiness lineaDetalle)
        {
            try
            {
                return lineaDetalle.Id == 0
                    ? LineaDetalleBusiness.Insert(lineaDetalle)
                    : LineaDetalleBusiness.Update(lineaDetalle);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaDetalleUpdate", exception);
            }
        }

        public void LineaDetalleDelete(int lineaDetalleId)
        {
            try
            {
                LineaDetalleBusiness.Delete(lineaDetalleId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaDetalleDelete", exception);
            }
        }

        public LineaDetalleBusiness[] LineaDetalleGetAll()
        {
            try
            {
                return LineaDetalleBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaDetalleGetAll", exception);
            }
        }

        public LineaDetalleBusiness[] LineaDetalleGetByLinea(int lineaId)
        {
            try
            {
                return LineaDetalleBusiness.GetByLinea(lineaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaDetalleGetByLinea", exception);
            }
        }

        public LineaDetalleBusiness[] LineaDetalleGetByLineaModulo(int lineaId, int moduloId)
        {
            try
            {
                return LineaDetalleBusiness.GetByLineaModulo(lineaId, moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.LineaDetalleGetByLineaModulo", exception);
            }
        }

        #endregion

        #region Modulo

        public ModuloBusiness ModuloUpdate(ModuloBusiness modulo)
        {
            try
            {
                return modulo.Id == 0
                    ? ModuloBusiness.Insert(modulo)
                    : ModuloBusiness.Update(modulo);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloUpdate", exception);
            }
        }

        public void ModuloDelete(int moduloId)
        {
            try
            {
                ModuloBusiness.Delete(moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloDelete", exception);
            }
        }

        public ModuloBusiness ModuloGet(int moduloId)
        {
            try
            {
                return ModuloBusiness.Get(moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloGet", exception);
            }
        }

        public ModuloBusiness[] ModuloGetAll()
        {
            try
            {
                return ModuloBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloGetAll", exception);
            }
        }

        public ModuloBusiness[] ModuloGetAllActivos()
        {
            try
            {
                return ModuloBusiness.GetAllActivos();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloGetAllActivos", exception);
            }
        }

        public ModuloBusiness[] ModuloGetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                return ModuloBusiness.GetByCentroTrabajo(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModulosGetByCentroTrabajo", exception);
            }
        }

        public ModuloBusiness[] ModuloGetByCentroTrabajoActivos(int centroTrabajoId)
        {
            try
            {
                return ModuloBusiness.GetByCentroTrabajoActivos(centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloGetByCentroTrabajoActivos", exception);
            }
        }

        #endregion

        #region ModuloSemana

        public ModuloSemanaBusiness ModuloSemanaUpdate(ModuloSemanaBusiness moduloSemana)
        {
            try
            {
                return moduloSemana.Id == 0
                    ? ModuloSemanaBusiness.Insert(moduloSemana)
                    : ModuloSemanaBusiness.Update(moduloSemana);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaUpdate", exception);
            }
        }

        public void ModuloSemanaDelete(int moduloSemanaId)
        {
            try
            {
                ModuloSemanaBusiness.Delete(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaDelete", exception);
            }
        }

        public ModuloSemanaBusiness ModuloSemanaGet(int moduloSemanaId)
        {
            try
            {
                return ModuloSemanaBusiness.Get(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaGet", exception);
            }
        }

        public ModuloSemanaBusiness[] ModuloSemanaGetAll()
        {
            try
            {
                return ModuloSemanaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaGetAll", exception);
            }
        }

        public ModuloSemanaBusiness[] ModuloSemanaGetByFecha(DateTime fechaInicio)
        {
            try
            {
                return ModuloSemanaBusiness.GetByFecha(fechaInicio);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaGetByFecha", exception);
            }
        }

        public ModuloSemanaBusiness[] ModuloSemanaGetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId)
        {
            try
            {
                return ModuloSemanaBusiness.GetbyFechaCentroTrabajo(fechaInicio, centroTrabajoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaGetByFechaCentroTrabajo", exception);
            }
        }

        public ModuloSemanaBusiness[] ModuloSemanaGetByFechaModulo(DateTime fechaInicio, int moduloId)
        {
            try
            {
                return ModuloSemanaBusiness.GetbyFechaModulo(fechaInicio, moduloId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaGetByFechaModulo", exception);
            }
        }

        #endregion

        #region ModuloSemanaOperario

        public ModuloSemanaOperarioBusiness ModuloSemanaOperarioUpdate(ModuloSemanaOperarioBusiness moduloSemanaOperario)
        {
            try
            {
                return moduloSemanaOperario.Id == 0
                    ? ModuloSemanaOperarioBusiness.Insert(moduloSemanaOperario)
                    : ModuloSemanaOperarioBusiness.Update(moduloSemanaOperario);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaOperarioUpdate", exception);
            }
        }

        public void ModuloSemanaOperarioDelete(int moduloSemanaOperarioId)
        {
            try
            {
                ModuloSemanaOperarioBusiness.Delete(moduloSemanaOperarioId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaOperarioDelete", exception);
            }
        }

        public ModuloSemanaOperarioBusiness ModuloSemanaOperarioGet(int moduloSemanaOperarioId)
        {
            try
            {
                return ModuloSemanaOperarioBusiness.Get(moduloSemanaOperarioId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaOperarioGet", exception);
            }
        }

        public ModuloSemanaOperarioBusiness[] ModuloSemanaOperarioGetAll()
        {
            try
            {
                return ModuloSemanaOperarioBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaOperarioGetAll", exception);
            }
        }

        public ModuloSemanaOperarioBusiness[] ModuloSemanaOperarioGetByModuloSemana(int moduloSemanaId)
        {
            try
            {
                return ModuloSemanaOperarioBusiness.GetByModuloSemana(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.ModuloSemanaOperarioGetByModuloSemana", exception);
            }
        }

        #endregion

        #region Turno

        public TurnoBusiness TurnoUpdate(TurnoBusiness turno)
        {
            try
            {
                return turno.Id == 0
                    ? TurnoBusiness.Insert(turno)
                    : TurnoBusiness.Update(turno);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoUpdate", exception);
            }
        }

        public void TurnoDelete(int turnoId)
        {
            try
            {
                TurnoBusiness.Delete(turnoId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoDelete", exception);
            }
        }

        public TurnoBusiness TurnoGet(int turnoId)
        {
            try
            {
                return TurnoBusiness.Get(turnoId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoGet", exception);
            }
        }

        public TurnoBusiness[] TurnoGetAll()
        {
            try
            {
                return TurnoBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoGetAll", exception);
            }
        }

        #endregion

        #region TurnoDetalle

        public TurnoDetalleBusiness TurnoDetalleUpdate(TurnoDetalleBusiness turnoDetalle)
        {
            try
            {
                return turnoDetalle.Id == 0
                    ? TurnoDetalleBusiness.Insert(turnoDetalle)
                    : TurnoDetalleBusiness.Update(turnoDetalle);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoDetalleUpdate", exception);
            }
        }

        public void TurnoDetalleDelete(int turnoDetalleId)
        {
            try
            {
                TurnoDetalleBusiness.Delete(turnoDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoDetalleDelete", exception);
            }
        }

        public TurnoDetalleBusiness TurnoDetalleGet(int turnoDetalleId)
        {
            try
            {
                return TurnoDetalleBusiness.Get(turnoDetalleId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoDetalleGet", exception);
            }
        }

        public TurnoDetalleBusiness[] TurnoDetalleGetAll()
        {
            try
            {
                return TurnoDetalleBusiness.GetAll();
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoDetalleGetAll", exception);
            }
        }

        public TurnoDetalleBusiness[] TurnoDetalleGetByTurno(int turnoId)
        {
            try
            {
                return TurnoDetalleBusiness.GetByTurno(turnoId);
            }
            catch (Exception exception)
            {

                throw new Exception("DataService.TurnoDetalleGetByTurno", exception);
            }
        }

        #endregion
    }
}
