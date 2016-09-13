using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.CTrabajoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class CentroTrabajo : ObservableObject
    {
        private static CTrabajoClient _client;

        #region Properties

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private int _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                if (_codigo == value)
                {
                    return;
                }

                _codigo = value;
                RaisePropertyChanged(CodigoPropertyName);
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

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int? _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                if (_orden == value)
                {
                    return;
                }

                _orden = value;
                RaisePropertyChanged(OrdenPropertyName);
            }
        }

        #endregion

        #region Observacion

        /// <summary>
        /// The <see cref="Observacion" /> property's name.
        /// </summary>
        public const string ObservacionPropertyName = "Observacion";

        private string _observacion;

        /// <summary>
        /// Sets and gets the Observacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Observacion
        {
            get
            {
                return _observacion;
            }

            set
            {
                if (_observacion == value)
                {
                    return;
                }

                _observacion = value;
                RaisePropertyChanged(ObservacionPropertyName);
            }
        }

        #endregion

        #region TiempoEspera

        /// <summary>
        /// The <see cref="TiempoEspera" /> property's name.
        /// </summary>
        public const string TiempoEsperaPropertyName = "TiempoEspera";

        private decimal? _tiempoEspera;

        /// <summary>
        /// Sets and gets the TiempoEspera property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoEspera
        {
            get
            {
                return _tiempoEspera;
            }

            set
            {
                if (_tiempoEspera == value)
                {
                    return;
                }

                _tiempoEspera = value;
                RaisePropertyChanged(TiempoEsperaPropertyName);
            }
        }

        #endregion

        #region TiempoProceso

        /// <summary>
        /// The <see cref="TiempoProceso" /> property's name.
        /// </summary>
        public const string TiempoProcesoPropertyName = "TiempoProceso";

        private decimal? _tiempoProceso;

        /// <summary>
        /// Sets and gets the TiempoProceso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoProceso
        {
            get
            {
                return _tiempoProceso;
            }

            set
            {
                if (_tiempoProceso == value)
                {
                    return;
                }

                _tiempoProceso = value;
                RaisePropertyChanged(TiempoProcesoPropertyName);
            }
        }

        #endregion

        #region LineaProduccionCodigo

        /// <summary>
        /// The <see cref="LineaProduccionCodigo" /> property's name.
        /// </summary>
        public const string LineaProduccionCodigoPropertyName = "LineaProduccionCodigo";

        private int? _lineaProduccionCodigo;

        /// <summary>
        /// Sets and gets the LineaProduccionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? LineaProduccionCodigo
        {
            get
            {
                return _lineaProduccionCodigo;
            }

            set
            {
                if (_lineaProduccionCodigo == value)
                {
                    return;
                }

                _lineaProduccionCodigo = value;
                RaisePropertyChanged(LineaProduccionCodigoPropertyName);
            }
        }

        #endregion

        #region EsObligatorio

        /// <summary>
        /// The <see cref="EsObligatorio" /> property's name.
        /// </summary>
        public const string EsObligatorioPropertyName = "EsObligatorio";

        private bool? _esObligatorio;

        /// <summary>
        /// Sets and gets the EsObligatorio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool? EsObligatorio
        {
            get
            {
                return _esObligatorio;
            }

            set
            {
                if (_esObligatorio == value)
                {
                    return;
                }

                _esObligatorio = value;
                RaisePropertyChanged(EsObligatorioPropertyName);
            }
        }

        #endregion

        #region EsActivo

        /// <summary>
        /// The <see cref="EsActivo" /> property's name.
        /// </summary>
        public const string EsActivoPropertyName = "EsActivo";

        private bool? _esActivo;

        /// <summary>
        /// Sets and gets the EsActivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool? EsActivo
        {
            get
            {
                return _esActivo;
            }

            set
            {
                if (_esActivo == value)
                {
                    return;
                }

                _esActivo = value;
                RaisePropertyChanged(EsActivoPropertyName);
            }
        }

        #endregion

        #region Tipo

        /// <summary>
        /// The <see cref="Tipo" /> property's name.
        /// </summary>
        public const string TipoPropertyName = "Tipo";

        private int? _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                if (_tipo == value)
                {
                    return;
                }

                _tipo = value;
                RaisePropertyChanged(TipoPropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<CentroTrabajo> Update(CentroTrabajo model)
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    var reg = ClientToBusiness(model);
                    reg = await _client.UpdateAsync(reg);

                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Update", exception);
            }
        }

        public static async Task Delete(int centroTrabajoId)
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    await _client.DeleteAsync(centroTrabajoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Delete", exception);
            }
        }

        public static async Task<CentroTrabajo> Get(int centroTrabajoId)
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    var reg = await _client.GetAsync(centroTrabajoId);

                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Get", exception);
            }
        }

        public static async Task<List<CentroTrabajo>> GetAll()
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetAll", exception);
            }
        }

        public static async Task<List<CentroTrabajo>> GetActivos()
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    var lista = await _client.GetActivosAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetActivos", exception);
            }
        }

        public static async Task<List<CentroTrabajo>> GetByOperacion(int operacionId)
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    var lista = await _client.GetByOperacionAsync(operacionId);

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetByOperacion", exception);
            }
        }

        public static async Task<List<CentroTrabajo>> GetAllLavanderia()
        {
            try
            {
                using (_client = new CTrabajoClient())
                {
                    var lista = await _client.GetAllLavanderiaAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetAllLavanderia", exception);
            }
        }

        private static CentroTrabajo BusinessToClient(CTrabajoBusiness input)
        {
            return new CentroTrabajo
            {
                Codigo = input.Codigo,
                Nombre = input.Nombre,
                Orden = input.Orden,
                Observacion = input.Observacion,
                TiempoEspera = input.TiempoEspera,
                TiempoProceso = input.TiempoProceso,
                LineaProduccionCodigo = input.LineaProduccionCodigo,
                EsObligatorio = input.EsObligatorio,
                EsActivo = input.EsActivo,
                Tipo = input.Tipo
            };
        }

        private static CTrabajoBusiness ClientToBusiness(CentroTrabajo input)
        {
            return new CTrabajoBusiness
            {
                Codigo = input.Codigo,
                Nombre = input.Nombre,
                Orden = input.Orden,
                Observacion = input.Observacion,
                TiempoEspera = input.TiempoEspera,
                TiempoProceso = input.TiempoProceso,
                LineaProduccionCodigo = input.LineaProduccionCodigo,
                EsObligatorio = input.EsObligatorio,
                EsActivo = input.EsActivo,
                Tipo = input.Tipo
            };
        }

        #endregion
    }
}