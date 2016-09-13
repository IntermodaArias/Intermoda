using System;
using Intermoda.Business.Lavanderia;

namespace Intermoda.DataService.Lavanderia
{
    public class Catalogo : ICatalogo
    {
        public CatalogoBusiness Update(CatalogoBusiness catalogo)
        {
            try
            {
                return catalogo.Id == 0
                    ? CatalogoBusiness.Insert(catalogo)
                    : CatalogoBusiness.Update(catalogo);
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo/Update", exception);
            }
        }

        public void Delete(int catalogoId)
        {
            try
            {
                CatalogoBusiness.Delete(catalogoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo/Delete", exception);
            }
        }

        public CatalogoBusiness Get(int catalogoId)
        {
            try
            {
                return CatalogoBusiness.Get(catalogoId);
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo/Get", exception);
            }
        }

        public CatalogoBusiness[] GetAll()
        {
            try
            {
                return CatalogoBusiness.GetAll();
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo/GetAll", exception);
            }
        }

        public CatalogoBusiness GetByTela(string telaCodigo)
        {
            try
            {
                return CatalogoBusiness.GetByTela(telaCodigo);
            }
            catch (Exception exception)
            {
                throw new Exception("Catalogo / GetByTela", exception);
            }
        }
    }
}
