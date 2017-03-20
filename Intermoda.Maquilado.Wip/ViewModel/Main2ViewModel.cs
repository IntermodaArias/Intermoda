using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Maquilado.Wip.Helpers;

namespace Intermoda.Maquilado.Wip.ViewModel
{
    public class Main2ViewModel : ViewModelBase
    {
        private readonly IDataServiceLbDatPro _dataService;
        private readonly IDialogService _dialogService;
        private List<TePEncabezado> _lista;

        #region Properties

        #region PlantaList

        /// <summary>
        /// The <see cref="PlantaList" /> property's name.
        /// </summary>
        public const string PlantaListPropertyName = "PlantaList";

        private ObservableCollection<Planta> _plantaList;

        /// <summary>
        /// Sets and gets the PlantaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Planta> PlantaList
        {
            get
            {
                return _plantaList;
            }

            set
            {
                if (_plantaList == value)
                {
                    return;
                }

                _plantaList = value;
                RaisePropertyChanged(PlantaListPropertyName);
            }
        }

        #endregion

        #region PlantaSelected

        /// <summary>
        /// The <see cref="PlantaSelected" /> property's name.
        /// </summary>
        public const string PlantaSelectedPropertyName = "PlantaSelected";

        private Planta _plantaSelected;

        /// <summary>
        /// Sets and gets the PlantaSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Planta PlantaSelected
        {
            get
            {
                return _plantaSelected;
            }

            set
            {
                if (_plantaSelected == value)
                {
                    return;
                }

                _plantaSelected = value;
                PlantaChanged();
                RaisePropertyChanged(PlantaSelectedPropertyName);
            }
        }

        #endregion

        #region Data

        /// <summary>
        /// The <see cref="Data" /> property's name.
        /// </summary>
        public const string DataPropertyName = "Data";

        private ObservableCollection<TePEncabezado> _data;

        /// <summary>
        /// Sets and gets the Data property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TePEncabezado> Data
        {
            get
            {
                return _data;
            }

            set
            {
                if (_data == value)
                {
                    return;
                }

                _data = value;
                RaisePropertyChanged(DataPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public Main2ViewModel(IDataServiceLbDatPro dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real"
            }

            RegisterCommands();

            LoadPlantas();
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            RefreshCommand = new RelayCommand(LoadData);
        }

        private void LoadPlantas()
        {
            _dataService.PlantaGetContratistas(
                (list, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    PlantaList = new ObservableCollection<Planta>(list);
                });
        }

        private void LoadData()
        {
            _dataService.OrdenProduccionExternoGet(
                (list, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    _lista = TepProcesar.Procesar(list);
                    if (PlantaSelected != null)
                    {
                        Data = new ObservableCollection<TePEncabezado>(
                            _lista.Where(r => r.PlantaId == PlantaSelected.Id));
                    }
                    else
                    {
                        Data = null;
                    }
                });
        }

        private void PlantaChanged()
        {
            if (PlantaSelected == null)
            {
                Data = null;
                return;
            }

            if (_lista == null)
            {
                LoadData();
            }
            else
            {
                Data = new ObservableCollection<TePEncabezado>(
                    _lista.Where(r => r.PlantaId == PlantaSelected.Id));
            }
        }

        #endregion
    }
}