using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Produccion.Lecturas.App.Helpers; 
using Intermoda.Produccion.Lecturas.App.Messages;
using Intermoda.Produccion.Lecturas.App.View;
using Intermoda.Produccion.Lecturas.App.View.Lavanderia;
using Intermoda.Wpf.Controls;
using Telerik.Windows.Controls;
using ViewModelBase = GalaSoft.MvvmLight.ViewModelBase;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private int _lastId;

        #region Properties

        #region TabList

        /// <summary>
        /// The <see cref="TabList" /> property's name.
        /// </summary>
        public const string TabListPropertyName = "TabList";

        private ObservableCollection<RadTabItem> _tabList;

        /// <summary>
        /// Sets and gets the TabList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<RadTabItem> TabList
        {
            get { return _tabList; }

            set
            {
                if (_tabList == value)
                {
                    return;
                }

                _tabList = value;
                RaisePropertyChanged(TabListPropertyName);
            }
        }

        #endregion

        #region TabSelected

        /// <summary>
        /// The <see cref="TabSelected" /> property's name.
        /// </summary>
        public const string TabSelectedPropertyName = "TabSelected";

        private RadTabItem _tabSelected;

        /// <summary>
        /// Sets and gets the TabSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RadTabItem TabSelected
        {
            get { return _tabSelected; }

            set
            {
                if (_tabSelected == value)
                {
                    return;
                }

                _tabSelected = value;
                RaisePropertyChanged(TabSelectedPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        #region Definiciones

        public RelayCommand CentroTrabajoCommand { get; set; }
        public RelayCommand GrupoCommand { get; set; }
        public RelayCommand TurnoCommand { get; set; }
        public RelayCommand JornadaCommand { get; set; }

        public RelayCommand ReporteTestCommand { get; set; }

        #endregion

        #region Lavandería

        public RelayCommand LavanderiaOperacionesCommand { get; set; }
        public RelayCommand LavanderiaProcesosCommand { get; set; }
        public RelayCommand LavanderiaColoresCommand { get; set; }
        public RelayCommand LavanderiaLavadosCommand { get; set; }
        public RelayCommand LavanderiaLavadoraCommand { get; set; }
        public RelayCommand LavanderiaSecadoraCommand { get; set; }

        #endregion

        //public RelayCommand CloseTabCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(IDataServiceLectura dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }

            _lastId = 0;

            Messenger.Default.Register<TablItemCloseMessage>(this, TabItemClose);

            TabList = new ObservableCollection<RadTabItem>();

            RegisterCommands();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            #region Definiciones

            CentroTrabajoCommand = new RelayCommand(TabCentroTrabajo);
            GrupoCommand = new RelayCommand(TabGrupo);
            JornadaCommand = new RelayCommand(TabJornada);
            TurnoCommand = new RelayCommand(TabTurno);

            ReporteTestCommand = new RelayCommand(ReporteTest);

            #endregion

            #region Lavandería

            LavanderiaOperacionesCommand = new RelayCommand(TabLavanderiaOperaciones);
            LavanderiaProcesosCommand = new RelayCommand(TabLavanderiaProcesos);
            LavanderiaColoresCommand = new RelayCommand(TabLavanderiaColor);
            LavanderiaLavadosCommand = new RelayCommand(TabLavanderiaLavado);
            LavanderiaLavadoraCommand = new RelayCommand(TabLavanderiaLavadora);
            LavanderiaSecadoraCommand = new RelayCommand(TabLavanderiaSecadora);

            #endregion
        }

        #region Definiciones

        private void TabCentroTrabajo()
        {
            var tab = VerificaExistenciaControl("CentroTrabajo");

            if (tab == null)
            {
                _lastId ++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Centro de Trabajo",
                    Id = _lastId
                };
                var header = new TabHeader {DataContext = vmHeader};

                tab = new RadTabItem
                {
                    Tag = new Tag {Id = _lastId, Control = "CentroTrabajo"},
                    Header = header,
                    Content = new CentroTrabajoView()
                };

                TabList.Add(tab);
                TabSelected = tab;
            }
            else
            {
                TabSelected = tab;
            }
        }

        private void TabGrupo()
        {
            var tab = VerificaExistenciaControl("Grupo");

            if (tab == null)
            {
                _lastId ++;
                var vmheader = new TabItemHeaderViewModel
                {
                    HeaderText = "Grupo",
                    Id = _lastId
                };
                var header = new TabHeader {DataContext = vmheader};

                tab = new RadTabItem
                {
                    Tag = new Tag {Id = _lastId, Control = "Grupo"},
                    Header = header,
                    Content = new GrupoView()
                };

                TabList.Add(tab);
                TabSelected = tab;
            }
            else
            {
                TabSelected = tab;
            }
        }

        private void TabJornada()
        {
            var tab = VerificaExistenciaControl("Jornada");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Jornada",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "Jornada" },
                    Header = header,
                    Content = new JornadaView()
                };

                TabList.Add(tab);
                TabSelected = tab;
            }
            else
            {
                TabSelected = tab;
            }
        }

        private void TabTurno()
        {
            var tab = VerificaExistenciaControl("Turno");

            if (tab == null)
            {
                _lastId ++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Turno",
                    Id = _lastId
                };
                var header = new TabHeader {DataContext = vmHeader};

                tab = new RadTabItem
                {
                    Tag = new Tag {Id = _lastId, Control = "Turno"},
                    Header = header,
                    Content = new TurnoView()
                };

                TabList.Add(tab);
                TabSelected = tab;
            }
            else
            {
                TabSelected = tab;
            }
        }

        private void ReporteTest()
        {
            var tab = VerificaExistenciaControl("ReporteTest");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Reporte Test",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "ReporteTest" },
                    Header = header,
                    Content = new ReportTest()
                };

                TabList.Add(tab);
                TabSelected = tab;
            }
            else
            {
                TabSelected = tab;
            }
        }

        #endregion

        #region Lavandería

        private void TabLavanderiaProcesos()
        {
            var tab = VerificaExistenciaControl("LavanderiaProcesos");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Procesos de Lavandería",
                    Id = _lastId
                };
                var header = new TabHeader {DataContext = vmHeader};

                tab = new RadTabItem
                {
                    Tag = new Tag {Id = _lastId, Control = "LavanderiaProcesos"},
                    Header = header,
                    Content = new LavanderiaCentroTrabajoView()
                };
                TabList.Add(tab);
            }
            TabSelected = tab;
        }

        private void TabLavanderiaOperaciones()
        {
            var tab = VerificaExistenciaControl("LavanderiaOperaciones");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Operaciones de Lavandería",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "LavanderiaOperaciones" },
                    Header = header,
                    Content = new LavanderiaOperacionView()
                };
                TabList.Add(tab);
            }
            TabSelected = tab;
        }

        private void TabLavanderiaColor()
        {
            var tab = VerificaExistenciaControl("LavanderiaColores");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Colores de Intermoda",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "LavanderiaColores" },
                    Header = header,
                    Content = new LavanderiaColoresView()
                };
                TabList.Add(tab);
            }
            TabSelected = tab;
        }

        private void TabLavanderiaLavado()
        {
            var tab = VerificaExistenciaControl("LavanderiaLavado");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Lavados",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "LavanderiaLavado" },
                    Header = header,
                    Content = new LavanderiaLavadoView()
                };
                TabList.Add(tab);
            }
            TabSelected = tab;
        }

        private void TabLavanderiaLavadora()
        {
            var tab = VerificaExistenciaControl("LavanderiaLavadora");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Lavadoras",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "LavanderiaLavadora" },
                    Header = header,
                    Content = new LavanderiaLavadoraCapacidadView()
                };
                TabList.Add(tab);
            }
            TabSelected = tab;
        }

        private void TabLavanderiaSecadora()
        {
            var tab = VerificaExistenciaControl("LavanderiaSecadora");

            if (tab == null)
            {
                _lastId++;
                var vmHeader = new TabItemHeaderViewModel
                {
                    HeaderText = "Secadoras",
                    Id = _lastId
                };
                var header = new TabHeader { DataContext = vmHeader };

                tab = new RadTabItem
                {
                    Tag = new Tag { Id = _lastId, Control = "LavanderiaSecadora" },
                    Header = header,
                    Content = new LavanderiaSecadoraCapacidadView()
                };
                TabList.Add(tab);
            }
            TabSelected = tab;
        }

        #endregion

        private void TabItemClose(TablItemCloseMessage message)
        {
            RadTabItem tab = null;
            foreach (var item in TabList)
            {
                var tag = (Tag) item.Tag;
                if (tag.Id == message.Id)
                {
                    tab = item;
                    break;
                }
            }
            if (tab != null)
            {
                TabList.Remove(tab);
            }
        }

        private RadTabItem VerificaExistenciaControl(string control)
        {
            RadTabItem tab = null;
            foreach (var item in TabList)
            {
                var tag = (Tag)item.Tag;
                if (tag.Control != control) continue;
                tab = item;
                break;
            }

            return tab;
        }

        #endregion
    }

    internal class Tag
    {
        public int Id { get; set; }
        public string Control { get; set; }
    }
}
