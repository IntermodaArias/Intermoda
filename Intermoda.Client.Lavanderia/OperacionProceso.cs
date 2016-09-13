using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.OperacionProcesoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class OperacionProceso : ObservableObject
    {
        private static OperacionProcesoClient _client;

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

        #region OperacionId

        /// <summary>
        /// The <see cref="OperacionId" /> property's name.
        /// </summary>
        public const string OperacionIdPropertyName = "OperacionId";

        private int _operacionId;

        /// <summary>
        /// Sets and gets the OperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionId
        {
            get
            {
                return _operacionId;
            }

            set
            {
                if (_operacionId == value)
                {
                    return;
                }

                _operacionId = value;
                RaisePropertyChanged(OperacionIdPropertyName);
            }
        }

        #endregion

        #region ProcesoId

        /// <summary>
        /// The <see cref="ProcesoId" /> property's name.
        /// </summary>
        public const string ProcesoIdPropertyName = "ProcesoId";

        private int _procesoId;

        /// <summary>
        /// Sets and gets the ProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ProcesoId
        {
            get
            {
                return _procesoId;
            }

            set
            {
                if (_procesoId == value)
                {
                    return;
                }

                _procesoId = value;
                RaisePropertyChanged(ProcesoIdPropertyName);
            }
        }

        #endregion

        #region ProcesoCentroTrabajoId

        /// <summary>
        /// The <see cref="ProcesoCentroTrabajoId" /> property's name.
        /// </summary>
        public const string ProcesoCentroTrabajoIdPropertyName = "ProcesoCentroTrabajoId";

        private int _procesoCentroTrabajoId;

        /// <summary>
        /// Sets and gets the ProcesoCentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ProcesoCentroTrabajoId
        {
            get
            {
                return _procesoCentroTrabajoId;
            }

            set
            {
                if (_procesoCentroTrabajoId == value)
                {
                    return;
                }

                _procesoCentroTrabajoId = value;
                RaisePropertyChanged(ProcesoCentroTrabajoIdPropertyName);
            }
        }

        #endregion

        #region Temperatura

        /// <summary>
        /// The <see cref="Temperatura" /> property's name.
        /// </summary>
        public const string TemperaturaPropertyName = "Temperatura";

        private int _temperatura;

        /// <summary>
        /// Sets and gets the Temperatura property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Temperatura
        {
            get
            {
                return _temperatura;
            }

            set
            {
                if (_temperatura == value)
                {
                    return;
                }

                _temperatura = value;
                RaisePropertyChanged(TemperaturaPropertyName);
            }
        }

        #endregion

        #region Ph

        /// <summary>
        /// The <see cref="Ph" /> property's name.
        /// </summary>
        public const string PhPropertyName = "Ph";

        private string _ph;

        /// <summary>
        /// Sets and gets the Ph property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Ph
        {
            get
            {
                return _ph;
            }

            set
            {
                if (_ph == value)
                {
                    return;
                }

                _ph = value;
                RaisePropertyChanged(PhPropertyName);
            }
        }

        #endregion

        #region TiempoMinimo

        /// <summary>
        /// The <see cref="TiempoMinimo" /> property's name.
        /// </summary>
        public const string TiempoMinimoPropertyName = "TiempoMinimo";

        private decimal _tiempoMinimo;

        /// <summary>
        /// Sets and gets the TiempoMinimo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMinimo
        {
            get
            {
                return _tiempoMinimo;
            }

            set
            {
                if (_tiempoMinimo == value)
                {
                    return;
                }

                _tiempoMinimo = value;
                RaisePropertyChanged(TiempoMinimoPropertyName);
            }
        }

        #endregion

        #region TiempoMaximo

        /// <summary>
        /// The <see cref="TiempoMaximo" /> property's name.
        /// </summary>
        public const string TiempoMaximoPropertyName = "TiempoMaximo";

        private decimal _tiempoMaximo;

        /// <summary>
        /// Sets and gets the TiempoMaximo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal TiempoMaximo
        {
            get
            {
                return _tiempoMaximo;
            }

            set
            {
                if (_tiempoMaximo == value)
                {
                    return;
                }

                _tiempoMaximo = value;
                RaisePropertyChanged(TiempoMaximoPropertyName);
            }
        }

        #endregion

        #region TiempoEstandar

        /// <summary>
        /// The <see cref="TiempoEstandar" /> property's name.
        /// </summary>
        public const string TiempoEstandarPropertyName = "TiempoEstandar";

        private decimal? _tiempoEstandar;

        /// <summary>
        /// Sets and gets the TiempoEstandar property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? TiempoEstandar
        {
            get
            {
                return _tiempoEstandar;
            }

            set
            {
                if (_tiempoEstandar == value)
                {
                    return;
                }

                _tiempoEstandar = value;
                RaisePropertyChanged(TiempoEstandarPropertyName);
            }
        }

        #endregion

        #region RelacionBano

        /// <summary>
        /// The <see cref="RelacionBano" /> property's name.
        /// </summary>
        public const string RelacionBanoPropertyName = "RelacionBano";

        private int _relacionBano;

        /// <summary>
        /// Sets and gets the RelacionBano property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int RelacionBano
        {
            get
            {
                return _relacionBano;
            }

            set
            {
                if (_relacionBano == value)
                {
                    return;
                }

                _relacionBano = value;
                RaisePropertyChanged(RelacionBanoPropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Orden
        {
            get
            {
                return _orden;
            }

            set
            {
                if (_orden == value)
                {
                    return;
                }

                _orden = value;
                RaisePropertyChanged(OrdenPropertyName);
            }
        }

        #endregion

        public Operacion Operacion { get; set; }

        public Proceso Proceso { get; set; }

        public ProcesoCentroTrabajo ProcesoCentroTrabajo { get; set; }

        #endregion

        #region Methods

        public static async Task<OperacionProceso> Update(OperacionProceso operacionProceso)
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    var reg = ClientToBusiness(operacionProceso);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / Update", exception);
            }
        }

        public static async Task Delete(int operacionProcesoId)
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    await _client.DeleteAsync(operacionProcesoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / Delete", exception);
            }
        }

        public static async Task<OperacionProceso> Get(int operacionProcesoId)
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    var reg = await _client.GetAsync(operacionProcesoId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / Get", exception);
            }
        }

        public static async Task<List<OperacionProceso>> GetAll()
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetAll", exception);
            }
        }

        public static async Task<List<OperacionProceso>> GetByOperacion(int operacionId)
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    var lista = await _client.GetByOperacionAsync(operacionId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetByOperacion", exception);
            }
        }

        public static async Task<List<OperacionProceso>> GetByProceso(int procesoId)
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    var lista = await _client.GetByProcesoAsync(procesoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetByProceso", exception);
            }
        }

        public static async Task<List<OperacionProceso>> GetByProcesoCentroTrabajo(int procesoCentroTrabajoId)
        {
            try
            {
                using (_client = new OperacionProcesoClient())
                {
                    var lista = await _client.GetByProcesoCentroTrabajoAsync(procesoCentroTrabajoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OperacionProceso / GetByProcesoCentroTrabajo", exception);
            }
        }

        private static OperacionProceso BusinessToClient(OperacionProcesoBusiness input)
        {
            return new OperacionProceso
            {
                Id = input.Id,
                OperacionId = input.OperacionId,
                ProcesoId = input.ProcesoId,
                ProcesoCentroTrabajoId = input.ProcesoCentroTrabajoId,
                Temperatura = input.Temperatura,
                Ph = input.Ph,
                TiempoMinimo = input.TiempoMinimo,
                TiempoMaximo = input.TiempoMaximo,
                TiempoEstandar = input.TiempoEstandar,
                RelacionBano = input.RelacionBano,
                Orden = input.Orden,
                Operacion = new Operacion
                {
                    Id = input.Operacion.Id,
                    Descripcion = input.Operacion.Descripcion,
                    GrupoId = input.Operacion.GrupoId,
                    LineaProduccionId = input.Operacion.LineaProduccionId,
                    Nombre = input.Operacion.Nombre,
                    OperacionTipoId = input.Operacion.OperacionTipoId,
                    OperacionPredefinida = new OperacionPredefinida
                    {
                        Id = input.Operacion.OperacionPredefinida.Id,
                        OperacionId = input.Operacion.OperacionPredefinida.OperacionId,
                        RelacionBano = input.Operacion.OperacionPredefinida.RelacionBano,
                        Secuencia = input.Operacion.OperacionPredefinida.Secuencia,
                        TiempoMinimo = input.Operacion.OperacionPredefinida.TiempoMinimo,
                        TiempoMaximo = input.Operacion.OperacionPredefinida.TiempoMaximo,
                        Temperatura = input.Operacion.OperacionPredefinida.Temperatura
                    }
                },
                Proceso = new Proceso
                {
                    Id = input.Proceso.Id,
                    CentroTrabajoId = input.Proceso.CentroTrabajoId,
                    Descripcion = input.Proceso.Descripcion,
                    EsActivo = input.Proceso.EsActivo,
                    EsObligatorio = input.Proceso.EsObligatorio,
                    Nombre = input.Proceso.Nombre,
                    Secuencia = input.Proceso.Secuencia,
                    TiempoEstandar = input.Proceso.TiempoEstandar,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Codigo = input.Proceso.CentroTrabajo.Codigo,
                        Nombre = input.Proceso.CentroTrabajo.Nombre,
                        Observacion = input.Proceso.CentroTrabajo.Observacion,
                        EsActivo = input.Proceso.CentroTrabajo.EsActivo,
                        EsObligatorio = input.Proceso.CentroTrabajo.EsObligatorio,
                        LineaProduccionCodigo = input.Proceso.CentroTrabajo.LineaProduccionCodigo,
                        Orden = input.Proceso.CentroTrabajo.Orden,
                        TiempoEspera = input.Proceso.CentroTrabajo.TiempoEspera,
                        TiempoProceso = input.Proceso.CentroTrabajo.TiempoProceso
                    }
                },
                ProcesoCentroTrabajo = new ProcesoCentroTrabajo
                {
                    Id = input.ProcesoCentroTrabajo.Id,
                    CentroTrabajo = new CentroTrabajo
                    {
                        Codigo = input.ProcesoCentroTrabajo.CentroTrabajo.Codigo,
                        Nombre = input.ProcesoCentroTrabajo.CentroTrabajo.Nombre,
                        Observacion = input.ProcesoCentroTrabajo.CentroTrabajo.Observacion,
                        EsActivo = input.ProcesoCentroTrabajo.CentroTrabajo.EsActivo,
                        EsObligatorio = input.ProcesoCentroTrabajo.CentroTrabajo.EsObligatorio,
                        LineaProduccionCodigo = input.ProcesoCentroTrabajo.CentroTrabajo.LineaProduccionCodigo,
                        Orden = input.ProcesoCentroTrabajo.CentroTrabajo.Orden,
                        TiempoEspera = input.ProcesoCentroTrabajo.CentroTrabajo.TiempoEspera,
                        TiempoProceso = input.ProcesoCentroTrabajo.CentroTrabajo.TiempoProceso
                    },
                    CentroTrabajoId = input.ProcesoCentroTrabajo.CentroTrabajoId,
                    CentroTrabajoOpcion = new CentroTrabajoOpcion
                    {
                        Id = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.Id,
                        CentroTrabajoId = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajoId,
                        CentroTrabajoNombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajoNombre,
                        CentroTrabajoObservacion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajoObservacion,
                        OpcionId = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionId,
                        Orden = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.Orden,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Codigo = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.Codigo,
                            EsActivo = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.EsActivo,
                            EsObligatorio = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.EsObligatorio,
                            LineaProduccionCodigo = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.LineaProduccionCodigo,
                            Nombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.Nombre,
                            Observacion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.Observacion,
                            Orden = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.Orden,
                            TiempoEspera = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.TiempoEspera,
                            TiempoProceso = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.CentroTrabajo.TiempoProceso
                        },
                        OpcionLavado = new OpcionLavado
                        {
                            Id = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Id,
                            Descripcion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Descripcion,
                            IsDefault = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.IsDefault,
                            Lavado = new Lavado
                            {
                                LavadoId = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.LavadoId,
                                ColorId = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.ColorId,
                                EsActivo = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.IsActivo,
                                ColorIntermoda = new ColorIntermoda
                                {
                                    Id = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.ColorIntermoda.Id,
                                    Nombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.ColorIntermoda.Nombre
                                },
                                LavadoDescripcion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.LavadoDescripcion,
                                LavadoFechaCreacion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.LavadoFechaCreacion,
                                LavadoFechaActualizacion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.LavadoFechaActualizacion,
                                LavadoNombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Lavado.LavadoNombre
                            },
                            LavadoId = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.LavadoId,
                            Nombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Nombre,
                            TelaId = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.TelaId,
                            Tela = new Tela
                            {
                                TelaCodigo = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Tela.TelaCodigo,
                                ComposicionNombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Tela.ComposicionNombre,
                                MaterialCodigo = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Tela.MaterialCodigo,
                                TelaDescripcion = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Tela.TelaDescripcion,
                                TelaNombre = input.ProcesoCentroTrabajo.CentroTrabajoOpcion.OpcionLavado.Tela.TelaNombre
                            }
                        }
                    },
                    CentroTrabajoOpcionId = input.ProcesoCentroTrabajo.CentroTrabajoOpcionId,
                    Orden = input.ProcesoCentroTrabajo.Orden,
                    Proceso = null,
                    ProcesoId = input.ProcesoCentroTrabajo.ProcesoId
                }
            };
        }

        private static OperacionProcesoBusiness ClientToBusiness(OperacionProceso input)
        {
            return new OperacionProcesoBusiness
            {
                Id = input.Id,
                OperacionId = input.OperacionId,
                ProcesoId = input.ProcesoId,
                ProcesoCentroTrabajoId = input.ProcesoCentroTrabajoId,
                Temperatura = input.Temperatura,
                Ph = input.Ph,
                TiempoMinimo = input.TiempoMinimo,
                TiempoMaximo = input.TiempoMaximo,
                TiempoEstandar = input.TiempoEstandar,
                RelacionBano = input.RelacionBano,
                Orden = input.Orden,
                Operacion = new OperacionBusiness
                {
                    Id = input.Operacion.Id,
                    Descripcion = input.Operacion.Descripcion,
                    GrupoId = input.Operacion.GrupoId,
                    LineaProduccionId = input.Operacion.LineaProduccionId,
                    Nombre = input.Operacion.Nombre,
                    OperacionTipoId = input.Operacion.OperacionTipoId,
                    OperacionPredefinida = new OperacionPredefinidaBusiness
                    {
                        Id = input.Operacion.OperacionPredefinida.Id,
                        OperacionId = input.Operacion.OperacionPredefinida.OperacionId,
                        RelacionBano = input.Operacion.OperacionPredefinida.RelacionBano,
                        Secuencia = input.Operacion.OperacionPredefinida.Secuencia,
                        TiempoMinimo = input.Operacion.OperacionPredefinida.TiempoMinimo,
                        TiempoMaximo = input.Operacion.OperacionPredefinida.TiempoMaximo,
                        Temperatura = input.Operacion.OperacionPredefinida.Temperatura
                    }
                },
                Proceso = new ProcesoBusiness
                {
                    Id = input.Proceso.Id,
                    CentroTrabajoId = input.Proceso.CentroTrabajoId,
                    Descripcion = input.Proceso.Descripcion,
                    EsActivo = input.Proceso.EsActivo,
                    EsObligatorio = input.Proceso.EsObligatorio,
                    Nombre = input.Proceso.Nombre,
                    Secuencia = input.Proceso.Secuencia,
                    TiempoEstandar = input.Proceso.TiempoEstandar,
                    CentroTrabajo = new CTrabajoBusiness
                    {
                        Codigo = input.Proceso.CentroTrabajo.Codigo,
                        Nombre = input.Proceso.CentroTrabajo.Nombre,
                        Observacion = input.Proceso.CentroTrabajo.Observacion,
                        EsActivo = input.Proceso.CentroTrabajo.EsActivo,
                        EsObligatorio = input.Proceso.CentroTrabajo.EsObligatorio,
                        LineaProduccionCodigo = input.Proceso.CentroTrabajo.LineaProduccionCodigo,
                        Orden = input.Proceso.CentroTrabajo.Orden,
                        TiempoEspera = input.Proceso.CentroTrabajo.TiempoEspera,
                        TiempoProceso = input.Proceso.CentroTrabajo.TiempoProceso
                    }
                },
                ProcesoCentroTrabajo = new ProcesoCentroTrabajoBusiness
                {
                    Id = input.ProcesoCentroTrabajo.Id,
                    CentroTrabajo = new CTrabajoBusiness
                    {
                        Codigo = input.ProcesoCentroTrabajo.CentroTrabajo.Codigo,
                        Nombre = input.ProcesoCentroTrabajo.CentroTrabajo.Nombre,
                        Observacion = input.ProcesoCentroTrabajo.CentroTrabajo.Observacion,
                        EsActivo = input.ProcesoCentroTrabajo.CentroTrabajo.EsActivo,
                        EsObligatorio = input.ProcesoCentroTrabajo.CentroTrabajo.EsObligatorio,
                        LineaProduccionCodigo = input.ProcesoCentroTrabajo.CentroTrabajo.LineaProduccionCodigo,
                        Orden = input.ProcesoCentroTrabajo.CentroTrabajo.Orden,
                        TiempoEspera = input.ProcesoCentroTrabajo.CentroTrabajo.TiempoEspera,
                        TiempoProceso = input.ProcesoCentroTrabajo.CentroTrabajo.TiempoProceso
                    },
                    CentroTrabajoId = input.ProcesoCentroTrabajo.CentroTrabajoId,
                    CentroTrabajoOpcion = null,
                    CentroTrabajoOpcionId = input.ProcesoCentroTrabajo.CentroTrabajoOpcionId,
                    Orden = input.ProcesoCentroTrabajo.Orden,
                    Proceso = null,
                    ProcesoId = input.ProcesoCentroTrabajo.ProcesoId
                }
            };
        }

        #endregion
    }
}