using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.IngredienteOperacionServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class IngredienteOperacion : ObservableObject
    {
        private static IngredienteOperacionClient _client;

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

        #region IngredienteId

        /// <summary>
        /// The <see cref="IngredienteId" /> property's name.
        /// </summary>
        public const string IngredienteIdPropertyName = "IngredienteId";

        private int _ingredienteId;

        /// <summary>
        /// Sets and gets the IngredienteId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IngredienteId
        {
            get
            {
                return _ingredienteId;
            }

            set
            {
                if (_ingredienteId == value)
                {
                    return;
                }

                _ingredienteId = value;
                RaisePropertyChanged(IngredienteIdPropertyName);
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

        #region OperacionProcesoId

        /// <summary>
        /// The <see cref="OperacionProcesoId" /> property's name.
        /// </summary>
        public const string OperacionProcesoIdPropertyName = "OperacionProcesoId";

        private int _operacionProcesoId;

        /// <summary>
        /// Sets and gets the OperacionProcesoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int OperacionProcesoId
        {
            get
            {
                return _operacionProcesoId;
            }

            set
            {
                if (_operacionProcesoId == value)
                {
                    return;
                }

                _operacionProcesoId = value;
                RaisePropertyChanged(OperacionProcesoIdPropertyName);
            }
        }

        #endregion

        #region InstruccionOperacionId

        /// <summary>
        /// The <see cref="InstruccionOperacionId" /> property's name.
        /// </summary>
        public const string InstruccionOperacionIdPropertyName = "InstruccionOperacionId";

        private int? _instruccionOperacionId;

        /// <summary>
        /// Sets and gets the InstruccionOperacionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? InstruccionOperacionId
        {
            get
            {
                return _instruccionOperacionId;
            }

            set
            {
                if (_instruccionOperacionId == value)
                {
                    return;
                }

                _instruccionOperacionId = value;
                RaisePropertyChanged(InstruccionOperacionIdPropertyName);
            }
        }

        #endregion

        #region ClaseId

        /// <summary>
        /// The <see cref="ClaseId" /> property's name.
        /// </summary>
        public const string ClaseIdPropertyName = "ClaseId";

        private string _claseId;

        /// <summary>
        /// Sets and gets the ClaseId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ClaseId
        {
            get
            {
                return _claseId;
            }

            set
            {
                if (_claseId == value)
                {
                    return;
                }

                _claseId = value;
                RaisePropertyChanged(ClaseIdPropertyName);
            }
        }

        #endregion

        #region SubClaseId

        /// <summary>
        /// The <see cref="SubClaseId" /> property's name.
        /// </summary>
        public const string SubClaseIdPropertyName = "SubClaseId";

        private string _subClaseId;

        /// <summary>
        /// Sets and gets the SubClaseId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SubClaseId
        {
            get
            {
                return _subClaseId;
            }

            set
            {
                if (_subClaseId == value)
                {
                    return;
                }

                _subClaseId = value;
                RaisePropertyChanged(SubClaseIdPropertyName);
            }
        }

        #endregion

        #region Porcentaje

        /// <summary>
        /// The <see cref="Porcentaje" /> property's name.
        /// </summary>
        public const string PorcentajePropertyName = "Porcentaje";

        private decimal? _porcentaje;

        /// <summary>
        /// Sets and gets the Porcentaje property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal? Porcentaje
        {
            get
            {
                return _porcentaje;
            }

            set
            {
                if (_porcentaje == value)
                {
                    return;
                }

                _porcentaje = value;
                RaisePropertyChanged(PorcentajePropertyName);
            }
        }

        #endregion

        #region Orden

        /// <summary>
        /// The <see cref="Orden" /> property's name.
        /// </summary>
        public const string OrdenPropertyName = "Orden";

        private int? _orden;

        /// <summary>
        /// Sets and gets the Orden property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Orden
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

        public Catalogo Ingrediente { get; set; }

        public Operacion Operacion { get; set; }

        public OperacionProceso OperacionProceso { get; set; }

        public InstruccionOperacion InstruccionOperacion { get; set; }

        public Clase Clase { get; set; }

        public SubClase SubClase { get; set; }

        #endregion

        #region Methods

        public static async Task<IngredienteOperacion> Update(IngredienteOperacion ingredienteOperacion)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var reg = ClientToBusiness(ingredienteOperacion);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / Update", exception);
            }
        }

        public static async Task Delete(int ingredienteOperacionId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    await _client.DeleteAsync(ingredienteOperacionId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / Delete", exception);
            }
        }

        public static async Task<IngredienteOperacion> Get(int ingredienteOperacionId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var reg = await _client.GetAsync(ingredienteOperacionId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / Get", exception);
            }
        }

        public static async Task<List<IngredienteOperacion>> GetAll()
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetAll", exception);
            }
        }

        public static async Task<List<IngredienteOperacion>> GetByIngrediente(int ingredienteId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetByIngredienteAsync(ingredienteId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByIngrediente", exception);
            }
        }
        
        public static async Task<List<IngredienteOperacion>> GetByOperacion(int operacionId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetByOperacionAsync(operacionId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByOperacion", exception);
            }
        }

        public static async Task<List<IngredienteOperacion>> GetByOperacionProceso(int operacionProcesoId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetByOperacionProcesoAsync(operacionProcesoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByOperacionProceso", exception);
            }
        }

        public static async Task<List<IngredienteOperacion>> GetByClase(string claseId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetByClaseAsync(claseId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByClase", exception);
            }
        }

        public static async Task<List<IngredienteOperacion>> GetBySubClase(string subClaseId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetBySubClaseAsync(subClaseId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetBySubClase", exception);
            }
        }

        public static async Task<List<IngredienteOperacion>> GetByInstruccionOperacion(int instruccionOperacionId)
        {
            try
            {
                using (_client = new IngredienteOperacionClient())
                {
                    var lista = await _client.GetByInstruccionOperacionAsync(instruccionOperacionId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredienteOperacion / GetByInstruccionOperacion", exception);
            }
        }

        private static IngredienteOperacion BusinessToClient(IngredienteOperacionBusiness input)
        {
            return new IngredienteOperacion
            {
                Id = input.Id,
                IngredienteId = input.IngredienteId,
                OperacionId = input.OperacionId,
                OperacionProcesoId = input.OperacionProcesoId,
                InstruccionOperacionId = input.InstruccionOperacionId,
                ClaseId = input.ClaseId,
                SubClaseId = input.SubClaseId,
                Porcentaje = input.Porcentaje,
                Orden = input.Orden,
                Ingrediente = new Catalogo
                {
                    Id = input.Ingrediente.Id,
                    Nombre = input.Ingrediente.Nombre,
                    Descripcion = input.Ingrediente.Descripcion,
                    MedidaCompraCodigo = input.Ingrediente.MedidaCompraCodigo,
                    MedidaConsumoCodigo = input.Ingrediente.MedidaConsumoCodigo,
                    TipoRequisicionCodigo = input.Ingrediente.TipoRequisicionCodigo,
                    GrupoCodigo = input.Ingrediente.GrupoCodigo,
                    TelaCodigo = input.Ingrediente.TelaCodigo,
                    CuentaContableCodigo = input.Ingrediente.CuentaContableCodigo,
                    CuentaVariableFija = input.Ingrediente.CuentaVariableFija,
                    CuentaContableInventarioCodigo = input.Ingrediente.CuentaContableInventarioCodigo,
                    RepuestoNumero = input.Ingrediente.RepuestoNumero
                },
                Operacion = new Operacion
                {
                    Id = input.Operacion.Id,
                    Nombre = input.Operacion.Nombre,
                    Descripcion = input.Operacion.Descripcion,
                    OperacionTipoId = input.Operacion.OperacionTipoId,
                    GrupoId = input.Operacion.GrupoId,
                    LineaProduccionId = input.Operacion.LineaProduccionId
                },
                OperacionProceso = new OperacionProceso
                {
                    Id = input.OperacionProceso.Id,
                    OperacionId = input.OperacionProceso.OperacionId,
                    ProcesoId = input.OperacionProceso.ProcesoId,
                    ProcesoCentroTrabajoId = input.OperacionProceso.ProcesoCentroTrabajoId,
                    Temperatura = input.OperacionProceso.Temperatura,
                    Ph = input.OperacionProceso.Ph,
                    TiempoMinimo = input.OperacionProceso.TiempoMinimo,
                    TiempoMaximo = input.OperacionProceso.TiempoMaximo,
                    TiempoEstandar = input.OperacionProceso.TiempoEstandar,
                    RelacionBano = input.OperacionProceso.RelacionBano,
                    Orden = input.OperacionProceso.Orden
                },
                Clase = new Clase
                {
                    CompaniaCodigo = input.Clase.CompaniaCodigo,
                    Codigo = input.Clase.Codigo,
                    ManejaInventario = input.Clase.ManejaInventario,
                    Descripcion = input.Clase.Descripcion,
                    CuentaContable = input.Clase.CuentaContable,
                    RotacionBaja = input.Clase.RotacionBaja,
                    SinRotacion = input.Clase.SinRotacion,
                    Estado = input.Clase.Estado,
                    DetalleMaestra = input.Clase.DetalleMaestra,
                    AgrupacionCodigo = input.Clase.AgrupacionCodigo,
                    DiasSinMovimiento = input.Clase.DiasSinMovimiento,
                    AgruparEnClaseCodigo = input.Clase.AgruparEnClaseCodigo,
                    GrupoNombre = input.Clase.GrupoNombre
                },
                SubClase = new SubClase
                {
                    CompaniaCodigo = input.SubClase.CompaniaCodigo,
                    Codigo = input.SubClase.Codigo,
                    Descripcion = input.SubClase.Descripcion,
                    Estado = input.SubClase.Estado
                }
            };
        }

        private static IngredienteOperacionBusiness ClientToBusiness(IngredienteOperacion input)
        {
            return new IngredienteOperacionBusiness
            {
                Id = input.Id,
                IngredienteId = input.IngredienteId,
                OperacionId = input.OperacionId,
                OperacionProcesoId = input.OperacionProcesoId,
                InstruccionOperacionId = input.InstruccionOperacionId,
                ClaseId = input.ClaseId,
                SubClaseId = input.SubClaseId,
                Porcentaje = input.Porcentaje,
                Orden = input.Orden,
                Ingrediente = new CatalogoBusiness
                {
                    Id = input.Ingrediente.Id,
                    Nombre = input.Ingrediente.Nombre,
                    Descripcion = input.Ingrediente.Descripcion,
                    MedidaCompraCodigo = input.Ingrediente.MedidaCompraCodigo,
                    MedidaConsumoCodigo = input.Ingrediente.MedidaConsumoCodigo,
                    TipoRequisicionCodigo = input.Ingrediente.TipoRequisicionCodigo,
                    GrupoCodigo = input.Ingrediente.GrupoCodigo,
                    TelaCodigo = input.Ingrediente.TelaCodigo,
                    CuentaContableCodigo = input.Ingrediente.CuentaContableCodigo,
                    CuentaVariableFija = input.Ingrediente.CuentaVariableFija,
                    CuentaContableInventarioCodigo = input.Ingrediente.CuentaContableInventarioCodigo,
                    RepuestoNumero = input.Ingrediente.RepuestoNumero
                },
                Operacion = new OperacionBusiness
                {
                    Id = input.Operacion.Id,
                    Nombre = input.Operacion.Nombre,
                    Descripcion = input.Operacion.Descripcion,
                    OperacionTipoId = input.Operacion.OperacionTipoId,
                    GrupoId = input.Operacion.GrupoId,
                    LineaProduccionId = input.Operacion.LineaProduccionId
                },
                OperacionProceso = new OperacionProcesoBusiness
                {
                    Id = input.OperacionProceso.Id,
                    OperacionId = input.OperacionProceso.OperacionId,
                    ProcesoId = input.OperacionProceso.ProcesoId,
                    ProcesoCentroTrabajoId = input.OperacionProceso.ProcesoCentroTrabajoId,
                    Temperatura = input.OperacionProceso.Temperatura,
                    Ph = input.OperacionProceso.Ph,
                    TiempoMinimo = input.OperacionProceso.TiempoMinimo,
                    TiempoMaximo = input.OperacionProceso.TiempoMaximo,
                    TiempoEstandar = input.OperacionProceso.TiempoEstandar,
                    RelacionBano = input.OperacionProceso.RelacionBano,
                    Orden = input.OperacionProceso.Orden
                },
                Clase = new ClaseBusiness
                {
                    CompaniaCodigo = input.Clase.CompaniaCodigo,
                    Codigo = input.Clase.Codigo,
                    ManejaInventario = input.Clase.ManejaInventario,
                    Descripcion = input.Clase.Descripcion,
                    CuentaContable = input.Clase.CuentaContable,
                    RotacionBaja = input.Clase.RotacionBaja,
                    SinRotacion = input.Clase.SinRotacion,
                    Estado = input.Clase.Estado,
                    DetalleMaestra = input.Clase.DetalleMaestra,
                    AgrupacionCodigo = input.Clase.AgrupacionCodigo,
                    DiasSinMovimiento = input.Clase.DiasSinMovimiento,
                    AgruparEnClaseCodigo = input.Clase.AgruparEnClaseCodigo,
                    GrupoNombre = input.Clase.GrupoNombre
                },
                SubClase = new SubClaseBusiness
                {
                    CompaniaCodigo = input.SubClase.CompaniaCodigo,
                    Codigo = input.SubClase.Codigo,
                    Descripcion = input.SubClase.Descripcion,
                    Estado = input.SubClase.Estado
                }
            };
        }

        #endregion
    }
}