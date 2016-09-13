using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lectura.GrupoServiceReference;

namespace Intermoda.Client.Lectura
{
    public class Grupo : ObservableObject
    {
        private static GrupoClient _client;

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

        #region FechaInicio

        /// <summary>
        /// The <see cref="FechaInicio" /> property's name.
        /// </summary>
        public const string FechaInicioPropertyName = "FechaInicio";

        private DateTime _fechaInicio;

        /// <summary>
        /// Sets and gets the FechaInicio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                if (_fechaInicio == value)
                {
                    return;
                }

                _fechaInicio = value;
                RaisePropertyChanged(FechaInicioPropertyName);
            }
        }

        #endregion

        #region FechaFinal

        /// <summary>
        /// The <see cref="FechaFinal" /> property's name.
        /// </summary>
        public const string FechaFinalPropertyName = "FechaFinal";

        private DateTime _fechaFinal;

        /// <summary>
        /// Sets and gets the FechaFinal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaFinal
        {
            get
            {
                return _fechaFinal;
            }

            set
            {
                if (_fechaFinal == value)
                {
                    return;
                }

                _fechaFinal = value;
                RaisePropertyChanged(FechaFinalPropertyName);
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

        public static async Task<Grupo> Update(Grupo reg)
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    var business = new GrupoBusiness
                    {
                        Id = reg.Id,
                        FechaInicio = reg.FechaInicio,
                        FechaFinal = reg.FechaFinal,
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        Secuencia = reg.Secuencia,
                        Estado = reg.Estado
                    };

                    var model = await _client.UpdateAsync(business);

                    return new Grupo
                    {
                        Id = model.Id,
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / Update", exception);
            }
        }

        public static async Task Delete(int grupoId)
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    await _client.DeleteAsync(grupoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / Delete", exception);
            }
        }

        public static async Task<Grupo> Get(int grupoId)
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    var model = await _client.GetAsync(grupoId);
                    return new Grupo
                    {
                        Id = model.Id,
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / Get", exception);
            }
        }

        public static async Task<List<Grupo>> GetAll()
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(model => new Grupo
                    {
                        Id = model.Id,
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / GetAll", exception);
            }
        }

        public static async Task<List<Grupo>> GetAllActive() {
            try
            {
                using (_client = new GrupoClient())
                {
                    var lista = await _client.GetAllActivosAsync();
                    return lista.Select(model => new Grupo
                    {
                        Id = model.Id,
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / GetAllActive", exception);
            }
        }

        public static async Task<Grupo> GetByLinea(int lineaId)
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    var model = await _client.GetByLineaAsync(lineaId);
                    return new Grupo
                    {
                        Id = model.Id,
                        FechaInicio = model.FechaInicio,
                        FechaFinal = model.FechaFinal,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / GetByLinea", exception);
            }
        }

        public static async Task CopiarSemana(DateTime desde, DateTime hasta)
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    await _client.CopiarSemanaAsync(desde, hasta);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / CopiarSemana", exception);
            }
        }

        public static async Task<bool> HayDataSemana(DateTime fecha)
        {
            try
            {
                using (_client = new GrupoClient())
                {
                    return await _client.HayDataSemanaAsync(fecha);
                    
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Grupo / HayDataSemana", exception);
            }
        }

        #endregion
    }
}