using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.LavadoraServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Lavadora : ObservableObject
    {
        private static LavadoraClient _client;

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

        #region LavadoraCapacidadId

        /// <summary>
        /// The <see cref="LavadoraCapacidadId" /> property's name.
        /// </summary>
        public const string LavadoraCapacidadIdPropertyName = "LavadoraCapacidadId";

        private short _lavadoraCapacidadId;

        /// <summary>
        /// Sets and gets the LavadoraCapacidadId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short LavadoraCapacidadId
        {
            get
            {
                return _lavadoraCapacidadId;
            }

            set
            {
                if (_lavadoraCapacidadId == value)
                {
                    return;
                }

                _lavadoraCapacidadId = value;
                RaisePropertyChanged(LavadoraCapacidadIdPropertyName);
            }
        }

        #endregion

        #region Marca

        /// <summary>
        /// The <see cref="Marca" /> property's name.
        /// </summary>
        public const string MarcaPropertyName = "Marca";

        private string _marca;

        /// <summary>
        /// Sets and gets the Marca property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Marca
        {
            get
            {
                return _marca;
            }

            set
            {
                if (_marca == value)
                {
                    return;
                }

                _marca = value;
                RaisePropertyChanged(MarcaPropertyName);
            }
        }

        #endregion

        #region Modelo

        /// <summary>
        /// The <see cref="Modelo" /> property's name.
        /// </summary>
        public const string ModeloPropertyName = "Modelo";

        private string _modelo;

        /// <summary>
        /// Sets and gets the Modelo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Modelo
        {
            get
            {
                return _modelo;
            }

            set
            {
                if (_modelo == value)
                {
                    return;
                }

                _modelo = value;
                RaisePropertyChanged(ModeloPropertyName);
            }
        }

        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private short _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Estado
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

        #region NumeroSerie

        /// <summary>
        /// The <see cref="NumeroSerie" /> property's name.
        /// </summary>
        public const string NumeroSeriePropertyName = "NumeroSerie";

        private string _numeroSerie;

        /// <summary>
        /// Sets and gets the NumeroSerie property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string NumeroSerie
        {
            get
            {
                return _numeroSerie;
            }

            set
            {
                if (_numeroSerie == value)
                {
                    return;
                }

                _numeroSerie = value;
                RaisePropertyChanged(NumeroSeriePropertyName);
            }
        }

        #endregion

        #region DireccionIp

        /// <summary>
        /// The <see cref="DireccionIp" /> property's name.
        /// </summary>
        public const string DireccionIpPropertyName = "DireccionIp";

        private string _direccionIp;

        /// <summary>
        /// Sets and gets the DireccionIp property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DireccionIp
        {
            get
            {
                return _direccionIp;
            }

            set
            {
                if (_direccionIp == value)
                {
                    return;
                }

                _direccionIp = value;
                RaisePropertyChanged(DireccionIpPropertyName);
            }
        }

        #endregion

        #region DireccionMac

        /// <summary>
        /// The <see cref="DireccionMac" /> property's name.
        /// </summary>
        public const string DireccionMacPropertyName = "DireccionMac";

        private string _direccionMac;

        /// <summary>
        /// Sets and gets the DireccionMac property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DireccionMac
        {
            get
            {
                return _direccionMac;
            }

            set
            {
                if (_direccionMac == value)
                {
                    return;
                }

                _direccionMac = value;
                RaisePropertyChanged(DireccionMacPropertyName);
            }
        }

        #endregion

        public LavadoraCapacidad LavadoraCapacidad { get; set; }

        #endregion

        #region Methods

        public static async Task<Lavadora> Update(Lavadora lavadora)
        {
            try
            {
                using (_client = new LavadoraClient())
                {
                    var reg = ClientToBusiness(lavadora);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavadora / Update", exception);
            }
        }

        public static async Task Delete(int lavadoraId)
        {
            try
            {
                using (_client = new LavadoraClient())
                {
                    await _client.DeleteAsync(lavadoraId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavadora / Delete", exception);
            }
        }

        public static async Task<Lavadora> Get(int lavadoraId)
        {
            try
            {
                using (_client = new LavadoraClient())
                {
                    var reg = await _client.GetAsync(lavadoraId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavadora / Get", exception);
            }
        }

        public static async Task<List<Lavadora>> GetAll()
        {
            try
            {
                using (_client = new LavadoraClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavadora / GetAll", exception);
            }
        }

        public static async Task<List<Lavadora>> GetByCapacidad(int lavadoraCapacidadId)
        {
            try
            {
                using (_client = new LavadoraClient())
                {
                    var lista = await _client.GetByCapacidadAsync(lavadoraCapacidadId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Lavadora / GetByCapacidad", exception);
            }
        }

        private static Lavadora BusinessToClient(LavadoraBusiness input)
        {
            return new Lavadora
            {
                Id = input.Id,
                Nombre = input.Nombre,
                LavadoraCapacidadId = input.LavadoraCapacidadId,
                Marca = input.Marca,
                Modelo = input.Modelo,
                Estado = input.Estado,
                NumeroSerie = input.NumeroSerie,
                DireccionIp = input.DireccionIp,
                DireccionMac = input.DireccionMac,
                LavadoraCapacidad = new LavadoraCapacidad
                {
                    Id = input.LavadoraCapacidad.Id,
                    CapacidadMinimaKg = input.LavadoraCapacidad.CapacidadMinimaKg,
                    CapacidadMaximaKg = input.LavadoraCapacidad.CapacidadMaximaKg,
                    CapacidadCanastaLitro = input.LavadoraCapacidad.CapacidadCanastaLitro
                }
            };
        }

        private static LavadoraBusiness ClientToBusiness(Lavadora input)
        {
            return new LavadoraBusiness
            {
                Id = input.Id,
                Nombre = input.Nombre,
                LavadoraCapacidadId = input.LavadoraCapacidadId,
                Marca = input.Marca,
                Modelo = input.Modelo,
                Estado = input.Estado,
                NumeroSerie = input.NumeroSerie,
                DireccionIp = input.DireccionIp,
                DireccionMac = input.DireccionMac,
                LavadoraCapacidad = new LavadoraCapacidadBusiness
                {
                    Id = input.LavadoraCapacidad.Id,
                    CapacidadMinimaKg = input.LavadoraCapacidad.CapacidadMinimaKg,
                    CapacidadMaximaKg = input.LavadoraCapacidad.CapacidadMaximaKg,
                    CapacidadCanastaLitro = input.LavadoraCapacidad.CapacidadCanastaLitro
                }
            };
        }

        #endregion
    }
}