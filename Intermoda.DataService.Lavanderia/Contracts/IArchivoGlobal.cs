using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IArchivoGlobal
    {
        [OperationContract]
        ArchivoGlobalBusiness Update(ArchivoGlobalBusiness archivoGlobal);

        [OperationContract]
        void Delete(int archivoGlobalId);

        [OperationContract]
        ArchivoGlobalBusiness Get(int archivoGlobalId);

        [OperationContract]
        ArchivoGlobalBusiness[] GetAll();

        [OperationContract]
        ArchivoGlobalBusiness GetByPropietario(int propietarioId);
    }
}
