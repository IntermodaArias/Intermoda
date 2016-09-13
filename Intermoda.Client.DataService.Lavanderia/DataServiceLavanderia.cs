using System;
using System.Collections.Generic;
using Intermoda.Client.Lavanderia;
using Intermoda.Common.Enum;

namespace Intermoda.Client.DataService.Lavanderia
{
    public class DataServiceLavanderia : IDataServiceLavanderia
    {
        #region ArchivoGlobal

        public async void ArchivoGlobalUpdate(ArchivoGlobal archivoGlobal, Action<ArchivoGlobal, Exception> action)
        {
            try
            {
                var reg = await ArchivoGlobal.Update(archivoGlobal);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ArchivoGlobalDelete(int archivoGlobalId, Action<Exception> action)
        {
            try
            {
                await ArchivoGlobal.Delete(archivoGlobalId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ArchivoGlobalGet(int archivoGlobalId, Action<ArchivoGlobal, Exception> action)
        {
            try
            {
                var reg = await ArchivoGlobal.Get(archivoGlobalId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ArchivoGlobalGetAll(Action<List<ArchivoGlobal>, Exception> action)
        {
            try
            {
                var lista = await ArchivoGlobal.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ArchivoGlobalGetByPropietario(int propietarioId, Action<ArchivoGlobal, Exception> action)
        {
            try
            {
                var reg = await ArchivoGlobal.GetByPropietario(propietarioId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Catalogo

        public async void CatalogoUpdate(Catalogo catalogo, Action<Catalogo, Exception> action)
        {
            try
            {
                var reg = await Catalogo.Update(catalogo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CatalogoDelete(int ingredienteId, Action<Exception> action)
        {
            try
            {
                await Catalogo.Delete(ingredienteId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void CatalogoGet(int ingredienteId, Action<Catalogo, Exception> action)
        {
            try
            {
                var reg = await Catalogo.Get(ingredienteId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CatalogoGetAll(Action<List<Catalogo>, Exception> action)
        {
            try
            {
                var lista = await Catalogo.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CatalogoGetByTela(string telaId, Action<Catalogo, Exception> action)
        {
            try
            {
                var reg = await Catalogo.GetByTela(telaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region CentroTrabajo

        public async void CentroTrabajoUpdate(CentroTrabajo centroTrabajo,
            Action<CentroTrabajo, Exception> action)
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

        public async void CentroTrabajoGetByOperacion(int operacionId, Action<List<CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajo.GetByOperacion(operacionId);

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoGetAllLavanderia(Action<List<CentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajo.GetAllLavanderia();

                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region CentroTrabajoOpcion

        public async void CentroTrabajoOpcionUpdate(CentroTrabajoOpcion centroTrabajoOpcion,
            Action<CentroTrabajoOpcion, Exception> action)
        {
            try
            {
                var reg = await CentroTrabajoOpcion.Update(centroTrabajoOpcion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoOpcionDelete(int centroTrabajoOpcionId, Action<Exception> action)
        {
            try
            {
                await CentroTrabajoOpcion.Delete(centroTrabajoOpcionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void CentroTrabajoOpcionGet(int centroTrabajoOpcionId, Action<CentroTrabajoOpcion, Exception> action)
        {
            try
            {
                var reg = await CentroTrabajoOpcion.Get(centroTrabajoOpcionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoOpcionGetAll(Action<List<CentroTrabajoOpcion>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajoOpcion.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoOpcionGetByCentroTrabajo(int centroTrabajoId,
            Action<List<CentroTrabajoOpcion>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajoOpcion.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void CentroTrabajoOpcionGetByOpcion(int opcionLavadoId,
            Action<List<CentroTrabajoOpcion>, Exception> action)
        {
            try
            {
                var lista = await CentroTrabajoOpcion.GetByOpcion(opcionLavadoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Clase

        public async void ClaseUpdate(Clase clase, Action<Clase, Exception> action)
        {
            try
            {
                var reg = await Clase.Update(clase);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ClaseDelete(string claseCodigo, Action<Exception> action)
        {
            try
            {
                await Clase.Delete(claseCodigo);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ClaseGet(string claseCodigo, Action<Clase, Exception> action)
        {
            try
            {
                var reg = await Clase.Get(claseCodigo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ClaseGetAll(Action<List<Clase>, Exception> action)
        {
            try
            {
                var lista = await Clase.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region ColorIntermoda

        public async void ColorIntermodaUpdate(ColorIntermoda colorIntermoda, Action<ColorIntermoda, Exception> action)
        {
            try
            {
                var reg = await ColorIntermoda.Update(colorIntermoda);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ColorIntermodaDelete(int colorIntermodaId, Action<Exception> action)
        {
            try
            {
                await ColorIntermoda.Delete(colorIntermodaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ColorIntermodaGet(int colorIntermodaId, Action<ColorIntermoda, Exception> action)
        {
            try
            {
                var reg = await ColorIntermoda.Get(colorIntermodaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ColorIntermodaGetAll(Action<List<ColorIntermoda>, Exception> action)
        {
            try
            {
                var lista = await ColorIntermoda.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region IngredienteOperacion

        public async void IngredienteOperacionUpdate(IngredienteOperacion ingredienteOperacion,
            Action<IngredienteOperacion, Exception> action)
        {
            try
            {
                var reg = await IngredienteOperacion.Update(ingredienteOperacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionDelete(int ingredienteOperacionId, Action<Exception> action)
        {
            try
            {
                await IngredienteOperacion.Delete(ingredienteOperacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action( exception);
            }
        }

        public async void IngredienteOperacionGet(int ingredienteOperacionId, Action<IngredienteOperacion, Exception> action)
        {
            try
            {
                var reg = await IngredienteOperacion.Get(ingredienteOperacionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetAll(Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetByIngrediente(int ingredienteId,
            Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetByIngrediente(ingredienteId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetByOperacion(int operacionId, Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetByOperacion(operacionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetByOperacionProceso(operacionProcesoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetByClase(string claseId, Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetByClase(claseId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetBySubClase(string subClaseId, Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetBySubClase(subClaseId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredienteOperacionGetByInstruccionOperacion(int instruccionOperacionId,
            Action<List<IngredienteOperacion>, Exception> action)
        {
            try
            {
                var lista = await IngredienteOperacion.GetByInstruccionOperacion(instruccionOperacionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region IngredientePredefinido

        public async void IngredientePredefinidoUpdate(IngredientePredefinido ingredientePredefinido,
            Action<IngredientePredefinido, Exception> action)
        {
            try
            {
                var reg = await IngredientePredefinido.Update(ingredientePredefinido);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredientePredefinidoDelete(int ingredientePredefinidoId, Action<Exception> action)
        {
            try
            {
                await IngredientePredefinido.Delete(ingredientePredefinidoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void IngredientePredefinidoGet(int ingredientePredefinidoId,
            Action<IngredientePredefinido, Exception> action)
        {
            try
            {
                var reg = await IngredientePredefinido.Get(ingredientePredefinidoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredientePredefinidoGetAll(Action<List<IngredientePredefinido>, Exception> action)
        {
            try
            {
                var lista = await IngredientePredefinido.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void IngredientePredefinidoGetByInstruccionPredefinida(int instruccionPredefinidaId,
            Action<List<IngredientePredefinido>, Exception> action)
        {
            try
            {
                var lista = await IngredientePredefinido.GetByInstruccionPredefinida(instruccionPredefinidaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region InstruccionOperacion

        public async void InstruccionOperacionUpdate(InstruccionOperacion instruccionOperacion,
            Action<InstruccionOperacion, Exception> action)
        {
            try
            {
                var reg = await InstruccionOperacion.Update(instruccionOperacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InstruccionOperacionDelete(int instruccionOperacionId, Action<Exception> action)
        {
            try
            {
                await InstruccionOperacion.Delete(instruccionOperacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void InstruccionOperacionGet(int instruccionOperacionId, Action<InstruccionOperacion, Exception> action)
        {
            try
            {
                var reg = await InstruccionOperacion.Get(instruccionOperacionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InstruccionOperacionGetAll(Action<List<InstruccionOperacion>, Exception> action)
        {
            try
            {
                var lista = await InstruccionOperacion.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InstruccionOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<InstruccionOperacion>, Exception> action)
        {
            try
            {
                var lista = await InstruccionOperacion.GetByOperacionProceso(operacionProcesoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region InstruccionPredefinida

        public async void InstruccionPredefinidaUpdate(InstruccionPredefinida instruccionPredefinida,
            Action<InstruccionPredefinida, Exception> action)
        {
            try
            {
                var reg = await InstruccionPredefinida.Update(instruccionPredefinida);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InstruccionPredefinidaDelete(int instruccionPredefinidaId, Action<Exception> action)
        {
            try
            {
                await InstruccionPredefinida.Delete(instruccionPredefinidaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void InstruccionPredefinidaGet(int instruccionPredefinidaId,
            Action<InstruccionPredefinida, Exception> action)
        {
            try
            {
                var reg = await InstruccionPredefinida.Get(instruccionPredefinidaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InstruccionPredefinidaGetAll(Action<List<InstruccionPredefinida>, Exception> action)
        {
            try
            {
                var lista = await InstruccionPredefinida.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void InstruccionPredefinidaGetbyOperacionPredefinida(int operacionPredefinidaId,
            Action<List<InstruccionPredefinida>, Exception> action)
        {
            try
            {
                var lista = await InstruccionPredefinida.GetByOperacionPredefinida(operacionPredefinidaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Lavado

        public async void LavadoUpdate(Lavado lavado, Action<Lavado, Exception> action)
        {
            try
            {
                var reg = await Lavado.Update(lavado);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoDelete(int lavadoId, Action<Exception> action)
        {
            try
            {
                await Lavado.Delete(lavadoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LavadoGet(int lavadoId, Action<Lavado, Exception> action)
        {
            try
            {
                var reg = await Lavado.Get(lavadoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoGetAll(Action<List<Lavado>, Exception> action)
        {
            try
            {
                var lista = await Lavado.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoGetByNombre(string lavadoNombre, Action<Lavado, Exception> action)
        {
            try
            {
                var reg = await Lavado.GetByNombre(lavadoNombre);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Lavadora

        public async void LavadoraUpdate(Lavadora lavadora, Action<Lavadora, Exception> action)
        {
            try
            {
                var reg = await Lavadora.Update(lavadora);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoraDelete(short lavadoraId, Action<Exception> action)
        {
            try
            {
                await Lavadora.Delete(lavadoraId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LavadoraGet(short lavadoraId, Action<Lavadora, Exception> action)
        {
            try
            {
                var reg = await Lavadora.Get(lavadoraId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoraGetAll(Action<List<Lavadora>, Exception> action)
        {
            try
            {
                var lista = await Lavadora.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoraGetByCapacidad(short lavadoraCapacidadId, Action<List<Lavadora>, Exception> action)
        {
            try
            {
                var lista = await Lavadora.GetByCapacidad(lavadoraCapacidadId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }


        #endregion

        #region LavadoraCapacidad

        public async void LavadoraCapacidadUpdate(LavadoraCapacidad lavadoraCapacidad, Action<LavadoraCapacidad, Exception> action)
        {
            try
            {
                var reg = await LavadoraCapacidad.Update(lavadoraCapacidad);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoraCapacidadDelete(short lavadoraCapacidadId, Action<Exception> action)
        {
            try
            {
                await LavadoraCapacidad.Delete(lavadoraCapacidadId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void LavadoraCapacidadGet(short lavadoraCapacidadId, Action<LavadoraCapacidad, Exception> action)
        {
            try
            {
                var reg = await LavadoraCapacidad.Get(lavadoraCapacidadId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void LavadoraCapacidadGetAll(Action<List<LavadoraCapacidad>, Exception> action)
        {
            try
            {
                var lista = await LavadoraCapacidad.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Maquina

        public async void MaquinaUpdate(Maquina maquina, Action<Maquina, Exception> action)
        {
            try
            {
                var reg = await Maquina.Update(maquina);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaDelete(MaquinaTipo tipo, int maquinaId, Action<Exception> action)
        {
            try
            {
                await Maquina.Delete(tipo, maquinaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void MaquinaGet(MaquinaTipo tipo, int maquinaId, Action<Maquina, Exception> action)
        {
            try
            {
                var reg = await Maquina.Get(tipo, maquinaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaGetAll(Action<List<Maquina>, Exception> action)
        {
            try
            {
                var lista = await Maquina.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaGetByTipo(MaquinaTipo tipo, Action<List<Maquina>, Exception> action)
        {
            try
            {
                var lista = await Maquina.GetByTipo(tipo);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaGetByTipoCapcacidad(MaquinaTipo tipo, int capacidadId, Action<List<Maquina>, Exception> action)
        {
            try
            {
                var lista = await Maquina.GetByTipoCapacidad(tipo, capacidadId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region MaquinaCapacidad

        public async void MaquinaCapacidadUpdate(MaquinaCapacidad maquinaCapacidad, Action<MaquinaCapacidad, Exception> action)
        {
            try
            {
                var reg = await MaquinaCapacidad.Update(maquinaCapacidad);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaCapacidadDelete(MaquinaTipo tipo, int maquinaCapacidadId, Action<Exception> action)
        {
            try
            {
                await MaquinaCapacidad.Delete(tipo, maquinaCapacidadId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void MaquinaCapacidadGet(MaquinaTipo tipo, int maquinaCapacidadId, Action<MaquinaCapacidad, Exception> action)
        {
            try
            {
                var reg = await MaquinaCapacidad.Get(tipo, maquinaCapacidadId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaCapacidadGetAll(Action<List<MaquinaCapacidad>, Exception> action)
        {
            try
            {
                var lista = await MaquinaCapacidad.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void MaquinaCapacidadGetByTipo(MaquinaTipo tipo, Action<List<MaquinaCapacidad>, Exception> action)
        {
            try
            {
                var lista = await MaquinaCapacidad.GetByTipo(tipo);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OpcionLavado

        public async void OpcionLavadoUpdate(OpcionLavado opcionLavado, Action<OpcionLavado, Exception> action)
        {
            try
            {
                var reg = await OpcionLavado.Update(opcionLavado);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OpcionLavadoDelete(int opcionLavadoId, Action<Exception> action)
        {
            try
            {
                await OpcionLavado.Delete(opcionLavadoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OpcionLavadoGet(int opcionLavadoId, Action<OpcionLavado, Exception> action)
        {
            try
            {
                var reg = await OpcionLavado.Get(opcionLavadoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OpcionLavadoGetAll(Action<List<OpcionLavado>, Exception> action)
        {
            try
            {
                var lista = await OpcionLavado.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OpcionLavadoGetByLavado(int lavadoId, Action<List<OpcionLavado>, Exception> action)
        {
            try
            {
                var lista = await OpcionLavado.GetByLavado(lavadoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OpcionLavadoGetByTela(string telaId, Action<List<OpcionLavado>, Exception> action)
        {
            try
            {
                var lista = await OpcionLavado.GetByTela(telaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region ObservacionPredefinida

        public async void ObservacionPredefinidaUpdate(ObservacionPredefinida observacionPredefinida,
            Action<ObservacionPredefinida, Exception> action)
        {
            try
            {
                var reg = await ObservacionPredefinida.Update(observacionPredefinida);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ObservacionPredefinidaDelete(int observacionPredefinidaId, Action<Exception> action)
        {
            try
            {
                await ObservacionPredefinida.Delete(observacionPredefinidaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ObservacionPredefinidaGet(int observacionPredefinidaId,
            Action<ObservacionPredefinida, Exception> action)
        {
            try
            {
                var reg = await ObservacionPredefinida.Get(observacionPredefinidaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ObservacionPredefinidaGetAll(Action<List<ObservacionPredefinida>, Exception> action)
        {
            try
            {
                var lista = await ObservacionPredefinida.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ObservacionPredefinidaGetByOperacion(int operacionId,
            Action<List<ObservacionPredefinida>, Exception> action)
        {
            try
            {
                var lista = await ObservacionPredefinida.GetbyOperacionId(operacionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region ObservacionOperacion

        public async void ObservacionOperacionUpdate(ObservacionOperacion observacionOperacion,
            Action<ObservacionOperacion, Exception> action)
        {
            try
            {
                var reg = await ObservacionOperacion.Update(observacionOperacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ObservacionOperacionDelete(int observacionOperacionId, Action<Exception> action)
        {
            try
            {
                await ObservacionOperacion.Delete(observacionOperacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ObservacionOperacionGet(int observacionOperacionId, Action<ObservacionOperacion, Exception> action)
        {
            try
            {
                var reg = await ObservacionOperacion.Get(observacionOperacionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ObservacionOperacionGetAll(Action<List<ObservacionOperacion>, Exception> action)
        {
            try
            {
                var lista = await ObservacionOperacion.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ObservacionOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<ObservacionOperacion>, Exception> action)
        {
            try
            {
                var lista = await ObservacionOperacion.GetByOperacionProceso(operacionProcesoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Operacion

        public async void OperacionUpdate(Operacion operacion, Action<Operacion, Exception> action)
        {
            try
            {
                var reg = await Operacion.Update(operacion);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionDelete(int operacionId, Action<Exception> action)
        {
            try
            {
                await Operacion.Delete(operacionId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OperacionGet(int operacionId, Action<Operacion, Exception> action)
        {
            try
            {
                var reg = await Operacion.Get(operacionId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionGetAll(Action<List<Operacion>, Exception> action)
        {
            try
            {
                var lista = await Operacion.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionGetAllLavanderia(Action<List<Operacion>, Exception> action)
        {
            try
            {
                var lista = await Operacion.GetAllLavanderia();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionGetOperacionesHumedas(int centrotrabajoId, Action<List<Operacion>, Exception> action)
        {
            try
            {
                var lista = await Operacion.GetOperacionesHumedas(centrotrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OperacionCentroTrabajo

        public async void OperacionCentroTrabajoUpdate(OperacionCentroTrabajo operacionCentroTrabajo,
            Action<OperacionCentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await OperacionCentroTrabajo.Update(operacionCentroTrabajo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void OperacionCentroTrabajoDelete(int opeacionCentroTrabajoId, Action<Exception> action)
        {
            try
            {
                await OperacionCentroTrabajo.Delete(opeacionCentroTrabajoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
                throw;
            }
        }

        public async void OperacionCentroTrabajoGet(int opeacionCentroTrabajoId,
            Action<OperacionCentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await OperacionCentroTrabajo.Get(opeacionCentroTrabajoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void OperacionCentroTrabajoGetAll(
            Action<List<OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await OperacionCentroTrabajo.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void OperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await OperacionCentroTrabajo.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        public async void OperacionCentroTrabajoGetByOperacion(short opeacionId,
            Action<List<OperacionCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await OperacionCentroTrabajo.GetByOperacion(opeacionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
                throw;
            }
        }

        #endregion

        #region OperacionPredefinida

        public async void OperacionPredefinidaUpdate(OperacionPredefinida operacionPredefinida,
            Action<OperacionPredefinida, Exception> action)
        {
            try
            {
                var reg = await OperacionPredefinida.Update(operacionPredefinida);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionPredefinidaDelete(int operacionPredefinidaId, Action<Exception> action)
        {
            try
            {
                await OperacionPredefinida.Delete(operacionPredefinidaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OperacionPredefinidaGet(int operacionPredefinidaId,
            Action<OperacionPredefinida, Exception> action)
        {
            try
            {
                var reg = await OperacionPredefinida.Get(operacionPredefinidaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionPredefinidaGetSingle(int operacionPredefinidaId,
            Action<OperacionPredefinida, Exception> action)
        {
            try
            {
                var reg = await OperacionPredefinida.GetSingle(operacionPredefinidaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionPredefinidaGetAll(Action<List<OperacionPredefinida>, Exception> action)
        {
            try
            {
                var lista = await OperacionPredefinida.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OperacionProceso

        public async void OperacionProcesoUpdate(OperacionProceso operacionProceso, Action<OperacionProceso, Exception> action)
        {
            try
            {
                var reg = await OperacionProceso.Update(operacionProceso);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionProcesoDelete(int operacionProcesoId, Action<Exception> action)
        {
            try
            {
                await OperacionProceso.Delete(operacionProcesoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void OperacionProcesoGet(int operacionProcesoId, Action<OperacionProceso, Exception> action)
        {
            try
            {
                var reg = await OperacionProceso.Get(operacionProcesoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionProcesoGetAll(Action<List<OperacionProceso>, Exception> action)
        {
            try
            {
                var lista = await OperacionProceso.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionProcesoGetByOperacion(int operacionId, Action<List<OperacionProceso>, Exception> action)
        {
            try
            {
                var lista = await OperacionProceso.GetByOperacion(operacionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionProcesoGetByProceso(int procesoId, Action<List<OperacionProceso>, Exception> action)
        {
            try
            {
                var lista = await OperacionProceso.GetByProceso(procesoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void OperacionProcesoGetByProcesoCentroTrabajo(int procesoCentroTrabajoId,
            Action<List<OperacionProceso>, Exception> action)
        {
            try
            {
                var lista = await OperacionProceso.GetByProcesoCentroTrabajo(procesoCentroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region OrdenProduccionLavanderia

        public async void OrdenProduccionLavanderiaGet(short companiaId, int plantaId, short centroTrabajoId,
            Action<List<OrdenProduccionLavanderia>, Exception> action)
        {
            try
            {
                var lista = await OrdenProduccionLavanderia.Get(companiaId, plantaId, centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Planta

        public async void PlantaUpdate(Planta planta, Action<Planta, Exception> action)
        {
            try
            {
                var reg = await Planta.Update(planta);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void PlantaDelete(int plantaId, Action<Exception> action)
        {
            try
            {
                await Planta.Delete(plantaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void PlantaGet(int plantaId, Action<Planta, Exception> action)
        {
            try
            {
                var reg = await Planta.Get(plantaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void PlantaGetAll(Action<List<Planta>, Exception> action)
        {
            try
            {
                var lista = await Planta.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void PlantaGetByCompania(int companiaId, Action<List<Planta>, Exception> action)
        {
            try
            {
                var lista = await Planta.GetByCompania(companiaId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Proceso

        public async void ProcesoUpdate(Proceso proceso, Action<Proceso, Exception> action)
        {
            try
            {
                var reg = await Proceso.Update(proceso);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoDelete(int procesoId, Action<Exception> action)
        {
            try
            {
                await Proceso.Delete(procesoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ProcesoGet(int procesoId, Action<Proceso, Exception> action)
        {
            try
            {
                var reg = await Proceso.Get(procesoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoGetAll(Action<List<Proceso>, Exception> action)
        {
            try
            {
                var lista = await Proceso.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<Proceso>, Exception> action)
        {
            try
            {
                var lista = await Proceso.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region ProcesoCentroTrabajo

        public async void ProcesoCentroTrabajoUpdate(ProcesoCentroTrabajo procesoCentroTrabajo,
            Action<ProcesoCentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await ProcesoCentroTrabajo.Update(procesoCentroTrabajo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoCentroTrabajoDelete(int procesoCentroTrabajoId, Action<Exception> action)
        {
            try
            {
                await ProcesoCentroTrabajo.Delete(procesoCentroTrabajoId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void ProcesoCentroTrabajoGet(int procesoCentroTrabajoId, Action<ProcesoCentroTrabajo, Exception> action)
        {
            try
            {
                var reg = await ProcesoCentroTrabajo.Get(procesoCentroTrabajoId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoCentroTrabajoGetAll(Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await ProcesoCentroTrabajo.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoCentroTrabajoGetByProceso(int procesoId, Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await ProcesoCentroTrabajo.GetByProceso(procesoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await ProcesoCentroTrabajo.GetByCentroTrabajo(centroTrabajoId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void ProcesoCentroTrabajoGetByCentroTrabajoOpcion(int centroTrabajoOpcionId,
            Action<List<ProcesoCentroTrabajo>, Exception> action)
        {
            try
            {
                var lista = await ProcesoCentroTrabajo.GetByCentroTrabajoOpcion(centroTrabajoOpcionId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Secadora

        public async void SecadoraUpdate(Secadora secadora, Action<Secadora, Exception> action)
        {
            try
            {
                var reg = await Secadora.Update(secadora);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SecadoraDelete(short secadoraId, Action<Exception> action)
        {
            try
            {
                await Secadora.Delete(secadoraId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void SecadoraGet(short secadoraId, Action<Secadora, Exception> action)
        {
            try
            {
                var reg = await Secadora.Get(secadoraId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SecadoraGetAll(Action<List<Secadora>, Exception> action)
        {
            try
            {
                var lista = await Secadora.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SecadoraGetByCapacidad(short secadoraCapacidadId, Action<List<Secadora>, Exception> action)
        {
            try
            {
                var lista = await Secadora.GetByCapacidad(secadoraCapacidadId);
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }


        #endregion

        #region SecadoraCapacidad

        public async void SecadoraCapacidadUpdate(SecadoraCapacidad secadoraCapacidad, Action<SecadoraCapacidad, Exception> action)
        {
            try
            {
                var reg = await SecadoraCapacidad.Update(secadoraCapacidad);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SecadoraCapacidadDelete(short secadoraCapacidadId, Action<Exception> action)
        {
            try
            {
                await SecadoraCapacidad.Delete(secadoraCapacidadId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void SecadoraCapacidadGet(short secadoraCapacidadId, Action<SecadoraCapacidad, Exception> action)
        {
            try
            {
                var reg = await SecadoraCapacidad.Get(secadoraCapacidadId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SecadoraCapacidadGetAll(Action<List<SecadoraCapacidad>, Exception> action)
        {
            try
            {
                var lista = await SecadoraCapacidad.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region SubClase

        public async void SubClaseUpdate(SubClase subClase, Action<SubClase, Exception> action)
        {
            try
            {
                var reg = await SubClase.Update(subClase);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SubClaseDelete(string subClaseCodigo, Action<Exception> action)
        {
            try
            {
                await SubClase.Delete(subClaseCodigo);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void SubClaseGet(string subClaseCodigo, Action<SubClase, Exception> action)
        {
            try
            {
                var reg = await SubClase.Get(subClaseCodigo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void SubClaseGetAll(Action<List<SubClase>, Exception> action)
        {
            try
            {
                var lista = await SubClase.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region Tela

        public async void TelaGet(string telaCodigo, Action<Tela, Exception> action)
        {
            try
            {
                var reg = await Tela.Get(telaCodigo);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TelaGetAll(Action<List<Tela>, Exception> action)
        {
            try
            {
                var lista = await Tela.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TelaGetCombo(Action<List<Tela>, Exception> action)
        {
            try
            {
                var lista = await Tela.GetCombo();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TelaGetComposicionCodigo(string telaCodigo, Action<string, Exception> action)
        {
            try
            {
                var str = await Tela.GetComposicionCodigo(telaCodigo);
                action(str, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        #endregion

        #region TelaColorIntermoda

        public async void TelaColorIntermodaUpdate(TelaColorIntermoda telaColorIntermoda,
            Action<TelaColorIntermoda, Exception> action)
        {
            try
            {
                var reg = await TelaColorIntermoda.Update(telaColorIntermoda);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TelaColorIntermodaDelete(int telaColorIntermodaId, Action<Exception> action)
        {
            try
            {
                await TelaColorIntermoda.Delete(telaColorIntermodaId);
                action(null);
            }
            catch (Exception exception)
            {
                action(exception);
            }
        }

        public async void TelaColorIntermodaGet(int telaColorIntermodaId, Action<TelaColorIntermoda, Exception> action)
        {
            try
            {
                var reg = await TelaColorIntermoda.Get(telaColorIntermodaId);
                action(reg, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TelaColorIntermodaGetAll(Action<List<TelaColorIntermoda>, Exception> action)
        {
            try
            {
                var lista = await TelaColorIntermoda.GetAll();
                action(lista, null);
            }
            catch (Exception exception)
            {
                action(null, exception);
            }
        }

        public async void TelaColorIntermodaGetByColorIntermoda(int colorIntermodaId,
            Action<List<TelaColorIntermoda>, Exception> action)
        {
            try
            {
                var lista = await TelaColorIntermoda.GetByColorIntermoda(colorIntermodaId);
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