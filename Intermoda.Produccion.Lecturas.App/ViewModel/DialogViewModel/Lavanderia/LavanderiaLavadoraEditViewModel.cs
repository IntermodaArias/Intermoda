using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaLavadoraEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private Lavadora _lavadora;
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
                if(_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(NombrePropertyName);
            }
        }

        #endregion

        #region LavadoraCapacidadId

        /// <summary>
        /// The <see cref="LavadoraCapacidadId" /> property's name.
        /// </summary>
        public const string LavadoraCapacidadIdPropertyName = "LavadoraCapacidadId";

        private short _lavadoraCapacidadId;

        /// <summary>
        /// Sets and gets the LavadoraCapacidadId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short LavadoraCapacidadId
        {
            get
            {
                return _lavadoraCapacidadId;
            }

            set
            {
                if (_lavadoraCapacidadId == value)
                {
                    return;
                }

                _lavadoraCapacidadId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoraCapacidadIdPropertyName);
            }
        }

        #endregion

        #region Marca

        /// <summary>
        /// The <see cref="Marca" /> property's name.
        /// </summary>
        public const string MarcaPropertyName = "Marca";

        private string _marca;

        /// <summary>
        /// Sets and gets the Marca property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Marca
        {
            get
            {
                return _marca;
            }

            set
            {
                if (_marca == value)
                {
                    return;
                }

                _marca = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(MarcaPropertyName);
            }
        }

        #endregion

        #region Modelo

        /// <summary>
        /// The <see cref="Modelo" /> property's name.
        /// </summary>
        public const string ModeloPropertyName = "Modelo";

        private string _modelo;

        /// <summary>
        /// Sets and gets the Modelo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Modelo
        {
            get
            {
                return _modelo;
            }

            set
            {
                if (_modelo == value)
                {
                    return;
                }

                _modelo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ModeloPropertyName);
            }
        }

        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private short _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Estado
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

        #region NumeroSerie

        /// <summary>
        /// The <see cref="NumeroSerie" /> property's name.
        /// </summary>
        public const string NumeroSeriePropertyName = "NumeroSerie";

        private string _numeroSerie;

        /// <summary>
        /// Sets and gets the NumeroSerie property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NumeroSerie
        {
            get
            {
                return _numeroSerie;
            }

            set
            {
                if (_numeroSerie == value)
                {
                    return;
                }

                _numeroSerie = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(NumeroSeriePropertyName);
            }
        }

        #endregion

        #region DireccionIp

        /// <summary>
        /// The <see cref="DireccionIp" /> property's name.
        /// </summary>
        public const string DireccionIpPropertyName = "DireccionIp";

        private string _direccionIp;

        /// <summary>
        /// Sets and gets the DireccionIp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DireccionIp
        {
            get
            {
                return _direccionIp;
            }

            set
            {
                if (_direccionIp == value)
                {
                    return;
                }

                _direccionIp = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(DireccionIpPropertyName);
            }
        }

        #endregion

        #region DireccionMac

        /// <summary>
        /// The <see cref="DireccionMac" /> property's name.
        /// </summary>
        public const string DireccionMacPropertyName = "DireccionMac";

        private string _direccionMac;

        /// <summary>
        /// Sets and gets the DireccionMac property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DireccionMac
        {
            get
            {
                return _direccionMac;
            }

            set
            {
                if (_direccionMac == value)
                {
                    return;
                }

                _direccionMac = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(DireccionMacPropertyName);
            }
        }

        #endregion

        #region State

        /// <summary>
        /// The <see cref="State" /> property's name.
        /// </summary>
        public const string StatePropertyName = "State";

        private bool _state;

        /// <summary>
        /// Sets and gets the State property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool State
        {
            get
            {
                return _state;
            }

            set
            {
                if (_state == value)
                {
                    return;
                }

                _state = value;
                Estado = value ? (short)1 : (short)0;
                RaisePropertyChanged(StatePropertyName);
            }
        }

        #endregion

        #region LavadoraCapacidad

        /// <summary>
        /// The <see cref="LavadoraCapacidad" /> property's name.
        /// </summary>
        public const string LavadoraCapacidadPropertyName = "LavadoraCapacidad";

        private string _lavadoraCapacidad;

        /// <summary>
        /// Sets and gets the LavadoraCapacidad property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoraCapacidad
        {
            get
            {
                return _lavadoraCapacidad;
            }

            set
            {
                if (_lavadoraCapacidad == value)
                {
                    return;
                }

                _lavadoraCapacidad = value;
                RaisePropertyChanged(LavadoraCapacidadPropertyName);
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

        public LavanderiaLavadoraEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Lavadora lavadora)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                Nombre = "Lavadora No. 001";
                LavadoraCapacidadId = 1;
                Marca = "Marca de la Lavadora No. 001";
                Modelo = "Modelo de la Lavadora No. 001";
                Estado = 1;
                NumeroSerie = "ABC123456789XYZ";
                DireccionIp = "192.168.125.125";
                DireccionMac = "1234567890ABCDEF";
            }
            else
            {
                _lavadora = lavadora;
                Id = 1;
                Nombre = lavadora.Nombre;
                LavadoraCapacidadId = lavadora.LavadoraCapacidadId;
                Marca = lavadora.Marca;
                Modelo = lavadora.Modelo;
                Estado = lavadora.Estado;
                NumeroSerie = lavadora.NumeroSerie;
                DireccionIp = lavadora.DireccionIp;
                DireccionMac = lavadora.DireccionMac;
            }

            _dataService.LavadoraCapacidadGet(lavadora.LavadoraCapacidadId,
                (reg, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    LavadoraCapacidad = reg.Capacidad;
                });

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
            _lavadora.Nombre = Nombre;
            _lavadora.LavadoraCapacidadId = LavadoraCapacidadId;
            _lavadora.Marca = Marca;
            _lavadora.Modelo = Modelo;
            _lavadora.Estado = Estado;
            _lavadora.NumeroSerie = NumeroSerie;
            _lavadora.DireccionIp = DireccionIp;
            _lavadora.DireccionMac = DireccionMac;

            _dataService.LavadoraUpdate(_lavadora,
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
            return _lavadora.Nombre == Nombre ||
                   _lavadora.LavadoraCapacidadId == LavadoraCapacidadId ||
                   _lavadora.Marca == Marca ||
                   _lavadora.Modelo == Modelo ||
                   _lavadora.Estado == Estado ||
                   _lavadora.NumeroSerie == NumeroSerie ||
                   _lavadora.DireccionIp == DireccionIp ||
                   _lavadora.DireccionMac == DireccionMac;
        }

        #endregion
    }
}