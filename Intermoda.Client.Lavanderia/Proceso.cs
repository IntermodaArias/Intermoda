using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ProcesoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Proceso : ObservableObject
    {
        private static ProcesoClient _client;

        #region Properties

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

        #region Secuencia

        /// <summary>
        /// The <see cref="Secuencia" /> property's name.
        /// </summary>
        public const string SecuenciaPropertyName = "Secuencia";

        private int _secuencia;

        /// <summary>
        /// Sets and gets the Secuencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Secuencia
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

        #region EsActivo

        /// <summary>
        /// The <see cref="EsActivo" /> property's name.
        /// </summary>
        public const string EsActivoPropertyName = "EsActivo";

        private bool _esActivo;

        /// <summary>
        /// Sets and gets the EsActivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsActivo
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

        #region EsObligatorio

        /// <summary>
        /// The <see cref="EsObligatorio" /> property's name.
        /// </summary>
        public const string EsObligatorioPropertyName = "EsObligatorio";

        private bool _esObligatorio;

        /// <summary>
        /// Sets and gets the EsObligatorio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsObligatorio
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

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private int _centroTrabajoId;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoId
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

        #region TiempoEstandar

        /// <summary>
        /// The <see cref="TiempoEstandar" /> property's name.
        /// </summary>
        public const string TiempoEstandarPropertyName = "TiempoEstandar";

        private decimal? _tiempoEstandar;

        /// <summary>
        /// Sets and gets the TiempoEstandar property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoEstandar
        {
            get
            {
                return _tiempoEstandar;
            }

            set
            {
                if (_tiempoEstandar == value)
                {
                    return;
                }

                _tiempoEstandar = value;
                RaisePropertyChanged(TiempoEstandarPropertyName);
            }
        }

        #endregion



        #region CentroTrabajo

        /// <summary>
        /// The <see cref="CentroTrabajo" /> property's name.
        /// </summary>
        public const string CentroTrabajoPropertyName = "CentroTrabajo";

        private CentroTrabajo _centroTrabajo;

        /// <summary>
        /// Sets and gets the CentroTrabajo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajo CentroTrabajo
        {
            get
            {
                return _centroTrabajo;
            }

            set
            {
                if (_centroTrabajo == value)
                {
                    return;
                }

                _centroTrabajo = value;
                RaisePropertyChanged(CentroTrabajoPropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<Proceso> Update(Proceso proceso)
        {
            try
            {
                using (_client = new ProcesoClient())
                {
                    var reg = await _client.UpdateAsync(new ProcesoBusiness
                    {
                        Id = proceso.Id,
                        Nombre = proceso.Nombre,
                        Descripcion = proceso.Descripcion,
                        Secuencia = proceso.Secuencia,
                        EsActivo = proceso.EsActivo,
                        EsObligatorio = proceso.EsObligatorio,
                        CentroTrabajoId = proceso.CentroTrabajoId,
                        TiempoEstandar = proceso.TiempoEstandar
                    });

                    return new Proceso
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        Secuencia = reg.Secuencia,
                        EsActivo = reg.EsActivo,
                        EsObligatorio = reg.EsObligatorio,
                        CentroTrabajoId = reg.CentroTrabajoId,
                        TiempoEstandar = reg.TiempoEstandar,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = reg.CentroTrabajo.Codigo,
                            Nombre = reg.CentroTrabajo.Nombre,
                            Observacion = reg.CentroTrabajo.Observacion,
                            EsActivo = reg.CentroTrabajo.EsActivo,
                            EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                            Orden = reg.CentroTrabajo.Orden,
                            TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                            TiempoProceso = reg.CentroTrabajo.TiempoProceso
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / Update", exception);
            }
        }

        public static async Task Delete(int procesoId)
        {
            try
            {
                using (_client = new ProcesoClient())
                {
                    await _client.DeleteAsync(procesoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / Delete", exception);
            }
        }

        public static async Task<Proceso> Get(int procesoId)
        {
            try
            {
                using (_client = new ProcesoClient())
                {
                    var reg = await _client.GetAsync(procesoId);
                    return new Proceso
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        Secuencia = reg.Secuencia,
                        EsActivo = reg.EsActivo,
                        EsObligatorio = reg.EsObligatorio,
                        CentroTrabajoId = reg.CentroTrabajoId,
                        TiempoEstandar = reg.TiempoEstandar,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = reg.CentroTrabajo.Codigo,
                            Nombre = reg.CentroTrabajo.Nombre,
                            Observacion = reg.CentroTrabajo.Observacion,
                            EsActivo = reg.CentroTrabajo.EsActivo,
                            EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                            Orden = reg.CentroTrabajo.Orden,
                            TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                            TiempoProceso = reg.CentroTrabajo.TiempoProceso
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / Get", exception);
            }
        }

        public static async Task<List<Proceso>> GetAll()
        {
            try
            {
                using (_client = new ProcesoClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(reg => new Proceso
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        Secuencia = reg.Secuencia,
                        EsActivo = reg.EsActivo,
                        EsObligatorio = reg.EsObligatorio,
                        CentroTrabajoId = reg.CentroTrabajoId,
                        TiempoEstandar = reg.TiempoEstandar,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = reg.CentroTrabajo.Codigo,
                            Nombre = reg.CentroTrabajo.Nombre,
                            Observacion = reg.CentroTrabajo.Observacion,
                            EsActivo = reg.CentroTrabajo.EsActivo,
                            EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                            Orden = reg.CentroTrabajo.Orden,
                            TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                            TiempoProceso = reg.CentroTrabajo.TiempoProceso
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / GetAll", exception);
            }
        }

        public static async Task<List<Proceso>> GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_client = new ProcesoClient())
                {
                    var lista = await _client.GetByCentroTrabajoAsync(centroTrabajoId);

                    return lista.Select(reg => new Proceso
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        Secuencia = reg.Secuencia,
                        EsActivo = reg.EsActivo,
                        EsObligatorio = reg.EsObligatorio,
                        CentroTrabajoId = reg.CentroTrabajoId,
                        TiempoEstandar = reg.TiempoEstandar,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = reg.CentroTrabajo.Codigo,
                            Nombre = reg.CentroTrabajo.Nombre,
                            Observacion = reg.CentroTrabajo.Observacion,
                            EsActivo = reg.CentroTrabajo.EsActivo,
                            EsObligatorio = reg.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = reg.CentroTrabajo.LineaProduccionCodigo,
                            Orden = reg.CentroTrabajo.Orden,
                            TiempoEspera = reg.CentroTrabajo.TiempoEspera,
                            TiempoProceso = reg.CentroTrabajo.TiempoProceso
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Proceso / GetByCentroTrabajo", exception);
            }
        }

        #endregion
    }
}