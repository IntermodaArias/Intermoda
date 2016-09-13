using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class LavadoraCapacidad : ILavadoraCapacidad
    {
        public LavadoraCapacidadBusiness Update(LavadoraCapacidadBusiness lavadoraCapacidad)
        {
            return lavadoraCapacidad.Id == 0
                ? LavadoraCapacidadBusiness.Insert(lavadoraCapacidad)
                : LavadoraCapacidadBusiness.Update(lavadoraCapacidad);
        }

        public void Delete(int lavadoraCapacidadId)
        {
            LavadoraCapacidadBusiness.Delete(lavadoraCapacidadId);
        }

        public LavadoraCapacidadBusiness Get(int lavadoraCapacidadId)
        {
            return LavadoraCapacidadBusiness.Get(lavadoraCapacidadId);
        }

        public LavadoraCapacidadBusiness[] GetAll()
        {
            return LavadoraCapacidadBusiness.GetAll();
        }
    }
}
