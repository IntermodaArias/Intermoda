using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.Lectura;
using Intermoda.Client.Lectura;
using Intermoda.Common;
using Intermoda.Common.Enum;
using Intermoda.Produccion.Lecturas.App.Helpers;

namespace Intermoda.Produccion.Lecturas.App.ViewModel
{
    public class LineaEditViewModel : ViewModelBase
    {
        private readonly IDataServiceLectura _dataService;
        private readonly IDialogService _dialogService;

        private Linea _linea;
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

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private string _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                if (_codigo == value)
                {
                    return;
                }

                _codigo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(CodigoPropertyName);
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

        #region Secuencia

        /// <summary>
        /// The <see cref="Secuencia" /> property's name.
        /// </summary>
        public const string SecuenciaPropertyName = "Secuencia";

        private int _secuencia;

        /// <summary>
        /// Sets and gets the Secuencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Secuencia
        {
            get
            {
                return _secuencia;
            }

            set
            {
                if (_secuencia == value)
                {
                    return;
                }

                _secuencia = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(SecuenciaPropertyName);
            }
        }

        #endregion

        #region Tipo

        /// <summary>
        /// The <see cref="Tipo" /> property's name.
        /// </summary>
        public const string TipoPropertyName = "Tipo";

        private LineaTipo _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LineaTipo Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                if (_tipo == value)
                {
                    return;
                }

                _tipo = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(TipoPropertyName);
            }
        }

        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private bool _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                if (_init) ConfirmCommand.RaiseCanExecuteChanged();
                RaisePropertyChanged(EstadoPropertyName);
            }
        }

        #endregion

        #region EsGrupoEnabled

        /// <summary>
        /// The <see cref="EsGrupoEnabled" /> property's name.
        /// </summary>
        public const string EsGrupoEnabledPropertyName = "EsGrupoEnabled";

        private bool _esGrupoEnabled;

        /// <summary>
        /// Sets and gets the EsGrupoEnabled property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsGrupoEnabled
        {
            get
            {
                return _esGrupoEnabled;
            }

            set
            {
                if (_esGrupoEnabled == value)
                {
                    return;
                }

                _esGrupoEnabled = value;
                RaisePropertyChanged(EsGrupoEnabledPropertyName);
            }
        }

        #endregion
        
        public Grupo Grupo { get; set; }

        public List<EnumModel> TipoList { get; set; }

        public List<Grupo> GrupoList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CancelCommand { get; set; }
        public RelayCommand ConfirmCommand { get; set; }

        #endregion

        #region Constructor

        public LineaEditViewModel(IDataServiceLectura dataService, IDialogService dialogService, Linea linea)
        {
            _dataService = dataService;
            _dialogService = dialogService;
            _init = false;

            LoadCombos();

            if (IsInDesignMode)
            {
                Id = 1;
                Grupo = new Grupo
                {
                    Id = 1000,
                    Codigo = "00001",
                    Nombre = "Grupo No. 000001",
                    FechaInicio = new DateTime(2016, 1, 4),
                    FechaFinal = new DateTime(2016, 1, 10),
                    Secuencia = 10,
                    Estado = true
                };
                Codigo = "000001";
                Nombre = "Linea No. 000001";
                Secuencia = 10;
                Tipo = LineaTipo.SalidaUnica;
                Estado = true;
                _linea = new Linea
                {
                    Id = Id,
                    GrupoId = Grupo.Id,
                    Codigo = Codigo,
                    Nombre = Nombre,
                    Secuencia = Secuencia,
                    Tipo = (ClientProxy.Lectura.LineaServiceReference.LineaTipo) Tipo,
                    Estado = Estado
                };
                EsGrupoEnabled = false;
            }
            else
            {
                _linea = linea;
                Id = linea.Id;
                Grupo = Grupo;
                Codigo = linea.Codigo;
                Nombre = linea.Nombre;
                Secuencia = linea.Secuencia;
                Tipo = (LineaTipo) linea.Tipo;
                Estado = linea.Estado;

                EsGrupoEnabled = Grupo != null;
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

        private void LoadCombos()
        {
            _dataService.GrupoGetAllActivos(
                (lista, error) =>
                {
                    if (error != null)
                    {
                        Tools.ExceptionMessage(error);
                        return;
                    }
                    GrupoList = new List<Grupo>(lista);
                });

            var enums = Enum.GetValues(typeof (LineaTipo));
            TipoList = (from object e in enums
                select new EnumModel
                {
                    Value = (int) e,
                    Name = e.ToString()
                }).ToList();
        }

        private void Cancel()
        {
            if (OnRequestClose != null)
                OnRequestClose(this, new EventArgs());
        }

        private void Confirm()
        {
            _linea.GrupoId = Grupo.Id;
            _linea.Codigo = Codigo;
            _linea.Nombre = Nombre;
            _linea.Secuencia = Secuencia;
            _linea.Tipo = (ClientProxy.Lectura.LineaServiceReference.LineaTipo) Tipo;
            _linea.Estado = Estado;
            _dataService.LineaUpdate(_linea,
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
            return _linea.Codigo != Codigo ||
                   _linea.Nombre != Nombre ||
                   _linea.Secuencia != Secuencia ||
                   _linea.Estado != Estado ||
                   _linea.Tipo != (ClientProxy.Lectura.LineaServiceReference.LineaTipo) Tipo ||
                   _linea.GrupoId != Grupo.Id;
        }

        #endregion
    }
}