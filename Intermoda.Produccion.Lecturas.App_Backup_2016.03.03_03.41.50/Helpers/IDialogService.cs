using System;
using System.Windows;
using Intermoda.Produccion.Lecturas.Client;
using Intermoda.Produccion.Lecturas.Client.DataServices;

namespace Intermoda.Produccion.Lecturas.App.Helpers
{
    public interface IDialogService
    {
        void CentroTrabajoEdit(IDataService dataService, IDialogService dialogService, CentroTrabajo centroTrabajo);

        void CentroTrabajoClasificacionEdit(IDataService dataService, IDialogService dialogService,
            CentroTrabajoClasificacion centroTrabajoClasificacion);

        void ModuloEdit(IDataService dataService, IDialogService dialogService, Modulo modulo);

        #region Generales

        MessageBoxResult ConfirmAction(string message, string caption);

        void ShowMessage(string message, string caption);

        void ShowException(Exception exception);

        #endregion
    }
}