using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ObservacionOperacionServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class ObservacionOperacion : ObservableObject
    {
        private static ObservacionOperacionClient _client;

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

        #region OperacionProcesoId

        /// <summary>
        /// The <see cref="OperacionProcesoId" /> property's name.
        /// </summary>
        public const string OperacionProcesoIdPropertyName = "OperacionProcesoId";

        private int _operacionProcesoId;

        /// <summary>
        /// Sets and gets the OperacionProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionProcesoId
        {
            get
            {
                return _operacionProcesoId;
            }

            set
            {
                if (_operacionProcesoId == value)
                {
                    return;
                }

                _operacionProcesoId = value;
                RaisePropertyChanged(OperacionProcesoIdPropertyName);
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

        #region Posicion

        /// <summary>
        /// The <see cref="Posicion" /> property's name.
        /// </summary>
        public const string PosicionPropertyName = "Posicion";

        private int? _posicion;

        /// <summary>
        /// Sets and gets the Posicion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Posicion
        {
            get
            {
                return _posicion;
            }

            set
            {
                if (_posicion == value)
                {
                    return;
                }

                _posicion = value;
                RaisePropertyChanged(PosicionPropertyName);
            }
        }

        #endregion

        public OperacionProceso OperacionProceso { get; set; }

        #endregion

        #region Methods

        public static async Task<ObservacionOperacion> Update(ObservacionOperacion observacionOperacion)
        {
            try
            {
                using (_client = new ObservacionOperacionClient())
                {
                    var reg = ClientToBusiness(observacionOperacion);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / Update", exception);
            }
        }

        public static async Task Delete(int observacionOperacionId)
        {
            try
            {
                using (_client = new ObservacionOperacionClient())
                {
                    await _client.DeleteAsync(observacionOperacionId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / Delete", exception);
            }
        }

        public static async Task<ObservacionOperacion> Get(int obaservacionOperacionId)
        {
            try
            {
                using (_client = new ObservacionOperacionClient())
                {
                    var reg = await _client.GetAsync(obaservacionOperacionId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / Get", exception);
            }
        }

        public static async Task<List<ObservacionOperacion>> GetAll()
        {
            try
            {
                using (_client = new ObservacionOperacionClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / GetAll", exception);
            }
        }

        public static async Task<List<ObservacionOperacion>> GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                using (_client = new ObservacionOperacionClient())
                {
                    var lista = await _client.GetByOperacionProcesoAsync(operacionProcesoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ObservacionOperacion / GetAll", exception);
            }
        }

        private static ObservacionOperacion BusinessToClient(ObservacionOperacionBusiness input)
        {
            return new ObservacionOperacion
            {
                Id = input.Id,
                Descripcion = input.Descripcion,
                Orden = input.Orden,
                Posicion = input.Posicion,
                OperacionProcesoId = input.OperacionProcesoId,
                OperacionProceso = new OperacionProceso
                {
                    Id = input.OperacionProceso.Id,
                    OperacionId = input.OperacionProceso.OperacionId,
                    ProcesoId = input.OperacionProceso.ProcesoId,
                    ProcesoCentroTrabajoId = input.OperacionProceso.ProcesoCentroTrabajoId,
                    Temperatura = input.OperacionProceso.Temperatura,
                    Ph = input.OperacionProceso.Ph,
                    TiempoMinimo = input.OperacionProceso.TiempoMinimo,
                    TiempoMaximo = input.OperacionProceso.TiempoMaximo,
                    TiempoEstandar = input.OperacionProceso.TiempoEstandar,
                    RelacionBano = input.OperacionProceso.RelacionBano,
                    Orden = input.OperacionProceso.Orden
                }
            };
        }

        private static ObservacionOperacionBusiness ClientToBusiness(ObservacionOperacion input)
        {
            return new ObservacionOperacionBusiness
            {
                Id = input.Id,
                Descripcion = input.Descripcion,
                Orden = input.Orden,
                Posicion = input.Posicion,
                OperacionProcesoId = input.OperacionProcesoId,
                OperacionProceso = new OperacionProcesoBusiness
                {
                    Id = input.OperacionProceso.Id,
                    OperacionId = input.OperacionProceso.OperacionId,
                    ProcesoId = input.OperacionProceso.ProcesoId,
                    ProcesoCentroTrabajoId = input.OperacionProceso.ProcesoCentroTrabajoId,
                    Temperatura = input.OperacionProceso.Temperatura,
                    Ph = input.OperacionProceso.Ph,
                    TiempoMinimo = input.OperacionProceso.TiempoMinimo,
                    TiempoMaximo = input.OperacionProceso.TiempoMaximo,
                    TiempoEstandar = input.OperacionProceso.TiempoEstandar,
                    RelacionBano = input.OperacionProceso.RelacionBano,
                    Orden = input.OperacionProceso.Orden
                }
            };
        }

        #endregion
    }
}