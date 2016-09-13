using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Lavadora : ILavadora
    {
        public LavadoraBusiness Update(LavadoraBusiness lavadora)
        {
            return lavadora.Id == 0
                ? LavadoraBusiness.Insert(lavadora)
                : LavadoraBusiness.Update(lavadora);
        }

        public void Delete(int lavadoraId)
        {
            LavadoraBusiness.Delete(lavadoraId);
        }

        public LavadoraBusiness Get(int lavadoraId)
        {
            return LavadoraBusiness.Get(lavadoraId);
        }

        public LavadoraBusiness[] GetAll()
        {
            return LavadoraBusiness.GetAll();
        }

        public LavadoraBusiness[] GetByCapacidad(int lavadoraCapacidadId)
        {
            return LavadoraBusiness.GetByCapacidad(lavadoraCapacidadId);
        }
    }
}
