using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class CentroTrabajoClasificacion : ObservableObject
    {
        private static DataServiceClient _client;

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

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private string _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                if (_codigo == value)
                {
                    return;
                }

                _codigo = value;
                RaisePropertyChanged(CodigoPropertyName);
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

        #region Tipo

        /// <summary>
        /// The <see cref="Tipo" /> property's name.
        /// </summary>
        public const string TipoPropertyName = "Tipo";

        private CentroTrabajoClasificacionTipo _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public CentroTrabajoClasificacionTipo Tipo
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

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private bool _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Estado
        {
            get
            {
                return _estado;
            }

            set
            {
                if (_estado == value)
                {
                    return;
                }

                _estado = value;
                RaisePropertyChanged(EstadoPropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<CentroTrabajoClasificacion> Update(CentroTrabajoClasificacion reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var business = new CentroTrabajoClasificacionBusiness
                    {
                        Id = reg.Id,
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        CentroTrabajoId = reg.CentroTrabajoId,
                        Secuencia = reg.Secuencia,
                        Estado = reg.Estado,
                        Tipo = CentroTrabajoClasificacionTipo.Titular //(CentroTrabajoClasificacionTipo)Convert.ToInt32(reg.Tipo)
                    };
                    var model = await _client.CentroTrabajoClasificacionUpdateAsync(business);
                    return new CentroTrabajoClasificacion
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Tipo = model.Tipo,
                        Estado = model.Estado,
                        CentroTrabajoId = model.CentroTrabajoId
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion / Insert", exception);
            }
        }

        public static async Task Delete(int centroTrabajoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.CentroTrabajoClasificacionDeleteAsync(centroTrabajoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion / Delete", exception);
            }
        }

        public static async Task<List<CentroTrabajoClasificacion>> GetAll(int centroTrabajoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.CentroTrabajoClasificacionGetByCentroTrabajoAsync(centroTrabajoId);
                    return lista.Select(model => new CentroTrabajoClasificacion
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado,
                        Tipo = model.Tipo,
                        CentroTrabajoId = model.CentroTrabajoId
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion / GetAll", exception);
            }
        }

        public static async Task<List<CentroTrabajoClasificacion>> GetAllActive(int centroTrabajoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.CentroTrabajoClasificacionGetByCentroTrabajoActivosAsync(centroTrabajoId);
                    return lista.Select(model => new CentroTrabajoClasificacion
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado,
                        Tipo = model.Tipo,
                        CentroTrabajoId = model.CentroTrabajoId
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajoClasificacion / GetAllActive", exception);
            }
        }

        #endregion
    }
}