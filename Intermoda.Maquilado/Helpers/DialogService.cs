using System;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Common;
using Intermoda.Maquilado.Messages;
using Intermoda.Maquilado.View;
using Intermoda.Maquilado.ViewModel;

namespace Intermoda.Maquilado.Helpers
{
    public class DialogService : IDialogService
    {
        private Planta _planta;

        #region Generales

        public MessageBoxResult ConfirmAction(string message, string caption)
        {
            var response = MessageBox.Show(message, caption, MessageBoxButton.OKCancel);
            return response;
        }

        public void ShowMessage(string message, string caption)
        {
            var vm = new MessageWindowViewModel(message, caption);
            var dlg = new MessageWindow { DataContext = vm };

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

        public Planta Login()
        {
            Messenger.Default.Register<LoginMessage>(this, HandleLogin);
            var vm = new LoginViewModel(new DataServiceLbDatPro());
            var dlg = new LoginView { DataContext = vm };

            if (vm.CloseAction == null) vm.CloseAction = dlg.Close;
            vm.OnRequestClose += (s, e) => dlg.Close();

            dlg.ShowDialog();

            var planta = _planta;

            return planta;
        }

        private void HandleLogin(LoginMessage obj)
        {
            _planta = obj.Planta;
        }
    }
}