using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaLavadoRecetaViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private readonly bool _init;

        #region Properties

        public OpcionLavado OpcionLavado { get; set; }

        #region CentroTrabajoOpcionList

        /// <summary>
        /// The <see cref="CentroTrabajoOpcionList" /> property's name.
        /// </summary>
        public const string CentroTrabajoOpcionListPropertyName = "CentroTrabajoOpcionList";

        private ObservableCollection<CentroTrabajoOpcion> _centroTrabajoOpcionList;

        /// <summary>
        /// Sets and gets the CentroTrabajoOpcionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<CentroTrabajoOpcion> CentroTrabajoOpcionList
        {
            get
            {
                return _centroTrabajoOpcionList;
            }

            set
            {
                if (_centroTrabajoOpcionList == value)
                {
                    return;
                }

                _centroTrabajoOpcionList = value;
                RaisePropertyChanged(CentroTrabajoOpcionListPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoOpcionSelected

        /// <summary>
        /// The <see cref="CentroTrabajoOpcionSelected" /> property's name.
        /// </summary>
        public const string CentroTrabajoOpcionSelectedPropertyName = "CentroTrabajoOpcionSelected";

        private CentroTrabajoOpcion _centroTrabajoOpcionSelected;

        /// <summary>
        /// Sets and gets the CentroTrabajoOpcionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajoOpcion CentroTrabajoOpcionSelected
        {
            get
            {
                return _centroTrabajoOpcionSelected;
            }

            set
            {
                if (_centroTrabajoOpcionSelected == value)
                {
                    return;
                }

                _centroTrabajoOpcionSelected = value;
                if (_init)
                {
                    RefreshProceso();
                    EditCentroTrabajoCommand.RaiseCanExecuteChanged();
                    DeleteCentroTrabajoCommand.RaiseCanExecuteChanged();
                }

                RaisePropertyChanged(CentroTrabajoOpcionSelectedPropertyName);
            }
        }

        #endregion

        #region ProcesoCentroTrabajoList

        /// <summary>
        /// The <see cref="ProcesoCentroTrabajoList" /> property's name.
        /// </summary>
        public const string ProcesoCentroTrabajoListPropertyName = "ProcesoCentroTrabajoList";

        private ObservableCollection<ProcesoCentroTrabajo> _procesoCentroTrabajoList;

        /// <summary>
        /// Sets and gets the ProcesoCentroTrabajoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ProcesoCentroTrabajo> ProcesoCentroTrabajoList
        {
            get
            {
                return _procesoCentroTrabajoList;
            }

            set
            {
                if (_procesoCentroTrabajoList == value)
                {
                    return;
                }

                _procesoCentroTrabajoList = value;
                RaisePropertyChanged(ProcesoCentroTrabajoListPropertyName);
            }
        }

        #endregion

        #region ProcesoCentroTrabajoSelected

        /// <summary>
        /// The <see cref="ProcesoCentroTrabajoSelected" /> property's name.
        /// </summary>
        public const string ProcesoCentroTrabajoSelectedPropertyName = "ProcesoCentroTrabajoSelected";

        private ProcesoCentroTrabajo _procesoCentroTrabajoSelected;

        /// <summary>
        /// Sets and gets the ProcesoCentroTrabajoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ProcesoCentroTrabajo ProcesoCentroTrabajoSelected
        {
            get
            {
                return _procesoCentroTrabajoSelected;
            }

            set
            {
                if (_procesoCentroTrabajoSelected == value)
                {
                    return;
                }

                _procesoCentroTrabajoSelected = value;
                if (_init)
                {
                    RefreshOperacion();
                    EditProcesoCommand.RaiseCanExecuteChanged();
                    DeleteProcesoCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(ProcesoCentroTrabajoSelectedPropertyName);
            }
        }

        #endregion

        #region OperacionProcesoList

        /// <summary>
        /// The <see cref="OperacionProcesoList" /> property's name.
        /// </summary>
        public const string OperacionProcesoListPropertyName = "OperacionProcesoList";

        private ObservableCollection<OperacionProceso> _operacionProcesoList;

        /// <summary>
        /// Sets and gets the OperacionProcesoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<OperacionProceso> OperacionProcesoList
        {
            get
            {
                return _operacionProcesoList;
            }

            set
            {
                if (_operacionProcesoList == value)
                {
                    return;
                }

                _operacionProcesoList = value;
                RaisePropertyChanged(OperacionProcesoListPropertyName);
            }
        }

        #endregion

        #region OperacionProcesoSelected

        /// <summary>
        /// The <see cref="OperacionProcesoSelected" /> property's name.
        /// </summary>
        public const string OperacionProcesoSelectedPropertyName = "OperacionProcesoSelected";

        private OperacionProceso _operacionProcesoSelected;

        /// <summary>
        /// Sets and gets the OperacionProcesoSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OperacionProceso OperacionProcesoSelected
        {
            get
            {
                return _operacionProcesoSelected;
            }

            set
            {
                if (_operacionProcesoSelected == value)
                {
                    return;
                }
                _operacionProcesoSelected = value;
                if (_init)
                {
                    RefreshInstruccion();
                    RefreshObservacion();
                    EditOperacionCommand.RaiseCanExecuteChanged();
                    DeleteOperacionCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(OperacionProcesoSelectedPropertyName);
            }
        }

        #endregion

        #region InstruccionOperacionList

        /// <summary>
        /// The <see cref="InstruccionOperacionList" /> property's name.
        /// </summary>
        public const string InstruccionOperacionListPropertyName = "InstruccionOperacionList";

        private ObservableCollection<InstruccionOperacion> _instruccionOperacionList;

        /// <summary>
        /// Sets and gets the InstruccionOperacionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<InstruccionOperacion> InstruccionOperacionList
        {
            get
            {
                return _instruccionOperacionList;
            }

            set
            {
                if (_instruccionOperacionList == value)
                {
                    return;
                }

                _instruccionOperacionList = value;
                RaisePropertyChanged(InstruccionOperacionListPropertyName);
            }
        }

        #endregion

        #region InstruccionOperacionSelected

        /// <summary>
        /// The <see cref="InstruccionOperacionSelected" /> property's name.
        /// </summary>
        public const string InstruccionOperacionSelectedPropertyName = "InstruccionOperacionSelected";

        private InstruccionOperacion _instruccionOperacionSelected;

        /// <summary>
        /// Sets and gets the InstruccionOperacionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public InstruccionOperacion InstruccionOperacionSelected
        {
            get
            {
                return _instruccionOperacionSelected;
            }

            set
            {
                if (_instruccionOperacionSelected == value)
                {
                    return;
                }

                _instruccionOperacionSelected = value;
                if (_init)
                {
                    RefreshMaterial();
                    EditInstruccionCommand.RaiseCanExecuteChanged();
                    DeleteInstruccionCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(InstruccionOperacionSelectedPropertyName);
            }
        }

        #endregion

        #region IngredienteOperacionList

        /// <summary>
        /// The <see cref="IngredienteOperacionList" /> property's name.
        /// </summary>
        public const string IngredienteOperacionListPropertyName = "IngredienteOperacionList";

        private ObservableCollection<IngredienteOperacion> _ingredienteOperacionList;

        /// <summary>
        /// Sets and gets the IngredienteOperacionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<IngredienteOperacion> IngredienteOperacionList
        {
            get
            {
                return _ingredienteOperacionList;
            }

            set
            {
                if (_ingredienteOperacionList == value)
                {
                    return;
                }

                _ingredienteOperacionList = value;
                RaisePropertyChanged(IngredienteOperacionListPropertyName);
            }
        }

        #endregion

        #region IngredienteOperacionSelected

        /// <summary>
        /// The <see cref="IngredienteOperacionSelected" /> property's name.
        /// </summary>
        public const string IngredienteOperacionSelectedPropertyName = "IngredienteOperacionSelected";

        private IngredienteOperacion _ingredienteOperacionSelected;

        /// <summary>
        /// Sets and gets the IngredienteOperacionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public IngredienteOperacion IngredienteOperacionSelected
        {
            get
            {
                return _ingredienteOperacionSelected;
            }

            set
            {
                if (_ingredienteOperacionSelected == value)
                {
                    return;
                }

                _ingredienteOperacionSelected = value;
                if (_init)
                {
                    EditMaterialCommand.RaiseCanExecuteChanged();
                    DeleteMaterialCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(IngredienteOperacionSelectedPropertyName);
            }
        }

        #endregion

        #region ObservacionOperacionList

        /// <summary>
        /// The <see cref="ObservacionOperacionList" /> property's name.
        /// </summary>
        public const string ObservacionOperacionListPropertyName = "ObservacionOperacionList";

        private ObservableCollection<ObservacionOperacion> _observacionOperacionList;

        /// <summary>
        /// Sets and gets the ObservacionOperacionList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ObservacionOperacion> ObservacionOperacionList
        {
            get
            {
                return _observacionOperacionList;
            }

            set
            {
                if (_observacionOperacionList == value)
                {
                    return;
                }

                _observacionOperacionList = value;
                RaisePropertyChanged(ObservacionOperacionListPropertyName);
            }
        }

        #endregion

        #region ObservacionOperacionSelected

        /// <summary>
        /// The <see cref="ObservacionOperacionSelected" /> property's name.
        /// </summary>
        public const string ObservacionOperacionSelectedPropertyName = "ObservacionOperacionSelected";

        private ObservacionOperacion _observacionOperacionSelected;

        /// <summary>
        /// Sets and gets the ObservacionOperacionSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservacionOperacion ObservacionOperacionSelected
        {
            get
            {
                return _observacionOperacionSelected;
            }

            set
            {
                if (_observacionOperacionSelected == value)
                {
                    return;
                }

                _observacionOperacionSelected = value;
                if (_init)
                {
                    EditObservacionCommand.RaiseCanExecuteChanged();
                    DeleteObservacionCommand.RaiseCanExecuteChanged();
                }
                RaisePropertyChanged(ObservacionOperacionSelectedPropertyName);
            }
        }

        #endregion

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        #region Centro de Trabajo

        public RelayCommand InsertCentroTrabajoCommand { get; set; }
        public RelayCommand EditCentroTrabajoCommand { get; set; }
        public RelayCommand DeleteCentroTrabajoCommand { get; set; }
        public RelayCommand RefreshCentroTrabajoCommand { get; set; }

        #endregion
        
        #region Proceso

        public RelayCommand InsertProcesoCommand { get; set; }
        public RelayCommand EditProcesoCommand { get; set; }
        public RelayCommand DeleteProcesoCommand { get; set; }
        public RelayCommand RefreshProcesoCommand { get; set; }

        #endregion

        #region Operacion

        public RelayCommand InsertOperacionCommand { get; set; }
        public RelayCommand EditOperacionCommand { get; set; }
        public RelayCommand DeleteOperacionCommand { get; set; }
        public RelayCommand RefreshOperacionCommand { get; set; }

        #endregion

        #region Instruccion

        public RelayCommand InsertInstruccionCommand { get; set; }
        public RelayCommand EditInstruccionCommand { get; set; }
        public RelayCommand DeleteInstruccionCommand { get; set; }
        public RelayCommand RefreshInstruccionCommand { get; set; }

        #endregion
        
        #region Material

        public RelayCommand InsertMaterialCommand { get; set; }
        public RelayCommand EditMaterialCommand { get; set; }
        public RelayCommand DeleteMaterialCommand { get; set; }
        public RelayCommand RefreshMaterialCommand { get; set; }

        #endregion
        
        #region Observacion

        public RelayCommand InsertObservacionCommand { get; set; }
        public RelayCommand EditObservacionCommand { get; set; }
        public RelayCommand DeleteObservacionCommand { get; set; }
        public RelayCommand RefreshObservacionCommand { get; set; }

        #endregion

        public RelayCommand CancelCommand { get; set; }
        
        #endregion

        #region Constructor

        public LavanderiaLavadoRecetaViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, OpcionLavado opcionLavado)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.OpcionLavadoGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        OpcionLavado = reg;
                    });
            }
            else
            {
                OpcionLavado = opcionLavado;
            }

            RegisterCommands();
            RefreshCentroTrabajo();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            #region Centro de Trabajo

            InsertCentroTrabajoCommand = new RelayCommand(InsertCentroTrabajo, CanInsertCentroTrabajo);
            EditCentroTrabajoCommand = new RelayCommand(EditCentroTrabajo, CanEditCentroTrabajo);
            DeleteCentroTrabajoCommand = new RelayCommand(DeleteCentroTrabajo, CanDeleteCentroTrabajo);
            RefreshCentroTrabajoCommand = new RelayCommand(RefreshCentroTrabajo);

            #endregion

            #region Proceso

            InsertProcesoCommand = new RelayCommand(InsertProceso, CanInsertProceso);
            EditProcesoCommand = new RelayCommand(EditProceso, CanEditProceso);
            DeleteProcesoCommand = new RelayCommand(DeleteProceso, CanDeleteProceso);
            RefreshProcesoCommand = new RelayCommand(RefreshProceso);

            #endregion

            #region Operacion

            InsertOperacionCommand = new RelayCommand(InsertOperacion, CanInsertOperacion);
            EditOperacionCommand = new RelayCommand(EditOperacion, CanEditOperacion);
            DeleteOperacionCommand = new RelayCommand(DeleteOperacion, CanDeleteOperacion);
            RefreshOperacionCommand = new RelayCommand(RefreshOperacion);

            #endregion

            #region Instruccion

            InsertInstruccionCommand = new RelayCommand(InsertInstruccion, CanInsertInstruccion);
            EditInstruccionCommand = new RelayCommand(EditInstruccion, CanEditInstruccion);
            DeleteInstruccionCommand = new RelayCommand(DeleteInstruccion, CanDeleteInstruccion);
            RefreshInstruccionCommand = new RelayCommand(RefreshInstruccion);

            #endregion

            #region Material

            InsertMaterialCommand = new RelayCommand(InsertMaterial, CanInsertMaterial);
            EditMaterialCommand = new RelayCommand(EditMaterial, CanEditMaterial);
            DeleteMaterialCommand = new RelayCommand(DeleteMaterial, CanDeleteMaterial);
            RefreshMaterialCommand = new RelayCommand(RefreshMaterial);

            #endregion

            #region Observacion

            InsertObservacionCommand = new RelayCommand(InsertObservacion, CanInsertObservacion);
            EditObservacionCommand = new RelayCommand(EditObservacion, CanEditObservacion);
            DeleteObservacionCommand = new RelayCommand(DeleteObservacion, CanDeleteObservacion);
            RefreshObservacionCommand = new RelayCommand(RefreshObservacion);

            #endregion

            CancelCommand = new RelayCommand(Cancel);
        }

        #region Centro de Trabajo

        private void InsertCentroTrabajo()
        {
            var reg = new CentroTrabajoOpcion
            {
                OpcionLavado = OpcionLavado
            };
            _dialogService.LavanderiaCentroTrabajoOpcionEdit(_dataService, _dialogService, reg);
            RefreshCentroTrabajo();
        }

        private void EditCentroTrabajo()
        {
            _dialogService.LavanderiaCentroTrabajoOpcionEdit(_dataService, _dialogService, CentroTrabajoOpcionSelected);
            RefreshCentroTrabajo();
        }

        private void DeleteCentroTrabajo()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el centro de trabajo?", "Confirmación");

            if (result != MessageBoxResult.OK)
                return;

            _dataService.CentroTrabajoOpcionDelete(CentroTrabajoOpcionSelected.Id,
                error =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    RefreshCentroTrabajo();
                });
        }

        private void RefreshCentroTrabajo()
        {
            if (OpcionLavado == null)
                return;

            _dataService.CentroTrabajoOpcionGetByOpcion(OpcionLavado.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    CentroTrabajoOpcionList = new ObservableCollection<CentroTrabajoOpcion>(lista);
                    CentroTrabajoOpcionSelected = CentroTrabajoOpcionList?.FirstOrDefault();
                });
        }

        private bool CanInsertCentroTrabajo()
        {
            return OpcionLavado != null && OpcionLavado.Id > 0;
        }

        private bool CanEditCentroTrabajo()
        {
            return CentroTrabajoOpcionSelected != null;
        }

        private bool CanDeleteCentroTrabajo()
        {
            return CentroTrabajoOpcionSelected != null;
        }

        #endregion

        #region Proceso

        private void InsertProceso()
        {
            var reg = new ProcesoCentroTrabajo
            {
                CentroTrabajo = CentroTrabajoOpcionSelected.CentroTrabajo,
                CentroTrabajoOpcion = CentroTrabajoOpcionSelected,
                CentroTrabajoId = CentroTrabajoOpcionSelected.CentroTrabajoId,
                CentroTrabajoOpcionId = CentroTrabajoOpcionSelected.Id
            };
            _dialogService.LavanderiaProcesoCentroTrabajoEdit(_dataService, _dialogService, reg);
            RefreshProceso();
        }

        private void EditProceso()
        {
            _dialogService.LavanderiaProcesoCentroTrabajoEdit(_dataService, _dialogService, ProcesoCentroTrabajoSelected);
            RefreshProceso();
        }

        private void DeleteProceso()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el proceso?", "Confirmación");

            if (result != MessageBoxResult.OK)
                return;

            _dataService.ProcesoCentroTrabajoDelete(ProcesoCentroTrabajoSelected.Id,
                error =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    RefreshProceso();
                });
        }

        private void RefreshProceso()
        {
            if (CentroTrabajoOpcionSelected == null)
            {
                ProcesoCentroTrabajoList = null;
                ProcesoCentroTrabajoSelected = null;
                return;
            }

            _dataService.ProcesoCentroTrabajoGetByCentroTrabajoOpcion(CentroTrabajoOpcionSelected.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ProcesoCentroTrabajoList = new ObservableCollection<ProcesoCentroTrabajo>(lista);
                    ProcesoCentroTrabajoSelected = ProcesoCentroTrabajoList?.FirstOrDefault();
                });
        }

        private bool CanInsertProceso()
        {
            return CentroTrabajoOpcionSelected != null;
        }

        private bool CanEditProceso()
        {
            return ProcesoCentroTrabajoSelected != null;
        }

        private bool CanDeleteProceso()
        {
            return ProcesoCentroTrabajoSelected != null;
        }

        #endregion

        #region Operacion

        private void InsertOperacion()
        {
            var reg = new OperacionProceso
            {
                ProcesoCentroTrabajoId = OperacionProcesoSelected.ProcesoCentroTrabajoId,
                ProcesoId = OperacionProcesoSelected.ProcesoId,
                ProcesoCentroTrabajo = OperacionProcesoSelected.ProcesoCentroTrabajo,
                Proceso = OperacionProcesoSelected.Proceso
            };
            _dialogService.LavanderiaOperacionProcesoEdit(_dataService, _dialogService, reg);
            RefreshOperacion();
        }

        private void EditOperacion()
        {
            _dialogService.LavanderiaOperacionProcesoEdit(_dataService, _dialogService, OperacionProcesoSelected);
            RefreshOperacion();
        }

        private void DeleteOperacion()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar la operación?", "Confirmación");

            if (result != MessageBoxResult.OK)
                return;

            _dataService.CentroTrabajoOpcionDelete(CentroTrabajoOpcionSelected.Id,
                error =>
                {
                    if (error!=null)
                        _dialogService.ShowException(error);
                });
        }

        private void RefreshOperacion()
        {
            if (ProcesoCentroTrabajoSelected == null)
                return;

            _dataService.OperacionProcesoGetByProcesoCentroTrabajo(ProcesoCentroTrabajoSelected.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OperacionProcesoList = new ObservableCollection<OperacionProceso>(lista);
                    OperacionProcesoSelected = OperacionProcesoList?.FirstOrDefault();
                });
        }

        private bool CanInsertOperacion()
        {
            return ProcesoCentroTrabajoSelected != null;
        }

        private bool CanEditOperacion()
        {
            return OperacionProcesoSelected != null;
        }

        private bool CanDeleteOperacion()
        {
            return OperacionProcesoSelected != null;
        }

        #endregion

        #region Instruccion

        private void InsertInstruccion()
        {
            var reg = new InstruccionOperacion
            {
                OperacionProcesoId = OperacionProcesoSelected.Id,
                OperacionProceso = OperacionProcesoSelected
            };
            _dialogService.LavanderiaInstruccionOperacionEdit(_dataService, _dialogService, reg);
            RefreshInstruccion();
        }

        private void EditInstruccion()
        {
            _dialogService.LavanderiaInstruccionOperacionEdit(_dataService, _dialogService, InstruccionOperacionSelected);
            RefreshInstruccion();
        }

        private void DeleteInstruccion()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar la instrucción?", "Confirmación");

            if (result != MessageBoxResult.OK)
                return;

            _dataService.InstruccionOperacionDelete(InstruccionOperacionSelected.Id,
                error =>
                {
                    if (error != null)
                        _dialogService.ShowException(error);
                });
        }

        private void RefreshInstruccion()
        {
            if (OperacionProcesoSelected == null)
                return;

            _dataService.InstruccionOperacionGetByOperacionProceso(OperacionProcesoSelected.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    InstruccionOperacionList = new ObservableCollection<InstruccionOperacion>(lista);
                    InstruccionOperacionSelected = InstruccionOperacionList?.FirstOrDefault();
                });
        }

        private bool CanInsertInstruccion()
        {
            return OperacionProcesoSelected != null;
        }

        private bool CanEditInstruccion()
        {
            return InstruccionOperacionSelected != null;
        }

        private bool CanDeleteInstruccion()
        {
            return InstruccionOperacionSelected != null;
        }

        #endregion

        #region Material

        private void InsertMaterial()
        {
            var reg = new IngredienteOperacion
            {
                OperacionId = OperacionProcesoSelected.OperacionId,
                OperacionProcesoId = OperacionProcesoSelected.Id,
                InstruccionOperacionId = InstruccionOperacionSelected.Id,
                Operacion = OperacionProcesoSelected.Operacion,
                OperacionProceso = OperacionProcesoSelected,
                InstruccionOperacion = InstruccionOperacionSelected
            };
            _dialogService.LavanderiaIngredienteInstruccionEdit(_dataService, _dialogService, reg);
            RefreshMaterial();
        }

        private void EditMaterial()
        {
            _dialogService.LavanderiaIngredienteInstruccionEdit(_dataService, _dialogService,
                IngredienteOperacionSelected);
            RefreshMaterial();
        }

        private void DeleteMaterial()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar el ingrediente?", "Confirmación");

            if (result != MessageBoxResult.OK)
                return;

            _dataService.IngredienteOperacionDelete(IngredienteOperacionSelected.Id,
                error =>
                {
                    if (error != null)
                        _dialogService.ShowException(error);
                });
        }

        private void RefreshMaterial()
        {
            if (InstruccionOperacionSelected == null) return;

            _dataService.IngredienteOperacionGetByInstruccionOperacion(InstruccionOperacionSelected.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    IngredienteOperacionList = new ObservableCollection<IngredienteOperacion>(lista);
                    IngredienteOperacionSelected = IngredienteOperacionList?.FirstOrDefault();
                });
        }

        private bool CanInsertMaterial()
        {
            return InstruccionOperacionSelected != null;
        }

        private bool CanEditMaterial()
        {
            return IngredienteOperacionSelected != null;
        }

        private bool CanDeleteMaterial()
        {
            return IngredienteOperacionSelected != null;
        }

        #endregion

        #region Observacion

        private void InsertObservacion()
        {
            var reg = new ObservacionOperacion
            {
                OperacionProcesoId = OperacionProcesoSelected.Id,
                OperacionProceso = OperacionProcesoSelected
            };
            _dialogService.LavanderiaObservacionOperacionEdit(_dataService, _dialogService, reg);
            RefreshObservacion();
        }

        private void EditObservacion()
        {
            _dialogService.LavanderiaObservacionOperacionEdit(_dataService, _dialogService, ObservacionOperacionSelected);
            RefreshObservacion();
        }

        private void DeleteObservacion()
        {
            var result = _dialogService.ConfirmAction("¿Está seguro de querer eliminar la observación?", "Confirmación");

            if (result != MessageBoxResult.OK)
                return;

            _dataService.ObservacionOperacionDelete(ObservacionOperacionSelected.Id,
                error =>
                {
                    if (error != null)
                        _dialogService.ShowException(error);
                });
        }

        private void RefreshObservacion()
        {
            if (ObservacionOperacionSelected == null)
                return;

            _dataService.ObservacionOperacionGetByOperacionProceso(OperacionProcesoSelected.Id,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    ObservacionOperacionList = new ObservableCollection<ObservacionOperacion>(lista);
                    ObservacionOperacionSelected = ObservacionOperacionList?.FirstOrDefault();
                });
        }

        private bool CanInsertObservacion()
        {
            return OperacionProcesoSelected != null;
        }

        private bool CanEditObservacion()
        {
            return ObservacionOperacionSelected != null;
        }

        private bool CanDeleteObservacion()
        {
            return ObservacionOperacionSelected != null;
        }

        #endregion

        private void Cancel()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}