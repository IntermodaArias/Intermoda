using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOpcionLavadoEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;
        private OpcionLavado _opcionLavado;
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

        #region Nombre

        /// <summary>
        /// The <see cref="Nombre" /> property's name.
        /// </summary>
        public const string NombrePropertyName = "Nombre";

        private string _nombre;

        /// <summary>
        /// Sets and gets the Nombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                if (_nombre == value)
                {
                    return;
                }

                _nombre = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(NombrePropertyName);
            }
        }

        #endregion

        #region Descripcion

        /// <summary>
        /// The <see cref="Descripcion" /> property's name.
        /// </summary>
        public const string DescripcionPropertyName = "Descripcion";

        private string _descripcion;

        /// <summary>
        /// Sets and gets the Descripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(DescripcionPropertyName);
            }
        }

        #endregion

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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoIdPropertyName);
            }
        }

        #endregion

        #region TelaId

        /// <summary>
        /// The <see cref="TelaId" /> property's name.
        /// </summary>
        public const string TelaIdPropertyName = "TelaId";

        private string _telaId;

        /// <summary>
        /// Sets and gets the TelaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaId
        {
            get
            {
                return _telaId;
            }

            set
            {
                if (_telaId == value)
                {
                    return;
                }

                _telaId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TelaIdPropertyName);
            }
        }

        #endregion

        #region IsDefault

        /// <summary>
        /// The <see cref="IsDefault" /> property's name.
        /// </summary>
        public const string IsDefaultPropertyName = "IsDefault";

        private int _isDefault;

        /// <summary>
        /// Sets and gets the IsDefault property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IsDefault
        {
            get
            {
                return _isDefault;
            }

            set
            {
                if (_isDefault == value)
                {
                    return;
                }

                _isDefault = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(IsDefaultPropertyName);
            }
        }

        #endregion

        #region LavadoList

        /// <summary>
        /// The <see cref="LavadoList" /> property's name.
        /// </summary>
        public const string LavadoListPropertyName = "LavadoList";

        private ObservableCollection<Lavado> _lavadoList;

        /// <summary>
        /// Sets and gets the LavadoList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Lavado> LavadoList
        {
            get
            {
                return _lavadoList;
            }

            set
            {
                if (_lavadoList == value)
                {
                    return;
                }

                _lavadoList = value;
                RaisePropertyChanged(LavadoListPropertyName);
            }
        }

        #endregion

        #region TelaList

        /// <summary>
        /// The <see cref="TelaList" /> property's name.
        /// </summary>
        public const string TelaListPropertyName = "TelaList";

        private ObservableCollection<Tela> _telaList;

        /// <summary>
        /// Sets and gets the TelaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Tela> TelaList
        {
            get
            {
                return _telaList;
            }

            set
            {
                if (_telaList == value)
                {
                    return;
                }

                _telaList = value;
                RaisePropertyChanged(TelaListPropertyName);
            }
        }

        #endregion

        #region LavadoIsReadOnly

        /// <summary>
        /// The <see cref="LavadoIsReadOnly" /> property's name.
        /// </summary>
        public const string LavadoIsReadOnlyPropertyName = "LavadoIsReadOnly";

        private bool _lavadoIsReadOnly;

        /// <summary>
        /// Sets and gets the LavadoIsReadOnly property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool LavadoIsReadOnly
        {
            get
            {
                return _lavadoIsReadOnly;
            }

            set
            {
                if (_lavadoIsReadOnly == value)
                {
                    return;
                }

                _lavadoIsReadOnly = value;
                RaisePropertyChanged(LavadoIsReadOnlyPropertyName);
            }
        }

        #endregion

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaOpcionLavadoEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, OpcionLavado opcionLavado, bool lavadoIsReadOnly)
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
                        _opcionLavado = reg;
                    });
            }
            else
            {
                _opcionLavado = opcionLavado;
            }

            LavadoIsReadOnly = lavadoIsReadOnly;

            PropertiesInitialization();

            RegisterCommands();

            _init = true;
        }

        #endregion

        #region Methods

        private void RegisterCommands()
        {
            CancelCommand = new RelayCommand(Cancel);
            ConfirmCommand = new RelayCommand(Confirm, CanConfirm);
        }

        private void Cancel()
        {
            OnRequestClose?.Invoke(this, new EventArgs());
        }

        private void Confirm()
        {
            _opcionLavado.Nombre = Nombre;
            _opcionLavado.Descripcion = Descripcion;
            _opcionLavado.LavadoId = LavadoId;
            _opcionLavado.TelaId = TelaId;
            _opcionLavado.IsDefault = IsDefault;


            _dataService.OpcionLavadoUpdate(_opcionLavado,
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
            return _opcionLavado.Nombre != Nombre ||
                   _opcionLavado.Descripcion != Descripcion ||
                   _opcionLavado.LavadoId != LavadoId ||
                   _opcionLavado.TelaId != TelaId ||
                   _opcionLavado.IsDefault != IsDefault;
        }

        private void PropertiesInitialization()
        {
            Id = _opcionLavado.Id;
            Nombre = _opcionLavado.Nombre;
            Descripcion = _opcionLavado.Descripcion;
            LavadoId = _opcionLavado.LavadoId;
            TelaId = _opcionLavado.TelaId;
            IsDefault = _opcionLavado.IsDefault;
        }

        #endregion
    }
}