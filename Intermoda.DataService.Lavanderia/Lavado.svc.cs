using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Lavado : ILavado
    {
        public LavadoBusiness Update(LavadoBusiness lavado)
        {
            try
            {
                return lavado.LavadoId == 0 ? LavadoBusiness.Insert(lavado) : LavadoBusiness.Update(lavado);
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Update", exception);
            }
        }

        public void Delete(int lavadoId)
        {
            try
            {
                LavadoBusiness.Delete(lavadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Delete", exception);
            }
        }

        public LavadoBusiness Get(int lavadoId)
        {
            try
            {
                return LavadoBusiness.Get(lavadoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / Get", exception);
            }
        }

        public LavadoBusiness[] GetAll()
        {
            try
            {
                return LavadoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / GetAll", exception);
            }
        }

        public LavadoBusiness GetByNombre(string lavadoNombre)
        {
            try
            {
                return LavadoBusiness.GetByNombre(lavadoNombre);
            }
            catch (Exception exception)
            {
                throw new Exception("Lavado / GetByNombre", exception);
            }
        }
    }
}
