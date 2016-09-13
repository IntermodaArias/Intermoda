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
    public class LavanderiaOperacionViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        
        private readonly bool _init;

        #region Properties

        #region OperacionList

        /// <summary>
        /// The <see cref="OperacionList" /> property's name.
        /// </summary>
        public const string OperacionListPropertyName = "OperacionList";

        private ObservableCollection<Operacion> _operacionList;

        /// <summary>
        /// Sets and gets the OperacionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Operacion> OperacionList
        {
            get
            {
                return _operacionList;
            }

            set
            {
                if (_operacionList == value)
                {
                    return;
                }

                _operacionList = value;
                RaisePropertyChanged(OperacionListPropertyName);
            }
        }

        #endregion

        #region OperacionSelected

        /// <summary>
        /// The <see cref="OperacionSelected" /> property's name.
        /// </summary>
        public const string OperacionSelectedPropertyName = "OperacionSelected";

        private Operacion _operacionSelected;

        /// <summary>
        /// Sets and gets the OperacionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Operacion OperacionSelected
        {
            get
            {
                return _operacionSelected;
            }

            set
            {
                if (_operacionSelected == value)
                {
                    return;
                }

                _operacionSelected = value;
                OperacionChanged();
                RaisePropertyChanged(OperacionSelectedPropertyName);
            }
        }

        #endregion

        #region OperacionCentroTrabajoDataContext

        /// <summary>
        /// The <see cref="OperacionCentroTrabajoDataContext" /> property's name.
        /// </summary>
        public const string OperacionCentroTrabajoDataContextPropertyName = "OperacionCentroTrabajoDataContext";

        private LavanderiaOperacionCentroTrabajoViewModel _operacionCentroTrabajoDataContext;

        /// <summary>
        /// Sets and gets the OperacionCentroTrabajoDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaOperacionCentroTrabajoViewModel OperacionCentroTrabajoDataContext
        {
            get
            {
                return _operacionCentroTrabajoDataContext;
            }

            set
            {
                if (_operacionCentroTrabajoDataContext == value)
                {
                    return;
                }

                _operacionCentroTrabajoDataContext = value;
                RaisePropertyChanged(OperacionCentroTrabajoDataContextPropertyName);
            }
        }

        #endregion

        #region OperacionInstruccionDataContext

        /// <summary>
        /// The <see cref="OperacionInstruccionDataContext" /> property's name.
        /// </summary>
        public const string OperacionInstruccionDataContextPropertyName = "OperacionInstruccionDataContext";

        private LavanderiaOperacionInstruccionViewModel _operacionInstruccionDataContext;

        /// <summary>
        /// Sets and gets the OperacionInstruccionDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaOperacionInstruccionViewModel OperacionInstruccionDataContext
        {
            get
            {
                return _operacionInstruccionDataContext;
            }

            set
            {
                if (_operacionInstruccionDataContext == value)
                {
                    return;
                }

                _operacionInstruccionDataContext = value;
                RaisePropertyChanged(OperacionInstruccionDataContextPropertyName);
            }
        }

        #endregion

        #region OperacionObservacionDataContext

        /// <summary>
        /// The <see cref="OperacionObservacionDataContext" /> property's name.
        /// </summary>
        public const string OperacionObservacionDataContextPropertyName = "OperacionObservacionDataContext";

        private LavanderiaOperacionObservacionViewModel _operacionObservacionDataContext;

        /// <summary>
        /// Sets and gets the OperacionObservacionDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaOperacionObservacionViewModel OperacionObservacionDataContext
        {
            get
            {
                return _operacionObservacionDataContext;
            }

            set
            {
                if (_operacionObservacionDataContext == value)
                {
                    return;
                }

                _operacionObservacionDataContext = value;
                RaisePropertyChanged(OperacionObservacionDataContextPropertyName);
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

        public LavanderiaOperacionViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
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
            var reg = new Operacion
            {
                OperacionPredefinida = new OperacionPredefinida()
            };
            _dialogService.LavanderiaOperacionEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaOperacionEdit(_dataService, _dialogService, OperacionSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.OperacionDelete(OperacionSelected.Id,
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
            return OperacionSelected != null;
        }

        private void Refresh()
        {
            _dataService.OperacionGetAllLavanderia(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OperacionList = new ObservableCollection<Operacion>(lista);
                    OperacionSelected = OperacionList?.FirstOrDefault();
                });
        }

        private void OperacionChanged()
        {
            if (_init)
            {
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
            OperacionCentroTrabajoDataContext = new LavanderiaOperacionCentroTrabajoViewModel(_dataService,
                _dialogService, OperacionSelected);
            OperacionInstruccionDataContext = new LavanderiaOperacionInstruccionViewModel(_dataService, _dialogService,
                OperacionSelected);
            OperacionObservacionDataContext = new LavanderiaOperacionObservacionViewModel(_dataService, _dialogService,
                OperacionSelected);
        }

        #endregion
    }
}