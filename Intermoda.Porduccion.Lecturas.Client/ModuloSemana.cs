using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class ModuloSemana:ObservableObject
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

        #region FechaInicio

        /// <summary>
        /// The <see cref="FechaInicio" /> property's name.
        /// </summary>
        public const string FechaInicioPropertyName = "FechaInicio";

        private DateTime _fechaInicio;

        /// <summary>
        /// Sets and gets the FechaInicio property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaInicio
        {
            get
            {
                return _fechaInicio;
            }

            set
            {
                if (_fechaInicio == value)
                {
                    return;
                }

                _fechaInicio = value;
                RaisePropertyChanged(FechaInicioPropertyName);
            }
        }

        #endregion

        #region FechaFinal

        /// <summary>
        /// The <see cref="FechaFinal" /> property's name.
        /// </summary>
        public const string FechaFinalPropertyName = "FechaFinal";

        private DateTime _fechaFinal;

        /// <summary>
        /// Sets and gets the FechaFinal property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime FechaFinal
        {
            get
            {
                return _fechaFinal;
            }

            set
            {
                if (_fechaFinal == value)
                {
                    return;
                }

                _fechaFinal = value;
                RaisePropertyChanged(FechaFinalPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private int _centroTrabajoId;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CentroTrabajoId
        {
            get
            {
                return _centroTrabajoId;
            }

            set
            {
                if (_centroTrabajoId == value)
                {
                    return;
                }

                _centroTrabajoId = value;
                RaisePropertyChanged(CentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region ModuloId

        /// <summary>
        /// The <see cref="ModuloId" /> property's name.
        /// </summary>
        public const string ModuloIdPropertyName = "ModuloId";

        private int _moduloId;

        /// <summary>
        /// Sets and gets the ModuloId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ModuloId
        {
            get
            {
                return _moduloId;
            }

            set
            {
                if (_moduloId == value)
                {
                    return;
                }

                _moduloId = value;
                RaisePropertyChanged(ModuloIdPropertyName);
            }
        }

        #endregion

        #region TransferenciaMinutos

        /// <summary>
        /// The <see cref="TransferenciaMinutos" /> property's name.
        /// </summary>
        public const string TransferenciaMinutosPropertyName = "TransferenciaMinutos";

        private int _transferenciaMinutos;

        /// <summary>
        /// Sets and gets the TransferenciaMinutos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int TransferenciaMinutos
        {
            get
            {
                return _transferenciaMinutos;
            }

            set
            {
                if (_transferenciaMinutos == value)
                {
                    return;
                }

                _transferenciaMinutos = value;
                RaisePropertyChanged(TransferenciaMinutosPropertyName);
            }
        }

        #endregion

        #region MetaPiezasPorHora

        /// <summary>
        /// The <see cref="MetaPiezasPorHora" /> property's name.
        /// </summary>
        public const string MetaPiezasPorHoraPropertyName = "MetaPiezasPorHora";

        private int _metaPiezasPorHora;

        /// <summary>
        /// Sets and gets the MetaPiezasPorHora property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MetaPiezasPorHora
        {
            get
            {
                return _metaPiezasPorHora;
            }

            set
            {
                if (_metaPiezasPorHora == value)
                {
                    return;
                }

                _metaPiezasPorHora = value;
                RaisePropertyChanged(MetaPiezasPorHoraPropertyName);
            }
        }

        #endregion

        #region MetaProduccion

        /// <summary>
        /// The <see cref="MetaProduccion" /> property's name.
        /// </summary>
        public const string MetaProduccionPropertyName = "MetaProduccion";

        private decimal _metaProduccion;

        /// <summary>
        /// Sets and gets the MetaProduccion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal MetaProduccion
        {
            get
            {
                return _metaProduccion;
            }

            set
            {
                if (_metaProduccion == value)
                {
                    return;
                }

                _metaProduccion = value;
                RaisePropertyChanged(MetaProduccionPropertyName);
            }
        }

        #endregion

        #region Curva

        /// <summary>
        /// The <see cref="Curva" /> property's name.
        /// </summary>
        public const string CurvaPropertyName = "Curva";

        private decimal _curva;

        /// <summary>
        /// Sets and gets the Curva property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal Curva
        {
            get
            {
                return _curva;
            }

            set
            {
                if (_curva == value)
                {
                    return;
                }

                _curva = value;
                RaisePropertyChanged(CurvaPropertyName);
            }
        }

        #endregion

        #region MinutosEntrenamiento

        /// <summary>
        /// The <see cref="MinutosEntrenamiento" /> property's name.
        /// </summary>
        public const string MinutosEntrenamientoPropertyName = "MinutosEntrenamiento";

        private int _minutosEntrenamiento;

        /// <summary>
        /// Sets and gets the MinutosEntrenamiento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MinutosEntrenamiento
        {
            get
            {
                return _minutosEntrenamiento;
            }

            set
            {
                if (_minutosEntrenamiento == value)
                {
                    return;
                }

                _minutosEntrenamiento = value;
                RaisePropertyChanged(MinutosEntrenamientoPropertyName);
            }
        }

        #endregion

        #region MinutosTitular

        /// <summary>
        /// The <see cref="MinutosTitular" /> property's name.
        /// </summary>
        public const string MinutosTitularPropertyName = "MinutosTitular";

        private int _minutosTitular;

        /// <summary>
        /// Sets and gets the MinutosTitular property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MinutosTitular
        {
            get
            {
                return _minutosTitular;
            }

            set
            {
                if (_minutosTitular == value)
                {
                    return;
                }

                _minutosTitular = value;
                RaisePropertyChanged(MinutosTitularPropertyName);
            }
        }

        #endregion

        #region MinutosUtilitario

        /// <summary>
        /// The <see cref="MinutosUtilitario" /> property's name.
        /// </summary>
        public const string MinutosUtilitarioPropertyName = "MinutosUtilitario";

        private int _minutosUtilitario;

        /// <summary>
        /// Sets and gets the MinutosUtilitario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MinutosUtilitario
        {
            get
            {
                return _minutosUtilitario;
            }

            set
            {
                if (_minutosUtilitario == value)
                {
                    return;
                }

                _minutosUtilitario = value;
                RaisePropertyChanged(MinutosUtilitarioPropertyName);
            }
        }

        #endregion

        #region MinutosBase

        /// <summary>
        /// The <see cref="MinutosBase" /> property's name.
        /// </summary>
        public const string MinutosBasePropertyName = "MinutosBase";

        private int _minutosBase;

        /// <summary>
        /// Sets and gets the MinutosBase property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MinutosBase
        {
            get
            {
                return _minutosBase;
            }

            set
            {
                if (_minutosBase == value)
                {
                    return;
                }

                _minutosBase = value;
                RaisePropertyChanged(MinutosBasePropertyName);
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

        public CentroTrabajo CentroTrabajo { get; set; }
        public Modulo Modulo { get; set; }
        public Turno Turno { get; set; }

        #endregion

        #region Methods

        public static async Task<ModuloSemana> Update(ModuloSemana reg)
        {
            try
            {
                var business = new ModuloSemanaBusiness
                {
                    Id = reg.Id,
                    FechaInicio = reg.FechaInicio,
                    FechaFinal = reg.FechaFinal,
                    CentroTrabajoId = reg.CentroTrabajoId,
                    ModuloId = reg.ModuloId,
                    TransferenciaMinutos = reg.TransferenciaMinutos,
                    MetaPiezasPorHora = reg.MetaPiezasPorHora,
                    MetaProduccion = reg.MetaProduccion,
                    Curva = reg.Curva,
                    MinutosEntrenamiento = reg.MinutosEntrenamiento,
                    MinutosTitular = reg.MinutosTitular,
                    MinutoUtilitario = reg.MinutosUtilitario,
                    MinutosBase = reg.MinutosBase,
                    TurnoId = reg.TurnoId
                };

                var model = await _client.ModuloSemanaUpdateAsync(business);

                return new ModuloSemana
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    CentroTrabajoId = model.CentroTrabajoId,
                    ModuloId = model.ModuloId,
                    TransferenciaMinutos = model.TransferenciaMinutos,
                    MetaPiezasPorHora = model.MetaPiezasPorHora,
                    MetaProduccion = model.MetaProduccion,
                    MinutosEntrenamiento = model.MinutosEntrenamiento,
                    MinutosTitular = model.MinutosTitular,
                    MinutosUtilitario = model.MinutoUtilitario,
                    MinutosBase = model.MinutosBase,
                    TurnoId = model.TurnoId,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = model.CentroTrabajo.Id,
                        Codigo = model.CentroTrabajo.Codigo,
                        Nombre = model.CentroTrabajo.Nombre,
                        Secuencia = model.CentroTrabajo.Secuencia
                    },
                    Modulo = new Modulo
                    {
                        Id = model.Modulo.Id,
                        Codigo = model.Modulo.Codigo,
                        Nombre = model.Modulo.Nombre,
                        Secuencia = model.Modulo.Secuencia
                    },
                    Turno = new Turno
                    {
                        Id = model.Turno.Id,
                        Codigo = model.Turno.Codigo,
                        Nombre = model.Turno.Nombre
                    }
                };
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana / Update", exception);
            }
        }

        public static async Task Delete(int moduloSemanaId)
        {
            try
            {
                await _client.ModuloSemanaDeleteAsync(moduloSemanaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana / Delete", exception);
            }
        }

        public static async Task<ModuloSemana> Get(int moduloSemanaId)
        {
            try
            {
                var model = await _client.ModuloSemanaGetAsync(moduloSemanaId);

                return new ModuloSemana
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    CentroTrabajoId = model.CentroTrabajoId,
                    ModuloId = model.ModuloId,
                    TransferenciaMinutos = model.TransferenciaMinutos,
                    MetaPiezasPorHora = model.MetaPiezasPorHora,
                    MetaProduccion = model.MetaProduccion,
                    MinutosEntrenamiento = model.MinutosEntrenamiento,
                    MinutosTitular = model.MinutosTitular,
                    MinutosUtilitario = model.MinutoUtilitario,
                    MinutosBase = model.MinutosBase,
                    TurnoId = model.TurnoId,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = model.CentroTrabajo.Id,
                        Codigo = model.CentroTrabajo.Codigo,
                        Nombre = model.CentroTrabajo.Nombre,
                        Secuencia = model.CentroTrabajo.Secuencia
                    },
                    Modulo = new Modulo
                    {
                        Id = model.Modulo.Id,
                        Codigo = model.Modulo.Codigo,
                        Nombre = model.Modulo.Nombre,
                        Secuencia = model.Modulo.Secuencia
                    },
                    Turno = new Turno
                    {
                        Id = model.Turno.Id,
                        Codigo = model.Turno.Codigo,
                        Nombre = model.Turno.Nombre
                    }
                };
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana / Get", exception);
            }
        }

        public static async Task<List<ModuloSemana>> GetByFecha(DateTime fechaIncio)
        {
            try
            {
                var lista = await _client.ModuloSemanaGetByFechaAsync(fechaIncio);

                return lista.Select(model => new ModuloSemana
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    CentroTrabajoId = model.CentroTrabajoId,
                    ModuloId = model.ModuloId,
                    TransferenciaMinutos = model.TransferenciaMinutos,
                    MetaPiezasPorHora = model.MetaPiezasPorHora,
                    MetaProduccion = model.MetaProduccion,
                    MinutosEntrenamiento = model.MinutosEntrenamiento,
                    MinutosTitular = model.MinutosTitular,
                    MinutosUtilitario = model.MinutoUtilitario,
                    MinutosBase = model.MinutosBase,
                    TurnoId = model.TurnoId,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = model.CentroTrabajo.Id,
                        Codigo = model.CentroTrabajo.Codigo,
                        Nombre = model.CentroTrabajo.Nombre,
                        Secuencia = model.CentroTrabajo.Secuencia
                    },
                    Modulo = new Modulo
                    {
                        Id = model.Modulo.Id,
                        Codigo = model.Modulo.Codigo,
                        Nombre = model.Modulo.Nombre,
                        Secuencia = model.Modulo.Secuencia
                    },
                    Turno = new Turno
                    {
                        Id = model.Turno.Id,
                        Codigo = model.Turno.Codigo,
                        Nombre = model.Turno.Nombre
                    }
                }).ToList();
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana / GetByFecha", exception);
            }
        }

        public static async Task<List<ModuloSemana>> GetByFechaCentroTrabajo(DateTime fechaInicio, int centroTrabajoId)
        {
            try
            {
                var lista = await _client.ModuloSemanaGetByFechaCentroTrabajoAsync(fechaInicio, centroTrabajoId);

                return lista.Select(model => new ModuloSemana
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    CentroTrabajoId = model.CentroTrabajoId,
                    ModuloId = model.ModuloId,
                    TransferenciaMinutos = model.TransferenciaMinutos,
                    MetaPiezasPorHora = model.MetaPiezasPorHora,
                    MetaProduccion = model.MetaProduccion,
                    MinutosEntrenamiento = model.MinutosEntrenamiento,
                    MinutosTitular = model.MinutosTitular,
                    MinutosUtilitario = model.MinutoUtilitario,
                    MinutosBase = model.MinutosBase,
                    TurnoId = model.TurnoId,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = model.CentroTrabajo.Id,
                        Codigo = model.CentroTrabajo.Codigo,
                        Nombre = model.CentroTrabajo.Nombre,
                        Secuencia = model.CentroTrabajo.Secuencia
                    },
                    Modulo = new Modulo
                    {
                        Id = model.Modulo.Id,
                        Codigo = model.Modulo.Codigo,
                        Nombre = model.Modulo.Nombre,
                        Secuencia = model.Modulo.Secuencia
                    },
                    Turno = new Turno
                    {
                        Id = model.Turno.Id,
                        Codigo = model.Turno.Codigo,
                        Nombre = model.Turno.Nombre
                    }
                }).ToList();
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana / GetByFechaCentroTrabajo", exception);
            }
        }

        public static async Task<List<ModuloSemana>> GetByFechaModulo(DateTime fechaInicio, int moduloId)
        {
            try
            {
                var lista = await _client.ModuloSemanaGetByFechaModuloAsync(fechaInicio, moduloId);

                return lista.Select(model => new ModuloSemana
                {
                    Id = model.Id,
                    FechaInicio = model.FechaInicio,
                    FechaFinal = model.FechaFinal,
                    CentroTrabajoId = model.CentroTrabajoId,
                    ModuloId = model.ModuloId,
                    TransferenciaMinutos = model.TransferenciaMinutos,
                    MetaPiezasPorHora = model.MetaPiezasPorHora,
                    MetaProduccion = model.MetaProduccion,
                    MinutosEntrenamiento = model.MinutosEntrenamiento,
                    MinutosTitular = model.MinutosTitular,
                    MinutosUtilitario = model.MinutoUtilitario,
                    MinutosBase = model.MinutosBase,
                    TurnoId = model.TurnoId,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Id = model.CentroTrabajo.Id,
                        Codigo = model.CentroTrabajo.Codigo,
                        Nombre = model.CentroTrabajo.Nombre,
                        Secuencia = model.CentroTrabajo.Secuencia
                    },
                    Modulo = new Modulo
                    {
                        Id = model.Modulo.Id,
                        Codigo = model.Modulo.Codigo,
                        Nombre = model.Modulo.Nombre,
                        Secuencia = model.Modulo.Secuencia
                    },
                    Turno = new Turno
                    {
                        Id = model.Turno.Id,
                        Codigo = model.Turno.Codigo,
                        Nombre = model.Turno.Nombre
                    }
                }).ToList();
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemana / GetByFechaModulo", exception);
            }
        }

        #endregion
    }
}