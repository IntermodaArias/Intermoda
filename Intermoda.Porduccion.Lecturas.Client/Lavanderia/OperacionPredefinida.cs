using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client.Lavanderia
{
    public class OperacionPredefinida : ViewModelBase
    {
        private static DataServiceClient _client;

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
                RaisePropertyChanged(OperacionIdPropertyName);
            }
        }

        #endregion

        #region Temperatura

        /// <summary>
        /// The <see cref="Temperatura" /> property's name.
        /// </summary>
        public const string TemperaturaPropertyName = "Temperatura";

        private int _temperatura;

        /// <summary>
        /// Sets and gets the Temperatura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Temperatura
        {
            get
            {
                return _temperatura;
            }

            set
            {
                if (_temperatura == value)
                {
                    return;
                }

                _temperatura = value;
                RaisePropertyChanged(TemperaturaPropertyName);
            }
        }

        #endregion

        #region Ph

        /// <summary>
        /// The <see cref="Ph" /> property's name.
        /// </summary>
        public const string PhPropertyName = "Ph";

        private string _ph;

        /// <summary>
        /// Sets and gets the Ph property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Ph
        {
            get
            {
                return _ph;
            }

            set
            {
                if (_ph == value)
                {
                    return;
                }

                _ph = value;
                RaisePropertyChanged(PhPropertyName);
            }
        }

        #endregion

        #region TiempoMinimo

        /// <summary>
        /// The <see cref="TiempoMinimo" /> property's name.
        /// </summary>
        public const string TiempoMinimoPropertyName = "TiempoMinimo";

        private decimal _tiempoMinimo;

        /// <summary>
        /// Sets and gets the TiempoMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMinimo
        {
            get
            {
                return _tiempoMinimo;
            }

            set
            {
                if (_tiempoMinimo == value)
                {
                    return;
                }

                _tiempoMinimo = value;
                RaisePropertyChanged(TiempoMinimoPropertyName);
            }
        }

        #endregion

        #region TiempoMaximo

        /// <summary>
        /// The <see cref="TiempoMaximo" /> property's name.
        /// </summary>
        public const string TiempoMaximoPropertyName = "TiempoMaximo";

        private decimal _tiempoMaximo;

        /// <summary>
        /// Sets and gets the TiempoMaximo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMaximo
        {
            get
            {
                return _tiempoMaximo;
            }

            set
            {
                if (_tiempoMaximo == value)
                {
                    return;
                }

                _tiempoMaximo = value;
                RaisePropertyChanged(TiempoMaximoPropertyName);
            }
        }

        #endregion

        #region RelacionBano

        /// <summary>
        /// The <see cref="RelacionBano" /> property's name.
        /// </summary>
        public const string RelacionBanoPropertyName = "RelacionBano";

        private int _relacionBano;

        /// <summary>
        /// Sets and gets the RelacionBano property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int RelacionBano
        {
            get
            {
                return _relacionBano;
            }

            set
            {
                if (_relacionBano == value)
                {
                    return;
                }

                _relacionBano = value;
                RaisePropertyChanged(RelacionBanoPropertyName);
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
                RaisePropertyChanged(SecuenciaPropertyName);
            }
        }

        #endregion

        public Operacion Operacion { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}