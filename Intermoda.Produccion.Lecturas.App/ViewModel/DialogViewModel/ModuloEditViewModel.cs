using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class ModuloEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private Modulo _modulo;
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(IdPropertyName);
            }
        }

        #endregion

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private string _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Codigo
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
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

        #region Secuencia

        /// <summary>
        /// The <see cref="Secuencia" /> property's name.
        /// </summary>
        public const string SecuenciaPropertyName = "Secuencia";

        private int _secuencia;

        /// <summary>
        /// Sets and gets the Secuencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Secuencia
        {
            get
            {
                return _secuencia;
            }

            set
            {
                if (_secuencia == value)
                {
                    return;
                }

                _secuencia = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(SecuenciaPropertyName);
            }
        }

        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private bool _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EstadoPropertyName);
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

        #region CentroTrabajoList

        /// <summary>
        /// The <see cref="CentroTrabajoList" /> property's name.
        /// </summary>
        public const string CentroTrabajoListPropertyName = "CentroTrabajoList";

        private List<CentroTrabajo> _centroTrabajoList;

        /// <summary>
        /// Sets and gets the CentroTrabajoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public List<CentroTrabajo> CentroTrabajoList
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

        #region EsCentroTrabajoEnabled

        /// <summary>
        /// The <see cref="EsCentroTrabajoEnabled" /> property's name.
        /// </summary>
        public const string EsCentroTrabajoEnabledPropertyName = "EsCentroTrabajoEnabled";

        private bool _esCentroTrabajoEnabled;

        /// <summary>
        /// Sets and gets the EsCentroTrabajoEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsCentroTrabajoEnabled
        {
            get
            {
                return _esCentroTrabajoEnabled;
            }

            set
            {
                if (_esCentroTrabajoEnabled == value)
                {
                    return;
                }

                _esCentroTrabajoEnabled = value;
                RaisePropertyChanged(EsCentroTrabajoEnabledPropertyName);
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

        public ModuloEditViewModel(IDataServiceLectura dataService, IDialogService dialogService, Modulo modulo)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            LoadCombos();

            if (IsInDesignMode)
            {
                Id = 1;
                Codigo = "000001";
                Nombre = "Módulo No. 000001";
                Secuencia = 10;
                Estado = true;
                CentroTrabajoId = 1000;

                _modulo = new Modulo
                {
                    Id = 1,
                    Codigo = "000001",
                    Nombre = "Módulo No. 000001",
                    Secuencia = 10,
                    Estado = true,
                    CentroTrabajoId = 1000
                };
                EsCentroTrabajoEnabled = false;
            }
            else
            {
                _modulo = modulo;
                Id = modulo.Id;
                Codigo = modulo.Codigo;
                Nombre = modulo.Nombre;
                Secuencia = modulo.Secuencia;
                Estado = modulo.Estado;
                CentroTrabajoId = modulo.CentroTrabajoId;

                EsCentroTrabajoEnabled = CentroTrabajoId == 0;
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

        private void LoadCombos()
        {
            _dataService.CentroTrabajoGetActivos(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    CentroTrabajoList = new List<CentroTrabajo>(lista);
                });
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _modulo.Codigo = Codigo;
            _modulo.Nombre = Nombre;
            _modulo.Secuencia = Secuencia;
            _modulo.Estado = Estado;
            _modulo.CentroTrabajoId = CentroTrabajoId;
            _dataService.ModuloUpdate(_modulo,
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
            return _modulo.Codigo != Codigo ||
                   _modulo.Nombre != Nombre ||
                   _modulo.Secuencia != Secuencia ||
                   _modulo.Estado != Estado ||
                   _modulo.CentroTrabajoId != CentroTrabajoId;
        }

        #endregion
    }
}