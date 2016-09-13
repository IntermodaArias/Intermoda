using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.OperacionServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class Operacion : ObservableObject
    {
        private static OperacionClient _client;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private short _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Id
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

        #region OperacionTipoId

        /// <summary>
        /// The <see cref="OperacionTipoId" /> property's name.
        /// </summary>
        public const string OperacionTipoIdPropertyName = "OperacionTipoId";

        private short _operacionTipoId;

        /// <summary>
        /// Sets and gets the OperacionTipoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short OperacionTipoId
        {
            get
            {
                return _operacionTipoId;
            }

            set
            {
                if (_operacionTipoId == value)
                {
                    return;
                }

                _operacionTipoId = value;
                RaisePropertyChanged(OperacionTipoIdPropertyName);
            }
        }

        #endregion

        #region GrupoId

        /// <summary>
        /// The <see cref="GrupoId" /> property's name.
        /// </summary>
        public const string GrupoIdPropertyName = "GrupoId";

        private short _grupoId;

        /// <summary>
        /// Sets and gets the GrupoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short GrupoId
        {
            get
            {
                return _grupoId;
            }

            set
            {
                if (_grupoId == value)
                {
                    return;
                }

                _grupoId = value;
                RaisePropertyChanged(GrupoIdPropertyName);
            }
        }

        #endregion

        #region LineaProduccionId

        /// <summary>
        /// The <see cref="LineaProduccionId" /> property's name.
        /// </summary>
        public const string LineaProduccionIdPropertyName = "LineaProduccionId";

        private int _lineaProduccionId;

        /// <summary>
        /// Sets and gets the LineaProduccionId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LineaProduccionId
        {
            get
            {
                return _lineaProduccionId;
            }

            set
            {
                if (_lineaProduccionId == value)
                {
                    return;
                }

                _lineaProduccionId = value;
                RaisePropertyChanged(LineaProduccionIdPropertyName);
            }
        }

        #endregion

        public OperacionPredefinida OperacionPredefinida { get; set; }

        #endregion

        #region Methods

        public static async Task<Operacion> Update(Operacion operacion)
        {
            try
            {
                using (_client = new OperacionClient())
                {
                    var reg = new OperacionBusiness
                    {
                        Id = operacion.Id,
                        Nombre = operacion.Nombre,
                        Descripcion = operacion.Descripcion,
                        OperacionTipoId = operacion.OperacionTipoId,
                        GrupoId = operacion.GrupoId,
                        LineaProduccionId = operacion.LineaProduccionId
                    };

                    reg = await _client.UpdateAsync(reg);

                    return new Operacion
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        OperacionTipoId = reg.OperacionTipoId,
                        GrupoId = reg.GrupoId,
                        LineaProduccionId = reg.LineaProduccionId,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OperacionPredefinida.Id,
                            OperacionId = reg.OperacionPredefinida.OperacionId,
                            RelacionBano = reg.OperacionPredefinida.RelacionBano,
                            Secuencia = reg.OperacionPredefinida.Secuencia,
                            TiempoMinimo = reg.OperacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OperacionPredefinida.TiempoMaximo,
                            Temperatura = reg.OperacionPredefinida.Temperatura
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / Update", exception);
            }
        }

        public static async Task Delete(int opeacionId)
        {
            try
            {
                using (_client = new OperacionClient())
                {
                    await _client.DeleteAsync(opeacionId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / Delete", exception);
            }
        }

        public static async Task<Operacion> Get(int operacionId)
        {
            try
            {
                using (_client = new OperacionClient())
                {
                    var reg = await _client.GetAsync(operacionId);

                    return new Operacion
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        OperacionTipoId = reg.OperacionTipoId,
                        GrupoId = reg.GrupoId,
                        LineaProduccionId = reg.LineaProduccionId,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OperacionPredefinida.Id,
                            OperacionId = reg.OperacionPredefinida.OperacionId,
                            RelacionBano = reg.OperacionPredefinida.RelacionBano,
                            Secuencia = reg.OperacionPredefinida.Secuencia,
                            Ph = reg.OperacionPredefinida.Ph,
                            TiempoMinimo = reg.OperacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OperacionPredefinida.TiempoMaximo,
                            Temperatura = reg.OperacionPredefinida.Temperatura
                        }
                    };
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / Get", exception);
            }
        }

        public static async Task<List<Operacion>> GetAll()
        {
            try
            {
                using (_client = new OperacionClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(reg => new Operacion
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        OperacionTipoId = reg.OperacionTipoId,
                        GrupoId = reg.GrupoId,
                        LineaProduccionId = reg.LineaProduccionId,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OperacionPredefinida.Id,
                            OperacionId = reg.OperacionPredefinida.OperacionId,
                            RelacionBano = reg.OperacionPredefinida.RelacionBano,
                            Secuencia = reg.OperacionPredefinida.Secuencia,
                            Ph = reg.OperacionPredefinida.Ph,
                            TiempoMinimo = reg.OperacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OperacionPredefinida.TiempoMaximo,
                            Temperatura = reg.OperacionPredefinida.Temperatura
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetAll", exception);
            }
        }

        public static async Task<List<Operacion>> GetAllLavanderia()
        {
            try
            {
                using (_client = new OperacionClient())
                {
                    var lista = await _client.GetAllLavanderiaAsync();

                    return lista.Select(reg => new Operacion
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        OperacionTipoId = reg.OperacionTipoId,
                        GrupoId = reg.GrupoId,
                        LineaProduccionId = reg.LineaProduccionId,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OperacionPredefinida.Id,
                            OperacionId = reg.OperacionPredefinida.OperacionId,
                            RelacionBano = reg.OperacionPredefinida.RelacionBano,
                            Secuencia = reg.OperacionPredefinida.Secuencia,
                            Ph = reg.OperacionPredefinida.Ph,
                            TiempoMinimo = reg.OperacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OperacionPredefinida.TiempoMaximo,
                            Temperatura = reg.OperacionPredefinida.Temperatura
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetAllLavanderia", exception);
            }
        }

        public static async Task<List<Operacion>> GetOperacionesHumedas(int centroTrabajoId)
        {
            try
            {
                using (_client = new OperacionClient())
                {
                    var lista = await _client.GetHumedasAsync(centroTrabajoId);

                    return lista.Select(reg => new Operacion
                    {
                        Id = reg.Id,
                        Nombre = reg.Nombre,
                        Descripcion = reg.Descripcion,
                        OperacionTipoId = reg.OperacionTipoId,
                        GrupoId = reg.GrupoId,
                        LineaProduccionId = reg.LineaProduccionId,
                        OperacionPredefinida = new OperacionPredefinida
                        {
                            Id = reg.OperacionPredefinida.Id,
                            OperacionId = reg.OperacionPredefinida.OperacionId,
                            RelacionBano = reg.OperacionPredefinida.RelacionBano,
                            Secuencia = reg.OperacionPredefinida.Secuencia,
                            Ph = reg.OperacionPredefinida.Ph,
                            TiempoMinimo = reg.OperacionPredefinida.TiempoMinimo,
                            TiempoMaximo = reg.OperacionPredefinida.TiempoMaximo,
                            Temperatura = reg.OperacionPredefinida.Temperatura
                        }
                    }).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Operacion / GetOperacionesHumedas", exception);
            }
        }

        #endregion
    }
}