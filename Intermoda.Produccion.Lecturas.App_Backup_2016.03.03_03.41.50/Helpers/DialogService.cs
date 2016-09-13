using System;
using System.Windows;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Dialog;
using Intermoda.Produccion.Lecturas.App.View;
using Intermoda.Produccion.Lecturas.App.ViewModel;
using Intermoda.Produccion.Lecturas.Client;
using Intermoda.Produccion.Lecturas.Client.DataServices;

namespace Intermoda.Produccion.Lecturas.App.Helpers
{
    public class DialogService : IDialogService
    {
        public void CentroTrabajoEdit(IDataService dataService, IDialogService dialogService, CentroTrabajo centroTrabajo)
        {
            var vm = new CentroTrabajoEditViewModel(dataService, dialogService, centroTrabajo);

            var dlg = new CentroTrabajoEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void CentroTrabajoClasificacionEdit(IDataService dataService, IDialogService dialogService,
            CentroTrabajoClasificacion centroTrabajoClasificacion)
        {
            var vm = new CentroTrabajoClasificacionEditViewModel(dataService, dialogService, centroTrabajoClasificacion);

            var dlg = new CentroTrabajoClasificacionEditView {DataContext = vm};
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }

        public void ModuloEdit(IDataService dataService, IDialogService dialogService, Modulo modulo)
        {
            var vm = new ModuloEditViewModel(dataService, dialogService, modulo);

            var dlg = new ModuloEditView { DataContext = vm };
            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();
        }
        
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

    }
}