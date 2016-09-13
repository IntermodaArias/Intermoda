using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.LbDatPro.InasistenciaServiceReference;

namespace Intermoda.Client.LbDatPro
{
    public class Inasistencia : ObservableObject
    {
        private static InasistenciaClient _client;

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

        #region EmpleadoCodigo

        /// <summary>
        /// The <see cref="EmpleadoCodigo" /> property's name.
        /// </summary>
        public const string EmpleadoCodigoPropertyName = "EmpleadoCodigo";

        private int _empleadoCodigo;

        /// <summary>
        /// Sets and gets the EmpleadoCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int EmpleadoCodigo
        {
            get
            {
                return _empleadoCodigo;
            }

            set
            {
                if (_empleadoCodigo == value)
                {
                    return;
                }

                _empleadoCodigo = value;
                RaisePropertyChanged(EmpleadoCodigoPropertyName);
            }
        }

        #endregion

        #region Fecha

        /// <summary>
        /// The <see cref="Fecha" /> property's name.
        /// </summary>
        public const string FechaPropertyName = "Fecha";

        private DateTime _fecha;

        /// <summary>
        /// Sets and gets the Fecha property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }

            set
            {
                if (_fecha == value)
                {
                    return;
                }

                _fecha = value;
                RaisePropertyChanged(FechaPropertyName);
            }
        }

        #endregion

        #region MinutosConPermiso

        /// <summary>
        /// The <see cref="MinutosConPermiso" /> property's name.
        /// </summary>
        public const string MinutosConPermisoPropertyName = "MinutosConPermiso";

        private int _minutosConPermiso;

        /// <summary>
        /// Sets and gets the MinutosConPermiso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MinutosConPermiso
        {
            get
            {
                return _minutosConPermiso;
            }

            set
            {
                if (_minutosConPermiso == value)
                {
                    return;
                }

                _minutosConPermiso = value;
                RaisePropertyChanged(MinutosConPermisoPropertyName);
            }
        }

        #endregion

        #region MinutosSinPermiso

        /// <summary>
        /// The <see cref="MinutosSinPermiso" /> property's name.
        /// </summary>
        public const string MinutosSinPermisoPropertyName = "MinutosSinPermiso";

        private int _minutosSinPermiso;

        /// <summary>
        /// Sets and gets the MinutosSinPermiso property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int MinutosSinPermiso
        {
            get
            {
                return _minutosSinPermiso;
            }

            set
            {
                if (_minutosSinPermiso == value)
                {
                    return;
                }

                _minutosSinPermiso = value;
                RaisePropertyChanged(MinutosSinPermisoPropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<List<Inasistencia>> GetByFecha(DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (_client = new InasistenciaClient())
                {
                    var lista = await _client.GetByFechaAsync(fechaInicio, fechaFinal);

                    return lista.Select(model => new Inasistencia
                    {
                        CompaniaCodigo = model.CompaniaCodigo,
                        EmpleadoCodigo = model.EmpleadoCodigo,
                        Fecha = model.Fecha,
                        MinutosConPermiso = model.MinutosConPermiso,
                        MinutosSinPermiso = model.MinutosSinPermiso
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Inasistencia / GetByFecha", exception);
            }
        }

        public static async Task<List<Inasistencia>> GetByEmpleadoFecha(short companiaCodigo, int empleadoCodigo,
            DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (_client = new InasistenciaClient())
                {
                    var lista =
                        await
                            _client.GetByEmpleadoFechaAsync(companiaCodigo, empleadoCodigo, fechaInicio, fechaFinal);

                    return lista.Select(model => new Inasistencia
                    {
                        CompaniaCodigo = model.CompaniaCodigo,
                        EmpleadoCodigo = model.EmpleadoCodigo,
                        Fecha = model.Fecha,
                        MinutosConPermiso = model.MinutosConPermiso,
                        MinutosSinPermiso = model.MinutosSinPermiso
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Inasistencia / GetByEmpleadoFecha", exception);
            }
        }

        #endregion
    }
}