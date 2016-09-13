//using Intermoda.Produccion.Lavanderia;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ColorIntermodaServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class ColorIntermoda : ObservableObject
    {
        private static ColorIntermodaClient _client;

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

        public static async Task<ColorIntermoda> Update(ColorIntermoda colorIntermoda)
        {
            try
            {
                using (_client = new ColorIntermodaClient())
                {
                    var reg = ClientToBusiness(colorIntermoda);

                    reg = await _client.UpdateAsync(reg);

                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / Update", exception);
            }
        }

        public static async Task Delete(int colorIntermodaId)
        {
            try
            {
                using (_client = new ColorIntermodaClient())
                {
                    await _client.DeleteAsync(colorIntermodaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / Delete", exception);
            }
        }

        public static async Task<ColorIntermoda> Get(int colorIntermodaId)
        {
            try
            {
                using (_client = new ColorIntermodaClient())
                {
                    var reg = await _client.GetAsync(colorIntermodaId);

                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / Get", exception);
            }
        }

        public static async Task<List<ColorIntermoda>> GetAll()
        {
            try
            {
                using (_client = new ColorIntermodaClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / GetAll", exception);
            }
        }

        private static ColorIntermoda BusinessToClient(ColorIntermodaBusiness business)
        {
            return new ColorIntermoda
            {
                Id = business.Id,
                Nombre = business.Nombre
            };
        }

        private static ColorIntermodaBusiness ClientToBusiness(ColorIntermoda client)
        {
            return new ColorIntermodaBusiness
            {
                Id = client.Id,
                Nombre = client.Nombre
            };
        }

        #endregion
    }
}