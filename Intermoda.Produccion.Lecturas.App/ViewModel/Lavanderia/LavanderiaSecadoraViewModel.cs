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
    public class LavanderiaSecadoraViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly short _secadoraCapacidadId;
        private readonly bool _init;

        #region Properties

        #region SecadoraList

        /// <summary>
        /// The <see cref="SecadoraList" /> property's name.
        /// </summary>
        public const string SecadoraListPropertyName = "SecadoraList";

        private ObservableCollection<Secadora> _secadoraList;

        /// <summary>
        /// Sets and gets the SecadoraList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Secadora> SecadoraList
        {
            get { return _secadoraList; }

            set
            {
                if (_secadoraList == value)
                {
                    return;
                }

                _secadoraList = value;
                RaisePropertyChanged(SecadoraListPropertyName);
            }
        }

        #endregion

        #region SecadoraSelected

        /// <summary>
        /// The <see cref="SecadoraSelected" /> property's name.
        /// </summary>
        public const string SecadoraSelectedPropertyName = "SecadoraSelected";

        private Secadora _secadoraSelected;

        /// <summary>
        /// Sets and gets the SecadoraSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Secadora SecadoraSelected
        {
            get { return _secadoraSelected; }

            set
            {
                if (_secadoraSelected == value)
                {
                    return;
                }

                _secadoraSelected = value;
                SecadoraChanged();
                RaisePropertyChanged(SecadoraSelectedPropertyName);
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

        public LavanderiaSecadoraViewModel(IDataServiceLavanderia dataService, IDialogService dialogService,
            short secadoraCapacidadId)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _secadoraCapacidadId = secadoraCapacidadId;

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
            var reg = new Secadora {SecadoraCapacidadId = _secadoraCapacidadId};
            _dialogService.LavanderiaSecadoraEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaSecadoraEdit(_dataService, _dialogService, SecadoraSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.SecadoraDelete(SecadoraSelected.Id,
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
            return SecadoraSelected != null;
        }

        private void Refresh()
        {
            _dataService.SecadoraGetByCapacidad(_secadoraCapacidadId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    SecadoraList = new ObservableCollection<Secadora>(lista);
                    SecadoraSelected = SecadoraList?.FirstOrDefault();
                });
        }

        private void SecadoraChanged()
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