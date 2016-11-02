using System;
using System.Windows;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;

namespace Intermoda.Maquilado.Helpers
{
    public interface IDialogService
    {
        #region Generales

        MessageBoxResult ConfirmAction(string message, string caption);

        void ShowMessage(string message, string caption);

        void ShowException(Exception exception);

        #endregion

        Planta Login();

        void EmpaqueDialog(IDataServiceLbDatPro dataService, IDialogService dialogService, OrdenProduccionExterno orden);
    }
}