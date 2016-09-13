using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class CentroTrabajo : ObservableObject
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
            get { return _id; }

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
            get { return _codigo; }

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
            get { return _nombre; }

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
            get { return _secuencia; }

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
            get { return _estado; }

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

        public static async Task<CentroTrabajo> Update(CentroTrabajo reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var business = new CentroTrabajoBusiness1
                    {
                        Id = reg.Id,
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        Secuencia = reg.Secuencia,
                        Estado = reg.Estado
                    };
                    var model = await _client.CentroTrabajoUpdateAsync(business);
                    return new CentroTrabajo
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Update", exception);
            }
        }

        public static async Task Delete(int centroTrabajoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.CentroTrabajoDeleteAsync(centroTrabajoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Delete", exception);
            }
        }

        public static async Task<CentroTrabajo> Get(int centroTrabajoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var model = await _client.CentroTrabajoGetAsync(centroTrabajoId);
                    return new CentroTrabajo
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Get", exception);
            }
        }

        public static async Task<List<CentroTrabajo>> GetAll()
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.CentroTrabajoGetAllAsync();

                    return lista.Select(model => new CentroTrabajo
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Get", exception);
            }
        }

        public static async Task<List<CentroTrabajo>> GetActivos()
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.CentroTrabajoGetActivosAsync();

                    return lista.Select(model => new CentroTrabajo
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("CentroTrabajo / Get", exception);
            }
        }
        
        #endregion
    }
}