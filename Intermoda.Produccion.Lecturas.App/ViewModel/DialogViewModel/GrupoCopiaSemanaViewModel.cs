using System;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class GrupoCopiaSemanaViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region FechaDesde

        /// <summary>
        /// The <see cref="FechaDesde" /> property's name.
        /// </summary>
        public const string FechaDesdePropertyName = "FechaDesde";

        private DateTime _fechaDesde;

        /// <summary>
        /// Sets and gets the FechaDesde property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaDesde
        {
            get
            {
                return _fechaDesde;
            }

            set
            {
                if (_fechaDesde == value)
                {
                    return;
                }

                _fechaDesde = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(FechaDesdePropertyName);
            }
        }

        #endregion

        #region FechaHasta

        /// <summary>
        /// The <see cref="FechaHasta" /> property's name.
        /// </summary>
        public const string FechaHastaPropertyName = "FechaHasta";

        private DateTime _fechaHasta;

        /// <summary>
        /// Sets and gets the FechaHasta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaHasta
        {
            get
            {
                return _fechaHasta;
            }

            set
            {
                if (_fechaHasta == value)
                {
                    return;
                }

                _fechaHasta = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(FechaHastaPropertyName);
            }
        }

        #endregion

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public GrupoCopiaSemanaViewModel(IDataServiceLectura dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                FechaDesde = new DateTime(2016,1,4);
                FechaHasta = new DateTime(2016,1,11);
            }

            RegisterCommands();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _dataService.GrupoHayDataSemana(FechaHasta,
                (vrf, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    if (!vrf)
                    {
                        var cnf = _dialogService.ConfirmAction("Existen datos. ¿desea reemplazarlos?", "Confirme");
                        if (cnf == MessageBoxResult.Cancel)
                            return;
                    }
                    Copiar();
                });
        }

        private void Copiar()
        {
            _dataService.GrupoCopiarSemana(FechaDesde, FechaHasta,
                error =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    if (OnRequestClose != null)
                        OnRequestClose(this, new EventArgs());
                });
        }

        private bool CanConfirm()
        {
            return FechaDesde.DayOfWeek == DayOfWeek.Monday &&
                   FechaHasta.DayOfWeek == DayOfWeek.Monday &&
                   FechaDesde < FechaHasta;
        }

        #endregion
    }
}