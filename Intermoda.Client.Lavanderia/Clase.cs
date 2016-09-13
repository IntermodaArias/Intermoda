using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.ClaseServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Clase : ObservableObject
    {
        private static ClaseClient _client; 

        #region Properties

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

        #region Codigo

        /// <summary>
        /// The <see cref="Codigo" /> property's name.
        /// </summary>
        public const string CodigoPropertyName = "Codigo";

        private string _codigo;

        /// <summary>
        /// Sets and gets the Codigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Codigo
        {
            get
            {
                return _codigo;
            }

            set
            {
                if (_codigo == value)
                {
                    return;
                }

                _codigo = value;
                RaisePropertyChanged(CodigoPropertyName);
            }
        }

        #endregion

        #region ManejaInventario

        /// <summary>
        /// The <see cref="ManejaInventario" /> property's name.
        /// </summary>
        public const string ManejaInventarioPropertyName = "ManejaInventario";

        private string _manejaInventario;

        /// <summary>
        /// Sets and gets the ManejaInventario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ManejaInventario
        {
            get
            {
                return _manejaInventario;
            }

            set
            {
                if (_manejaInventario == value)
                {
                    return;
                }

                _manejaInventario = value;
                RaisePropertyChanged(ManejaInventarioPropertyName);
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

        #region CuentaContable

        /// <summary>
        /// The <see cref="CuentaContable" /> property's name.
        /// </summary>
        public const string CuentaContablePropertyName = "CuentaContable";

        private string _cuentaContable;

        /// <summary>
        /// Sets and gets the CuentaContable property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CuentaContable
        {
            get
            {
                return _cuentaContable;
            }

            set
            {
                if (_cuentaContable == value)
                {
                    return;
                }

                _cuentaContable = value;
                RaisePropertyChanged(CuentaContablePropertyName);
            }
        }

        #endregion

        #region RotacionBaja

        /// <summary>
        /// The <see cref="RotacionBaja" /> property's name.
        /// </summary>
        public const string RotacionBajaPropertyName = "RotacionBaja";

        private short? _rotacionBaja;

        /// <summary>
        /// Sets and gets the RotacionBaja property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? RotacionBaja
        {
            get
            {
                return _rotacionBaja;
            }

            set
            {
                if (_rotacionBaja == value)
                {
                    return;
                }

                _rotacionBaja = value;
                RaisePropertyChanged(RotacionBajaPropertyName);
            }
        }

        #endregion

        #region SinRotacion

        /// <summary>
        /// The <see cref="SinRotacion" /> property's name.
        /// </summary>
        public const string SinRotacionPropertyName = "SinRotacion";

        private short? _sinRotacion;

        /// <summary>
        /// Sets and gets the SinRotacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? SinRotacion
        {
            get
            {
                return _sinRotacion;
            }

            set
            {
                if (_sinRotacion == value)
                {
                    return;
                }

                _sinRotacion = value;
                RaisePropertyChanged(SinRotacionPropertyName);
            }
        }

        #endregion

        #region Estado

        /// <summary>
        /// The <see cref="Estado" /> property's name.
        /// </summary>
        public const string EstadoPropertyName = "Estado";

        private string _estado;

        /// <summary>
        /// Sets and gets the Estado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Estado
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

        #region DetalleMaestra

        /// <summary>
        /// The <see cref="DetalleMaestra" /> property's name.
        /// </summary>
        public const string DetalleMaestraPropertyName = "DetalleMaestra";

        private string _detalleMaestra;

        /// <summary>
        /// Sets and gets the DetalleMaestra property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DetalleMaestra
        {
            get
            {
                return _detalleMaestra;
            }

            set
            {
                if (_detalleMaestra == value)
                {
                    return;
                }

                _detalleMaestra = value;
                RaisePropertyChanged(DetalleMaestraPropertyName);
            }
        }

        #endregion

        #region AgrupacionCodigo

        /// <summary>
        /// The <see cref="AgrupacionCodigo" /> property's name.
        /// </summary>
        public const string AgrupacionCodigoPropertyName = "AgrupacionCodigo";

        private short? _agrupacionCodigo;

        /// <summary>
        /// Sets and gets the AgrupacionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? AgrupacionCodigo
        {
            get
            {
                return _agrupacionCodigo;
            }

            set
            {
                if (_agrupacionCodigo == value)
                {
                    return;
                }

                _agrupacionCodigo = value;
                RaisePropertyChanged(AgrupacionCodigoPropertyName);
            }
        }

        #endregion

        #region DiasSinMovimiento

        /// <summary>
        /// The <see cref="DiasSinMovimiento" /> property's name.
        /// </summary>
        public const string DiasSinMovimientoPropertyName = "DiasSinMovimiento";

        private short _diasSinMovimiento;

        /// <summary>
        /// Sets and gets the DiasSinMovimiento property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short DiasSinMovimiento
        {
            get
            {
                return _diasSinMovimiento;
            }

            set
            {
                if (_diasSinMovimiento == value)
                {
                    return;
                }

                _diasSinMovimiento = value;
                RaisePropertyChanged(DiasSinMovimientoPropertyName);
            }
        }

        #endregion

        #region AgruparEnClaseCodigo

        /// <summary>
        /// The <see cref="AgruparEnClaseCodigo" /> property's name.
        /// </summary>
        public const string AgruparEnClaseCodigoPropertyName = "AgruparEnClaseCodigo";

        private string _agruparEnClaseCodigo;

        /// <summary>
        /// Sets and gets the AgruparEnClaseCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string AgruparEnClaseCodigo
        {
            get
            {
                return _agruparEnClaseCodigo;
            }

            set
            {
                if (_agruparEnClaseCodigo == value)
                {
                    return;
                }

                _agruparEnClaseCodigo = value;
                RaisePropertyChanged(AgruparEnClaseCodigoPropertyName);
            }
        }

        #endregion

        #region GrupoNombre

        /// <summary>
        /// The <see cref="GrupoNombre" /> property's name.
        /// </summary>
        public const string GrupoNombrePropertyName = "GrupoNombre";

        private string _grupoNombre;

        /// <summary>
        /// Sets and gets the GrupoNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string GrupoNombre
        {
            get
            {
                return _grupoNombre;
            }

            set
            {
                if (_grupoNombre == value)
                {
                    return;
                }

                _grupoNombre = value;
                RaisePropertyChanged(GrupoNombrePropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<Clase> Update(Clase clase)
        {
            try
            {
                using (_client = new ClaseClient())
                {
                    var reg = new ClaseBusiness
                    {
                        CompaniaCodigo = clase.CompaniaCodigo,
                        Codigo = clase.Codigo,
                        ManejaInventario = clase.ManejaInventario,
                        Descripcion = clase.Descripcion,
                        CuentaContable = clase.CuentaContable,
                        RotacionBaja = clase.RotacionBaja,
                        SinRotacion = clase.SinRotacion,
                        Estado = clase.Estado,
                        DetalleMaestra = clase.DetalleMaestra,
                        AgrupacionCodigo = clase.AgrupacionCodigo,
                        DiasSinMovimiento = clase.DiasSinMovimiento,
                        AgruparEnClaseCodigo = clase.AgruparEnClaseCodigo,
                        GrupoNombre = clase.GrupoNombre
                    };

                    reg = await _client.UpdateAsync(reg);

                    return new Clase
                    {
                        CompaniaCodigo = reg.CompaniaCodigo,
                        Codigo = reg.Codigo,
                        ManejaInventario = reg.ManejaInventario,
                        Descripcion = reg.Descripcion,
                        CuentaContable = reg.CuentaContable,
                        RotacionBaja = reg.RotacionBaja,
                        SinRotacion = reg.SinRotacion,
                        Estado = reg.Estado,
                        DetalleMaestra = reg.DetalleMaestra,
                        AgrupacionCodigo = reg.AgrupacionCodigo,
                        GrupoNombre = reg.GrupoNombre
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Clase / Update", exception);
            }
        }

        public static async Task Delete(string claseCodigo)
        {
            try
            {
                using (_client = new ClaseClient())
                {
                    await _client.DeleteAsync(claseCodigo);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Clase / Delete", exception);
            }
        }

        public static async Task<Clase> Get(string claseCodigo)
        {
            try
            {
                using (_client = new ClaseClient())
                {
                    var reg = await _client.GetAsync(claseCodigo);

                    return new Clase
                    {
                        CompaniaCodigo = reg.CompaniaCodigo,
                        Codigo = reg.Codigo,
                        ManejaInventario = reg.ManejaInventario,
                        Descripcion = reg.Descripcion,
                        CuentaContable = reg.CuentaContable,
                        RotacionBaja = reg.RotacionBaja,
                        SinRotacion = reg.SinRotacion,
                        Estado = reg.Estado,
                        DetalleMaestra = reg.DetalleMaestra,
                        AgrupacionCodigo = reg.AgrupacionCodigo,
                        GrupoNombre = reg.GrupoNombre
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Clase / Get", exception);
            }
        }

        public static async Task<List<Clase>> GetAll()
        {
            try
            {
                using (_client = new ClaseClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(reg => new Clase
                    {
                        CompaniaCodigo = reg.CompaniaCodigo,
                        Codigo = reg.Codigo,
                        ManejaInventario = reg.ManejaInventario,
                        Descripcion = reg.Descripcion,
                        CuentaContable = reg.CuentaContable,
                        RotacionBaja = reg.RotacionBaja,
                        SinRotacion = reg.SinRotacion,
                        Estado = reg.Estado,
                        DetalleMaestra = reg.DetalleMaestra,
                        AgrupacionCodigo = reg.AgrupacionCodigo,
                        GrupoNombre = reg.GrupoNombre
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Clase / GetAll", exception);
            }
        }

        #endregion
    }
}