using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Produccion.Lecturas.Client;
using Intermoda.Produccion.Lecturas.Client.DataServices;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class CentroTrabajoEditViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;
        
        private CentroTrabajo _centroTrabajo;
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

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }
        
        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public CentroTrabajoEditViewModel(IDataService dataService, IDialogService dialogService, CentroTrabajo centroTrabajo)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                Codigo = "000001";
                Nombre = "Centro de Trabajo No. 000001";
                Secuencia = 10;
                Estado = true;
                _centroTrabajo = new CentroTrabajo
                {
                    Id = Id,
                    Codigo = Codigo,
                    Nombre = Nombre,
                    Secuencia = Secuencia,
                    Estado = Estado
                };
            }
            else
            {
                _centroTrabajo = centroTrabajo;
                Id = centroTrabajo.Id;
                Codigo = centroTrabajo.Codigo;
                Nombre = centroTrabajo.Nombre;
                Secuencia = centroTrabajo.Secuencia;
                Estado = centroTrabajo.Estado;
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
            _centroTrabajo.Codigo = Codigo;
            _centroTrabajo.Nombre = Nombre;
            _centroTrabajo.Secuencia = Secuencia;
            _centroTrabajo.Estado = Estado;
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
            return _centroTrabajo.Codigo != Codigo ||
                       _centroTrabajo.Nombre != Nombre ||
                       _centroTrabajo.Secuencia != Secuencia ||
                       _centroTrabajo.Estado != Estado;
        }

        #endregion
    }
}