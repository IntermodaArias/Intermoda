using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Maquilado.Helpers;
using Telerik.Windows.Documents.Utils;

namespace Intermoda.Maquilado.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataServiceLbDatPro _dataService;
        private readonly IDialogService _dialogService;
        private List<OrdenProduccionExterno> _ordenes;

        #region Properties
        
        #region Planta

        /// <summary>
        /// The <see cref="Planta" /> property's name.
        /// </summary>
        public const string PlantaPropertyName = "Planta";

        private Planta _planta;

        /// <summary>
        /// Sets and gets the Planta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Planta Planta
        {
            get
            {
                return _planta;
            }

            set
            {
                if (_planta == value)
                {
                    return;
                }

                _planta = value;
                LoadData();
                RaisePropertyChanged(PlantaPropertyName);
            }
        }

        #endregion

        #region OrdenList

        /// <summary>
        /// The <see cref="OrdenList" /> property's name.
        /// </summary>
        public const string OrdenListPropertyName = "OrdenList";

        private ObservableCollection<OrdenProduccionExterno> _ordenList;

        /// <summary>
        /// Sets and gets the OrdenList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<OrdenProduccionExterno> OrdenList
        {
            get
            {
                return _ordenList;
            }

            set
            {
                if (_ordenList == value)
                {
                    return;
                }

                _ordenList = value;
                RaisePropertyChanged(OrdenListPropertyName);
            }
        }

        #endregion

        #region OrdenSelected

        /// <summary>
        /// The <see cref="OrdenSelected" /> property's name.
        /// </summary>
        public const string OrdenSelectedPropertyName = "OrdenSelected";

        private OrdenProduccionExterno _ordenSelected;

        /// <summary>
        /// Sets and gets the OrdenSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OrdenProduccionExterno OrdenSelected
        {
            get
            {
                return _ordenSelected;
            }

            set
            {
                if (_ordenSelected == value)
                {
                    return;
                }

                _ordenSelected = value;
                OrdenChanged();
                RaisePropertyChanged(OrdenSelectedPropertyName);
            }
        }

        #endregion
        
        #region OrdenBusqueda

        /// <summary>
        /// The <see cref="OrdenBusqueda" /> property's name.
        /// </summary>
        public const string OrdenBusquedaPropertyName = "OrdenBusqueda";

        private string _ordenBusqueda = "";

        /// <summary>
        /// Sets and gets the OrdenBusqueda property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OrdenBusqueda
        {
            get
            {
                return _ordenBusqueda;
            }

            set
            {
                if (_ordenBusqueda == value)
                {
                    return;
                }

                _ordenBusqueda = value;
                BusquedaChanged();
                RaisePropertyChanged(OrdenBusquedaPropertyName);
            }
        }

        #endregion

        #region ReferenciaBusqueda

        /// <summary>
        /// The <see cref="ReferenciaBusqueda" /> property's name.
        /// </summary>
        public const string ReferenciaBusquedaPropertyName = "ReferenciaBusqueda";

        private string _referenciaBusqueda = "";

        /// <summary>
        /// Sets and gets the ReferenciaBusqueda property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ReferenciaBusqueda
        {
            get
            {
                return _referenciaBusqueda;
            }

            set
            {
                if (_referenciaBusqueda == value)
                {
                    return;
                }

                _referenciaBusqueda = value;
                BusquedaChanged();
                RaisePropertyChanged(ReferenciaBusquedaPropertyName);
            }
        }

        #endregion

        #region Color

        /// <summary>
        /// The <see cref="Color" /> property's name.
        /// </summary>
        public const string ColorPropertyName = "Color";

        private string _color = "";

        /// <summary>
        /// Sets and gets the Color property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                if (_color == value)
                {
                    return;
                }

                _color = value;
                BusquedaChanged();
                RaisePropertyChanged(ColorPropertyName);
            }
        }

        #endregion

        #region Total

        /// <summary>
        /// The <see cref="Total" /> property's name.
        /// </summary>
        public const string TotalPropertyName = "Total";

        private int _total;

        /// <summary>
        /// Sets and gets the Total property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Total
        {
            get
            {
                return _total;
            }

            set
            {
                if (_total == value)
                {
                    return;
                }

                _total = value;
                RaisePropertyChanged(TotalPropertyName);
            }
        }

        #endregion

        // Visibility de Botones

        #region LoginVisibility

        /// <summary>
        /// The <see cref="LoginVisibility" /> property's name.
        /// </summary>
        public const string LoginVisibilityPropertyName = "LoginVisibility";

        private Visibility _loginVisibility;

        /// <summary>
        /// Sets and gets the LoginVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility LoginVisibility
        {
            get
            {
                return _loginVisibility;
            }

            set
            {
                if (_loginVisibility == value)
                {
                    return;
                }

                _loginVisibility = value;
                RaisePropertyChanged(LoginVisibilityPropertyName);
            }
        }

        #endregion

        #region NoLoginVisibility

        /// <summary>
        /// The <see cref="NoLoginVisibility" /> property's name.
        /// </summary>
        public const string NoLoginVisibilityPropertyName = "NoLoginVisibility";

        private Visibility _noLoginVisibility;

        /// <summary>
        /// Sets and gets the NoLoginVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility NoLoginVisibility
        {
            get
            {
                return _noLoginVisibility;
            }

            set
            {
                if (_noLoginVisibility == value)
                {
                    return;
                }

                _noLoginVisibility = value;
                RaisePropertyChanged(NoLoginVisibilityPropertyName);
            }
        }

        #endregion

        #region IniciarVisibility

        /// <summary>
        /// The <see cref="IniciarVisibility" /> property's name.
        /// </summary>
        public const string IniciarVisibilityPropertyName = "IniciarVisibility";

        private Visibility _iniciarVisibility;

        /// <summary>
        /// Sets and gets the IniciarVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility IniciarVisibility
        {
            get
            {
                return _iniciarVisibility;
            }

            set
            {
                if (_iniciarVisibility == value)
                {
                    return;
                }

                _iniciarVisibility = value;
                RaisePropertyChanged(IniciarVisibilityPropertyName);
            }
        }

        #endregion

        #region FinalizarVisibility

        /// <summary>
        /// The <see cref="FinalizarVisibility" /> property's name.
        /// </summary>
        public const string FinalizarVisibilityPropertyName = "FinalizarVisibility";

        private Visibility _finalizarVisibility;

        /// <summary>
        /// Sets and gets the FinalizarVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility FinalizarVisibility
        {
            get
            {
                return _finalizarVisibility;
            }

            set
            {
                if (_finalizarVisibility == value)
                {
                    return;
                }

                _finalizarVisibility = value;
                RaisePropertyChanged(FinalizarVisibilityPropertyName);
            }
        }

        #endregion

        #region EnviarVisibility

        /// <summary>
        /// The <see cref="EnviarVisibility" /> property's name.
        /// </summary>
        public const string EnviarVisibilityPropertyName = "EnviarVisibility";

        private Visibility _enviarVisibility;

        /// <summary>
        /// Sets and gets the EnviarVisibility property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Visibility EnviarVisibility
        {
            get
            {
                return _enviarVisibility;
            }

            set
            {
                if (_enviarVisibility == value)
                {
                    return;
                }

                _enviarVisibility = value;
                RaisePropertyChanged(EnviarVisibilityPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand IniciarCentroTrabajoCommand { get; set; }
        public RelayCommand FinalizarCentroTrabajoCommand { get; set; }
        public RelayCommand EnviarIntermodaCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel()
        {
            _dialogService = new DialogService();

            if (IsInDesignMode)
            {
                _dataService = new DesignDataServiceLbDatPro();
                _planta = new Planta
                {
                    Id = "XX",
                    BodegaId = 1,
                    Clave = "CLAVE",
                    CompaniaId = 1,
                    Descripcion = "Nombre de la Planta",
                    Estado = "A",
                    GeneraTicket = "S",
                    Habilitar = 1,
                    NuevoId = 1,
                    Iniciales = "NDLP",
                    ProveedorId = 1,
                    Tipo = "E",
                    Usuario = "USUARIO"
                };
                
                LoginVisibility = Visibility.Hidden;
                NoLoginVisibility = Visibility.Collapsed;
            }
            else
            {
                _dataService = new DataServiceLbDatPro();
                LoginVisibility = Visibility.Visible;
                NoLoginVisibility = Visibility.Visible;
            }

            OrdenBusqueda = "";
            ReferenciaBusqueda = "";

            RegisterCommands();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            LoginCommand = new RelayCommand(Login);
            RefreshCommand = new RelayCommand(LoadData);
            IniciarCentroTrabajoCommand = new RelayCommand(LecturaEntrada);
            FinalizarCentroTrabajoCommand = new RelayCommand(LecturaSalida);
            EnviarIntermodaCommand = new RelayCommand(EnviarIntermoda);
        }

        private void Login()
        {
            var planta = _dialogService.Login();

            if (planta == null) return;

            Planta = planta;
            LoginVisibility = Visibility.Hidden;
        }

        private void LoadData()
        {
            NoLoginVisibility = Visibility.Visible;

            _dataService.OrdenProduccionExternoGetByUsuarioPlanta(Planta.Usuario,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    _ordenes = lista.OrderBy(r=>r.OrdenProduccion).ToList();
                    BusquedaChanged();
                });
        }

        private void OrdenChanged()
        {
            if (OrdenSelected == null)
            {
                IniciarVisibility = Visibility.Collapsed;
                FinalizarVisibility = Visibility.Collapsed;
                EnviarVisibility = Visibility.Collapsed;
                return;
            }

            switch (OrdenSelected.SiguienteLecturaTipo)
            {
                case "E": // Entrada
                    IniciarVisibility = Visibility.Visible;
                    FinalizarVisibility = Visibility.Collapsed;
                    EnviarVisibility = Visibility.Collapsed;
                    break;
                case "S": // Salida
                    IniciarVisibility = Visibility.Collapsed;
                    FinalizarVisibility = Visibility.Visible;
                    EnviarVisibility = Visibility.Collapsed;
                    break;
                case "X": // Pendiente de Envio a Intermoda
                    IniciarVisibility = Visibility.Collapsed;
                    FinalizarVisibility = Visibility.Collapsed;
                    EnviarVisibility = Visibility.Visible;
                    break;
            }
        }

        private void BusquedaChanged()
        {
            try
            {
                var lista = _ordenes
                    .Where(o => o.OrdenProduccion.Contains(OrdenBusqueda.ToUpper()))
                    .Where(r => r.Referencia.Contains(ReferenciaBusqueda.ToUpper()))
                    .Where(c => c.ColorDescripcion.ToUpper().Contains(Color.ToUpper()))
                    .ToList();
                Total = lista.Sum(r => r.Cantidad);
                OrdenList = new ObservableCollection<OrdenProduccionExterno>(lista);
                OrdenSelected = OrdenList?.FirstOrDefault();
                NoLoginVisibility = Visibility.Collapsed;

            }
            catch (Exception exception)
            {
                _dialogService.ShowException(new Exception("MainViewModel / BusquedaChanged", exception));
            }
        }

        //private void HandleLogin(LoginMessage message)
        //{
        //    if (message.Planta == null)
                
        //    Planta = message.Planta;
        //}

        private void LecturaEntrada()
        {
            _dataService.OrdenProduccionExternoGrabarLectura(OrdenSelected.CompaniaId, OrdenSelected.Ano,
                OrdenSelected.Numero, OrdenSelected.CentroTrabajoSiguienteId, OrdenSelected.SiguienteLecturaTipo,
                Planta.Usuario.Trim(), error =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LoadData();
                });
        }

        private void LecturaSalida()
        {
            _dataService.OrdenProduccionExternoGrabarLectura(OrdenSelected.CompaniaId, OrdenSelected.Ano,
               OrdenSelected.Numero, OrdenSelected.CentroTrabajoSiguienteId, OrdenSelected.SiguienteLecturaTipo,
               Planta.Usuario.Trim(), error =>
               {
                   if (error != null)
                   {
                       _dialogService.ShowException(error);
                       return;
                   }
                   LoadData();
               });
        }

        private void EnviarIntermoda()
        {
            _dataService.OrdenProduccionExternoSerEstadoEnviarIntermoda(OrdenSelected.CompaniaId, OrdenSelected.Ano,
                OrdenSelected.Numero, error =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LoadData();
                });
        }

        #endregion
    }
}