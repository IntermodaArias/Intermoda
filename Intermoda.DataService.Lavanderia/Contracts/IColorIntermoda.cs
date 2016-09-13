using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IColorIntermoda
    {
        [OperationContract]
        ColorIntermodaBusiness Update(ColorIntermodaBusiness colorIntermoda);

        [OperationContract]
        void Delete(int colorIntermodaId);

        [OperationContract]
        ColorIntermodaBusiness Get(int colorIntermodaId);

        [OperationContract]
        ColorIntermodaBusiness[] GetAll();
    }
}
