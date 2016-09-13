using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaOperacionEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLavanderia _dataService;
        private readonly IDialogService _dialogService;

        private Operacion _operacion;
        private readonly bool _init;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private int _myProperty;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Id
        {
            get
            {
                return _myProperty;
            }

            set
            {
                if (_myProperty == value)
                {
                    return;
                }

                _myProperty = value;
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
                RaisePropertyChanged(DescripcionPropertyName);
            }
        }

        #endregion

        #region OperacionTipoId

        /// <summary>
        /// The <see cref="OperacionTipoId" /> property's name.
        /// </summary>
        public const string OperacionTipoIdPropertyName = "OperacionTipoId";

        private short _operacionTipoId;

        /// <summary>
        /// Sets and gets the OperacionTipoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short OperacionTipoId
        {
            get
            {
                return _operacionTipoId;
            }

            set
            {
                if (_operacionTipoId == value)
                {
                    return;
                }

                _operacionTipoId = value;
                RaisePropertyChanged(OperacionTipoIdPropertyName);
            }
        }

        #endregion

        #region GrupoId

        /// <summary>
        /// The <see cref="GrupoId" /> property's name.
        /// </summary>
        public const string GrupoIdPropertyName = "GrupoId";

        private short _grupoId;

        /// <summary>
        /// Sets and gets the GrupoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short GrupoId
        {
            get
            {
                return _grupoId;
            }

            set
            {
                if (_grupoId == value)
                {
                    return;
                }

                _grupoId = value;
                RaisePropertyChanged(GrupoIdPropertyName);
            }
        }

        #endregion

        #region LineaProduccionId

        /// <summary>
        /// The <see cref="LineaProduccionId" /> property's name.
        /// </summary>
        public const string LineaProduccionIdPropertyName = "LineaProduccionId";

        private int _lineaProduccionId;

        /// <summary>
        /// Sets and gets the LineaProduccionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LineaProduccionId
        {
            get
            {
                return _lineaProduccionId;
            }

            set
            {
                if (_lineaProduccionId == value)
                {
                    return;
                }

                _lineaProduccionId = value;
                RaisePropertyChanged(LineaProduccionIdPropertyName);
            }
        }

        #endregion

        #region OperacionPreDefinida

        /// <summary>
        /// The <see cref="OperacionPreDefinida" /> property's name.
        /// </summary>
        public const string OperacionPreDefinidaPropertyName = "OperacionPreDefinida";

        private OperacionPredefinida _operacionPredefinida;

        /// <summary>
        /// Sets and gets the OperacionPreDefinida property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OperacionPredefinida OperacionPreDefinida
        {
            get
            {
                return _operacionPredefinida;
            }

            set
            {
                if (_operacionPredefinida == value)
                {
                    return;
                }

                _operacionPredefinida = value;
                RaisePropertyChanged(OperacionPreDefinidaPropertyName);
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

        public LavanderiaOperacionEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Operacion operacion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                Id = 1;
                Nombre = "Operación No. 000001";
                Descripcion = "Descripción de la Operación No. 000001";
                OperacionTipoId = 1000;
                GrupoId = 2000;
                LineaProduccionId = 3000;
                OperacionPreDefinida = new OperacionPredefinida
                {
                    Id = 10,
                    OperacionId = 1,
                    Temperatura = 80,
                    Ph = "10",
                    RelacionBano = 5,
                    Secuencia = 100,
                    TiempoMinimo = 10,
                    TiempoMaximo = 20
                };
            }
            else
            {
                _operacion = operacion;
                Id = _operacion.Id;
                Nombre = _operacion.Nombre;
                Descripcion = _operacion.Descripcion;
                OperacionTipoId = _operacion.OperacionTipoId;
                GrupoId = _operacion.GrupoId;
                LineaProduccionId = _operacion.LineaProduccionId;
                OperacionPreDefinida = new OperacionPredefinida
                {
                    Id = _operacion.OperacionPredefinida.Id,
                    OperacionId = _operacion.OperacionPredefinida.OperacionId,
                    Temperatura = _operacion.OperacionPredefinida.Temperatura,
                    Ph = _operacion.OperacionPredefinida.Ph,
                    RelacionBano = _operacion.OperacionPredefinida.RelacionBano,
                    Secuencia = _operacion.OperacionPredefinida.Secuencia,
                    TiempoMinimo = _operacion.OperacionPredefinida.TiempoMinimo,
                    TiempoMaximo = _operacion.OperacionPredefinida.TiempoMaximo
                };
            }

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
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _operacion.Nombre = Nombre;
            _operacion.Descripcion = Descripcion;
            _operacion.OperacionTipoId = OperacionTipoId;
            _operacion.GrupoId = GrupoId;
            _operacion.LineaProduccionId = LineaProduccionId;
            _operacionPredefinida = OperacionPreDefinida;

            _dataService.OperacionUpdate(_operacion,
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
            return _operacion.Nombre != Nombre ||
                   _operacion.Descripcion != Descripcion ||
                   _operacion.OperacionTipoId!= OperacionTipoId ||
                   _operacion.GrupoId != GrupoId ||
                   _operacion.LineaProduccionId != LineaProduccionId ||
                   _operacion.OperacionPredefinida != OperacionPreDefinida;
        }

        #endregion
    }
}