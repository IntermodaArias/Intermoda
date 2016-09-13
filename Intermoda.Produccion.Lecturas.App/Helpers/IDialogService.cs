using System;
using System.Windows;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lavanderia;
using Intermoda.Client.Lectura;
using LeCentroTrabajo = Intermoda.Client.Lectura.CentroTrabajo;
using LvCentroTrabajo = Intermoda.Client.Lavanderia.CentroTrabajo;

namespace Intermoda.Produccion.Lecturas.App.Helpers
{
    public interface IDialogService
    {
        #region Lecturas

        void CentroTrabajoEdit(IDataServiceLectura dataService, IDialogService dialogService,
            LeCentroTrabajo centroTrabajo);

        void CentroTrabajoClasificacionEdit(IDataServiceLectura dataService, IDialogService dialogService,
            CentroTrabajoClasificacion centroTrabajoClasificacion);

        void GrupoEdit(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo);

        void JornadaEdit(IDataServiceLectura dataService, IDialogService dialogService, Jornada jornada);

        void JornadaDetalleEdit(IDataServiceLectura dataService, IDialogService dialogService,
            JornadaDetalle jornadaDetalle);

        void LineaEdit(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo, Linea linea);

        void LineaDetalleEdit(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo,
            LineaDetalle lineaDetalle);

        void ModuloEdit(IDataServiceLectura dataService, IDialogService dialogService, Modulo modulo);

        void TurnoEdit(IDataServiceLectura dataService, IDialogService dialogService, Turno turno);

        void TurnoDetalleEdit(IDataServiceLectura dataService, IDialogService dialogService, TurnoDetalle turnoDetalle);

        #endregion
        
        #region Generales

        MessageBoxResult ConfirmAction(string message, string caption);

        void ShowMessage(string message, string caption);

        void ShowException(Exception exception);

        #endregion

        #region Lavandería

        void LavanderiaCentroTrabajoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            LvCentroTrabajo centroTrabajo);

        void LavanderiaCentroTrabajoOpcionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            CentroTrabajoOpcion centroTrabajoOpcion);

        void LavanderiaColoresEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ColorIntermoda colorIntermoda);

        void LavanderiaIngredienteInstruccionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            IngredienteOperacion ingredienteOperacion);

        void LavanderiaIngredientePredefinidaEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            IngredientePredefinido ingredientePredefinido);

        void LavanderiaInstruccionOperacionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            InstruccionOperacion instruccionOperacion);

        void LavanderiaInstruccionPredefinidaEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            InstruccionPredefinida instruccionPredefinida);

        void LavanderiaLavadoEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Lavado lavado);

        void LavanderiaLavadoraEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Lavadora lavadora);

        void LavanderiaLavadoraCapacidadEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            LavadoraCapacidad lavadoraCapacidad);

        void LavanderiaObservacionOperacionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ObservacionOperacion observacionOperacion);

        void LavanderiaOpcionLavadoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            OpcionLavado opcionLavado, bool lavadoIsReadOnly);

        void LavanderiaOperacionEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Operacion operacion);

        void LavanderiaOperacionCentroTrabajoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            OperacionCentroTrabajo operacionCentroTrabajo);

        void LavanderiaOperacionObservacionPredefinidaEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ObservacionPredefinida observacionPredefinida);

        void LavanderiaOperacionProcesoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            OperacionProceso operacionProceso);

        void LavanderiaProcesoCentroTrabajoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ProcesoCentroTrabajo procesoCentroTrabajo);

        void LavanderiaProcesoEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Proceso proceso);

        void LavanderiaRecetaTrabajarCon(IDataServiceLavanderia dataService, IDialogService dialogService,
            OpcionLavado opcionLavado);

        void LavanderiaSecadoraEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Secadora secadora);

        void LavanderiaSecadoraCapacidadEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            SecadoraCapacidad secadoraCapacidad);

        void LavanderiaTelaColorEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            TelaColorIntermoda telaColorIntermoda);

        #endregion
    }
}