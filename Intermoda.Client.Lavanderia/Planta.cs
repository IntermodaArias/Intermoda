using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using Intermoda.ClientProxy.Lavanderia.PlantaServiceReference;

namespace Intermoda.Client.Lavanderia
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

        #region Observacion

        /// <summary>
        /// The <see cref="Observacion" /> property's name.
        /// </summary>
        public const string ObservacionPropertyName = "Observacion";

        private string _observacion;

        /// <summary>
        /// Sets and gets the Observacion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Observacion
        {
            get
            {
                return _observacion;
            }

            set
            {
                if (_observacion == value)
                {
                    return;
                }

                _observacion = value;
                RaisePropertyChanged(ObservacionPropertyName);
            }
        }

        #endregion

        #region Propietaria

        /// <summary>
        /// The <see cref="Propietaria" /> property's name.
        /// </summary>
        public const string PropietariaPropertyName = "Propietaria";

        private bool _propietaria;

        /// <summary>
        /// Sets and gets the Propietaria property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool Propietaria
        {
            get
            {
                return _propietaria;
            }

            set
            {
                if (_propietaria == value)
                {
                    return;
                }

                _propietaria = value;
                RaisePropertyChanged(PropietariaPropertyName);
            }
        }

        #endregion

        #region CompaniaId

        /// <summary>
        /// The <see cref="CompaniaId" /> property's name.
        /// </summary>
        public const string CompaniaIdPropertyName = "CompaniaId";

        private int _companiaId;

        /// <summary>
        /// Sets and gets the CompaniaId property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int CompaniaId
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

        #endregion

        #region Methods

        public static async Task<Planta> Update(Planta model)
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    var reg = ClientToBusiness(model);
                    reg = await _client.UpdateAsync(reg);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / Update", exception);
            }
        }

        public static async Task Delete(int plantaId)
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    await _client.DeleteAsync(plantaId);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / Delete", exception);
            }
        }

        public static async Task<Planta> Get(int plantaId)
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    var reg = await _client.GetAsync(plantaId);
                    return BusinessToClient(reg);
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / Get", exception);
            }
        }

        public static async Task<List<Planta>> GetAll()
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    var lista = await _client.GetAllAsync();
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetAll", exception);
            }
        }
        public static async Task<List<Planta>> GetByCompania(int companiaId = 1)
        {
            try
            {
                using (_client = new PlantaClient())
                {
                    var lista = await _client.GetByCompaniaAsync(companiaId);
                    return lista.Select(BusinessToClient).ToList();
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetByCompania", exception);
            }
        }

        private static Planta BusinessToClient(PlantaBusiness input)
        {
            return new Planta
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Observacion = input.Observacion,
                Propietaria = input.Propietaria,
                CompaniaId = input.CompaniaId
            };
        }

        private static PlantaBusiness ClientToBusiness(Planta input)
        {
            return new PlantaBusiness
            {
                Id = input.Id,
                Nombre = input.Nombre,
                Observacion = input.Observacion,
                Propietaria = input.Propietaria,
                CompaniaId = input.CompaniaId
            };
        }

        #endregion
    }
}