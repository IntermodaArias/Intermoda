using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.LavadoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Lavado : ObservableObject
    {
        private static LavadoClient _client;

        #region Properties

        #region LavadoId

        /// <summary>
        /// The <see cref="LavadoId" /> property's name.
        /// </summary>
        public const string LavadoIdPropertyName = "LavadoId";

        private int _lavadoId;

        /// <summary>
        /// Sets and gets the LavadoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LavadoId
        {
            get
            {
                return _lavadoId;
            }

            set
            {
                if (_lavadoId == value)
                {
                    return;
                }

                _lavadoId = value;
                RaisePropertyChanged(LavadoIdPropertyName);
            }
        }

        #endregion

        #region LavadoNombre

        /// <summary>
        /// The <see cref="LavadoNombre" /> property's name.
        /// </summary>
        public const string LavadoNombrePropertyName = "LavadoNombre";

        private string _lavadoNombre;

        /// <summary>
        /// Sets and gets the LavadoNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoNombre
        {
            get
            {
                return _lavadoNombre;
            }

            set
            {
                if (_lavadoNombre == value)
                {
                    return;
                }

                _lavadoNombre = value;
                RaisePropertyChanged(LavadoNombrePropertyName);
            }
        }

        #endregion

        #region LavadoDescripcion

        /// <summary>
        /// The <see cref="LavadoDescripcion" /> property's name.
        /// </summary>
        public const string LavadoDescripcionPropertyName = "LavadoDescripcion";

        private string _lavadoDescripcion;

        /// <summary>
        /// Sets and gets the LavadoDescripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoDescripcion
        {
            get
            {
                return _lavadoDescripcion;
            }

            set
            {
                if (_lavadoDescripcion == value)
                {
                    return;
                }

                _lavadoDescripcion = value;
                RaisePropertyChanged(LavadoDescripcionPropertyName);
            }
        }

        #endregion

        #region ColorId

        /// <summary>
        /// The <see cref="ColorId" /> property's name.
        /// </summary>
        public const string ColorIdPropertyName = "ColorId";

        private int _colorId;

        /// <summary>
        /// Sets and gets the ColorId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ColorId
        {
            get
            {
                return _colorId;
            }

            set
            {
                if (_colorId == value)
                {
                    return;
                }

                _colorId = value;
                RaisePropertyChanged(ColorIdPropertyName);
            }
        }

        #endregion

        #region EsActivo

        /// <summary>
        /// The <see cref="EsActivo" /> property's name.
        /// </summary>
        public const string EsActivoPropertyName = "EsActivo";

        private int? _esActivo;

        /// <summary>
        /// Sets and gets the EsActivo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? EsActivo
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

        #region LavadoFechaCreacion

        /// <summary>
        /// The <see cref="LavadoFechaCreacion" /> property's name.
        /// </summary>
        public const string LavadoFechaCreacionPropertyName = "LavadoFechaCreacion";

        private DateTime? _lavadoFechaCreacion;

        /// <summary>
        /// Sets and gets the LavadoFechaCreacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? LavadoFechaCreacion
        {
            get
            {
                return _lavadoFechaCreacion;
            }

            set
            {
                if (_lavadoFechaCreacion == value)
                {
                    return;
                }

                _lavadoFechaCreacion = value;
                RaisePropertyChanged(LavadoFechaCreacionPropertyName);
            }
        }

        #endregion

        #region LavadoFechaActualizacion

        /// <summary>
        /// The <see cref="LavadoFechaActualizacion" /> property's name.
        /// </summary>
        public const string LavadoFechaActualizacionPropertyName = "LavadoFechaActualizacion";

        private DateTime? _lavadofechaActualizacion;

        /// <summary>
        /// Sets and gets the LavadoFechaActualizacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? LavadoFechaActualizacion
        {
            get
            {
                return _lavadofechaActualizacion;
            }

            set
            {
                if (_lavadofechaActualizacion == value)
                {
                    return;
                }

                _lavadofechaActualizacion = value;
                RaisePropertyChanged(LavadoFechaActualizacionPropertyName);
            }
        }

        #endregion

        public ColorIntermoda ColorIntermoda { get; set; }

        #endregion

        #region Methods

        public static async Task<Lavado> Update(Lavado lavado)
        {
            try
            {
                using (_client = new LavadoClient())
                {
                    var reg = ClientToBusiness(lavado);
                    reg = await _client.UpdateAsync(reg);
                    lavado = BusinessToClient(reg);
                    return lavado;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Update", exception);
            }
        }

        public static async Task Delete(int lavadoId)
        {
            try
            {
                using (_client = new LavadoClient())
                {
                    await _client.DeleteAsync(lavadoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Update", exception);
            }
        }

        public static async Task<Lavado> Get(int lavadoId)
        {
            try
            {
                using (_client = new LavadoClient())
                {
                    var reg = await _client.GetAsync(lavadoId);
                    var ret = BusinessToClient(reg);
                    return ret;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Update", exception);
            }
        }

        public static async Task<List<Lavado>> GetAll()
        {
            try
            {
                using (_client = new LavadoClient())
                {
                    var array = await _client.GetAllAsync();
                    var lista = array.Select(BusinessToClient).ToList();
                    return lista;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / GetAll", exception);
            }
        }

        public static async Task<Lavado> GetByNombre(string lavadoNombre)
        {
            try
            {
                using (_client = new LavadoClient())
                {
                    var reg = await _client.GetByNombreAsync(lavadoNombre);
                    var ret = BusinessToClient(reg);
                    return ret;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Update", exception);
            }
        }

        private static Lavado BusinessToClient(LavadoBusiness input)
        {
            return new Lavado
            {
                LavadoId = input.LavadoId,
                LavadoNombre = input.LavadoNombre,
                LavadoDescripcion = input.LavadoDescripcion,
                ColorId = input.ColorId,
                EsActivo = input.IsActivo,
                LavadoFechaCreacion = input.LavadoFechaCreacion,
                LavadoFechaActualizacion = input.LavadoFechaActualizacion,
                ColorIntermoda = new ColorIntermoda
                {
                    Id = input.ColorIntermoda.Id,
                    Nombre = input.ColorIntermoda.Nombre
                }
            };
        }

        private static LavadoBusiness ClientToBusiness(Lavado input)
        {
            return new LavadoBusiness
            {
                LavadoId = input.LavadoId,
                LavadoNombre = input.LavadoNombre,
                LavadoDescripcion = input.LavadoDescripcion,
                ColorId = input.ColorId,
                IsActivo = input.EsActivo,
                LavadoFechaCreacion = input.LavadoFechaCreacion,
                LavadoFechaActualizacion = input.LavadoFechaActualizacion,
                ColorIntermoda = new ColoresIntermodaBusiness
                {
                    Id = input.ColorIntermoda.Id,
                    Nombre = input.ColorIntermoda.Nombre
                }
            };
        }

        #endregion
    }
}