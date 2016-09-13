using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class Planta : IPlanta
    {
        public PlantaBusiness GetByUsuario(string usuario, string clave)
        {
            try
            {
                return PlantaBusiness.GetByUsuario(usuario, clave);
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / GetByUsuario", exception);
            }
        }

        public void UpdateClave(string plantaId, string claveOld, string claveNew)
        {
            try
            {
                PlantaBusiness.UdpateClave(plantaId, claveOld, claveNew);
            }
            catch (Exception exception)
            {
                throw new Exception("Planta / UpdateClave", exception);
            }
        }
    }
}
