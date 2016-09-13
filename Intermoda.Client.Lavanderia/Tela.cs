using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.TelaServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Tela : ObservableObject
    {
        private static TelaClient _client; 

        #region Properties

        #region TelaCodigo

        /// <summary>
        /// The <see cref="TelaCodigo" /> property's name.
        /// </summary>
        public const string TelaCodigoPropertyName = "TelaCodigo";

        private string _telaCodigo;

        /// <summary>
        /// Sets and gets the TelaCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaCodigo
        {
            get
            {
                return _telaCodigo;
            }

            set
            {
                if (_telaCodigo == value)
                {
                    return;
                }

                _telaCodigo = value;
                RaisePropertyChanged(TelaCodigoPropertyName);
            }
        }

        #endregion

        #region TelaNombre

        /// <summary>
        /// The <see cref="TelaNombre" /> property's name.
        /// </summary>
        public const string TelaNombrePropertyName = "TelaNombre";

        private string _telaNombre;

        /// <summary>
        /// Sets and gets the TelaNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaNombre
        {
            get
            {
                return _telaNombre;
            }

            set
            {
                if (_telaNombre == value)
                {
                    return;
                }

                _telaNombre = value;
                RaisePropertyChanged(TelaNombrePropertyName);
            }
        }

        #endregion

        #region ComposicionNombre

        /// <summary>
        /// The <see cref="ComposicionNombre" /> property's name.
        /// </summary>
        public const string ComposicionNombrePropertyName = "ComposicionNombre";

        private string _composicionNombre;

        /// <summary>
        /// Sets and gets the ComposicionNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ComposicionNombre
        {
            get
            {
                return _composicionNombre;
            }

            set
            {
                if (_composicionNombre == value)
                {
                    return;
                }

                _composicionNombre = value;
                RaisePropertyChanged(ComposicionNombrePropertyName);
            }
        }

        #endregion

        #region MaterialCodigo

        /// <summary>
        /// The <see cref="MaterialCodigo" /> property's name.
        /// </summary>
        public const string MaterialCodigoPropertyName = "MaterialCodigo";

        private int _materialCodigo;

        /// <summary>
        /// Sets and gets the MaterialCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MaterialCodigo
        {
            get
            {
                return _materialCodigo;
            }

            set
            {
                if (_materialCodigo == value)
                {
                    return;
                }

                _materialCodigo = value;
                RaisePropertyChanged(MaterialCodigoPropertyName);
            }
        }

        #endregion

        #region TelaDescripcion

        /// <summary>
        /// The <see cref="TelaDescripcion" /> property's name.
        /// </summary>
        public const string TelaDescripcionPropertyName = "TelaDescripcion";

        private string _telaDescripcion;

        /// <summary>
        /// Sets and gets the TelaDescripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaDescripcion
        {
            get
            {
                return _telaDescripcion;
            }

            set
            {
                if (_telaDescripcion == value)
                {
                    return;
                }

                _telaDescripcion = value;
                RaisePropertyChanged(TelaDescripcionPropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<Tela> Get(string telaCodigo)
        {
            try
            {
                using (_client = new TelaClient())
                {
                    var reg = await _client.GetAsync(telaCodigo);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / Get", exception);
            }
        }

        public static async Task<List<Tela>> GetAll()
        {
            try
            {
                using (_client = new TelaClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetAll", exception);
            }
        }

        public static async Task<List<Tela>> GetCombo()
        {
            try
            {
                using (_client = new TelaClient())
                {
                    var lista = await _client.GetComboAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetAll", exception);
            }
        }

        public static async Task<string> GetComposicionCodigo(string telaCodigo)
        {
            try
            {
                using (_client = new TelaClient())
                {
                    return await _client.GetComposicionCodigoAsync(telaCodigo);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Tela / GetComposicionCodigo", exception);
            }
        }

        private static Tela BusinessToClient(TelaBusiness business)
        {
            return new Tela
            {
                TelaCodigo = business.TelaCodigo,
                TelaNombre = business.TelaNombre,
                ComposicionNombre = business.ComposicionNombre,
                MaterialCodigo = business.MaterialCodigo,
                TelaDescripcion = business.TelaDescripcion
            };
        }

        private static TelaBusiness ClientToBusiness(Tela client)
        {
            return new TelaBusiness
            {
                TelaCodigo = client.TelaCodigo,
                TelaNombre = client.TelaNombre,
                ComposicionNombre = client.ComposicionNombre,
                MaterialCodigo = client.MaterialCodigo,
                TelaDescripcion = client.TelaDescripcion
            };
        }

        #endregion
    }
}