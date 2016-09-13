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
    public class LavanderiaLavadoraCapacidadViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;
        
        private readonly bool _init;

        #region Properties

        #region LavadoraCapacidadList

        /// <summary>
        /// The <see cref="LavadoraCapacidadList" /> property's name.
        /// </summary>
        public const string LavadoraCapacidadListPropertyName = "LavadoraCapacidadList";

        private ObservableCollection<LavadoraCapacidad> _lavadoraCapacidadList;

        /// <summary>
        /// Sets and gets the LavadoraCapacidadList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<LavadoraCapacidad> LavadoraCapacidadList
        {
            get
            {
                return _lavadoraCapacidadList;
            }

            set
            {
                if (_lavadoraCapacidadList == value)
                {
                    return;
                }

                _lavadoraCapacidadList = value;
                RaisePropertyChanged(LavadoraCapacidadListPropertyName);
            }
        }

        #endregion

        #region LavadoraCapacidadSelected

        /// <summary>
        /// The <see cref="LavadoraCapacidadSelected" /> property's name.
        /// </summary>
        public const string LavadoraCapacidadSelectedPropertyName = "LavadoraCapacidadSelected";

        private LavadoraCapacidad _lavadoraCapacidadSelected;

        /// <summary>
        /// Sets and gets the LavadoraCapacidadSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavadoraCapacidad LavadoraCapacidadSelected
        {
            get
            {
                return _lavadoraCapacidadSelected;
            }

            set
            {
                if (_lavadoraCapacidadSelected == value)
                {
                    return;
                }

                _lavadoraCapacidadSelected = value;
                LavadoraCapacidadChanged();
                RaisePropertyChanged(LavadoraCapacidadSelectedPropertyName);
            }
        }

        #endregion

        #region LavadoraDataContext

        /// <summary>
        /// The <see cref="LavadoraDataContext" /> property's name.
        /// </summary>
        public const string LavadoraDataContextPropertyName = "LavadoraDataContext";

        private LavanderiaLavadoraViewModel _lavadoraDataContext;

        /// <summary>
        /// Sets and gets the LavadoraDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaLavadoraViewModel LavadoraDataContext
        {
            get
            {
                return _lavadoraDataContext;
            }

            set
            {
                if (_lavadoraDataContext == value)
                {
                    return;
                }

                _lavadoraDataContext = value;
                RaisePropertyChanged(LavadoraDataContextPropertyName);
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

        public LavanderiaLavadoraCapacidadViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
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
            var reg = new LavadoraCapacidad();
            _dialogService.LavanderiaLavadoraCapacidadEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaLavadoraCapacidadEdit(_dataService, _dialogService, LavadoraCapacidadSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.LavadoraCapacidadDelete(LavadoraCapacidadSelected.Id,
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
            return LavadoraCapacidadSelected != null;
        }

        private void Refresh()
        {
            _dataService.LavadoraCapacidadGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LavadoraCapacidadList = new ObservableCollection<LavadoraCapacidad>(lista);
                    LavadoraCapacidadSelected = LavadoraCapacidadList?.FirstOrDefault();
                });
        }

        private void LavadoraCapacidadChanged()
        {
            if (_init && LavadoraCapacidadSelected != null)
            {
                LavadoraDataContext = new LavanderiaLavadoraViewModel(_dataService, _dialogService,
                    LavadoraCapacidadSelected.Id);
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion

    }
}