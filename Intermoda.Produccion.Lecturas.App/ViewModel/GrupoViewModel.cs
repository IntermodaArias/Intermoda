using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class GrupoViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region GrupoList

        /// <summary>
        /// The <see cref="GrupoList" /> property's name.
        /// </summary>
        public const string GrupoListPropertyName = "GrupoList";

        private ObservableCollection<Grupo> _grupoList;

        /// <summary>
        /// Sets and gets the GrupoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Grupo> GrupoList
        {
            get
            {
                return _grupoList;
            }

            set
            {
                if (_grupoList == value)
                {
                    return;
                }

                _grupoList = value;
                RaisePropertyChanged(GrupoListPropertyName);
            }
        }

        #endregion

        #region GrupoSelected

        /// <summary>
        /// The <see cref="GrupoSelected" /> property's name.
        /// </summary>
        public const string GrupoSelectedPropertyName = "GrupoSelected";

        private Grupo _grupoSelected;

        /// <summary>
        /// Sets and gets the GrupoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Grupo GrupoSelected
        {
            get
            {
                return _grupoSelected;
            }

            set
            {
                if (_grupoSelected == value)
                {
                    return;
                }

                _grupoSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                    GrupoChange();
                }
                RaisePropertyChanged(GrupoSelectedPropertyName);
            }
        }

        #endregion

        #region LineaDataContext

        /// <summary>
        /// The <see cref="LineaDataContext" /> property's name.
        /// </summary>
        public const string LineaDataContextPropertyName = "LineaDataContext";

        private LineaViewModel _lineaDataContext;

        /// <summary>
        /// Sets and gets the LineaDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LineaViewModel LineaDataContext
        {
            get
            {
                return _lineaDataContext;
            }

            set
            {
                if (_lineaDataContext == value)
                {
                    return;
                }

                _lineaDataContext = value;
                RaisePropertyChanged(LineaDataContextPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public GrupoViewModel(IDataServiceLectura dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            RegisterCommands();

            _init = true;

            Refresh();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            InsertCommand = new RelayCommand(Insert);
            EditCommand = new RelayCommand(Edit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(Delete, CanEditOrDelete);
            RefreshCommand = new RelayCommand(Refresh);
        }

        private void Insert()
        {
            var reg = new Grupo();
            _dialogService.GrupoEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.GrupoEdit(_dataService, _dialogService, GrupoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.GrupoDelete(GrupoSelected.Id,
                    error =>
                    {
                        if (error != null)
                        {
                            Tools.ExceptionMessage(error);
                            return;
                        }
                        Refresh();
                    });
            }
        }

        private bool CanEditOrDelete()
        {
            return GrupoSelected != null;
        }

        private void Refresh()
        {
            _dataService.GrupoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    GrupoList = new ObservableCollection<Grupo>(lista);
                    GrupoSelected = GrupoList?.FirstOrDefault();
                });
        }

        private void GrupoChange()
        {
            LineaDataContext = new LineaViewModel(_dataService, _dialogService, GrupoSelected);
        }

        #endregion
    }
}