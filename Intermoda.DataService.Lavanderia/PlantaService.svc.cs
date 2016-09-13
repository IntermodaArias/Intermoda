using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Planta : IPlanta
    {
        public PlantaBusiness Update(PlantaBusiness planta)
        {
            try
            {
                return planta.Id == 0 ? PlantaBusiness.Insert(planta) : PlantaBusiness.Update(planta);
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / Update", exception);
            }
        }

        public void Delete(int plantaId)
        {
            try
            {
                PlantaBusiness.Delete(plantaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / Delete", exception);
            }
        }

        public PlantaBusiness Get(int plantaId)
        {
            try
            {
                return PlantaBusiness.Get(plantaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / Get", exception);
            }
        }

        public PlantaBusiness[] GetAll()
        {
            try
            {
                return PlantaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetAll", exception);
            }
        }

        public PlantaBusiness[] GetByCompania(int companiaId = 1)
        {
            try
            {
                return PlantaBusiness.GetbyCompania(companiaId);
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetByCompania", exception);
            }
        }
    }
}
