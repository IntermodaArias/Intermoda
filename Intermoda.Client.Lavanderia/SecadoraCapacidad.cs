using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.SecadoraCapacidadServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class SecadoraCapacidad : ObservableObject
    {
        private static SecadoraCapacidadClient _client;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private short _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Id
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

        #region CapacidadMinimaKg

        /// <summary>
        /// The <see cref="CapacidadMinimaKg" /> property's name.
        /// </summary>
        public const string CapacidadMinimaKgPropertyName = "CapacidadMinimaKg";

        private decimal _capacidadMinimaKg;

        /// <summary>
        /// Sets and gets the CapacidadMinimaKg property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CapacidadMinimaKg
        {
            get
            {
                return _capacidadMinimaKg;
            }

            set
            {
                if (_capacidadMinimaKg == value)
                {
                    return;
                }

                _capacidadMinimaKg = value;
                RaisePropertyChanged(CapacidadMinimaKgPropertyName);
            }
        }

        #endregion

        #region CapacidadMaximaKg

        /// <summary>
        /// The <see cref="CapacidadMaximaKg" /> property's name.
        /// </summary>
        public const string CapacidadMaximaKgPropertyName = "CapacidadMaximaKg";

        private decimal _capacidadMaximaKg;

        /// <summary>
        /// Sets and gets the CapacidadMaximaKg property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CapacidadMaximaKg
        {
            get
            {
                return _capacidadMaximaKg;
            }

            set
            {
                if (_capacidadMaximaKg == value)
                {
                    return;
                }

                _capacidadMaximaKg = value;
                RaisePropertyChanged(CapacidadMaximaKgPropertyName);
            }
        }

        #endregion

        public string Capacidad => $"De {CapacidadMinimaKg} a {CapacidadMaximaKg} Kg";

        #endregion

        #region Methods

        public static async Task<SecadoraCapacidad> Update(SecadoraCapacidad secadoraCapacidad)
        {
            try
            {
                using (_client = new SecadoraCapacidadClient())
                {
                    var reg = ClientToBusiness(secadoraCapacidad);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidad / Update", exception);
            }
        }

        public static async Task Delete(int secadoraCapacidadId)
        {
            try
            {
                using (_client = new SecadoraCapacidadClient())
                {
                    await _client.DeleteAsync(secadoraCapacidadId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidad / Delete", exception);
            }
        }

        public static async Task<SecadoraCapacidad> Get(int secadoraCapacidadId)
        {
            try
            {
                using (_client = new SecadoraCapacidadClient())
                {
                    var reg = await _client.GetAsync(secadoraCapacidadId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidad / Get", exception);
            }
        }

        public static async Task<List<SecadoraCapacidad>> GetAll()
        {
            try
            {
                using (_client = new SecadoraCapacidadClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("SecadoraCapacidad / GetAll", exception);
            }
        }

        private static SecadoraCapacidad BusinessToClient(SecadoraCapacidadBusiness input)
        {
            return new SecadoraCapacidad
            {
                Id = input.Id,
                CapacidadMinimaKg = input.CapacidadMinimaKg,
                CapacidadMaximaKg = input.CapacidadMaximaKg
            };
        }

        private static SecadoraCapacidadBusiness ClientToBusiness(SecadoraCapacidad input)
        {
            return new SecadoraCapacidadBusiness
            {
                Id = input.Id,
                CapacidadMinimaKg = input.CapacidadMinimaKg,
                CapacidadMaximaKg = input.CapacidadMaximaKg
            };
        }

        #endregion
    }
}