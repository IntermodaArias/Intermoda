using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class SecadoraCapacidad : ISecadoraCapacidad
    {
        public SecadoraCapacidadBusiness Update(SecadoraCapacidadBusiness secadoraCapacidad)
        {
            return secadoraCapacidad.Id == 0
                ? SecadoraCapacidadBusiness.Insert(secadoraCapacidad)
                : SecadoraCapacidadBusiness.Update(secadoraCapacidad);
        }

        public void Delete(int secadoraCapacidadId)
        {
            SecadoraCapacidadBusiness.Delete(secadoraCapacidadId);
        }

        public SecadoraCapacidadBusiness Get(int secadoraCapacidadId)
        {
            return SecadoraCapacidadBusiness.Get(secadoraCapacidadId);
        }

        public SecadoraCapacidadBusiness[] GetAll()
        {
            return SecadoraCapacidadBusiness.GetAll();
        }
    }
}
