using System;
using System.Collections.Generic;
using Intermoda.Client.Lavanderia;
using Intermoda.Common.Enum;

namespace Intermoda.Client.DataService.Lavanderia
{
    public interface IDataServiceLavanderia
    {
        #region ArchivoGlobal

        void ArchivoGlobalUpdate(ArchivoGlobal archivoGlobal, Action<ArchivoGlobal, Exception> action);
        void ArchivoGlobalDelete(int archivoGlobalId, Action<Exception> action);
        void ArchivoGlobalGet(int archivoGlobalId, Action<ArchivoGlobal, Exception> action);
        void ArchivoGlobalGetAll(Action<List<ArchivoGlobal>, Exception> action);
        void ArchivoGlobalGetByPropietario(int propietarioId, Action<ArchivoGlobal, Exception> action);

        #endregion

        #region Catalogo

        void CatalogoUpdate(Catalogo catalogo, Action<Catalogo, Exception> action);
        void CatalogoDelete(int ingredienteId, Action<Exception> action);
        void CatalogoGet(int ingredienteId, Action<Catalogo, Exception> action);
        void CatalogoGetAll(Action<List<Catalogo>, Exception> action);
        void CatalogoGetByTela(string telaId, Action<Catalogo, Exception> action);

        #endregion

        #region CentroTrabajo

        void CentroTrabajoUpdate(CentroTrabajo centroTrabajo, Action<CentroTrabajo, Exception> action);
        void CentroTrabajoDelete(int centroTrabajoId, Action<Exception> action);
        void CentroTrabajoGet(int centroTrabajoId, Action<CentroTrabajo, Exception> action);
        void CentroTrabajoGetAll(Action<List<CentroTrabajo>, Exception> action);
        void CentroTrabajoGetActivos(Action<List<CentroTrabajo>, Exception> action);
        void CentroTrabajoGetByOperacion(int operacionId, Action<List<CentroTrabajo>, Exception> action);
        void CentroTrabajoGetAllLavanderia(Action<List<CentroTrabajo>, Exception> action);

        #endregion

        #region CentroTrabajoOpcion

        void CentroTrabajoOpcionUpdate(CentroTrabajoOpcion centroTrabajoOpcion,
            Action<CentroTrabajoOpcion, Exception> action);
        void CentroTrabajoOpcionDelete(int centroTrabajoOpcionId, Action<Exception> action);
        void CentroTrabajoOpcionGet(int centroTrabajoOpcionId, Action<CentroTrabajoOpcion, Exception> action);
        void CentroTrabajoOpcionGetAll(Action<List<CentroTrabajoOpcion>, Exception> action);
        void CentroTrabajoOpcionGetByCentroTrabajo(int centroTrabajoId,
            Action<List<CentroTrabajoOpcion>, Exception> action);
        void CentroTrabajoOpcionGetByOpcion(int opcionLavadoId, Action<List<CentroTrabajoOpcion>, Exception> action);

        #endregion

        #region Clase

        void ClaseUpdate(Clase clase, Action<Clase, Exception> action);
        void ClaseDelete(string claseCodigo, Action<Exception> action);
        void ClaseGet(string claseCodigo, Action<Clase, Exception> action);
        void ClaseGetAll(Action<List<Clase>, Exception> action);

        #endregion

        #region ColorIntermoda

        void ColorIntermodaUpdate(ColorIntermoda colorIntermoda, Action<ColorIntermoda, Exception> action);
        void ColorIntermodaDelete(int colorIntermodaId, Action<Exception> action);
        void ColorIntermodaGet(int colorIntermodaId, Action<ColorIntermoda, Exception> action);
        void ColorIntermodaGetAll(Action<List<ColorIntermoda>, Exception> action);

        #endregion

        #region IngredienteOperacion

        void IngredienteOperacionUpdate(IngredienteOperacion ingredienteOperacion,
            Action<IngredienteOperacion, Exception> action);
        void IngredienteOperacionDelete(int ingredienteOperacionId, Action<Exception> action);
        void IngredienteOperacionGet(int ingredienteOperacionId, Action<IngredienteOperacion, Exception> action);
        void IngredienteOperacionGetAll(Action<List<IngredienteOperacion>, Exception> action);
        void IngredienteOperacionGetByIngrediente(int ingredienteId,
            Action<List<IngredienteOperacion>, Exception> action);
        void IngredienteOperacionGetByOperacion(int operacionId, Action<List<IngredienteOperacion>, Exception> action);
        void IngredienteOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<IngredienteOperacion>, Exception> action);
        void IngredienteOperacionGetByClase(string claseId, Action<List<IngredienteOperacion>, Exception> action);
        void IngredienteOperacionGetBySubClase(string subClaseId, Action<List<IngredienteOperacion>, Exception> action);
        void IngredienteOperacionGetByInstruccionOperacion(int instruccionOperacionId,
            Action<List<IngredienteOperacion>, Exception> action);

        #endregion

        #region IngredientePredefinido

        void IngredientePredefinidoUpdate(IngredientePredefinido ingredientePredefinido,
            Action<IngredientePredefinido, Exception> action);
        void IngredientePredefinidoDelete(int ingredientePredefinidoId, Action<Exception> action);
        void IngredientePredefinidoGet(int ingredientePredefinidoId, Action<IngredientePredefinido, Exception> action);
        void IngredientePredefinidoGetAll(Action<List<IngredientePredefinido>, Exception> action);
        void IngredientePredefinidoGetByInstruccionPredefinida(int instruccionPredefinidaId,
            Action<List<IngredientePredefinido>, Exception> action);

        #endregion

        #region InstruccionOperacion

        void InstruccionOperacionUpdate(InstruccionOperacion instruccionOperacion,
            Action<InstruccionOperacion, Exception> action);
        void InstruccionOperacionDelete(int instruccionOperacionId, Action<Exception> action);
        void InstruccionOperacionGet(int instruccionOperacionId, Action<InstruccionOperacion, Exception> action);
        void InstruccionOperacionGetAll(Action<List<InstruccionOperacion>, Exception> action);
        void InstruccionOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<InstruccionOperacion>, Exception> action);

        #endregion

        #region InstruccionPredefinida

        void InstruccionPredefinidaUpdate(InstruccionPredefinida instruccionPredefinida,
            Action<InstruccionPredefinida, Exception> action);
        void InstruccionPredefinidaDelete(int instruccionPredefinidaId, Action<Exception> action);
        void InstruccionPredefinidaGet(int instruccionPredefinidaId, Action<InstruccionPredefinida, Exception> action);
        void InstruccionPredefinidaGetAll(Action<List<InstruccionPredefinida>, Exception> action);
        void InstruccionPredefinidaGetbyOperacionPredefinida(int operacionPredefinidaId, Action<List<InstruccionPredefinida>, Exception> action);

        #endregion

        #region Lavado

        void LavadoUpdate(Lavado lavado, Action<Lavado, Exception> action);
        void LavadoDelete(int lavadoId, Action<Exception> action);
        void LavadoGet(int lavadoId, Action<Lavado, Exception> action);
        void LavadoGetAll(Action<List<Lavado>, Exception> action);
        void LavadoGetByNombre(string lavadoNombre, Action<Lavado, Exception> action);

        #endregion

        #region Lavadora

        void LavadoraUpdate(Lavadora lavadora, Action<Lavadora, Exception> action);
        void LavadoraDelete(short lavadoraId, Action<Exception> action);
        void LavadoraGet(short lavadoraId, Action<Lavadora, Exception> action);
        void LavadoraGetAll(Action<List<Lavadora>, Exception> action);
        void LavadoraGetByCapacidad(short lavadoraCapacidadId, Action<List<Lavadora>, Exception> action);

        #endregion

        #region LavadoraCapacidad

        void LavadoraCapacidadUpdate(LavadoraCapacidad lavadoraCapacidad, Action<LavadoraCapacidad, Exception> action);
        void LavadoraCapacidadDelete(short lavadoraCapacidadId, Action<Exception> action);
        void LavadoraCapacidadGet(short lavadoraCapacidadId, Action<LavadoraCapacidad, Exception> action);
        void LavadoraCapacidadGetAll(Action<List<LavadoraCapacidad>, Exception> action);

        #endregion

        #region Maquina

        void MaquinaUpdate(Maquina maquina, Action<Maquina, Exception> action);
        void MaquinaDelete(MaquinaTipo tipo, int maquinaId, Action<Exception> action);
        void MaquinaGet(MaquinaTipo tipo, int maquinaId, Action<Maquina, Exception> action);
        void MaquinaGetAll(Action<List<Maquina>, Exception> action);
        void MaquinaGetByTipo(MaquinaTipo tipo, Action<List<Maquina>, Exception> action);
        void MaquinaGetByTipoCapcacidad(MaquinaTipo tipo, int capacidadId, Action<List<Maquina>, Exception> action);

        #endregion

        #region MaquinaCapacidad

        void MaquinaCapacidadUpdate(MaquinaCapacidad maquinaCapacidad, Action<MaquinaCapacidad, Exception> action);
        void MaquinaCapacidadDelete(MaquinaTipo tipo, int maquinaCapacidadId, Action<Exception> action);
        void MaquinaCapacidadGet(MaquinaTipo tipo, int maquinaCapacidadId, Action<MaquinaCapacidad, Exception> action);
        void MaquinaCapacidadGetAll(Action<List<MaquinaCapacidad>, Exception> action);
        void MaquinaCapacidadGetByTipo(MaquinaTipo tipo, Action<List<MaquinaCapacidad>, Exception> action);

        #endregion

        #region ObservacionPredefinida

        void ObservacionPredefinidaUpdate(ObservacionPredefinida observacionPredefinida,
            Action<ObservacionPredefinida, Exception> action);
        void ObservacionPredefinidaDelete(int observacionPredefinidaId, Action<Exception> action);
        void ObservacionPredefinidaGet(int observacionPredefinidaId, Action<ObservacionPredefinida, Exception> action);
        void ObservacionPredefinidaGetAll(Action<List<ObservacionPredefinida>, Exception> action);
        void ObservacionPredefinidaGetByOperacion(int operacionId,
            Action<List<ObservacionPredefinida>, Exception> action);

        #endregion

        #region ObservacionOperacion

        void ObservacionOperacionUpdate(ObservacionOperacion observacionOperacion,
            Action<ObservacionOperacion, Exception> action);
        void ObservacionOperacionDelete(int observacionOperacionId, Action<Exception> action);
        void ObservacionOperacionGet(int observacionOperacionId, Action<ObservacionOperacion, Exception> action);
        void ObservacionOperacionGetAll(Action<List<ObservacionOperacion>, Exception> action);
        void ObservacionOperacionGetByOperacionProceso(int operacionProcesoId,
            Action<List<ObservacionOperacion>, Exception> action);

        #endregion

        #region OpcionLavado

        void OpcionLavadoUpdate(OpcionLavado opcionLavado, Action<OpcionLavado, Exception> action);
        void OpcionLavadoDelete(int opcionLavadoId, Action<Exception> action);
        void OpcionLavadoGet(int opcionLavadoId, Action<OpcionLavado, Exception> action);
        void OpcionLavadoGetAll(Action<List<OpcionLavado>, Exception> action);
        void OpcionLavadoGetByLavado(int lavadoId, Action<List<OpcionLavado>, Exception> action);
        void OpcionLavadoGetByTela(string telaId, Action<List<OpcionLavado>, Exception> action);

        #endregion

        #region Operacion

        void OperacionUpdate(Operacion operacion, Action<Operacion, Exception> action);
        void OperacionDelete(int operacionId, Action<Exception> action);
        void OperacionGet(int operacionId, Action<Operacion, Exception> action);
        void OperacionGetAll(Action<List<Operacion>, Exception> action);
        void OperacionGetAllLavanderia(Action<List<Operacion>, Exception> action);
        void OperacionGetOperacionesHumedas(int centrotrabajoId, Action<List<Operacion>, Exception> action);

        #endregion

        #region OperacionCentroTrabajo

        void OperacionCentroTrabajoUpdate(OperacionCentroTrabajo operacionCentroTrabajo,
            Action<OperacionCentroTrabajo, Exception> action);
        void OperacionCentroTrabajoDelete(int opeacionCentroTrabajoId, Action<Exception> action);
        void OperacionCentroTrabajoGet(int opeacionCentroTrabajoId,
            Action<OperacionCentroTrabajo, Exception> action);
        void OperacionCentroTrabajoGetAll(Action<List<OperacionCentroTrabajo>, Exception> action);
        void OperacionCentroTrabajoGetByCentroTrabajo(int centroTrabajoId,
            Action<List<OperacionCentroTrabajo>, Exception> action);
        void OperacionCentroTrabajoGetByOperacion(short opeacionId,
            Action<List<OperacionCentroTrabajo>, Exception> action);

        #endregion

        #region OperacionPredefinida

        void OperacionPredefinidaUpdate(OperacionPredefinida operacionPredefinida,
            Action<OperacionPredefinida, Exception> action);
        void OperacionPredefinidaDelete(int operacionPredefinidaId, Action<Exception> action);
        void OperacionPredefinidaGet(int operacionPredefinidaId, Action<OperacionPredefinida, Exception> action);
        void OperacionPredefinidaGetSingle(int operacionPredefinidaId, Action<OperacionPredefinida, Exception> action);
        void OperacionPredefinidaGetAll(Action<List<OperacionPredefinida>, Exception> action);

        #endregion

        #region OperacionProceso

        void OperacionProcesoUpdate(OperacionProceso operacionProceso, Action<OperacionProceso, Exception> action);
        void OperacionProcesoDelete(int operacionProcesoId, Action<Exception> action);
        void OperacionProcesoGet(int operacionProcesoId, Action<OperacionProceso, Exception> action);
        void OperacionProcesoGetAll(Action<List<OperacionProceso>, Exception> action);
        void OperacionProcesoGetByOperacion(int operacionId, Action<List<OperacionProceso>, Exception> action);
        void OperacionProcesoGetByProceso(int procesoId, Action<List<OperacionProceso>, Exception> action);
        void OperacionProcesoGetByProcesoCentroTrabajo(int procesoCentroTrabajoId,
            Action<List<OperacionProceso>, Exception> action);

        #endregion

        #region OrdenProduccionLavanderia

        void OrdenProduccionLavanderiaGet(short companiaId, int plantaId, short centroTrabajoId,
            Action<List<OrdenProduccionLavanderia>, Exception> action);

        #endregion

        #region Planta

        void PlantaUpdate(Planta planta, Action<Planta, Exception> action);
        void PlantaDelete(int plantaId, Action<Exception> action);
        void PlantaGet(int plantaId, Action<Planta, Exception> action);
        void PlantaGetAll(Action<List<Planta>, Exception> action);
        void PlantaGetByCompania(int companiaId, Action<List<Planta>, Exception> action);

        #endregion

        #region Proceso

        void ProcesoUpdate(Proceso proceso, Action<Proceso, Exception> action);
        void ProcesoDelete(int procesoId, Action<Exception> action);
        void ProcesoGet(int procesoId, Action<Proceso, Exception> action);
        void ProcesoGetAll(Action<List<Proceso>, Exception> action);
        void ProcesoGetByCentroTrabajo(int centroTrabajoId, Action<List<Proceso>, Exception> action);

        #endregion

        #region ProcesoCentroTrabajo

        void ProcesoCentroTrabajoUpdate(ProcesoCentroTrabajo procesoCentroTrabajo,
            Action<ProcesoCentroTrabajo, Exception> action);
        void ProcesoCentroTrabajoDelete(int procesoCentroTrabajoId, Action<Exception> action);
        void ProcesoCentroTrabajoGet(int procesoCentroTrabajoId, Action<ProcesoCentroTrabajo, Exception> action);
        void ProcesoCentroTrabajoGetAll(Action<List<ProcesoCentroTrabajo>, Exception> action);
        void ProcesoCentroTrabajoGetByProceso(int procesoId, Action<List<ProcesoCentroTrabajo>, Exception> action);
        void ProcesoCentroTrabajoGetByCentroTrabajo(int centroTrabajoId, Action<List<ProcesoCentroTrabajo>, Exception> action);
        void ProcesoCentroTrabajoGetByCentroTrabajoOpcion(int centroTrabajoOpcionId, Action<List<ProcesoCentroTrabajo>, Exception> action);

        #endregion

        #region Secadora

        void SecadoraUpdate(Secadora secadora, Action<Secadora, Exception> action);
        void SecadoraDelete(short secadoraId, Action<Exception> action);
        void SecadoraGet(short secadoraId, Action<Secadora, Exception> action);
        void SecadoraGetAll(Action<List<Secadora>, Exception> action);
        void SecadoraGetByCapacidad(short secadoraCapacidadId, Action<List<Secadora>, Exception> action);

        #endregion

        #region SecadoraCapacidad

        void SecadoraCapacidadUpdate(SecadoraCapacidad secadoraCapacidad, Action<SecadoraCapacidad, Exception> action);
        void SecadoraCapacidadDelete(short secadoraCapacidadId, Action<Exception> action);
        void SecadoraCapacidadGet(short secadoraCapacidadId, Action<SecadoraCapacidad, Exception> action);
        void SecadoraCapacidadGetAll(Action<List<SecadoraCapacidad>, Exception> action);

        #endregion

        #region SubClase

        void SubClaseUpdate(SubClase subClase, Action<SubClase, Exception> action);
        void SubClaseDelete(string subClaseCodigo, Action<Exception> action);
        void SubClaseGet(string subClaseCodigo, Action<SubClase, Exception> action);
        void SubClaseGetAll(Action<List<SubClase>, Exception> action);

        #endregion

        #region Tela

        void TelaGet(string telaCodigo, Action<Tela, Exception> action);
        void TelaGetAll(Action<List<Tela>, Exception> action);
        void TelaGetCombo(Action<List<Tela>, Exception> action);
        void TelaGetComposicionCodigo(string telaCodigo, Action<string, Exception> action);

        #endregion

        #region TelaColorIntermoda

        void TelaColorIntermodaUpdate(TelaColorIntermoda telaColorIntermoda, Action<TelaColorIntermoda, Exception> action);
        void TelaColorIntermodaDelete(int telaColorIntermodaId, Action<Exception> action);
        void TelaColorIntermodaGet(int telaColorIntermodaId, Action<TelaColorIntermoda, Exception> action);
        void TelaColorIntermodaGetAll(Action<List<TelaColorIntermoda>, Exception> action);
        void TelaColorIntermodaGetByColorIntermoda(int colorIntermodaId,
            Action<List<TelaColorIntermoda>, Exception> action);

        #endregion
    }
}