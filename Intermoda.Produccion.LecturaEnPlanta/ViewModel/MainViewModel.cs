using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.LecturaEnPlanta;
using Intermoda.Produccion.LecturaEnPlanta.Classes;

namespace Intermoda.Produccion.LecturaEnPlanta.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataServiceLecturaPlanta _dataService;

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
                RaisePropertyChanged(UsuarioPropertyName);
            }
        }

        #endregion

        #region UsuarioIsReadOnly

        /// <summary>
        /// The <see cref="UsuarioIsReadOnly" /> property's name.
        /// </summary>
        public const string UsuarioIsReadOnlyPropertyName = "UsuarioIsReadOnly";

        private bool _usuarioIsReadOnly;

        /// <summary>
        /// Sets and gets the UsuarioIsReadOnly property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool UsuarioIsReadOnly
        {
            get
            {
                return _usuarioIsReadOnly;
            }

            set
            {
                if (_usuarioIsReadOnly == value)
                {
                    return;
                }

                _usuarioIsReadOnly = value;
                RaisePropertyChanged(UsuarioIsReadOnlyPropertyName);
            }
        }

        #endregion

        #region LoginButtonVisibility

        /// <summary>
        /// The <see cref="LoginButtonVisibility" /> property's name.
        /// </summary>
        public const string LoginButtonVisibilityPropertyName = "LoginButtonVisibility";

        private Visibility _loginButtonVisibility = Visibility.Visible;

        /// <summary>
        /// Sets and gets the LoginButtonVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility LoginButtonVisibility
        {
            get
            {
                return _loginButtonVisibility;
            }

            set
            {
                if (_loginButtonVisibility == value)
                {
                    return;
                }

                _loginButtonVisibility = value;
                RaisePropertyChanged(LoginButtonVisibilityPropertyName);
            }
        }

        #endregion

        #region LogoutButtonVisibility

        /// <summary>
        /// The <see cref="LogoutButtonVisibility" /> property's name.
        /// </summary>
        public const string LogoutButtonVisibilityPropertyName = "LogoutButtonVisibility";

        private Visibility _logoutButtonVisibility = Visibility.Collapsed;

        /// <summary>
        /// Sets and gets the LogoutButtonVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility LogoutButtonVisibility
        {
            get
            {
                return _logoutButtonVisibility;
            }

            set
            {
                if (_logoutButtonVisibility == value)
                {
                    return;
                }

                _logoutButtonVisibility = value;
                RaisePropertyChanged(LogoutButtonVisibilityPropertyName);
            }
        }

        #endregion

        #region Cupon

        /// <summary>
        /// The <see cref="Cupon" /> property's name.
        /// </summary>
        public const string CuponPropertyName = "Cupon";

        private string _cupon;

        /// <summary>
        /// Sets and gets the Cupon property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Cupon
        {
            get
            {
                return _cupon;
            }

            set
            {
                if (_cupon == value)
                {
                    return;
                }

                _cupon = value;
                CuponChanged();
                RaisePropertyChanged(CuponPropertyName);
            }
        }

        #endregion

        #region CuponIsReadOnly

        /// <summary>
        /// The <see cref="CuponIsReadOnly" /> property's name.
        /// </summary>
        public const string CuponIsReadOnlyPropertyName = "CuponIsReadOnly";

        private bool _cuponIsReadOnly = true;

        /// <summary>
        /// Sets and gets the CuponIsReadOnly property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool CuponIsReadOnly
        {
            get
            {
                return _cuponIsReadOnly;
            }

            set
            {
                if (_cuponIsReadOnly == value)
                {
                    return;
                }

                _cuponIsReadOnly = value;
                RaisePropertyChanged(CuponIsReadOnlyPropertyName);
            }
        }

        #endregion

        #region ErrorMensaje

        /// <summary>
        /// The <see cref="ErrorMensaje" /> property's name.
        /// </summary>
        public const string ErrorMensajePropertyName = "ErrorMensaje";

        private string _errorMensaje = "Error: ....";

        /// <summary>
        /// Sets and gets the ErrorMensaje property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ErrorMensaje
        {
            get
            {
                return _errorMensaje;
            }

            set
            {
                if (_errorMensaje == value)
                {
                    return;
                }

                _errorMensaje = value;
                RaisePropertyChanged(ErrorMensajePropertyName);
            }
        }

        #endregion

        #region ErrorMensajeVisibility

        /// <summary>
        /// The <see cref="ErrorMensajeVisibility" /> property's name.
        /// </summary>
        public const string ErrorMensajeVisibilityPropertyName = "ErrorMensajeVisibility";

        private Visibility _errorMensajeVisibility = Visibility.Hidden;

        /// <summary>
        /// Sets and gets the ErrorMensajeVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility ErrorMensajeVisibility
        {
            get
            {
                return _errorMensajeVisibility;
            }

            set
            {
                if (_errorMensajeVisibility == value)
                {
                    return;
                }

                _errorMensajeVisibility = value;
                RaisePropertyChanged(ErrorMensajeVisibilityPropertyName);
            }
        }

        #endregion

        #region CuponList

        /// <summary>
        /// The <see cref="CuponList" /> property's name.
        /// </summary>
        public const string CuponListPropertyName = "CuponList";

        private ObservableCollection<Boleta> _cuponList = new ObservableCollection<Boleta>();

        /// <summary>
        /// Sets and gets the CuponList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Boleta> CuponList
        {
            get
            {
                return _cuponList;
            }

            set
            {
                if (_cuponList == value)
                {
                    return;
                }

                _cuponList = value;
                CuponListChanged();
                RaisePropertyChanged(CuponListPropertyName);
            }
        }

        #endregion

        #region CuponCount

        /// <summary>
        /// The <see cref="CuponCount" /> property's name.
        /// </summary>
        public const string CuponCountPropertyName = "CuponCount";

        private int _cuponCount;

        /// <summary>
        /// Sets and gets the CuponCount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CuponCount
        {
            get
            {
                return _cuponCount;
            }

            set
            {
                if (_cuponCount == value)
                {
                    return;
                }

                _cuponCount = value;
                RaisePropertyChanged(CuponCountPropertyName);
            }
        }

        #endregion

        #region ConnectingVisibility

        /// <summary>
        /// The <see cref="ConnectingVisibility" /> property's name.
        /// </summary>
        public const string ConnectingVisibilityPropertyName = "ConnectingVisibility";

        private Visibility _coneectingVisibility = Visibility.Hidden;

        /// <summary>
        /// Sets and gets the ConnectingVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility ConnectingVisibility
        {
            get
            {
                return _coneectingVisibility;
            }

            set
            {
                if (_coneectingVisibility == value)
                {
                    return;
                }

                _coneectingVisibility = value;
                RaisePropertyChanged(ConnectingVisibilityPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand LogoutCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(IDataServiceLecturaPlanta dataService)
        {
            _dataService = dataService;

            if (IsInDesignMode)
            {
                CuponList = new ObservableCollection<Boleta>
                {
                    new Boleta {Cupon = "1228170101111"},
                    new Boleta {Cupon = "1228170101112"},
                    new Boleta {Cupon = "1228170102111"},
                    new Boleta {Cupon = "1228170102112"}
                };
                ErrorMensajeVisibility = Visibility.Visible;
            }
            else
            {
                ErrorMensajeVisibility = Visibility.Hidden;
            }

            RegisterCommands();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            LoginCommand = new RelayCommand(Login);
            LogoutCommand = new RelayCommand(Logout);
        }

        private void Login()
        {
            UsuarioIsReadOnly = true;
            Usuario = Usuario.ToUpper();
            _dataService.ValidaUsuario(Usuario.Trim(),
                (vrf, error) =>
                {
                    if (error != null)
                    {
                        ErrorMensajeVisibility = Visibility.Visible;
                        ErrorMensaje = error.Message;
                        UsuarioIsReadOnly = false;
                        return;
                    }
                    ErrorMensajeVisibility = Visibility.Hidden;
                    UsuarioIsReadOnly = true;
                    LoginButtonVisibility = Visibility.Collapsed;
                    LogoutButtonVisibility = Visibility.Visible;
                    CuponIsReadOnly = false;
                });
        }

        private void Logout()
        {
            CuponList = new ObservableCollection<Boleta>();
            Usuario = "";
            UsuarioIsReadOnly = false;
            LoginButtonVisibility = Visibility.Visible;
            LogoutButtonVisibility = Visibility.Collapsed;
            CuponIsReadOnly = true;
        }

        private void CuponChanged()
        {
            if (Cupon.Trim().Length == 0)
            {
                return;
            }

            if (Cupon.Trim().Length < 13)
            {
                ErrorMensajeVisibility = Visibility.Visible;
                ErrorMensaje = $"El Cupón solo tiene {Cupon.Trim().Length} caracteres.";
            }
            else
            {
                if (CuponList.Any(r => r.Cupon.ToUpper().Trim() == Cupon.ToUpper().Trim()))
                {
                    ErrorMensajeVisibility = Visibility.Visible;
                    ErrorMensaje = "El cupón ingresado ya fue leído en esta sesión.";
                    Cupon = "";
                    return;
                }

                CuponIsReadOnly = true;
                ConnectingVisibility = Visibility.Visible;
                _dataService.ProcesaCupon(Usuario, Cupon,
                    (vrf, error) =>
                    {
                        if (error != null)
                        {
                            ErrorMensajeVisibility = Visibility.Visible;
                            ErrorMensaje = error.Message;
                            CuponIsReadOnly = false;
                            ConnectingVisibility = Visibility.Hidden;
                            return;
                        }
                        ErrorMensajeVisibility = Visibility.Hidden;
                        CuponList.Add(new Boleta { Cupon = Cupon });
                        CuponListChanged();
                        Cupon = "";
                        CuponIsReadOnly = false;
                        ConnectingVisibility = Visibility.Hidden;
                    });
            }
        }

        private void CuponListChanged()
        {
            CuponCount = CuponList.Count;
        }

        #endregion
    }
}