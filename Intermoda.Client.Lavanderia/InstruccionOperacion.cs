using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.InstruccionOperacionServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class InstruccionOperacion : ObservableObject
    {
        private static InstruccionOperacionClient _client;

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

        #region TiempoMinimo

        /// <summary>
        /// The <see cref="TiempoMinimo" /> property's name.
        /// </summary>
        public const string TiempoMinimoPropertyName = "TiempoMinimo";

        private decimal _tiempoMinimo;

        /// <summary>
        /// Sets and gets the TiempoMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMinimo
        {
            get
            {
                return _tiempoMinimo;
            }

            set
            {
                if (_tiempoMinimo == value)
                {
                    return;
                }

                _tiempoMinimo = value;
                RaisePropertyChanged(TiempoMinimoPropertyName);
            }
        }

        #endregion

        #region TiempoMaximo

        /// <summary>
        /// The <see cref="TiempoMaximo" /> property's name.
        /// </summary>
        public const string TiempoMaximoPropertyName = "TiempoMaximo";

        private decimal _tiempoMaximo;

        /// <summary>
        /// Sets and gets the TiempoMaximo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMaximo
        {
            get
            {
                return _tiempoMaximo;
            }

            set
            {
                if (_tiempoMaximo == value)
                {
                    return;
                }

                _tiempoMaximo = value;
                RaisePropertyChanged(TiempoMaximoPropertyName);
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

        #region Temperatura

        /// <summary>
        /// The <see cref="Temperatura" /> property's name.
        /// </summary>
        public const string TemperaturaPropertyName = "Temperatura";

        private int? _temperatura;

        /// <summary>
        /// Sets and gets the Temperatura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Temperatura
        {
            get
            {
                return _temperatura;
            }

            set
            {
                if (_temperatura == value)
                {
                    return;
                }

                _temperatura = value;
                RaisePropertyChanged(TemperaturaPropertyName);
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

        public OperacionProceso OperacionProceso { get; set; }

        #endregion

        #region Methods

        public static async Task<InstruccionOperacion> Update(InstruccionOperacion instruccionOperacion)
        {
            try
            {
                using (_client = new InstruccionOperacionClient())
                {
                    var reg = ClientToBusiness(instruccionOperacion);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOpercion / Update", exception);
            }
        }

        public static async Task Delete(int instruccionOperacionId)
        {
            try
            {
                using (_client = new InstruccionOperacionClient())
                {
                    await _client.DeleteAsync(instruccionOperacionId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOpercion / Delete", exception);
            }
        }

        public static async Task<InstruccionOperacion> Get(int instruccionOperacionId)
        {
            try
            {
                using (_client = new InstruccionOperacionClient())
                {
                    var reg = await _client.GetAsync(instruccionOperacionId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOpercion / Get", exception);
            }
        }

        public static async Task<List<InstruccionOperacion>> GetAll()
        {
            try
            {
                using (_client = new InstruccionOperacionClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOpercion / GetAll", exception);
            }
        }

        public static async Task<List<InstruccionOperacion>> GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                using (_client = new InstruccionOperacionClient())
                {
                    var lista = await _client.GetByOperacionProcesoAsync(operacionProcesoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionOpercion / GetAll", exception);
            }
        }

        private static InstruccionOperacion BusinessToClient(InstruccionOperacionBusiness input)
        {
            return new InstruccionOperacion
            {
                Id = input.Id,
                OperacionProcesoId = input.OperacionProcesoId,
                Descripcion = input.Descripcion,
                TiempoMinimo = input.TiempoMinimo,
                TiempoMaximo = input.TiempoMaximo,
                TiempoEstandar = input.TiempoEstandar,
                Temperatura = input.Temperatura,
                Orden = input.Orden,
                OperacionProceso = new OperacionProceso
                {
                    Id = input.OperacionProceso.Id,
                    OperacionId = input.OperacionProceso.OperacionId,
                    Orden = input.OperacionProceso.Orden,
                    Ph = input.OperacionProceso.Ph,
                    ProcesoCentroTrabajoId = input.OperacionProceso.ProcesoCentroTrabajoId,
                    ProcesoId = input.OperacionProceso.ProcesoId,
                    RelacionBano = input.OperacionProceso.RelacionBano,
                    TiempoMinimo = input.OperacionProceso.TiempoMinimo,
                    TiempoMaximo = input.OperacionProceso.TiempoMaximo,
                    TiempoEstandar = input.OperacionProceso.TiempoEstandar
                }
            };
        }

        private static InstruccionOperacionBusiness ClientToBusiness(InstruccionOperacion input)
        {
            return new InstruccionOperacionBusiness
            {
                Id = input.Id,
                OperacionProcesoId = input.OperacionProcesoId,
                Descripcion = input.Descripcion,
                TiempoMinimo = input.TiempoMinimo,
                TiempoMaximo = input.TiempoMaximo,
                TiempoEstandar = input.TiempoEstandar,
                Temperatura = input.Temperatura,
                Orden = input.Orden,
                OperacionProceso = new OperacionProcesoBusiness
                {
                    Id = input.OperacionProceso.Id,
                    OperacionId = input.OperacionProceso.OperacionId,
                    Orden = input.OperacionProceso.Orden,
                    Ph = input.OperacionProceso.Ph,
                    ProcesoCentroTrabajoId = input.OperacionProceso.ProcesoCentroTrabajoId,
                    ProcesoId = input.OperacionProceso.ProcesoId,
                    RelacionBano = input.OperacionProceso.RelacionBano,
                    TiempoMinimo = input.OperacionProceso.TiempoMinimo,
                    TiempoMaximo = input.OperacionProceso.TiempoMaximo,
                    TiempoEstandar = input.OperacionProceso.TiempoEstandar
                }
            };
        }

        #endregion
    }
}