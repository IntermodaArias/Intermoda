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
    public class LavanderiaSecadoraCapacidadViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region SecadoraCapacidadList

        /// <summary>
        /// The <see cref="SecadoraCapacidadList" /> property's name.
        /// </summary>
        public const string SecadoraCapacidadListPropertyName = "SecadoraCapacidadList";

        private ObservableCollection<SecadoraCapacidad> _secadoraCapacidadList;

        /// <summary>
        /// Sets and gets the SecadoraCapacidadList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<SecadoraCapacidad> SecadoraCapacidadList
        {
            get
            {
                return _secadoraCapacidadList;
            }

            set
            {
                if (_secadoraCapacidadList == value)
                {
                    return;
                }

                _secadoraCapacidadList = value;
                RaisePropertyChanged(SecadoraCapacidadListPropertyName);
            }
        }

        #endregion

        #region SecadoraCapacidadSelected

        /// <summary>
        /// The <see cref="SecadoraCapacidadSelected" /> property's name.
        /// </summary>
        public const string SecadoraCapacidadSelectedPropertyName = "SecadoraCapacidadSelected";

        private SecadoraCapacidad _secadoraCapacidadSelected;

        /// <summary>
        /// Sets and gets the SecadoraCapacidadSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SecadoraCapacidad SecadoraCapacidadSelected
        {
            get
            {
                return _secadoraCapacidadSelected;
            }

            set
            {
                if (_secadoraCapacidadSelected == value)
                {
                    return;
                }

                _secadoraCapacidadSelected = value;
                SecadoraCapacidadChanged();
                RaisePropertyChanged(SecadoraCapacidadSelectedPropertyName);
            }
        }

        #endregion

        #region SecadoraDataContext

        /// <summary>
        /// The <see cref="SecadoraDataContext" /> property's name.
        /// </summary>
        public const string SecadoraDataContextPropertyName = "SecadoraDataContext";

        private LavanderiaSecadoraViewModel _secadoraDataContext;

        /// <summary>
        /// Sets and gets the SecadoraDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaSecadoraViewModel SecadoraDataContext
        {
            get
            {
                return _secadoraDataContext;
            }

            set
            {
                if (_secadoraDataContext == value)
                {
                    return;
                }

                _secadoraDataContext = value;
                RaisePropertyChanged(SecadoraDataContextPropertyName);
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

        public LavanderiaSecadoraCapacidadViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
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
            var reg = new SecadoraCapacidad();
            _dialogService.LavanderiaSecadoraCapacidadEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaSecadoraCapacidadEdit(_dataService, _dialogService, SecadoraCapacidadSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.SecadoraCapacidadDelete(SecadoraCapacidadSelected.Id,
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
            return SecadoraCapacidadSelected != null;
        }

        private void Refresh()
        {
            _dataService.SecadoraCapacidadGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    SecadoraCapacidadList = new ObservableCollection<SecadoraCapacidad>(lista);
                    SecadoraCapacidadSelected = SecadoraCapacidadList?.FirstOrDefault();
                });
        }

        private void SecadoraCapacidadChanged()
        {
            if (_init && SecadoraCapacidadSelected != null)
            {
                SecadoraDataContext = new LavanderiaSecadoraViewModel(_dataService, _dialogService,
                    SecadoraCapacidadSelected.Id);
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion
    }
}