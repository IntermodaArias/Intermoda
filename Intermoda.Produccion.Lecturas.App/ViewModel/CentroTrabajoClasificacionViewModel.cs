using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Common;
using Intermoda.Common.Enum;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class CentroTrabajoClasificacionViewModel : ViewModelBase
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

        #region CentroTrabajoClasificacionList

        /// <summary>
        /// The <see cref="CentroTrabajoClasificacionList" /> property's name.
        /// </summary>
        public const string CentroTrabajoClasificacionListPropertyName = "CentroTrabajoClasificacionList";

        private ObservableCollection<CentroTrabajoClasificacion> _centroTrabajoClasificacionList;

        /// <summary>
        /// Sets and gets the CentroTrabajoClasificacionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<CentroTrabajoClasificacion> CentroTrabajoClasificacionList
        {
            get
            {
                return _centroTrabajoClasificacionList;
            }

            set
            {
                if (_centroTrabajoClasificacionList == value)
                {
                    return;
                }

                _centroTrabajoClasificacionList = value;
                RaisePropertyChanged(CentroTrabajoClasificacionListPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoClasificacionSelected

        /// <summary>
        /// The <see cref="CentroTrabajoClasificacionSelected" /> property's name.
        /// </summary>
        public const string CentroTrabajoClasificacionSelectedPropertyName = "CentroTrabajoClasificacionSelected";

        private CentroTrabajoClasificacion _centroTrabajoClasificacionSelected;

        /// <summary>
        /// Sets and gets the CentroTrabajoClasificacionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajoClasificacion CentroTrabajoClasificacionSelected
        {
            get
            {
                return _centroTrabajoClasificacionSelected;
            }

            set
            {
                if (_centroTrabajoClasificacionSelected == value)
                {
                    return;
                }

                _centroTrabajoClasificacionSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(CentroTrabajoClasificacionSelectedPropertyName);
            }
        }

        #endregion

        #region TipoList

        /// <summary>
        /// The <see cref="TipoList" /> property's name.
        /// </summary>
        public const string TipoListPropertyName = "TipoList";

        private ObservableCollection<EnumModel> _tipoList;

        /// <summary>
        /// Sets and gets the TipoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<EnumModel> TipoList
        {
            get
            {
                return _tipoList;
            }

            set
            {
                if (_tipoList == value)
                {
                    return;
                }

                _tipoList = value;
                RaisePropertyChanged(TipoListPropertyName);
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

        public CentroTrabajoClasificacionViewModel(IDataServiceLectura dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                CentroTrabajoId = 1000;
            }

            RegisterCommands();
            LoadTipoList();

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

        private void LoadTipoList()
        {
            var enums = Enum.GetValues(typeof(CentroTrabajoClasificacionTipo));
            var tipos = (from object e in enums
                         select new EnumModel
                         {
                             Value = (int)e,
                             Name = e.ToString()
                         }).ToList();
            TipoList = new ObservableCollection<EnumModel>(tipos);
        }

        private void Insert()
        {
            var reg = new CentroTrabajoClasificacion {CentroTrabajoId = CentroTrabajoId};
            _dialogService.CentroTrabajoClasificacionEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.CentroTrabajoClasificacionEdit(_dataService, _dialogService,
                CentroTrabajoClasificacionSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.CentroTrabajoClasificacionDelete(CentroTrabajoClasificacionSelected.Id,
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
            return CentroTrabajoClasificacionSelected != null;
        }

        private void Refresh()
        {
            _dataService.CentroTrabajoClasificacionGetAll(CentroTrabajoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    CentroTrabajoClasificacionList = new ObservableCollection<CentroTrabajoClasificacion>(lista);
                    CentroTrabajoClasificacionSelected = CentroTrabajoClasificacionList?.FirstOrDefault();
                });
        }

        #endregion
    }
}