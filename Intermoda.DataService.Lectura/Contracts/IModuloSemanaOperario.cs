using System.ServiceModel;
using Intermoda.Business.Lecturas;

namespace Intermoda.DataService.Lectura
{
    [ServiceContract]
    public interface IModuloSemanaOperario
    {
        [OperationContract]
        ModuloSemanaOperarioBusiness Update(ModuloSemanaOperarioBusiness moduloSemanaOperario);

        [OperationContract]
        void Delete(int moduloSemanaOperarioId);

        [OperationContract]
        ModuloSemanaOperarioBusiness Get(int moduloSemanaOperarioId);

        [OperationContract]
        ModuloSemanaOperarioBusiness[] GetAll();

        [OperationContract]
        ModuloSemanaOperarioBusiness[] GetByModuloSemana(int moduloSemanaId);
    }
}
