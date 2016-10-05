using System.ServiceModel;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    [ServiceContract]
    public interface IMaquiladoCajaDetalle
    {
        [OperationContract]
        MaquiladoCajaDetalleBusiness Update(MaquiladoCajaDetalleBusiness model);

        [OperationContract]
        void Delete(int maquiladoCajaDetalleId);

        [OperationContract]
        MaquiladoCajaDetalleBusiness Get(int maquiladoCajaDetalleId);

        [OperationContract]
        MaquiladoCajaDetalleBusiness[] GetByMaquiladoCaja(int maquiladoCajaId);
    }
}
