using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ObservacionPredefinidaServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class ObservacionPredefinida : ObservableObject
    {
        private static ObservacionPredefinidaClient _client;

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

        #region OperacionId

        /// <summary>
        /// The <see cref="OperacionId" /> property's name.
        /// </summary>
        public const string OperacionIdPropertyName = "OperacionId";

        private int _operacionId;

        /// <summary>
        /// Sets and gets the OperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionId
        {
            get
            {
                return _operacionId;
            }

            set
            {
                if (_operacionId == value)
                {
                    return;
                }

                _operacionId = value;
                RaisePropertyChanged(OperacionIdPropertyName);
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

        //

        public Operacion Operacion { get; set; }

        #endregion

        #region Methods

        public static async Task<ObservacionPredefinida> Update(ObservacionPredefinida observacionPredefinida)
        {
            try
            {
                using (_client = new ObservacionPredefinidaClient())
                {
                    var reg = new ObservacionPredefinidaBusiness
                    {
                        Id = observacionPredefinida.Id,
                        Descripcion = observacionPredefinida.Descripcion,
                        OperacionId = observacionPredefinida.OperacionId,
                        Orden = observacionPredefinida.Orden,
                        Posicion = observacionPredefinida.Posicion
                    };

                    reg = await _client.UpdateAsync(reg);

                    return BusinesToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinida / Update", exception);
            }
        }

        public static async Task Delete(int observacionPredefinidaId)
        {
            try
            {
                using (_client = new ObservacionPredefinidaClient())
                {
                    using (_client = new ObservacionPredefinidaClient())
                    {
                        await _client.DeleteAsync(observacionPredefinidaId);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinida / Delete", exception);
            }
        }

        public static async Task<ObservacionPredefinida> Get(int observacionPredefinidaId)
        {
            try
            {
                using (_client = new ObservacionPredefinidaClient())
                {
                    var reg = await _client.GetAsync(observacionPredefinidaId);

                    return BusinesToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinida / Get", exception);
            }
        }

        public static async Task<List<ObservacionPredefinida>> GetAll()
        {
            try
            {
                using (_client = new ObservacionPredefinidaClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(BusinesToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinida / GetAll", exception);
            }
        }

        public static async Task<List<ObservacionPredefinida>> GetbyOperacionId(int operacionId)
        {
            try
            {
                using (_client = new ObservacionPredefinidaClient())
                {
                    var lista = await _client.GetByOperacionAsync(operacionId);

                    return lista.Select(BusinesToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionPredefinida / GetByOperacion", exception);
            }
        }

        private static ObservacionPredefinida BusinesToClient(ObservacionPredefinidaBusiness reg)
        {
            return new ObservacionPredefinida
            {
                Id = reg.Id,
                Descripcion = reg.Descripcion,
                OperacionId = reg.OperacionId,
                Orden = reg.Orden,
                Posicion = reg.Posicion,
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
                        Operacion = null,
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

        #endregion
    }
}