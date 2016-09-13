using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaProcesoCentroTrabajoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private ProcesoCentroTrabajo _procesoCentroTrabajo;
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ProcesoIdPropertyName);
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

        #region CentroTrabajoOpcionId

        /// <summary>
        /// The <see cref="CentroTrabajoOpcionId" /> property's name.
        /// </summary>
        public const string CentroTrabajoOpcionIdPropertyName = "CentroTrabajoOpcionId";

        private int _centroTrabajoOpcionId;

        /// <summary>
        /// Sets and gets the CentroTrabajoOpcionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoOpcionId
        {
            get
            {
                return _centroTrabajoOpcionId;
            }

            set
            {
                if (_centroTrabajoOpcionId == value)
                {
                    return;
                }

                _centroTrabajoOpcionId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CentroTrabajoOpcionIdPropertyName);
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

        public CentroTrabajo CentroTrabajo { get; set; }
        public OpcionLavado OpcionLavado { get; set; }
        public List<Proceso> ProcesoList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaProcesoCentroTrabajoEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, ProcesoCentroTrabajo procesoCentroTrabajo)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.ProcesoCentroTrabajoGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _procesoCentroTrabajo = reg;
                    });
            }
            else
            {
                if (procesoCentroTrabajo == null || procesoCentroTrabajo.CentroTrabajo == null ||
                    procesoCentroTrabajo.CentroTrabajoId == 0 || procesoCentroTrabajo.CentroTrabajoOpcionId == 0 ||
                    procesoCentroTrabajo.CentroTrabajoOpcion == null)
                {
                    _dialogService.ShowMessage(
                        "No se ha especificado datos base o Centro de Trabajo u Opción de Lavado", "Error");
                    Cancel();
                }
                _procesoCentroTrabajo = procesoCentroTrabajo;
            }

            Id = _procesoCentroTrabajo.Id;
            ProcesoId = _procesoCentroTrabajo.ProcesoId;
            CentroTrabajoId = _procesoCentroTrabajo.CentroTrabajoId;
            CentroTrabajoOpcionId = _procesoCentroTrabajo.CentroTrabajoOpcionId;
            Orden = _procesoCentroTrabajo.Orden;

            CentroTrabajo = _procesoCentroTrabajo.CentroTrabajo;
            OpcionLavado = _procesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado;

            LoadProcesos();
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

        private void LoadProcesos()
        {
            _dataService.ProcesoGetByCentroTrabajo(_procesoCentroTrabajo.CentroTrabajoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ProcesoList = new List<Proceso>(lista);
                });
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _procesoCentroTrabajo.ProcesoId = ProcesoId;
            _procesoCentroTrabajo.Orden = Orden;

            _dataService.ProcesoCentroTrabajoUpdate(_procesoCentroTrabajo,
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
            return _procesoCentroTrabajo.ProcesoId != ProcesoId ||
                   _procesoCentroTrabajo.Orden != Orden;
        }

        #endregion
    }
}