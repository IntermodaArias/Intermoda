using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Linq;
using Intermoda.ClientProxy.Lavanderia.MaquinaServiceReference;
using MaquinaTipo = Intermoda.Common.Enum.MaquinaTipo;

namespace Intermoda.Client.Lavanderia
{
    public class Maquina : ObservableObject
    {
        private static MaquinaClient _client;

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

        #region CapacidadId

        /// <summary>
        /// The <see cref="CapacidadId" /> property's name.
        /// </summary>
        public const string CapacidadIdPropertyName = "CapacidadId";

        private short _capacidadId;

        /// <summary>
        /// Sets and gets the CapacidadId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short CapacidadId
        {
            get
            {
                return _capacidadId;
            }

            set
            {
                if (_capacidadId == value)
                {
                    return;
                }

                _capacidadId = value;
                RaisePropertyChanged(CapacidadIdPropertyName);
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

        public MaquinaCapacidad Capacidad { get; set; }

        #endregion

        #region Methods

        public static async Task<Maquina> Update(Maquina maquina)
        {
            try
            {
                using (_client = new MaquinaClient())
                {
                    var reg = ClientToBusiness(maquina);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / Update", exception);
            }
        }

        public static async Task Delete(MaquinaTipo tipo, int maquinaId)
        {
            try
            {
                using (_client = new MaquinaClient())
                {
                    await _client.DeleteAsync((ClientProxy.Lavanderia.MaquinaServiceReference.MaquinaTipo)tipo, maquinaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / Delete", exception);
            }
        }

        public static async Task<Maquina> Get(MaquinaTipo tipo, int maquinaId)
        {
            try
            {
                using (_client = new MaquinaClient())
                {
                    var reg = await _client.GetAsync((ClientProxy.Lavanderia.MaquinaServiceReference.MaquinaTipo)tipo, maquinaId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / Get", exception);
            }
        }

        public static async Task<List<Maquina>> GetAll()
        {
            try
            {
                using (_client = new MaquinaClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / GetAll", exception);
            }
        }

        public static async Task<List<Maquina>> GetByTipo(MaquinaTipo tipo)
        {
            try
            {
                using (_client = new MaquinaClient())
                {
                    var lista =
                        await _client.GetByTipoAsync((ClientProxy.Lavanderia.MaquinaServiceReference.MaquinaTipo) tipo);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / GetAll", exception);
            }
        }

        public static async Task<List<Maquina>> GetByTipoCapacidad(MaquinaTipo tipo, int lavadoraCapacidadId)
        {
            try
            {
                using (_client = new MaquinaClient())
                {
                    var lista = await _client.GetByTipoCapacidadAsync(
                        (ClientProxy.Lavanderia.MaquinaServiceReference.MaquinaTipo) tipo, lavadoraCapacidadId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Maquina / GetByCapacidad", exception);
            }
        }

        private static Maquina BusinessToClient(MaquinaBusiness input)
        {
            return new Maquina
            {
                Tipo = (MaquinaTipo)input.Tipo,
                Id = input.Id,
                Nombre = input.Nombre,
                CapacidadId = input.CapacidadId,
                Marca = input.Marca,
                Modelo = input.Modelo,
                Estado = input.Estado,
                NumeroSerie = input.NumeroSerie,
                DireccionIp = input.DireccionIp,
                DireccionMac = input.DireccionMac,
                Capacidad = new MaquinaCapacidad
                {
                    Id = input.Capacidad.Id,
                    CapacidadMinimaKg = input.Capacidad.CapacidadMinimaKg,
                    CapacidadMaximaKg = input.Capacidad.CapacidadMaximaKg,
                    CapacidadCanastaLitro = input.Capacidad.CapacidadCanastaLitro
                }
            };
        }

        private static MaquinaBusiness ClientToBusiness(Maquina input)
        {
            return new MaquinaBusiness
            {
                Tipo = (ClientProxy.Lavanderia.MaquinaServiceReference.MaquinaTipo)input.Tipo,
                Id = input.Id,
                Nombre = input.Nombre,
                CapacidadId = input.CapacidadId,
                Marca = input.Marca,
                Modelo = input.Modelo,
                Estado = input.Estado,
                NumeroSerie = input.NumeroSerie,
                DireccionIp = input.DireccionIp,
                DireccionMac = input.DireccionMac,
                Capacidad = new MaquinaCapacidadBusiness
                {
                    Id = input.Capacidad.Id,
                    CapacidadMinimaKg = input.Capacidad.CapacidadMinimaKg,
                    CapacidadMaximaKg = input.Capacidad.CapacidadMaximaKg,
                    CapacidadCanastaLitro = input.Capacidad.CapacidadCanastaLitro
                }
            };
        }

        #endregion
    }
}