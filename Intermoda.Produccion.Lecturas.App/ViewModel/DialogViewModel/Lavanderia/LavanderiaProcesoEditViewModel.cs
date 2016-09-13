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
    public class LavanderiaProcesoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private Proceso _proceso;
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

        #region EsActivo

        /// <summary>
        /// The <see cref="EsActivo" /> property's name.
        /// </summary>
        public const string EsActivoPropertyName = "EsActivo";

        private bool _esActivo;

        /// <summary>
        /// Sets and gets the EsActivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsActivo
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

        #region EsObligatorio

        /// <summary>
        /// The <see cref="EsObligatorio" /> property's name.
        /// </summary>
        public const string EsObligatorioPropertyName = "EsObligatorio";

        private bool _esObligatorio;

        /// <summary>
        /// Sets and gets the EsObligatorio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsObligatorio
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EsCentroTrabajoEnabledPropertyName);
            }
        }

        #endregion

        public CentroTrabajo CentroTrabajo { get; set; }

        public List<CentroTrabajo> CentroTrabajoList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaProcesoEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Proceso proceso)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            LoadCombos();

            if (IsInDesignMode)
            {
                Id = 1;
                Nombre = "Centro de Trabajo No. 000001";
                Descripcion = "Descripción del Centro de Trabajo No. 000001";
                Secuencia = 10;
                EsActivo = true;
                EsObligatorio = true;
                CentroTrabajoId = 1000;
                TiempoEstandar = 23;
                CentroTrabajo = new CentroTrabajo
                {
                    Codigo = 1000,
                    Nombre = "Centro de Trabajo No. 001000",
                    EsObligatorio = true,
                    EsActivo = true,
                    LineaProduccionCodigo = 2000,
                    Observacion = "Observaciones del Centro de Trabajo No. 001000",
                    Orden = 10,
                    TiempoEspera = 10,
                    TiempoProceso = 20
                };
            }
            else
            {
                _proceso = proceso;
                Id = proceso.Id;
                Nombre = proceso.Nombre;
                Descripcion = proceso.Descripcion;
                Secuencia = proceso.Secuencia;
                EsActivo = proceso.EsActivo;
                EsObligatorio = proceso.EsObligatorio;
                CentroTrabajoId = proceso.CentroTrabajoId;
                TiempoEstandar = proceso.TiempoEstandar;
                CentroTrabajo = proceso.CentroTrabajo;
                EsCentroTrabajoEnabled = CentroTrabajo != null;
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
            _dataService.CentroTrabajoGetAllLavanderia(
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
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _proceso.Nombre = Nombre;
            _proceso.Descripcion = Descripcion;
            _proceso.CentroTrabajoId = CentroTrabajoId;
            _proceso.EsActivo = EsActivo;
            _proceso.EsObligatorio = EsObligatorio;
            _proceso.Secuencia = Secuencia;
            _proceso.TiempoEstandar = TiempoEstandar;
            _dataService.ProcesoUpdate(_proceso,
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
            return _proceso.Nombre != Nombre ||
                   _proceso.Descripcion != Descripcion ||
                   _proceso.CentroTrabajoId != CentroTrabajoId ||
                   _proceso.EsActivo != EsActivo ||
                   _proceso.EsObligatorio != EsObligatorio ||
                   _proceso.Secuencia != Secuencia ||
                   _proceso.TiempoEstandar != TiempoEstandar;
        }

        #endregion
    }
}