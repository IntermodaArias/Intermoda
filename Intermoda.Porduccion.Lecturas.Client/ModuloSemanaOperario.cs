using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.Client.LbDatPro;
using Intermoda.Produccion.Lecturas.ClientProxy.DataServiceReference;

namespace Intermoda.Produccion.Lecturas.Client
{
    public class ModuloSemanaOperario : ObservableObject
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

        #region ModuloSemanaId

        /// <summary>
        /// The <see cref="ModuloSemanaId" /> property's name.
        /// </summary>
        public const string ModuloSemanaIdPropertyName = "ModuloSemanaId";

        private int _moduloSemanaId;

        /// <summary>
        /// Sets and gets the ModuloSemanaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ModuloSemanaId
        {
            get
            {
                return _moduloSemanaId;
            }

            set
            {
                if (_moduloSemanaId == value)
                {
                    return;
                }

                _moduloSemanaId = value;
                RaisePropertyChanged(ModuloSemanaIdPropertyName);
            }
        }

        #endregion

        #region CompaniaCodigo

        /// <summary>
        /// The <see cref="CompaniaCodigo" /> property's name.
        /// </summary>
        public const string CompaniaCodigoPropertyName = "CompaniaCodigo";

        private short _companiaCodigo;

        /// <summary>
        /// Sets and gets the CompaniaCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short CompaniaCodigo
        {
            get
            {
                return _companiaCodigo;
            }

            set
            {
                if (_companiaCodigo == value)
                {
                    return;
                }

                _companiaCodigo = value;
                RaisePropertyChanged(CompaniaCodigoPropertyName);
            }
        }

        #endregion

        #region OperarioCodigo

        /// <summary>
        /// The <see cref="OperarioCodigo" /> property's name.
        /// </summary>
        public const string OperarioCodigoPropertyName = "OperarioCodigo";

        private int _operarioCodigo;

        /// <summary>
        /// Sets and gets the OperarioCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperarioCodigo
        {
            get
            {
                return _operarioCodigo;
            }

            set
            {
                if (_operarioCodigo == value)
                {
                    return;
                }

                _operarioCodigo = value;
                RaisePropertyChanged(OperarioCodigoPropertyName);
            }
        }

        #endregion

        #region ClasificacionId

        /// <summary>
        /// The <see cref="ClasificacionId" /> property's name.
        /// </summary>
        public const string ClasificacionIdPropertyName = "ClasificacionId";

        private int _clasificacionId;

        /// <summary>
        /// Sets and gets the ClasificacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ClasificacionId
        {
            get
            {
                return _clasificacionId;
            }

            set
            {
                if (_clasificacionId == value)
                {
                    return;
                }

                _clasificacionId = value;
                RaisePropertyChanged(ClasificacionIdPropertyName);
            }
        }

        #endregion

        #region CurvaEntrenamiento

        /// <summary>
        /// The <see cref="CurvaEntrenamiento" /> property's name.
        /// </summary>
        public const string CurvaEntrenamientoPropertyName = "CurvaEntrenamiento";

        private decimal _curvaEntrenamiento;

        /// <summary>
        /// Sets and gets the CurvaEntrenamiento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal CurvaEntrenamiento
        {
            get
            {
                return _curvaEntrenamiento;
            }

            set
            {
                if (_curvaEntrenamiento == value)
                {
                    return;
                }

                _curvaEntrenamiento = value;
                RaisePropertyChanged(CurvaEntrenamientoPropertyName);
            }
        }

        #endregion

        #region SemanaEntrenamiento

        /// <summary>
        /// The <see cref="SemanaEntrenamiento" /> property's name.
        /// </summary>
        public const string SemanaEntrenamientoPropertyName = "SemanaEntrenamiento";

        private int _semanaEntrenamiento;

        /// <summary>
        /// Sets and gets the SemanaEntrenamiento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SemanaEntrenamiento
        {
            get
            {
                return _semanaEntrenamiento;
            }

            set
            {
                if (_semanaEntrenamiento == value)
                {
                    return;
                }

                _semanaEntrenamiento = value;
                RaisePropertyChanged(SemanaEntrenamientoPropertyName);
            }
        }

        #endregion

        public Empleado Operario { get; set; }

        public CentroTrabajoClasificacion Clasificacion { get; set; }

        public List<Inasistencia> Inasistencias { get; set; }

        #endregion

        #region Methods

        public static async Task<ModuloSemanaOperario> Update(ModuloSemanaOperario reg)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var business = new ModuloSemanaOperarioBusiness
                    {
                        Id = reg.Id,
                        ModuloSemanaId = reg.ModuloSemanaId,
                        CompaniaCodigo = reg.CompaniaCodigo,
                        OperarioCodigo = reg.OperarioCodigo,
                        ClasificacionId = reg.ClasificacionId,
                        CurvaEntrenamiento = reg.CurvaEntrenamiento,
                        SemanaEntrenamiento = reg.SemanaEntrenamiento
                    };

                    var model = await _client.ModuloSemanaOperarioUpdateAsync(business);

                    var retorno = new ModuloSemanaOperario
                    {
                        Id = model.Id,
                        ModuloSemanaId = model.ModuloSemanaId,
                        CompaniaCodigo = model.CompaniaCodigo,
                        OperarioCodigo = model.OperarioCodigo,
                        ClasificacionId = model.ClasificacionId,
                        CurvaEntrenamiento = model.CurvaEntrenamiento,
                        SemanaEntrenamiento = model.SemanaEntrenamiento,
                        Operario = new Empleado
                        {
                            CompaniaCodigo = model.Operario.CompaniaCodigo,
                            Codigo = model.Operario.Codigo,
                            Nombres = model.Operario.Nombres,
                            Apellidos = model.Operario.Apellidos,
                            Alias = model.Operario.Alias,
                            Estado = model.Operario.Estado
                        },
                        Clasificacion = new CentroTrabajoClasificacion
                        {
                            Id = model.Clasificacion.Id,
                            Codigo = model.Clasificacion.Codigo,
                            Nombre = model.Clasificacion.Nombre,
                            Secuencia = model.Clasificacion.Secuencia,
                            Tipo = model.Clasificacion.Tipo
                        },
                        Inasistencias = new List<Inasistencia>()
                    };

                    foreach (var item in model.Inasistencias)
                    {
                        retorno.Inasistencias.Add(new Inasistencia
                        {
                            CompaniaCodigo = item.CompaniaCodigo,
                            EmpleadoCodigo = item.EmpleadoCodigo,
                            Fecha = item.Fecha,
                            MinutosConPermiso = item.MinutosConPermiso,
                            MinutosSinPermiso = item.MinutosSinPermiso
                        });
                    }

                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario / Update", exception);
            }
        }

        public static async Task Delete(int moduloSemanaOperarioId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    await _client.ModuloSemanaOperarioDeleteAsync(moduloSemanaOperarioId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario / Delete", exception);
            }
        }

        public static async Task<ModuloSemanaOperario> Get(int moduloSemanaOperarioId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var model = await _client.ModuloSemanaOperarioGetAsync(moduloSemanaOperarioId);

                    var retorno = new ModuloSemanaOperario
                    {
                        Id = model.Id,
                        ModuloSemanaId = model.ModuloSemanaId,
                        CompaniaCodigo = model.CompaniaCodigo,
                        OperarioCodigo = model.OperarioCodigo,
                        ClasificacionId = model.ClasificacionId,
                        CurvaEntrenamiento = model.CurvaEntrenamiento,
                        SemanaEntrenamiento = model.SemanaEntrenamiento,
                        Operario = new Empleado
                        {
                            CompaniaCodigo = model.Operario.CompaniaCodigo,
                            Codigo = model.Operario.Codigo,
                            Nombres = model.Operario.Nombres,
                            Apellidos = model.Operario.Apellidos,
                            Alias = model.Operario.Alias,
                            Estado = model.Operario.Estado
                        },
                        Clasificacion = new CentroTrabajoClasificacion
                        {
                            Id = model.Clasificacion.Id,
                            Codigo = model.Clasificacion.Codigo,
                            Nombre = model.Clasificacion.Nombre,
                            Secuencia = model.Clasificacion.Secuencia,
                            Tipo = model.Clasificacion.Tipo
                        },
                        Inasistencias = new List<Inasistencia>()
                    };

                    foreach (var item in model.Inasistencias)
                    {
                        retorno.Inasistencias.Add(new Inasistencia
                        {
                            CompaniaCodigo = item.CompaniaCodigo,
                            EmpleadoCodigo = item.EmpleadoCodigo,
                            Fecha = item.Fecha,
                            MinutosConPermiso = item.MinutosConPermiso,
                            MinutosSinPermiso = item.MinutosSinPermiso
                        });
                    }

                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario / Get", exception);
            }
        }

        public static async Task<List<ModuloSemanaOperario>> GetByModuloSemana(int moduloSemanaId)
        {
            try
            {
                using (_client = new DataServiceClient())
                {
                    var lista = await _client.ModuloSemanaOperarioGetByModuloSemanaAsync(moduloSemanaId);

                    var retorno = new List<ModuloSemanaOperario>();

                    foreach (var model in lista)
                    {
                        var reg = new ModuloSemanaOperario
                        {
                            Id = model.Id,
                            ModuloSemanaId = model.ModuloSemanaId,
                            CompaniaCodigo = model.CompaniaCodigo,
                            OperarioCodigo = model.OperarioCodigo,
                            ClasificacionId = model.ClasificacionId,
                            CurvaEntrenamiento = model.CurvaEntrenamiento,
                            SemanaEntrenamiento = model.SemanaEntrenamiento,
                            Operario = new Empleado
                            {
                                CompaniaCodigo = model.Operario.CompaniaCodigo,
                                Codigo = model.Operario.Codigo,
                                Nombres = model.Operario.Nombres,
                                Apellidos = model.Operario.Apellidos,
                                Alias = model.Operario.Alias,
                                Estado = model.Operario.Estado
                            },
                            Clasificacion = new CentroTrabajoClasificacion
                            {
                                Id = model.Clasificacion.Id,
                                Codigo = model.Clasificacion.Codigo,
                                Nombre = model.Clasificacion.Nombre,
                                Secuencia = model.Clasificacion.Secuencia,
                                Tipo = model.Clasificacion.Tipo
                            },
                            Inasistencias = new List<Inasistencia>()
                        };

                        foreach (var item in model.Inasistencias)
                        {
                            reg.Inasistencias.Add(new Inasistencia
                            {
                                CompaniaCodigo = item.CompaniaCodigo,
                                EmpleadoCodigo = item.EmpleadoCodigo,
                                Fecha = item.Fecha,
                                MinutosConPermiso = item.MinutosConPermiso,
                                MinutosSinPermiso = item.MinutosSinPermiso
                            });
                        }

                        retorno.Add(reg);

                    }
                    return retorno;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("ModuloSemanaOperario / GetByModuloSemana", exception);
            }
        }

        #endregion
    }
}