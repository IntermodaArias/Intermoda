using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Intermoda.Client.DataService.LbDatPro;
using Intermoda.Client.LbDatPro;
using Intermoda.Maquilado.Helpers;

namespace Intermoda.Maquilado.ViewModel
{
    public class MaquiladoEmpaqueViewModel : ViewModelBase
    {
        private IDataServiceLbDatPro _dataService;
        private IDialogService _dialogService;

        #region Properties

        #region OrdenProduccion

        /// <summary>
        /// The <see cref="OrdenProduccion" /> property's name.
        /// </summary>
        public const string OrdenProduccionPropertyName = "OrdenProduccion";

        private OrdenProduccionExterno _ordenProduccion;

        /// <summary>
        /// Sets and gets the OrdenProduccion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OrdenProduccionExterno OrdenProduccion
        {
            get
            {
                return _ordenProduccion;
            }

            set
            {
                if (_ordenProduccion == value)
                {
                    return;
                }

                _ordenProduccion = value;
                RaisePropertyChanged(OrdenProduccionPropertyName);
            }
        }

        #endregion

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

        #region CajaActualNumero

        /// <summary>
        /// The <see cref="CajaActualNumero" /> property's name.
        /// </summary>
        public const string CajaActualNumeroPropertyName = "CajaActualNumero";

        private int _cajaActualNumero;

        /// <summary>
        /// Sets and gets the CajaActualNumero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CajaActualNumero
        {
            get
            {
                return _cajaActualNumero;
            }

            set
            {
                if (_cajaActualNumero == value)
                {
                    return;
                }

                _cajaActualNumero = value;
                RaisePropertyChanged(CajaActualNumeroPropertyName);
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

        private MaquiladoCaja _cajaList;

        /// <summary>
        /// Sets and gets the CajaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MaquiladoCaja CajaList
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

        #region TallaList

        /// <summary>
        /// The <see cref="TallaList" /> property's name.
        /// </summary>
        public const string TallaListPropertyName = "TallaList";

        private OrdenProduccionTalla _tallaList;

        /// <summary>
        /// Sets and gets the TallaList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public OrdenProduccionTalla TallaList
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

        #endregion

        #region Commands

        public RelayCommand Type { get; set; }
        #endregion
    }
}