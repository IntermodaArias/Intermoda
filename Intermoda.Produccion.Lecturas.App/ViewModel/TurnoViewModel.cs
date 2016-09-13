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
    public class TurnoViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region TurnoList

        /// <summary>
        /// The <see cref="TurnoList" /> property's name.
        /// </summary>
        public const string TurnoListPropertyName = "TurnoList";

        private ObservableCollection<Turno> _turnoList;

        /// <summary>
        /// Sets and gets the TurnoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Turno> TurnoList
        {
            get
            {
                return _turnoList;
            }

            set
            {
                if (_turnoList == value)
                {
                    return;
                }

                _turnoList = value;
                RaisePropertyChanged(TurnoListPropertyName);
            }
        }

        #endregion

        #region TurnoSelected

        /// <summary>
        /// The <see cref="TurnoSelected" /> property's name.
        /// </summary>
        public const string TurnoSelectedPropertyName = "TurnoSelected";

        private Turno _turnoSelected;

        /// <summary>
        /// Sets and gets the TurnoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Turno TurnoSelected
        {
            get
            {
                return _turnoSelected;
            }

            set
            {
                if (_turnoSelected == value)
                {
                    return;
                }

                _turnoSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                    TurnoChanged();
                }
                RaisePropertyChanged(TurnoSelectedPropertyName);
            }
        }

        #endregion

        #region TurnoDetalleDataContext

        /// <summary>
        /// The <see cref="TurnoDetalleDataContext" /> property's name.
        /// </summary>
        public const string TurnoDetalleDataContextPropertyName = "TurnoDetalleDataContext";

        private TurnoDetalleViewModel _turnoDetalleDataContext;

        /// <summary>
        /// Sets and gets the TurnoDetalleDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TurnoDetalleViewModel TurnoDetalleDataContext
        {
            get
            {
                return _turnoDetalleDataContext;
            }

            set
            {
                if (_turnoDetalleDataContext == value)
                {
                    return;
                }

                _turnoDetalleDataContext = value;
                RaisePropertyChanged(TurnoDetalleDataContextPropertyName);
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

        public TurnoViewModel(IDataServiceLectura dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            RegisterCommands();
            
            _init = true;

            TurnoRefresh();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            InsertCommand = new RelayCommand(TurnoInsert);
            EditCommand = new RelayCommand(TurnoEdit, TurnoCanEditOrDelete);
            DeleteCommand = new RelayCommand(TurnoDelete, TurnoCanEditOrDelete);
            RefreshCommand = new RelayCommand(TurnoRefresh);
        }

        private void TurnoInsert()
        {
            var reg = new Turno();
            _dialogService.TurnoEdit(_dataService, _dialogService, reg);
            TurnoRefresh();
        }

        private void TurnoEdit()
        {
            _dialogService.TurnoEdit(_dataService, _dialogService, TurnoSelected);
            TurnoRefresh();
        }

        private void TurnoDelete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                   "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.TurnoDelete(TurnoSelected.Id,
                    error =>
                    {
                        if (error != null)
                        {
                            Tools.ExceptionMessage(error);
                            return;
                        }
                        TurnoRefresh();
                    });
            }
        }

        private bool TurnoCanEditOrDelete()
        {
            return TurnoSelected != null;
        }

        private void TurnoRefresh()
        {
            _dataService.TurnoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    TurnoList = new ObservableCollection<Turno>(lista);
                    TurnoSelected = TurnoList?.FirstOrDefault();
                });
        }

        private void TurnoChanged()
        {
            var turnoId = TurnoSelected?.Id ?? 0;
            TurnoDetalleDataContext = new TurnoDetalleViewModel(_dataService, _dialogService, turnoId);
        }

        #endregion
    }
}