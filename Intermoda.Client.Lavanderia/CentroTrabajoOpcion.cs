using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.CentroTrabajoOpcionServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class CentroTrabajoOpcion : ObservableObject
    {
        private static CentroTrabajoOpcionClient _client;

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

        #region CentroTrabajoObservacion

        /// <summary>
        /// The <see cref="CentroTrabajoObservacion" /> property's name.
        /// </summary>
        public const string CentroTrabajoObservacionPropertyName = "CentroTrabajoObservacion";

        private string _centroTrabajoObservacion;

        /// <summary>
        /// Sets and gets the CentroTrabajoObservacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoObservacion
        {
            get
            {
                return _centroTrabajoObservacion;
            }

            set
            {
                if (_centroTrabajoObservacion == value)
                {
                    return;
                }

                _centroTrabajoObservacion = value;
                RaisePropertyChanged(CentroTrabajoObservacionPropertyName);
            }
        }

        #endregion

        #region OpcionId

        /// <summary>
        /// The <see cref="OpcionId" /> property's name.
        /// </summary>
        public const string OpcionIdPropertyName = "OpcionId";

        private int _opcionId;

        /// <summary>
        /// Sets and gets the OpcionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OpcionId
        {
            get
            {
                return _opcionId;
            }

            set
            {
                if (_opcionId == value)
                {
                    return;
                }

                _opcionId = value;
                RaisePropertyChanged(OpcionIdPropertyName);
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

        public CentroTrabajo CentroTrabajo { get; set; }

        public OpcionLavado OpcionLavado { get; set; }

        #endregion

        #region Methods

        public static async Task<CentroTrabajoOpcion> Update(CentroTrabajoOpcion centroTrabajoOpcion)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    var reg = ClientToBusiness(centroTrabajoOpcion);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / Update", exception);
            }
        }

        public static async Task InsertLegacy(int opcionId, int centroTrabajoId)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    throw new NotImplementedException();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / InsertLegacy", exception);
            }
        }

        public static async Task BajarOrden(int centroTrabajoOpcionId, int orden)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    await _client.BajarOrdenAsync(centroTrabajoOpcionId, orden);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / BajarOrden", exception);
            }
        }

        public static async Task SubirOrden(int centroTrabajoOpcion, int orden)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    await _client.SubirOrdenAsync(centroTrabajoOpcion, orden);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / SubirOrden", exception);
            }
        }

        public static async Task Delete(int centroTrabajoOpcionId)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    await _client.DeleteAsync(centroTrabajoOpcionId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / Delete", exception);
            }
        }

        public static async Task DeleteRutaOpcionAcabado(int opcionId)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    await _client.DeleteRutaOpcionAcabadoAsync(opcionId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / DeleteRutaOpcionAcabado", exception);
            }
        }

        public static async Task<CentroTrabajoOpcion> Get(int centroTrabajoOpcionId)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    var reg = await _client.GetAsync(centroTrabajoOpcionId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / Get", exception);
            }
        }

        public static async Task<List<CentroTrabajoOpcion>> GetAll()
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / GetAll", exception);
            }
        }

        public static async Task<List<CentroTrabajoOpcion>> GetByOpcion(int opcionId)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    var lista = await _client.GetByOpcionAsync(opcionId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / GetByOpcion", exception);
            }
        }

        public static async Task<List<CentroTrabajoOpcion>> GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_client = new CentroTrabajoOpcionClient())
                {
                    var lista = await _client.GetByCentroTrabajoAsync(centroTrabajoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoOpcion / InsertLegacy", exception);
            }
        }

        private static CentroTrabajoOpcion BusinessToClient(CentroTrabajoOpcionBusiness input)
        {
            return new CentroTrabajoOpcion
            {
                Id = input.Id,
                OpcionId = input.OpcionId,
                CentroTrabajoId = input.CentroTrabajoId,
                CentroTrabajoNombre = input.CentroTrabajoNombre,
                CentroTrabajoObservacion = input.CentroTrabajoObservacion,
                Orden = input.Orden,
                CentroTrabajo = new CentroTrabajo
                {
                    Codigo = input.CentroTrabajo.Codigo,
                    Nombre = input.CentroTrabajo.Nombre,
                    EsActivo = input.CentroTrabajo.EsActivo,
                    EsObligatorio = input.CentroTrabajo.EsObligatorio,
                    LineaProduccionCodigo = input.CentroTrabajo.LineaProduccionCodigo,
                    Observacion = input.CentroTrabajo.Observacion,
                    Orden = input.CentroTrabajo.Orden,
                    TiempoEspera = input.CentroTrabajo.TiempoEspera,
                    TiempoProceso = input.CentroTrabajo.TiempoProceso
                },
                OpcionLavado = new OpcionLavado
                {
                    Id = input.OpcionLavado.Id,
                    Descripcion = input.OpcionLavado.Descripcion,
                    IsDefault = input.OpcionLavado.IsDefault,
                    TelaId = input.OpcionLavado.TelaId
                }
            };
        }

        private static CentroTrabajoOpcionBusiness ClientToBusiness(CentroTrabajoOpcion input)
        {
            return new CentroTrabajoOpcionBusiness
            {
                Id = input.Id,
                OpcionId = input.OpcionId,
                CentroTrabajoId = input.CentroTrabajoId,
                CentroTrabajoNombre = input.CentroTrabajoNombre,
                CentroTrabajoObservacion = input.CentroTrabajoObservacion,
                Orden = input.Orden,
                CentroTrabajo = new CTrabajoBusiness
                {
                    Codigo = input.CentroTrabajo.Codigo,
                    Nombre = input.CentroTrabajo.Nombre,
                    EsActivo = input.CentroTrabajo.EsActivo,
                    EsObligatorio = input.CentroTrabajo.EsObligatorio,
                    LineaProduccionCodigo = input.CentroTrabajo.LineaProduccionCodigo,
                    Observacion = input.CentroTrabajo.Observacion,
                    Orden = input.CentroTrabajo.Orden,
                    TiempoEspera = input.CentroTrabajo.TiempoEspera,
                    TiempoProceso = input.CentroTrabajo.TiempoProceso
                },
                OpcionLavado = new OpcionLavadoBusiness
                {
                    Id = input.OpcionLavado.Id,
                    Descripcion = input.OpcionLavado.Descripcion,
                    IsDefault = input.OpcionLavado.IsDefault,
                    TelaId = input.OpcionLavado.TelaId
                }
            };
        }

        #endregion
    }
}