using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaIngredienteInstruccionEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private IngredienteOperacion _ingredienteOperacion;
        private readonly bool _init;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private int _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id == value)
                {
                    return;
                }

                _id = value;
                RaisePropertyChanged(IdPropertyName);
            }
        }

        #endregion

        #region IngredienteId

        /// <summary>
        /// The <see cref="IngredienteId" /> property's name.
        /// </summary>
        public const string IngredienteIdPropertyName = "IngredienteId";

        private int _ingredienteId;

        /// <summary>
        /// Sets and gets the IngredienteId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IngredienteId
        {
            get
            {
                return _ingredienteId;
            }

            set
            {
                if (_ingredienteId == value)
                {
                    return;
                }

                _ingredienteId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(IngredienteIdPropertyName);
            }
        }

        #endregion

        #region OperacionProcesoId

        /// <summary>
        /// The <see cref="OperacionProcesoId" /> property's name.
        /// </summary>
        public const string OperacionProcesoIdPropertyName = "OperacionProcesoId";

        private int _operacionProcesoId;

        /// <summary>
        /// Sets and gets the OperacionProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionProcesoId
        {
            get
            {
                return _operacionProcesoId;
            }

            set
            {
                if (_operacionProcesoId == value)
                {
                    return;
                }

                _operacionProcesoId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OperacionProcesoIdPropertyName);
            }
        }

        #endregion

        #region InstruccionOperacionId

        /// <summary>
        /// The <see cref="InstruccionOperacionId" /> property's name.
        /// </summary>
        public const string InstruccionOperacionIdPropertyName = "InstruccionOperacionId";

        private int? _instruccionOperacionId;

        /// <summary>
        /// Sets and gets the InstruccionOperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? InstruccionOperacionId
        {
            get
            {
                return _instruccionOperacionId;
            }

            set
            {
                if (_instruccionOperacionId == value)
                {
                    return;
                }

                _instruccionOperacionId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(InstruccionOperacionIdPropertyName);
            }
        }

        #endregion

        #region ClaseId

        /// <summary>
        /// The <see cref="ClaseId" /> property's name.
        /// </summary>
        public const string ClaseIdPropertyName = "ClaseId";

        private string _claseId;

        /// <summary>
        /// Sets and gets the ClaseId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ClaseId
        {
            get
            {
                return _claseId;
            }

            set
            {
                if (_claseId == value)
                {
                    return;
                }

                _claseId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ClaseIdPropertyName);
            }
        }

        #endregion

        #region SubClaseId

        /// <summary>
        /// The <see cref="SubClaseId" /> property's name.
        /// </summary>
        public const string SubClaseIdPropertyName = "SubClaseId";

        private string _subClaseId;

        /// <summary>
        /// Sets and gets the SubClaseId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SubClaseId
        {
            get
            {
                return _subClaseId;
            }

            set
            {
                if (_subClaseId == value)
                {
                    return;
                }

                _subClaseId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(SubClaseIdPropertyName);
            }
        }

        #endregion

        #region Porcentaje

        /// <summary>
        /// The <see cref="Porcentaje" /> property's name.
        /// </summary>
        public const string PorcentajePropertyName = "Porcentaje";

        private decimal? _porcentaje;

        /// <summary>
        /// Sets and gets the Porcentaje property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? Porcentaje
        {
            get
            {
                return _porcentaje;
            }

            set
            {
                if (_porcentaje == value)
                {
                    return;
                }

                _porcentaje = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(PorcentajePropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int? _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                if (_orden == value)
                {
                    return;
                }

                _orden = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OrdenPropertyName);
            }
        }

        #endregion
        
        #region IngredienteList

        /// <summary>
        /// The <see cref="IngredienteList" /> property's name.
        /// </summary>
        public const string IngredienteListPropertyName = "IngredienteList";

        private ObservableCollection<Catalogo> _ingredienteList;

        /// <summary>
        /// Sets and gets the IngredienteList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Catalogo> IngredienteList
        {
            get
            {
                return _ingredienteList;
            }

            set
            {
                if (_ingredienteList == value)
                {
                    return;
                }

                _ingredienteList = value;
                RaisePropertyChanged(IngredienteListPropertyName);
            }
        }

        #endregion

        #region IngredienteSeleccionado

        /// <summary>
        /// The <see cref="IngredienteSeleccionado" /> property's name.
        /// </summary>
        public const string IngredienteSeleccionadoPropertyName = "IngredienteSeleccionado";

        private Catalogo _ingredienteSeleccionado;

        /// <summary>
        /// Sets and gets the IngredienteSeleccionado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Catalogo IngredienteSeleccionado
        {
            get
            {
                return _ingredienteSeleccionado;
            }

            set
            {
                if (_ingredienteSeleccionado == value)
                {
                    return;
                }

                _ingredienteSeleccionado = value;
                if (_init) IngredienteChanged();
                RaisePropertyChanged(IngredienteSeleccionadoPropertyName);
            }
        }

        #endregion


        #region Clase

        /// <summary>
        /// The <see cref="Clase" /> property's name.
        /// </summary>
        public const string ClasePropertyName = "Clase";

        private Clase _clase;

        /// <summary>
        /// Sets and gets the Clase property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Clase Clase
        {
            get
            {
                return _clase;
            }

            set
            {
                if (_clase == value)
                {
                    return;
                }

                _clase = value;
                RaisePropertyChanged(ClasePropertyName);
            }
        }

        #endregion

        #region SubClase

        /// <summary>
        /// The <see cref="SubClase" /> property's name.
        /// </summary>
        public const string SubClasePropertyName = "SubClase";

        private SubClase _subClase;

        /// <summary>
        /// Sets and gets the SubClase property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SubClase SubClase
        {
            get
            {
                return _subClase;
            }

            set
            {
                if (_subClase == value)
                {
                    return;
                }

                _subClase = value;
                RaisePropertyChanged(SubClasePropertyName);
            }
        }

        #endregion

        public OperacionProceso OperacionProceso { get; set; }
        public InstruccionOperacion InstruccionOperacion { get; set; }
        
        public Action CloseAction { get; set; }
        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaIngredienteInstruccionEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, IngredienteOperacion ingredienteOperacion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.IngredienteOperacionGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        _ingredienteOperacion = reg;
                        Initialize();
                    });
            }
            else
            {
                _ingredienteOperacion = ingredienteOperacion;
                Initialize();
            }

            RegisterCommands();
            LoadLists();

            _init = true;
        }


        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void LoadLists()
        {
            _dataService.CatalogoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    IngredienteList = new ObservableCollection<Catalogo>(lista);
                    IngredienteSeleccionado = IngredienteList?.FirstOrDefault(r => r.Id == IngredienteId);
                });
        }

        private void IngredienteChanged()
        {
            ClaseId = IngredienteSeleccionado.ClaseId;
            SubClaseId = IngredienteSeleccionado.SubClaseId;
            Clase = IngredienteSeleccionado.Clase;
            SubClase = IngredienteSeleccionado.SubClase;
        }

        private void Cancel()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _ingredienteOperacion.IngredienteId = IngredienteId;
            _ingredienteOperacion.OperacionProcesoId = OperacionProcesoId;
            _ingredienteOperacion.InstruccionOperacionId = InstruccionOperacionId;
            _ingredienteOperacion.ClaseId = IngredienteSeleccionado.ClaseId;
            _ingredienteOperacion.SubClaseId = IngredienteSeleccionado.SubClaseId;
            _ingredienteOperacion.Porcentaje = Porcentaje;
            _ingredienteOperacion.Orden = Orden;

            _dataService.IngredienteOperacionUpdate(_ingredienteOperacion,
                (updated, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OnRequestClose?.Invoke(this, new EventArgs());
                });
        }

        private bool CanConfirm()
        {
            return _ingredienteOperacion.IngredienteId != IngredienteId ||
                   _ingredienteOperacion.OperacionProcesoId != OperacionProcesoId ||
                   _ingredienteOperacion.InstruccionOperacionId != InstruccionOperacionId ||
                   _ingredienteOperacion.ClaseId != IngredienteSeleccionado.ClaseId ||
                   _ingredienteOperacion.SubClaseId != IngredienteSeleccionado.SubClaseId ||
                   _ingredienteOperacion.Porcentaje != Porcentaje ||
                   _ingredienteOperacion.Orden != Orden;
        }

        private void Initialize()
        {
            Id = _ingredienteOperacion.Id;
            IngredienteId = _ingredienteOperacion.IngredienteId;
            OperacionProcesoId = _ingredienteOperacion.OperacionProcesoId;
            InstruccionOperacionId = _ingredienteOperacion.InstruccionOperacionId;
            ClaseId = _ingredienteOperacion.ClaseId;
            SubClaseId = _ingredienteOperacion.SubClaseId;
            Porcentaje = _ingredienteOperacion.Porcentaje;
            Orden = _ingredienteOperacion.Orden;
        }


        #endregion
    }
}