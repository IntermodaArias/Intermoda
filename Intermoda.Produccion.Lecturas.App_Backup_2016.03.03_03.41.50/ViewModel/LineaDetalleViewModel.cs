using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Produccion.Lecturas.Client;
using Intermoda.Produccion.Lecturas.Client.DataServices;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LineaDetalleViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        private int _grupoId;
        private LineaDetalle _lineaDetalle;
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
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

        private bool _esLineaEnabled;

        /// <summary>
        /// Sets and gets the EsLineaEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsLineaEnabled
        {
            get
            {
                return _esLineaEnabled;
            }

            set
            {
                if (_esLineaEnabled == value)
                {
                    return;
                }

                _esLineaEnabled = value;
                RaisePropertyChanged(EsLineaEnabledPropertyName);
            }
        }

        #endregion

        public List<Linea> LineaList { get; set; }
        public List<CentroTrabajo> CentroTrabajoList { get; set; }
        public List<Modulo> ModuloList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LineaDetalleViewModel(IDataService dataService, IDialogService dialogService,int grupoId, LineaDetalle lineaDetalle)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            LoadCombos();

            if (IsInDesignMode)
            {
                Id = 1;
                LineaId = 1000;
                CentroTrabajoId = 10;
                ModuloId = 10;
                EsSalidaUnica = true;
                Secuencia = 10;
                _lineaDetalle = new LineaDetalle
                {
                    Id = Id,
                    LineaId = LineaId,
                    CentroTrabajoId = CentroTrabajoId,
                    ModuloId = ModuloId,
                    EsSalidaUnica = EsSalidaUnica,
                    Secuencia = Secuencia
                };
                EsLineaEnabled = false;
            }
            else
            {
                _grupoId = grupoId;
                _lineaDetalle = lineaDetalle;
                Id = lineaDetalle.Id;
                LineaId = lineaDetalle.LineaId;
                CentroTrabajoId = lineaDetalle.CentroTrabajoId;
                ModuloId = lineaDetalle.ModuloId;
                EsSalidaUnica = lineaDetalle.EsSalidaUnica;
                Secuencia = lineaDetalle.Secuencia;

                EsLineaEnabled = LineaId == 0;
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
            _dataService.LineaGetByGrupo(_grupoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    LineaList = new List<Linea>(lista);
                });
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
                    ModuloList = new List<Modulo>(lista);
                });
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _lineaDetalle.LineaId= LineaId;
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