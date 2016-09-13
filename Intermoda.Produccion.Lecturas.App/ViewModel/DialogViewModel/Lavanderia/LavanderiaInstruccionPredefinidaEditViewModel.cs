using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaInstruccionPredefinidaEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService; 
        private readonly IDialogService _dialogService;

        private InstruccionPredefinida _instruccionPredefinida;
        private readonly bool _init;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private int _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Id
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

        #region OperacionPredefinidaId

        /// <summary>
        /// The <see cref="OperacionPredefinidaId" /> property's name.
        /// </summary>
        public const string OperacionPredefinidaIdPropertyName = "OperacionPredefinidaId";

        private int _operacionPredefinidaId;

        /// <summary>
        /// Sets and gets the OperacionPredefinidaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionPredefinidaId
        {
            get
            {
                return _operacionPredefinidaId;
            }

            set
            {
                if (_operacionPredefinidaId == value)
                {
                    return;
                }

                _operacionPredefinidaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OperacionPredefinidaIdPropertyName);
            }
        }

        #endregion

        #region Descripcion

        /// <summary>
        /// The <see cref="Descripcion" /> property's name.
        /// </summary>
        public const string DescripcionPropertyName = "Descripcion";

        private string _descripcion;

        /// <summary>
        /// Sets and gets the Descripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(DescripcionPropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                if (_orden == value)
                {
                    return;
                }

                _orden = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OrdenPropertyName);
            }
        }

        #endregion

        #region TiempoMinimo

        /// <summary>
        /// The <see cref="TiempoMinimo" /> property's name.
        /// </summary>
        public const string TiempoMinimoPropertyName = "TiempoMinimo";

        private decimal _tiempoMinimo;

        /// <summary>
        /// Sets and gets the TiempoMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMinimo
        {
            get
            {
                return _tiempoMinimo;
            }

            set
            {
                if (_tiempoMinimo == value)
                {
                    return;
                }

                _tiempoMinimo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TiempoMinimoPropertyName);
            }
        }

        #endregion

        #region TiempoMaximo

        /// <summary>
        /// The <see cref="TiempoMaximo" /> property's name.
        /// </summary>
        public const string TiempoMaximoPropertyName = "TiempoMaximo";

        private decimal _tiempoMaximo;

        /// <summary>
        /// Sets and gets the TiempoMaximo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMaximo
        {
            get
            {
                return _tiempoMaximo;
            }

            set
            {
                if (_tiempoMaximo == value)
                {
                    return;
                }

                _tiempoMaximo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TiempoMaximoPropertyName);
            }
        }

        #endregion

        #region Temperatura

        /// <summary>
        /// The <see cref="Temperatura" /> property's name.
        /// </summary>
        public const string TemperaturaPropertyName = "Temperatura";

        private int? _temperatura;

        /// <summary>
        /// Sets and gets the Temperatura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Temperatura
        {
            get
            {
                return _temperatura;
            }

            set
            {
                if (_temperatura == value)
                {
                    return;
                }

                _temperatura = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TemperaturaPropertyName);
            }
        }

        #endregion
        
        //

        #region IsOperacionPredefinidaEnabled

        /// <summary>
        /// The <see cref="IsOperacionPredefinidaEnabled" /> property's name.
        /// </summary>
        public const string IsOperacionPredefinidaEnabledPropertyName = "IsOperacionPredefinidaEnabled";

        private bool _isOperacionPredefinidaEnabled;

        /// <summary>
        /// Sets and gets the IsOperacionPredefinidaEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsOperacionPredefinidaEnabled
        {
            get
            {
                return _isOperacionPredefinidaEnabled;
            }

            set
            {
                if (_isOperacionPredefinidaEnabled == value)
                {
                    return;
                }

                _isOperacionPredefinidaEnabled = value;
                RaisePropertyChanged(IsOperacionPredefinidaEnabledPropertyName);
            }
        }

        #endregion

        public List<OperacionPredefinida> OperacionPredefinidaList { get; set; }
        
        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaInstruccionPredefinidaEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, InstruccionPredefinida instruccionPredefinida)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                OperacionPredefinidaId = 1000;
                Descripcion = "Operacion Predefinida No. 001000";
                Orden = 10;
                TiempoMinimo = 10;
                TiempoMaximo = 20;
                Temperatura = 80;
            }
            else
            {
                _instruccionPredefinida = instruccionPredefinida;
                Id = instruccionPredefinida.Id;
                OperacionPredefinidaId = instruccionPredefinida.OperacionPredefinidaId;
                Descripcion = instruccionPredefinida.Descripcion;
                Orden = instruccionPredefinida.Orden;
                TiempoMinimo = instruccionPredefinida.TiempoMinimo;
                TiempoMaximo = instruccionPredefinida.TiempoMaximo;
                Temperatura = instruccionPredefinida.Temperatura;
            }

            RegisterCommands();
            LoadData();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void LoadData()
        {
            _dataService.OperacionPredefinidaGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    OperacionPredefinidaList = new List<OperacionPredefinida>(lista);
                });
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _instruccionPredefinida.Id = Id;
            _instruccionPredefinida.OperacionPredefinidaId = OperacionPredefinidaId;
            _instruccionPredefinida.Descripcion = Descripcion;
            _instruccionPredefinida.Orden = Orden;
            _instruccionPredefinida.TiempoMinimo = TiempoMinimo;
            _instruccionPredefinida.TiempoMaximo = TiempoMaximo;
            _instruccionPredefinida.Temperatura = Temperatura;

            _dataService.InstruccionPredefinidaUpdate(_instruccionPredefinida,
                (updated, error) =>
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
            return _instruccionPredefinida.OperacionPredefinidaId != OperacionPredefinidaId ||
                   _instruccionPredefinida.Descripcion != Descripcion ||
                   _instruccionPredefinida.Orden != Orden ||
                   _instruccionPredefinida.TiempoMinimo != TiempoMinimo ||
                   _instruccionPredefinida.TiempoMaximo != TiempoMaximo ||
                   _instruccionPredefinida.Temperatura != Temperatura;
        }

        #endregion
    }
}