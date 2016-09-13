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
    public class TurnoDetalleViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        private int _turnoId;

        #region Properties

        #region TurnoDetalleList

        /// <summary>
        /// The <see cref="TurnoDetalleList" /> property's name.
        /// </summary>
        public const string TurnoDetalleListPropertyName = "TurnoDetalleList";

        private ObservableCollection<TurnoDetalle> _turnoDetalleList;

        /// <summary>
        /// Sets and gets the TurnoDetalleList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TurnoDetalle> TurnoDetalleList
        {
            get
            {
                return _turnoDetalleList;
            }

            set
            {
                if (_turnoDetalleList == value)
                {
                    return;
                }

                _turnoDetalleList = value;
                RaisePropertyChanged(TurnoDetalleListPropertyName);
            }
        }

        #endregion

        #region TurnoDetalleSelected

        /// <summary>
        /// The <see cref="TurnoDetalleSelected" /> property's name.
        /// </summary>
        public const string TurnoDetalleSelectedPropertyName = "TurnoDetalleSelected";

        private TurnoDetalle _turnoDetalleSelected;

        /// <summary>
        /// Sets and gets the TurnoDetalleSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TurnoDetalle TurnoDetalleSelected
        {
            get
            {
                return _turnoDetalleSelected;
            }

            set
            {
                if (_turnoDetalleSelected == value)
                {
                    return;
                }
                _turnoDetalleSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(TurnoDetalleSelectedPropertyName);
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

        public TurnoDetalleViewModel(IDataServiceLectura dataService, IDialogService dialogService, int turnoId)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _turnoId = turnoId;

            _init = false;

            if (IsInDesignMode)
            {
                _turnoId = 1000;
            }

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
            var reg = new TurnoDetalle { TurnoId = _turnoId};
            _dialogService.TurnoDetalleEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.TurnoDetalleEdit(_dataService, _dialogService, TurnoDetalleSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                   "Confirmar eliminación");

            if (result == MessageBoxResult.OK)
            {
                _dataService.TurnoDetalleDelete(TurnoDetalleSelected.Id,
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
            return TurnoDetalleSelected != null;
        }

        private void Refresh()
        {
            _dataService.TurnoDetalleGetByTurno(_turnoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    TurnoDetalleList = new ObservableCollection<TurnoDetalle>(lista);
                    TurnoDetalleSelected = TurnoDetalleList?.FirstOrDefault();
                });
        }

        #endregion
    }
}