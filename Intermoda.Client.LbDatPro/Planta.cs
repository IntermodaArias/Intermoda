using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.LbDatPro.PlantaServiceReference;

namespace Intermoda.Client.LbDatPro
{
    public class Planta : ObservableObject
    {
        private static PlantaClient _client;

        #region Properties

        #region Id

        /// <summary>
        /// The <see cref="Id" /> property's name.
        /// </summary>
        public const string IdPropertyName = "Id";

        private string _id;

        /// <summary>
        /// Sets and gets the Id property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Id
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

        #region Iniciales

        /// <summary>
        /// The <see cref="Iniciales" /> property's name.
        /// </summary>
        public const string InicialesPropertyName = "Iniciales";

        private string _iniciales;

        /// <summary>
        /// Sets and gets the Iniciales property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Iniciales
        {
            get
            {
                return _iniciales;
            }

            set
            {
                if (_iniciales == value)
                {
                    return;
                }

                _iniciales = value;
                RaisePropertyChanged(InicialesPropertyName);
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

        #region GeneraTicket

        /// <summary>
        /// The <see cref="GeneraTicket" /> property's name.
        /// </summary>
        public const string GeneraTicketPropertyName = "GeneraTicket";

        private string _generaTicket;

        /// <summary>
        /// Sets and gets the GeneraTicket property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string GeneraTicket
        {
            get
            {
                return _generaTicket;
            }

            set
            {
                if (_generaTicket == value)
                {
                    return;
                }

                _generaTicket = value;
                RaisePropertyChanged(GeneraTicketPropertyName);
            }
        }

        #endregion

        #region Tipo

        /// <summary>
        /// The <see cref="Tipo" /> property's name.
        /// </summary>
        public const string TipoPropertyName = "Tipo";

        private string _tipo;

        /// <summary>
        /// Sets and gets the Tipo property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Tipo
        {
            get
            {
                return _tipo;
            }

            set
            {
                if (_tipo == value)
                {
                    return;
                }

                _tipo = value;
                RaisePropertyChanged(TipoPropertyName);
            }
        }

        #endregion

        #region BodegaId

        /// <summary>
        /// The <see cref="BodegaId" /> property's name.
        /// </summary>
        public const string BodegaIdPropertyName = "BodegaId";

        private short? _bodegaId;

        /// <summary>
        /// Sets and gets the BodegaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? BodegaId
        {
            get
            {
                return _bodegaId;
            }

            set
            {
                if (_bodegaId == value)
                {
                    return;
                }

                _bodegaId = value;
                RaisePropertyChanged(BodegaIdPropertyName);
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

        #region Habilitar

        /// <summary>
        /// The <see cref="Habilitar" /> property's name.
        /// </summary>
        public const string HabilitarPropertyName = "Habilitar";

        private short? _habilitar;

        /// <summary>
        /// Sets and gets the Habilitar property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? Habilitar
        {
            get
            {
                return _habilitar;
            }

            set
            {
                if (_habilitar == value)
                {
                    return;
                }

                _habilitar = value;
                RaisePropertyChanged(HabilitarPropertyName);
            }
        }

        #endregion

        #region NuevoId

        /// <summary>
        /// The <see cref="NuevoId" /> property's name.
        /// </summary>
        public const string NuevoIdPropertyName = "NuevoId";

        private int? _nuevoId;

        /// <summary>
        /// Sets and gets the NuevoId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? NuevoId
        {
            get
            {
                return _nuevoId;
            }

            set
            {
                if (_nuevoId == value)
                {
                    return;
                }

                _nuevoId = value;
                RaisePropertyChanged(NuevoIdPropertyName);
            }
        }

        #endregion

        #region CompaniaId

        /// <summary>
        /// The <see cref="CompaniaId" /> property's name.
        /// </summary>
        public const string CompaniaIdPropertyName = "CompaniaId";

        private short? _companiaId;

        /// <summary>
        /// Sets and gets the CompaniaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? CompaniaId
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

        #region ProveedorId

        /// <summary>
        /// The <see cref="ProveedorId" /> property's name.
        /// </summary>
        public const string ProveedorIdPropertyName = "ProveedorId";

        private short? _proveedorId;

        /// <summary>
        /// Sets and gets the ProveedorId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public short? ProveedorId
        {
            get
            {
                return _proveedorId;
            }

            set
            {
                if (_proveedorId == value)
                {
                    return;
                }

                _proveedorId = value;
                RaisePropertyChanged(ProveedorIdPropertyName);
            }
        }

        #endregion

        #region ProveedorNombre

        /// <summary>
        /// The <see cref="ProveedorNombre" /> property's name.
        /// </summary>
        public const string ProveedorNombrePropertyName = "ProveedorNombre";

        private string _proveedorNombre;

        /// <summary>
        /// Sets and gets the ProveedorNombre property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ProveedorNombre
        {
            get
            {
                return _proveedorNombre;
            }

            set
            {
                if (_proveedorNombre == value)
                {
                    return;
                }

                _proveedorNombre = value;
                RaisePropertyChanged(ProveedorNombrePropertyName);
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

        #region Clave

        /// <summary>
        /// The <see cref="Clave" /> property's name.
        /// </summary>
        public const string ClavePropertyName = "Clave";

        private string _clave;

        /// <summary>
        /// Sets and gets the Clave property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Clave
        {
            get
            {
                return _clave;
            }

            set
            {
                if (_clave == value)
                {
                    return;
                }

                _clave = value;
                RaisePropertyChanged(ClavePropertyName);
            }
        }

        #endregion

        #endregion

        #region Methods

        public static Planta GetByUsuario(string usuario, string clave)
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    var reg = _client.GetByUsuario(usuario, clave);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetByUsuario", exception);
            }
        }

        public static List<Planta> GetContratistas()
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    var lista = _client.GetContratistas();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetByUsuario", exception);
            }
        }

        public static void UpdateClave(string plantaId, string claveOld, string claveNew)
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    _client.UpdateClave(plantaId, claveOld, claveNew);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / UpdateClave", exception);
            }
        }
        
        private static PlantaBusiness ClientToBusiness(Planta input)
        {
            return new PlantaBusiness
            {
                Id = input.Id,
                Iniciales = input.Iniciales,
                Descripcion = input.Descripcion,
                GeneraTicket = input.GeneraTicket,
                Tipo = input.Tipo,
                BodegaId = input.BodegaId,
                Estado = input.Estado,
                Habilitar = input.Habilitar,
                NuevoId = input.NuevoId,
                CompaniaId = input.CompaniaId,
                ProveedorId = input.ProveedorId,
                ProveedorNombre = input.ProveedorNombre,
                Usuario = input.Usuario,
                Clave = input.Clave
            };
        }

        private static Planta BusinessToClient(PlantaBusiness input)
        {
            return new Planta
            {
                Id = input.Id,
                Iniciales = input.Iniciales,
                Descripcion = input.Descripcion,
                GeneraTicket = input.GeneraTicket,
                Tipo = input.Tipo,
                BodegaId = input.BodegaId,
                Estado = input.Estado,
                Habilitar = input.Habilitar,
                NuevoId = input.NuevoId,
                CompaniaId = input.CompaniaId,
                ProveedorId = input.ProveedorId,
                ProveedorNombre = input.ProveedorNombre,
                Usuario = input.Usuario,
                Clave = input.Clave
            };
        }

        #endregion
    }
}