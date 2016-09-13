using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.MaquinaCapacidadServiceReference;
using MaquinaTipo = Intermoda.Common.Enum.MaquinaTipo;

namespace Intermoda.Client.Lavanderia
{
    public class MaquinaCapacidad : ObservableObject
    {
        private static MaquinaCapacidadClient _client;

        #region Properties

        #region Tipo

        /// <summary>
        /// The <see cref="Tipo" /> property's name.
        /// </summary>
        public const string TipoPropertyName = "Tipo";

        private MaquinaTipo _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public MaquinaTipo Tipo
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

        public static async Task<MaquinaCapacidad> Update(MaquinaCapacidad maquinaCapacidad)
        {
            try
            {
                using (_client = new MaquinaCapacidadClient())
                {
                    var reg = ClientToBusiness(maquinaCapacidad);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("maquinaCapacidad / Update", exception);
            }
        }

        public static async Task Delete(MaquinaTipo tipo, int maquinaCapacidadId)
        {
            try
            {
                using (_client = new MaquinaCapacidadClient())
                {
                    await _client.DeleteAsync(
                        (ClientProxy.Lavanderia.MaquinaCapacidadServiceReference.MaquinaTipo) tipo, maquinaCapacidadId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("maquinaCapacidad / Delete", exception);
            }
        }

        public static async Task<MaquinaCapacidad> Get(MaquinaTipo tipo, int maquinaCapacidadId)
        {
            try
            {
                using (_client = new MaquinaCapacidadClient())
                {
                    var reg = await _client.GetAsync(
                        (ClientProxy.Lavanderia.MaquinaCapacidadServiceReference.MaquinaTipo) tipo,
                        maquinaCapacidadId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("maquinaCapacidad / Get", exception);
            }
        }

        public static async Task<List<MaquinaCapacidad>> GetAll()
        {
            try
            {
                using (_client = new MaquinaCapacidadClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("maquinaCapacidad / GetAll", exception);
            }
        }

        public static async Task<List<MaquinaCapacidad>> GetByTipo(MaquinaTipo tipo)
        {
            try
            {
                using (_client = new MaquinaCapacidadClient())
                {
                    var lista = await _client.GetByTipoAsync(
                        (ClientProxy.Lavanderia.MaquinaCapacidadServiceReference.MaquinaTipo) tipo);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("maquinaCapacidad / GetByTipo", exception);
            }
        }

        private static MaquinaCapacidad BusinessToClient(MaquinaCapacidadBusiness input)
        {
            return new MaquinaCapacidad
            {
                Tipo = (MaquinaTipo)input.Tipo,
                Id = input.Id,
                CapacidadMinimaKg = input.CapacidadMinimaKg,
                CapacidadMaximaKg = input.CapacidadMaximaKg,
                CapacidadCanastaLitro = input.CapacidadCanastaLitro
            };
        }

        private static MaquinaCapacidadBusiness ClientToBusiness(MaquinaCapacidad input)
        {
            return new MaquinaCapacidadBusiness
            {
                Tipo = (ClientProxy.Lavanderia.MaquinaCapacidadServiceReference.MaquinaTipo)input.Tipo,
                Id = input.Id,
                CapacidadMinimaKg = input.CapacidadMinimaKg,
                CapacidadMaximaKg = input.CapacidadMaximaKg,
                CapacidadCanastaLitro = input.CapacidadCanastaLitro
            };
        }

        #endregion
    }
}