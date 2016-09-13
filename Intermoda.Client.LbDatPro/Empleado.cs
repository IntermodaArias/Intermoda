using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.LbDatPro.EmpleadoServiceReference;

namespace Intermoda.Client.LbDatPro
{
    public class Empleado : ObservableObject
    {
        private static EmpleadoClient _client;

        #region Properties

        #region CompaniaCodigo

        /// <summary>
        /// The <see cref="CompaniaCodigo" /> property's name.
        /// </summary>
        public const string CompaniaCodigoPropertyName = "CompaniaCodigo";

        private short _companiaCodigo;

        /// <summary>
        /// Sets and gets the CompaniaCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short CompaniaCodigo
        {
            get
            {
                return _companiaCodigo;
            }

            set
            {
                if (_companiaCodigo == value)
                {
                    return;
                }

                _companiaCodigo = value;
                RaisePropertyChanged(CompaniaCodigoPropertyName);
            }
        }

        #endregion

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private int _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Codigo
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

        #region Nombres

        /// <summary>
        /// The <see cref="Nombres" /> property's name.
        /// </summary>
        public const string NombresPropertyName = "Nombres";

        private string _nombres;

        /// <summary>
        /// Sets and gets the Nombres property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nombres
        {
            get
            {
                return _nombres;
            }

            set
            {
                if (_nombres == value)
                {
                    return;
                }

                _nombres = value;
                RaisePropertyChanged(NombresPropertyName);
            }
        }

        #endregion

        #region Apellidos

        /// <summary>
        /// The <see cref="Apellidos" /> property's name.
        /// </summary>
        public const string ApellidosPropertyName = "Apellidos";

        private string _apellidos;

        /// <summary>
        /// Sets and gets the Apellidos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Apellidos
        {
            get
            {
                return _apellidos;
            }

            set
            {
                if (_apellidos == value)
                {
                    return;
                }

                _apellidos = value;
                RaisePropertyChanged(ApellidosPropertyName);
            }
        }

        #endregion

        #region Alias

        /// <summary>
        /// The <see cref="Alias" /> property's name.
        /// </summary>
        public const string AliasPropertyName = "Alias";

        private string _alias;

        /// <summary>
        /// Sets and gets the Alias property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Alias
        {
            get
            {
                return _alias;
            }

            set
            {
                if (_alias == value)
                {
                    return;
                }

                _alias = value;
                RaisePropertyChanged(AliasPropertyName);
            }
        }

        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private string _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Estado
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

        public static async Task<Empleado> Get(short companiaCodigo, int empleadoCodigo)
        {
            try
            {
                using(_client = new EmpleadoClient())
                {
                    var model = await _client.GetAsync(companiaCodigo, empleadoCodigo);
                    return new Empleado
                    {
                        CompaniaCodigo = model.CompaniaCodigo,
                        Codigo = model.Codigo,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        Alias = model.Alias,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Empleado / Get", exception);
            }
        }

        public static async Task<List<Empleado>> GetAllActivos()
        {
            try
            {
                using (_client = new EmpleadoClient())
                {
                    var lista = await _client.GetAllActivosAsync();

                    return lista.Select(model => new Empleado
                    {
                        CompaniaCodigo = model.CompaniaCodigo,
                        Codigo = model.Codigo,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        Alias = model.Alias,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Empleado / Get", exception);
            }
        }

        public static List<Empleado> GetAll()
        {
            try
            {
                using (_client = new EmpleadoClient())
                {
                    var lista = _client.GetAllActivos();

                    return lista.Select(model => new Empleado
                    {
                        CompaniaCodigo = model.CompaniaCodigo,
                        Codigo = model.Codigo,
                        Nombres = model.Nombres,
                        Apellidos = model.Apellidos,
                        Alias = model.Alias,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Empleado / Get", exception);
            }
        }
        
        #endregion
    }
}