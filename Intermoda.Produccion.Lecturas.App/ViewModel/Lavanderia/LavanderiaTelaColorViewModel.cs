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
    public class LavanderiaTelaColorViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private int _colorIntermodaId;
        private readonly bool _init;

        #region Properties

        #region TelaColorList

        /// <summary>
        /// The <see cref="TelaColorList" /> property's name.
        /// </summary>
        public const string TelaColorListPropertyName = "TelaColorList";

        private ObservableCollection<TelaColorIntermoda> _telaColorList;

        /// <summary>
        /// Sets and gets the TelaColorList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TelaColorIntermoda> TelaColorList
        {
            get
            {
                return _telaColorList;
            }

            set
            {
                if (_telaColorList == value)
                {
                    return;
                }

                _telaColorList = value;
                RaisePropertyChanged(TelaColorListPropertyName);
            }
        }

        #endregion

        #region TelaColorSelected

        /// <summary>
        /// The <see cref="TelaColorSelected" /> property's name.
        /// </summary>
        public const string TelaColorSelectedPropertyName = "TelaColorSelected";

        private TelaColorIntermoda _telaColorSelected;

        /// <summary>
        /// Sets and gets the TelaColorSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TelaColorIntermoda TelaColorSelected
        {
            get
            {
                return _telaColorSelected;
            }

            set
            {
                if (_telaColorSelected == value)
                {
                    return;
                }

                _telaColorSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(TelaColorSelectedPropertyName);
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

        public LavanderiaTelaColorViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, int colorIntermodaId)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _colorIntermodaId = colorIntermodaId;

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
            var reg = new TelaColorIntermoda {TelaId = TelaColorSelected.TelaId, Tela = TelaColorSelected.Tela};
            _dialogService.LavanderiaTelaColorEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaTelaColorEdit(_dataService, _dialogService, TelaColorSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.TelaColorIntermodaDelete(TelaColorSelected.Id,
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
            return TelaColorSelected != null;
        }

        private void Refresh()
        {
            _dataService.TelaColorIntermodaGetByColorIntermoda(_colorIntermodaId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    TelaColorList = new ObservableCollection<TelaColorIntermoda>(lista);
                    TelaColorSelected = TelaColorList?.FirstOrDefault();
                });
        }

        #endregion
    }
}