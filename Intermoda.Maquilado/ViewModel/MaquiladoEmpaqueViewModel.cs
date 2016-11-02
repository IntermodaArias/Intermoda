using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Maquilado.Helpers;
using Intermoda.Maquilado.Model;

namespace Intermoda.Maquilado.ViewModel
{
    public class MaquiladoEmpaqueViewModel : ViewModelBase
    {
        private readonly IDataServiceLbDatPro _dataService;
        private readonly IDialogService _dialogService;

        #region Properties

        public OrdenProduccionExterno OrdenProduccion { get; set; }

        #region CantidadTotal

        /// <summary>
        /// The <see cref="CantidadTotal" /> property's name.
        /// </summary>
        public const string CantidadTotalPropertyName = "CantidadTotal";

        private int _cantidadTotal;

        /// <summary>
        /// Sets and gets the CantidadTotal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CantidadTotal
        {
            get
            {
                return _cantidadTotal;
            }

            set
            {
                if (_cantidadTotal == value)
                {
                    return;
                }

                _cantidadTotal = value;
                RaisePropertyChanged(CantidadTotalPropertyName);
            }
        }

        #endregion

        #region CantidadEmpacada

        /// <summary>
        /// The <see cref="CantidadEmpacada" /> property's name.
        /// </summary>
        public const string CantidadEmpacadaPropertyName = "CantidadEmpacada";

        private int _cantidadEmpacada;

        /// <summary>
        /// Sets and gets the CantidadEmpacada property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CantidadEmpacada
        {
            get
            {
                return _cantidadEmpacada;
            }

            set
            {
                if (_cantidadEmpacada == value)
                {
                    return;
                }

                _cantidadEmpacada = value;
                RaisePropertyChanged(CantidadEmpacadaPropertyName);
            }
        }

        #endregion

        #region CantidadPendiente

        /// <summary>
        /// The <see cref="CantidadPendiente" /> property's name.
        /// </summary>
        public const string CantidadPendientePropertyName = "CantidadPendiente";

        private int _cantidadPendiente;

        /// <summary>
        /// Sets and gets the CantidadPendiente property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CantidadPendiente
        {
            get
            {
                return _cantidadPendiente;
            }

            set
            {
                if (_cantidadPendiente == value)
                {
                    return;
                }

                _cantidadPendiente = value;
                RaisePropertyChanged(CantidadPendientePropertyName);
            }
        }

        #endregion

        #region Lectura

        /// <summary>
        /// The <see cref="Lectura" /> property's name.
        /// </summary>
        public const string LecturaPropertyName = "Lectura";

        private string _lectura;

        /// <summary>
        /// Sets and gets the Lectura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Lectura
        {
            get
            {
                return _lectura;
            }

            set
            {
                if (_lectura == value)
                {
                    return;
                }

                _lectura = value;
                RaisePropertyChanged(LecturaPropertyName);
            }
        }

        #endregion

        #region CajaActualDetalleList

        /// <summary>
        /// The <see cref="CajaActualDetalleList" /> property's name.
        /// </summary>
        public const string CajaActualDetalleListPropertyName = "CajaActualDetalleList";

        private ObservableCollection<MaquiladoCajaDetalle> _cajaActualDetalleList;

        /// <summary>
        /// Sets and gets the CajaActualDetalleList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MaquiladoCajaDetalle> CajaActualDetalleList
        {
            get
            {
                return _cajaActualDetalleList;
            }

            set
            {
                if (_cajaActualDetalleList == value)
                {
                    return;
                }

                _cajaActualDetalleList = value;
                RaisePropertyChanged(CajaActualDetalleListPropertyName);
            }
        }

        #endregion

        #region CajaList

        /// <summary>
        /// The <see cref="CajaList" /> property's name.
        /// </summary>
        public const string CajaListPropertyName = "CajaList";

        private ObservableCollection<MaquiladoCaja> _cajaList;

        /// <summary>
        /// Sets and gets the CajaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<MaquiladoCaja> CajaList
        {
            get
            {
                return _cajaList;
            }

            set
            {
                if (_cajaList == value)
                {
                    return;
                }

                _cajaList = value;
                RaisePropertyChanged(CajaListPropertyName);
            }
        }

        #endregion

        #region CajaActualSelected

        /// <summary>
        /// The <see cref="CajaActualSelected" /> property's name.
        /// </summary>
        public const string CajaActualSelectedPropertyName = "CajaActualSelected";

        private MaquiladoCaja _cajaActualSelected;

        /// <summary>
        /// Sets and gets the CajaActualSelected property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MaquiladoCaja CajaActualSelected
        {
            get
            {
                return _cajaActualSelected;
            }

            set
            {
                if (_cajaActualSelected == value)
                {
                    return;
                }

                _cajaActualSelected = value;
                RaisePropertyChanged(CajaActualSelectedPropertyName);
            }
        }

        #endregion

        #region TallaList

        /// <summary>
        /// The <see cref="TallaList" /> property's name.
        /// </summary>
        public const string TallaListPropertyName = "TallaList";

        private ObservableCollection<TallaModel> _tallaList;

        /// <summary>
        /// Sets and gets the TallaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TallaModel> TallaList
        {
            get
            {
                return _tallaList;
            }

            set
            {
                if (_tallaList == value)
                {
                    return;
                }

                _tallaList = value;
                RaisePropertyChanged(TallaListPropertyName);
            }
        }

        #endregion

        public List<OrdenProduccionTalla> OrdenProduccionTallaList { get; set; }

        public Action CloseAction { get; set; }

        public EventHandler OnRequestClose { get; set; }

        #endregion

        #region Commands

        public RelayCommand CajaNuevaCommand { get; set; }
        public RelayCommand CajaCerrarCommand { get; set; }
        public RelayCommand OrdenCerrarCommand { get; set; }
        public RelayCommand CajaReAbrirCommand { get; set; }

        #endregion

        #region Constructor

        public MaquiladoEmpaqueViewModel(IDataServiceLbDatPro dataService, IDialogService dialogService, OrdenProduccionExterno ordenProduccion)
        {
            _dataService = dataService;
            _dialogService = dialogService;

            if (IsInDesignMode)
            {
                _dataService.OrdenProduccionExternoGet(1, 1, 1,
                    (reg, error) =>
                    {
                        if (error != null)
                        {
                            _dialogService.ShowException(error);
                            return;
                        }
                        OrdenProduccion = reg;
                    });
            }
            else
            {
                OrdenProduccion = ordenProduccion;
            }

            CantidadTotal = OrdenProduccion.Cantidad;

            RegisterCommand();
            LoadOrdenProduccionData();
        }

        #endregion

        #region Methods

        private void RegisterCommand()
        {
            CajaNuevaCommand = new RelayCommand(CajaNueva, CanCajaNueva);
            CajaCerrarCommand = new RelayCommand(CajaCerrar, CanCajaCerrar);
            CajaReAbrirCommand = new RelayCommand(CajaReabrir, CanCajaReabrir);
            OrdenCerrarCommand = new RelayCommand(OrdenCerrar, CanOrdenCerrar);
        }

        private void LoadOrdenProduccionData()
        {
            _dataService.OrdenProduccionDetalleGetTallas(OrdenProduccion.CompaniaId, OrdenProduccion.Ano, OrdenProduccion.Numero,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    OrdenProduccionTallaList = new List<OrdenProduccionTalla>(lista);
                    LoadCajas();
                });
        }

        private void LoadCajas()
        {
            _dataService.MaquiladoEmpaqueGet(OrdenProduccion.CompaniaId, OrdenProduccion.Ano, OrdenProduccion.Numero,
                (lista, error) =>
                {
                    if (error != null)
                    {
                        _dialogService.ShowException(error);
                        return;
                    }
                    CajaList = new ObservableCollection<MaquiladoCaja>(lista);
                    CalculaResumen();
                });
        }

        private void CalculaResumen()
        {
            TallaList = new ObservableCollection<TallaModel>();
            foreach (var talla in OrdenProduccionTallaList.OrderBy(r=>r.Talla.Secuencia))
            {
                var empacado = TotalEmpacadoTalla(talla.TallaCodigo);
                TallaList.Add(new TallaModel
                {
                    Codigo = talla.TallaCodigo,
                    Nombre = talla.Talla.Nombre,
                    Total = talla.Cantidad,
                    Empacado = empacado,
                    Pendiente = talla.Cantidad - empacado
                });
            }
        }

        private int TotalEmpacadoTalla(string tallaCodigo)
        {
            return CajaList.Sum(caja => caja.Detalle.Where(r => r.TallaId == tallaCodigo).Sum(r => r.Cantidad));
        }

        private void CajaNueva()
        {
            
        }

        private bool CanCajaNueva()
        {
            return true;
        }

        private void CajaCerrar()
        {
            
        }

        private bool CanCajaCerrar()
        {
            return true;
        }

        private void CajaReabrir()
        {
            
        }

        private bool CanCajaReabrir()
        {
            return true;
        }

        private void OrdenCerrar()
        {
            
        }

        private bool CanOrdenCerrar()
        {
            return true;
        }

        #endregion
    }
}