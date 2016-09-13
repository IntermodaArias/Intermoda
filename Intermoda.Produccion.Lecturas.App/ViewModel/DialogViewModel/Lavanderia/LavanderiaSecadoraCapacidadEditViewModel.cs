using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaSecadoraCapacidadEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private SecadoraCapacidad _secadoraCapacidad;
        private readonly bool _init;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private short _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IdPropertyName);
            }
        }

        #endregion

        #region CapacidadMinimaKg

        /// <summary>
        /// The <see cref="CapacidadMinimaKg" /> property's name.
        /// </summary>
        public const string CapacidadMinimaKgPropertyName = "CapacidadMinimaKg";

        private decimal _capacidadMinimaKg;

        /// <summary>
        /// Sets and gets the CapacidadMinimaKg property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CapacidadMinimaKg
        {
            get
            {
                return _capacidadMinimaKg;
            }

            set
            {
                if (_capacidadMinimaKg == value)
                {
                    return;
                }

                _capacidadMinimaKg = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CapacidadMinimaKgPropertyName);
            }
        }

        #endregion

        #region CapacidadMaximaKg

        /// <summary>
        /// The <see cref="CapacidadMaximaKg" /> property's name.
        /// </summary>
        public const string CapacidadMaximaKgPropertyName = "CapacidadMaximaKg";

        private decimal _capacidadMaximaKg;

        /// <summary>
        /// Sets and gets the CapacidadMaximaKg property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CapacidadMaximaKg
        {
            get
            {
                return _capacidadMaximaKg;
            }

            set
            {
                if (_capacidadMaximaKg == value)
                {
                    return;
                }

                _capacidadMaximaKg = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CapacidadMaximaKgPropertyName);
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

        public LavanderiaSecadoraCapacidadEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, SecadoraCapacidad secadoraCapacidad)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                CapacidadMinimaKg = 100;
                CapacidadMaximaKg = 200;
            }
            else
            {
                _secadoraCapacidad = secadoraCapacidad;
                Id = secadoraCapacidad.Id;
                CapacidadMinimaKg = secadoraCapacidad.CapacidadMinimaKg;
                CapacidadMaximaKg = secadoraCapacidad.CapacidadMaximaKg;
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
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _secadoraCapacidad.CapacidadMinimaKg = CapacidadMinimaKg;
            _secadoraCapacidad.CapacidadMaximaKg = CapacidadMaximaKg;
            
            _dataService.SecadoraCapacidadUpdate(_secadoraCapacidad,
                (updated, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OnRequestClose?.Invoke(this, new EventArgs());
                });
        }

        private bool CanConfirm()
        {
            return _secadoraCapacidad.CapacidadMinimaKg != CapacidadMinimaKg ||
                   _secadoraCapacidad.CapacidadMaximaKg != CapacidadMaximaKg;
        }

        #endregion
    }
}