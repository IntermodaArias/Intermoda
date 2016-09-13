using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaInstruccionOperacionEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private InstruccionOperacion _instruccionOperacion;
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

        #region OperacionProcesoId

        /// <summary>
        /// The <see cref="OperacionProcesoId" /> property's name.
        /// </summary>
        public const string OperacionProcesoIdPropertyName = "OperacionProcesoId";

        private int _operacionProcesoId;

        /// <summary>
        /// Sets and gets the OperacionProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionProcesoId
        {
            get
            {
                return _operacionProcesoId;
            }

            set
            {
                if (_operacionProcesoId == value)
                {
                    return;
                }

                _operacionProcesoId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OperacionProcesoIdPropertyName);
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

        #region TiempoEstandar

        /// <summary>
        /// The <see cref="TiempoEstandar" /> property's name.
        /// </summary>
        public const string TiempoEstandarPropertyName = "TiempoEstandar";

        private decimal? _tiempoEstandar;

        /// <summary>
        /// Sets and gets the TiempoEstandar property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoEstandar
        {
            get
            {
                return _tiempoEstandar;
            }

            set
            {
                if (_tiempoEstandar == value)
                {
                    return;
                }

                _tiempoEstandar = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TiempoEstandarPropertyName);
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

        public Operacion Operacion { get; set; }
        
        public Action CloseAction { get; set; }
        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaInstruccionOperacionEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, InstruccionOperacion instruccionOperacion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.InstruccionOperacionGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _instruccionOperacion = reg;
                        Initialize();
                    });
            }
            else
            {
                _instruccionOperacion = instruccionOperacion;
                Initialize();
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
            _instruccionOperacion.Descripcion = Descripcion;
            _instruccionOperacion.TiempoMinimo = TiempoMinimo;
            _instruccionOperacion.TiempoMaximo = TiempoMaximo;
            _instruccionOperacion.TiempoEstandar = TiempoEstandar;
            _instruccionOperacion.Temperatura = Temperatura;
            _instruccionOperacion.Orden = Orden;

            _dataService.InstruccionOperacionUpdate(_instruccionOperacion,
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
            return _instruccionOperacion.Descripcion != Descripcion ||
                   _instruccionOperacion.TiempoMinimo != TiempoMinimo ||
                   _instruccionOperacion.TiempoMaximo != TiempoMaximo ||
                   _instruccionOperacion.TiempoEstandar != TiempoEstandar ||
                   _instruccionOperacion.Temperatura != Temperatura ||
                   _instruccionOperacion.Orden != Orden;
        }

        private void Initialize()
        {
            Id = _instruccionOperacion.Id;
            OperacionProcesoId = _instruccionOperacion.OperacionProcesoId;
            Descripcion = _instruccionOperacion.Descripcion;
            TiempoMinimo = _instruccionOperacion.TiempoMinimo;
            TiempoMaximo = _instruccionOperacion.TiempoMaximo;
            TiempoEstandar = _instruccionOperacion.TiempoEstandar;
            Temperatura = _instruccionOperacion.Temperatura;
            Orden = _instruccionOperacion.Orden;
            Operacion = _instruccionOperacion.OperacionProceso.Operacion;
        }

        #endregion
    }
}