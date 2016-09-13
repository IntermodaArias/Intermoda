using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaCentroTrabajoOpcionEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private CentroTrabajoOpcion _centroTrabajoOpcion;
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

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private int _centroTrabajoId;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoId
        {
            get
            {
                return _centroTrabajoId;
            }

            set
            {
                if (_centroTrabajoId == value)
                {
                    return;
                }

                _centroTrabajoId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoNombre

        /// <summary>
        /// The <see cref="CentroTrabajoNombre" /> property's name.
        /// </summary>
        public const string CentroTrabajoNombrePropertyName = "CentroTrabajoNombre";

        private string _centroTrabajoNombre;

        /// <summary>
        /// Sets and gets the CentroTrabajoNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoNombre
        {
            get
            {
                return _centroTrabajoNombre;
            }

            set
            {
                if (_centroTrabajoNombre == value)
                {
                    return;
                }

                _centroTrabajoNombre = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CentroTrabajoNombrePropertyName);
            }
        }

        #endregion

        #region CentroTrabajoObservacion

        /// <summary>
        /// The <see cref="CentroTrabajoObservacion" /> property's name.
        /// </summary>
        public const string CentroTrabajoObservacionPropertyName = "CentroTrabajoObservacion";

        private string _centroTrabajoObservacion;

        /// <summary>
        /// Sets and gets the CentroTrabajoObservacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoObservacion
        {
            get
            {
                return _centroTrabajoObservacion;
            }

            set
            {
                if (_centroTrabajoObservacion == value)
                {
                    return;
                }

                _centroTrabajoObservacion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CentroTrabajoObservacionPropertyName);
            }
        }

        #endregion

        #region OpcionId

        /// <summary>
        /// The <see cref="OpcionId" /> property's name.
        /// </summary>
        public const string OpcionIdPropertyName = "OpcionId";

        private int _opcionId;

        /// <summary>
        /// Sets and gets the OpcionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OpcionId
        {
            get
            {
                return _opcionId;
            }

            set
            {
                if (_opcionId == value)
                {
                    return;
                }

                _opcionId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OpcionIdPropertyName);
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

        #region CentroTrabajoList

        /// <summary>
        /// The <see cref="CentroTrabajoList" /> property's name.
        /// </summary>
        public const string CentroTrabajoListPropertyName = "CentroTrabajoList";

        private ObservableCollection<CentroTrabajo> _centroTrabajoList;

        /// <summary>
        /// Sets and gets the CentroTrabajoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<CentroTrabajo> CentroTrabajoList
        {
            get
            {
                return _centroTrabajoList;
            }

            set
            {
                if (_centroTrabajoList == value)
                {
                    return;
                }

                _centroTrabajoList = value;
                RaisePropertyChanged(CentroTrabajoListPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoSelected

        /// <summary>
        /// The <see cref="CentroTrabajoSelected" /> property's name.
        /// </summary>
        public const string CentroTrabajoSelectedPropertyName = "CentroTrabajoSelected";

        private CentroTrabajo _centroTrabajoSelected;

        /// <summary>
        /// Sets and gets the CentroTrabajoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajo CentroTrabajoSelected
        {
            get
            {
                return _centroTrabajoSelected;
            }

            set
            {
                if (_centroTrabajoSelected == value)
                {
                    return;
                }

                _centroTrabajoSelected = value;
                if (_init)
                {
                    CentroTrabajoNombre = value.Nombre;
                    CentroTrabajoObservacion = value.Observacion;
                }
                RaisePropertyChanged(CentroTrabajoSelectedPropertyName);
            }
        }

        #endregion

        public OpcionLavado OpcionLavado { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaCentroTrabajoOpcionEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService,
            CentroTrabajoOpcion centroTrabajoOpcion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.CentroTrabajoOpcionGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _centroTrabajoOpcion = reg;
                    });
            }
            else
            {
                if (centroTrabajoOpcion == null || centroTrabajoOpcion.OpcionId == 0 ||
                    centroTrabajoOpcion.OpcionLavado == null)
                {
                    _dialogService.ShowMessage(
                        "No se ha especificado datos base o no se ha especificado Opcion de Lavado",
                        "Error");
                    Cancel();
                }
                _centroTrabajoOpcion = centroTrabajoOpcion;
            }

            Id = _centroTrabajoOpcion.Id;
            CentroTrabajoNombre = _centroTrabajoOpcion.CentroTrabajoNombre;
            CentroTrabajoObservacion = _centroTrabajoOpcion.CentroTrabajoObservacion;
            OpcionId = _centroTrabajoOpcion.OpcionId;
            Orden = _centroTrabajoOpcion.Orden;

            OpcionLavado = _centroTrabajoOpcion.OpcionLavado;

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
            _dataService.CentroTrabajoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    CentroTrabajoList = new ObservableCollection<CentroTrabajo>(lista);
                });
        }

        private void Cancel()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _centroTrabajoOpcion.CentroTrabajoId = CentroTrabajoId;
            _centroTrabajoOpcion.CentroTrabajoNombre = CentroTrabajoNombre;
            _centroTrabajoOpcion.CentroTrabajoObservacion = CentroTrabajoObservacion;
            _centroTrabajoOpcion.Orden = Orden;

            _dataService.CentroTrabajoOpcionUpdate(_centroTrabajoOpcion,
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
            return _centroTrabajoOpcion.CentroTrabajoId != CentroTrabajoId ||
                   _centroTrabajoOpcion.CentroTrabajoNombre != CentroTrabajoNombre ||
                   _centroTrabajoOpcion.CentroTrabajoObservacion != CentroTrabajoObservacion ||
                   _centroTrabajoOpcion.OpcionId != OpcionId ||
                   _centroTrabajoOpcion.Orden != Orden;
        }

        #endregion
    }
}