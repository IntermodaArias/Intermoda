using System;
using System.Windows;
using Intermoda.Common;
using Intermoda.Maquilado.Wip.View;
using Intermoda.Maquilado.Wip.ViewModel;

namespace Intermoda.Maquilado.Wip.Helpers
{
    public class DialogService : IDialogService 
    {
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
    }
}