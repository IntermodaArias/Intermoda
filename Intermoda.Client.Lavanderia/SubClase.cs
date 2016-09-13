using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.SubClaseServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class SubClase : ObservableObject
    {
        private static SubClaseClient _client;

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

        public static async Task<SubClase> Update(SubClase subClase)
        {
            try
            {
                using (_client = new SubClaseClient())
                {
                    var reg = new SubClaseBusiness
                    {
                        CompaniaCodigo = subClase.CompaniaCodigo,
                        Codigo = subClase.Codigo,
                        Descripcion = subClase.Descripcion,
                        Estado = subClase.Estado
                    };

                    reg = await _client.UpdateAsync(reg);

                    return new SubClase
                    {
                        CompaniaCodigo = reg.CompaniaCodigo,
                        Codigo = reg.Codigo,
                        Descripcion = reg.Descripcion,
                        Estado = reg.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClase / Update", exception);
            }
        }

        public static async Task Delete(string subClaseCodigo)
        {
            try
            {
                using (_client = new SubClaseClient())
                {
                    await _client.DeleteAsync(subClaseCodigo);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClase / Delete", exception);
            }
        }

        public static async Task<SubClase> Get(string subClaseCodigo)
        {
            try
            {
                using (_client = new SubClaseClient())
                {
                    var reg = await _client.GetAsync(subClaseCodigo);

                    return new SubClase
                    {
                        CompaniaCodigo = reg.CompaniaCodigo,
                        Codigo = reg.Codigo,
                        Descripcion = reg.Descripcion,
                        Estado = reg.Estado
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClase / Get", exception);
            }
        }

        public static async Task<List<SubClase>> GetAll()
        {
            try
            {
                using (_client = new SubClaseClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(reg => new SubClase
                    {
                        CompaniaCodigo = reg.CompaniaCodigo,
                        Codigo = reg.Codigo,
                        Descripcion = reg.Descripcion,
                        Estado = reg.Estado
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SubClase / GetAll", exception);
            }
        }

        #endregion
    }
}