using System;
using System.Runtime.InteropServices;
using System.Security;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Common;

namespace Intermoda.Maquilado.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IDataServiceLbDatPro _dataService;

        #region Properties

        #region Usuario

        /// <summary>
        /// The <see cref="Usuario" /> property's name.
        /// </summary>
        public const string UsuarioPropertyName = "Usuario";

        private string _usuario;

        /// <summary>
        /// Sets and gets the Usuario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                if (_usuario == value)
                {
                    return;
                }

                _usuario = value;
                ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(UsuarioPropertyName);
            }
        }

        #endregion

        #region Clave

        /// <summary>
        /// The <see cref="Clave" /> property's name.
        /// </summary>
        public const string ClavePropertyName = "Clave";

        private SecureString _clave;

        /// <summary>
        /// Sets and gets the Clave property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SecureString Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                if (_clave == value)
                {
                    return;
                }

                _clave = value;
                ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ClavePropertyName);
            }
        }

        #endregion

        public Planta Planta { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand ConfirmCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel(IDataServiceLbDatPro dataService)
        {
            _dataService = dataService;

            RegisterCommands();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void Confirm()
        {
            _dataService.PlantaGetByUsuario(Usuario, SecureStringToString(Clave),
                (planta, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }

                    //Messenger.Default.Send(new LoginMessage {Planta = planta});
                    Planta = planta;

                    OnRequestClose?.Invoke(this,new EventArgs());
                });
        }

        private bool CanConfirm()
        {
            return !string.IsNullOrWhiteSpace(Usuario) && 
                !string.IsNullOrWhiteSpace(SecureStringToString(Clave));
        }

        private string SecureStringToString(SecureString value)
        {
            if (value == null) return "";

            var valuePtr = IntPtr.Zero;
            try
            {
                valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
                return Marshal.PtrToStringUni(valuePtr);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
            }
        }

        #endregion
    }
}