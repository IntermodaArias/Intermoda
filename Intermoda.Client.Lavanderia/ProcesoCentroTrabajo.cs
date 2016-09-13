using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ProcesoCentroTrabajoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class ProcesoCentroTrabajo : ObservableObject
    {
        private static ProcesoCentroTrabajoClient _client;

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

        #region ProcesoId

        /// <summary>
        /// The <see cref="ProcesoId" /> property's name.
        /// </summary>
        public const string ProcesoIdPropertyName = "ProcesoId";

        private int _procesoId;

        /// <summary>
        /// Sets and gets the ProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ProcesoId
        {
            get
            {
                return _procesoId;
            }

            set
            {
                if (_procesoId == value)
                {
                    return;
                }

                _procesoId = value;
                RaisePropertyChanged(ProcesoIdPropertyName);
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

        #region CentroTrabajoOpcionId

        /// <summary>
        /// The <see cref="CentroTrabajoOpcionId" /> property's name.
        /// </summary>
        public const string CentroTrabajoOpcionIdPropertyName = "CentroTrabajoOpcionId";

        private int _centroTrabajoOpcionId;

        /// <summary>
        /// Sets and gets the CentroTrabajoOpcionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoOpcionId
        {
            get
            {
                return _centroTrabajoOpcionId;
            }

            set
            {
                if (_centroTrabajoOpcionId == value)
                {
                    return;
                }

                _centroTrabajoOpcionId = value;
                RaisePropertyChanged(CentroTrabajoOpcionIdPropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Orden
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

        public Proceso Proceso { get; set; }

        public CentroTrabajo CentroTrabajo { get; set; }

        public CentroTrabajoOpcion CentroTrabajoOpcion { get; set; }

        #endregion

        #region Methods

        public static async Task<ProcesoCentroTrabajo> Update(ProcesoCentroTrabajo procesoCentroTrabajo)
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    var reg = ClientToBusiness(procesoCentroTrabajo);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / Update", exception);
            }
        }

        public static async Task Delete(int procesoCentroTrabajoId)
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    await _client.DeleteAsync(procesoCentroTrabajoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / Delete", exception);
            }
        }

        public static async Task<ProcesoCentroTrabajo> Get(int procesoCentroTrabajoId)
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    var reg = await _client.GetAsync(procesoCentroTrabajoId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / Get", exception);
            }
        }

        public static async Task<List<ProcesoCentroTrabajo>> GetAll()
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetAll", exception);
            }
        }

        public static async Task<List<ProcesoCentroTrabajo>> GetByProceso(int procesoId)
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    var lista = await _client.GetbyProcesoAsync(procesoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetByProceso", exception);
            }
        }

        public static async Task<List<ProcesoCentroTrabajo>> GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    var lista = await _client.GetByCentroTrabajoAsync(centroTrabajoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetByCentroTrabajo", exception);
            }
        }

        public static async Task<List<ProcesoCentroTrabajo>> GetByCentroTrabajoOpcion(int centroTrabajoOpcionId)
        {
            try
            {
                using (_client = new ProcesoCentroTrabajoClient())
                {
                    var lista = await _client.GetByCentroTrabajoOpcionAsync(centroTrabajoOpcionId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ProcesoCentroTrabajo / GetByCentroTrabajoOpcion", exception);
            }
        }

        private static ProcesoCentroTrabajo BusinessToClient(ProcesoCentroTrabajoBusiness input)
        {
            return new ProcesoCentroTrabajo
            {
                Id = input.Id,
                ProcesoId = input.ProcesoId,
                CentroTrabajoId = input.CentroTrabajoId,
                CentroTrabajoOpcionId = input.CentroTrabajoOpcionId,
                Orden = input.Orden,
                Proceso = new Proceso
                {
                    Id = input.Proceso.Id,
                    CentroTrabajoId = input.Proceso.CentroTrabajoId,
                    Descripcion = input.Proceso.Descripcion,
                    EsActivo = input.Proceso.EsActivo,
                    EsObligatorio = input.Proceso.EsObligatorio,
                    Nombre = input.Proceso.Nombre,
                    Secuencia = input.Proceso.Secuencia,
                    TiempoEstandar = input.Proceso.TiempoEstandar
                },
                CentroTrabajo = new CentroTrabajo
                {
                    Codigo = input.CentroTrabajo.Codigo,
                    Nombre = input.CentroTrabajo.Nombre,
                    EsActivo = input.CentroTrabajo.EsActivo,
                    EsObligatorio = input.CentroTrabajo.EsObligatorio,
                    TiempoEspera = input.CentroTrabajo.TiempoEspera,
                    LineaProduccionCodigo = input.CentroTrabajo.LineaProduccionCodigo,
                    Orden = input.CentroTrabajo.Orden,
                    Observacion = input.CentroTrabajo.Observacion,
                    TiempoProceso = input.CentroTrabajo.TiempoProceso
                },
                CentroTrabajoOpcion = new CentroTrabajoOpcion
                {
                    Id = input.CentroTrabajoOpcion.Id,
                    CentroTrabajoId = input.CentroTrabajoOpcion.CentroTrabajoId,
                    CentroTrabajoNombre = input.CentroTrabajoOpcion.CentroTrabajoNombre,
                    CentroTrabajoObservacion = input.CentroTrabajoOpcion.CentroTrabajoObservacion,
                    OpcionId = input.CentroTrabajoOpcion.OpcionId,
                    Orden = input.CentroTrabajoOpcion.Orden,
                    OpcionLavado = null,
                    CentroTrabajo = null
                }
            };
        }

        private static ProcesoCentroTrabajoBusiness ClientToBusiness(ProcesoCentroTrabajo input)
        {
            return new ProcesoCentroTrabajoBusiness
            {
                Id = input.Id,
                ProcesoId = input.ProcesoId,
                CentroTrabajoId = input.CentroTrabajoId,
                CentroTrabajoOpcionId = input.CentroTrabajoOpcionId,
                Orden = input.Orden,
                Proceso = new ProcesoBusiness
                {
                    Id = input.Proceso.Id,
                    CentroTrabajoId = input.Proceso.CentroTrabajoId,
                    Descripcion = input.Proceso.Descripcion,
                    EsActivo = input.Proceso.EsActivo,
                    EsObligatorio = input.Proceso.EsObligatorio,
                    Nombre = input.Proceso.Nombre,
                    Secuencia = input.Proceso.Secuencia,
                    TiempoEstandar = input.Proceso.TiempoEstandar
                },
                CentroTrabajo = new CTrabajoBusiness
                {
                    Codigo = input.CentroTrabajo.Codigo,
                    Nombre = input.CentroTrabajo.Nombre,
                    EsActivo = input.CentroTrabajo.EsActivo,
                    EsObligatorio = input.CentroTrabajo.EsObligatorio,
                    TiempoEspera = input.CentroTrabajo.TiempoEspera,
                    LineaProduccionCodigo = input.CentroTrabajo.LineaProduccionCodigo,
                    Orden = input.CentroTrabajo.Orden,
                    Observacion = input.CentroTrabajo.Observacion,
                    TiempoProceso = input.CentroTrabajo.TiempoProceso
                }
            };
        }

        #endregion
    }
}