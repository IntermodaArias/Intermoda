using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOperacionCentroTrabajoViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly Operacion _operacion;
        private readonly bool _init;

        #region Properties

        #region OpeacionCentroTrabajoList

        /// <summary>
        /// The <see cref="OpeacionCentroTrabajoList" /> property's name.
        /// </summary>
        public const string OpeacionCentroTrabajoListPropertyName = "OpeacionCentroTrabajoList";

        private ObservableCollection<OperacionCentroTrabajo> _operacionCentroTrabajoList;

        /// <summary>
        /// Sets and gets the OpeacionCentroTrabajoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<OperacionCentroTrabajo> OpeacionCentroTrabajoList
        {
            get
            {
                return _operacionCentroTrabajoList;
            }

            set
            {
                if (_operacionCentroTrabajoList == value)
                {
                    return;
                }

                _operacionCentroTrabajoList = value;
                RaisePropertyChanged(OpeacionCentroTrabajoListPropertyName);
            }
        }

        #endregion

        #region OperacionCentroTrabajoSelected

        /// <summary>
        /// The <see cref="OperacionCentroTrabajoSelected" /> property's name.
        /// </summary>
        public const string OperacionCentroTrabajoSelectedPropertyName = "OperacionCentroTrabajoSelected";

        private OperacionCentroTrabajo _operacionCentroTrabajoSelected;

        /// <summary>
        /// Sets and gets the OperacionCentroTrabajoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OperacionCentroTrabajo OperacionCentroTrabajoSelected
        {
            get
            {
                return _operacionCentroTrabajoSelected;
            }

            set
            {
                if (_operacionCentroTrabajoSelected == value)
                {
                    return;
                }

                _operacionCentroTrabajoSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(OperacionCentroTrabajoSelectedPropertyName);
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

        public LavanderiaOperacionCentroTrabajoViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Operacion operacion)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _operacion = operacion;

            _init = false;

            if (IsInDesignMode)
            {
                _operacion = new Operacion
                {
                    Id = 10,
                    Nombre = "Operacion No. 000010",
                    Descripcion = "Descripción de la Operación No. 000010",
                    GrupoId = 100,
                    LineaProduccionId = 200,
                    OperacionTipoId = 300,
                    OperacionPredefinida = new OperacionPredefinida()
                };
            }

            RegisterCommands();

            _init = true;

            Refresh();
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
            var reg = new OperacionCentroTrabajo {OperacionCodigo = _operacion.Id, Operacion = _operacion};
            _dialogService.LavanderiaOperacionCentroTrabajoEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaOperacionCentroTrabajoEdit(_dataService, _dialogService,
                OperacionCentroTrabajoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                //_dataService.LavanderiaProcesoDelete(ProcesoSelected.Id,
                //    error =>
                //    {
                //        if (error != null)
                //        {
                //            Tools.ExceptionMessage(error);
                //            return;
                //        }
                //        Refresh();
                //    });
            }
        }

        private bool CanInsert()
        {
            return _operacion != null;
        }

        private bool CanEditOrDelete()
        {
            return OperacionCentroTrabajoSelected != null;
        }

        private void Refresh()
        {
            if (_operacion == null) return;

            _dataService.OperacionCentroTrabajoGetByOperacion(_operacion.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OpeacionCentroTrabajoList = new ObservableCollection<OperacionCentroTrabajo>(lista);
                    OperacionCentroTrabajoSelected = OpeacionCentroTrabajoList?.FirstOrDefault();
                });
        }

        #endregion
    }
}