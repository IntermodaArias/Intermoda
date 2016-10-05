using GalaSoft.MvvmLight;

namespace Intermoda.Client.LbDatPro
{
    public class MaquiladoCajaDetalle : ObservableObject
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

        #region MaquiladoCajaId

        /// <summary>
        /// The <see cref="MaquiladoCajaId" /> property's name.
        /// </summary>
        public const string MaquiladoCajaIdPropertyName = "MaquiladoCajaId";

        private int _maquiladoCajaId;

        /// <summary>
        /// Sets and gets the MaquiladoCajaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MaquiladoCajaId
        {
            get
            {
                return _maquiladoCajaId;
            }

            set
            {
                if (_maquiladoCajaId == value)
                {
                    return;
                }

                _maquiladoCajaId = value;
                RaisePropertyChanged(MaquiladoCajaIdPropertyName);
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

        #region TallaId

        /// <summary>
        /// The <see cref="TallaId" /> property's name.
        /// </summary>
        public const string TallaIdPropertyName = "TallaId";

        private string _tallaId;

        /// <summary>
        /// Sets and gets the TallaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TallaId
        {
            get
            {
                return _tallaId;
            }

            set
            {
                if (_tallaId == value)
                {
                    return;
                }

                _tallaId = value;
                RaisePropertyChanged(TallaIdPropertyName);
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
            get
            {
                return _cantidad;
            }

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

        #endregion

        public Talla Talla { get; set; }
    }
}