using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaProcesoViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;
        
        private int _centroTrabajoId;
        private readonly bool _init;

        #region Properties

        #region ProcesoList

        /// <summary>
        /// The <see cref="ProcesoList" /> property's name.
        /// </summary>
        public const string ProcesoListPropertyName = "ProcesoList";

        private ObservableCollection<Proceso> _procesoList;

        /// <summary>
        /// Sets and gets the ProcesoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Proceso> ProcesoList
        {
            get
            {
                return _procesoList;
            }

            set
            {
                if (_procesoList == value)
                {
                    return;
                }

                _procesoList = value;
                RaisePropertyChanged(ProcesoListPropertyName);
            }
        }

        #endregion

        #region ProcesoSelected

        /// <summary>
        /// The <see cref="ProcesoSelected" /> property's name.
        /// </summary>
        public const string ProcesoSelectedPropertyName = "ProcesoSelected";

        private Proceso _procesoSelected;

        /// <summary>
        /// Sets and gets the ProcesoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Proceso ProcesoSelected
        {
            get
            {
                return _procesoSelected;
            }

            set
            {
                if (_procesoSelected == value)
                {
                    return;
                }

                _procesoSelected = value;
                if (_init)
                {
                    EditCommand.RaiseCanExecuteChanged();
                    DeleteCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(ProcesoSelectedPropertyName);
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

        public LavanderiaProcesoViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, int centroTrabajoId)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _centroTrabajoId = centroTrabajoId;

            _init = false;

            if (IsInDesignMode)
            {
                _centroTrabajoId = 1000;
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
            var reg = new Proceso {CentroTrabajoId = _centroTrabajoId};
            _dialogService.LavanderiaProcesoEdit(_dataService, _dialogService, reg);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaProcesoEdit(_dataService, _dialogService, ProcesoSelected);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminaçión");

            if (result == MessageBoxResult.OK)
            {
                _dataService.ProcesoDelete(ProcesoSelected.Id,
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
            return _centroTrabajoId > 0;
        }

        private bool CanEditOrDelete()
        {
            return ProcesoSelected != null;
        }

        private void Refresh()
        {
            _dataService.ProcesoGetByCentroTrabajo(_centroTrabajoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ProcesoList = new ObservableCollection<Proceso>(lista);
                    ProcesoSelected = ProcesoList?.FirstOrDefault();
                });
        }

        #endregion
    }
}