using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaCentroTrabajoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;
        
        private CentroTrabajo _centroTrabajo;
        private readonly bool _init;

        #region Properties

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private int _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                if (_codigo == value)
                {
                    return;
                }

                _codigo = value;
                RaisePropertyChanged(CodigoPropertyName);
            }
        }

        #endregion

        #region Nombre

        /// <summary>
        /// The <see cref="Nombre" /> property's name.
        /// </summary>
        public const string NombrePropertyName = "Nombre";

        private string _nombre;

        /// <summary>
        /// Sets and gets the Nombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                if (_nombre == value)
                {
                    return;
                }

                _nombre = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(NombrePropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int? _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Orden
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

        #region Observacion

        /// <summary>
        /// The <see cref="Observacion" /> property's name.
        /// </summary>
        public const string ObservacionPropertyName = "Observacion";

        private string _observacion;

        /// <summary>
        /// Sets and gets the Observacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Observacion
        {
            get
            {
                return _observacion;
            }

            set
            {
                if (_observacion == value)
                {
                    return;
                }

                _observacion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ObservacionPropertyName);
            }
        }

        #endregion

        #region TiempoEspera

        /// <summary>
        /// The <see cref="TiempoEspera" /> property's name.
        /// </summary>
        public const string TiempoEsperaPropertyName = "TiempoEspera";

        private decimal? _tiempoEspera;

        /// <summary>
        /// Sets and gets the TiempoEspera property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoEspera
        {
            get
            {
                return _tiempoEspera;
            }

            set
            {
                if (_tiempoEspera == value)
                {
                    return;
                }

                _tiempoEspera = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TiempoEsperaPropertyName);
            }
        }

        #endregion

        #region TiempoProceso

        /// <summary>
        /// The <see cref="TiempoProceso" /> property's name.
        /// </summary>
        public const string TiempoProcesoPropertyName = "TiempoProceso";

        private decimal? _tiempoProceso;

        /// <summary>
        /// Sets and gets the TiempoProceso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoProceso
        {
            get
            {
                return _tiempoProceso;
            }

            set
            {
                if (_tiempoProceso == value)
                {
                    return;
                }

                _tiempoProceso = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TiempoProcesoPropertyName);
            }
        }

        #endregion

        #region LineaProduccionCodigo

        /// <summary>
        /// The <see cref="LineaProduccionCodigo" /> property's name.
        /// </summary>
        public const string LineaProduccionCodigoPropertyName = "LineaProduccionCodigo";

        private int? _lineaProduccionCodigo;

        /// <summary>
        /// Sets and gets the LineaProduccionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? LineaProduccionCodigo
        {
            get
            {
                return _lineaProduccionCodigo;
            }

            set
            {
                if (_lineaProduccionCodigo == value)
                {
                    return;
                }

                _lineaProduccionCodigo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LineaProduccionCodigoPropertyName);
            }
        }

        #endregion

        #region EsObligatorio

        /// <summary>
        /// The <see cref="EsObligatorio" /> property's name.
        /// </summary>
        public const string EsObligatorioPropertyName = "EsObligatorio";

        private bool? _esObligatorio;

        /// <summary>
        /// Sets and gets the EsObligatorio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool? EsObligatorio
        {
            get
            {
                return _esObligatorio;
            }

            set
            {
                if (_esObligatorio == value)
                {
                    return;
                }

                _esObligatorio = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EsObligatorioPropertyName);
            }
        }

        #endregion

        #region EsActivo

        /// <summary>
        /// The <see cref="EsActivo" /> property's name.
        /// </summary>
        public const string EsActivoPropertyName = "EsActivo";

        private bool? _esActivo;

        /// <summary>
        /// Sets and gets the EsActivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool? EsActivo
        {
            get
            {
                return _esActivo;
            }

            set
            {
                if (_esActivo == value)
                {
                    return;
                }

                _esActivo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EsActivoPropertyName);
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

        public LavanderiaCentroTrabajoEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, CentroTrabajo centroTrabajo)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                Codigo = 1;
                Nombre = "Centro de Trabajo No. 000001";
                Observacion = "Observaciones del Centro de Trabajo No. 000001";
                Orden = 10;
                TiempoEspera = 20;
                TiempoProceso = 30;
                LineaProduccionCodigo = 1000;
                EsObligatorio = true;
                EsActivo = true;
            }
            else
            {
                _centroTrabajo = centroTrabajo;
                Codigo = centroTrabajo.Codigo;
                Nombre = centroTrabajo.Nombre;
                Orden = centroTrabajo.Orden;
                Observacion = centroTrabajo.Observacion;
                TiempoEspera = centroTrabajo.TiempoEspera;
                TiempoProceso = centroTrabajo.TiempoProceso;
                LineaProduccionCodigo = centroTrabajo.LineaProduccionCodigo;
                EsObligatorio = centroTrabajo.EsObligatorio;
                EsActivo = centroTrabajo.EsActivo;
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
            _centroTrabajo.Nombre = Nombre;
            _centroTrabajo.Orden = Orden;
            _centroTrabajo.Observacion = Observacion;
            _centroTrabajo.TiempoEspera = TiempoEspera;
            _centroTrabajo.TiempoProceso = TiempoProceso;
            _centroTrabajo.LineaProduccionCodigo = LineaProduccionCodigo;
            _centroTrabajo.EsObligatorio = EsObligatorio;
            _centroTrabajo.EsActivo = EsActivo;

            _dataService.CentroTrabajoUpdate(_centroTrabajo,
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
            return _centroTrabajo.Nombre != Nombre ||
                   _centroTrabajo.Orden != Orden ||
                   _centroTrabajo.Observacion != Observacion ||
                   _centroTrabajo.TiempoEspera != TiempoEspera ||
                   _centroTrabajo.TiempoProceso != TiempoProceso ||
                   _centroTrabajo.LineaProduccionCodigo != LineaProduccionCodigo ||
                   _centroTrabajo.EsObligatorio != EsObligatorio ||
                   _centroTrabajo.EsActivo != EsActivo;
        }

        #endregion
    }
}