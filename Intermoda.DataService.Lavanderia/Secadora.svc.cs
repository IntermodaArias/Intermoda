using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Secadora : ISecadora
    {
        public SecadoraBusiness Update(SecadoraBusiness secadora)
        {
            return secadora.Id == 0
                ? SecadoraBusiness.Insert(secadora)
                : SecadoraBusiness.Update(secadora);
        }

        public void Delete(int secadoraId)
        {
            SecadoraBusiness.Delete(secadoraId);
        }

        public SecadoraBusiness Get(int secadoraId)
        {
            return SecadoraBusiness.Get(secadoraId);
        }

        public SecadoraBusiness[] GetAll()
        {
            return SecadoraBusiness.GetAll();
        }

        public SecadoraBusiness[] GetByCapacidad(int secadoraCapacidadId)
        {
            return SecadoraBusiness.GetByCapacidad(secadoraCapacidadId);
        }
    }
}
