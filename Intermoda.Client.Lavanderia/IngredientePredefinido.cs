using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.IngredientePredefinidoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class IngredientePredefinido : ObservableObject
    {
        private static IngredientePredefinidoClient _client;

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

        #region InstruccionPredefinidaId

        /// <summary>
        /// The <see cref="InstruccionPredefinidaId" /> property's name.
        /// </summary>
        public const string InstruccionPredefinidaIdPropertyName = "InstruccionPredefinidaId";

        private int? _instruccionPredefinidaId;

        /// <summary>
        /// Sets and gets the InstruccionPredefinidaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? InstruccionPredefinidaId
        {
            get
            {
                return _instruccionPredefinidaId;
            }

            set
            {
                if (_instruccionPredefinidaId == value)
                {
                    return;
                }

                _instruccionPredefinidaId = value;
                RaisePropertyChanged(InstruccionPredefinidaIdPropertyName);
            }
        }

        #endregion

        public Catalogo Catalogo { get; set; }
        public Operacion Operacion { get; set; }
        public InstruccionPredefinida InstruccionPredefinida { get; set; }
        public Clase Clase { get; set; }
        public SubClase SubClase { get; set; }

        #endregion

        #region Methods

        public static async Task<IngredientePredefinido> Update(IngredientePredefinido ingredientePredefinido)
        {
            try
            {
                using (_client = new IngredientePredefinidoClient())
                {
                    var reg = new IngredientePredefinidoBusiness
                    {
                        Id = ingredientePredefinido.Id,
                        IngredienteId = ingredientePredefinido.IngredienteId,
                        OperacionId = ingredientePredefinido.OperacionId,
                        ClaseId = ingredientePredefinido.ClaseId,
                        SubClaseId = ingredientePredefinido.SubClaseId,
                        Porcentaje = ingredientePredefinido.Porcentaje,
                        Orden = ingredientePredefinido.Orden,
                        InstruccionPredefinidaId = ingredientePredefinido.InstruccionPredefinidaId
                    };

                    reg = await _client.UpdateAsync(reg);

                    return new IngredientePredefinido
                    {
                        Id = reg.Id,
                        IngredienteId = reg.IngredienteId,
                        OperacionId = reg.OperacionId,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
                        Porcentaje = reg.Porcentaje,
                        Orden = reg.Orden,
                        InstruccionPredefinidaId = reg.InstruccionPredefinidaId,
                        Catalogo = new Catalogo
                        {
                            Id = reg.Catalogo.Id,
                            Nombre = reg.Catalogo.Nombre,
                            Descripcion = reg.Catalogo.Descripcion,
                            MedidaCompraCodigo = reg.Catalogo.MedidaCompraCodigo,
                            MedidaConsumoCodigo = reg.Catalogo.MedidaConsumoCodigo,
                            TipoRequisicionCodigo = reg.Catalogo.TipoRequisicionCodigo,
                            GrupoCodigo = reg.Catalogo.GrupoCodigo,
                            TelaCodigo = reg.Catalogo.TelaCodigo,
                            CuentaContableCodigo = reg.Catalogo.CuentaContableCodigo,
                            CuentaVariableFija = reg.Catalogo.CuentaVariableFija,
                            CuentaContableInventarioCodigo = reg.Catalogo.CuentaContableInventarioCodigo,
                            RepuestoNumero = reg.Catalogo.RepuestoNumero
                        },
                        Operacion = new Operacion
                        {
                            Id = reg.Operacion.Id,
                            Nombre = reg.Operacion.Nombre,
                            Descripcion = reg.Operacion.Descripcion,
                            OperacionTipoId = reg.Operacion.OperacionTipoId,
                            GrupoId = reg.Operacion.GrupoId,
                            LineaProduccionId = reg.Operacion.LineaProduccionId
                        },
                        Clase = new Clase
                        {
                            CompaniaCodigo = reg.Clase.CompaniaCodigo,
                            Codigo = reg.Clase.Codigo,
                            ManejaInventario = reg.Clase.ManejaInventario,
                            Descripcion = reg.Clase.Descripcion,
                            CuentaContable = reg.Clase.CuentaContable,
                            RotacionBaja = reg.Clase.RotacionBaja,
                            SinRotacion = reg.Clase.SinRotacion,
                            Estado = reg.Clase.Estado,
                            DetalleMaestra = reg.Clase.DetalleMaestra,
                            AgrupacionCodigo = reg.Clase.AgrupacionCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        },
                        InstruccionPredefinida = new InstruccionPredefinida
                        {
                            Id = reg.InstruccionPredefinida.Id,
                            OperacionPredefinidaId = reg.InstruccionPredefinida.OperacionPredefinidaId,
                            Descripcion = reg.InstruccionPredefinida.Descripcion,
                            Orden = reg.InstruccionPredefinida.Orden,
                            TiempoMaximo = reg.InstruccionPredefinida.TiempoMaximo,
                            TiempoMinimo = reg.InstruccionPredefinida.TiempoMinimo,
                            Temperatura = reg.InstruccionPredefinida.Temperatura
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / Update", exception);
            }
        }

        public static async Task Delete(int ingredientePredefinidoId)
        {
            try
            {
                using (_client = new IngredientePredefinidoClient())
                {
                    await _client.DeleteAsync(ingredientePredefinidoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / Delete", exception);
            }
        }

        public static async Task<IngredientePredefinido> Get(int ingredientePredefinidoId)
        {
            try
            {
                using (_client = new IngredientePredefinidoClient())
                {
                    var reg = await _client.GetAsync(ingredientePredefinidoId);

                    return new IngredientePredefinido
                    {
                        Id = reg.Id,
                        IngredienteId = reg.IngredienteId,
                        OperacionId = reg.OperacionId,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
                        Porcentaje = reg.Porcentaje,
                        Orden = reg.Orden,
                        InstruccionPredefinidaId = reg.InstruccionPredefinidaId,
                        Catalogo = new Catalogo
                        {
                            Id = reg.Catalogo.Id,
                            Nombre = reg.Catalogo.Nombre,
                            Descripcion = reg.Catalogo.Descripcion,
                            MedidaCompraCodigo = reg.Catalogo.MedidaCompraCodigo,
                            MedidaConsumoCodigo = reg.Catalogo.MedidaConsumoCodigo,
                            TipoRequisicionCodigo = reg.Catalogo.TipoRequisicionCodigo,
                            GrupoCodigo = reg.Catalogo.GrupoCodigo,
                            TelaCodigo = reg.Catalogo.TelaCodigo,
                            CuentaContableCodigo = reg.Catalogo.CuentaContableCodigo,
                            CuentaVariableFija = reg.Catalogo.CuentaVariableFija,
                            CuentaContableInventarioCodigo = reg.Catalogo.CuentaContableInventarioCodigo,
                            RepuestoNumero = reg.Catalogo.RepuestoNumero
                        },
                        Operacion = new Operacion
                        {
                            Id = reg.Operacion.Id,
                            Nombre = reg.Operacion.Nombre,
                            Descripcion = reg.Operacion.Descripcion,
                            OperacionTipoId = reg.Operacion.OperacionTipoId,
                            GrupoId = reg.Operacion.GrupoId,
                            LineaProduccionId = reg.Operacion.LineaProduccionId
                        },
                        Clase = new Clase
                        {
                            CompaniaCodigo = reg.Clase.CompaniaCodigo,
                            Codigo = reg.Clase.Codigo,
                            ManejaInventario = reg.Clase.ManejaInventario,
                            Descripcion = reg.Clase.Descripcion,
                            CuentaContable = reg.Clase.CuentaContable,
                            RotacionBaja = reg.Clase.RotacionBaja,
                            SinRotacion = reg.Clase.SinRotacion,
                            Estado = reg.Clase.Estado,
                            DetalleMaestra = reg.Clase.DetalleMaestra,
                            AgrupacionCodigo = reg.Clase.AgrupacionCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        },
                        InstruccionPredefinida = new InstruccionPredefinida
                        {
                            Id = reg.InstruccionPredefinida.Id,
                            OperacionPredefinidaId = reg.InstruccionPredefinida.OperacionPredefinidaId,
                            Descripcion = reg.InstruccionPredefinida.Descripcion,
                            Orden = reg.InstruccionPredefinida.Orden,
                            TiempoMaximo = reg.InstruccionPredefinida.TiempoMaximo,
                            TiempoMinimo = reg.InstruccionPredefinida.TiempoMinimo,
                            Temperatura = reg.InstruccionPredefinida.Temperatura
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / Get", exception);
            }
        }

        public static async Task<List<IngredientePredefinido>> GetAll()
        {
            try
            {
                using (_client = new IngredientePredefinidoClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(reg => new IngredientePredefinido
                    {
                        Id = reg.Id,
                        IngredienteId = reg.IngredienteId,
                        OperacionId = reg.OperacionId,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
                        Porcentaje = reg.Porcentaje,
                        Orden = reg.Orden,
                        InstruccionPredefinidaId = reg.InstruccionPredefinidaId,
                        Catalogo = new Catalogo
                        {
                            Id = reg.Catalogo.Id,
                            Nombre = reg.Catalogo.Nombre,
                            Descripcion = reg.Catalogo.Descripcion,
                            MedidaCompraCodigo = reg.Catalogo.MedidaCompraCodigo,
                            MedidaConsumoCodigo = reg.Catalogo.MedidaConsumoCodigo,
                            TipoRequisicionCodigo = reg.Catalogo.TipoRequisicionCodigo,
                            GrupoCodigo = reg.Catalogo.GrupoCodigo,
                            TelaCodigo = reg.Catalogo.TelaCodigo,
                            CuentaContableCodigo = reg.Catalogo.CuentaContableCodigo,
                            CuentaVariableFija = reg.Catalogo.CuentaVariableFija,
                            CuentaContableInventarioCodigo = reg.Catalogo.CuentaContableInventarioCodigo,
                            RepuestoNumero = reg.Catalogo.RepuestoNumero
                        },
                        Operacion = new Operacion
                        {
                            Id = reg.Operacion.Id,
                            Nombre = reg.Operacion.Nombre,
                            Descripcion = reg.Operacion.Descripcion,
                            OperacionTipoId = reg.Operacion.OperacionTipoId,
                            GrupoId = reg.Operacion.GrupoId,
                            LineaProduccionId = reg.Operacion.LineaProduccionId
                        },
                        Clase = new Clase
                        {
                            CompaniaCodigo = reg.Clase.CompaniaCodigo,
                            Codigo = reg.Clase.Codigo,
                            ManejaInventario = reg.Clase.ManejaInventario,
                            Descripcion = reg.Clase.Descripcion,
                            CuentaContable = reg.Clase.CuentaContable,
                            RotacionBaja = reg.Clase.RotacionBaja,
                            SinRotacion = reg.Clase.SinRotacion,
                            Estado = reg.Clase.Estado,
                            DetalleMaestra = reg.Clase.DetalleMaestra,
                            AgrupacionCodigo = reg.Clase.AgrupacionCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        },
                        InstruccionPredefinida = new InstruccionPredefinida
                        {
                            Id = reg.InstruccionPredefinida.Id,
                            OperacionPredefinidaId = reg.InstruccionPredefinida.OperacionPredefinidaId,
                            Descripcion = reg.InstruccionPredefinida.Descripcion,
                            Orden = reg.InstruccionPredefinida.Orden,
                            TiempoMaximo = reg.InstruccionPredefinida.TiempoMaximo,
                            TiempoMinimo = reg.InstruccionPredefinida.TiempoMinimo,
                            Temperatura = reg.InstruccionPredefinida.Temperatura
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / GetAll", exception);
            }
        }

        public static async Task<List<IngredientePredefinido>> GetByInstruccionPredefinida(int instruccionPredefinidaId)
        {
            try
            {
                using (_client = new IngredientePredefinidoClient())
                {
                    var lista = await _client.GetByInstruccionPredefinidaAsync(instruccionPredefinidaId);

                    return lista.Select(reg => new IngredientePredefinido
                    {
                        Id = reg.Id,
                        IngredienteId = reg.IngredienteId,
                        OperacionId = reg.OperacionId,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
                        Porcentaje = reg.Porcentaje,
                        Orden = reg.Orden,
                        InstruccionPredefinidaId = reg.InstruccionPredefinidaId,
                        Catalogo = reg.Catalogo != null
                            ? new Catalogo
                            {
                                Id = reg.Catalogo.Id,
                                Nombre = reg.Catalogo.Nombre,
                                Descripcion = reg.Catalogo.Descripcion,
                                MedidaCompraCodigo = reg.Catalogo.MedidaCompraCodigo,
                                MedidaConsumoCodigo = reg.Catalogo.MedidaConsumoCodigo,
                                TipoRequisicionCodigo = reg.Catalogo.TipoRequisicionCodigo,
                                GrupoCodigo = reg.Catalogo.GrupoCodigo,
                                TelaCodigo = reg.Catalogo.TelaCodigo,
                                CuentaContableCodigo = reg.Catalogo.CuentaContableCodigo,
                                CuentaVariableFija = reg.Catalogo.CuentaVariableFija,
                                CuentaContableInventarioCodigo = reg.Catalogo.CuentaContableInventarioCodigo,
                                RepuestoNumero = reg.Catalogo.RepuestoNumero
                            }
                            : null,
                        Operacion = reg.Operacion != null
                            ? new Operacion
                            {
                                Id = reg.Operacion.Id,
                                Nombre = reg.Operacion.Nombre,
                                Descripcion = reg.Operacion.Descripcion,
                                OperacionTipoId = reg.Operacion.OperacionTipoId,
                                GrupoId = reg.Operacion.GrupoId,
                                LineaProduccionId = reg.Operacion.LineaProduccionId
                            }
                            : null,
                        Clase = reg.Clase != null
                            ? new Clase
                            {
                                CompaniaCodigo = reg.Clase.CompaniaCodigo,
                                Codigo = reg.Clase.Codigo,
                                ManejaInventario = reg.Clase.ManejaInventario,
                                Descripcion = reg.Clase.Descripcion,
                                CuentaContable = reg.Clase.CuentaContable,
                                RotacionBaja = reg.Clase.RotacionBaja,
                                SinRotacion = reg.Clase.SinRotacion,
                                Estado = reg.Clase.Estado,
                                DetalleMaestra = reg.Clase.DetalleMaestra,
                                AgrupacionCodigo = reg.Clase.AgrupacionCodigo,
                                GrupoNombre = reg.Clase.GrupoNombre
                            }
                            : null,
                        SubClase = reg.SubClase != null
                            ? new SubClase
                            {
                                CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                                Codigo = reg.SubClase.Codigo,
                                Descripcion = reg.SubClase.Descripcion,
                                Estado = reg.SubClase.Estado
                            }
                            : null,
                        InstruccionPredefinida = reg.InstruccionPredefinida != null
                            ? new InstruccionPredefinida
                            {
                                Id = reg.InstruccionPredefinida.Id,
                                OperacionPredefinidaId = reg.InstruccionPredefinida.OperacionPredefinidaId,
                                Descripcion = reg.InstruccionPredefinida.Descripcion,
                                Orden = reg.InstruccionPredefinida.Orden,
                                TiempoMaximo = reg.InstruccionPredefinida.TiempoMaximo,
                                TiempoMinimo = reg.InstruccionPredefinida.TiempoMinimo,
                                Temperatura = reg.InstruccionPredefinida.Temperatura
                            }
                            : null
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("IngredientePredefinido / GetByInstruccionPredefinida", exception);
            }
        }
        
        #endregion
    }
}