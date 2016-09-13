using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOperacionInstruccionViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region InstruccionPredefinidaList

        /// <summary>
        /// The <see cref="InstruccionPredefinidaList" /> property's name.
        /// </summary>
        public const string InstruccionPredefinidaListPropertyName = "InstruccionPredefinidaList";

        private ObservableCollection<InstruccionPredefinida> _instruccionPredefinidaList;

        /// <summary>
        /// Sets and gets the InstruccionPredefinidaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<InstruccionPredefinida> InstruccionPredefinidaList
        {
            get
            {
                return _instruccionPredefinidaList;
            }

            set
            {
                if (_instruccionPredefinidaList == value)
                {
                    return;
                }

                _instruccionPredefinidaList = value;
                RaisePropertyChanged(InstruccionPredefinidaListPropertyName);
            }
        }

        #endregion

        #region InstruccionPredefinidaSelected

        /// <summary>
        /// The <see cref="InstruccionPredefinidaSelected" /> property's name.
        /// </summary>
        public const string InstruccionPredefinidaSelectedPropertyName = "InstruccionPredefinidaSelected";

        private InstruccionPredefinida _instruccionPredefinidaSelected;

        /// <summary>
        /// Sets and gets the InstruccionPredefinidaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public InstruccionPredefinida InstruccionPredefinidaSelected
        {
            get
            {
                return _instruccionPredefinidaSelected;
            }

            set
            {
                if (_instruccionPredefinidaSelected == value)
                {
                    return;
                }

                _instruccionPredefinidaSelected = value;
                InstruccionChanged();
                RaisePropertyChanged(InstruccionPredefinidaSelectedPropertyName);
            }
        }

        #endregion

        #region Operacion

        /// <summary>
        /// The <see cref="Operacion" /> property's name.
        /// </summary>
        public const string OperacionPropertyName = "Operacion";

        private Operacion _operacion;

        /// <summary>
        /// Sets and gets the Operacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Operacion Operacion
        {
            get
            {
                return _operacion;
            }

            set
            {
                if (_operacion == value)
                {
                    return;
                }

                _operacion = value;
                RaisePropertyChanged(OperacionPropertyName);
            }
        }

        #endregion

        #region LavanderiaIngredientePredefinidoDataContext

        /// <summary>
        /// The <see cref="LavanderiaIngredientePredefinidoDataContext" /> property's name.
        /// </summary>
        public const string LavanderiaIngredientePredefinidoDataContextPropertyName = "LavanderiaIngredientePredefinidoDataContext";

        private LavanderiaIngredientePredefinidoViewModel _lavanderiaIngredientePredefinidoDataContext;

        /// <summary>
        /// Sets and gets the LavanderiaIngredientePredefinidoDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaIngredientePredefinidoViewModel LavanderiaIngredientePredefinidoDataContext
        {
            get
            {
                return _lavanderiaIngredientePredefinidoDataContext;
            }

            set
            {
                if (_lavanderiaIngredientePredefinidoDataContext == value)
                {
                    return;
                }

                _lavanderiaIngredientePredefinidoDataContext = value;
                RaisePropertyChanged(LavanderiaIngredientePredefinidoDataContextPropertyName);
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

        public LavanderiaOperacionInstruccionViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Operacion operacion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            Operacion = operacion;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.OperacionGet(1000,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            Tools.ExceptionMessage(error);
                            return;
                        }
                        Operacion = reg;
                    });
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
            var reg = new InstruccionPredefinida {OperacionPredefinidaId = Operacion.OperacionPredefinida.Id};
            _dialogService.LavanderiaInstruccionPredefinidaEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaInstruccionPredefinidaEdit(_dataService, _dialogService,
                InstruccionPredefinidaSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro?",
                "Confirmar eliminación");

            if (result == MessageBoxResult.OK)
            {
                _dataService.InstruccionPredefinidaDelete(InstruccionPredefinidaSelected.Id,
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
            return Operacion != null;
        }

        private bool CanEditOrDelete()
        {
            return InstruccionPredefinidaSelected != null;
        }

        private void Refresh()
        {
            if (Operacion == null)
            {
                InstruccionPredefinidaList = null;
                InstruccionPredefinidaSelected = null;
                return;
            }

            _dataService.InstruccionPredefinidaGetbyOperacionPredefinida(Operacion.OperacionPredefinida.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    InstruccionPredefinidaList = new ObservableCollection<InstruccionPredefinida>(lista);
                    InstruccionPredefinidaSelected = InstruccionPredefinidaList?.FirstOrDefault();
                });
        }

        private void InstruccionChanged()
        {
            if (_init)
            {
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
            LavanderiaIngredientePredefinidoDataContext = new LavanderiaIngredientePredefinidoViewModel(_dataService,
                _dialogService, InstruccionPredefinidaSelected);
        }

        #endregion
    }
}