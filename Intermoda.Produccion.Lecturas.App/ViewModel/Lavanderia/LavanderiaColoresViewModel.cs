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
    public class LavanderiaColoresViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region ColorIntermodaList

        /// <summary>
        /// The <see cref="ColorIntermodaList" /> property's name.
        /// </summary>
        public const string ColorIntermodaListPropertyName = "ColorIntermodaList";

        private ObservableCollection<ColorIntermoda> _colorIntermodaList;

        /// <summary>
        /// Sets and gets the ColorIntermodaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ColorIntermoda> ColorIntermodaList
        {
            get
            {
                return _colorIntermodaList;
            }

            set
            {
                if (_colorIntermodaList == value)
                {
                    return;
                }

                _colorIntermodaList = value;
                RaisePropertyChanged(ColorIntermodaListPropertyName);
            }
        }

        #endregion

        #region ColorIntermodaSelected

        /// <summary>
        /// The <see cref="ColorIntermodaSelected" /> property's name.
        /// </summary>
        public const string ColorIntermodaSelectedPropertyName = "ColorIntermodaSelected";

        private ColorIntermoda _colorIntermodaSelected;

        /// <summary>
        /// Sets and gets the ColorIntermodaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ColorIntermoda ColorIntermodaSelected
        {
            get
            {
                return _colorIntermodaSelected;
            }

            set
            {
                if (_colorIntermodaSelected == value)
                {
                    return;
                }

                _colorIntermodaSelected = value;
                ColorIntermodaChanged();
               RaisePropertyChanged(ColorIntermodaSelectedPropertyName);
            }
        }

        #endregion

        #region TelaColorDataContext

        /// <summary>
        /// The <see cref="TelaColorDataContext" /> property's name.
        /// </summary>
        public const string TelaColorDataContextPropertyName = "TelaColorDataContext";

        private LavanderiaTelaColorViewModel _telaColorDataContext;

        /// <summary>
        /// Sets and gets the TelaColorDataContext property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LavanderiaTelaColorViewModel TelaColorDataContext
        {
            get
            {
                return _telaColorDataContext;
            }

            set
            {
                if (_telaColorDataContext == value)
                {
                    return;
                }

                _telaColorDataContext = value;
                RaisePropertyChanged(TelaColorDataContextPropertyName);
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

        public LavanderiaColoresViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
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
            var reg = new ColorIntermoda();
            _dialogService.LavanderiaColoresEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaColoresEdit(_dataService, _dialogService, ColorIntermodaSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.ColorIntermodaDelete(ColorIntermodaSelected.Id,
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
            return ColorIntermodaSelected != null;
        }

        private void Refresh()
        {
            _dataService.ColorIntermodaGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ColorIntermodaList = new ObservableCollection<ColorIntermoda>(lista);
                    ColorIntermodaSelected = ColorIntermodaList?.FirstOrDefault();
                });
        }

        private void ColorIntermodaChanged()
        {
            if (_init)
                TelaColorDataContext = new LavanderiaTelaColorViewModel(_dataService, _dialogService,
                    ColorIntermodaSelected.Id);
        }

        #endregion
    }
}