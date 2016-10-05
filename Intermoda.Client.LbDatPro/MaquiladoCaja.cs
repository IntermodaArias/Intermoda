using GalaSoft.MvvmLight;

namespace Intermoda.Client.LbDatPro
{
    public class MaquiladoCaja : ObservableObject
    {
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
            get
            {
                return _companiaId;
            }

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
            get
            {
                return _ordenAno;
            }

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
            get
            {
                return _ordenNumero;
            }

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

        #region Numero

        /// <summary>
        /// The <see cref="Numero" /> property's name.
        /// </summary>
        public const string NumeroPropertyName = "Numero";

        private int _numero;

        /// <summary>
        /// Sets and gets the Numero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (_numero == value)
                {
                    return;
                }

                _numero = value;
                RaisePropertyChanged(NumeroPropertyName);
            }
        }

        #endregion
    }
}