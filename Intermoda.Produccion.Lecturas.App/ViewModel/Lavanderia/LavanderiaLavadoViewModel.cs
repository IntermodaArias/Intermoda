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
    public class LavanderiaLavadoViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region LavadoList

        /// <summary>
        /// The <see cref="LavadoList" /> property's name.
        /// </summary>
        public const string LavadoListPropertyName = "LavadoList";

        private ObservableCollection<Lavado> _lavadoList;

        /// <summary>
        /// Sets and gets the LavadoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Lavado> LavadoList
        {
            get
            {
                return _lavadoList;
            }

            set
            {
                if (_lavadoList == value)
                {
                    return;
                }

                _lavadoList = value;
                RaisePropertyChanged(LavadoListPropertyName);
            }
        }

        #endregion

        #region LavadoSelected

        /// <summary>
        /// The <see cref="LavadoSelected" /> property's name.
        /// </summary>
        public const string LavadoSelectedPropertyName = "LavadoSelected";

        private Lavado _lavadoSelected;

        /// <summary>
        /// Sets and gets the LavadoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Lavado LavadoSelected
        {
            get
            {
                return _lavadoSelected;
            }

            set
            {
                if (_lavadoSelected == value)
                {
                    return;
                }

                _lavadoSelected = value;
                LavadoChanged();
                RaisePropertyChanged(LavadoSelectedPropertyName);
            }
        }

        #endregion

        #region OpcionLavadoDataContext

        /// <summary>
        /// The <see cref="OpcionLavadoDataContext" /> property's name.
        /// </summary>
        public const string OpcionLavadoDataContextPropertyName = "OpcionLavadoDataContext";

        private LavanderiaOpcionLavadoViewModel _opcionLavadoDataContext;

        /// <summary>
        /// Sets and gets the OpcionLavadoDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaOpcionLavadoViewModel OpcionLavadoDataContext
        {
            get
            {
                return _opcionLavadoDataContext;
            }

            set
            {
                if (_opcionLavadoDataContext == value)
                {
                    return;
                }

                _opcionLavadoDataContext = value;
                RaisePropertyChanged(OpcionLavadoDataContextPropertyName);
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

        public LavanderiaLavadoViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
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
            var reg = new Lavado();
            _dialogService.LavanderiaLavadoEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaLavadoEdit(_dataService, _dialogService, LavadoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminación");

            if (result == MessageBoxResult.OK)
            {
                _dataService.LavadoDelete(LavadoSelected.LavadoId,
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
            return LavadoSelected != null;
        }

        private void Refresh()
        {
            _dataService.LavadoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LavadoList = new ObservableCollection<Lavado>(lista);
                    LavadoSelected = LavadoList?.FirstOrDefault();
                });
        }

        private void LavadoChanged()
        {
            if (_init)
            {
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
                InsertCommand.RaiseCanExecuteChanged();
                OpcionLavadoDataContext = new LavanderiaOpcionLavadoViewModel(_dataService, _dialogService)
                {
                    LavadoId = LavadoSelected.LavadoId
                };
            }
        }

        #endregion
    }
}