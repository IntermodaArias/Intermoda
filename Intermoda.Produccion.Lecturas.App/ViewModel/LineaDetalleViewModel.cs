using System.Collections.Generic;
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
    public class LineaDetalleViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;
        private readonly Grupo _grupo;

        #region Properties

        #region LineaId

        /// <summary>
        /// The <see cref="LineaId" /> property's name.
        /// </summary>
        public const string LineaIdPropertyName = "LineaId";

        private int _lineaId;

        /// <summary>
        /// Sets and gets the LineaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LineaId
        {
            get
            {
                return _lineaId;
            }

            set
            {
                if (_lineaId == value)
                {
                    return;
                }

                _lineaId = value;
                RaisePropertyChanged(LineaIdPropertyName);
            }
        }

        #endregion

        #region LineaDetalleList

        /// <summary>
        /// The <see cref="LineaDetalleList" /> property's name.
        /// </summary>
        public const string LineaDetalleListPropertyName = "LineaDetalleList";

        private ObservableCollection<LineaDetalle> _lineaDetalleList;

        /// <summary>
        /// Sets and gets the LineaDetalleList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<LineaDetalle> LineaDetalleList
        {
            get
            {
                return _lineaDetalleList;
            }

            set
            {
                if (_lineaDetalleList == value)
                {
                    return;
                }

                _lineaDetalleList = value;
                RaisePropertyChanged(LineaDetalleListPropertyName);
            }
        }

        #endregion

        #region LineaDetalleSelected

        /// <summary>
        /// The <see cref="LineaDetalleSelected" /> property's name.
        /// </summary>
        public const string LineaDetalleSelectedPropertyName = "LineaDetalleSelected";

        private LineaDetalle _lineaDetalleSelected;

        /// <summary>
        /// Sets and gets the LineaDetalleSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LineaDetalle LineaDetalleSelected
        {
            get
            {
                return _lineaDetalleSelected;
            }

            set
            {
                if (_lineaDetalleSelected == value)
                {
                    return;
                }

                _lineaDetalleSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(LineaDetalleSelectedPropertyName);
            }
        }

        #endregion

        public List<CentroTrabajo> CentroTrabajoList { get; set; }

        public List<Modulo> ModuloList { get; set; }

        #endregion

        #region Commands

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public LineaDetalleViewModel(IDataServiceLectura dataService, IDialogService dialogService, Grupo grupo, int lineaId)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            LineaId = lineaId;
            _grupo = grupo;

            _init = false;

            if (IsInDesignMode)
            {
                LineaId = 1000;
            }

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
            var reg = new LineaDetalle { LineaId = LineaId };
            _dialogService.LineaDetalleEdit(_dataService, _dialogService, _grupo, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LineaDetalleEdit(_dataService, _dialogService, _grupo, LineaDetalleSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.LineaDetalleDelete(LineaDetalleSelected.Id,
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
            return LineaId > 0;
        }

        private bool CanEditOrDelete()
        {
            return LineaDetalleSelected != null;
        }

        private void Refresh()
        {
            _dataService.LineaDetalleGetByLinea(LineaId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LineaDetalleList = new ObservableCollection<LineaDetalle>(lista);
                    LineaDetalleSelected = LineaDetalleList?.FirstOrDefault();
                });
        }

        #endregion
    }
}