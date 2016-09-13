using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.InstruccionPredefinidaServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class InstruccionPredefinida: ObservableObject
    {
        private static InstruccionPredefinidaClient _client;

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

        #region OperacionPredefinidaId

        /// <summary>
        /// The <see cref="OperacionPredefinidaId" /> property's name.
        /// </summary>
        public const string OperacionPredefinidaIdPropertyName = "OperacionPredefinidaId";

        private int _operacionPredefinidaId;

        /// <summary>
        /// Sets and gets the OperacionPredefinidaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionPredefinidaId
        {
            get
            {
                return _operacionPredefinidaId;
            }

            set
            {
                if (_operacionPredefinidaId == value)
                {
                    return;
                }

                _operacionPredefinidaId = value;
                RaisePropertyChanged(OperacionPredefinidaIdPropertyName);
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

        public OperacionPredefinida OperacionPredefinida { get; set; }

        #endregion

        #region Methods

        public static async Task<InstruccionPredefinida> Update(InstruccionPredefinida instruccionPredefinida)
        {
            try
            {
                using (_client = new InstruccionPredefinidaClient())
                {
                    var reg = new InstruccionPredefinidaBusiness
                    {
                        Id = instruccionPredefinida.Id,
                        OperacionPredefinidaId = instruccionPredefinida.OperacionPredefinidaId,
                        Descripcion = instruccionPredefinida.Descripcion,
                        Orden = instruccionPredefinida.Orden,
                        TiempoMinimo = instruccionPredefinida.TiempoMinimo,
                        TiempoMaximo = instruccionPredefinida.TiempoMaximo,
                        Temperatura = instruccionPredefinida.Temperatura
                    };

                    reg = await _client.UpdateAsync(reg);

                    return new InstruccionPredefinida
                    {
                        Id = reg.Id,
                        OperacionPredefinidaId = reg.OperacionPredefinidaId,
                        Descripcion = reg.Descripcion,
                        Orden = reg.Orden,
                        TiempoMinimo = reg.TiempoMinimo,
                        TiempoMaximo = reg.TiempoMaximo,
                        Temperatura = reg.Temperatura,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OpeacionPredefinida.Id,
                            OperacionId = reg.OpeacionPredefinida.OperacionId,
                            Temperatura = reg.OpeacionPredefinida.Temperatura,
                            Ph = reg.OpeacionPredefinida.Ph,
                            TiempoMinimo = reg.OpeacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OpeacionPredefinida.TiempoMaximo,
                            RelacionBano = reg.OpeacionPredefinida.RelacionBano,
                            Secuencia = reg.OpeacionPredefinida.Secuencia,
                            Operacion = new Operacion
                            {
                                Id = reg.OpeacionPredefinida.Operacion.Id,
                                Descripcion = reg.OpeacionPredefinida.Operacion.Descripcion,
                                GrupoId = reg.OpeacionPredefinida.Operacion.GrupoId,
                                LineaProduccionId = reg.OpeacionPredefinida.Operacion.LineaProduccionId,
                                Nombre = reg.OpeacionPredefinida.Operacion.Nombre,
                                OperacionTipoId = reg.OpeacionPredefinida.Operacion.OperacionTipoId
                            }
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / Update", exception);
            }
        }

        public static async Task Delete(int instruccionPredefinidaId)
        {
            try
            {
                using (_client = new InstruccionPredefinidaClient())
                {
                    await _client.DeleteAsync(instruccionPredefinidaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / Delete", exception);
            }
        }

        public static async Task<InstruccionPredefinida> Get(int instruccionPredefinidaId)
        {
            try
            {
                using (_client = new InstruccionPredefinidaClient())
                {
                    var reg = await _client.GetAsync(instruccionPredefinidaId);

                    return new InstruccionPredefinida
                    {
                        Id = reg.Id,
                        OperacionPredefinidaId = reg.OperacionPredefinidaId,
                        Descripcion = reg.Descripcion,
                        Orden = reg.Orden,
                        TiempoMinimo = reg.TiempoMinimo,
                        TiempoMaximo = reg.TiempoMaximo,
                        Temperatura = reg.Temperatura,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OpeacionPredefinida.Id,
                            OperacionId = reg.OpeacionPredefinida.OperacionId,
                            Temperatura = reg.OpeacionPredefinida.Temperatura,
                            Ph = reg.OpeacionPredefinida.Ph,
                            TiempoMinimo = reg.OpeacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OpeacionPredefinida.TiempoMaximo,
                            RelacionBano = reg.OpeacionPredefinida.RelacionBano,
                            Secuencia = reg.OpeacionPredefinida.Secuencia,
                            Operacion = new Operacion
                            {
                                Id = reg.OpeacionPredefinida.Operacion.Id,
                                Descripcion = reg.OpeacionPredefinida.Operacion.Descripcion,
                                GrupoId = reg.OpeacionPredefinida.Operacion.GrupoId,
                                LineaProduccionId = reg.OpeacionPredefinida.Operacion.LineaProduccionId,
                                Nombre = reg.OpeacionPredefinida.Operacion.Nombre,
                                OperacionTipoId = reg.OpeacionPredefinida.Operacion.OperacionTipoId
                            }
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / Get", exception);
            }
        }

        public static async Task<List<InstruccionPredefinida>> GetAll()
        {
            try
            {
                using (_client = new InstruccionPredefinidaClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(reg => new InstruccionPredefinida
                    {
                        Id = reg.Id,
                        OperacionPredefinidaId = reg.OperacionPredefinidaId,
                        Descripcion = reg.Descripcion,
                        Orden = reg.Orden,
                        TiempoMinimo = reg.TiempoMinimo,
                        TiempoMaximo = reg.TiempoMaximo,
                        Temperatura = reg.Temperatura,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OpeacionPredefinida.Id,
                            OperacionId = reg.OpeacionPredefinida.OperacionId,
                            Temperatura = reg.OpeacionPredefinida.Temperatura,
                            Ph = reg.OpeacionPredefinida.Ph,
                            TiempoMinimo = reg.OpeacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OpeacionPredefinida.TiempoMaximo,
                            RelacionBano = reg.OpeacionPredefinida.RelacionBano,
                            Secuencia = reg.OpeacionPredefinida.Secuencia,
                            Operacion = new Operacion
                            {
                                Id = reg.OpeacionPredefinida.Operacion.Id,
                                Descripcion = reg.OpeacionPredefinida.Operacion.Descripcion,
                                GrupoId = reg.OpeacionPredefinida.Operacion.GrupoId,
                                LineaProduccionId = reg.OpeacionPredefinida.Operacion.LineaProduccionId,
                                Nombre = reg.OpeacionPredefinida.Operacion.Nombre,
                                OperacionTipoId = reg.OpeacionPredefinida.Operacion.OperacionTipoId
                            }
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / GetAll", exception);
            }
        }

        public static async Task<List<InstruccionPredefinida>> GetByOperacionPredefinida(int operacionPredefinidaId)
        {
            try
            {
                using (_client = new InstruccionPredefinidaClient())
                {
                    var lista = await _client.GetByOperacionPredefinidaAsync(operacionPredefinidaId);

                    return lista.Select(reg => new InstruccionPredefinida
                    {
                        Id = reg.Id,
                        OperacionPredefinidaId = reg.OperacionPredefinidaId,
                        Descripcion = reg.Descripcion,
                        Orden = reg.Orden,
                        TiempoMinimo = reg.TiempoMinimo,
                        TiempoMaximo = reg.TiempoMaximo,
                        Temperatura = reg.Temperatura,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OpeacionPredefinida.Id,
                            OperacionId = reg.OpeacionPredefinida.OperacionId,
                            Temperatura = reg.OpeacionPredefinida.Temperatura,
                            Ph = reg.OpeacionPredefinida.Ph,
                            TiempoMinimo = reg.OpeacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OpeacionPredefinida.TiempoMaximo,
                            RelacionBano = reg.OpeacionPredefinida.RelacionBano,
                            Secuencia = reg.OpeacionPredefinida.Secuencia,
                            Operacion = new Operacion
                            {
                                Id = reg.OpeacionPredefinida.Operacion.Id,
                                Descripcion = reg.OpeacionPredefinida.Operacion.Descripcion,
                                GrupoId = reg.OpeacionPredefinida.Operacion.GrupoId,
                                LineaProduccionId = reg.OpeacionPredefinida.Operacion.LineaProduccionId,
                                Nombre = reg.OpeacionPredefinida.Operacion.Nombre,
                                OperacionTipoId = reg.OpeacionPredefinida.Operacion.OperacionTipoId
                            }
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("InstruccionPredefinida / GetByOperacionPredefinida", exception);
            }
        }

        #endregion
    }
}