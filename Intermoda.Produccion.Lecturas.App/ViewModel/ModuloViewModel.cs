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
    public class ModuloViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private int _centroTrabajoId;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoId
        {
            get
            {
                return _centroTrabajoId;
            }

            set
            {
                if (_centroTrabajoId == value)
                {
                    return;
                }

                _centroTrabajoId = value;
                InsertCommand.RaiseCanExecuteChanged();
                Refresh();
                RaisePropertyChanged(CentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region ModuloList

        /// <summary>
        /// The <see cref="ModuloList" /> property's name.
        /// </summary>
        public const string ModuloListPropertyName = "ModuloList";

        private ObservableCollection<Modulo> _moduloList;

        /// <summary>
        /// Sets and gets the ModuloList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Modulo> ModuloList
        {
            get
            {
                return _moduloList;
            }

            set
            {
                if (_moduloList == value)
                {
                    return;
                }

                _moduloList = value;
                RaisePropertyChanged(ModuloListPropertyName);
            }
        }

        #endregion

        #region ModuloSelected

        /// <summary>
        /// The <see cref="ModuloSelected" /> property's name.
        /// </summary>
        public const string ModuloSelectedPropertyName = "ModuloSelected";

        private Modulo _moduloSelected;

        /// <summary>
        /// Sets and gets the ModuloSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Modulo ModuloSelected
        {
            get
            {
                return _moduloSelected;
            }

            set
            {
                if (_moduloSelected == value)
                {
                    return;
                }

                _moduloSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(ModuloSelectedPropertyName);
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

        public ModuloViewModel(IDataServiceLectura dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                CentroTrabajoId = 1000;
            }

            RegisterCommands();

            _init = true;

        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            InsertCommand = new RelayCommand(Insert, CanInsert);
            EditCommand = new RelayCommand(Edit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(Delete, CanEditOrDelete);
            RefreshCommand = new RelayCommand(Refresh);
        }

        private void Insert()
        {
            var reg = new Modulo {CentroTrabajoId = CentroTrabajoId};
            _dialogService.ModuloEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.ModuloEdit(_dataService, _dialogService, ModuloSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.CentroTrabajoDelete(ModuloSelected.Id,
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

        private bool CanInsert()
        {
            return CentroTrabajoId > 0;
        }

        private bool CanEditOrDelete()
        {
            return ModuloSelected != null;
        }

        private void Refresh()
        {
            _dataService.ModuloGetAll(CentroTrabajoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ModuloList = new ObservableCollection<Modulo>(lista);
                    ModuloSelected = ModuloList?.FirstOrDefault();
                });
        }

        #endregion
    }
}