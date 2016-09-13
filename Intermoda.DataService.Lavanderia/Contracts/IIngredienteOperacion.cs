using System.ServiceModel;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    [ServiceContract]
    public interface IIngredienteOperacion
    {
        [OperationContract]
        IngredienteOperacionBusiness Update(IngredienteOperacionBusiness ingredienteOperacion);

        [OperationContract]
        void Delete(int ingredienteOperacionId);

        [OperationContract]
        IngredienteOperacionBusiness Get(int ingredienteOperacionId);

        [OperationContract]
        IngredienteOperacionBusiness[] GetAll();

        [OperationContract]
        IngredienteOperacionBusiness[] GetByIngrediente(int ingredienteId);

        [OperationContract]
        IngredienteOperacionBusiness[] GetByOperacion(int operacionId);

        [OperationContract]
        IngredienteOperacionBusiness[] GetByOperacionProceso(int operacionProcesoId);

        [OperationContract]
        IngredienteOperacionBusiness[] GetByClase(string claseId);

        [OperationContract]
        IngredienteOperacionBusiness[] GetBySubClase(string subClaseId);

        [OperationContract]
        IngredienteOperacionBusiness[] GetByInstruccionOperacion(int instruccionOperacionId);
    }
}
