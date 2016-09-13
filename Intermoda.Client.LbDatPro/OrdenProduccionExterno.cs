using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.LbDatPro.OrdenProduccionExternoServiceReference;

namespace Intermoda.Client.LbDatPro
{
    public class OrdenProduccionExterno : ObservableObject
    {
        private static OrdenProduccionExternoClient _client;

        #region Properties

        #region CompaniaId

        /// <summary>
        /// The <see cref="CompaniaId" /> property's name.
        /// </summary>
        public const string CompaniaIdPropertyName = "CompaniaId";

        private short _companiaId;

        /// <summary>
        /// Sets and gets the CompaniaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short CompaniaId
        {
            get
            {
                return _companiaId;
            }

            set
            {
                if (_companiaId == value)
                {
                    return;
                }

                _companiaId = value;
                RaisePropertyChanged(CompaniaIdPropertyName);
            }
        }

        #endregion

        #region Ano

        /// <summary>
        /// The <see cref="Ano" /> property's name.
        /// </summary>
        public const string AnoPropertyName = "Ano";

        private short _ano;

        /// <summary>
        /// Sets and gets the Ano property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Ano
        {
            get
            {
                return _ano;
            }

            set
            {
                if (_ano == value)
                {
                    return;
                }

                _ano = value;
                RaisePropertyChanged(AnoPropertyName);
            }
        }

        #endregion

        #region Numero

        /// <summary>
        /// The <see cref="Numero" /> property's name.
        /// </summary>
        public const string NumeroPropertyName = "Numero";

        private short _numero;

        /// <summary>
        /// Sets and gets the Numero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Numero
        {
            get
            {
                return _numero;
            }

            set
            {
                if (_numero == value)
                {
                    return;
                }

                _numero = value;
                RaisePropertyChanged(NumeroPropertyName);
            }
        }

        #endregion

        #region Patron

        /// <summary>
        /// The <see cref="Patron" /> property's name.
        /// </summary>
        public const string PatronPropertyName = "Patron";

        private string _patron;

        /// <summary>
        /// Sets and gets the Patron property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Patron
        {
            get
            {
                return _patron;
            }

            set
            {
                if (_patron == value)
                {
                    return;
                }

                _patron = value;
                RaisePropertyChanged(PatronPropertyName);
            }
        }

        #endregion

        #region Variante

        /// <summary>
        /// The <see cref="Variante" /> property's name.
        /// </summary>
        public const string VariantePropertyName = "Variante";

        private string _variante;

        /// <summary>
        /// Sets and gets the Variante property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Variante
        {
            get
            {
                return _variante;
            }

            set
            {
                if (_variante == value)
                {
                    return;
                }

                _variante = value;
                RaisePropertyChanged(VariantePropertyName);
            }
        }

        #endregion

        #region Tela

        /// <summary>
        /// The <see cref="Tela" /> property's name.
        /// </summary>
        public const string TelaPropertyName = "Tela";

        private string _tela;

        /// <summary>
        /// Sets and gets the Tela property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Tela
        {
            get
            {
                return _tela;
            }

            set
            {
                if (_tela == value)
                {
                    return;
                }

                _tela = value;
                RaisePropertyChanged(TelaPropertyName);
            }
        }

        #endregion

        #region Lavado

        /// <summary>
        /// The <see cref="Lavado" /> property's name.
        /// </summary>
        public const string LavadoPropertyName = "Lavado";

        private string _lavado;

        /// <summary>
        /// Sets and gets the Lavado property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Lavado
        {
            get
            {
                return _lavado;
            }

            set
            {
                if (_lavado == value)
                {
                    return;
                }

                _lavado = value;
                RaisePropertyChanged(LavadoPropertyName);
            }
        }

        #endregion

        #region Color

        /// <summary>
        /// The <see cref="Color" /> property's name.
        /// </summary>
        public const string ColorPropertyName = "Color";

        private string _color;

        /// <summary>
        /// Sets and gets the Color property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Color
        {
            get
            {
                return _color;
            }

            set
            {
                if (_color == value)
                {
                    return;
                }

                _color = value;
                RaisePropertyChanged(ColorPropertyName);
            }
        }

        #endregion

        #region ColorDescripcion

        /// <summary>
        /// The <see cref="ColorDescripcion" /> property's name.
        /// </summary>
        public const string ColorDescripcionPropertyName = "ColorDescripcion";

        private string _colorDescripcion;

        /// <summary>
        /// Sets and gets the ColorDescripcion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ColorDescripcion
        {
            get
            {
                return _colorDescripcion;
            }

            set
            {
                if (_colorDescripcion == value)
                {
                    return;
                }

                _colorDescripcion = value;
                RaisePropertyChanged(ColorDescripcionPropertyName);
            }
        }

        #endregion

        #region EstadoId

        /// <summary>
        /// The <see cref="EstadoId" /> property's name.
        /// </summary>
        public const string EstadoIdPropertyName = "EstadoId";

        private string _estadoId;

        /// <summary>
        /// Sets and gets the EstadoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string EstadoId
        {
            get
            {
                return _estadoId;
            }

            set
            {
                if (_estadoId == value)
                {
                    return;
                }

                _estadoId = value;
                RaisePropertyChanged(EstadoIdPropertyName);
            }
        }

        #endregion

        #region Cantidad

        /// <summary>
        /// The <see cref="Cantidad" /> property's name.
        /// </summary>
        public const string CantidadPropertyName = "Cantidad";

        private int _cantidad;

        /// <summary>
        /// Sets and gets the Cantidad property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int Cantidad
        {
            get
            {
                return _cantidad;
            }

            set
            {
                if (_cantidad == value)
                {
                    return;
                }

                _cantidad = value;
                RaisePropertyChanged(CantidadPropertyName);
            }
        }

        #endregion

        #region OrdenProduccion

        /// <summary>
        /// The <see cref="OrdenProduccion" /> property's name.
        /// </summary>
        public const string OrdenProduccionPropertyName = "OrdenProduccion";

        private string _ordenProduccion;

        /// <summary>
        /// Sets and gets the OrdenProduccion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string OrdenProduccion
        {
            get
            {
                return _ordenProduccion;
            }

            set
            {
                if (_ordenProduccion == value)
                {
                    return;
                }

                _ordenProduccion = value;
                RaisePropertyChanged(OrdenProduccionPropertyName);
            }
        }

        #endregion

        #region Referencia

        /// <summary>
        /// The <see cref="Referencia" /> property's name.
        /// </summary>
        public const string ReferenciaPropertyName = "Referencia";

        private string _referencia;

        /// <summary>
        /// Sets and gets the Referencia property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Referencia
        {
            get
            {
                return _referencia;
            }

            set
            {
                if (_referencia == value)
                {
                    return;
                }

                _referencia = value;
                RaisePropertyChanged(ReferenciaPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoUltimaLecturaId

        /// <summary>
        /// The <see cref="CentroTrabajoUltimaLecturaId" /> property's name.
        /// </summary>
        public const string CentroTrabajoUltimaLecturaIdPropertyName = "CentroTrabajoUltimaLecturaId";

        private string _centroTrabajoUltimaLecturaId;

        /// <summary>
        /// Sets and gets the CentroTrabajoUltimaLecturaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoUltimaLecturaId
        {
            get
            {
                return _centroTrabajoUltimaLecturaId;
            }

            set
            {
                if (_centroTrabajoUltimaLecturaId == value)
                {
                    return;
                }

                _centroTrabajoUltimaLecturaId = value;
                RaisePropertyChanged(CentroTrabajoUltimaLecturaIdPropertyName);
            }
        }

        #endregion

        #region SiguienteLecturaTipo

        /// <summary>
        /// The <see cref="SiguienteLecturaTipo" /> property's name.
        /// </summary>
        public const string SiguienteLecturaTipoPropertyName = "SiguienteLecturaTipo";

        private string _siguienteLecturaTipo;

        /// <summary>
        /// Sets and gets the SiguienteLecturaTipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SiguienteLecturaTipo
        {
            get
            {
                return _siguienteLecturaTipo;
            }

            set
            {
                if (_siguienteLecturaTipo == value)
                {
                    return;
                }

                _siguienteLecturaTipo = value;
                RaisePropertyChanged(SiguienteLecturaTipoPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoSiguienteId

        /// <summary>
        /// The <see cref="CentroTrabajoSiguienteId" /> property's name.
        /// </summary>
        public const string CentroTrabajoSiguienteIdPropertyName = "CentroTrabajoSiguienteId";

        private string _centroTrabajoSiguienteId;

        /// <summary>
        /// Sets and gets the CentroTrabajoSiguienteId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string CentroTrabajoSiguienteId
        {
            get
            {
                return _centroTrabajoSiguienteId;
            }

            set
            {
                if (_centroTrabajoSiguienteId == value)
                {
                    return;
                }

                _centroTrabajoSiguienteId = value;
                RaisePropertyChanged(CentroTrabajoSiguienteIdPropertyName);
            }
        }

        #endregion

        #region EstadoLeyenda

        /// <summary>
        /// The <see cref="EstadoLeyenda" /> property's name.
        /// </summary>
        public const string EstadoLeyendaPropertyName = "EstadoLeyenda";

        private string _estadoLeyenda;

        /// <summary>
        /// Sets and gets the EstadoLeyenda property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string EstadoLeyenda
        {
            get
            {
                return _estadoLeyenda;
            }

            set
            {
                if (_estadoLeyenda == value)
                {
                    return;
                }

                _estadoLeyenda = value;
                RaisePropertyChanged(EstadoLeyendaPropertyName);
            }
        }

        #endregion

        public OrdenEstado Estado { get; set; }
        public List<PasoRuta> Ruta { get; set; }
        public CentroTrabajo CentroTrabajoUltimaLectura { get; set; }
        public CentroTrabajo CentroTrabajoSiguiente { get; set; }

        #endregion

        #region Methods

        public static async Task<List<OrdenProduccionExterno>> GetByUsuarioPlanta(string usuario)
        {
            try
            {
                using (_client = new OrdenProduccionExternoClient())
                {
                    var lista = await _client.GetByUsuarioPlantaAsync(usuario);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno / GetByUsuarioPlanta", exception);
            }
        }

        public static async Task SetEstado(short companiaId, short ordenAno, short ordenNumero, string estadoId)
        {
            try
            {
                using (_client = new OrdenProduccionExternoClient())
                {
                    await _client.SetEstadoAsync(companiaId, ordenAno, ordenNumero, estadoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno / SetEstado", exception);
            }
        }

        public static async Task GrabarLectura(short companiaId, short ordenAno, short ordenNumero,
            string centroTrabajoId, string tipo, string usuario)
        {
            try
            {
                using (_client = new OrdenProduccionExternoClient())
                {
                    await _client.GrabarLecturaAsync(companiaId, ordenAno, ordenNumero, centroTrabajoId, tipo, usuario);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno / GrabarLectura", exception);
            }
        }

        public static async Task SetEstadoEnviarIntermoda(short companiaId, short ordenAno, short ordenNumero)
        {
            try
            {
                using (_client = new OrdenProduccionExternoClient())
                {
                    await _client.SetEstadoEnviarIntermodaAsync(companiaId, ordenAno, ordenNumero);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionExterno / SetEstadoEnviarIntermoda", exception);
            }
        }
        
        private static OrdenProduccionExternoBusiness ClientToBusiness(OrdenProduccionExterno input)
        {
            var reg = new OrdenProduccionExternoBusiness
            {
                CompaniaId = input.CompaniaId,
                Ano = input.Ano,
                Numero = input.Numero,
                Patron = input.Patron,
                Variante = input.Variante,
                Tela = input.Tela,
                Lavado = input.Lavado,
                Color = input.Color,
                ColorDescripcion = input.ColorDescripcion,
                EstadoId = input.EstadoId,
                Cantidad = input.Cantidad,
                OrdenProduccion = input.OrdenProduccion,
                Referencia = input.Referencia,
                CentroTrabajoUltimaLecturaId = input.CentroTrabajoUltimaLecturaId,
                SiguienteLecturaTipo = input.SiguienteLecturaTipo,
                CentroTrabajoSiguienteId = input.CentroTrabajoSiguienteId,
                EstadoLeyenda = input.EstadoLeyenda,
                Estado = new OrdenEstadoBusiness
                {
                    Id = input.Estado.Id,
                    Secuencia = input.Estado.Secuencia,
                    Descripcion = input.Estado.Descripcion,
                    Area = input.Estado.Area,
                    CentroCostoAlias = input.Estado.CentroCostoAlias,
                    CentroTrabajoId = input.Estado.CentroTrabajoId
                },
                CentroTrabajoUltimaLectura = new CentroTrabajoBusiness
                {
                    CompaniaId = input.CentroTrabajoUltimaLectura.CompaniaId,
                    Id = input.CentroTrabajoUltimaLectura.Id,
                    Nombre = input.CentroTrabajoUltimaLectura.Nombre
                },
                CentroTrabajoSiguiente = new CentroTrabajoBusiness
                {
                    CompaniaId = input.CentroTrabajoSiguiente.CompaniaId,
                    Id = input.CentroTrabajoSiguiente.Id,
                    Nombre = input.CentroTrabajoSiguiente.Nombre
                }
            };
            var ruta = reg.Ruta.Select(paso => new PasoRutaBusiness
            {
                CompaniaId = paso.CompaniaId,
                Ano = paso.Ano,
                Numero = paso.Numero,
                CentroTrabajoId = paso.CentroTrabajoId,
                PlantaId = paso.PlantaId,
                Secuencia = paso.Secuencia
            }).ToList();
            reg.Ruta = ruta.ToArray();

            return reg;
        }

        private static OrdenProduccionExterno BusinessToClient(OrdenProduccionExternoBusiness input)
        {
            var centroTrabajoUltimaLectura = input.CentroTrabajoUltimaLectura == null
                ? null
                : new CentroTrabajo
                {
                    CompaniaId = input.CentroTrabajoUltimaLectura.CompaniaId,
                    Id = input.CentroTrabajoUltimaLectura.Id,
                    Nombre = input.CentroTrabajoUltimaLectura.Nombre
                };
            var centroTrabajoSiguiente = input.CentroTrabajoSiguiente == null
                ? null
                : new CentroTrabajo
                {
                    CompaniaId = input.CentroTrabajoSiguiente.CompaniaId,
                    Id = input.CentroTrabajoSiguiente.Id,
                    Nombre = input.CentroTrabajoSiguiente.Nombre
                };

            var estado = input.Estado == null
                ? null
                : new OrdenEstado
                {
                    Id = input.Estado.Id,
                    Secuencia = input.Estado.Secuencia,
                    Descripcion = input.Estado.Descripcion,
                    Area = input.Estado.Area,
                    CentroCostoAlias = input.Estado.CentroCostoAlias,
                    CentroTrabajoId = input.Estado.CentroTrabajoId
                };

            var ruta = input.Ruta.Any()
                ? input.Ruta.Select(paso => new PasoRuta
                {
                    CompaniaId = paso.CompaniaId,
                    Ano = paso.Ano,
                    Numero = paso.Numero,
                    CentroTrabajoId = paso.CentroTrabajoId,
                    PlantaId = paso.PlantaId,
                    Secuencia = paso.Secuencia
                }).ToList()
                : null;

            var reg = new OrdenProduccionExterno
            {
                CompaniaId = input.CompaniaId,
                Ano = input.Ano,
                Numero = input.Numero,
                Patron = input.Patron,
                Variante = input.Variante,
                Tela = input.Tela,
                Lavado = input.Lavado,
                Color = input.Color,
                ColorDescripcion = input.ColorDescripcion,
                EstadoId = input.EstadoId,
                Cantidad = input.Cantidad, 
                OrdenProduccion = input.OrdenProduccion,
                Referencia = input.Referencia,
                CentroTrabajoUltimaLecturaId = input.CentroTrabajoUltimaLecturaId,
                SiguienteLecturaTipo = input.SiguienteLecturaTipo,
                CentroTrabajoSiguienteId = input.CentroTrabajoSiguienteId,
                EstadoLeyenda = input.EstadoLeyenda,
                Estado = estado,
                CentroTrabajoUltimaLectura = centroTrabajoUltimaLectura,
                CentroTrabajoSiguiente = centroTrabajoSiguiente,
                Ruta = ruta
            };

            return reg;
        }

        #endregion
    }
}