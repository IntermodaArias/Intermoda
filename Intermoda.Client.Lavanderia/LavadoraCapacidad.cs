using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.LavadoraCapacidadServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class LavadoraCapacidad : ObservableObject
    {
         private static LavadoraCapacidadClient _client;

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

        private decimal? _capacidadMinimaKg;

        /// <summary>
        /// Sets and gets the CapacidadMinimaKg property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? CapacidadMinimaKg
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

        #region CapacidadCanastaLitro

        /// <summary>
        /// The <see cref="CapacidadCanastaLitro" /> property's name.
        /// </summary>
        public const string CapacidadCanastaLitroPropertyName = "CapacidadCanastaLitro";

        private decimal? _capacidadCanastaLitro;

        /// <summary>
        /// Sets and gets the CapacidadCanastaLitro property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? CapacidadCanastaLitro
        {
            get
            {
                return _capacidadCanastaLitro;
            }

            set
            {
                if (_capacidadCanastaLitro == value)
                {
                    return;
                }

                _capacidadCanastaLitro = value;
                RaisePropertyChanged(CapacidadCanastaLitroPropertyName);
            }
        }

        #endregion

        public string Capacidad => $"De {CapacidadMinimaKg} a {CapacidadMaximaKg} Kg";

        #endregion

        #region Methods

        public static async Task<LavadoraCapacidad> Update(LavadoraCapacidad lavadoraCapacidad)
        {
            try
            {
                using (_client = new LavadoraCapacidadClient())
                {
                    var reg = ClientToBusiness(lavadoraCapacidad);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidad / Update", exception);
            }
        }

        public static async Task Delete(short lavadoraCapacidadId)
        {
            try
            {
                using (_client = new LavadoraCapacidadClient())
                {
                    await _client.DeleteAsync(lavadoraCapacidadId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidad / Delete", exception);
            }
        }

        public static async Task<LavadoraCapacidad> Get(int lavadoraCapacidadId)
        {
            try
            {
                using (_client = new LavadoraCapacidadClient())
                {
                    var reg = await _client.GetAsync(lavadoraCapacidadId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidad / Get", exception);
            }
        }

        public static async Task<List<LavadoraCapacidad>> GetAll()
        {
            try
            {
                using (_client = new LavadoraCapacidadClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LavadoraCapacidad / GetAll", exception);
            }
        }

        private static LavadoraCapacidad BusinessToClient(LavadoraCapacidadBusiness input)
        {
            return new LavadoraCapacidad
            {
                Id = input.Id,
                CapacidadMinimaKg = input.CapacidadMinimaKg,
                CapacidadMaximaKg = input.CapacidadMaximaKg,
                CapacidadCanastaLitro = input.CapacidadCanastaLitro
            };
        }

        private static LavadoraCapacidadBusiness ClientToBusiness(LavadoraCapacidad input)
        {
            return new LavadoraCapacidadBusiness
            {
                Id = input.Id,
                CapacidadMinimaKg = input.CapacidadMinimaKg,
                CapacidadMaximaKg = input.CapacidadMaximaKg,
                CapacidadCanastaLitro = input.CapacidadCanastaLitro
            };
        }

        #endregion
    }
}