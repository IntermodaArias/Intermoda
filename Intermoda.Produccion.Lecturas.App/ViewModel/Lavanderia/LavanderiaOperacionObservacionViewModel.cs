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
    public class LavanderiaOperacionObservacionViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly Operacion _operacion;
        private readonly bool _init;

        #region Properties

        #region ObservacionPredefinidaList

        /// <summary>
        /// The <see cref="ObservacionPredefinidaList" /> property's name.
        /// </summary>
        public const string ObservacionPredefinidaListPropertyName = "ObservacionPredefinidaList";

        private ObservableCollection<ObservacionPredefinida> _observacionPredefinidaList;

        /// <summary>
        /// Sets and gets the ObservacionPredefinidaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ObservacionPredefinida> ObservacionPredefinidaList
        {
            get
            {
                return _observacionPredefinidaList;
            }

            set
            {
                if (_observacionPredefinidaList == value)
                {
                    return;
                }

                _observacionPredefinidaList = value;
                RaisePropertyChanged(ObservacionPredefinidaListPropertyName);
            }
        }

        #endregion

        #region ObservacionPredefinidaSelected

        /// <summary>
        /// The <see cref="ObservacionPredefinidaSelected" /> property's name.
        /// </summary>
        public const string ObservacionPredefinidaSelectedPropertyName = "ObservacionPredefinidaSelected";

        private ObservacionPredefinida _observacionPredefinidaSelected;

        /// <summary>
        /// Sets and gets the ObservacionPredefinidaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservacionPredefinida ObservacionPredefinidaSelected
        {
            get
            {
                return _observacionPredefinidaSelected;
            }

            set
            {
                if (_observacionPredefinidaSelected == value)
                {
                    return;
                }

                _observacionPredefinidaSelected = value;
                RaisePropertyChanged(ObservacionPredefinidaSelectedPropertyName);
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

        public LavanderiaOperacionObservacionViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Operacion operacion)
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
            var reg = new ObservacionPredefinida {OperacionId = _operacion.Id, Operacion = _operacion};
            _dialogService.LavanderiaOperacionObservacionPredefinidaEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaOperacionObservacionPredefinidaEdit(_dataService, _dialogService,
                ObservacionPredefinidaSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.ObservacionPredefinidaDelete(ObservacionPredefinidaSelected.Id,
                    error =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        Refresh();
                    });
            }
        }

        private bool CanInsert()
        {
            return _operacion != null;
        }

        private bool CanEditOrDelete()
        {
            return ObservacionPredefinidaSelected != null;
        }

        private void Refresh()
        {
            if (_operacion == null) return;

            _dataService.ObservacionPredefinidaGetByOperacion(_operacion.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ObservacionPredefinidaList = new ObservableCollection<ObservacionPredefinida>(lista);
                    ObservacionPredefinidaSelected = ObservacionPredefinidaList?.FirstOrDefault();
                });
        }

        #endregion

    }
}