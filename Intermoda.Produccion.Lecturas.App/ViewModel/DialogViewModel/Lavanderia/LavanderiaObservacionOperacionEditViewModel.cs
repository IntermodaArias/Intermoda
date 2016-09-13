using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaObservacionOperacionEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private ObservacionOperacion _observacionOperacion;
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

        #region Posicion

        /// <summary>
        /// The <see cref="Posicion" /> property's name.
        /// </summary>
        public const string PosicionPropertyName = "Posicion";

        private int? _posicion;

        /// <summary>
        /// Sets and gets the Posicion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Posicion
        {
            get
            {
                return _posicion;
            }

            set
            {
                if (_posicion == value)
                {
                    return;
                }

                _posicion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(PosicionPropertyName);
            }
        }

        #endregion

        public OperacionProceso OperacionProceso { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaObservacionOperacionEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, ObservacionOperacion observacionOperacion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.ObservacionOperacionGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _observacionOperacion = reg;
                        Initialize();
                    });
            }
            else
            {
                _observacionOperacion = observacionOperacion;
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
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _observacionOperacion.Descripcion = Descripcion;
            _observacionOperacion.Orden = Orden;
            _observacionOperacion.Posicion = Posicion;

            _dataService.ObservacionOperacionUpdate(_observacionOperacion,
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
            return _observacionOperacion.Descripcion != Descripcion ||
                   _observacionOperacion.Orden != Orden ||
                   _observacionOperacion.Posicion != Posicion;
        }

        private void Initialize()
        {
            Id = _observacionOperacion.Id;
            Descripcion = _observacionOperacion.Descripcion;
            OperacionProcesoId = _observacionOperacion.OperacionProcesoId;
            Orden = _observacionOperacion.Orden;
            Posicion = _observacionOperacion.Posicion;
            OperacionProceso = _observacionOperacion.OperacionProceso;
        }

        #endregion
    }
}