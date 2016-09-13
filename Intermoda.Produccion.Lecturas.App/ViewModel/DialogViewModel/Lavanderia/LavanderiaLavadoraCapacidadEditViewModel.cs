using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaLavadoraCapacidadEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private LavadoraCapacidad _lavadoraCapacidad;
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

        private decimal? _capacidadMinimaKg;

        /// <summary>
        /// Sets and gets the CapacidadMinimaKg property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? CapacidadMinimaKg
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

        #region CapacidadCanastaLitro

        /// <summary>
        /// The <see cref="CapacidadCanastaLitro" /> property's name.
        /// </summary>
        public const string CapacidadCanastaLitroPropertyName = "CapacidadCanastaLitro";

        private decimal? _capacidadCanastaLitro;

        /// <summary>
        /// Sets and gets the CapacidadCanastaLitro property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? CapacidadCanastaLitro
        {
            get
            {
                return _capacidadCanastaLitro;
            }

            set
            {
                if (_capacidadCanastaLitro == value)
                {
                    return;
                }

                _capacidadCanastaLitro = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CapacidadCanastaLitroPropertyName);
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

        public LavanderiaLavadoraCapacidadEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, LavadoraCapacidad lavadoraCapacidad)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                CapacidadMinimaKg = 100;
                CapacidadMaximaKg = 200;
                CapacidadCanastaLitro = 300;
            }
            else
            {
                _lavadoraCapacidad = lavadoraCapacidad;
                Id = lavadoraCapacidad.Id;
                CapacidadMinimaKg = lavadoraCapacidad.CapacidadMinimaKg;
                CapacidadMaximaKg = lavadoraCapacidad.CapacidadMaximaKg;
                CapacidadCanastaLitro = lavadoraCapacidad.CapacidadCanastaLitro;
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
            _lavadoraCapacidad.CapacidadMinimaKg= CapacidadMinimaKg;
            _lavadoraCapacidad.CapacidadMaximaKg = CapacidadMaximaKg;
            _lavadoraCapacidad.CapacidadCanastaLitro = CapacidadCanastaLitro;

            _dataService.LavadoraCapacidadUpdate(_lavadoraCapacidad,
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
            return _lavadoraCapacidad.CapacidadMinimaKg != CapacidadMinimaKg ||
                   _lavadoraCapacidad.CapacidadMaximaKg != CapacidadMaximaKg ||
                   _lavadoraCapacidad.CapacidadCanastaLitro != CapacidadCanastaLitro;
        }

        #endregion
    }
}