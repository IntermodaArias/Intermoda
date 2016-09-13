using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class Jornada : ObservableObject
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

        #endregion

        #region Methods

        public static async Task<Jornada> Update(Jornada reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var business = new JornadaBusiness
                    {
                        Id = reg.Id,
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre
                    };

                    var model = await _client.JornadaUpdateAsync(business);

                    return new Jornada
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Jornada / Update", exception);
            }
        }

        public static async Task Delete(int jornadaId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.JornadaDeleteAsync(jornadaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Jornada / Delete", exception);
            }
        }

        public static async Task<Jornada> Get(int jornadaId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var model = await _client.JornadaGetAsync(jornadaId);

                    return new Jornada
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Jornada / Get", exception);
            }
        }

        public static async Task<List<Jornada>> GetAll()
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.JornadaGetAllAsync();

                    return lista.Select(model => new Jornada
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Jornada / GetAll", exception);
            }
        }

        #endregion
    }
}