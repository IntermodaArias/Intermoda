using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Common;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaIngredientePredefinidoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private IngredientePredefinido _ingredientePredefinido;
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

        #region OperacionId

        /// <summary>
        /// The <see cref="OperacionId" /> property's name.
        /// </summary>
        public const string OperacionIdPropertyName = "OperacionId";

        private int _operacionId;

        /// <summary>
        /// Sets and gets the OperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionId
        {
            get
            {
                return _operacionId;
            }

            set
            {
                if (_operacionId == value)
                {
                    return;
                }

                _operacionId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(OperacionIdPropertyName);
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

        #region InstruccionPredefinidaId

        /// <summary>
        /// The <see cref="InstruccionPredefinidaId" /> property's name.
        /// </summary>
        public const string InstruccionPredefinidaIdPropertyName = "InstruccionPredefinidaId";

        private int? _instruccionPredefinidaId;

        /// <summary>
        /// Sets and gets the InstruccionPredefinidaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? InstruccionPredefinidaId
        {
            get
            {
                return _instruccionPredefinidaId;
            }

            set
            {
                if (_instruccionPredefinidaId == value)
                {
                    return;
                }

                _instruccionPredefinidaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(InstruccionPredefinidaIdPropertyName);
            }
        }

        #endregion

        public List<Catalogo> IngredienteList { get; set; }
        public List<Operacion> OperacionList { get; set; }
        public List<Clase> ClaseList { get; set; }
        public List<SubClase> SubClaseList { get; set; }
        public List<InstruccionPredefinida> InstruccionPredefinidaList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaIngredientePredefinidoEditViewModel(IDataServiceLavanderia dataService,
            IDialogService dialogService, IngredientePredefinido ingredientePredefinido)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                InitInDesign();
            }
            else
            {
                InitInRuntime(ingredientePredefinido);
            }

            RegisterCommands();
            LoadData();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void LoadData()
        {
            LoadIngredienteList();
            LoadOperacionList();
            LoadClaseList();
            LoadSubClaseList();
            LoadInstruccionPredefinidaList();
        }

        private void LoadIngredienteList()
        {
            _dataService.CatalogoGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    IngredienteList = new List<Catalogo>(lista);
                });
        }

        private void LoadOperacionList()
        {
            _dataService.OperacionGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    OperacionList = new List<Operacion>(lista);
                });
        }

        private void LoadClaseList()
        {
            _dataService.ClaseGetAll(
                (lista,error)=>
            {
                if (error != null)
                {
                    Tools.ExceptionMessage(error);
                    return;
                }
                ClaseList = new List<Clase>(lista);
            });
        }

        private void LoadSubClaseList()
        {
            _dataService.SubClaseGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    SubClaseList = new List<SubClase>(lista);
                });
        }

        private void LoadInstruccionPredefinidaList()
        {
            _dataService.InstruccionPredefinidaGetAll(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    InstruccionPredefinidaList = new List<InstruccionPredefinida>(lista);
                });
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _ingredientePredefinido.Id = Id;
            _ingredientePredefinido.IngredienteId = IngredienteId;
            _ingredientePredefinido.OperacionId = OperacionId;
            _ingredientePredefinido.ClaseId = ClaseId;
            _ingredientePredefinido.SubClaseId = SubClaseId;
            _ingredientePredefinido.Porcentaje = Porcentaje;
            _ingredientePredefinido.Orden = Orden;
            _ingredientePredefinido.InstruccionPredefinidaId = InstruccionPredefinidaId;

            _dataService.IngredientePredefinidoUpdate(_ingredientePredefinido,
                (updated, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    if (OnRequestClose != null)
                        OnRequestClose(this, new EventArgs());
                });
        }

        private bool CanConfirm()
        {
            return _ingredientePredefinido.IngredienteId != IngredienteId ||
                   _ingredientePredefinido.OperacionId != OperacionId ||
                   _ingredientePredefinido.ClaseId != ClaseId ||
                   _ingredientePredefinido.SubClaseId != SubClaseId ||
                   _ingredientePredefinido.Porcentaje != Porcentaje ||
                   _ingredientePredefinido.Orden != Orden ||
                   _ingredientePredefinido.InstruccionPredefinidaId != InstruccionPredefinidaId;
        }

        private void InitInDesign()
        {
            Id = 1;
            IngredienteId = 1000;
            OperacionId = 2000;
            ClaseId = "3000";
            SubClaseId = "4000";
            Porcentaje = 40;
            Orden = 10;
            InstruccionPredefinidaId = 5000;
        }

        private void InitInRuntime(IngredientePredefinido ingredientePredefinido)
        {
            _ingredientePredefinido = ingredientePredefinido;

            Id = _ingredientePredefinido.Id;
            IngredienteId = _ingredientePredefinido.IngredienteId;
            OperacionId = _ingredientePredefinido.OperacionId;
            ClaseId = _ingredientePredefinido.ClaseId;
            SubClaseId = _ingredientePredefinido.SubClaseId;
            Porcentaje = _ingredientePredefinido.Porcentaje;
            Orden = _ingredientePredefinido.Orden;
            InstruccionPredefinidaId = _ingredientePredefinido.InstruccionPredefinidaId;
        }

        #endregion
    }
}