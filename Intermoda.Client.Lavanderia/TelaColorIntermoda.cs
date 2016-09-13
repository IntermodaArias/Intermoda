using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.TelaColorIntermodaServiceReference;

namespace Intermoda.Client.Lavanderia
{
    public class TelaColorIntermoda : ObservableObject
    {
        private static TelaColorIntermodaClient _client;

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

        #region ColorIntermodaId

        /// <summary>
        /// The <see cref="ColorIntermodaId" /> property's name.
        /// </summary>
        public const string ColorIntermodaIdPropertyName = "ColorIntermodaId";

        private int _colorIntermodaId;

        /// <summary>
        /// Sets and gets the ColorIntermodaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int ColorIntermodaId
        {
            get
            {
                return _colorIntermodaId;
            }

            set
            {
                if (_colorIntermodaId == value)
                {
                    return;
                }

                _colorIntermodaId = value;
                RaisePropertyChanged(ColorIntermodaIdPropertyName);
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

        #region MaterialId

        /// <summary>
        /// The <see cref="MaterialId" /> property's name.
        /// </summary>
        public const string MaterialIdPropertyName = "MaterialId";

        private int? _materialId;

        /// <summary>
        /// Sets and gets the MaterialId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int? MaterialId
        {
            get
            {
                return _materialId;
            }

            set
            {
                if (_materialId == value)
                {
                    return;
                }

                _materialId = value;
                RaisePropertyChanged(MaterialIdPropertyName);
            }
        }

        #endregion

        public ColorIntermoda ColorIntermoda { get; set; }

        public Tela Tela { get; set; }

        public Catalogo Catalogo { get; set; }

        #endregion

        #region Methods

        public static async Task<TelaColorIntermoda> Update(TelaColorIntermoda telaColorIntermoda)
        {
            try
            {
                using (_client = new TelaColorIntermodaClient())
                {
                    var reg = ClientToBusiness(telaColorIntermoda);

                    reg = await _client.UpdateAsync(reg);

                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / Update", exception);
            }
        }

        public static async Task Delete(int telaColorIntermodaId)
        {
            try
            {
                using (_client = new TelaColorIntermodaClient())
                {
                    await _client.DeleteAsync(telaColorIntermodaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / Delete", exception);
            }
        }

        public static async Task<TelaColorIntermoda> Get(int telaColorIntermodaId)
        {
            try
            {
                using (_client = new TelaColorIntermodaClient())
                {
                    var reg = await _client.GetAsync(telaColorIntermodaId);

                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / Get", exception);
            }
        }

        public static async Task<List<TelaColorIntermoda>> GetAll()
        {
            try
            {
                using (_client = new TelaColorIntermodaClient())
                {
                    var lista = await _client.GetAllAsync();

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / GetAll", exception);
            }
        }

        public static async Task<List<TelaColorIntermoda>> GetByColorIntermoda(int colorIntermodaId)
        {
            try
            {
                using (_client = new TelaColorIntermodaClient())
                {
                    var lista = await _client.GetByColorIntermodaAsync(colorIntermodaId);

                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / GetByColorIntermoda", exception);
            }
        }

        private static TelaColorIntermoda BusinessToClient(TelaColorIntermodaBusiness input)
        {
            return new TelaColorIntermoda
            {
                Id = input.Id,
                ColorIntermodaId = input.ColorIntermodaId,
                TelaId = input.TelaId,
                MaterialId = input.MaterialId,
                ColorIntermoda = new ColorIntermoda
                {
                    Id = input.ColorIntermoda.Id,
                    Nombre = input.ColorIntermoda.Nombre
                },
                Tela = new Tela
                {
                    TelaCodigo = input.Tela.TelaCodigo,
                    TelaNombre = input.Tela.TelaNombre,
                    ComposicionNombre = input.Tela.ComposicionNombre,
                    TelaDescripcion = input.Tela.TelaDescripcion
                },
                Catalogo = new Catalogo
                {
                    CuentaContableCodigo = input.Material.CuentaContableCodigo,
                    CuentaVariableFija = input.Material.CuentaVariableFija,
                    CuentaContableInventarioCodigo = input.Material.CuentaContableInventarioCodigo,
                    Descripcion = input.Material.Descripcion,
                    GrupoCodigo = input.Material.GrupoCodigo,
                    Id = input.Material.Id,
                    MedidaConsumoCodigo = input.Material.MedidaConsumoCodigo,
                    MedidaCompraCodigo = input.Material.MedidaCompraCodigo,
                    Nombre = input.Material.Nombre
                }
            };
        }

        private static TelaColorIntermodaBusiness ClientToBusiness(TelaColorIntermoda input)
        {
            return new TelaColorIntermodaBusiness
            {
                Id = input.Id,
                ColorIntermodaId = input.ColorIntermodaId,
                TelaId = input.TelaId,
                MaterialId = input.MaterialId,
                ColorIntermoda = new ColorIntermodaBusiness
                {
                    Id = input.ColorIntermoda.Id,
                    Nombre = input.ColorIntermoda.Nombre
                },
                Tela = new TelaBusiness
                {
                    TelaCodigo = input.Tela.TelaCodigo,
                    TelaNombre = input.Tela.TelaNombre,
                    ComposicionNombre = input.Tela.ComposicionNombre,
                    TelaDescripcion = input.Tela.TelaDescripcion
                },
                Material = new CatalogoBusiness
                {
                    CuentaContableCodigo = input.Catalogo.CuentaContableCodigo,
                    CuentaVariableFija = input.Catalogo.CuentaVariableFija,
                    CuentaContableInventarioCodigo = input.Catalogo.CuentaContableInventarioCodigo,
                    Descripcion = input.Catalogo.Descripcion,
                    GrupoCodigo = input.Catalogo.GrupoCodigo,
                    Id = input.Catalogo.Id,
                    MedidaConsumoCodigo = input.Catalogo.MedidaConsumoCodigo,
                    MedidaCompraCodigo = input.Catalogo.MedidaCompraCodigo,
                    Nombre = input.Catalogo.Nombre
                }
            };
        }

        #endregion
    }
}