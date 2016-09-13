using GalaSoft.MvvmLight;

namespace Intermoda.Client.LbDatPro
{
    public class CentroTrabajo : ObservableObject
    {
        #region Properties

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

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private string _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Id
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
                RaisePropertyChanged(NombrePropertyName);
            }
        }

        #endregion

        #endregion
    }
}