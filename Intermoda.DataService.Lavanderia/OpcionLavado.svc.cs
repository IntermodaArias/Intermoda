using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class OpcionLavado : IOpcionLavado
    {
        public OpcionLavadoBusiness Update(OpcionLavadoBusiness opcionLavado)
        {
            try
            {
                return opcionLavado.Id == 0
                    ? OpcionLavadoBusiness.Insert(opcionLavado)
                    : OpcionLavadoBusiness.Update(opcionLavado);
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / Update", exception);
            }
        }

        public void Delete(int opcionLavadoId)
        {
            try
            {
                OpcionLavadoBusiness.Delete(opcionLavadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / Delete", exception);
            }
        }

        public OpcionLavadoBusiness Get(int opcionLavadoId)
        {
            try
            {
                return OpcionLavadoBusiness.Get(opcionLavadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / Get", exception);
            }
        }

        public OpcionLavadoBusiness[] GetAll()
        {
            try
            {
                return OpcionLavadoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / GetAll", exception);
            }
        }

        public OpcionLavadoBusiness[] GetByLavado(int lavadoId)
        {
            try
            {
                return OpcionLavadoBusiness.GetByLavado(lavadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / GetByLavado", exception);
            }
        }

        public OpcionLavadoBusiness[] GetByTela(string telaId)
        {
            try
            {
                return OpcionLavadoBusiness.GetByTela(telaId);
            }
            catch (Exception exception)
            {
                throw new Exception("OpcionLavado / GetByTela", exception);
            }
        }
    }
}
