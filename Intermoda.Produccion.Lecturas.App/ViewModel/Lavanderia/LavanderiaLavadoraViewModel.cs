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
    public class LavanderiaLavadoraViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly short _lavadoraCapacidadId;
        private readonly bool _init;

        #region Properties

        #region LavadoraList

        /// <summary>
        /// The <see cref="LavadoraList" /> property's name.
        /// </summary>
        public const string LavadoraListPropertyName = "LavadoraList";

        private ObservableCollection<Lavadora> _lavadoraList;

        /// <summary>
        /// Sets and gets the LavadoraList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Lavadora> LavadoraList
        {
            get
            {
                return _lavadoraList;
            }

            set
            {
                if (_lavadoraList == value)
                {
                    return;
                }

                _lavadoraList = value;
                RaisePropertyChanged(LavadoraListPropertyName);
            }
        }

        #endregion

        #region LavadoraSelected

        /// <summary>
        /// The <see cref="LavadoraSelected" /> property's name.
        /// </summary>
        public const string LavadoraSelectedPropertyName = "LavadoraSelected";

        private Lavadora _lavadoraSelected;

        /// <summary>
        /// Sets and gets the LavadoraSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Lavadora LavadoraSelected
        {
            get
            {
                return _lavadoraSelected;
            }

            set
            {
                if (_lavadoraSelected == value)
                {
                    return;
                }

                _lavadoraSelected = value;
                LavadoraChanged();
                RaisePropertyChanged(LavadoraSelectedPropertyName);
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

        public LavanderiaLavadoraViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, short lavadoraCapacidadId)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _lavadoraCapacidadId = lavadoraCapacidadId;
            
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
            var reg = new Lavadora { LavadoraCapacidadId = _lavadoraCapacidadId };
            _dialogService.LavanderiaLavadoraEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaLavadoraEdit(_dataService, _dialogService, LavadoraSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.LavadoraDelete(LavadoraSelected.Id,
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
            return LavadoraSelected != null;
        }

        private void Refresh()
        {
            _dataService.LavadoraGetByCapacidad(_lavadoraCapacidadId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    LavadoraList = new ObservableCollection<Lavadora>(lista);
                    LavadoraSelected = LavadoraList?.FirstOrDefault();
                });
        }

        private void LavadoraChanged()
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