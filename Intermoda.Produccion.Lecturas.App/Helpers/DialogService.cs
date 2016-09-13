using System;
using System.Windows;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lavanderia;
using Intermoda.Client.Lectura;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Dialog;
using Intermoda.Produccion.Lecturas.App.View;
using Intermoda.Produccion.Lecturas.App.View.DialogView.Lavanderia;
using Intermoda.Produccion.Lecturas.App.View.Lavanderia;
using Intermoda.Produccion.Lecturas.App.ViewModel;
using LavanderiaIngredientePredefinidoView = Intermoda.Produccion.Lecturas.App.View.LavanderiaIngredientePredefinidoView;
using LeCentroTrabajo = Intermoda.Client.Lectura.CentroTrabajo;
using LvCentroTrabajo = Intermoda.Client.Lavanderia.CentroTrabajo;

namespace Intermoda.Produccion.Lecturas.App.Helpers
{
    public class DialogService : IDialogService
    {
        #region Lecturas

        public void CentroTrabajoEdit(IDataServiceLectura dataService, IDialogService dialogService,
            LeCentroTrabajo centroTrabajo)
        {
            var vm = new CentroTrabajoEditViewModel(dataService, dialogService, centroTrabajo);

            var dlg = new CentroTrabajoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void CentroTrabajoClasificacionEdit(IDataServiceLectura dataService, IDialogService dialogService,
            CentroTrabajoClasificacion centroTrabajoClasificacion)
        {
            var vm = new CentroTrabajoClasificacionEditViewModel(dataService, dialogService, centroTrabajoClasificacion);

            var dlg = new CentroTrabajoClasificacionEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void GrupoEdit(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo)
        {
            var vm = new GrupoEditViewModel(dataService, dialogService, grupo);

            var dlg = new GrupoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void JornadaEdit(IDataServiceLectura dataService, IDialogService dialogService, Jornada jornada)
        {
            var vm = new JornadaEditViewModel(dataService, dialogService, jornada);

            var dlg = new JornadaEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void JornadaDetalleEdit(IDataServiceLectura dataService, IDialogService dialogService,
            JornadaDetalle jornadaDetalle)
        {
            var vm = new JornadaDetalleEditViewModel(dataService, dialogService, jornadaDetalle);

            var dlg = new JornadaDetalleEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LineaEdit(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo, Linea linea)
        {
            var vm = new LineaEditViewModel(dataService, dialogService, linea)
            {
                Grupo = grupo
            };

            var dlg = new LineaEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LineaDetalleEdit(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo,
            LineaDetalle lineaDetalle)
        {
            var vm = new LineaDetalleEditViewModel(dataService, dialogService, grupo, lineaDetalle);

            var dlg = new LineaDetalleEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void ModuloEdit(IDataServiceLectura dataService, IDialogService dialogService, Modulo modulo)
        {
            var vm = new ModuloEditViewModel(dataService, dialogService, modulo);

            var dlg = new ModuloEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void TurnoEdit(IDataServiceLectura dataService, IDialogService dialogService, Turno turno)
        {
            var vm = new TurnoEditViewModel(dataService, dialogService, turno);

            var dlg = new TurnoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void TurnoDetalleEdit(IDataServiceLectura dataService, IDialogService dialogService,
            TurnoDetalle turnoDetalle)
        {
            var vm = new TurnoDetalleEditViewModel(dataService, dialogService, turnoDetalle);

            var dlg = new TurnoDetalleEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        #endregion
        
        #region Generales

        public MessageBoxResult ConfirmAction(string message, string caption)
        {
            var response = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);
            return response;
        }

        public void ShowMessage(string message, string caption)
        {
            var vm = new MessageWindowViewModel(message, caption);
            var dlg = new MessageWindow {DataContext = vm};

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void ShowException(Exception exception)
        {
            var message = Tools.ExceptionMessage(exception);
            const string caption = "Error";

            var vm = new MessageWindowViewModel(caption, message);
            var dlg = new MessageWindow { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        #endregion

        #region Lavandería

        public void LavanderiaCentroTrabajoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            LvCentroTrabajo centroTrabajo)
        {
            var vm = new LavanderiaCentroTrabajoEditViewModel(dataService, dialogService,centroTrabajo);

            var dlg = new LavanderiaCentroTrabajoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaCentroTrabajoOpcionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            CentroTrabajoOpcion centroTrabajoOpcion)
        {
            var vm = new LavanderiaCentroTrabajoOpcionEditViewModel(dataService, dialogService, centroTrabajoOpcion);

            var dlg = new LavanderiaCentroTrabajoOpcionEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaColoresEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ColorIntermoda colorIntermoda)
        {
            var vm = new LavanderiaColoresEditViewModel(dataService, dialogService, colorIntermoda);

            var dlg = new LavanderiaColoresEditView { DataContext = vm };
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaIngredienteInstruccionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            IngredienteOperacion ingredienteOperacion)
        {
            var vm = new LavanderiaIngredienteInstruccionEditViewModel(dataService, dialogService, ingredienteOperacion);
            var dlg = new LavanderiaIngredienteInstruccionEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaIngredientePredefinidaEdit(IDataServiceLavanderia dataService,
            IDialogService dialogService, IngredientePredefinido ingredientePredefinido)
        {
            var vm = new LavanderiaIngredientePredefinidoEditViewModel(dataService, dialogService, ingredientePredefinido);

            var dlg = new LavanderiaIngredientePredefinidoView {DataContext = vm};

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaInstruccionOperacionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            InstruccionOperacion instruccionOperacion)
        {
            var vm = new LavanderiaInstruccionOperacionEditViewModel(dataService, dialogService, instruccionOperacion);
            var dlg = new LavanderiaInstruccionOperacionEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaInstruccionPredefinidaEdit(IDataServiceLavanderia dataService,
            IDialogService dialogService, InstruccionPredefinida instruccionPredefinida)
        {
            var vm = new LavanderiaInstruccionPredefinidaEditViewModel(dataService, dialogService,
                instruccionPredefinida);
            var dlg = new LavanderiaInstruccionPredefinidaEditView {DataContext = vm};

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaLavadoEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Lavado lavado)
        {
            var vm = new LavanderiaLavadoEditViewModel(dataService, dialogService, lavado);
            var dlg = new LavanderiaLavadoEditView { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaLavadoraEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Lavadora lavadora)
        {
            var vm = new LavanderiaLavadoraEditViewModel(dataService, dialogService, lavadora);
            var dlg = new LavanderiaLavadoraEditView { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaLavadoraCapacidadEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            LavadoraCapacidad lavadoraCapacidad)
        {
            var vm = new LavanderiaLavadoraCapacidadEditViewModel(dataService, dialogService, lavadoraCapacidad);
            var dlg = new LavanderiaLavadoraCapacidadEditView { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaObservacionOperacionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ObservacionOperacion observacionOperacion)
        {
            var vm = new LavanderiaObservacionOperacionEditViewModel(dataService, dialogService, observacionOperacion);
            var dlg = new LavanderiaObservacionOperacionEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaOpcionLavadoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            OpcionLavado opcionLavado, bool lavadoIsReadOnly)
        {
            var vm = new LavanderiaOpcionLavadoEditViewModel(dataService, dialogService, opcionLavado, lavadoIsReadOnly);
            var dlg = new LavanderiaOpcionLavadoEditView { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaOperacionEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            Operacion operacion)
        {
            var vm = new LavanderiaOperacionEditViewModel(dataService, dialogService, operacion);

            var dlg = new LavanderiaOperacionEditView { DataContext = vm };
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaOperacionCentroTrabajoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            OperacionCentroTrabajo operacionCentroTrabajo)
        {
            var vm = new LavanderiaOperacionCentroTrabajoEditViewModel(dataService, dialogService, operacionCentroTrabajo);

            var dlg = new LavanderiaOperacionCentroTrabajoEditView { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaOperacionObservacionPredefinidaEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ObservacionPredefinida observacionPredefinida)
        {
            var vm = new LavanderiaOperacionObservacionEditViewModel(dataService, dialogService, observacionPredefinida);

            var dlg = new LavanderiaOperacionObservacionEditView {DataContext = vm};

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaOperacionProcesoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            OperacionProceso operacionProceso)
        {
            var vm = new LavanderiaOperacionProcesoEditViewModel(dataService, dialogService, operacionProceso);
            var dlg = new LavanderiaOperacionProcesoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaProcesoCentroTrabajoEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            ProcesoCentroTrabajo procesoCentroTrabajo)
        {
            var vm = new LavanderiaProcesoCentroTrabajoEditViewModel(dataService, dialogService, procesoCentroTrabajo);
            var dlg = new LavanderiaProcesoCentroTrabajoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaProcesoEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Proceso proceso)
        {
            var vm = new LavanderiaProcesoEditViewModel(dataService, dialogService, proceso);

            var dlg = new LavanderiaProcesoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void LavanderiaRecetaTrabajarCon(IDataServiceLavanderia dataService, IDialogService dialogService,
            OpcionLavado opcionLavado)
        {
            var vm = new LavanderiaLavadoRecetaViewModel(dataService, dialogService, opcionLavado);
            var dlg = new LavanderiaLavadoRecetaView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaSecadoraEdit(IDataServiceLavanderia dataService, IDialogService dialogService, Secadora secadora)
        {
            var vm = new LavanderiaSecadoraEditViewModel(dataService, dialogService, secadora);
            var dlg = new LavanderiaSecadoraEditView { DataContext = vm };
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaSecadoraCapacidadEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            SecadoraCapacidad secadoraCapacidad)
        {
            var vm = new LavanderiaSecadoraCapacidadEditViewModel(dataService, dialogService, secadoraCapacidad);
            var dlg = new LavanderiaSecadoraCapacidadEditView { DataContext = vm };
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();
            dlg.ShowDialog();
        }

        public void LavanderiaTelaColorEdit(IDataServiceLavanderia dataService, IDialogService dialogService,
            TelaColorIntermoda telaColorIntermoda)
        {
            var vm = new LavanderiaTelaColorIntermodaEditViewModel(dataService, dialogService, telaColorIntermoda);

            var dlg = new LavanderiaTelaColorIntermodaEditView { DataContext = vm };
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        #endregion
    }
}