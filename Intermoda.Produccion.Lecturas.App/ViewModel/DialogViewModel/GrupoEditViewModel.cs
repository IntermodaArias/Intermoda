using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class GrupoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private Grupo _grupo;
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

        #region FechaInicio

        /// <summary>
        /// The <see cref="FechaInicio" /> property's name.
        /// </summary>
        public const string FechaInicioPropertyName = "FechaInicio";

        private DateTime _fechaInicio;

        /// <summary>
        /// Sets and gets the FechaInicio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                if (_fechaInicio == value)
                {
                    return;
                }

                _fechaInicio = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(FechaInicioPropertyName);
            }
        }

        #endregion

        #region FechaFinal

        /// <summary>
        /// The <see cref="FechaFinal" /> property's name.
        /// </summary>
        public const string FechaFinalPropertyName = "FechaFinal";

        private DateTime _fechaFinal;

        /// <summary>
        /// Sets and gets the FechaFinal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaFinal
        {
            get
            {
                return _fechaFinal;
            }

            set
            {
                if (_fechaFinal == value)
                {
                    return;
                }

                _fechaFinal = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(FechaFinalPropertyName);
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

        public GrupoEditViewModel(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                FechaInicio = new DateTime(2016,1,4);
                FechaFinal = new DateTime(2016,1,10);
                Codigo = "000001";
                Nombre = "Grupo No. 000001";
                Secuencia = 10;
                Estado = true;
                _grupo = new Grupo
                {
                    Id = Id,
                    FechaInicio = FechaInicio,
                    FechaFinal = FechaFinal,
                    Codigo = Codigo,
                    Nombre = Nombre,
                    Secuencia = Secuencia,
                    Estado = Estado
                };
            }
            else
            {
                _grupo = grupo;
                Id = grupo.Id;
                FechaInicio = grupo.FechaInicio;
                FechaFinal = grupo.FechaFinal;
                Codigo = grupo.Codigo;
                Nombre = grupo.Nombre;
                Secuencia = grupo.Secuencia;
                Estado = grupo.Estado;
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
            _grupo.FechaInicio = FechaInicio;
            _grupo.FechaFinal = FechaFinal;
            _grupo.Codigo = Codigo;
            _grupo.Nombre = Nombre;
            _grupo.Secuencia = Secuencia;
            _grupo.Estado = Estado;
            _dataService.GrupoUpdate(_grupo,
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
            return _grupo.FechaInicio != FechaInicio ||
                   _grupo.FechaFinal != FechaFinal ||
                   _grupo.Codigo != Codigo ||
                   _grupo.Nombre != Nombre ||
                   _grupo.Secuencia != Secuencia ||
                   _grupo.Estado != Estado;
        }

        #endregion
    }
}