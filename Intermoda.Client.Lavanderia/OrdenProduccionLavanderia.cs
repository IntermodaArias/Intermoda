using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.OrdenProduccionLavanderiaServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class OrdenProduccionLavanderia : ObservableObject
    {
        private static OrdenProduccionLavanderiaClient _client;

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

        #region PlantaId

        /// <summary>
        /// The <see cref="PlantaId" /> property's name.
        /// </summary>
        public const string PlantaIdPropertyName = "PlantaId";

        private int _plantaId;

        /// <summary>
        /// Sets and gets the PlantaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int PlantaId
        {
            get
            {
                return _plantaId;
            }

            set
            {
                if (_plantaId == value)
                {
                    return;
                }

                _plantaId = value;
                RaisePropertyChanged(PlantaIdPropertyName);
            }
        }

        #endregion

        #region CentroTrabajoId

        /// <summary>
        /// The <see cref="CentroTrabajoId" /> property's name.
        /// </summary>
        public const string CentroTrabajoIdPropertyName = "CentroTrabajoId";

        private int? _centroTrabajoId;

        /// <summary>
        /// Sets and gets the CentroTrabajoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? CentroTrabajoId
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

        private short _Numero;

        /// <summary>
        /// Sets and gets the Numero property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short Numero
        {
            get
            {
                return _Numero;
            }

            set
            {
                if (_Numero == value)
                {
                    return;
                }

                _Numero = value;
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

        #region LavadoCodigoOld

        /// <summary>
        /// The <see cref="LavadoCodigoOld" /> property's name.
        /// </summary>
        public const string LavadoCodigoOldPropertyName = "LavadoCodigoOld";

        private string _lavadoCodigoOld;

        /// <summary>
        /// Sets and gets the LavadoCodigoOld property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoCodigoOld
        {
            get
            {
                return _lavadoCodigoOld;
            }

            set
            {
                if (_lavadoCodigoOld == value)
                {
                    return;
                }

                _lavadoCodigoOld = value;
                RaisePropertyChanged(LavadoCodigoOldPropertyName);
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

        #region FechaInicioProgramada

        /// <summary>
        /// The <see cref="FechaInicioProgramada" /> property's name.
        /// </summary>
        public const string FechaInicioProgramadaPropertyName = "FechaInicioProgramada";

        private DateTime? _fechaInicioProgramada;

        /// <summary>
        /// Sets and gets the FechaInicioProgramada property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? FechaInicioProgramada
        {
            get
            {
                return _fechaInicioProgramada;
            }

            set
            {
                if (_fechaInicioProgramada == value)
                {
                    return;
                }

                _fechaInicioProgramada = value;
                RaisePropertyChanged(FechaInicioProgramadaPropertyName);
            }
        }

        #endregion

        #region FechaFinalProgramada

        /// <summary>
        /// The <see cref="FechaFinalProgramada" /> property's name.
        /// </summary>
        public const string FechaFinalProgramadaPropertyName = "FechaFinalProgramada";

        private DateTime? _fechaFinalProgramada;

        /// <summary>
        /// Sets and gets the FechaFinalProgramada property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime? FechaFinalProgramada
        {
            get
            {
                return _fechaFinalProgramada;
            }

            set
            {
                if (_fechaFinalProgramada == value)
                {
                    return;
                }

                _fechaFinalProgramada = value;
                RaisePropertyChanged(FechaFinalProgramadaPropertyName);
            }
        }

        #endregion

        #region TelaProduccionCodigo

        /// <summary>
        /// The <see cref="TelaProduccionCodigo" /> property's name.
        /// </summary>
        public const string TelaProduccionCodigoPropertyName = "TelaProduccionCodigo";

        private string _telaProduccionCodigo;

        /// <summary>
        /// Sets and gets the TelaProduccionCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaProduccionCodigo
        {
            get
            {
                return _telaProduccionCodigo;
            }

            set
            {
                if (_telaProduccionCodigo == value)
                {
                    return;
                }

                _telaProduccionCodigo = value;
                RaisePropertyChanged(TelaProduccionCodigoPropertyName);
            }
        }

        #endregion

        #region TelaVentaCodigo

        /// <summary>
        /// The <see cref="TelaVentaCodigo" /> property's name.
        /// </summary>
        public const string TelaVentaCodigoPropertyName = "TelaVentaCodigo";

        private string _telaVentaCodigo;

        /// <summary>
        /// Sets and gets the TelaVentaCodigo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaVentaCodigo
        {
            get
            {
                return _telaVentaCodigo;
            }

            set
            {
                if (_telaVentaCodigo == value)
                {
                    return;
                }

                _telaVentaCodigo = value;
                RaisePropertyChanged(TelaVentaCodigoPropertyName);
            }
        }

        #endregion

        #region Usuario

        /// <summary>
        /// The <see cref="Usuario" /> property's name.
        /// </summary>
        public const string UsuarioPropertyName = "Usuario";

        private string _usuario;

        /// <summary>
        /// Sets and gets the Usuario property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                if (_usuario == value)
                {
                    return;
                }

                _usuario = value;
                RaisePropertyChanged(UsuarioPropertyName);
            }
        }

        #endregion

        #region Cantidad

        /// <summary>
        /// The <see cref="Cantidad" /> property's name.
        /// </summary>
        public const string CantidadPropertyName = "Cantidad";

        private int? _cantidad;

        /// <summary>
        /// Sets and gets the Cantidad property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? Cantidad
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

        #region CantidadFinalEnsamble

        /// <summary>
        /// The <see cref="CantidadFinalEnsamble" /> property's name.
        /// </summary>
        public const string CantidadFinalEnsamblePropertyName = "CantidadFinalEnsamble";

        private int? _cantidadFinalEnsamble;

        /// <summary>
        /// Sets and gets the CantidadFinalEnsamble property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? CantidadFinalEnsamble
        {
            get
            {
                return _cantidadFinalEnsamble;
            }

            set
            {
                if (_cantidadFinalEnsamble == value)
                {
                    return;
                }

                _cantidadFinalEnsamble = value;
                RaisePropertyChanged(CantidadFinalEnsamblePropertyName);
            }
        }

        #endregion

        #region CantidadEntradaLavanderia2

        /// <summary>
        /// The <see cref="CantidadEntradaLavanderia2" /> property's name.
        /// </summary>
        public const string CantidadEntradaLavanderia2PropertyName = "CantidadEntradaLavanderia2";

        private int? _cantidadEntradaLavanderia2;

        /// <summary>
        /// Sets and gets the CantidadEntradaLavanderia2 property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? CantidadEntradaLavanderia2
        {
            get
            {
                return _cantidadEntradaLavanderia2;
            }

            set
            {
                if (_cantidadEntradaLavanderia2 == value)
                {
                    return;
                }

                _cantidadEntradaLavanderia2 = value;
                RaisePropertyChanged(CantidadEntradaLavanderia2PropertyName);
            }
        }

        #endregion

        #region CantidadPendiente

        /// <summary>
        /// The <see cref="CantidadPendiente" /> property's name.
        /// </summary>
        public const string CantidadPendientePropertyName = "CantidadPendiente";

        private int? _cantidadPendiente;

        /// <summary>
        /// Sets and gets the CantidadPendiente property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? CantidadPendiente
        {
            get
            {
                return _cantidadPendiente;
            }

            set
            {
                if (_cantidadPendiente == value)
                {
                    return;
                }

                _cantidadPendiente = value;
                RaisePropertyChanged(CantidadPendientePropertyName);
            }
        }

        #endregion

        #region LavadoId

        /// <summary>
        /// The <see cref="LavadoId" /> property's name.
        /// </summary>
        public const string LavadoIdPropertyName = "LavadoId";

        private int _lavadoId;

        /// <summary>
        /// Sets and gets the LavadoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int LavadoId
        {
            get
            {
                return _lavadoId;
            }

            set
            {
                if (_lavadoId == value)
                {
                    return;
                }

                _lavadoId = value;
                RaisePropertyChanged(LavadoIdPropertyName);
            }
        }

        #endregion

        #region LavadoNombre

        /// <summary>
        /// The <see cref="LavadoNombre" /> property's name.
        /// </summary>
        public const string LavadoNombrePropertyName = "LavadoNombre";

        private string _lavadoNombre;

        /// <summary>
        /// Sets and gets the LavadoNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LavadoNombre
        {
            get
            {
                return _lavadoNombre;
            }

            set
            {
                if (_lavadoNombre == value)
                {
                    return;
                }

                _lavadoNombre = value;
                RaisePropertyChanged(LavadoNombrePropertyName);
            }
        }

        #endregion

        #region PesoUnidad

        /// <summary>
        /// The <see cref="PesoUnidad" /> property's name.
        /// </summary>
        public const string PesoUnidadPropertyName = "PesoUnidad";

        private decimal _pesoUnidad;

        /// <summary>
        /// Sets and gets the PesoUnidad property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public decimal PesoUnidad
        {
            get
            {
                return _pesoUnidad;
            }

            set
            {
                if (_pesoUnidad == value)
                {
                    return;
                }

                _pesoUnidad = value;
                RaisePropertyChanged(PesoUnidadPropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static async Task<List<OrdenProduccionLavanderia>> Get(short companiaId, int plantaId,
            short centroTrabajoId)
        {
            try
            {
                using (_client = new OrdenProduccionLavanderiaClient())
                {
                    var lista = await _client.GetAsync(companiaId, plantaId, centroTrabajoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OrdenProduccionLavanderia / Get", exception);
            }
        }

        private static OrdenProduccionLavanderia BusinessToClient(OrdenProduccionLavanderiaBusiness input)
        {
            return new OrdenProduccionLavanderia
            {
                CompaniaId = input.CompaniaId,
                PlantaId = input.PlantaId,
                CentroTrabajoId = input.CentroTrabajoId,
                Ano = input.Ano,
                Numero = input.Numero,
                Patron = input.Patron,
                Variante = input.Variante,
                LavadoCodigoOld = input.LavadoCodigoOld,
                Estado = input.Estado,
                FechaInicioProgramada = input.FechaInicioProgramada,
                FechaFinalProgramada = input.FechaFinalProgramada,
                TelaProduccionCodigo = input.TelaProduccionCodigo,
                TelaVentaCodigo = input.TelaVentaCodigo,
                Usuario = input.Usuario,
                Cantidad = input.Cantidad,
                CantidadFinalEnsamble = input.CantidadFinalEnsamble,
                CantidadEntradaLavanderia2 = input.CantidadEntradaLavanderia2,
                CantidadPendiente = input.CantidadPendiente,
                LavadoId = input.LavadoId,
                LavadoNombre = input.LavadoNombre,
                PesoUnidad = input.PesoUnidad
            };
        }

        private static OrdenProduccionLavanderiaBusiness ClientToBusiness(OrdenProduccionLavanderia input)
        {
            return new OrdenProduccionLavanderiaBusiness
            {
                CompaniaId = input.CompaniaId,
                PlantaId = input.PlantaId,
                CentroTrabajoId = input.CentroTrabajoId,
                Ano = input.Ano,
                Numero = input.Numero,
                Patron = input.Patron,
                Variante = input.Variante,
                LavadoCodigoOld = input.LavadoCodigoOld,
                Estado = input.Estado,
                FechaInicioProgramada = input.FechaInicioProgramada,
                FechaFinalProgramada = input.FechaFinalProgramada,
                TelaProduccionCodigo = input.TelaProduccionCodigo,
                TelaVentaCodigo = input.TelaVentaCodigo,
                Usuario = input.Usuario,
                Cantidad = input.Cantidad,
                CantidadFinalEnsamble = input.CantidadFinalEnsamble,
                CantidadEntradaLavanderia2 = input.CantidadEntradaLavanderia2,
                CantidadPendiente = input.CantidadPendiente,
                LavadoId = input.LavadoId,
                LavadoNombre = input.LavadoNombre,
                PesoUnidad = input.PesoUnidad
            };
        }

        #endregion
    }
}