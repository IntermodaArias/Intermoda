using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class TelaColorIntermoda : ITelaColorIntermoda
    {
        public TelaColorIntermodaBusiness Update(TelaColorIntermodaBusiness telaColorIntermoda)
        {
            try
            {
                return telaColorIntermoda.Id == 0
                    ? TelaColorIntermodaBusiness.Insert(telaColorIntermoda)
                    : TelaColorIntermodaBusiness.Update(telaColorIntermoda);
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / Update", exception);
            }
        }

        public void Delete(int telaColorIntermodaId)
        {
            try
            {
                TelaColorIntermodaBusiness.Delete(telaColorIntermodaId);
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / Delete", exception);
            }
        }

        public TelaColorIntermodaBusiness Get(int telaColorIntermodaId)
        {
            try
            {
                return TelaColorIntermodaBusiness.Get(telaColorIntermodaId);
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / Get", exception);
            }
        }

        public TelaColorIntermodaBusiness[] GetAll()
        {
            try
            {
                return TelaColorIntermodaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / GetAll", exception);
            }
        }

        public TelaColorIntermodaBusiness[] GetByColorIntermoda(int colorIntermodaId)
        {
            try
            {
                return TelaColorIntermodaBusiness.GetByColorIntermoda(colorIntermodaId);
            }
            catch (Exception exception)
            {
                throw new Exception("TelaColorIntermoda / GetByColorIntermoda", exception);
            }
        }
    }
}
