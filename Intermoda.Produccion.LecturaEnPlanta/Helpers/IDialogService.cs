using System;
using System.Windows;

namespace Intermoda.Produccion.LecturaEnPlanta.Helpers
{
    public interface IDialogService
    {
        #region Generales

        MessageBoxResult ConfirmAction(string message, string caption);

        void ShowMessage(string message, string caption);

        void ShowException(Exception exception);

        #endregion
    }
}