using GalaSoft.MvvmLight;

namespace Intermoda.Client.LbDatPro
{
    public class PasoRuta : ObservableObject
    {
        //private static PasoRutaClient _client;

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

        #region Ano

        /// <summary>
        /// The <see cref="Ano" /> property's name.
        /// </summary>
        public const string AnoPropertyName = "Ano";

        private short _ano;

        /// <summary>
        /// Sets and gets the Ano property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Ano
        {
            get
            {
                return _ano;
            }

            set
            {
                if (_ano == value)
                {
                    return;
                }

                _ano = value;
                RaisePropertyChanged(AnoPropertyName);
            }
        }

        #endregion

        #region Numero

        /// <summary>
        /// The <see cref="Numero" /> property's name.
        /// </summary>
        public const string NumeroPropertyName = "Numero";

        private short _numero;

        /// <summary>
        /// Sets and gets the Numero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Numero
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

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private string _centroTrabajoId;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoId
        {
            get
            {
                return _centroTrabajoId;
            }

            set
            {
                if (_centroTrabajoId == value)
                {
                    return;
                }

                _centroTrabajoId = value;
                RaisePropertyChanged(CentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region PlantaId

        /// <summary>
        /// The <see cref="PlantaId" /> property's name.
        /// </summary>
        public const string PlantaIdPropertyName = "PlantaId";

        private string _plantaId;

        /// <summary>
        /// Sets and gets the PlantaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PlantaId
        {
            get
            {
                return _plantaId;
            }

            set
            {
                if (_plantaId == value)
                {
                    return;
                }

                _plantaId = value;
                RaisePropertyChanged(PlantaIdPropertyName);
            }
        }

        #endregion

        #region Secuencia

        /// <summary>
        /// The <see cref="Secuencia" /> property's name.
        /// </summary>
        public const string SecuenciaPropertyName = "Secuencia";

        private short _secuencia;

        /// <summary>
        /// Sets and gets the Secuencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Secuencia
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

        #endregion
    }
}