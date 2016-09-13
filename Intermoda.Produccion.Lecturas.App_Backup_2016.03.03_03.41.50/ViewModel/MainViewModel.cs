using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Produccion.Lecturas.App.Messages;
using Intermoda.Produccion.Lecturas.App.View;
using Intermoda.Produccion.Lecturas.Client.DataServices;
using Intermoda.Wpf.Controls;
using Telerik.Windows.Controls;
using ViewModelBase = GalaSoft.MvvmLight.ViewModelBase;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
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

        public RelayCommand CentroTrabajoCommand { get; set; }

        //public RelayCommand CloseTabCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(IDataService dataService, IDialogService dialogService)
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
            CentroTrabajoCommand = new RelayCommand(TabCentroTrabajo);
        }

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
