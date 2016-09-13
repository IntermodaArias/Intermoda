using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client.Lavanderia
{
    public class CentroTrabajo : ObservableObject
    {
        private static DataServiceClient _client;

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

        #endregion

        #region Methods

        public static async Task<CentroTrabajo> Update(CentroTrabajo reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {

                    var model = await _client.LavanderiaCentroTrabajoUpdateAsync(new CentroTrabajoBusiness
                    {
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        Orden = reg.Orden,
                        Observacion = reg.Observacion,
                        TiempoProceso = reg.TiempoProceso,
                        TiempoEspera = reg.TiempoEspera,
                        LineaProduccionCodigo = reg.LineaProduccionCodigo,
                        EsObligatorio = reg.EsObligatorio,
                        EsActivo = reg.EsActivo
                    });

                    return new CentroTrabajo
                    {
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Orden = model.Orden,
                        Observacion = model.Observacion,
                        TiempoProceso = model.TiempoProceso,
                        TiempoEspera = model.TiempoEspera,
                        LineaProduccionCodigo = model.LineaProduccionCodigo,
                        EsObligatorio = model.EsObligatorio,
                        EsActivo = model.EsActivo
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Update", exception);
            }
        }

        public static async Task Delete(int centroTrabajoCodigo)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.LavanderiaCentroTrabajoDeleteAsync(centroTrabajoCodigo);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Delete", exception);
            }
        }

        public static async Task<CentroTrabajo> Get(int centroTrabajoCodigo)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var reg = await _client.LavanderiaCentroTrabajoGetAsync(centroTrabajoCodigo);

                    return new CentroTrabajo
                    {
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        Orden = reg.Orden,
                        Observacion = reg.Observacion,
                        TiempoEspera = reg.TiempoEspera,
                        TiempoProceso = reg.TiempoProceso,
                        LineaProduccionCodigo = reg.LineaProduccionCodigo,
                        EsObligatorio = reg.EsObligatorio,
                        EsActivo = reg.EsActivo
                    };
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
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.LavanderiaCentroTrabajoGetAllAsync();

                    return lista.Select(r => new CentroTrabajo
                    {
                        Codigo = r.Codigo,
                        Nombre = r.Nombre,
                        Orden = r.Orden,
                        Observacion = r.Observacion,
                        TiempoEspera = r.TiempoEspera,
                        TiempoProceso = r.TiempoProceso,
                        LineaProduccionCodigo = r.LineaProduccionCodigo,
                        EsObligatorio = r.EsObligatorio,
                        EsActivo = r.EsActivo
                    }).ToList();
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
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.LavanderiaCentroTrabajoGetActivosAsync();

                    return lista.Select(r => new CentroTrabajo
                    {
                        Codigo = r.Codigo,
                        Nombre = r.Nombre,
                        Orden = r.Orden,
                        Observacion = r.Observacion,
                        TiempoEspera = r.TiempoEspera,
                        TiempoProceso = r.TiempoProceso,
                        LineaProduccionCodigo = r.LineaProduccionCodigo,
                        EsObligatorio = r.EsObligatorio,
                        EsActivo = r.EsActivo
                    }).ToList();
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
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.LavanderiaCentroTrabajoGetByOperacionAsync(operacionId);

                    return lista.Select(r => new CentroTrabajo
                    {
                        Codigo = r.Codigo,
                        Nombre = r.Nombre,
                        Orden = r.Orden,
                        Observacion = r.Observacion,
                        TiempoEspera = r.TiempoEspera,
                        TiempoProceso = r.TiempoProceso,
                        LineaProduccionCodigo = r.LineaProduccionCodigo,
                        EsObligatorio = r.EsObligatorio,
                        EsActivo = r.EsActivo
                    }).ToList();
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
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.LavanderiaCentroTrabajoGetAllLavanderiaAsync();

                    return lista.Select(r => new CentroTrabajo
                    {
                        Codigo = r.Codigo,
                        Nombre = r.Nombre,
                        Orden = r.Orden,
                        Observacion = r.Observacion,
                        TiempoEspera = r.TiempoEspera,
                        TiempoProceso = r.TiempoProceso,
                        LineaProduccionCodigo = r.LineaProduccionCodigo,
                        EsObligatorio = r.EsObligatorio,
                        EsActivo = r.EsActivo
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / GetAllLavanderia", exception);
            }
        }

        #endregion
    }
}