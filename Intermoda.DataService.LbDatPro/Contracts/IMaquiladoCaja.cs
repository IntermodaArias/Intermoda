using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IMaquiladoCaja
    {
        [OperationContract]
        MaquiladoCajaBusiness Update(MaquiladoCajaBusiness model);

        [OperationContract]
        void Delete(int maquiladoCajaId);

        [OperationContract]
        MaquiladoCajaBusiness Get(int maquiladoCajaId);

        [OperationContract]
        MaquiladoCajaBusiness[] GetByOrden(short companiaId, short ordenAno, short ordenNumero);

        //

        [OperationContract]
        MaquiladoEmpaqueBusiness[] GetDetalleByOrden(short companiaId, short ordenAno, short ordenNumero);
    }
}
