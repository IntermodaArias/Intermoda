using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Clase : IClase
    {
        public ClaseBusiness Update(ClaseBusiness clase)
        {
            return clase.Codigo == ""
                ? ClaseBusiness.Insert(clase)
                : ClaseBusiness.Update(clase);
        }

        public void Delete(string claseCodigo)
        {
            ClaseBusiness.Delete(claseCodigo);
        }

        public ClaseBusiness Get(string claseCodigo)
        {
            return ClaseBusiness.Get(claseCodigo);
        }

        public ClaseBusiness[] GetAll()
        {
            return ClaseBusiness.GetAll();
        }
    }
}
