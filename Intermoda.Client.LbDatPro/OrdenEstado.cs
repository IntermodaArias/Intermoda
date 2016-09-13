using GalaSoft.MvvmLight;

namespace Intermoda.Client.LbDatPro
{
    public class OrdenEstado : ObservableObject
    {
        //private static OrdenEstadoClient _client;

        #region Properties

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

        #region Secuencia

        /// <summary>
        /// The <see cref="Secuencia" /> property's name.
        /// </summary>
        public const string SecuenciaPropertyName = "Secuencia";

        private short? _secuencia;

        /// <summary>
        /// Sets and gets the Secuencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? Secuencia
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

        #region Descripcion

        /// <summary>
        /// The <see cref="Descripcion" /> property's name.
        /// </summary>
        public const string DescripcionPropertyName = "Descripcion";

        private string _descripcion;

        /// <summary>
        /// Sets and gets the Descripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(DescripcionPropertyName);
            }
        }

        #endregion

        #region Area

        /// <summary>
        /// The <see cref="Area" /> property's name.
        /// </summary>
        public const string AreaPropertyName = "Area";

        private string _area;

        /// <summary>
        /// Sets and gets the Area property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Area
        {
            get
            {
                return _area;
            }

            set
            {
                if (_area == value)
                {
                    return;
                }

                _area = value;
                RaisePropertyChanged(AreaPropertyName);
            }
        }

        #endregion

        #region CentroCostoAlias

        /// <summary>
        /// The <see cref="CentroCostoAlias" /> property's name.
        /// </summary>
        public const string CentroCostoAliasPropertyName = "CentroCostoAlias";

        private string _centroCostoAlias;

        /// <summary>
        /// Sets and gets the CentroCostoAlias property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroCostoAlias
        {
            get
            {
                return _centroCostoAlias;
            }

            set
            {
                if (_centroCostoAlias == value)
                {
                    return;
                }

                _centroCostoAlias = value;
                RaisePropertyChanged(CentroCostoAliasPropertyName);
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

        #endregion
    }
}