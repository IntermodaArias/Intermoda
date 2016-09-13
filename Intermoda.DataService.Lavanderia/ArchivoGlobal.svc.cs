using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class ArchivoGlobal : IArchivoGlobal
    {
        public ArchivoGlobalBusiness Update(ArchivoGlobalBusiness archivoGlobal)
        {
            try
            {
                return archivoGlobal.Id == 0
                    ? ArchivoGlobalBusiness.Insert(archivoGlobal)
                    : ArchivoGlobalBusiness.Update(archivoGlobal);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / Update", exception);
            }
        }

        public void Delete(int archivoGlobalId)
        {
            try
            {
                ArchivoGlobalBusiness.Delete(archivoGlobalId);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / Delete", exception);
            }
        }

        public ArchivoGlobalBusiness Get(int archivoGlobalId)
        {
            try
            {
                return ArchivoGlobalBusiness.Get(archivoGlobalId);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / Get", exception);
            }
        }

        public ArchivoGlobalBusiness[] GetAll()
        {
            try
            {
                return ArchivoGlobalBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / GetAll", exception);
            }
        }

        public ArchivoGlobalBusiness GetByPropietario(int propietarioId)
        {
            try
            {
                return ArchivoGlobalBusiness.GetByPropietario(propietarioId);
            }
            catch (Exception exception)
            {
                throw new Exception("ArchivoGlobal / GtByPropietario", exception);
            }
        }
    }
}
