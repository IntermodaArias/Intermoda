using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaCentroTrabajoViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region CentroTrabajoList

        /// <summary>
        /// The <see cref="CentroTrabajoList" /> property's name.
        /// </summary>
        public const string CentroTrabajoListPropertyName = "CentroTrabajoList";

        private ObservableCollection<CentroTrabajo> _centroTrabajoList;

        /// <summary>
        /// Sets and gets the CentroTrabajoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<CentroTrabajo> CentroTrabajoList
        {
            get
            {
                return _centroTrabajoList;
            }

            set
            {
                if (_centroTrabajoList == value)
                {
                    return;
                }

                _centroTrabajoList = value;
                RaisePropertyChanged(CentroTrabajoListPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoSelected

        /// <summary>
        /// The <see cref="CentroTrabajoSelected" /> property's name.
        /// </summary>
        public const string CentroTrabajoSelectedPropertyName = "CentroTrabajoSelected";

        private CentroTrabajo _centroTrabajoSelected;

        /// <summary>
        /// Sets and gets the CentroTrabajoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajo CentroTrabajoSelected
        {
            get
            {
                return _centroTrabajoSelected;
            }

            set
            {
                if (_centroTrabajoSelected == value)
                {
                    return;
                }

                _centroTrabajoSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                ProcesosDataContext = new LavanderiaProcesoViewModel(_dataService, _dialogService,
                    _centroTrabajoSelected.Codigo);
                RaisePropertyChanged(CentroTrabajoSelectedPropertyName);
            }
        }

        #endregion

        #region ProcesosDataContext

        /// <summary>
        /// The <see cref="ProcesosDataContext" /> property's name.
        /// </summary>
        public const string ProcesosDataContextPropertyName = "ProcesosDataContext";

        private LavanderiaProcesoViewModel _procesosDataContext;

        /// <summary>
        /// Sets and gets the ProcesosDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaProcesoViewModel ProcesosDataContext
        {
            get
            {
                return _procesosDataContext;
            }

            set
            {
                if (_procesosDataContext == value)
                {
                    return;
                }

                _procesosDataContext = value;
                RaisePropertyChanged(ProcesosDataContextPropertyName);
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

        public LavanderiaCentroTrabajoViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
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
            var reg = new CentroTrabajo();
            _dialogService.LavanderiaCentroTrabajoEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaCentroTrabajoEdit(_dataService, _dialogService, CentroTrabajoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.CentroTrabajoDelete(CentroTrabajoSelected.Codigo,
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
            return CentroTrabajoSelected != null;
        }

        private void Refresh()
        {
            _dataService.CentroTrabajoGetAllLavanderia(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    CentroTrabajoList = new ObservableCollection<CentroTrabajo>(lista);
                    CentroTrabajoSelected = CentroTrabajoList?.FirstOrDefault();
                });
        }

        #endregion
    }
}