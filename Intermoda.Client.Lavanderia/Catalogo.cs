using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.CatalogoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Catalogo : ObservableObject
    {
        private static CatalogoClient _client;

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

        #region Descripcion

        /// <summary>
        /// The <see cref="Descripcion" /> property's name.
        /// </summary>
        public const string DescripcionPropertyName = "Descripcion";

        private string _descripcion;

        /// <summary>
        /// Sets and gets the Descripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }

            set
            {
                if (_descripcion == value)
                {
                    return;
                }

                _descripcion = value;
                RaisePropertyChanged(DescripcionPropertyName);
            }
        }

        #endregion

        #region MedidaCompraCodigo

        /// <summary>
        /// The <see cref="MedidaCompraCodigo" /> property's name.
        /// </summary>
        public const string MedidaCompraCodigoPropertyName = "MedidaCompraCodigo";

        private string _medidaCompraCodigo;

        /// <summary>
        /// Sets and gets the MedidaCompraCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MedidaCompraCodigo
        {
            get
            {
                return _medidaCompraCodigo;
            }

            set
            {
                if (_medidaCompraCodigo == value)
                {
                    return;
                }

                _medidaCompraCodigo = value;
                RaisePropertyChanged(MedidaCompraCodigoPropertyName);
            }
        }

        #endregion

        #region MedidaConsumoCodigo

        /// <summary>
        /// The <see cref="MedidaConsumoCodigo" /> property's name.
        /// </summary>
        public const string MedidaConsumoCodigoPropertyName = "MedidaConsumoCodigo";

        private string _medidaConsumoCodigo;

        /// <summary>
        /// Sets and gets the MedidaConsumoCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string MedidaConsumoCodigo
        {
            get
            {
                return _medidaConsumoCodigo;
            }

            set
            {
                if (_medidaConsumoCodigo == value)
                {
                    return;
                }

                _medidaConsumoCodigo = value;
                RaisePropertyChanged(MedidaConsumoCodigoPropertyName);
            }
        }

        #endregion

        #region TipoRequisicionCodigo

        /// <summary>
        /// The <see cref="TipoRequisicionCodigo" /> property's name.
        /// </summary>
        public const string TipoRequisicionCodigoPropertyName = "TipoRequisicionCodigo";

        private string _tipoRequisicionCodigo;

        /// <summary>
        /// Sets and gets the TipoRequisicionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TipoRequisicionCodigo
        {
            get
            {
                return _tipoRequisicionCodigo;
            }

            set
            {
                if (_tipoRequisicionCodigo == value)
                {
                    return;
                }

                _tipoRequisicionCodigo = value;
                RaisePropertyChanged(TipoRequisicionCodigoPropertyName);
            }
        }

        #endregion

        #region GrupoCodigo

        /// <summary>
        /// The <see cref="GrupoCodigo" /> property's name.
        /// </summary>
        public const string GrupoCodigoPropertyName = "GrupoCodigo";

        private string _grupoCodigo;

        /// <summary>
        /// Sets and gets the GrupoCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string GrupoCodigo
        {
            get
            {
                return _grupoCodigo;
            }

            set
            {
                if (_grupoCodigo == value)
                {
                    return;
                }

                _grupoCodigo = value;
                RaisePropertyChanged(GrupoCodigoPropertyName);
            }
        }

        #endregion

        #region TelaCodigo

        /// <summary>
        /// The <see cref="TelaCodigo" /> property's name.
        /// </summary>
        public const string TelaCodigoPropertyName = "TelaCodigo";

        private string _telaCodigo;

        /// <summary>
        /// Sets and gets the TelaCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaCodigo
        {
            get
            {
                return _telaCodigo;
            }

            set
            {
                if (_telaCodigo == value)
                {
                    return;
                }

                _telaCodigo = value;
                RaisePropertyChanged(TelaCodigoPropertyName);
            }
        }

        #endregion

        #region CuentaContableCodigo

        /// <summary>
        /// The <see cref="CuentaContableCodigo" /> property's name.
        /// </summary>
        public const string CuentaContableCodigoPropertyName = "CuentaContableCodigo";

        private string _cuentaContableCodigo;

        /// <summary>
        /// Sets and gets the CuentaContableCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CuentaContableCodigo
        {
            get
            {
                return _cuentaContableCodigo;
            }

            set
            {
                if (_cuentaContableCodigo == value)
                {
                    return;
                }

                _cuentaContableCodigo = value;
                RaisePropertyChanged(CuentaContableCodigoPropertyName);
            }
        }

        #endregion

        #region CuentaVariableFija

        /// <summary>
        /// The <see cref="CuentaVariableFija" /> property's name.
        /// </summary>
        public const string CuentaVariableFijaPropertyName = "CuentaVariableFija";

        private string _cuentaVariableFija;

        /// <summary>
        /// Sets and gets the CuentaVariableFija property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CuentaVariableFija
        {
            get
            {
                return _cuentaVariableFija;
            }

            set
            {
                if (_cuentaVariableFija == value)
                {
                    return;
                }

                _cuentaVariableFija = value;
                RaisePropertyChanged(CuentaVariableFijaPropertyName);
            }
        }

        #endregion

        #region CuentaContableInventarioCodigo

        /// <summary>
        /// The <see cref="CuentaContableInventarioCodigo" /> property's name.
        /// </summary>
        public const string CuentaContableInventarioCodigoPropertyName = "CuentaContableInventarioCodigo";

        private string _cuentaContableInventarioCodigo;

        /// <summary>
        /// Sets and gets the CuentaContableInventarioCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CuentaContableInventarioCodigo
        {
            get
            {
                return _cuentaContableInventarioCodigo;
            }

            set
            {
                if (_cuentaContableInventarioCodigo == value)
                {
                    return;
                }

                _cuentaContableInventarioCodigo = value;
                RaisePropertyChanged(CuentaContableInventarioCodigoPropertyName);
            }
        }

        #endregion

        #region RepuestoNumero

        /// <summary>
        /// The <see cref="RepuestoNumero" /> property's name.
        /// </summary>
        public const string RepuestoNumeroPropertyName = "RepuestoNumero";

        private string _repuestoNumero;

        /// <summary>
        /// Sets and gets the RepuestoNumero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string RepuestoNumero
        {
            get
            {
                return _repuestoNumero;
            }

            set
            {
                if (_repuestoNumero == value)
                {
                    return;
                }

                _repuestoNumero = value;
                RaisePropertyChanged(RepuestoNumeroPropertyName);
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


        #region Clase

        /// <summary>
        /// The <see cref="Clase" /> property's name.
        /// </summary>
        public const string ClasePropertyName = "Clase";

        private Clase _clase;

        /// <summary>
        /// Sets and gets the Clase property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Clase Clase
        {
            get
            {
                return _clase;
            }

            set
            {
                if (_clase == value)
                {
                    return;
                }

                _clase = value;
                RaisePropertyChanged(ClasePropertyName);
            }
        }

        #endregion

        #region SubClase

        /// <summary>
        /// The <see cref="SubClase" /> property's name.
        /// </summary>
        public const string SubClasePropertyName = "SubClase";

        private SubClase _subClase;

        /// <summary>
        /// Sets and gets the SubClase property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SubClase SubClase
        {
            get
            {
                return _subClase;
            }

            set
            {
                if (_subClase == value)
                {
                    return;
                }

                _subClase = value;
                RaisePropertyChanged(SubClasePropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<Catalogo> Update(Catalogo catalogo)
        {
            try
            {
                using (_client = new CatalogoClient())
                {
                    var reg = new CatalogoBusiness
                    {
                        Id = catalogo.Id,
                        Nombre = catalogo.Nombre,
                        Descripcion = catalogo.Descripcion,
                        MedidaCompraCodigo = catalogo.MedidaCompraCodigo,
                        MedidaConsumoCodigo = catalogo.MedidaConsumoCodigo,
                        TipoRequisicionCodigo = catalogo.TipoRequisicionCodigo,
                        GrupoCodigo = catalogo.GrupoCodigo,
                        TelaCodigo = catalogo.TelaCodigo,
                        CuentaContableCodigo = catalogo.CuentaContableCodigo,
                        CuentaVariableFija = catalogo.CuentaVariableFija,
                        CuentaContableInventarioCodigo = catalogo.CuentaContableInventarioCodigo,
                        RepuestoNumero = catalogo.RepuestoNumero
                    };

                    reg = await _client.UpdateAsync(reg);
                    
                    return new Catalogo
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        MedidaConsumoCodigo = reg.MedidaConsumoCodigo,
                        MedidaCompraCodigo = reg.MedidaCompraCodigo,
                        TipoRequisicionCodigo = reg.TipoRequisicionCodigo,
                        GrupoCodigo = reg.GrupoCodigo,
                        TelaCodigo = reg.TelaCodigo,
                        CuentaContableCodigo = reg.CuentaContableCodigo,
                        CuentaVariableFija = reg.CuentaVariableFija,
                        CuentaContableInventarioCodigo = reg.CuentaContableInventarioCodigo,
                        RepuestoNumero = reg.RepuestoNumero,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
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
                            DiasSinMovimiento = reg.Clase.DiasSinMovimiento,
                            AgruparEnClaseCodigo = reg.Clase.AgruparEnClaseCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo / Update", exception);
            }
        }

        public static async Task Delete(int ingredienteId)
        {
            try
            {
                using (_client = new CatalogoClient())
                {
                    await _client.DeleteAsync(ingredienteId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo / Delete", exception);
            }
        }

        public static async Task<Catalogo> Get(int ingredienteId)
        {
            try
            {
                using (_client = new CatalogoClient())
                {
                    var reg = await _client.GetAsync(ingredienteId);

                    return new Catalogo
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        MedidaConsumoCodigo = reg.MedidaConsumoCodigo,
                        MedidaCompraCodigo = reg.MedidaCompraCodigo,
                        TipoRequisicionCodigo = reg.TipoRequisicionCodigo,
                        GrupoCodigo = reg.GrupoCodigo,
                        TelaCodigo = reg.TelaCodigo,
                        CuentaContableCodigo = reg.CuentaContableCodigo,
                        CuentaVariableFija = reg.CuentaVariableFija,
                        CuentaContableInventarioCodigo = reg.CuentaContableInventarioCodigo,
                        RepuestoNumero = reg.RepuestoNumero,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
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
                            DiasSinMovimiento = reg.Clase.DiasSinMovimiento,
                            AgruparEnClaseCodigo = reg.Clase.AgruparEnClaseCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo / Get", exception);
            }
        }

        public static async Task<List<Catalogo>> GetAll()
        {
            try
            {
                using (_client = new CatalogoClient())
                {
                    var lista = await _client.GetAllAsync();

                    return (lista.Select(reg => new Catalogo
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        MedidaConsumoCodigo = reg.MedidaConsumoCodigo,
                        MedidaCompraCodigo = reg.MedidaCompraCodigo,
                        TipoRequisicionCodigo = reg.TipoRequisicionCodigo,
                        GrupoCodigo = reg.GrupoCodigo,
                        TelaCodigo = reg.TelaCodigo,
                        CuentaContableCodigo = reg.CuentaContableCodigo,
                        CuentaVariableFija = reg.CuentaVariableFija,
                        CuentaContableInventarioCodigo = reg.CuentaContableInventarioCodigo,
                        RepuestoNumero = reg.RepuestoNumero,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
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
                            DiasSinMovimiento = reg.Clase.DiasSinMovimiento,
                            AgruparEnClaseCodigo = reg.Clase.AgruparEnClaseCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        }
                    })).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo / GetAll", exception);
            }
        }

        public static async Task<Catalogo> GetByTela(string telaId)
        {
            try
            {
                using (_client = new CatalogoClient())
                {
                    var reg = await _client.GetByTelaAsync(telaId);

                    return new Catalogo
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        MedidaConsumoCodigo = reg.MedidaConsumoCodigo,
                        MedidaCompraCodigo = reg.MedidaCompraCodigo,
                        TipoRequisicionCodigo = reg.TipoRequisicionCodigo,
                        GrupoCodigo = reg.GrupoCodigo,
                        TelaCodigo = reg.TelaCodigo,
                        CuentaContableCodigo = reg.CuentaContableCodigo,
                        CuentaVariableFija = reg.CuentaVariableFija,
                        CuentaContableInventarioCodigo = reg.CuentaContableInventarioCodigo,
                        RepuestoNumero = reg.RepuestoNumero,
                        ClaseId = reg.ClaseId,
                        SubClaseId = reg.SubClaseId,
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
                            DiasSinMovimiento = reg.Clase.DiasSinMovimiento,
                            AgruparEnClaseCodigo = reg.Clase.AgruparEnClaseCodigo,
                            GrupoNombre = reg.Clase.GrupoNombre
                        },
                        SubClase = new SubClase
                        {
                            CompaniaCodigo = reg.SubClase.CompaniaCodigo,
                            Codigo = reg.SubClase.Codigo,
                            Descripcion = reg.SubClase.Descripcion,
                            Estado = reg.SubClase.Estado
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo / Get", exception);
            }
        }

        #endregion
    }
}