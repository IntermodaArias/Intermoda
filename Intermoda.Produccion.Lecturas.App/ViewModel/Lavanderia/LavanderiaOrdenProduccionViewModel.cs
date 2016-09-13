using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOrdenProduccionViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private const int CompaniaId = 1;
        private const int PlantaId = 1;

        private readonly bool _init;

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

        #region CentroTrabajoList

        /// <summary>
        /// The <see cref="CentroTrabajoList" /> property's name.
        /// </summary>
        public const string CentroTrabajoListPropertyName = "CentroTrabajoList";

        private ObservableCollection<CentroTrabajo> _centroTrabajoList;

        /// <summary>
        /// Sets and gets the CentroTrabajoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<CentroTrabajo> CentroTrabajoList
        {
            get
            {
                return _centroTrabajoList;
            }

            set
            {
                if (_centroTrabajoList == value)
                {
                    return;
                }

                _centroTrabajoList = value;
                RaisePropertyChanged(CentroTrabajoListPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoSelected

        /// <summary>
        /// The <see cref="CentroTrabajoSelected" /> property's name.
        /// </summary>
        public const string CentroTrabajoSelectedPropertyName = "CentroTrabajoSelected";

        private CentroTrabajo _centroTrabajoSelected;

        /// <summary>
        /// Sets and gets the CentroTrabajoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajo CentroTrabajoSelected
        {
            get
            {
                return _centroTrabajoSelected;
            }

            set
            {
                if (_centroTrabajoSelected == value)
                {
                    return;
                }

                _centroTrabajoSelected = value;
                CentroTrabajoChanged();
                RaisePropertyChanged(CentroTrabajoSelectedPropertyName);
            }
        }

        #endregion

        #region OrdenProduccionList

        /// <summary>
        /// The <see cref="OrdenProduccionList" /> property's name.
        /// </summary>
        public const string OrdenProduccionListPropertyName = "OrdenProduccionList";

        private ObservableCollection<OrdenProduccionLavanderia> _ordenProduccionList;

        /// <summary>
        /// Sets and gets the OrdenProduccionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<OrdenProduccionLavanderia> OrdenProduccionList
        {
            get
            {
                return _ordenProduccionList;
            }

            set
            {
                if (_ordenProduccionList == value)
                {
                    return;
                }

                _ordenProduccionList = value;
                RaisePropertyChanged(OrdenProduccionListPropertyName);
            }
        }

        #endregion

        #region OrdenProduccionSelected

        /// <summary>
        /// The <see cref="OrdenProduccionSelected" /> property's name.
        /// </summary>
        public const string OrdenProduccionSelectedPropertyName = "OrdenProduccionSelected";

        private OrdenProduccionLavanderia _ordenProduccionSelected;

        /// <summary>
        /// Sets and gets the OrdenProduccionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OrdenProduccionLavanderia OrdenProduccionSelected
        {
            get
            {
                return _ordenProduccionSelected;
            }

            set
            {
                if (_ordenProduccionSelected == value)
                {
                    return;
                }

                _ordenProduccionSelected = value;
                OrdenChanged();
                RaisePropertyChanged(OrdenProduccionSelectedPropertyName);
            }
        }

        #endregion

        #endregion

        #region Commands

        public RelayCommand RefreshCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaOrdenProduccionViewModel(IDataServiceLavanderia dataService, IDialogService dialogService)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            LoadCombos();

            RegisterCommands();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            RefreshCommand = new RelayCommand(Refresh);
        }

        private void LoadCombos()
        {
            // Plantas
            _dataService.PlantaGetByCompania(CompaniaId,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    PlantaList = new ObservableCollection<Planta>(lista);
                    PlantaSelected = PlantaList?.FirstOrDefault();
                });

            // Centros de Trabajo
            _dataService.CentroTrabajoGetAllLavanderia(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    CentroTrabajoList = new ObservableCollection<CentroTrabajo>(lista);
                    CentroTrabajoSelected = null;
                });
        }

        private void PlantaChanged()
        {
            if (!_init || PlantaSelected == null) return;
            Refresh();
        }

        private void CentroTrabajoChanged()
        {
            if (!_init || CentroTrabajoSelected == null) return;
            Refresh();
        }

        private void Refresh()
        {
            if (PlantaSelected == null)
            {
                _dialogService.ShowMessage("No se ha seleccionado planta", "¡Error!");
                return;
            }
            if (CentroTrabajoSelected == null)
            {
                _dialogService.ShowMessage("No se ha seleccionado centro de Trabajo", "¡Error!");
                return;
            }
            _dataService.OrdenProduccionLavanderiaGet(CompaniaId, PlantaId, (short) CentroTrabajoSelected.Codigo,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    OrdenProduccionList = new ObservableCollection<OrdenProduccionLavanderia>(lista);
                    OrdenProduccionSelected = OrdenProduccionList?.FirstOrDefault();
                });
        }

        private void OrdenChanged()
        {
            if (_init && OrdenProduccionSelected != null)
            {
                
            }
        }

        #endregion
    }
}