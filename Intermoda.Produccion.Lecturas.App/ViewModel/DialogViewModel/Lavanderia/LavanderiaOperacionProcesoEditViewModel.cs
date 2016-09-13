using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOperacionProcesoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private OperacionProceso _operacionProceso;
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

        #region OperacionId

        /// <summary>
        /// The <see cref="OperacionId" /> property's name.
        /// </summary>
        public const string OperacionIdPropertyName = "OperacionId";

        private int _operacionId;

        /// <summary>
        /// Sets and gets the OperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionId
        {
            get
            {
                return _operacionId;
            }

            set
            {
                if (_operacionId == value)
                {
                    return;
                }

                _operacionId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OperacionIdPropertyName);
            }
        }

        #endregion

        #region ProcesoId

        /// <summary>
        /// The <see cref="ProcesoId" /> property's name.
        /// </summary>
        public const string ProcesoIdPropertyName = "ProcesoId";

        private int _procesoId;

        /// <summary>
        /// Sets and gets the ProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ProcesoId
        {
            get
            {
                return _procesoId;
            }

            set
            {
                if (_procesoId == value)
                {
                    return;
                }

                _procesoId = value;
                RaisePropertyChanged(ProcesoIdPropertyName);
            }
        }

        #endregion

        #region ProcesoCentroTrabajoId

        /// <summary>
        /// The <see cref="ProcesoCentroTrabajoId" /> property's name.
        /// </summary>
        public const string ProcesoCentroTrabajoIdPropertyName = "ProcesoCentroTrabajoId";

        private int _procesoCentroTrabajoId;

        /// <summary>
        /// Sets and gets the ProcesoCentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ProcesoCentroTrabajoId
        {
            get
            {
                return _procesoCentroTrabajoId;
            }

            set
            {
                if (_procesoCentroTrabajoId == value)
                {
                    return;
                }

                _procesoCentroTrabajoId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ProcesoCentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region Temperatura

        /// <summary>
        /// The <see cref="Temperatura" /> property's name.
        /// </summary>
        public const string TemperaturaPropertyName = "Temperatura";

        private int _temperatura;

        /// <summary>
        /// Sets and gets the Temperatura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Temperatura
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

        #region Ph

        /// <summary>
        /// The <see cref="Ph" /> property's name.
        /// </summary>
        public const string PhPropertyName = "Ph";

        private string _ph;

        /// <summary>
        /// Sets and gets the Ph property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Ph
        {
            get
            {
                return _ph;
            }

            set
            {
                if (_ph == value)
                {
                    return;
                }

                _ph = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(PhPropertyName);
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

        private decimal? _myProperty;

        /// <summary>
        /// Sets and gets the TiempoEstandar property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoEstandar
        {
            get
            {
                return _myProperty;
            }

            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                _myProperty = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TiempoEstandarPropertyName);
            }
        }

        #endregion

        #region RelacionBano

        /// <summary>
        /// The <see cref="RelacionBano" /> property's name.
        /// </summary>
        public const string RelacionBanoPropertyName = "RelacionBano";

        private int _relacionBano;

        /// <summary>
        /// Sets and gets the RelacionBano property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int RelacionBano
        {
            get
            {
                return _relacionBano;
            }

            set
            {
                if (_relacionBano == value)
                {
                    return;
                }

                _relacionBano = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(RelacionBanoPropertyName);
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


        #region OperacionList

        /// <summary>
        /// The <see cref="OperacionList" /> property's name.
        /// </summary>
        public const string OperacionListPropertyName = "OperacionList";

        private ObservableCollection<Operacion> _operacionList;

        /// <summary>
        /// Sets and gets the OperacionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Operacion> OperacionList
        {
            get
            {
                return _operacionList;
            }

            set
            {
                if (_operacionList == value)
                {
                    return;
                }

                _operacionList = value;
                RaisePropertyChanged(OperacionListPropertyName);
            }
        }

        #endregion

        #region OperacionSelected

        /// <summary>
        /// The <see cref="OperacionSelected" /> property's name.
        /// </summary>
        public const string OperacionSelectedPropertyName = "OperacionSelected";

        private Operacion _operacionSelected;

        /// <summary>
        /// Sets and gets the OperacionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Operacion OperacionSelected
        {
            get
            {
                return _operacionSelected;
            }

            set
            {
                if (_operacionSelected == value)
                {
                    return;
                }

                _operacionSelected = value;
                if (_init)
                    OperacionChanged();
                RaisePropertyChanged(OperacionSelectedPropertyName);
            }
        }

        #endregion

        public Proceso Proceso { get; set; }
        public CentroTrabajo CentroTrabajo { get; set; }
        public OpcionLavado OpcionLavado { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaOperacionProcesoEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService,
            OperacionProceso operacionProceso)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.OperacionProcesoGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _operacionProceso = reg;
                        Initialize();
                    });
            }
            else
            {
                if (operacionProceso == null || operacionProceso.ProcesoId == 0 ||
                    operacionProceso.Proceso == null || operacionProceso.ProcesoCentroTrabajoId == 0 ||
                    operacionProceso.ProcesoCentroTrabajo == null || operacionProceso.ProcesoCentroTrabajo.CentroTrabajo == null)
                {
                    _dialogService.ShowMessage("No se han especificados datos base", "Error");
                    Cancel();
                }
                _operacionProceso = operacionProceso;
                Initialize();
            }

            RegisterCommands();
            LoadListas();

            _init = true;
        }
        
        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void LoadListas()
        {
            _dataService.OperacionGetAllLavanderia(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OperacionList = new ObservableCollection<Operacion>(lista);
                });

            _dataService.ProcesoGet(_operacionProceso.ProcesoId,
                (reg, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    Proceso = reg;
                });

            _dataService.CentroTrabajoGet(_operacionProceso.ProcesoCentroTrabajo.CentroTrabajoId,
                (reg, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    CentroTrabajo = reg;
                });
        }

        private void Cancel()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _operacionProceso.OperacionId = OperacionId;
            _operacionProceso.Temperatura = Temperatura;
            _operacionProceso.TiempoMinimo = TiempoMinimo;
            _operacionProceso.TiempoMaximo = TiempoMaximo;
            _operacionProceso.TiempoEstandar = TiempoEstandar;
            _operacionProceso.RelacionBano = RelacionBano;
            _operacionProceso.Orden = Orden;

            _dataService.OperacionProcesoUpdate(_operacionProceso,
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
            return _operacionProceso.OperacionId != OperacionId ||
                   _operacionProceso.Temperatura != Temperatura ||
                   _operacionProceso.TiempoMinimo != TiempoMinimo ||
                   _operacionProceso.TiempoMaximo != TiempoMaximo ||
                   _operacionProceso.TiempoEstandar != TiempoEstandar ||
                   _operacionProceso.RelacionBano != RelacionBano ||
                   _operacionProceso.Orden != Orden;
        }

        private void Initialize()
        {
            Id = _operacionProceso.Id;
            OperacionId = _operacionProceso.OperacionId;
            ProcesoId = _operacionProceso.ProcesoId;
            ProcesoCentroTrabajoId = _operacionProceso.ProcesoCentroTrabajoId;
            Temperatura = _operacionProceso.Temperatura;
            TiempoMinimo = _operacionProceso.TiempoMinimo;
            TiempoMaximo = _operacionProceso.TiempoMaximo;
            TiempoEstandar = _operacionProceso.TiempoEstandar;
            RelacionBano = _operacionProceso.RelacionBano;
            Orden = _operacionProceso.Orden;

            OpcionLavado = _operacionProceso.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado;
            CentroTrabajo = _operacionProceso.ProcesoCentroTrabajo.CentroTrabajo;
            Proceso = _operacionProceso.Proceso;
        }

        private void OperacionChanged()
        {
            Temperatura = OperacionSelected.OperacionPredefinida.Temperatura;
            Ph = OperacionSelected.OperacionPredefinida.Ph;
            TiempoMinimo = OperacionSelected.OperacionPredefinida.TiempoMinimo;
            TiempoMaximo = OperacionSelected.OperacionPredefinida.TiempoMaximo;
            RelacionBano = OperacionSelected.OperacionPredefinida.RelacionBano;
        }

        #endregion
    }
}