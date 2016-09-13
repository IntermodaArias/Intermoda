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
    public class JornadaDetalleViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        private int _jornadaId;

        #region Properties

        #region JornadaDetalleList

        /// <summary>
        /// The <see cref="JornadaDetalleList" /> property's name.
        /// </summary>
        public const string JornadaDetalleListPropertyName = "JornadaDetalleList";

        private ObservableCollection<JornadaDetalle> _jornadaDetalleList;

        /// <summary>
        /// Sets and gets the JornadaDetalleList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<JornadaDetalle> JornadaDetalleList
        {
            get
            {
                return _jornadaDetalleList;
            }

            set
            {
                if (_jornadaDetalleList == value)
                {
                    return;
                }

                _jornadaDetalleList = value;
                RaisePropertyChanged(JornadaDetalleListPropertyName);
            }
        }

        #endregion

        #region JornadaDetalleSelected

        /// <summary>
        /// The <see cref="JornadaDetalleSelected" /> property's name.
        /// </summary>
        public const string JornadaDetalleSelectedPropertyName = "JornadaDetalleSelected";

        private JornadaDetalle _jornadaDetalleSelected;

        /// <summary>
        /// Sets and gets the JornadaDetalleSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public JornadaDetalle JornadaDetalleSelected
        {
            get
            {
                return _jornadaDetalleSelected;
            }

            set
            {
                if (_jornadaDetalleSelected == value)
                {
                    return;
                }

                _jornadaDetalleSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(JornadaDetalleSelectedPropertyName);
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

        public JornadaDetalleViewModel(IDataServiceLectura dataService, IDialogService dialogService, int jornadaId)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _jornadaId = jornadaId;

            _init = false;

            if (IsInDesignMode)
            {
                _jornadaId = 1000;
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
            var reg = new JornadaDetalle {JornadaId = _jornadaId};
            _dialogService.JornadaDetalleEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.JornadaDetalleEdit(_dataService, _dialogService, JornadaDetalleSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                   "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.JornadaDetalleDelete(JornadaDetalleSelected.Id,
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
            return JornadaDetalleSelected != null;
        }

        private void Refresh()
        {
            _dataService.JornadaDetalleGetByJornada(_jornadaId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    JornadaDetalleList = new ObservableCollection<JornadaDetalle>(lista);
                    JornadaDetalleSelected = JornadaDetalleList?.FirstOrDefault();
                });
        }

        #endregion
    }
}