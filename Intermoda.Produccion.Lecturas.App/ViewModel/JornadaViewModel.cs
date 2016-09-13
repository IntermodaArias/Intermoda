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
    public class JornadaViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region JornadaList

        /// <summary>
        /// The <see cref="JornadaList" /> property's name.
        /// </summary>
        public const string JornadaListPropertyName = "JornadaList";

        private ObservableCollection<Jornada> _jornadaList;

        /// <summary>
        /// Sets and gets the JornadaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Jornada> JornadaList
        {
            get
            {
                return _jornadaList;
            }

            set
            {
                if (_jornadaList == value)
                {
                    return;
                }

                _jornadaList = value;
                RaisePropertyChanged(JornadaListPropertyName);
            }
        }

        #endregion

        #region JornadaSelected

        /// <summary>
        /// The <see cref="JornadaSelected" /> property's name.
        /// </summary>
        public const string JornadaSelectedPropertyName = "JornadaSelected";

        private Jornada _jornadaSelected;

        /// <summary>
        /// Sets and gets the JornadaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Jornada JornadaSelected
        {
            get
            {
                return _jornadaSelected;
            }

            set
            {
                if (_jornadaSelected == value)
                {
                    return;
                }

                _jornadaSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                    JornadaChanged();
                }
                RaisePropertyChanged(JornadaSelectedPropertyName);
            }
        }

        #endregion

        #region JornadaDetalleDataContext

        /// <summary>
        /// The <see cref="JornadaDetalleDataContext" /> property's name.
        /// </summary>
        public const string JornadaDetalleDataContextPropertyName = "JornadaDetalleDataContext";

        private JornadaDetalleViewModel _jornadaDetalleDataContext;

        /// <summary>
        /// Sets and gets the JornadaDetalleDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public JornadaDetalleViewModel JornadaDetalleDataContext
        {
            get
            {
                return _jornadaDetalleDataContext;
            }

            set
            {
                if (_jornadaDetalleDataContext == value)
                {
                    return;
                }

                _jornadaDetalleDataContext = value;
                RaisePropertyChanged(JornadaDetalleDataContextPropertyName);
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

        public JornadaViewModel(IDataServiceLectura dataService, IDialogService dialogService)
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
            var reg = new Jornada();
            _dialogService.JornadaEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.JornadaEdit(_dataService, _dialogService, JornadaSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                   "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.JornadaDelete(JornadaSelected.Id,
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
            return JornadaSelected != null;
        }

        private void Refresh()
        {
            _dataService.JornadaGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    JornadaList = new ObservableCollection<Jornada>(lista);
                    JornadaSelected = JornadaList?.FirstOrDefault();
                });
        }

        private void JornadaChanged()
        {
            var jornadaId = JornadaSelected?.Id ?? 0;
            JornadaDetalleDataContext = new JornadaDetalleViewModel(_dataService, _dialogService, jornadaId);
        }

        #endregion
    }
}