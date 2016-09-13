using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lectura.ModuloServiceReference;

namespace Intermoda.Client.Lectura
{
    public class Modulo : ObservableObject
    {
        private static ModuloClient _client;

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

        #endregion

        #region Methods

        public static async Task<Modulo> Update(Modulo reg)
        {
            try
            {
                using (_client = new ModuloClient())
                {
                    var business = new ModuloBusiness
                    {
                        Id = reg.Id,
                        Codigo = reg.Codigo,
                        Nombre = reg.Nombre,
                        Secuencia = reg.Secuencia,
                        Estado = reg.Estado,
                        CentroTrabajoId = reg.CentroTrabajoId
                    };
                    var model = await _client.UpdateAsync(business);
                    return new Modulo
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado,
                        CentroTrabajoId = model.CentroTrabajoId
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo / Update", exception);
            }
        }

        public static async Task Delete(int moduloId)
        {
            try
            {
                using (_client = new ModuloClient())
                {
                    await _client.DeleteAsync(moduloId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo / Delete", exception);
            }
        }

        public static async Task<List<Modulo>> GetByCentroTrabajo(int centroTrabajoId)
        {
            try
            {
                using (_client = new ModuloClient())
                {
                    var lista = await _client.GetByCentroTrabajoActivosAsync(centroTrabajoId);
                    return lista.Select(model => new Modulo
                    {
                        Id = model.Id,
                        Codigo = model.Codigo,
                        Nombre = model.Nombre,
                        Secuencia = model.Secuencia,
                        Estado = model.Estado,
                        CentroTrabajoId = model.CentroTrabajoId
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Modulo / Update", exception);
            }
        }

        #endregion
    }
}