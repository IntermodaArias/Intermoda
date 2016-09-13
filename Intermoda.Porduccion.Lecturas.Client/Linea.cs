using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class Linea : ObservableObject
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

        #region GrupoId

        /// <summary>
        /// The <see cref="GrupoId" /> property's name.
        /// </summary>
        public const string GrupoIdPropertyName = "GrupoId";

        private int _grupoId;

        /// <summary>
        /// Sets and gets the GrupoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int GrupoId
        {
            get
            {
                return _grupoId;
            }

            set
            {
                if (_grupoId == value)
                {
                    return;
                }

                _grupoId = value;
                RaisePropertyChanged(GrupoIdPropertyName);
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

        private LineaTipo _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LineaTipo Tipo
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

        public static async Task<Linea> Update(Linea reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var business = new LineaBusiness
                    {
                        Id = reg.Id,
                        GrupoId = reg.GrupoId,
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        Secuencia = reg.Secuencia,
                        Estado = reg.Estado
                    };

                    var model = await _client.LineaUpdateAsync(business);

                    return new Linea
                    {
                        Id = model.Id,
                        GrupoId = model.GrupoId,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Linea / Update", exception);
            }
        }

        public static async Task Delete(int lineaId) {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.LineaDeleteAsync(lineaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Linea / Delete", exception);
            }
        }

        public static async Task<List<Linea>> GetByGrupo(int grupoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.LineaGetByGrupoAsync(grupoId);
                    return lista.Select(model => new Linea
                    {
                        Id = model.Id,
                        GrupoId = model.GrupoId,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Linea / GetByGrupo", exception);
            }
        }

        public static async Task<List<Linea>> GetByGrupoActivas(int grupoId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.LineaGetByGrupoActivasAsync(grupoId);
                    return lista.Select(model => new Linea
                    {
                        Id = model.Id,
                        GrupoId = model.GrupoId,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Linea / GetByGrupoActivas", exception);
            }
        }

        #endregion
    }
}