using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ITela
    {
        [OperationContract]
        TelaBusiness Get(string telaCodigo);

        [OperationContract]
        TelaBusiness[] GetAll();

        [OperationContract]
        TelaBusiness[] GetCombo();

        [OperationContract]
        string GetComposicionCodigo(string telaCodigo);
    }
}
