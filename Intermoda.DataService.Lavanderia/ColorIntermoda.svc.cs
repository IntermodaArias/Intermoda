using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class ColorIntermoda : IColorIntermoda
    {
        public ColorIntermodaBusiness Update(ColorIntermodaBusiness colorIntermoda)
        {
            try
            {
                return colorIntermoda.Id == 0
                    ? ColorIntermodaBusiness.Insert(colorIntermoda)
                    : ColorIntermodaBusiness.Update(colorIntermoda);
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / Update", exception);
            }
        }

        public void Delete(int colorIntermodaId)
        {
            try
            {
                ColorIntermodaBusiness.Delete(colorIntermodaId);
                ;
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / Delete", exception);
            }
        }

        public ColorIntermodaBusiness Get(int colorIntermodaId)
        {
            try
            {
                return ColorIntermodaBusiness.Get(colorIntermodaId);
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / Get", exception);
            }
        }

        public ColorIntermodaBusiness[] GetAll()
        {
            try
            {
                return ColorIntermodaBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ColorIntermoda / GetAll", exception);
            }
        }
    }
}
