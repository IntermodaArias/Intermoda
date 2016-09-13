using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ArchivoGlobalServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class ArchivoGlobal : ObservableObject
    {
        private static ArchivoGlobalClient _client;

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

        #region PropietarioId

        /// <summary>
        /// The <see cref="PropietarioId" /> property's name.
        /// </summary>
        public const string PropietarioIdPropertyName = "PropietarioId";

        private int _propietarioId;

        /// <summary>
        /// Sets and gets the PropietarioId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PropietarioId
        {
            get
            {
                return _propietarioId;
            }

            set
            {
                if (_propietarioId == value)
                {
                    return;
                }

                _propietarioId = value;
                RaisePropertyChanged(PropietarioIdPropertyName);
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

        #region Tipo

        /// <summary>
        /// The <see cref="Tipo" /> property's name.
        /// </summary>
        public const string TipoPropertyName = "Tipo";

        private string _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                if (_tipo == value)
                {
                    return;
                }

                _tipo = value;
                RaisePropertyChanged(TipoPropertyName);
            }
        }

        #endregion

        #region Extension

        /// <summary>
        /// The <see cref="Extension" /> property's name.
        /// </summary>
        public const string ExtensionPropertyName = "Extension";

        private string _extension;

        /// <summary>
        /// Sets and gets the Extension property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Extension
        {
            get
            {
                return _extension;
            }

            set
            {
                if (_extension == value)
                {
                    return;
                }

                _extension = value;
                RaisePropertyChanged(ExtensionPropertyName);
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

        #region Binario

        /// <summary>
        /// The <see cref="Binario" /> property's name.
        /// </summary>
        public const string BinarioPropertyName = "Binario";

        private byte[] _binario;

        /// <summary>
        /// Sets and gets the Binario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public byte[] Binario
        {
            get
            {
                return _binario;
            }

            set
            {
                if (_binario == value)
                {
                    return;
                }

                _binario = value;
                RaisePropertyChanged(BinarioPropertyName);
            }
        }

        #endregion

        #region PropietarioNombre

        /// <summary>
        /// The <see cref="PropietarioNombre" /> property's name.
        /// </summary>
        public const string PropietarioNombrePropertyName = "PropietarioNombre";

        private string _propietarioNombre;

        /// <summary>
        /// Sets and gets the PropietarioNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PropietarioNombre
        {
            get
            {
                return _propietarioNombre;
            }

            set
            {
                if (_propietarioNombre == value)
                {
                    return;
                }

                _propietarioNombre = value;
                RaisePropertyChanged(PropietarioNombrePropertyName);
            }
        }

        #endregion

        #region Fecha

        /// <summary>
        /// The <see cref="Fecha" /> property's name.
        /// </summary>
        public const string FechaPropertyName = "Fecha";

        private DateTime _fecha;

        /// <summary>
        /// Sets and gets the Fecha property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                if (_fecha == value)
                {
                    return;
                }

                _fecha = value;
                RaisePropertyChanged(FechaPropertyName);
            }
        }

        #endregion

        #region Version

        /// <summary>
        /// The <see cref="Version" /> property's name.
        /// </summary>
        public const string VersionPropertyName = "Version";

        private string _version;

        /// <summary>
        /// Sets and gets the Version property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Version
        {
            get
            {
                return _version;
            }

            set
            {
                if (_version == value)
                {
                    return;
                }

                _version = value;
                RaisePropertyChanged(VersionPropertyName);
            }
        }

        #endregion

        public Lavado Lavado { get; set; }

        #endregion

        #region Methods

        public static async Task<ArchivoGlobal> Update(ArchivoGlobal archivoGlobal)
        {
            try
            {
                var reg = ClientToBusiness(archivoGlobal);
                reg = await _client.UpdateAsync(reg);
                return BusinessToClient(reg);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / Update", exception);
            }
        }

        public static async Task Delete(int archivoGlobalId)
        {
            try
            {
                await _client.DeleteAsync(archivoGlobalId);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / Delete", exception);
            }
        }

        public static async Task<ArchivoGlobal> Get(int archivoGlobalId)
        {
            try
            {
                var reg = await _client.GetAsync(archivoGlobalId);
                return BusinessToClient(reg);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / Get", exception);
            }
        }

        public static async Task<List<ArchivoGlobal>> GetAll()
        {
            try
            {
                var array = await _client.GetAllAsync();
                return array.Select(BusinessToClient).ToList();
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / GetAll", exception);
            }
        }

        public static async Task<ArchivoGlobal> GetByPropietario(int propietarioId)
        {
            try
            {
                var reg = await _client.GetByPropietarioAsync(propietarioId);
                return BusinessToClient(reg);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / GetByPropietario", exception);
            }
        }

        private static ArchivoGlobal BusinessToClient(ArchivoGlobalBusiness input)
        {
            var reg = new ArchivoGlobal
            {
                Id = input.Id,
                PropietarioId = input.PropietarioId,
                Nombre = input.Nombre,
                Tipo = input.Tipo,
                Extension = input.Extension,
                Orden = input.Orden,
                Descripcion = input.Descripcion,
                Binario = input.Binario,
                PropietarioNombre = input.PropietarioNombre,
                Fecha = input.Fecha,
                Version = input.Version,
                Lavado = new Lavado
                {
                    LavadoId = input.Lavado.LavadoId,
                    LavadoNombre = input.Lavado.LavadoNombre,
                    LavadoDescripcion = input.Lavado.LavadoDescripcion,
                    ColorId = input.Lavado.ColorId,
                    EsActivo = input.Lavado.IsActivo,
                    LavadoFechaCreacion = input.Lavado.LavadoFechaCreacion,
                    LavadoFechaActualizacion = input.Lavado.LavadoFechaActualizacion,
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = input.Lavado.ColorIntermoda.Id,
                        Nombre = input.Lavado.ColorIntermoda.Nombre
                    }
                }
            };
            return reg;
        }

        private static ArchivoGlobalBusiness ClientToBusiness(ArchivoGlobal input)
        {
            var reg = new ArchivoGlobalBusiness
            {
                Id = input.Id,
                PropietarioId = input.PropietarioId,
                Nombre = input.Nombre,
                Tipo = input.Tipo,
                Extension = input.Extension,
                Orden = input.Orden,
                Descripcion = input.Descripcion,
                Binario = input.Binario,
                PropietarioNombre = input.PropietarioNombre,
                Fecha = input.Fecha,
                Version = input.Version,
                Lavado = new LavadoBusiness
                {
                    LavadoId = input.Lavado.LavadoId,
                    LavadoNombre = input.Lavado.LavadoNombre,
                    LavadoDescripcion = input.Lavado.LavadoDescripcion,
                    ColorId = input.Lavado.ColorId,
                    IsActivo = input.Lavado.EsActivo,
                    LavadoFechaCreacion = input.Lavado.LavadoFechaCreacion,
                    LavadoFechaActualizacion = input.Lavado.LavadoFechaActualizacion,
                    ColorIntermoda = new ColoresIntermodaBusiness
                    {
                        Id = input.Lavado.ColorIntermoda.Id,
                        Nombre = input.Lavado.ColorIntermoda.Nombre
                    }
                }
            };
            return reg;
        }

        #endregion
    }
}