using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class JornadaDetalleEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private JornadaDetalle _jornadaDetalle;
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

        #region JornadaId

        /// <summary>
        /// The <see cref="JornadaId" /> property's name.
        /// </summary>
        public const string JornadaIdPropertyName = "JornadaId";

        private int _jornadaId;

        /// <summary>
        /// Sets and gets the JornadaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int JornadaId
        {
            get
            {
                return _jornadaId;
            }

            set
            {
                if (_jornadaId == value)
                {
                    return;
                }

                _jornadaId = value;
                RaisePropertyChanged(JornadaIdPropertyName);
            }
        }

        #endregion

        #region EntradaHora

        /// <summary>
        /// The <see cref="EntradaHora" /> property's name.
        /// </summary>
        public const string EntradaHoraPropertyName = "EntradaHora";

        private int _entradaHora;

        /// <summary>
        /// Sets and gets the EntradaHora property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EntradaHora
        {
            get
            {
                return _entradaHora;
            }

            set
            {
                if (_entradaHora == value)
                {
                    return;
                }

                _entradaHora = value;
                if (_init)
                {
                    Calculate();
                    ConfirmCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(EntradaHoraPropertyName);
            }
        }

        #endregion

        #region EntradaMinuto

        /// <summary>
        /// The <see cref="EntradaMinuto" /> property's name.
        /// </summary>
        public const string EntradaMinutoPropertyName = "EntradaMinuto";

        private int _entradaMinuto;

        /// <summary>
        /// Sets and gets the EntradaMinuto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EntradaMinuto
        {
            get
            {
                return _entradaMinuto;
            }

            set
            {
                if (_entradaMinuto == value)
                {
                    return;
                }

                _entradaMinuto = value;
                if (_init)
                {
                    Calculate();
                    ConfirmCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(EntradaMinutoPropertyName);
            }
        }

        #endregion

        #region SalidaHora

        /// <summary>
        /// The <see cref="SalidaHora" /> property's name.
        /// </summary>
        public const string SalidaHoraPropertyName = "SalidaHora";

        private int _salidaHora;

        /// <summary>
        /// Sets and gets the SalidaHora property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SalidaHora
        {
            get
            {
                return _salidaHora;
            }

            set
            {
                if (_salidaHora == value)
                {
                    return;
                }

                _salidaHora = value;
                if (_init)
                {
                    Calculate();
                    ConfirmCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(SalidaHoraPropertyName);
            }
        }

        #endregion

        #region SalidaMinuto

        /// <summary>
        /// The <see cref="SalidaMinuto" /> property's name.
        /// </summary>
        public const string SalidaMinutoPropertyName = "SalidaMinuto";

        private int _salidaMinuto;

        /// <summary>
        /// Sets and gets the SalidaMinuto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SalidaMinuto
        {
            get
            {
                return _salidaMinuto;
            }

            set
            {
                if (_salidaMinuto == value)
                {
                    return;
                }

                _salidaMinuto = value;
                if (_init)
                {
                    Calculate();
                    ConfirmCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(SalidaMinutoPropertyName);
            }
        }

        #endregion

        #region Horas

        /// <summary>
        /// The <see cref="Horas" /> property's name.
        /// </summary>
        public const string HorasPropertyName = "Horas";

        private int _horas;

        /// <summary>
        /// Sets and gets the Horas property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Horas
        {
            get
            {
                return _horas;
            }

            set
            {
                if (_horas == value)
                {
                    return;
                }

                _horas = value;
                RaisePropertyChanged(HorasPropertyName);
            }
        }

        #endregion

        #region Minutos

        /// <summary>
        /// The <see cref="Minutos" /> property's name.
        /// </summary>
        public const string MinutosPropertyName = "Minutos";

        private int _minutos;

        /// <summary>
        /// Sets and gets the Minutos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Minutos
        {
            get
            {
                return _minutos;
            }

            set
            {
                if (_minutos == value)
                {
                    return;
                }

                _minutos = value;
                RaisePropertyChanged(MinutosPropertyName);
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

        public JornadaDetalleEditViewModel(IDataServiceLectura dataService, IDialogService dialogService, JornadaDetalle jornadaDetalle)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                JornadaId = 1000;
                EntradaHora = 7;
                EntradaMinuto = 0;
                SalidaHora = 12;
                SalidaMinuto = 0;
                Horas = 5;
                Minutos = 0;
                _jornadaDetalle = new JornadaDetalle
                {
                    Id = Id,
                    JornadaId = JornadaId,
                    EntradaHora = EntradaHora,
                    EntradaMinuto = EntradaMinuto,
                    SalidaHora = SalidaHora,
                    SalidaMinuto = SalidaMinuto,
                    Horas = Horas,
                    Minutos = Minutos
                };
            }
            else
            {
                _jornadaDetalle = jornadaDetalle;
                Id = jornadaDetalle.Id;
                JornadaId = jornadaDetalle.JornadaId;
                EntradaHora = jornadaDetalle.EntradaHora;
                EntradaMinuto = jornadaDetalle.EntradaMinuto;
                SalidaHora = jornadaDetalle.SalidaHora;
                SalidaMinuto = jornadaDetalle.SalidaMinuto;
                Horas = jornadaDetalle.Horas;
                Minutos = jornadaDetalle.Minutos;
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
            _jornadaDetalle.JornadaId = JornadaId;
            _jornadaDetalle.EntradaHora = EntradaHora;
            _jornadaDetalle.EntradaMinuto = EntradaMinuto;
            _jornadaDetalle.SalidaHora = SalidaHora;
            _jornadaDetalle.SalidaMinuto = SalidaMinuto;
            _jornadaDetalle.Horas = Horas;
            _jornadaDetalle.Minutos = Minutos;

            _dataService.JornadaDetalleUpdate(_jornadaDetalle,
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
            return _jornadaDetalle.EntradaHora != EntradaHora ||
                   _jornadaDetalle.EntradaMinuto != EntradaMinuto ||
                   _jornadaDetalle.SalidaHora != SalidaHora ||
                   _jornadaDetalle.SalidaMinuto != SalidaMinuto ||
                   _jornadaDetalle.Horas != Horas ||
                   _jornadaDetalle.Minutos != Minutos;
        }

        private void Calculate()
        {
            var minutosEntrada = EntradaHora*60 + EntradaMinuto;
            var minutosSalida = SalidaHora*60 + SalidaMinuto;

            var minutos = 0;
            if (minutosSalida < minutosEntrada)
            {
                minutos = minutosSalida - minutosEntrada;
            }
            else
            {
                var minutosMediaNoche = 24*60;
                minutos = minutosMediaNoche - minutosEntrada + minutosSalida;
            }

            Horas = (int) Math.Truncate((decimal) minutos/60);
            Minutos = minutos - Horas*60;
        }

        #endregion
    }
}