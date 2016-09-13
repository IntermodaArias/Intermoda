using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface ICatalogo
    {
        [OperationContract]
        CatalogoBusiness Update(CatalogoBusiness catalogo);

        [OperationContract]
        void Delete(int catalogoId);

        [OperationContract]
        CatalogoBusiness Get(int catalogoId);

        [OperationContract]
        CatalogoBusiness[] GetAll();

        [OperationContract]
        CatalogoBusiness GetByTela(string telaCodigo);
    }
}
