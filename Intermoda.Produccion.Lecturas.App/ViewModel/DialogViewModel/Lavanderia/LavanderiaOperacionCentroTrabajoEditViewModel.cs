using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOperacionCentroTrabajoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private OperacionCentroTrabajo _operacionCentroTrabajo;
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

        #region OperacionCodigo

        /// <summary>
        /// The <see cref="OperacionCodigo" /> property's name.
        /// </summary>
        public const string OperacionCodigoPropertyName = "OperacionCodigo";

        private short _operacionCodigo;

        /// <summary>
        /// Sets and gets the OperacionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short OperacionCodigo
        {
            get
            {
                return _operacionCodigo;
            }

            set
            {
                if (_operacionCodigo == value)
                {
                    return;
                }

                _operacionCodigo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OperacionCodigoPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoCodigo

        /// <summary>
        /// The <see cref="CentroTrabajoCodigo" /> property's name.
        /// </summary>
        public const string CentroTrabajoCodigoPropertyName = "CentroTrabajoCodigo";

        private int _centroTrabajoCodigo;

        /// <summary>
        /// Sets and gets the CentroTrabajoCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoCodigo
        {
            get
            {
                return _centroTrabajoCodigo;
            }

            set
            {
                if (_centroTrabajoCodigo == value)
                {
                    return;
                }

                _centroTrabajoCodigo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CentroTrabajoCodigoPropertyName);
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

        #region EsRepetible

        /// <summary>
        /// The <see cref="EsRepetible" /> property's name.
        /// </summary>
        public const string EsRepetiblePropertyName = "EsRepetible";

        private int? _esRepetible;

        /// <summary>
        /// Sets and gets the EsRepetible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? EsRepetible
        {
            get
            {
                return _esRepetible;
            }

            set
            {
                if (_esRepetible == value)
                {
                    return;
                }

                _esRepetible = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EsRepetiblePropertyName);
            }
        }

        #endregion

        public List<CentroTrabajo> CentroTrabajoList { get; set; }

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
                RaisePropertyChanged(CentroTrabajoSelectedPropertyName);
            }
        }

        #endregion

        public List<Operacion> OperacionList { get; set; }

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
                RaisePropertyChanged(OperacionSelectedPropertyName);
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

        public LavanderiaOperacionCentroTrabajoEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, OperacionCentroTrabajo operacionCentroTrabajo)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _operacionCentroTrabajo = operacionCentroTrabajo;

            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                OperacionCodigo = 10;
                CentroTrabajoCodigo = 20;
                CentroTrabajoNombre = "Nombre del Centro de Trabajo No. 000020";
                EsRepetible = 1;
            }
            else
            {
                _operacionCentroTrabajo = operacionCentroTrabajo;
                Id = _operacionCentroTrabajo.Id;
                OperacionCodigo = _operacionCentroTrabajo.OperacionCodigo;
                CentroTrabajoCodigo = _operacionCentroTrabajo.CentroTrabajoCodigo;
                CentroTrabajoNombre = _operacionCentroTrabajo.CentroTrabajoNombre;
                EsRepetible = _operacionCentroTrabajo.EsRepetible;
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
            _operacionCentroTrabajo.OperacionCodigo = OperacionCodigo;
            _operacionCentroTrabajo.CentroTrabajoCodigo = CentroTrabajoCodigo;
            _operacionCentroTrabajo.CentroTrabajoNombre = CentroTrabajoSelected.Nombre;
            _operacionCentroTrabajo.EsRepetible = EsRepetible;
            
            _dataService.OperacionCentroTrabajoUpdate(_operacionCentroTrabajo,
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
            return _operacionCentroTrabajo.OperacionCodigo != OperacionCodigo ||
                   _operacionCentroTrabajo.CentroTrabajoCodigo != CentroTrabajoCodigo ||
                   _operacionCentroTrabajo.EsRepetible != EsRepetible;
        }

        #endregion
    }
}