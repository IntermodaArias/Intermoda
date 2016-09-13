using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lavanderia;
using Intermoda.Client.Lavanderia;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LavanderiaLavadoEditViewModel : ViewModelBase
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
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoIdPropertyName);
            }
        }

        #endregion

        #region LavadoNombre

        /// <summary>
        /// The <see cref="LavadoNombre" /> property's name.
        /// </summary>
        public const string LavadoNombrePropertyName = "LavadoNombre";

        private string _lavadoNombre;

        /// <summary>
        /// Sets and gets the LavadoNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoNombre
        {
            get
            {
                return _lavadoNombre;
            }

            set
            {
                if (_lavadoNombre == value)
                {
                    return;
                }

                _lavadoNombre = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoNombrePropertyName);
            }
        }

        #endregion

        #region LavadoDescripcion

        /// <summary>
        /// The <see cref="LavadoDescripcion" /> property's name.
        /// </summary>
        public const string LavadoDescripcionPropertyName = "LavadoDescripcion";

        private string _lavadoDescripcion;

        /// <summary>
        /// Sets and gets the LavadoDescripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoDescripcion
        {
            get
            {
                return _lavadoDescripcion;
            }

            set
            {
                if (_lavadoDescripcion == value)
                {
                    return;
                }

                _lavadoDescripcion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoDescripcionPropertyName);
            }
        }

        #endregion

        #region ColorId

        /// <summary>
        /// The <see cref="ColorId" /> property's name.
        /// </summary>
        public const string ColorIdPropertyName = "ColorId";

        private int _colorId;

        /// <summary>
        /// Sets and gets the ColorId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ColorId
        {
            get
            {
                return _colorId;
            }

            set
            {
                if (_colorId == value)
                {
                    return;
                }

                _colorId = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(ColorIdPropertyName);
            }
        }

        #endregion

        #region EsActivo

        /// <summary>
        /// The <see cref="EsActivo" /> property's name.
        /// </summary>
        public const string EsActivoPropertyName = "EsActivo";

        private int? _esActivo;

        /// <summary>
        /// Sets and gets the EsActivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? EsActivo
        {
            get
            {
                return _esActivo;
            }

            set
            {
                if (_esActivo == value)
                {
                    return;
                }

                _esActivo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EsActivoPropertyName);
            }
        }

        #endregion

        #region Activo

        /// <summary>
        /// The <see cref="Activo" /> property's name.
        /// </summary>
        public const string ActivoPropertyName = "Activo";

        private bool _activo;

        /// <summary>
        /// Sets and gets the Activo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Activo
        {
            get
            {
                return _activo;
            }

            set
            {
                if (_activo == value)
                {
                    return;
                }

                _activo = value;
                RaisePropertyChanged(ActivoPropertyName);
            }
        }

        #endregion

        #region LavadoFechaCreacion

        /// <summary>
        /// The <see cref="LavadoFechaCreacion" /> property's name.
        /// </summary>
        public const string LavadoFechaCreacionPropertyName = "LavadoFechaCreacion";

        private DateTime? _lavadoFechaCreacion;

        /// <summary>
        /// Sets and gets the LavadoFechaCreacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? LavadoFechaCreacion
        {
            get
            {
                return _lavadoFechaCreacion;
            }

            set
            {
                if (_lavadoFechaCreacion == value)
                {
                    return;
                }

                _lavadoFechaCreacion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoFechaCreacionPropertyName);
            }
        }

        #endregion

        #region LavadoFechaActualizacion

        /// <summary>
        /// The <see cref="LavadoFechaActualizacion" /> property's name.
        /// </summary>
        public const string LavadoFechaActualizacionPropertyName = "LavadoFechaActualizacion";

        private DateTime? _lavadofechaActualizacion;

        /// <summary>
        /// Sets and gets the LavadoFechaActualizacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? LavadoFechaActualizacion
        {
            get
            {
                return _lavadofechaActualizacion;
            }

            set
            {
                if (_lavadofechaActualizacion == value)
                {
                    return;
                }

                _lavadofechaActualizacion = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(LavadoFechaActualizacionPropertyName);
            }
        }

        #endregion

        #region ColorList

        /// <summary>
        /// The <see cref="ColorList" /> property's name.
        /// </summary>
        public const string ColorListPropertyName = "ColorList";

        private ObservableCollection<ColorIntermoda> _colorList;

        /// <summary>
        /// Sets and gets the ColorList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<ColorIntermoda> ColorList
        {
            get
            {
                return _colorList;
            }

            set
            {
                if (_colorList == value)
                {
                    return;
                }

                _colorList = value;
                RaisePropertyChanged(ColorListPropertyName);
            }
        }

        #endregion

        //

        public Lavado Lavado { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LavanderiaLavadoEditViewModel(IDataServiceLavanderia dataService, IDialogService dialogService, Lavado lavado)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            _init = false;

            if (IsInDesignMode)
            {
                _dataService.LavadoGet(1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        Lavado = reg;
                    });
            }
            else
            {
                Lavado = lavado;
            }
            LavadoId = Lavado.LavadoId;
            LavadoNombre = Lavado.LavadoNombre;
            LavadoDescripcion = Lavado.LavadoDescripcion;
            ColorId = Lavado.ColorId;
            EsActivo = Lavado.EsActivo;
            Activo = EsActivo == 1;
            LavadoFechaCreacion = Lavado.LavadoFechaCreacion;
            LavadoFechaActualizacion = Lavado.LavadoFechaActualizacion;
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
            EsActivo = Activo ? 1 : 0;
            Lavado.LavadoId = LavadoId;
            Lavado.LavadoNombre = LavadoNombre;
            Lavado.LavadoDescripcion = LavadoDescripcion;
            Lavado.ColorId = ColorId;
            Lavado.EsActivo = EsActivo;

            _dataService.LavadoUpdate(Lavado,
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
            if (Lavado == null) return false;
            EsActivo = Activo ? 1 : 0;
            return Lavado.LavadoNombre != LavadoNombre ||
                   Lavado.LavadoDescripcion != LavadoDescripcion ||
                   Lavado.ColorId != ColorId ||
                   Lavado.EsActivo != EsActivo ||
                   Lavado.LavadoFechaCreacion != LavadoFechaCreacion ||
                   Lavado.LavadoFechaActualizacion != LavadoFechaActualizacion;
        }

        #endregion
    }
}