using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class SubClase : ISubClase
    {
        public SubClaseBusiness Update(SubClaseBusiness subClase)
        {
            return subClase.Codigo == ""
                ? SubClaseBusiness.Insert(subClase)
                : SubClaseBusiness.Update(subClase);
        }

        public void Delete(string subClaseCodigo)
        {
            SubClaseBusiness.Delete(subClaseCodigo);
        }

        public SubClaseBusiness Get(string subClaseCodigo)
        {
            return SubClaseBusiness.Get(subClaseCodigo);
        }

        public SubClaseBusiness[] GetAll()
        {
            return SubClaseBusiness.GetAll();
        }
    }
}
