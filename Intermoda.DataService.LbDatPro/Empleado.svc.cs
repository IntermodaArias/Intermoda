using System;
using Intermoda.Business.LbDatPro;

namespace Intermoda.DataService.LbDatPro
{
    public class Empleado : IEmpleado
    {
        public EmpleadoBusiness Get(short companiaCodigo, int empleadoId)
        {
            try
            {
                return EmpleadoBusiness.Get(companiaCodigo, empleadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.EmpleadoGet", exception);
            }
        }

        public EmpleadoBusiness[] GetAllActivos()
        {
            try
            {
                var lista = EmpleadoBusiness.GetAllActivos();
                return lista;
            }
            catch (Exception exception)
            {
                throw new Exception("DataService.EmpleadoGetAllActivos", exception);
            }
        }
    }
}