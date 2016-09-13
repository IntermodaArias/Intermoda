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
    public class LavanderiaIngredientePredefinidoViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region IngredientePredefinidoList

        /// <summary>
        /// The <see cref="IngredientePredefinidoList" /> property's name.
        /// </summary>
        public const string IngredientePredefinidoListPropertyName = "IngredientePredefinidoList";

        private ObservableCollection<IngredientePredefinido> _ingredientePredefinidoList;

        /// <summary>
        /// Sets and gets the IngredientePredefinidoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<IngredientePredefinido> IngredientePredefinidoList
        {
            get { return _ingredientePredefinidoList; }

            set
            {
                if (_ingredientePredefinidoList == value)
                {
                    return;
                }

                _ingredientePredefinidoList = value;
                RaisePropertyChanged(IngredientePredefinidoListPropertyName);
            }
        }

        #endregion

        #region IngredientePredefinidoSelected

        /// <summary>
        /// The <see cref="IngredientePredefinidoSelected" /> property's name.
        /// </summary>
        public const string IngredientePredefinidoSelectedPropertyName = "IngredientePredefinidoSelected";

        private IngredientePredefinido _ingredientePredefinidoSelected;

        /// <summary>
        /// Sets and gets the IngredientePredefinidoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IngredientePredefinido IngredientePredefinidoSelected
        {
            get { return _ingredientePredefinidoSelected; }

            set
            {
                if (_ingredientePredefinidoSelected == value)
                {
                    return;
                }

                _ingredientePredefinidoSelected = value;
                IngredientePredefinidoChanged();
                RaisePropertyChanged(IngredientePredefinidoSelectedPropertyName);
            }
        }

        #endregion

        #region InstruccionPredefinida

        /// <summary>
        /// The <see cref="InstruccionPredefinida" /> property's name.
        /// </summary>
        public const string InstruccionPredefinidaPropertyName = "InstruccionPredefinida";

        private InstruccionPredefinida _instruccionPredefinida;

        /// <summary>
        /// Sets and gets the InstruccionPredefinida property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public InstruccionPredefinida InstruccionPredefinida
        {
            get { return _instruccionPredefinida; }

            set
            {
                if (_instruccionPredefinida == value)
                {
                    return;
                }

                _instruccionPredefinida = value;
                RaisePropertyChanged(InstruccionPredefinidaPropertyName);
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

        public LavanderiaIngredientePredefinidoViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, InstruccionPredefinida instruccionPredefinida)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            InstruccionPredefinida = instruccionPredefinida;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.InstruccionPredefinidaGet(1000,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            Tools.ExceptionMessage(error);
                            return;
                        }
                        InstruccionPredefinida = reg;
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
            var reg = new IngredientePredefinido {InstruccionPredefinidaId = InstruccionPredefinida.Id};
            _dialogService.LavanderiaIngredientePredefinidaEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaIngredientePredefinidaEdit(_dataService, _dialogService,
                IngredientePredefinidoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro?",
                "Confirmar eliminación");

            if (result == MessageBoxResult.OK)
            {
                _dataService.IngredientePredefinidoDelete(IngredientePredefinidoSelected.Id,
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
            return InstruccionPredefinida != null;
        }

        private bool CanEditOrDelete()
        {
            return IngredientePredefinidoSelected != null;
        }

        private void Refresh()
        {
            if (InstruccionPredefinida == null)
            {
                IngredientePredefinidoList = null;
                IngredientePredefinidoSelected = null;
                return;
            }

            _dataService.IngredientePredefinidoGetByInstruccionPredefinida(InstruccionPredefinida.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    IngredientePredefinidoList = new ObservableCollection<IngredientePredefinido>(lista);
                    IngredientePredefinidoSelected = IngredientePredefinidoList?.FirstOrDefault();
                });
        }

        private void IngredientePredefinidoChanged()
        {
            if (_init)
            {
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        #endregion
    }
}