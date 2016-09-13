using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.OpcionLavadoServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class OpcionLavado : ObservableObject
    {
        private static OpcionLavadoClient _client;

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

        #region TelaId

        /// <summary>
        /// The <see cref="TelaId" /> property's name.
        /// </summary>
        public const string TelaIdPropertyName = "TelaId";

        private string _telaId;

        /// <summary>
        /// Sets and gets the TelaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string TelaId
        {
            get
            {
                return _telaId;
            }

            set
            {
                if (_telaId == value)
                {
                    return;
                }

                _telaId = value;
                RaisePropertyChanged(TelaIdPropertyName);
            }
        }

        #endregion

        #region IsDefault

        /// <summary>
        /// The <see cref="IsDefault" /> property's name.
        /// </summary>
        public const string IsDefaultPropertyName = "IsDefault";

        private int _isDefault;

        /// <summary>
        /// Sets and gets the IsDefault property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int IsDefault
        {
            get
            {
                return _isDefault;
            }

            set
            {
                if (_isDefault == value)
                {
                    return;
                }

                _isDefault = value;
                RaisePropertyChanged(IsDefaultPropertyName);
            }
        }

        #endregion

        public Lavado Lavado { get; set; }

        public Tela Tela { get; set; }

        #endregion

        #region Methods

        public static async Task<OpcionLavado> Update(OpcionLavado opcionLavado)
        {
            try
            {
                using (_client = new OpcionLavadoClient())
                {
                    var reg = ClientToBusiness(opcionLavado);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / Update", exception);
            }
        }

        public static async Task Delete(int opcionLavadoId)
        {
            try
            {
                using (_client = new OpcionLavadoClient())
                {
                    await _client.DeleteAsync(opcionLavadoId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / Delete", exception);
            }
        }

        public static async Task<OpcionLavado> Get(int opcionLavadoId)
        {
            try
            {
                using (_client = new OpcionLavadoClient())
                {
                    var reg = await _client.GetAsync(opcionLavadoId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / Get", exception);
            }
        }

        public static async Task<List<OpcionLavado>> GetAll()
        {
            try
            {
                using (_client = new OpcionLavadoClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / GetAll", exception);
            }
        }

        public static async Task<List<OpcionLavado>> GetByLavado(int lavadoId)
        {
            try
            {
                using (_client = new OpcionLavadoClient())
                {
                    var lista = await _client.GetByLavadoAsync(lavadoId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / GetByLavado", exception);
            }
        }

        public static async Task<List<OpcionLavado>> GetByTela(string telaId)
        {
            try
            {
                using (_client = new OpcionLavadoClient())
                {
                    var lista = await _client.GetByTelaAsync(telaId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / GetByTela", exception);
            }
        }

        private static OpcionLavado BusinessToClient(OpcionLavadoBusiness input)
        {
            return new OpcionLavado
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                LavadoId = input.LavadoId,
                TelaId = input.TelaId,
                IsDefault = input.IsDefault,
                Lavado = new Lavado
                {
                    LavadoId = input.Lavado.LavadoId,
                    ColorId = input.Lavado.ColorId,
                    ColorIntermoda = new ColorIntermoda
                    {
                        Id = input.Lavado.ColorIntermoda.Id,
                        Nombre = input.Lavado.ColorIntermoda.Nombre
                    },
                    EsActivo = input.Lavado.IsActivo,
                    LavadoDescripcion = input.Lavado.LavadoDescripcion,
                    LavadoNombre = input.Lavado.LavadoNombre,
                    LavadoFechaActualizacion = input.Lavado.LavadoFechaActualizacion,
                    LavadoFechaCreacion = input.Lavado.LavadoFechaCreacion
                },
                Tela = new Tela
                {
                    TelaCodigo = input.Tela.TelaCodigo,
                    ComposicionNombre = input.Tela.ComposicionNombre,
                    MaterialCodigo = input.Tela.MaterialCodigo,
                    TelaDescripcion = input.Tela.TelaDescripcion,
                    TelaNombre = input.Tela.TelaNombre
                }
            };
        }

        private static OpcionLavadoBusiness ClientToBusiness(OpcionLavado input)
        {
            return new OpcionLavadoBusiness
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Descripcion = input.Descripcion,
                LavadoId = input.LavadoId,
                TelaId = input.TelaId,
                IsDefault = input.IsDefault,
                Lavado = new LavadoBusiness
                {
                    LavadoId = input.Lavado.LavadoId,
                    ColorId = input.Lavado.ColorId,
                    ColorIntermoda = new ColoresIntermodaBusiness
                    {
                        Id = input.Lavado.ColorIntermoda.Id,
                        Nombre = input.Lavado.ColorIntermoda.Nombre
                    },
                    IsActivo = input.Lavado.EsActivo,
                    LavadoDescripcion = input.Lavado.LavadoDescripcion,
                    LavadoNombre = input.Lavado.LavadoNombre,
                    LavadoFechaActualizacion = input.Lavado.LavadoFechaActualizacion,
                    LavadoFechaCreacion = input.Lavado.LavadoFechaCreacion,
                },
                Tela = new TelaBusiness
                {
                    TelaCodigo = input.Tela.TelaCodigo,
                    ComposicionNombre = input.Tela.ComposicionNombre,
                    MaterialCodigo = input.Tela.MaterialCodigo,
                    TelaDescripcion = input.Tela.TelaDescripcion,
                    TelaNombre = input.Tela.TelaNombre
                }
            };
        }

        #endregion
    }
}