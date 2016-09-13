using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lectura.TurnoDetalleServiceReference;

namespace Intermoda.Client.Lectura
{
    public class TurnoDetalle : ObservableObject
    {
        private static TurnoDetalleClient _client;

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

        #region TurnoId

        /// <summary>
        /// The <see cref="TurnoId" /> property's name.
        /// </summary>
        public const string TurnoIdPropertyName = "TurnoId";

        private int _turnoId;

        /// <summary>
        /// Sets and gets the TurnoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int TurnoId
        {
            get
            {
                return _turnoId;
            }

            set
            {
                if (_turnoId == value)
                {
                    return;
                }

                _turnoId = value;
                RaisePropertyChanged(TurnoIdPropertyName);
            }
        }

        #endregion

        #region Dia

        /// <summary>
        /// The <see cref="Dia" /> property's name.
        /// </summary>
        public const string DiaPropertyName = "Dia";

        private DiaSemana _dia;

        /// <summary>
        /// Sets and gets the Dia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DiaSemana Dia
        {
            get
            {
                return _dia;
            }

            set
            {
                if (_dia == value)
                {
                    return;
                }

                _dia = value;
                RaisePropertyChanged(DiaPropertyName);
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

        public Jornada Jornada { get; set; }

        #endregion

        #region Methods

        public static async Task<TurnoDetalle> Update(TurnoDetalle reg)
        {
            try
            {
                using (_client = new TurnoDetalleClient())
                {
                    var business = new TurnoDetalleBusiness
                    {
                        Id = reg.Id,
                        TurnoId = reg.TurnoId,
                        Dia = reg.Dia,
                        JornadaId = reg.JornadaId,
                        Horas = reg.Horas,
                        Minutos = reg.Minutos
                    };

                    var model = await _client.UpdateAsync(business);

                    return new TurnoDetalle
                    {
                        Id = model.Id,
                        TurnoId = model.TurnoId,
                        Dia = model.Dia,
                        JornadaId = model.JornadaId,
                        Horas = model.Horas,
                        Minutos = model.Minutos,
                        Jornada = new Jornada
                        {
                            Id = model.Jornada.Id,
                            Codigo = model.Jornada.Codigo,
                            Nombre = model.Jornada.Nombre
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalle / Update", exception);
            }
        }

        public static async Task Delete(int turnoDetalleId)
        {
            try
            {
                using (_client = new TurnoDetalleClient())
                {
                    await _client.DeleteAsync(turnoDetalleId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalle / Delete", exception);
            }
        }

        public static async Task<TurnoDetalle> Get(int turnoDetalleId)
        {
            try
            {
                using (_client = new TurnoDetalleClient())
                {
                    var model = await _client.GetAsync(turnoDetalleId);

                    return new TurnoDetalle
                    {
                        Id = model.Id,
                        TurnoId = model.TurnoId,
                        Dia = model.Dia,
                        JornadaId = model.JornadaId,
                        Horas = model.Horas,
                        Minutos = model.Minutos,
                        Jornada = new Jornada
                        {
                            Id = model.Jornada.Id,
                            Codigo = model.Jornada.Codigo,
                            Nombre = model.Jornada.Nombre
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalle / Get", exception);
            }
        }

        public static async Task<List<TurnoDetalle>> GetByTurno(int turnoId)
        {
            try
            {
                using (_client = new TurnoDetalleClient())
                {
                    var lista = await _client.GetByTurnoAsync(turnoId);

                    return lista.Select(model => new TurnoDetalle
                    {
                        Id = model.Id,
                        TurnoId = model.TurnoId,
                        Dia = model.Dia,
                        JornadaId = model.JornadaId,
                        Horas = model.Horas,
                        Minutos = model.Minutos,
                        Jornada = new Jornada
                        {
                            Id = model.Jornada.Id,
                            Codigo = model.Jornada.Codigo,
                            Nombre = model.Jornada.Nombre
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TurnoDetalle / GetByTurno", exception);
            }
        }

        #endregion
    }
}