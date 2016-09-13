using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lectura.LineaDetalleServiceReference;

namespace Intermoda.Client.Lectura
{
    public class LineaDetalle : ObservableObject
    {
        private static LineaDetalleClient _client;

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

        #region LineaId

        /// <summary>
        /// The <see cref="LineaId" /> property's name.
        /// </summary>
        public const string LineaIdPropertyName = "LineaId";

        private int _lineaId;

        /// <summary>
        /// Sets and gets the LineaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LineaId
        {
            get
            {
                return _lineaId;
            }

            set
            {
                if (_lineaId == value)
                {
                    return;
                }

                _lineaId = value;
                RaisePropertyChanged(LineaIdPropertyName);
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

        #region EsSalidaUnica

        /// <summary>
        /// The <see cref="EsSalidaUnica" /> property's name.
        /// </summary>
        public const string EsSalidaUnicaPropertyName = "EsSalidaUnica";

        private bool _esSalidaUnica;

        /// <summary>
        /// Sets and gets the EsSalidaUnica property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool EsSalidaUnica
        {
            get
            {
                return _esSalidaUnica;
            }

            set
            {
                if (_esSalidaUnica == value)
                {
                    return;
                }

                _esSalidaUnica = value;
                RaisePropertyChanged(EsSalidaUnicaPropertyName);
            }
        }

        #endregion

        #region Secuencia

        /// <summary>
        /// The <see cref="Secuencia" /> property's name.
        /// </summary>
        public const string SecuenciaPropertyName = "Secuencia";

        private int _secuencia;

        /// <summary>
        /// Sets and gets the Secuencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Secuencia
        {
            get
            {
                return _secuencia;
            }

            set
            {
                if (_secuencia == value)
                {
                    return;
                }

                _secuencia = value;
                RaisePropertyChanged(SecuenciaPropertyName);
            }
        }

        #endregion

        public CentroTrabajo CentroTrabajo { get; set; }

        public Modulo Modulo { get; set; }

        #endregion

        #region Methods

        public static async Task<LineaDetalle> Update(LineaDetalle reg)
        {
            try
            {
                using (_client = new LineaDetalleClient())
                {
                    var business = new LineaDetalleBusiness
                    {
                        Id = reg.Id,
                        LineaId = reg.LineaId,
                        CentroTrabajoId = reg.CentroTrabajoId,
                        ModuloId = reg.ModuloId,
                        EsSalidaUnica = reg.EsSalidaUnica,
                        Secuencia = reg.Secuencia
                    };

                    var model = await _client.UpdateAsync(business);

                    return new LineaDetalle
                    {
                        Id = model.Id,
                        LineaId = model.LineaId,
                        CentroTrabajoId = model.CentroTrabajoId,
                        ModuloId = model.ModuloId,
                        EsSalidaUnica = model.EsSalidaUnica,
                        Secuencia = model.Secuencia
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle / Update", exception);
            }
        }

        public static async Task Delete(int lineaDetalleId)
        {
            try
            {
                using (_client = new LineaDetalleClient())
                {
                    await _client.DeleteAsync(lineaDetalleId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle / Delete", exception);
            }
        }

        public static async Task<List<LineaDetalle>> GetByLinea(int lineaId)
        {
            try
            {
                using (_client = new LineaDetalleClient())
                {
                    var lista = await _client.GetByLineaAsync(lineaId);
                    return lista.Select(model => new LineaDetalle
                    {
                        Id = model.Id,
                        LineaId = model.LineaId,
                        CentroTrabajoId = model.CentroTrabajoId,
                        ModuloId = model.ModuloId,
                        EsSalidaUnica = model.EsSalidaUnica,
                        Secuencia = model.Secuencia,
                        CentroTrabajo = new CentroTrabajo
                        {
                            Id = model.CentroTrabajo.Id,
                            Codigo = model.CentroTrabajo.Codigo,
                            Nombre = model.CentroTrabajo.Nombre,
                            Secuencia = model.CentroTrabajo.Secuencia,
                            Estado = model.CentroTrabajo.Estado
                        },
                        Modulo = new Modulo
                        {
                            Id = model.Modulo.Id,
                            Codigo = model.Modulo.Codigo,
                            Nombre = model.Modulo.Nombre,
                            Secuencia = model.Modulo.Secuencia,
                            Estado = model.Modulo.Estado
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("LineaDetalle / GetByLinea", exception);
            }
        }

        #endregion
    }
}