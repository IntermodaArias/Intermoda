using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Produccion.Lecturas.Client;
using Intermoda.Produccion.Lecturas.Client.DataServices;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class CentroTrabajoViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init ;

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
                    CentroTrabajoChange();
                }
                RaisePropertyChanged(CentroTrabajoSelectedPropertyName);
            }
        }

        #endregion
        
        #region ModuloDataContext

        /// <summary>
        /// The <see cref="ModuloDataContext" /> property's name.
        /// </summary>
        public const string ModuloDataContextPropertyName = "ModuloDataContext";

        private ModuloViewModel _moduloDataContext;

        /// <summary>
        /// Sets and gets the ModuloDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ModuloViewModel ModuloDataContext
        {
            get
            {
                return _moduloDataContext;
            }

            set
            {
                if (_moduloDataContext == value)
                {
                    return;
                }

                _moduloDataContext = value;
                RaisePropertyChanged(ModuloDataContextPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoClasificacionDataContext

        /// <summary>
        /// The <see cref="CentroTrabajoClasificacionDataContext" /> property's name.
        /// </summary>
        public const string CentroTrabajoClasificacionDataContextPropertyName = "CentroTrabajoClasificacionDataContext";

        private CentroTrabajoClasificacionViewModel _centroTrabajoClasificacionDataContext;

        /// <summary>
        /// Sets and gets the CentroTrabajoClasificacionDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajoClasificacionViewModel CentroTrabajoClasificacionDataContext
        {
            get
            {
                return _centroTrabajoClasificacionDataContext;
            }

            set
            {
                if (_centroTrabajoClasificacionDataContext == value)
                {
                    return;
                }

                _centroTrabajoClasificacionDataContext = value;
                RaisePropertyChanged(CentroTrabajoClasificacionDataContextPropertyName);
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

        public CentroTrabajoViewModel(IDataService dataService, IDialogService dialogService)
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
            var reg  = new CentroTrabajo();
            _dialogService.CentroTrabajoEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.CentroTrabajoEdit(_dataService, _dialogService, CentroTrabajoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if(result == MessageBoxResult.OK)
            {
                _dataService.CentroTrabajoDelete(CentroTrabajoSelected.Id,
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
            _dataService.CentroTrabajoGetAll(
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

        private void CentroTrabajoChange()
        {
            var centroTrabajoId = CentroTrabajoSelected?.Id ?? 0;

            ModuloDataContext = new ModuloViewModel(_dataService, _dialogService)
            {
                CentroTrabajoId = centroTrabajoId
            };

            CentroTrabajoClasificacionDataContext = new CentroTrabajoClasificacionViewModel(_dataService, _dialogService)
            {
                CentroTrabajoId = centroTrabajoId
            };
        }

        #endregion

        public override void Cleanup()
        {
            base.Cleanup();
            MessengerInstance.Unregister(this);
        }
    }
}