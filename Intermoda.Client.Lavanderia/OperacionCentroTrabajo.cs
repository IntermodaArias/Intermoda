using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.OperacionCentroTrabajoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class OperacionCentroTrabajo : ObservableObject
    {
        private static OperacionCentroTrabajoClient _client;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private short _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Id
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

        #region OperacionCodigo

        /// <summary>
        /// The <see cref="OperacionCodigo" /> property's name.
        /// </summary>
        public const string OperacionCodigoPropertyName = "OperacionCodigo";

        private short _operacionCodigo;

        /// <summary>
        /// Sets and gets the OperacionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short OperacionCodigo
        {
            get
            {
                return _operacionCodigo;
            }

            set
            {
                if (_operacionCodigo == value)
                {
                    return;
                }

                _operacionCodigo = value;
                RaisePropertyChanged(OperacionCodigoPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoCodigo

        /// <summary>
        /// The <see cref="CentroTrabajoCodigo" /> property's name.
        /// </summary>
        public const string CentroTrabajoCodigoPropertyName = "CentroTrabajoCodigo";

        private int _centroTrabajoCodigo;

        /// <summary>
        /// Sets and gets the CentroTrabajoCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoCodigo
        {
            get
            {
                return _centroTrabajoCodigo;
            }

            set
            {
                if (_centroTrabajoCodigo == value)
                {
                    return;
                }

                _centroTrabajoCodigo = value;
                RaisePropertyChanged(CentroTrabajoCodigoPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoNombre

        /// <summary>
        /// The <see cref="CentroTrabajoNombre" /> property's name.
        /// </summary>
        public const string CentroTrabajoNombrePropertyName = "CentroTrabajoNombre";

        private string _centroTrabajoNombre;

        /// <summary>
        /// Sets and gets the CentroTrabajoNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoNombre
        {
            get
            {
                return _centroTrabajoNombre;
            }

            set
            {
                if (_centroTrabajoNombre == value)
                {
                    return;
                }

                _centroTrabajoNombre = value;
                RaisePropertyChanged(CentroTrabajoNombrePropertyName);
            }
        }

        #endregion

        #region EsRepetible

        /// <summary>
        /// The <see cref="EsRepetible" /> property's name.
        /// </summary>
        public const string EsRepetiblePropertyName = "EsRepetible";

        private int? _esRepetible;

        /// <summary>
        /// Sets and gets the EsRepetible property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? EsRepetible
        {
            get
            {
                return _esRepetible;
            }

            set
            {
                if (_esRepetible == value)
                {
                    return;
                }

                _esRepetible = value;
                RaisePropertyChanged(EsRepetiblePropertyName);
            }
        }

        #endregion

        #region EsRepetibleBool

        /// <summary>
        /// The <see cref="EsRepetibleBool" /> property's name.
        /// </summary>
        public const string EsRepetibleBoolPropertyName = "EsRepetibleBool";

        private bool _esRepetibleBool;

        /// <summary>
        /// Sets and gets the EsRepetibleBool property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsRepetibleBool
        {
            get
            {
                return _esRepetibleBool;
            }

            set
            {
                if (_esRepetibleBool == value)
                {
                    return;
                }

                _esRepetibleBool = value;
                RaisePropertyChanged(EsRepetibleBoolPropertyName);
            }
        }

        #endregion

        public CentroTrabajo CentroTrabajo { get; set; }

        public Operacion Operacion { get; set; }

        #endregion

        #region Methods

        public static async Task<OperacionCentroTrabajo> Update(OperacionCentroTrabajo operacionCentroTrabajo)
        {
            try
            {
                using (_client = new OperacionCentroTrabajoClient())
                {
                    var reg = new OperacionCentroTrabajoBusiness
                    {
                        Id = operacionCentroTrabajo.Id,
                        CentroTrabajoCodigo = operacionCentroTrabajo.CentroTrabajoCodigo,
                        OperacionCodigo = operacionCentroTrabajo.OperacionCodigo,
                        CentroTrabajoNombre = operacionCentroTrabajo.CentroTrabajoNombre,
                        EsRepetible = operacionCentroTrabajo.EsRepetibleBool ? 1 : 0
                    };

                    reg = await _client.UpdateAsync(reg);

                    return new OperacionCentroTrabajo
                    {
                        Id = reg.Id,
                        CentroTrabajoCodigo = reg.CentroTrabajoCodigo,
                        CentroTrabajoNombre = reg.CentroTrabajoNombre,
                        OperacionCodigo = reg.OperacionCodigo,
                        EsRepetible = reg.EsRepetible,
                        EsRepetibleBool = reg.EsRepetible == 1,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = reg.CentroTrabajo.Codigo,
                            Nombre = reg.CentroTrabajo.Nombre,
                            EsActivo = reg.CentroTrabajo.EsActivo,
                            EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                            Observacion = reg.CentroTrabajo.Observacion,
                            Orden = reg.CentroTrabajo.Orden,
                            TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                            TiempoProceso = reg.CentroTrabajo.TiempoProceso
                        },
                        Operacion = new Operacion
                        {
                            Id = reg.Operacion.Id,
                            Descripcion = reg.Operacion.Descripcion,
                            GrupoId = reg.Operacion.GrupoId,
                            LineaProduccionId = reg.Operacion.LineaProduccionId,
                            Nombre = reg.Operacion.Nombre,
                            OperacionTipoId = reg.Operacion.OperacionTipoId,
                            OperacionPredefinida = new OperacionPredefinida
                            {
                                Id = reg.Operacion.OperacionPredefinida.Id,
                                OperacionId = reg.Operacion.OperacionPredefinida.OperacionId,
                                Ph = reg.Operacion.OperacionPredefinida.Ph,
                                RelacionBano = reg.Operacion.OperacionPredefinida.RelacionBano,
                                Secuencia = reg.Operacion.OperacionPredefinida.Secuencia,
                                Temperatura = reg.Operacion.OperacionPredefinida.Temperatura,
                                TiempoMinimo = reg.Operacion.OperacionPredefinida.TiempoMinimo,
                                TiempoMaximo = reg.Operacion.OperacionPredefinida.TiempoMaximo
                            }
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        public static async Task Delete(int operacionCentroTrabajoId)
        {
            try
            {
                using (_client = new OperacionCentroTrabajoClient())
                {
                    await _client.DeleteAsync(operacionCentroTrabajoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        public static async Task<OperacionCentroTrabajo> Get(int operacionCentroTrabajoId)
        {
            try
            {
                using (_client = new OperacionCentroTrabajoClient())
                {
                    var reg = await _client.GetAsync(operacionCentroTrabajoId);

                    return new OperacionCentroTrabajo
                    {
                        Id = reg.Id,
                        CentroTrabajoCodigo = reg.CentroTrabajoCodigo,
                        CentroTrabajoNombre = reg.CentroTrabajoNombre,
                        OperacionCodigo = reg.OperacionCodigo,
                        EsRepetible = reg.EsRepetible,
                        EsRepetibleBool = reg.EsRepetible == 1,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = reg.CentroTrabajo.Codigo,
                            Nombre = reg.CentroTrabajo.Nombre,
                            EsActivo = reg.CentroTrabajo.EsActivo,
                            EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                            Observacion = reg.CentroTrabajo.Observacion,
                            Orden = reg.CentroTrabajo.Orden,
                            TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                            TiempoProceso = reg.CentroTrabajo.TiempoProceso
                        },
                        Operacion = new Operacion
                        {
                            Id = reg.Operacion.Id,
                            Descripcion = reg.Operacion.Descripcion,
                            GrupoId = reg.Operacion.GrupoId,
                            LineaProduccionId = reg.Operacion.LineaProduccionId,
                            Nombre = reg.Operacion.Nombre,
                            OperacionTipoId = reg.Operacion.OperacionTipoId,
                            OperacionPredefinida = new OperacionPredefinida
                            {
                                Id = reg.Operacion.OperacionPredefinida.Id,
                                OperacionId = reg.Operacion.OperacionPredefinida.OperacionId,
                                Ph = reg.Operacion.OperacionPredefinida.Ph,
                                RelacionBano = reg.Operacion.OperacionPredefinida.RelacionBano,
                                Secuencia = reg.Operacion.OperacionPredefinida.Secuencia,
                                Temperatura = reg.Operacion.OperacionPredefinida.Temperatura,
                                TiempoMinimo = reg.Operacion.OperacionPredefinida.TiempoMinimo,
                                TiempoMaximo = reg.Operacion.OperacionPredefinida.TiempoMaximo
                            }
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        public static async Task<List<OperacionCentroTrabajo>> GetAll()
        {
            try
            {
                using (_client = new OperacionCentroTrabajoClient())
                {
                    var retorno = new List<OperacionCentroTrabajo>();
                    var lista = await _client.GetAllAsync();

                    foreach (var reg in lista)
                    {
                        retorno.Add(new OperacionCentroTrabajo
                        {
                            Id = reg.Id,
                            CentroTrabajoCodigo = reg.CentroTrabajoCodigo,
                            CentroTrabajoNombre = reg.CentroTrabajoNombre,
                            OperacionCodigo = reg.OperacionCodigo,
                            EsRepetible = reg.EsRepetible,
                            EsRepetibleBool = reg.EsRepetible == 1,
                            CentroTrabajo = new CentroTrabajo
                            {
                                Codigo = reg.CentroTrabajo.Codigo,
                                Nombre = reg.CentroTrabajo.Nombre,
                                EsActivo = reg.CentroTrabajo.EsActivo,
                                EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                                LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                                Observacion = reg.CentroTrabajo.Observacion,
                                Orden = reg.CentroTrabajo.Orden,
                                TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                                TiempoProceso = reg.CentroTrabajo.TiempoProceso
                            },
                            Operacion = new Operacion
                            {
                                Id = reg.Operacion.Id,
                                Descripcion = reg.Operacion.Descripcion,
                                GrupoId = reg.Operacion.GrupoId,
                                LineaProduccionId = reg.Operacion.LineaProduccionId,
                                Nombre = reg.Operacion.Nombre,
                                OperacionTipoId = reg.Operacion.OperacionTipoId,
                                OperacionPredefinida = new OperacionPredefinida
                                {
                                    Id = reg.Operacion.OperacionPredefinida.Id,
                                    OperacionId = reg.Operacion.OperacionPredefinida.OperacionId,
                                    Ph = reg.Operacion.OperacionPredefinida.Ph,
                                    RelacionBano = reg.Operacion.OperacionPredefinida.RelacionBano,
                                    Secuencia = reg.Operacion.OperacionPredefinida.Secuencia,
                                    Temperatura = reg.Operacion.OperacionPredefinida.Temperatura,
                                    TiempoMinimo = reg.Operacion.OperacionPredefinida.TiempoMinimo,
                                    TiempoMaximo = reg.Operacion.OperacionPredefinida.TiempoMaximo
                                }
                            }
                        });
                    }
                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        public static async Task<List<OperacionCentroTrabajo>> GetByCentroTrabajo(int centroTrabajoCodigo)
        {
            try
            {
                using (_client = new OperacionCentroTrabajoClient())
                {
                    var retorno = new List<OperacionCentroTrabajo>();
                    var lista =
                        await _client.GetByCentroTrabajoAsync(centroTrabajoCodigo);

                    foreach (var reg in lista)
                    {
                        retorno.Add(new OperacionCentroTrabajo
                        {
                            Id = reg.Id,
                            CentroTrabajoCodigo = reg.CentroTrabajoCodigo,
                            CentroTrabajoNombre = reg.CentroTrabajoNombre,
                            OperacionCodigo = reg.OperacionCodigo,
                            EsRepetible = reg.EsRepetible,
                            EsRepetibleBool = reg.EsRepetible == 1,
                            CentroTrabajo = new CentroTrabajo
                            {
                                Codigo = reg.CentroTrabajo.Codigo,
                                Nombre = reg.CentroTrabajo.Nombre,
                                EsActivo = reg.CentroTrabajo.EsActivo,
                                EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                                LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                                Observacion = reg.CentroTrabajo.Observacion,
                                Orden = reg.CentroTrabajo.Orden,
                                TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                                TiempoProceso = reg.CentroTrabajo.TiempoProceso
                            },
                            Operacion = new Operacion
                            {
                                Id = reg.Operacion.Id,
                                Descripcion = reg.Operacion.Descripcion,
                                GrupoId = reg.Operacion.GrupoId,
                                LineaProduccionId = reg.Operacion.LineaProduccionId,
                                Nombre = reg.Operacion.Nombre,
                                OperacionTipoId = reg.Operacion.OperacionTipoId,
                                OperacionPredefinida = new OperacionPredefinida
                                {
                                    Id = reg.Operacion.OperacionPredefinida.Id,
                                    OperacionId = reg.Operacion.OperacionPredefinida.OperacionId,
                                    Ph = reg.Operacion.OperacionPredefinida.Ph,
                                    RelacionBano = reg.Operacion.OperacionPredefinida.RelacionBano,
                                    Secuencia = reg.Operacion.OperacionPredefinida.Secuencia,
                                    Temperatura = reg.Operacion.OperacionPredefinida.Temperatura,
                                    TiempoMinimo = reg.Operacion.OperacionPredefinida.TiempoMinimo,
                                    TiempoMaximo = reg.Operacion.OperacionPredefinida.TiempoMaximo
                                }
                            }
                        });
                    }
                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        public static async Task<List<OperacionCentroTrabajo>> GetByOperacion(short operacionCodigo)
        {
            try
            {
                using (_client = new OperacionCentroTrabajoClient())
                {
                    var retorno = new List<OperacionCentroTrabajo>();
                    var lista = await _client.GetByOperacionAsync(operacionCodigo);

                    foreach (var reg in lista)
                    {
                        retorno.Add(new OperacionCentroTrabajo
                        {
                            Id = reg.Id,
                            CentroTrabajoCodigo = reg.CentroTrabajoCodigo,
                            CentroTrabajoNombre = reg.CentroTrabajoNombre,
                            OperacionCodigo = reg.OperacionCodigo,
                            EsRepetible = reg.EsRepetible,
                            EsRepetibleBool = reg.EsRepetible == 1,
                            CentroTrabajo = new CentroTrabajo
                            {
                                Codigo = reg.CentroTrabajo.Codigo,
                                Nombre = reg.CentroTrabajo.Nombre,
                                EsActivo = reg.CentroTrabajo.EsActivo,
                                EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                                LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                                Observacion = reg.CentroTrabajo.Observacion,
                                Orden = reg.CentroTrabajo.Orden,
                                TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                                TiempoProceso = reg.CentroTrabajo.TiempoProceso
                            },
                            Operacion = new Operacion
                            {
                                Id = reg.Operacion.Id,
                                Descripcion = reg.Operacion.Descripcion,
                                GrupoId = reg.Operacion.GrupoId,
                                LineaProduccionId = reg.Operacion.LineaProduccionId,
                                Nombre = reg.Operacion.Nombre,
                                OperacionTipoId = reg.Operacion.OperacionTipoId,
                                OperacionPredefinida = new OperacionPredefinida
                                {
                                    Id = reg.Operacion.OperacionPredefinida.Id,
                                    OperacionId = reg.Operacion.OperacionPredefinida.OperacionId,
                                    Ph = reg.Operacion.OperacionPredefinida.Ph,
                                    RelacionBano = reg.Operacion.OperacionPredefinida.RelacionBano,
                                    Secuencia = reg.Operacion.OperacionPredefinida.Secuencia,
                                    Temperatura = reg.Operacion.OperacionPredefinida.Temperatura,
                                    TiempoMinimo = reg.Operacion.OperacionPredefinida.TiempoMinimo,
                                    TiempoMaximo = reg.Operacion.OperacionPredefinida.TiempoMaximo
                                }
                            }
                        });
                    }
                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionCentroTrabajo / Update", exception);
            }
        }

        #endregion
    }
}