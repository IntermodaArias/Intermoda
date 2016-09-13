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
    public class LavanderiaOpcionLavadoViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        #region LavadoId

        /// <summary>
        /// The <see cref="LavadoId" /> property's name.
        /// </summary>
        public const string LavadoIdPropertyName = "LavadoId";

        private int _lavadoId;

        /// <summary>
        /// Sets and gets the LavadoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LavadoId
        {
            get
            {
                return _lavadoId;
            }

            set
            {
                if (_lavadoId == value)
                {
                    return;
                }

                _lavadoId = value;
                Refresh();
                RaisePropertyChanged(LavadoIdPropertyName);
            }
        }

        #endregion

        #region OpcionLavadoList

        /// <summary>
        /// The <see cref="OpcionLavadoList" /> property's name.
        /// </summary>
        public const string OpcionLavadoListPropertyName = "OpcionLavadoList";

        private ObservableCollection<OpcionLavado> _opcionLavadoList;

        /// <summary>
        /// Sets and gets the OpcionLavadoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<OpcionLavado> OpcionLavadoList
        {
            get
            {
                return _opcionLavadoList;
            }

            set
            {
                if (_opcionLavadoList == value)
                {
                    return;
                }

                _opcionLavadoList = value;
                RaisePropertyChanged(OpcionLavadoListPropertyName);
            }
        }

        #endregion

        #region OpcionLavadoSelected

        /// <summary>
        /// The <see cref="OpcionLavadoSelected" /> property's name.
        /// </summary>
        public const string OpcionLavadoSelectedPropertyName = "OpcionLavadoSelected";

        private OpcionLavado _opcionLavadoSelected;

        /// <summary>
        /// Sets and gets the OpcionLavadoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OpcionLavado OpcionLavadoSelected
        {
            get
            {
                return _opcionLavadoSelected;
            }

            set
            {
                if (_opcionLavadoSelected == value)
                {
                    return;
                }

                _opcionLavadoSelected = value;
                OpcionLavadoChanged();
                RaisePropertyChanged(OpcionLavadoSelectedPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand InstruccionesCommand { get; set; }

        public RelayCommand InsertCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaOpcionLavadoViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            RegisterCommands();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            InstruccionesCommand = new RelayCommand(Instrucciones, CanEditOrDelete);

            InsertCommand = new RelayCommand(Insert);
            EditCommand = new RelayCommand(Edit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(Delete, CanEditOrDelete);
            RefreshCommand = new RelayCommand(Refresh);
        }

        private void Insert()
        {
            var reg = new OpcionLavado {LavadoId = LavadoId};
            _dialogService.LavanderiaOpcionLavadoEdit(_dataService, _dialogService, reg, true);
            Refresh();
        }

        private void Edit()
        {
            _dialogService.LavanderiaOpcionLavadoEdit(_dataService, _dialogService, OpcionLavadoSelected, true);
            Refresh();
        }

        private void Delete()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el registro",
                "Confirmar eliminación");

            if (result == MessageBoxResult.OK)
            {
                _dataService.OpcionLavadoDelete(OpcionLavadoSelected.Id,
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
            return OpcionLavadoSelected != null;
        }

        private void Refresh()
        {
            if (LavadoId == 0) 
                _dialogService.ShowMessage("No se ha determinado el Id del Lavado", "Lavado ID inválido");

            _dataService.OpcionLavadoGetByLavado(LavadoId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OpcionLavadoList = new ObservableCollection<OpcionLavado>(lista);
                    OpcionLavadoSelected = OpcionLavadoList?.FirstOrDefault();
                });
        }

        private void Instrucciones()
        {
            _dialogService.LavanderiaRecetaTrabajarCon(_dataService,_dialogService,OpcionLavadoSelected);
            Refresh();
        }

        private void OpcionLavadoChanged()
        {
            if (_init)
            {
                EditCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
                InsertCommand.RaiseCanExecuteChanged();
                InstruccionesCommand.RaiseCanExecuteChanged();
            }
            
        }

        #endregion
    }
}