using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LineaDetalleEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private LineaDetalle _lineaDetalle;
        private readonly bool _init;

        #region Properties

        #region Grupo

        /// <summary>
        /// The <see cref="Grupo" /> property's name.
        /// </summary>
        public const string GrupoPropertyName = "Grupo";

        private Grupo _grupo;

        /// <summary>
        /// Sets and gets the Grupo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Grupo Grupo
        {
            get
            {
                return _grupo;
            }

            set
            {
                if (_grupo == value)
                {
                    return;
                }

                _grupo = value;
                RaisePropertyChanged(GrupoPropertyName);
            }
        }

        #endregion

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

        #region LineaId

        /// <summary>
        /// The <see cref="LineaId" /> property's name.
        /// </summary>
        public const string LineaIdPropertyName = "LineaId";

        private int _lineaId;

        /// <summary>
        /// Sets and gets the LineaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LineaId
        {
            get
            {
                return _lineaId;
            }

            set
            {
                if (_lineaId == value)
                {
                    return;
                }

                _lineaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LineaIdPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private int _myProperty;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoId
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
                if (_init)
                {
                    ConfirmCommand.RaiseCanExecuteChanged();
                }
                LoadModulos();
                RaisePropertyChanged(CentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region ModuloId

        /// <summary>
        /// The <see cref="ModuloId" /> property's name.
        /// </summary>
        public const string ModuloIdPropertyName = "ModuloId";

        private int _moduloId;

        /// <summary>
        /// Sets and gets the ModuloId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ModuloId
        {
            get
            {
                return _moduloId;
            }

            set
            {
                if (_moduloId == value)
                {
                    return;
                }

                _moduloId = value;
                RaisePropertyChanged(ModuloIdPropertyName);
            }
        }

        #endregion

        #region EsSalidaUnica

        /// <summary>
        /// The <see cref="EsSalidaUnica" /> property's name.
        /// </summary>
        public const string EsSalidaUnicaPropertyName = "EsSalidaUnica";

        private bool _esSalidaUnica;

        /// <summary>
        /// Sets and gets the EsSalidaUnica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsSalidaUnica
        {
            get
            {
                return _esSalidaUnica;
            }

            set
            {
                if (_esSalidaUnica == value)
                {
                    return;
                }

                _esSalidaUnica = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EsSalidaUnicaPropertyName);
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

        #region EsLineaEnabled

        /// <summary>
        /// The <see cref="EsLineaEnabled" /> property's name.
        /// </summary>
        public const string EsLineaEnabledPropertyName = "EsLineaEnabled";

        private bool _esLiuneaEnabled;

        /// <summary>
        /// Sets and gets the EsLineaEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsLineaEnabled
        {
            get
            {
                return _esLiuneaEnabled;
            }

            set
            {
                if (_esLiuneaEnabled == value)
                {
                    return;
                }

                _esLiuneaEnabled = value;
                RaisePropertyChanged(EsLineaEnabledPropertyName);
            }
        }

        #endregion

        #region LineaList

        /// <summary>
        /// The <see cref="LineaList" /> property's name.
        /// </summary>
        public const string LineaListPropertyName = "LineaList";

        private ObservableCollection<Linea> _lineaList;

        /// <summary>
        /// Sets and gets the LineaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Linea> LineaList
        {
            get
            {
                return _lineaList;
            }

            set
            {
                if (_lineaList == value)
                {
                    return;
                }

                _lineaList = value;
                RaisePropertyChanged(LineaListPropertyName);
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

        #region ModuloList

        /// <summary>
        /// The <see cref="ModuloList" /> property's name.
        /// </summary>
        public const string ModuloListPropertyName = "ModuloList";

        private ObservableCollection<Modulo> _moduloList;

        /// <summary>
        /// Sets and gets the ModuloList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Modulo> ModuloList
        {
            get
            {
                return _moduloList;
            }

            set
            {
                if (_moduloList == value)
                {
                    return;
                }

                _moduloList = value;
                RaisePropertyChanged(ModuloListPropertyName);
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

        public LineaDetalleEditViewModel(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo, LineaDetalle lineaDetalle)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _grupo = grupo;
            _lineaDetalle = lineaDetalle;

            _init = false;

            LoadCombos();

            if (IsInDesignMode)
            {
                Id = 1;
                LineaId = 2;
                CentroTrabajoId = 3;
                ModuloId = 4;
                EsSalidaUnica = true;
                Secuencia = 10;
                _grupo = new Grupo
                {
                    Id = 1,
                    Codigo = "000001",
                    Nombre = "Grupo No. 000001",
                    Estado = true,
                    FechaInicio = new DateTime(2019, 1, 4),
                    FechaFinal = new DateTime(2016, 1, 11),
                    Secuencia = 10
                };
                _lineaDetalle = new LineaDetalle
                {
                    Id = 1,
                    LineaId = 2,
                    CentroTrabajoId = 3,
                    ModuloId = 4,
                    EsSalidaUnica = true,
                    Secuencia = 10
                };
                EsLineaEnabled = false;
            }
            else
            {
                _lineaDetalle = lineaDetalle;
                Id = lineaDetalle.Id;
                LineaId = lineaDetalle.LineaId;
                CentroTrabajoId = lineaDetalle.CentroTrabajoId;
                ModuloId = lineaDetalle.ModuloId;
                EsLineaEnabled = lineaDetalle.EsSalidaUnica;
                Secuencia = lineaDetalle.Secuencia;

                EsLineaEnabled = false;
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
            _dataService.LineaGetByGrupo(_grupo.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    LineaList = new ObservableCollection<Linea>(lista);
                });

            _dataService.CentroTrabajoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    CentroTrabajoList = new ObservableCollection<CentroTrabajo>(lista);
                });
        }

        private void LoadModulos()
        {
            _dataService.ModuloGetAll(CentroTrabajoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    ModuloList = new ObservableCollection<Modulo>(lista);
                });
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _lineaDetalle.LineaId = LineaId;
            _lineaDetalle.CentroTrabajoId = CentroTrabajoId;
            _lineaDetalle.ModuloId = ModuloId;
            _lineaDetalle.EsSalidaUnica = EsSalidaUnica;
            _lineaDetalle.Secuencia = Secuencia;
            _dataService.LineaDetalleUpdate(_lineaDetalle,
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
            return _lineaDetalle.LineaId != LineaId ||
                   _lineaDetalle.CentroTrabajoId != CentroTrabajoId ||
                   _lineaDetalle.ModuloId != ModuloId ||
                   _lineaDetalle.EsSalidaUnica != EsSalidaUnica ||
                   _lineaDetalle.Secuencia != Secuencia;
        }

        #endregion
    }
}