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
    public class LineaViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        private readonly Grupo _grupo;

        #region Properties

        #region LineaList

        /// <summary>
        /// The <see cref="LineaList" /> property's name.
        /// </summary>
        public const string LineaListPropertyName = "LineaList";

        private ObservableCollection<Linea> _lineaList;

        /// <summary>
        /// Sets and gets the LineaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Linea> LineaList
        {
            get
            {
                return _lineaList;
            }

            set
            {
                if (_lineaList == value)
                {
                    return;
                }

                _lineaList = value;
                RaisePropertyChanged(LineaListPropertyName);
            }
        }

        #endregion

        #region LineaSelected

        /// <summary>
        /// The <see cref="LineaSelected" /> property's name.
        /// </summary>
        public const string LineaSelectedPropertyName = "LineaSelected";

        private Linea _lineaSelected;

        /// <summary>
        /// Sets and gets the LineaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Linea LineaSelected
        {
            get
            {
                return _lineaSelected;
            }

            set
            {
                if (_lineaSelected == value)
                {
                    return;
                }

                _lineaSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                    LineaChanged();
                }
                RaisePropertyChanged(LineaSelectedPropertyName);
            }
        }

        #endregion

        #region LineaDetalleDataContext

        /// <summary>
        /// The <see cref="LineaDetalleDataContext" /> property's name.
        /// </summary>
        public const string LineaDetalleDataContextPropertyName = "LineaDetalleDataContext";

        private LineaDetalleViewModel _lineaDetalleDataContext;

        /// <summary>
        /// Sets and gets the LineaDetalleDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LineaDetalleViewModel LineaDetalleDataContext
        {
            get
            {
                return _lineaDetalleDataContext;
            }

            set
            {
                if (_lineaDetalleDataContext == value)
                {
                    return;
                }

                _lineaDetalleDataContext = value;
                RaisePropertyChanged(LineaDetalleDataContextPropertyName);
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

        public LineaViewModel(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            _grupo = grupo;

            RegisterCommands();

            Refresh();

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
            var reg = new Linea { GrupoId = _grupo.Id};
            _dialogService.LineaEdit(_dataService, _dialogService, _grupo, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LineaEdit(_dataService, _dialogService, _grupo, LineaSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.LineaDelete(LineaSelected.Id,
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
            return _grupo != null && _grupo.Id > 0;
        }

        private bool CanEditOrDelete()
        {
            return LineaSelected != null;
        }

        private void Refresh()
        {
            _dataService.LineaGetByGrupo(_grupo.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LineaList = new ObservableCollection<Linea>(lista);
                    LineaSelected = LineaList?.FirstOrDefault();
                });
        }

        private void LineaChanged()
        {
            var lineaId = LineaSelected?.Id ?? 0;

            LineaDetalleDataContext = new LineaDetalleViewModel(_dataService, _dialogService, _grupo, lineaId);
        }
        
        #endregion
    }
}