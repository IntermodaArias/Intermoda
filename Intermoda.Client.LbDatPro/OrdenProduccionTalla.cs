using GalaSoft.MvvmLight;

namespace Intermoda.Client.LbDatPro
{
    public class OrdenProduccionTalla : ObservableObject
    {
        #region CompaniaId

        /// <summary>
        /// The <see cref="CompaniaId" /> property's name.
        /// </summary>
        public const string CompaniaIdPropertyName = "CompaniaId";

        private short _companiaId;

        /// <summary>
        /// Sets and gets the CompaniaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short CompaniaId
        {
            get { return _companiaId; }

            set
            {
                if (_companiaId == value)
                {
                    return;
                }

                _companiaId = value;
                RaisePropertyChanged(CompaniaIdPropertyName);
            }
        }

        #endregion

        #region OrdenAno

        /// <summary>
        /// The <see cref="OrdenAno" /> property's name.
        /// </summary>
        public const string OrdenAnoPropertyName = "OrdenAno";

        private short _ordenAno;

        /// <summary>
        /// Sets and gets the OrdenAno property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short OrdenAno
        {
            get { return _ordenAno; }

            set
            {
                if (_ordenAno == value)
                {
                    return;
                }

                _ordenAno = value;
                RaisePropertyChanged(OrdenAnoPropertyName);
            }
        }

        #endregion

        #region OrdenNumero

        /// <summary>
        /// The <see cref="OrdenNumero" /> property's name.
        /// </summary>
        public const string OrdenNumeroPropertyName = "OrdenNumero";

        private short _ordenNumero;

        /// <summary>
        /// Sets and gets the OrdenNumero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short OrdenNumero
        {
            get { return _ordenNumero; }

            set
            {
                if (_ordenNumero == value)
                {
                    return;
                }

                _ordenNumero = value;
                RaisePropertyChanged(OrdenNumeroPropertyName);
            }
        }

        #endregion

        #region TallaCodigo

        /// <summary>
        /// The <see cref="TallaCodigo" /> property's name.
        /// </summary>
        public const string TallaCodigoPropertyName = "TallaCodigo";

        private string _tallaCodigo;

        /// <summary>
        /// Sets and gets the TallaCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TallaCodigo
        {
            get { return _tallaCodigo; }

            set
            {
                if (_tallaCodigo == value)
                {
                    return;
                }

                _tallaCodigo = value;
                RaisePropertyChanged(TallaCodigoPropertyName);
            }
        }

        #endregion

        #region Cantidad

        /// <summary>
        /// The <see cref="Cantidad" /> property's name.
        /// </summary>
        public const string CantidadPropertyName = "Cantidad";

        private int _cantidad;

        /// <summary>
        /// Sets and gets the Cantidad property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Cantidad
        {
            get { return _cantidad; }

            set
            {
                if (_cantidad == value)
                {
                    return;
                }

                _cantidad = value;
                RaisePropertyChanged(CantidadPropertyName);
            }
        }

        #endregion}

        public Talla Talla { get; set; }
    }
}