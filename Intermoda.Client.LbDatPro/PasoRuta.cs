using System;
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

        #region Planta

        /// <summary>
        /// The <see cref="Planta" /> property's name.
        /// </summary>
        public const string PlantaPropertyName = "Planta";

        private string _planta;

        /// <summary>
        /// Sets and gets the Planta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Planta
        {
            get
            {
                return _planta;
            }

            set
            {
                if (_planta == value)
                {
                    return;
                }

                _planta = value;
                RaisePropertyChanged(PlantaPropertyName);
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

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private string _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Estado
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
                RaisePropertyChanged(EstadoPropertyName);
            }
        }

        #endregion

        #region LecturaEntrada

        /// <summary>
        /// The <see cref="LecturaEntrada" /> property's name.
        /// </summary>
        public const string LecturaEntradaPropertyName = "LecturaEntrada";

        private DateTime? _lecturaEntrada;

        /// <summary>
        /// Sets and gets the LecturaEntrada property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? LecturaEntrada
        {
            get
            {
                return _lecturaEntrada;
            }

            set
            {
                if (_lecturaEntrada == value)
                {
                    return;
                }

                _lecturaEntrada = value;
                RaisePropertyChanged(LecturaEntradaPropertyName);
            }
        }

        #endregion

        #region LecturaSalida

        /// <summary>
        /// The <see cref="LecturaSalida" /> property's name.
        /// </summary>
        public const string LecturaSalidaPropertyName = "LecturaSalida";

        private DateTime? _lecturaSalida;

        /// <summary>
        /// Sets and gets the LecturaSalida property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? LecturaSalida
        {
            get
            {
                return _lecturaSalida;
            }

            set
            {
                if (_lecturaSalida == value)
                {
                    return;
                }

                _lecturaSalida = value;
                RaisePropertyChanged(LecturaSalidaPropertyName);
            }
        }

        #endregion

        #region TiempoEnProceso

        /// <summary>
        /// The <see cref="TiempoEnProceso" /> property's name.
        /// </summary>
        public const string TiempoEnProcesoPropertyName = "TiempoEnProceso";

        private TimeSpan? _tiempoEnProceso;

        /// <summary>
        /// Sets and gets the TiempoEnProceso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan? TiempoEnProceso
        {
            get
            {
                return _tiempoEnProceso;
            }

            set
            {
                if (_tiempoEnProceso == value)
                {
                    return;
                }

                _tiempoEnProceso = value;
                RaisePropertyChanged(TiempoEnProcesoPropertyName);
            }
        }

        #endregion

        #region TiempoEnPlanta

        /// <summary>
        /// The <see cref="TiempoEnPlanta" /> property's name.
        /// </summary>
        public const string TiempoEnPlantaPropertyName = "TiempoEnPlanta";

        private TimeSpan? _tiempoEnPlanta;

        /// <summary>
        /// Sets and gets the TiempoEnPlanta property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public TimeSpan? TiempoEnPlanta
        {
            get
            {
                return _tiempoEnPlanta;
            }

            set
            {
                if (_tiempoEnPlanta == value)
                {
                    return;
                }

                _tiempoEnPlanta = value;
                RaisePropertyChanged(TiempoEnPlantaPropertyName);
            }
        }

        #endregion

        #endregion
    }
}