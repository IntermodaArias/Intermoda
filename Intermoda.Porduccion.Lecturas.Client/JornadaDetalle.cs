using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class JornadaDetalle : ObservableObject
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

        #region JornadaId

        /// <summary>
        /// The <see cref="JornadaId" /> property's name.
        /// </summary>
        public const string JornadaIdPropertyName = "JornadaId";

        private int _jornadaId;

        /// <summary>
        /// Sets and gets the JornadaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int JornadaId
        {
            get
            {
                return _jornadaId;
            }

            set
            {
                if (_jornadaId == value)
                {
                    return;
                }

                _jornadaId = value;
                RaisePropertyChanged(JornadaIdPropertyName);
            }
        }

        #endregion

        #region EntradaHora

        /// <summary>
        /// The <see cref="EntradaHora" /> property's name.
        /// </summary>
        public const string EntradaHoraPropertyName = "EntradaHora";

        private int _entradaHora;

        /// <summary>
        /// Sets and gets the EntradaHora property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EntradaHora
        {
            get
            {
                return _entradaHora;
            }

            set
            {
                if (_entradaHora == value)
                {
                    return;
                }

                _entradaHora = value;
                RaisePropertyChanged(EntradaHoraPropertyName);
            }
        }

        #endregion

        #region EntradaMinuto

        /// <summary>
        /// The <see cref="EntradaMinuto" /> property's name.
        /// </summary>
        public const string EntradaMinutoPropertyName = "EntradaMinuto";

        private int _entradaMinuto;

        /// <summary>
        /// Sets and gets the EntradaMinuto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EntradaMinuto
        {
            get
            {
                return _entradaMinuto;
            }

            set
            {
                if (_entradaMinuto == value)
                {
                    return;
                }

                _entradaMinuto = value;
                RaisePropertyChanged(EntradaMinutoPropertyName);
            }
        }

        #endregion

        #region SalidaHora

        /// <summary>
        /// The <see cref="SalidaHora" /> property's name.
        /// </summary>
        public const string SalidaHoraPropertyName = "SalidaHora";

        private int _salidaHora;

        /// <summary>
        /// Sets and gets the SalidaHora property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SalidaHora
        {
            get
            {
                return _salidaHora;
            }

            set
            {
                if (_salidaHora == value)
                {
                    return;
                }

                _salidaHora = value;
                RaisePropertyChanged(SalidaHoraPropertyName);
            }
        }

        #endregion

        #region SalidaMinuto

        /// <summary>
        /// The <see cref="SalidaMinuto" /> property's name.
        /// </summary>
        public const string SalidaMinutoPropertyName = "SalidaMinuto";

        private int _salidaMinuto;

        /// <summary>
        /// Sets and gets the SalidaMinuto property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SalidaMinuto
        {
            get
            {
                return _salidaMinuto;
            }

            set
            {
                if (_salidaMinuto == value)
                {
                    return;
                }

                _salidaMinuto = value;
                RaisePropertyChanged(SalidaMinutoPropertyName);
            }
        }

        #endregion

        #region Horas

        /// <summary>
        /// The <see cref="Horas" /> property's name.
        /// </summary>
        public const string HorasPropertyName = "Horas";

        private int _horas;

        /// <summary>
        /// Sets and gets the Horas property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Horas
        {
            get
            {
                return _horas;
            }

            set
            {
                if (_horas == value)
                {
                    return;
                }

                _horas = value;
                RaisePropertyChanged(HorasPropertyName);
            }
        }

        #endregion

        #region Minutos

        /// <summary>
        /// The <see cref="Minutos" /> property's name.
        /// </summary>
        public const string MinutosPropertyName = "Minutos";

        private int _minutos;

        /// <summary>
        /// Sets and gets the Minutos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Minutos
        {
            get
            {
                return _minutos;
            }

            set
            {
                if (_minutos == value)
                {
                    return;
                }

                _minutos = value;
                RaisePropertyChanged(MinutosPropertyName);
            }
        }

        #endregion

        public string Entrada { get; set; }
        public string Salida { get; set; }
        public string Tiempo { get; set; }

        #endregion

        #region Methods

        public static async Task<JornadaDetalle> Update(JornadaDetalle reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var business = new JornadaDetalleBusiness
                    {
                        Id = reg.Id,
                        JornadaId = reg.JornadaId,
                        EntradaHora = reg.EntradaHora,
                        EntradaMinuto = reg.EntradaMinuto,
                        SalidaHora = reg.SalidaHora,
                        SalidaMinuto = reg.SalidaMinuto
                    };

                    var model = await _client.JornadaDetalleUpdateAsync(business);

                    return new JornadaDetalle
                    {
                        Id = model.Id,
                        JornadaId = model.JornadaId,
                        EntradaHora = model.EntradaHora,
                        EntradaMinuto = model.EntradaMinuto,
                        SalidaHora = model.SalidaHora,
                        SalidaMinuto = model.SalidaMinuto
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalle / Update", exception);
            }
        }

        public static async Task Delete(int jornadaDetalleId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.JornadaDetalleDeleteAsync(jornadaDetalleId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalle / Delete", exception);
            }
        }

        public static async Task<JornadaDetalle> Get(int jornadaDetalleId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var model = await _client.JornadaDetalleGetAsync(jornadaDetalleId);

                    var entrada = $"{model.EntradaHora.ToString("00")}:{model.EntradaMinuto.ToString("00")}";
                    var salida = $"{model.SalidaHora.ToString("00")}:{model.SalidaMinuto.ToString("00")}";
                    var tiempo = $"{model.Horas.ToString("00")}:{model.Minutos.ToString("00")}";

                    return new JornadaDetalle
                    {
                        Id = model.Id,
                        JornadaId = model.JornadaId,
                        EntradaHora = model.EntradaHora,
                        EntradaMinuto = model.EntradaMinuto,
                        SalidaHora = model.SalidaHora,
                        SalidaMinuto = model.SalidaMinuto,
                        Horas = model.Horas,
                        Minutos = model.Minutos,
                        Entrada = entrada,
                        Salida = salida,
                        Tiempo = tiempo
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalle / Get", exception);
            }
        }

        public static async Task<List<JornadaDetalle>> GetByJornada(int jornadaId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.JornadaDetalleGetByJornadaAsync(jornadaId);

                    var retorno = new List<JornadaDetalle>();
                    foreach (var model in lista)
                    {
                        var entrada = $"{model.EntradaHora.ToString("00")}:{model.EntradaMinuto.ToString("00")}";
                        var salida = $"{model.SalidaHora.ToString("00")}:{model.SalidaMinuto.ToString("00")}";
                        var tiempo = $"{model.Horas.ToString("00")}:{model.Minutos.ToString("00")}";

                        retorno.Add(new JornadaDetalle
                        {
                            Id = model.Id,
                            JornadaId = model.JornadaId,
                            EntradaHora = model.EntradaHora,
                            EntradaMinuto = model.EntradaMinuto,
                            SalidaHora = model.SalidaHora,
                            SalidaMinuto = model.SalidaMinuto,
                            Horas = model.Horas,
                            Minutos = model.Minutos,
                            Entrada = entrada,
                            Salida = salida,
                            Tiempo = tiempo
                        });
                    }
                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("JornadaDetalle / GetByJornada", exception);
            }
        }

        #endregion
    }
}