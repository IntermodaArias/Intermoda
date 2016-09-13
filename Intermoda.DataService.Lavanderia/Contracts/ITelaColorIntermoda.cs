using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ITelaColorIntermoda
    {
        [OperationContract]
        TelaColorIntermodaBusiness Update(TelaColorIntermodaBusiness telaColorIntermoda);

        [OperationContract]
        void Delete(int telaColorIntermodaId);

        [OperationContract]
        TelaColorIntermodaBusiness Get(int telaColorIntermodaId);

        [OperationContract]
        TelaColorIntermodaBusiness[] GetAll();

        [OperationContract]
        TelaColorIntermodaBusiness[] GetByColorIntermoda(int colorIntermodaId);
    }
}
